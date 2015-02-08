using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Xml;

namespace Account.Components
{
    public partial class MenuStripEnhanced : MenuStrip
    {
        public MenuStripEnhanced()
        {
            InitializeComponent();
        }

        private object m_form;
        [ToolboxItem( "Extended" ), Category( "Extended" ), Description("The Form that the MenuStrip is attached to.")]
        public object Form
        {
            get { return m_form; }
            set { m_form = value; }
        }

        private string m_xmlPath;
        [ToolboxItem("Extended"), Category("Extended"), Description("The path to the Menu XML configuration file.")]
        public string XmlPath
        {
            get { return m_xmlPath; }
            set { m_xmlPath = value; }
        }

        public void LoadDynamicMenu()
        {
            string xmlPath;

            if ( System.IO.Path.IsPathRooted( XmlPath ) )
                xmlPath = XmlPath;
            else
                xmlPath = Application.StartupPath + XmlPath;

            if ( System.IO.File.Exists( XmlPath ) )
            {

                XmlDocument document = new XmlDocument();
                document.Load( XmlPath );

                XmlElement element = document.DocumentElement;

                foreach ( XmlNode node in document.FirstChild.ChildNodes )
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();

                    menuItem.Name = node.Attributes["Name"].Value;
                    menuItem.Text = node.Attributes["Text"].Value;

                    this.Items.Add( menuItem );
                    GenerateMenusFromXML( node, (ToolStripMenuItem)this.Items[this.Items.Count - 1] );
                }
            }
        }

        private void GenerateMenusFromXML( XmlNode rootNode, ToolStripMenuItem menuItem )
        {
            ToolStripItem item = null;
            ToolStripSeparator separator = null;

            foreach ( XmlNode node in rootNode.ChildNodes )
            {
                if ( node.Attributes["Text"].Value == "-" )
                {
                    separator = new ToolStripSeparator();

                    menuItem.DropDownItems.Add( separator );
                }
                else
                {
                    item = new ToolStripMenuItem();
                    item.Name = node.Attributes["Name"].Value;
                    item.Text = node.Attributes["Text"].Value;

                    menuItem.DropDownItems.Add( item );

                    if ( node.Attributes["FormLocation"] != null )
                        item.Tag = node.Attributes["FormLocation"].Value;

                    // add an event handler to the menu item added
                    if ( node.Attributes["OnClick"] != null )
                    {
                        FindEventsByName( item, this.Form, true, "MenuItemOn", node.Attributes["OnClick"].Value );
                    }

                    GenerateMenusFromXML( node, (ToolStripMenuItem)menuItem.DropDownItems[menuItem.DropDownItems.Count - 1] );
                }
            }
        }

        private void FindEventsByName( object sender, object receiver, bool bind, string handlerPrefix, string handlerSuffix )
        {
            System.Reflection.EventInfo[] SenderEvent = sender.GetType().GetEvents();
            Type ReceiverType = receiver.GetType();
            System.Reflection.MethodInfo method;

            foreach ( System.Reflection.EventInfo e in SenderEvent )
            {
                method = ReceiverType.GetMethod( string.Format( "{0}{1}{2}", handlerPrefix, e.Name, handlerSuffix ), System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );

                if ( method != null )
                {

                    System.Delegate d = System.Delegate.CreateDelegate( e.EventHandlerType, receiver, method.Name );

                    if ( bind )
                        e.AddEventHandler( sender, d );
                    else
                        e.RemoveEventHandler( sender, d );
                }
            }
        }
    }
}