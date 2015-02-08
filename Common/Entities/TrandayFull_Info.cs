using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class TrandayFull_Info
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
        private DateTime _createdDate;
        private DateTime _lastDate;
        private string _accountID;
        private decimal _db_Amount = 0;
        private decimal _cr_Amount = 0;
        private int _seq;
        private string _Ccy;
        private decimal _balance_avai = 0;

        public TrandayFull_Info()
        { }
        /// <summary>
        /// Mã số chứng từ của hệ thống tự sinh theo một định dạng của từng kênh giao dịch
        /// </summary>
        public string DocID
        {
            get { return _docId; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Transaction number does not null or empty");
                _docId = value;
            }
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
            set
            {
                if (value == DateTime.MinValue)
                    throw new Exception("Transaction date does not null or empty");
                _transDate = value;
            }
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
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Transaction code does not null or empty");
                _transCode = value;
            }
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
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new Exception("Transaction status does not null or empty");
                _status = value;
            }
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
            set { _createdDate = value; }
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
    }
}
