using System;
using System.Text;

namespace Account.Common.Entities
{
    public class Channel_Info
    {
        int _id;
        string _name;
        string _descript;
        int _servicePort;
        int _isoPort;
        string _listenerHost;
        string _categories;
        string _currencyCode;
        string _userlogin;
        string _branch;
        string _addfundTrancode;
        string _retailTrancode;
        string _fundtransferTrancode;
        DateTime _createDate;
        DateTime _lastDate;
        string _userCreate;
        bool _security;
        string _key;

        public Channel_Info()
        { }
        public Channel_Info(string name, string descript, int servicePort,int isoPort, 
                            string categories, string currencyCode, string userlogin, 
                            string branch, string addfundTrancode, string retailTrancode, string fundtransferTrancode , 
                            string listenerHost, DateTime createDate, DateTime lastDate, 
                            string userCreate, bool security, string key)
        {
            this.Name = name;
            this.Descript=descript;
            this.ISO_Port = isoPort;
            this.Listener_Host = listenerHost;
            this.Currency_Code = _currencyCode;
            this.Categories = categories;
            this.UserLogin = userlogin;
            this.Branch = branch;
            this.AddFund_Trancode = addfundTrancode;
            this.Retail_Trancode = retailTrancode;
            this.FundTranfer_Trancode = fundtransferTrancode;
            this.Create_Date=createDate;
            this.Last_Date=lastDate;
            this.User_Create=userCreate;
            this.Security = security;
            this.Key = key;
        }
        public string Name
        {
            get { return _name; } 
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("String is empty or null");
                if (value.IndexOf(' ')>0)
                    throw new Exception("strings of characters are not spaces");
                _name = value; 
            } 
        }
        public int ID
        { get { return _id; } set { _id = value; } }
        public string Descript
        { get { return _descript; } set { _descript = value; } }
        public int Service_Port
        { get { return _servicePort; } set { _servicePort = value; } }
        public int ISO_Port
        { get { return _isoPort; } set { _isoPort = value; } }
        public string Categories
        { get { return _categories; } set { _categories = value; } }
        public string Currency_Code
        { get { return _currencyCode; } set { _currencyCode = value; } }
        public string UserLogin
        { get { return _userlogin; } set { _userlogin = value; } }
        public string Branch
        { get { return _branch; } set { _branch = value; } }
        public string AddFund_Trancode
        { get { return _addfundTrancode; } set { _addfundTrancode = value; } }
        public string Retail_Trancode
        { get { return _retailTrancode; } set { _retailTrancode = value; } }
        public string FundTranfer_Trancode
        { get { return _fundtransferTrancode; } set { _fundtransferTrancode = value; } }
        public string Listener_Host
        { get { return _listenerHost; } set { _listenerHost = value; } }
        public DateTime Create_Date
        { get { return _createDate; } set { _createDate = value; } }
        public DateTime Last_Date
        { get { return _lastDate; } set { _lastDate = value; } }
        public string User_Create
        { get { return _userCreate; } set { _userCreate = value; } }
        public bool Security
        { get { return _security; } set { _security = value; } }
        public string Key
        { get { return _key; } set { _key = value; } }
        public string RenderXML()
        { 
            StringBuilder bstr = new StringBuilder("<channel>");
            bstr.Append("<id>");
            bstr.Append(string.Format("{0}", ID));
            bstr.Append("</id>");
            bstr.Append("<name>");
            bstr.Append(string.Format("{0}", Name));
            bstr.Append("</name>");
            bstr.Append("<descript>");
            bstr.Append(string.Format("{0}", Descript));
            bstr.Append("</descript>");
            bstr.Append("<service_port>");
            bstr.Append(string.Format("{0}",Service_Port));
            bstr.Append("</service_port>");
            bstr.Append("<listener_port>");
            bstr.Append(string.Format("{0}", ISO_Port));
            bstr.Append("</listener_port>");
            bstr.Append("<listener_host>");
            bstr.Append(string.Format("{0}", Listener_Host));
            bstr.Append("</listener_host>");
            bstr.Append("<currency_code>");
            bstr.Append(string.Format("{0}", Currency_Code));
            bstr.Append("</currency_code>");
            bstr.Append("<categories>");
            bstr.Append(string.Format("{0}", Categories));
            bstr.Append("</categories>");
            bstr.Append("<branch>");
            bstr.Append(string.Format("{0}", Branch));
            bstr.Append("</branch>");
            bstr.Append("<userlogin>");
            bstr.Append(string.Format("{0}", UserLogin));
            bstr.Append("</userlogin>");
            bstr.Append("<addfund_retail>");
            bstr.Append(string.Format("{0}", AddFund_Trancode));
            bstr.Append("</addfund_retail>");
            bstr.Append("<trancode_retail>");
            bstr.Append(string.Format("{0}", Retail_Trancode));
            bstr.Append("</trancode_retail>");
            bstr.Append("<trancode_fund_transfer>");
            bstr.Append(string.Format("{0}", FundTranfer_Trancode));
            bstr.Append("</trancode_fund_transfer>");
            bstr.Append("<create_date>");
            bstr.Append(string.Format("{0}", Create_Date));
            bstr.Append("</create_date>");
            bstr.Append("<last_date>");
            bstr.Append(string.Format("{0}", Last_Date));
            bstr.Append("</last_date>");
            bstr.Append("<user_create>");
            bstr.Append(string.Format("{0}", User_Create));
            bstr.Append("</user_create>");
            bstr.Append("<security>");
            bstr.Append(string.Format("{0}", Security));
            bstr.Append("</security>");
            bstr.Append("</channel>");
            return bstr.ToString();
        }
    }
}