using System;
using System.Text;

namespace Account.Common.Entities
{
    public class Customer_Info
    {
        private string _id = "";
        private string _custRef = "";
        private string _name = "";
        private string _shortName = "";
        private string _sector = "";
        private string _industry = "";
        private string _vatCode = "";
        private string _address = "";
        private string _address1 = "";
        private string _tel = "";
        private string _tel1 = "";
        private string _fax = "";
        private string _handphone = "";
        private string _accountId = "";
        private string _custCert = "";
        private string _custCertType = "";
        private DateTime _custCertDated;
        private string _custCertBy = "";
        private string _custType = "";
        private string _familyName = "";
        private string _email = "";
        private string _website = "";
        private DateTime _approvedTime;
        private bool _approved = true;
        private string _branchId = "";
        private string _mngStaff = "";
        private string _eAddress = "";
        private string _eName = "";
        private DateTime _dateCreated;
        private string _userCreated = "";
        private DateTime _lastUpdate = DateTime.Now;
        private decimal _bal;

        public Customer_Info()
        {
        }
        public Customer_Info(string id, string custRef, string name, 
                             string shortName, string sector, string industry, string vatCode, 
                             string address, string address1, string tel, string tel1, 
                             string fax, string handphone, string accountId, string custCert, 
                             string custCertType, DateTime custCertDated, string custCertBy, 
                             string custType, string familyName, string email, 
                             string website, DateTime approvedTime, bool approved, string branchId, 
                             string mngStaff, string eAddress, string eName, DateTime dateCreated, 
                             string userCreated, DateTime lastUpdate, decimal bal)
        {
            this.ID = id;
            this.Reference = custRef;
            this.Name = name;
            this.ShortName = shortName;
            this.Sector = sector;
            this.Industry = industry;
            this.VATCode = vatCode;
            this.Address = address;
            this.Address1 = address1;
            this.Tel = tel;
            this.Tel1 = tel1;
            this.Fax = fax;
            this.Handphone = handphone;
            this.Account_ID = accountId;
            this.Balance = bal;
            this.Cust_Cert = custCert;
            this.Cust_Cert_Type = custCertType;
            this.Cust_Cert_Dated = custCertDated;
            this.Cust_Cert_By = custCertBy;
            this.Cust_Type = custType;
            this.FamilyName = familyName;
            this.Email = email;
            this.Website = website;
            this.ApprovedTime = approvedTime;
            this.Approved = approved;
            this.Branch_ID = branchId;
            this.mngStaff = mngStaff;
            this.EAddress = eAddress;
            this.EName = eName;
            this.DateCreated = dateCreated;
            this.UserCreate = userCreated;
            this.LastUpdate = lastUpdate;
        }
        /// <summary>
        /// mã số khách hàng
        /// </summary>
        public string ID
        {
            get { return _id; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Customer id does not null or empty");
                _id = value; }
        }
        /// <summary>
        /// mã tham chiếu của khách hàng
        /// </summary>
        public string Reference
        {
            get { return _custRef; }
            set { _custRef = value; }
        }
        /// <summary>
        /// tên đầy đủ của khách hàng
        /// </summary>
        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Customer name does not null or empty");
                _name = value; }
        }
        /// <summary>
        /// tên viết tắt của khách hàng
        /// </summary>
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }
        /// <summary>
        /// thành phần kinh tế
        /// </summary>
        public string Sector
        {
            get { return _sector; }
            set { _sector = value; }
        }
        /// <summary>
        /// ngành nghề kinh tế
        /// </summary>
        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }
        /// <summary>
        /// mã số thuế VAT
        /// </summary>
        public string VATCode
        {
            get { return _vatCode; }
            set { _vatCode = value; }
        }
        /// <summary>
        /// địa chỉ của khách hàng
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// địa chỉ thứ hai của khách hàng
        /// </summary>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// số điện thoại thứ 2
        /// </summary>
        public string Tel1
        {
            get { return _tel1; }
            set { _tel1 = value; }
        }
        /// <summary>
        /// số fax của khách hàng
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// số điện thoại cầm tay của khách hàng
        /// </summary>
        public string Handphone
        {
            get { return _handphone; }
            set { _handphone = value; }
        }
        /// <summary>
        /// mã số tài khoản của khách hàng nếu có
        /// </summary>
        public string Account_ID
        {
            get { return _accountId; }
            set { _accountId = value; }
        }
        /// <summary>
        /// tổng số dư còn lại của khách hàng
        /// </summary>
        public decimal Balance
        {
            get { return _bal; }
            set { _bal = value; }
        }
        /// <summary>
        /// số chứng minh thư hoặc hộ chiếu
        /// </summary>
        public string Cust_Cert
        {
            get { return _custCert; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Customer certificate does not null or empty");
                _custCert = value; }
        }
        /// <summary>
        /// loại giấy tờ chứng minh
        /// </summary>
        public string Cust_Cert_Type
        {
            get { return _custCertType; }
            set { _custCertType = value; }
        }
        /// <summary>
        /// ngày cấp chứng minh thư hoặc hộ chiếu
        /// </summary>
        public DateTime Cust_Cert_Dated
        {
            get { return _custCertDated; }
            set { _custCertDated = value; }
        }
        /// <summary>
        /// chứng minh thư được cấp bởi
        /// </summary>
        public string Cust_Cert_By
        {
            get { return _custCertBy; }
            set { _custCertBy = value; }
        }
        /// <summary>
        /// loại khách hàng
        /// </summary>
        public string Cust_Type
        {
            get { return _custType; }
            set { _custType = value; }
        }
        /// <summary>
        /// tên thường gọi của khách hàng
        /// </summary>
        public string FamilyName
        {
            get { return _familyName; }
            set { _familyName = value; }
        }
        /// <summary>
        /// địa chỉ thư điện tử của khách hàng
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// địa chỉ trang web của khách hàng
        /// </summary>
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        /// <summary>
        /// ngày giờ duyệt hồ sơ khách hàng
        /// </summary>
        public DateTime ApprovedTime
        {
            get { return _approvedTime; }
            set { _approvedTime = value; }
        }
        /// <summary>
        /// hồ sơ khách hàng được duyệt hay chưa
        /// hồ sơ được duyệt mới được sử dụng
        /// </summary>
        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }
        /// <summary>
        /// mã chi nhánh
        /// </summary>
        public string Branch_ID
        {
            get { return _branchId; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Branch id in Customer does not null or empty");
                _branchId = value; }
        }
        /// <summary>
        /// mã nhân viên quản lý khách hàng
        /// không bắt buộc nhập
        /// </summary>
        public string mngStaff
        {
            get { return _mngStaff; }
            set { _mngStaff = value; }
        }
        /// <summary>
        /// địa chỉ khách hàng bằng tiếng Anh
        /// </summary>
        public string EAddress
        {
            get { return _eAddress; }
            set { _eAddress = value; }
        }
        /// <summary>
        /// Tên khách hàng bằng tiếng anh
        /// </summary>
        public string EName
        {
            get { return _eName; }
            set { _eName = value; }
        }
        /// <summary>
        /// ngày tạo hồ sơ khách hàng
        /// </summary>
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set {
                if (value == DateTime.MinValue)
                    throw new Exception("DateCreated in Customer does not null or empty");
                _dateCreated = value; }
        }
        /// <summary>
        /// mã truy cập tạo hồ sơ khách hàng
        /// </summary>
        public string UserCreate
        {
            get { return _userCreated; }
            set { _userCreated = value; }
        }
        /// <summary>
        /// ngày cập nhật hồ sơ lần cuối
        /// </summary>
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }
        /// <summary>
        /// Trạng thái khách hàng đã được kích hoạt sử dụng hay chưa
        /// </summary>
        public bool Active
        {
            get
            {
                if (this.Approved == true)
                    return true;
                else
                    return false;
            }
        }
        /// <summary>
        /// Hàm sinh chuỗi ký tự XML
        /// </summary>
        /// <returns></returns>
        public string RenderXML()
        {
            StringBuilder bstr = new StringBuilder("<customer>");
            bstr.Append("<id>");
            bstr.Append(string.Format("{0}", ID));
            bstr.Append("</id>");
            bstr.Append("<name>");
            bstr.Append(string.Format("{0}", Name));
            bstr.Append("</name>");
            bstr.Append("<cust_ref>");
            bstr.Append(string.Format("{0}", Reference));
            bstr.Append("</cust_ref>");
            bstr.Append("<shortname>");
            bstr.Append(string.Format("{0}", ShortName));
            bstr.Append("</shortname>");
            bstr.Append("<sector>");
            bstr.Append(string.Format("{0}", Sector));
            bstr.Append("</sector>");
            bstr.Append("<industry>");
            bstr.Append(string.Format("{0}", Industry));
            bstr.Append("</industry>");
            bstr.Append("<vatcode>");
            bstr.Append(string.Format("{0}", VATCode));
            bstr.Append("</vatcode>");
            bstr.Append("<address>");
            bstr.Append(string.Format("{0}", Address));
            bstr.Append("</address>");
            bstr.Append("<address1>");
            bstr.Append(string.Format("{0}", Address1));
            bstr.Append("</address1>");
            bstr.Append("<tel>");
            bstr.Append(string.Format("{0}", Tel));
            bstr.Append("</tel>");
            bstr.Append("<tel1>");
            bstr.Append(string.Format("{0}", Tel1));
            bstr.Append("</tel1>");
            bstr.Append("<fax>");
            bstr.Append(string.Format("{0}", Fax));
            bstr.Append("</fax>");
            bstr.Append("<handphone>");
            bstr.Append(string.Format("{0}", Handphone));
            bstr.Append("</handphone>");
            bstr.Append("<account_id>");
            bstr.Append(string.Format("{0}", Account_ID));
            bstr.Append("</account_id>");
            bstr.Append("<amount>");
            bstr.Append(string.Format("{0}", Balance));
            bstr.Append("</amount>");
            bstr.Append("<cust_cert>");
            bstr.Append(string.Format("{0}", Cust_Cert));
            bstr.Append("</cust_cert>");
            bstr.Append("<cust_cert_type>");
            bstr.Append(string.Format("{0}", Cust_Cert_Type));
            bstr.Append("</cust_cert_type>");
            bstr.Append("<cust_cert_dated>");
            bstr.Append(string.Format("{0}", Cust_Cert_Dated));
            bstr.Append("</cust_cert_dated>");
            bstr.Append("<cust_cert_by>");
            bstr.Append(string.Format("{0}", Cust_Cert_By));
            bstr.Append("</cust_cert_by>");
            bstr.Append("<cust_type>");
            bstr.Append(string.Format("{0}", Cust_Type));
            bstr.Append("</cust_type>");
            bstr.Append("<familyname>");
            bstr.Append(string.Format("{0}", FamilyName));
            bstr.Append("</familyname>");
            bstr.Append("<approved>");
            bstr.Append(string.Format("{0}", Approved));
            bstr.Append("</approved>");
            bstr.Append("<approvedtime>");
            bstr.Append(string.Format("{0}", ApprovedTime));
            bstr.Append("</approvedtime>");
            bstr.Append("<email>");
            bstr.Append(string.Format("{0}", Email));
            bstr.Append("</email>");
            bstr.Append("<website>");
            bstr.Append(string.Format("{0}", Website));
            bstr.Append("</website>");
            bstr.Append("<branch_id>");
            bstr.Append(string.Format("{0}", Branch_ID));
            bstr.Append("</branch_id>");
            bstr.Append("<mngstaff>");
            bstr.Append(string.Format("{0}", mngStaff));
            bstr.Append("</mngstaff>");
            bstr.Append("<eaddress>");
            bstr.Append(string.Format("{0}", EAddress));
            bstr.Append("</eaddress>");
            bstr.Append("<ename>");
            bstr.Append(string.Format("{0}", EName));
            bstr.Append("</ename>");
            bstr.Append("<datecreated>");
            bstr.Append(string.Format("{0}", DateCreated));
            bstr.Append("</datecreated>");
            bstr.Append("<usercreate>");
            bstr.Append(string.Format("{0}", UserCreate));
            bstr.Append("</usercreate>");
            bstr.Append("<lastupdate>");
            bstr.Append(string.Format("{0}", LastUpdate));
            bstr.Append("</lasupdate>");
            bstr.Append("<active>");
            bstr.Append(string.Format("{0}", Active));
            bstr.Append("</active>");
            bstr.Append("</account>");
            return bstr.ToString();
        }
    }
}