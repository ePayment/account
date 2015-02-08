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
    public partial class frmCurrencyList : Form
    {
        private static frmCurrencyList m_CurrentInstance = null;
        public static frmCurrencyList CurrentInstance
        {
            get
            {
                if (m_CurrentInstance == null)
                {
                    m_CurrentInstance = new frmCurrencyList();
                }
                else if (m_CurrentInstance.IsDisposed)
                {
                    m_CurrentInstance = new frmCurrencyList();
                }
                return m_CurrentInstance;
            }
        }
        DataTable dtTemp = new DataTable();

        public static List<Account.Common.Entities.Currency_Info> lstCurrencyInfo = new List<Account.Common.Entities.Currency_Info>();
        public static Account.Common.Entities.Currency_Info oSelectedCcy = null;

        public frmCurrencyList()
        {
            InitializeComponent();
            m_CurrentInstance = this;
        }

        private void frmErrorList_Load(object sender, EventArgs e)
        {
            lstCurrencyInfo = Account.UIProviders.UICurrency.GetAll();
            Create_DataSource_Table();
            SetDataSource();
        }

        private void frmErrorList_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape) sbtnExit.PerformClick();
            else if (e.KeyCode == Keys.Enter) sbtnDetail.PerformClick();
        }

        private void sbtnDetail_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            else
            {
                string Code = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gcolCode).ToString();
                for (int i = 0; i < lstCurrencyInfo.Count; i++)
                {
                    if (lstCurrencyInfo[i].Code == Code)
                    {
                        oSelectedCcy = lstCurrencyInfo[i];
                        frmCurrency ofrm = new frmCurrency();
                        ofrm.ShowDialog();
                        SetDataSource();
                        break;
                    }
                }
            }
        }

        private void sbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Create_DataSource_Table()
        {
            dtTemp = new DataTable();
            dtTemp.Columns.Add("Code");
            dtTemp.Columns.Add("Name");
            dtTemp.Columns.Add("NumberCode");
            
            gcolCode.FieldName = "Code";
            gcolName.FieldName = "Name";
            gcolNumberCode.FieldName = "NumberCode";
        }

        private void SetDataSource()
        {
            if (lstCurrencyInfo.Count == 0)
            {
                dtTemp.Rows.Clear();
                return;
            }
            dtTemp.Rows.Clear();            
            for (int i = 0; i < lstCurrencyInfo.Count; i++)
            {
                DataRow oRow = dtTemp.NewRow();
                oRow["Code"] = lstCurrencyInfo[i].Code;
                oRow["Name"] = lstCurrencyInfo[i].Name;
                oRow["NumberCode"] = lstCurrencyInfo[i].NumberCode;
                dtTemp.Rows.Add(oRow);
            }
            grdCtrlError.DataSource = null;
            grdCtrlError.DataSource = dtTemp;
        }
    }
}
