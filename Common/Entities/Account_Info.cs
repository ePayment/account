using System;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class Account_Info
    {
        private string _accountId = String.Empty;
        private string _name = String.Empty;
        private string _ref = String.Empty;
        private decimal _b_Credit = 0;
        private decimal _y_Credit = 0;
        private decimal _y_Debit = 0;
        private decimal _q_Credit = 0;
        private decimal _q_Debit = 0;
        private decimal _m_Credit = 0;
        private decimal _m_Debit = 0;
        private decimal _w_Credit = 0;
        private decimal _w_Debit = 0;
        private decimal _d_Credit = 0;
        private decimal _d_Debit = 0;
        private AccountType _CreditDebit;
        private string _Ccy = String.Empty;
        private decimal _Amount_Blocked = 0;
        private string _Account_GL = String.Empty;
        private string _branchId = String.Empty;
        private string _customerId = String.Empty;
        private string _categories = String.Empty;
        private DateTime _approvedTime;
        private bool _approved = false;
        private bool _locked = false;
        private string _UNC_Rpt = String.Empty;
        private bool _closed = false;
        private DateTime _Closed_date;
        private DateTime _Open_Date;
        private DateTime _Last_Date;
        private string _userCreate = String.Empty;
        private decimal _bal;
        private string _checksumvalue;
        public Account_Info()
        {
        }
        public Account_Info(string accountId, string name, string reference, decimal b_Credit,
                            decimal y_Credit, decimal y_Debit, decimal q_Credit, decimal q_Debit,
                            decimal m_Credit, decimal m_Debit, decimal w_Credit, decimal w_Debit,
                            decimal d_Credit, decimal d_Debit,
                            AccountType CreditDebit, string Ccy, string Account_GL, string branchId,
                            string customerId, string categories, decimal Amount_Blocked, DateTime approvedTime,
                            bool approved, bool locked,string UNC_Rpt, bool Closed, DateTime Closed_date,
                            DateTime Open_Date, DateTime Last_Date, string userCreate, string checksumvalue)
        {
			this.Account_ID = accountId;
            this.Name = name;
            this.Reference = reference;
            this.b_Credit = b_Credit;
            this.y_Credit = y_Credit;
            this.y_Debit = y_Debit;
            this.q_Credit = q_Credit;
            this.q_Debit = q_Debit;
            this.m_Credit = m_Credit;
            this.m_Debit = m_Debit;
            this.w_Credit = w_Credit;
            this.w_Debit = w_Debit;
            this.d_Credit = d_Credit;
            this.d_Debit = d_Debit;
            this.CreditDebit = CreditDebit;
            this.Ccy = Ccy;
            this.Account_GL = Account_GL;
            this.Branch_ID = branchId;
            this.Customer_ID = customerId;
            this.Categories = categories;
            this.Amount_Blocked = Amount_Blocked;
            this.ApprovedTime = approvedTime;
            this.Approved = approved;
            this.UNC_Rpt = UNC_Rpt;
            this.Closed = Closed;
            this.Closed_date = Closed_date;
            this.Open_Date = Open_Date;
            this.Last_Date = Last_Date;
            this.UserCreate = userCreate;
            this.CheckSumValue = checksumvalue;
        }
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public string Account_ID
        {
            get { return _accountId; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Account_ID does not null or empty");
                _accountId = value; }
        }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Account Name does not null or empty");
                _name = value; }
        }
        /// <summary>
        /// Số tham chiếu tài khoản.
        /// </summary>
        public string Reference
        {
            get { return _ref; }
            set { _ref = value; }
        }
        /// <summary>
        /// số dư tài khoản không bao gồm số dư bị khóa
        /// dương là dư có
        /// âm là dư nợ
        /// </summary>
        public decimal Balance
        {
            get
            {
                _bal = (_b_Credit + _y_Credit - _y_Debit);
                return _bal;
            }
        }
        /// <summary>
        /// Số dư tài khoản bao gồm cả số dư bị khóa
        /// </summary>
        public decimal BalanceAvaiable
        {
            get
            {   // tài khoản nợ
                if (_CreditDebit == AccountType.DB)
                {
                    // tài khoản nợ luôn mang dấu -
                    return (this.Balance) + this.Amount_Blocked;
                }
                else
                {
                    // tài khoản có luôn mang dấu +
                    return (this.Balance) - this.Amount_Blocked;
                }
            }
        }
        /// <summary>
        /// Số dư đầu năm
        /// mở sổ đầu năm mới cập nhật số dư mới
        /// </summary>
        public decimal b_Credit
        {
            get { return _b_Credit; }
            set { _b_Credit = value; }
        }
        /// <summary>
        /// doanh số có trong năm
        /// mở sổ năm thì về 0
        /// </summary>
        public decimal y_Credit
        {
            get { return _y_Credit; }
            set { _y_Credit = value; }
        }
        /// <summary>
        /// doanh số nợ trong năm
        /// mở sổ năm thì về 0
        /// </summary>
        public decimal y_Debit
        {
            get { return _y_Debit; }
            set { _y_Debit = value; }
        }
        /// <summary>
        /// doanh số có trong quý
        /// mở sổ quý thì về 0
        /// </summary>
        public decimal q_Credit
        {
            get { return _q_Credit; }
            set { _q_Credit = value; }
        }
        /// <summary>
        /// doanh số nợ trong quý
        /// mở sổ quý thì về 0
        /// </summary>
        public decimal q_Debit
        {
            get { return _q_Debit; }
            set { _q_Debit = value; }
        }
        /// <summary>
        /// doanh số có trong tháng
        /// mở sổ tháng thì về 0
        /// </summary>
        public decimal m_Credit
        {
            get { return _m_Credit; }
            set { _m_Credit = value; }
        }
        /// <summary>
        /// doanh số nợ trong tháng
        /// mở sổ tháng thì về 0
        /// </summary>
        public decimal m_Debit
        {
            get { return _m_Debit; }
            set { _m_Debit = value; }
        }
        /// <summary>
        /// doanh số có trong tuần
        /// mở sổ tuần thì về 0
        /// </summary>
        public decimal w_Credit
        {
            get { return _w_Credit; }
            set { _w_Credit = value; }
        }
        /// <summary>
        /// doanh số nợ trong tuần
        /// mở sổ tuần thì về 0
        /// </summary>
        public decimal w_Debit
        {
            get { return _w_Debit; }
            set { _w_Debit = value; }
        }
        /// <summary>
        /// doanh số có trong ngày
        /// mở sổ ngày thì về 0
        /// </summary>
        public decimal d_Credit
        {
            get { return _d_Credit; }
            set { _d_Credit = value; }
        }
        /// <summary>
        /// doanh số nợ trong ngày
        /// mở sổ ngày thì về 0
        /// </summary>
        public decimal d_Debit
        {
            get { return _d_Debit; }
            set { _d_Debit = value; }
        }
        /// <summary>
        /// Tính chất tài khoản nợ/có
        /// "DB" là tính chất tài khoản nợ
        /// "CR" là tính chất tài khoản có
        /// "DC" là tính chất tài khoản lưỡng tính (có thể dư nợ và có thể dư có)
        /// </summary>
        public AccountType CreditDebit
        {
            get { return _CreditDebit; }
            set { _CreditDebit = value; }
        }
        /// <summary>
        /// mã số tiền tệ
        /// 3 ký tự
        /// VND, USD
        /// </summary>
        public string Ccy
        {
            get { return _Ccy; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Currency code does not null or empty");
                _Ccy = value; }
        }
        /// <summary>
        /// mã số tài khoản tổng hợp (sổ cái)
        /// </summary>
        public string Account_GL
        {
            get { return _Account_GL; }
            set { _Account_GL = value; }
        }
        /// <summary>
        /// mã chi nhánh
        /// </summary>
        public string Branch_ID
        {
            get { return _branchId; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Branch id does not null or empty");
                _branchId = value; }
        }
        /// <summary>
        /// mã khách hàng của tài khoản
        /// </summary>
        public string Customer_ID
        {
            get { return _customerId; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Customer id does not null or empty");
                _customerId = value; }
        }
        /// <summary>
        /// mã số sản phẩm
        /// </summary>
        public string Categories
        {
            get { return _categories; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Categories code does not null or empty");
                _categories = value; }
        }
        /// <summary>
        /// số dư bị khóa của tài khoản
        /// </summary>
        public decimal Amount_Blocked
        {
            get { return _Amount_Blocked; }
            set { _Amount_Blocked = value; }
        }
        /// <summary>
        /// thời gian duyệt mở tài khoản
        /// </summary>
        public DateTime ApprovedTime
        {
            get { return _approvedTime; }
            set 
            {
                if ((value == new DateTime(0)) && (Approved == true))
                    throw new Exception("Invalid data ApprovedTime");
                _approvedTime = value; 
            }
        }
        /// <summary>
        /// tài khoản đã được duyệt hay chưa
        /// tài khoản được duyệt mới được hạch toán
        /// true nếu đã được duyệt
        /// false nếu chưa được duyệt
        /// </summary>
        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }
        /// <summary>
        /// Thuộc tính tạm khóa tài khoản không sử dụng 
        /// khi tài khoản còn đang hoạt động
        /// </summary>
        public bool Locked
        { get { return _locked; } set { _locked = value; } }
        /// <summary>
        /// tài khoản có được kích hoạt hay chưa
        /// kiểm tra 2 điều kiện đóng và duyệt tài khoản
        /// </summary>
        public bool IsActive
        { 
            get 
            {
                if (_closed == false && _approved == true && _locked == false)
                { return true; }
                else
                { return false; }
            }  
        }
        /// <summary>
        /// tài khoản có in ủy nhiệm chi hay không
        /// không sử dụng
        /// </summary>
        public string UNC_Rpt
        {
            get { return _UNC_Rpt; }
            set { _UNC_Rpt = value; }
        }
        /// <summary>
        /// ghi nhận trạng thái đóng tài khoản
        /// true nếu tài khoản đã được đóng
        /// false nếu tài khoản đang sử dụng
        /// </summary>
        public bool Closed
        {
            get { return _closed; }
            set { _closed = value; }
        }
        /// <summary>
        /// ngày đóng tài khoản nếu có
        /// đi xong xong với trường Closed
        /// nếu trường Closed là true thì trả về kết quả
        /// ngày giờ đóng tài khoản.
        /// </summary>
        public DateTime Closed_date
        {
            get { return _Closed_date; }
            set { _Closed_date = value; }
        }
        /// <summary>
        /// ngày mở tài khoản
        /// </summary>
        public DateTime Open_Date
        {
            get { return _Open_Date; }
            set {
                if (value == new DateTime(0))
                    throw new Exception("Field Open_Date does not null or empty");
                _Open_Date = value; }
        }
        /// <summary>
        /// ngày cập nhật lần cuối
        /// trường này được cập nhật 
        /// thường xuyêt khi có bất kỳ
        /// sự thay đổi tài khoản
        /// </summary>
        public DateTime Last_Date
        {
            get { return _Last_Date; }
            set 
            {
                if (value == new DateTime(0))
                    throw new Exception("Invalid data Last_Date");
                _Last_Date = value; 
            }
        }
        /// <summary>
        /// mã số truy nhập tạo tài khoản
        /// </summary>
        public string UserCreate
        {
            get { return _userCreate; }
            set { _userCreate = value; }
        }
        /// <summary>
        /// Gía trị kiểm tra tính toàn vẹn dữ liệu
        /// </summary>
        public string CheckSumValue
        { get { return _checksumvalue; } set { _checksumvalue = value; } }
        /// <summary>
        /// hàm trả về định dạng xml
        /// </summary>
        /// <returns></returns>
        public string RenderXML()
        {
            StringBuilder bstr = new StringBuilder("<account>");
            bstr.Append("<account_id>");
            bstr.Append(string.Format("{0}",Account_ID));
            bstr.Append("</account_id>");
            bstr.Append("<name>");
            bstr.Append(string.Format("{0}", Name));
            bstr.Append("</name>");
            bstr.Append("<reference>");
            bstr.Append(string.Format("{0}", Reference));
            bstr.Append("</reference>");
            bstr.Append("<b_credit>");
            bstr.Append(string.Format("{0}", b_Credit));
            bstr.Append("</b_credit>");
            bstr.Append("<y_credit>");
            bstr.Append(string.Format("{0}", y_Credit));
            bstr.Append("</y_credit>");
            bstr.Append("<y_debit>");
            bstr.Append(string.Format("{0}", y_Debit));
            bstr.Append("</y_debit>");
            bstr.Append("<q_credit>");
            bstr.Append(string.Format("{0}", q_Credit));
            bstr.Append("</q_credit>");
            bstr.Append("<q_debit>");
            bstr.Append(string.Format("{0}", q_Debit));
            bstr.Append("</q_debit>");
            bstr.Append("<m_credit>");
            bstr.Append(string.Format("{0}", m_Credit));
            bstr.Append("</m_credit>");
            bstr.Append("<m_debit>");
            bstr.Append(string.Format("{0}", m_Debit));
            bstr.Append("</m_debit>");
            bstr.Append("<w_credit>");
            bstr.Append(string.Format("{0}", w_Credit));
            bstr.Append("</w_credit>");
            bstr.Append("<w_debit>");
            bstr.Append(string.Format("{0}", w_Debit));
            bstr.Append("</w_debit>");
            bstr.Append("<d_credit>");
            bstr.Append(string.Format("{0}", d_Credit));
            bstr.Append("</d_credit>");
            bstr.Append("<d_debit>");
            bstr.Append(string.Format("{0}", d_Debit));
            bstr.Append("</d_debit>");
            bstr.Append("<creditdebit>");
            bstr.Append(string.Format("{0}", CreditDebit));
            bstr.Append("</creditdebit>");
            bstr.Append("<ccy>");
            bstr.Append(string.Format("{0}", Ccy));
            bstr.Append("</ccy>");
            bstr.Append("<amount_blocked>");
            bstr.Append(string.Format("{0}", Amount_Blocked));
            bstr.Append("</amount_blocked>");
            bstr.Append("<account_gl>");
            bstr.Append(string.Format("{0}", Account_GL));
            bstr.Append("</account_gl>");
            bstr.Append("<branch_id>");
            bstr.Append(string.Format("{0}", Branch_ID));
            bstr.Append("</branch_id>");
            bstr.Append("<customer_id>");
            bstr.Append(string.Format("{0}", Customer_ID));
            bstr.Append("</customer_id>");
            bstr.Append("<categories>");
            bstr.Append(string.Format("{0}", Categories));
            bstr.Append("</categories>");
            bstr.Append("<approvedtime>");
            bstr.Append(string.Format("{0}", ApprovedTime));
            bstr.Append("</approvedtime>");
            bstr.Append("<approved>");
            bstr.Append(string.Format("{0}", Approved));
            bstr.Append("</approved>");

            bstr.Append("<locked>");
            bstr.Append(string.Format("{0}", Locked));
            bstr.Append("</locked>");

            bstr.Append("<closed>");
            bstr.Append(string.Format("{0}", Closed));
            bstr.Append("</closed>");
            bstr.Append("<closed_date>");
            bstr.Append(string.Format("{0}", Closed_date));
            bstr.Append("</closed_date>");
            bstr.Append("<open_date>");
            bstr.Append(string.Format("{0}", Open_Date));
            bstr.Append("</open_date>");
            bstr.Append("<last_date>");
            bstr.Append(string.Format("{0}", Last_Date));
            bstr.Append("</last_date>");
            bstr.Append("<usercreate>");
            bstr.Append(string.Format("{0}", UserCreate));
            bstr.Append("</usercreate>");
            bstr.Append("<balance>");
            bstr.Append(string.Format("{0}", Balance));
            bstr.Append("</balance>");

            bstr.Append("<balanceavaiable>");
            bstr.Append(string.Format("{0}", BalanceAvaiable));
            bstr.Append("</balanceavaiable>");

            bstr.Append("</account>");
            return bstr.ToString();
        }
    }
}