using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.Serialization;
using System.ServiceModel;

using System.Text;
using System.Diagnostics;
using System.Xml;
using Account.Common.Entities;
using Account.Common.Utilities;
using log4net;

using Account.Business;


namespace Account.Host
{
    
    public class ServiceTest
    {
        XmlDocument doc;
        xml_response res;
        public xml_response Response
        { get { return res; } }
        public ServiceTest(XmlDocument _doc)
        {
            if (_doc != null)
            { doc = _doc; }
            else
            { throw new Exception("Invalid parameters"); }
            Analysis();
        }
        private void Analysis()
        {
            res = new xml_response();
            res.function_name = this.ToString() + ".Analysis()";
            try
            {
                string cmdstr = doc.SelectSingleNode("//request/function_name").InnerText;
                switch (cmdstr.ToLower())
                {
                    case "createaccountrole":
                        CreateRole();
                        break;
                    case "checkaccountbalance":
                        if (!CheckAccountBalance())
                        { res.SetError("61", "Invalid balance day"); }
                        break;
                }
            }
            catch (Exception ex)
            { res.SetError("99", ex.Message); }
        }
        private void CreateRole()
        {
            AccountRoles_Info ari = new AccountRoles_Info();
            ari.Name = doc.SelectSingleNode("//request/name").InnerText;
            ari.Type = (AccountRoleType)Enum.Parse(typeof(AccountRoleType), doc.SelectSingleNode("//request/type").InnerText);
            ari.Operator = (OperatorType)Enum.Parse(typeof(OperatorType), doc.SelectSingleNode("//request/operation").InnerText);
            ari.Seq = int.Parse(doc.SelectSingleNode("//request/seq").InnerText);
            ari.UserCreated = "sa";
            ari.Value = Decimal.Parse(doc.SelectSingleNode("//request/value").InnerText);
            ari.Last_Update = DateTime.Now;
            ari.Active = true;
            ari.Active_Date = DateTime.Now;
            ari.Account_ID = doc.SelectSingleNode("//request/account_id").InnerText;
            ari.CreateDate = DateTime.Now;
            BaseRole baseRole = new BaseRole();
            baseRole.CreateRole(ari);
        }
        private bool CheckAccountBalance()
        {
            //EndOfDay eod = new EndOfDay();
            //return eod.CheckAccountBalance();
            return true;
        }
    }
}
