using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    public partial class frmChannelList : Form
    {
        private static frmChannelList m_CurrentInstance = null;
        public static frmChannelList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmChannelList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmChannelList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();
        public static List<Account.Common.Entities.Channel_Info> lstChannelInfo = new List<Account.Common.Entities.Channel_Info>();
        public static Account.Common.Entities.Channel_Info oSelectedChannel = null;

        public frmChannelList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void frmChannelList_Load(object sender, EventArgs e)
        {
            Program.GetAll_Branch();
            lstChannelInfo = Account.UIProviders.UIChannels.GetAll();
            Create_DataSource_Table();
            SetDataSource();
        }

        private void frmChannelList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            oSelectedChannel = Find_Channel(Convert.ToInt32(gridView1.GetFocusedRowCellValue(gcolID).ToString()));
            if (oSelectedChannel == null) return;
            frmChannel ofrm = new frmChannel();
            ofrm.ShowDialog();
            SetDataSource();
        }        

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        
        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("ID");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("Service_port");
            dtTemp.Columns.Add("ISO_Port");
            dtTemp.Columns.Add("Listener_host");
            dtTemp.Columns.Add("BranchID");
            dtTemp.Columns.Add("Curency_Code");
            dtTemp.Columns.Add("Security");
            dtTemp.Columns.Add("Private_Key");
            dtTemp.Columns.Add("Descript");

            dtTemp.Columns["ID"].DataType = System.Type.GetType("System.Int32");
            dtTemp.Columns["Service_port"].DataType = System.Type.GetType("System.Int32");
            dtTemp.Columns["ISO_Port"].DataType = System.Type.GetType("System.Int32");         

            gcolID.FieldName = "ID";
            gcolName.FieldName = "Name";            
            gcolServicePort.FieldName = "Service_port";
            gcolListennerPort.FieldName = "ISO_Port";
            gcolListennerHost.FieldName = "Listener_host";
            gcolBranchID.FieldName = "BranchID";
            gcolCcy.FieldName = "Curency_Code";
            gcolSecurity.FieldName = "Security";
            gcolKey.FieldName = "Private_Key";
            gcolDescription.FieldName = "Descript";            
        }

        private void SetDataSource()
        {
            if (lstChannelInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();
            Account.Common.Entities.Branches_Info oBranch = null;
            for (int i = 0; i < lstChannelInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["ID"] = lstChannelInfo[i].ID;
                oRow["Name"] = lstChannelInfo[i].Name;
                oRow["Service_port"] = lstChannelInfo[i].Service_Port;
                oRow["ISO_Port"] = lstChannelInfo[i].ISO_Port;
                oRow["Listener_host"] = lstChannelInfo[i].Listener_Host;
                oRow["BranchID"] = lstChannelInfo[i].Branch;
                oRow["Curency_Code"] = lstChannelInfo[i].Currency_Code;
                oRow["Security"] = lstChannelInfo[i].Security;
                oRow["Private_Key"] = lstChannelInfo[i].Key;
                oRow["Descript"] = lstChannelInfo[i].Descript;
                dtTemp.Rows.Add(oRow);
            }

            grdCtrlAccountGL.DataSource = null;
            grdCtrlAccountGL.DataSource = dtTemp;
        }
              

        private Account.Common.Entities.Channel_Info Find_Channel(int ID)
        {
            for (int i = 0; i < lstChannelInfo.Count; i++)
            {
                if (lstChannelInfo[i].ID == ID) return lstChannelInfo[i];
            }
            return null;
        }
    }
}

