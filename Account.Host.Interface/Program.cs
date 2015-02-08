using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Account.Host.Interface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin frmlogin = new frmLogin();
            Application.Run(frmlogin);
            if (frmlogin.DialogResult == DialogResult.OK)
            {
                m_frmMain = new frmMain();
                Application.Run(m_frmMain); 
            }
        }
        public static frmMain m_frmMain;
        private static Account.Common.Entities.User_Info m_CurrentUser = null;
        public static Account.Common.Entities.User_Info CurrentUser
        {
            get { return m_CurrentUser; }
            set { m_CurrentUser = value; }
        }
        public static Account.Common.Entities.WorkingDay_Info m_workingday = null;
        public static Account.Common.Entities.WorkingDay_Info ToDay
        { get { return m_workingday; } set { m_workingday = value; } }
        public static Account.Common.Entities.Branches_Info m_branch = null;
        public static Account.Common.Entities.Branches_Info Branch
        { get { return m_branch; } set { m_branch = value; } }
        public static Account.Common.Entities.Currency_Info m_ccy = null;
        public static Account.Common.Entities.Currency_Info Currency
        { get { return m_ccy; } set { m_ccy = value; } }
        
        public static List<Account.Common.Entities.Branches_Info> lstBranch = new List<Account.Common.Entities.Branches_Info>();
        public static List<Account.Common.Entities.Sector_Info> lstSector = new List<Account.Common.Entities.Sector_Info>();
        public static List<Account.Common.Entities.Industry_Info> lstIndustry = new List<Account.Common.Entities.Industry_Info>();
        public static List<Account.Common.Entities.Categories_Info> lstCategories = new List<Account.Common.Entities.Categories_Info>();
        public static List<Account.Common.Entities.Account_GL_Info> lstAccountGL = new List<Account.Common.Entities.Account_GL_Info>();
        public static List<Account.Common.Entities.Currency_Info> lstCcy = new List<Account.Common.Entities.Currency_Info>();
        public static List<Account.Common.Entities.Customer_Info> lstCustomer = new List<Account.Common.Entities.Customer_Info>();
        public static List<Account.Common.Entities.Trancode_Info> lstTranCode = new List<Account.Common.Entities.Trancode_Info>();
        public static List<Account.Common.Entities.Tranday_Info> lstTranday = new List<Account.Common.Entities.Tranday_Info>();

        public static void GetAll_Branch()
        {
            if (lstBranch.Count == 0) lstBranch = Account.UIProviders.UIBranches.GetAll();
        }
        public static void RefreshAll_Branch()
        {
             lstBranch= new List<Account.Common.Entities.Branches_Info>();
            lstBranch = Account.UIProviders.UIBranches.GetAll();
        }
        public static Account.Common.Entities.Branches_Info FindBranch(string strBranchID)
        {
            for (int i = 0; i < Program.lstBranch.Count; i++)
            {
                if (Program.lstBranch[i].ID == strBranchID)
                    return Program.lstBranch[i];
            }
            return new Account.Common.Entities.Branches_Info();
        }

        public static void GetAll_Sector()
        {
            //if (lstSector.Count == 0) lstSector = Account.UIProviders.UIIn.GetAll();
        }
        public static void RefreshAll_Sector()
        {
 
        }
        public static Account.Common.Entities.Sector_Info FindSector(string strSectorID)
        {
            for (int i = 0; i < Program.lstSector.Count; i++)
            {
                if (Program.lstSector[i].ID == strSectorID)
                    return Program.lstSector[i];
            }
            return new Account.Common.Entities.Sector_Info();
        }

        public static void GetAll_Industry()
        {
            //if (lstIndustry.Count == 0) lstSector = Account.UIProviders.UIIn.GetAll();
        }
        public static void RefreshAll_Industry()
        {

        }
        public static Account.Common.Entities.Industry_Info FindIndustry(string strIndustryID)
        {
            for (int i = 0; i < Program.lstIndustry.Count; i++)
            {
                if (Program.lstIndustry[i].ID == strIndustryID)
                    return Program.lstIndustry[i];
            }
            return new Account.Common.Entities.Industry_Info();
        }

        public static void GetAll_Categories()
        {
            if (lstCategories.Count == 0) lstCategories = Account.UIProviders.UICategories.GetAll();
        }
        public static void RefreshAll_Categories()
        {
            lstCategories = new List<Account.Common.Entities.Categories_Info>();
            lstCategories = Account.UIProviders.UICategories.GetAll();

        }
        public static Account.Common.Entities.Categories_Info FindCategories(string strCateID)
        {
            for (int i = 0; i < Program.lstCategories.Count; i++)
            {
                if (Program.lstCategories[i].ID == strCateID)
                    return Program.lstCategories[i];
            }
            return new Account.Common.Entities.Categories_Info();
        }


        public static void GetAll_Account_GL()
        {
            if (lstAccountGL.Count == 0) lstAccountGL = Account.UIProviders.UIAccount_GL.GetAll();
        }
        public static void RefreshAll_Account_GL()
        {
            lstAccountGL = new List<Account.Common.Entities.Account_GL_Info>();
            lstAccountGL = Account.UIProviders.UIAccount_GL.GetAll();

        }
        public static Account.Common.Entities.Account_GL_Info FindAccount_GL(string strAccountID)
        {
            for (int i = 0; i < Program.lstAccountGL.Count; i++)
            {
                if (Program.lstAccountGL[i].Account_ID == strAccountID)
                    return Program.lstAccountGL[i];
            }
            return new Account.Common.Entities.Account_GL_Info();
        }


        public static void GetAll_Ccy()
        {
            if (lstCcy.Count == 0) lstCcy = Account.UIProviders.UICurrency.GetAll();
        }
        public static void RefreshAll_Ccy()
        {
            lstCcy = new List<Account.Common.Entities.Currency_Info>();
            lstCcy = Account.UIProviders.UICurrency.GetAll();

        }
        public static Account.Common.Entities.Currency_Info FindCcy(string strCode)
        {
            for (int i = 0; i < Program.lstCcy.Count; i++)
            {
                if (Program.lstCcy[i].Code == strCode)
                    return Program.lstCcy[i];
            }
            return new Account.Common.Entities.Currency_Info();
        }

        public static void GetAll_Customer()
        {
            if (lstCustomer.Count == 0) lstCustomer = Account.UIProviders.UICustomer.GetAll();
        }
        public static void RefreshAll_Customer()
        {
            lstCustomer = new List<Account.Common.Entities.Customer_Info>();
            lstCustomer = Account.UIProviders.UICustomer.GetAll();

        }
        public static Account.Common.Entities.Customer_Info FindCustomer(string strID)
        {
            for (int i = 0; i < Program.lstCustomer.Count; i++)
            {
                if (Program.lstCustomer[i].ID == strID)
                    return Program.lstCustomer[i];
            }
            return Account.UIProviders.UICustomer.GetCustomerByID(strID);
        }

        public static void GetAll_TranCode()
        {
            if (lstTranCode.Count == 0) lstTranCode = Account.UIProviders.UITranCode.GetAll();
        }
        public static void RefreshAll_TranCode()
        {
            lstTranCode = new List<Account.Common.Entities.Trancode_Info>();
            lstTranCode = Account.UIProviders.UITranCode.GetAll();

        }
        public static Account.Common.Entities.Trancode_Info FindTranCode(string strCode)
        {
            for (int i = 0; i < Program.lstTranCode.Count; i++)
            {
                if (Program.lstTranCode[i].Code == strCode)
                    return Program.lstTranCode[i];
            }
            return new Account.Common.Entities.Trancode_Info();
        }

        public enum Button
        {
            New = 0,
            Edit = 1,
            Del = 2,
            OK = 3,
            ESC = 4,
            None = 5
        }
        public static Button eButton = Button.None;       
    }
}
