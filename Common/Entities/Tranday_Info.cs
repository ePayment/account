using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class Tranday_Info
    {
        private string _docId;
        private string _tracenum;
        private DateTime _transDate;
        private string _branchId;
        private string _descript;
        private string _transCode;
        private string _nextDocId;
        private TransactionStatus _status;
        private string _otherRef;
        private DateTime _valueDate;
        private bool _verified = false;
        private string _verifiedUser;
        private string _userCreated;
        private bool _allowreverse = true;
        private DateTime _createdDate = DateTime.Now;
        private DateTime _lastDate = DateTime.Now;
        private List<TrandayDetail_Info> _list;

        public Tranday_Info()
        {
        }
        public Tranday_Info(string docid, string tracenum, DateTime transdate, string branchId,
                            string descript, string transCode, string nextdocid,
                            TransactionStatus status, string otherref, DateTime valuedate, bool verified,
                            string verifiedUser, string usercreated, bool allowreverse,List<TrandayDetail_Info> list,
                            DateTime createddate, DateTime lastDate)
        {
            this.DocID = docid;
            this.TransDate = transdate;
            this.Branch_ID = branchId;
            this.Descript = descript;
            this.TranCode = transCode;
            this.NextDocId = nextdocid;
            this.Status = status;
            this.OtherRef = otherref;
            this.ValueDate = valuedate;
            this.Verified = verified;
            this.Verified_User = verifiedUser;
            this.UserCreate = usercreated;
            this.AllowReverse = allowreverse;
            this.CreatedDate = createddate;
            this.Last_Update = lastDate;
            this.TrandayDetails = list;
        }
        /// <summary>
        /// Mã số chứng từ của hệ thống tự sinh theo một định dạng của từng kênh giao dịch
        /// </summary>
        public string DocID
        {
            get { return _docId; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Transaction number does not null or empty");
                _docId = value; }
        }
        /// <summary>
        /// Mã số chứng từ của hệ thống ngoài tham chiếu vào
        /// </summary>
        public string Trace
        { get { return _tracenum; } set { _tracenum = value; } }
        /// <summary>
        /// ngày giao dịch
        /// </summary>
        public DateTime TransDate
        {
            get { return _transDate; }
            set {
                if (value == DateTime.MinValue)
                    throw new Exception("Transaction date does not null or empty");
                _transDate = value; }
        }
        /// <summary>
        /// mã chi nhánh
        /// </summary>
        public string Branch_ID
        {
            get { return _branchId; }
            set { _branchId = value; }
        }
        /// <summary>
        /// diễn giải của chứng từ
        /// </summary>
        public string Descript
        {
            get { return _descript; }
            set { _descript = value; }
        }
        /// <summary>
        /// mã số hạch toán
        /// </summary>
        public string TranCode
        {
            get { return _transCode; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Transaction code does not null or empty");
                _transCode = value; }
        }
        /// <summary>
        /// mã phòng hạch toán chuyển chứng từ
        /// </summary>
        public string NextDocId
        {
            get { return _nextDocId; }
            set { _nextDocId = value; }
        }
        /// <summary>
        /// trạng thái chứng từ
        /// </summary>
        public TransactionStatus Status
        {
            get { return _status; }
            set {
                if (string.IsNullOrEmpty( value.ToString()))
                    throw new Exception("Transaction status does not null or empty");
                _status = value; }
        }
        /// <summary>
        /// tham số chứng từ
        /// </summary>
        public string OtherRef
        {
            get { return _otherRef; }
            set { _otherRef = value; }
        }
        /// <summary>
        /// ngày hiệu lực chứng từ
        /// </summary>
        public DateTime ValueDate
        {
            get { return _valueDate; }
            set { _valueDate = value; }
        }
        /// <summary>
        /// ghi nhận trạng thái duyệt chứng từ
        /// </summary>
        public bool Verified
        {
            get { return _verified; }
            set { _verified = value; }
        }
        /// <summary>
        /// mã truy cập duyệt chứng từ
        /// </summary>
        public string Verified_User
        {
            get { return _verifiedUser; }
            set { _verifiedUser = value; }
        }
        /// <summary>
        /// mã truy cập tạo chứng từ
        /// </summary>
        public string UserCreate
        {
            get { return _userCreated; }
            set { _userCreated = value; }
        }
        /// <summary>
        /// ghi nhận thông tin cho phép hay không
        /// cho phép đảo ngược chứng từ
        /// </summary>
        public bool AllowReverse
        {
            get { return _allowreverse; }
            set { _allowreverse = value; }
        }
        /// <summary>
        /// ngày tạo chứng từ
        /// </summary>
        public DateTime CreatedDate
        { 
            get { return _createdDate; } 
            set {_createdDate = value; } 
        }
        /// <summary>
        /// ngày cập nhật chứng từ lần cuối
        /// </summary>
        public DateTime Last_Update
        { 
            get { return _lastDate; } 
            set { _lastDate = value; } 
        }
        /// <summary>
        /// giao dịch chi tiết
        /// </summary>
        public List<TrandayDetail_Info> TrandayDetails
        {
            get { return _list; }
            set { _list = value; } 
        }
        /// <summary>
        /// Hàm sinh chuối XML
        /// </summary>
        /// <returns></returns>
        public string RenderXML()
        {
            StringBuilder bstr = new StringBuilder("<tranday>");
            bstr.Append("<doc_id>");
            bstr.Append(string.Format("{0}",DocID));
            bstr.Append("</doc_id>");
            bstr.Append("<trace>");
            bstr.Append(string.Format("{0}", Trace));
            bstr.Append("</trace>");
            bstr.Append("<transdate>");
            bstr.Append(string.Format("{0}", TransDate));
            bstr.Append("</transdate>");
            bstr.Append("<branch_id>");
            bstr.Append(string.Format("{0}", Branch_ID));
            bstr.Append("</branch_id>");
            bstr.Append("<descript>");
            bstr.Append(string.Format("{0}", Descript));
            bstr.Append("</descript>");
            bstr.Append("<trans_code>");
            bstr.Append(string.Format("{0}", TranCode));
            bstr.Append("</trans_code>");
            bstr.Append("<postfrom>");
            bstr.Append(string.Format("{0}", NextDocId));
            bstr.Append("</postfrom>");
            bstr.Append("<status>");
            bstr.Append(string.Format("{0}", Status));
            bstr.Append("</status>");
            bstr.Append("<otherref>");
            bstr.Append(string.Format("{0}", OtherRef));
            bstr.Append("</otherref>");
            bstr.Append("<valuedate>");
            bstr.Append(string.Format("{0}", ValueDate));
            bstr.Append("</valuedate>");
            bstr.Append("<verified>");
            bstr.Append(string.Format("{0}", Verified));
            bstr.Append("</verified>");
            bstr.Append("<verified_user>");
            bstr.Append(string.Format("{0}", Verified_User));
            bstr.Append("</verified_user>");
            bstr.Append("<usercreate>");
            bstr.Append(string.Format("{0}", UserCreate));
            bstr.Append("</usercreate>");
            bstr.Append("<allowreverse>");
            bstr.Append(string.Format("{0}", AllowReverse));
            bstr.Append("</allowreverse>");
            bstr.Append("<createddate>");
            bstr.Append(string.Format("{0}", CreatedDate));
            bstr.Append("</createddate>");
            bstr.Append("<last_update>");
            bstr.Append(string.Format("{0}", Last_Update));
            bstr.Append("</last_update>");
            bstr.Append("<trandaydetails>");
            foreach (TrandayDetail_Info tdi in TrandayDetails)
                bstr.Append(tdi.RenderXML());
            bstr.Append("</trandaydetails");
            bstr.Append("</tranday>");
            return bstr.ToString();
        }
    }

    public class TrandayDetail_Info
    {
        private decimal _id;
        private string _docID = "";
        private string _accountID = "";
        private decimal _db_Amount = 0;
        private decimal _cr_Amount = 0;
        private int _seq;
        private string _Ccy = "";
        private decimal _balance_avai = 0;

        public TrandayDetail_Info()
        {
        }
        public TrandayDetail_Info(decimal id, string docID, string accountId,
                                  decimal db_Amount, decimal Cr_Amount, int seq, string ccy, decimal bal_avai)
        {
            this.ID = id;
            this.DocID = docID;
            this.Account_ID = accountId;
            this.DB_Amount = db_Amount;
            this.CR_Amount = Cr_Amount;
            this.SEQ = seq;
            this.Ccy = ccy;
            this.BalanceAvaiable = bal_avai;
        }
        /// <summary>
        /// Chỉ số tự tăng
        /// </summary>
        public decimal ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Số chứng từ
        /// </summary>
        public string DocID
        {
            get { return _docID; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Transaction id detail does not null or empty");
                _docID = value;
            }
        }
        /// <summary>
        /// Mã số tài khoản chi tiết
        /// </summary>
        public string Account_ID
        {
            get { return _accountID; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Account_id in transaction detail does not null or empty");
                _accountID = value;
            }
        }
        /// <summary>
        /// SỐ tiền ghi nợ vào tài khoản.
        /// </summary>
        public decimal DB_Amount
        {
            get { return _db_Amount; }
            set { _db_Amount = value; }
        }
        /// <summary>
        /// Số tiền ghi có vào tài khoản.
        /// </summary>
        public decimal CR_Amount
        {
            get { return _cr_Amount; }
            set { _cr_Amount = value; }
        }
        /// <summary>
        /// Số thứ tự định khoản trong bút toán
        /// </summary>
        public int SEQ
        {
            get { return _seq; }
            set { _seq = value; }
        }
        /// <summary>
        /// Loại tiền của tài khoản.
        /// </summary>
        public string Ccy
        {
            get { return _Ccy; }
            set { _Ccy = value; }
        }
        /// <summary>
        /// Số dư tài khoản sau khi đã định khoản
        /// </summary>
        public decimal BalanceAvaiable
        { get { return _balance_avai; } set { _balance_avai = value; } }
        /// <summary>
        /// Hàm sinh chuối XML
        /// </summary>
        /// <returns></returns>
        public string RenderXML()
        {
            StringBuilder bstr = new StringBuilder("<trandaydetail>");
            bstr.Append("<id>");
            bstr.Append(string.Format("{0}", ID));
            bstr.Append("</id>");
            bstr.Append("<doc_id>");
            bstr.Append(string.Format("{0}", DocID));
            bstr.Append("</doc_id>");
            bstr.Append("<account_id>");
            bstr.Append(string.Format("{0}", Account_ID));
            bstr.Append("</account_id>");
            bstr.Append("<db_amount>");
            bstr.Append(string.Format("{0}", DB_Amount));
            bstr.Append("</db_amount>");
            bstr.Append("<cr_amount>");
            bstr.Append(string.Format("{0}", CR_Amount));
            bstr.Append("</cr_amount>");
            bstr.Append("<seq>");
            bstr.Append(string.Format("{0}", SEQ));
            bstr.Append("</seq>");
            bstr.Append("<ccy>");
            bstr.Append(string.Format("{0}", Ccy));
            bstr.Append("</ccy>");
            bstr.Append("<balavaiable>");
            bstr.Append(string.Format("{0}", BalanceAvaiable));
            bstr.Append("</balavaiable>");
            bstr.Append("</trandaydetail>");
            return bstr.ToString();
        }
    }
}