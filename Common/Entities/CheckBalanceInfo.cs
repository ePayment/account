using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Entities
{
    public class CheckBalanceInfo
    {
        private string _accountId;
        private string _name;
        private decimal _ac_debit;
        private decimal _ac_credit;
        private decimal _tran_debit;
        private decimal _tran_credit;

        public CheckBalanceInfo()
        {
        }
        public CheckBalanceInfo(string accountId, string name, decimal ac_debit, decimal ac_credit, decimal tran_debit, decimal tran_credit)
        {
        }
        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        public string AccountName
        {
            get { return _name; }
            set { _name = value; }
        }
        public decimal AccountDebit
        {
            get { return _ac_debit; }
            set { _ac_debit = value; }
        }
        public decimal AccountCredit
        {
            get { return _ac_credit; }
            set { _ac_credit = value; }
        }
        public decimal TranDebit
        {
            get { return _tran_debit; }
            set { _tran_debit = value; }
        }
        public decimal TranCredit
        {
            get { return _tran_credit; }
            set { _tran_credit = value; }
        }
        public string RenderXML()
        {
            StringBuilder bstr = new StringBuilder();
            bstr.Append("<checkbalance>");

            bstr.Append("<accountid>");
            bstr.Append(string.Format("{0}", AccountId));
            bstr.Append("</accountid>");
            bstr.Append("<accountname>");
            bstr.Append(string.Format("{0}", AccountName));
            bstr.Append("</accountname>");
            bstr.Append("<accountdebit>");
            bstr.Append(string.Format("{0}", AccountDebit));
            bstr.Append("</accountdebit>");
            bstr.Append("<accountcredit>");
            bstr.Append(string.Format("{0}", AccountCredit));
            bstr.Append("</accountcredit>");
            bstr.Append("<trandebit>");
            bstr.Append(string.Format("{0}", TranDebit));
            bstr.Append("</trandebit>");
            bstr.Append("<trancredit>");
            bstr.Append(string.Format("{0}", TranCredit));
            bstr.Append("</trancredit>");

            bstr.Append("</checkbalance>");
            return bstr.ToString();
        }
    }
}
