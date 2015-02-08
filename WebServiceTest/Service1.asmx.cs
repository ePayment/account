using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Account.Common.Utilities;

namespace WebServiceTest
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        MyService.AccountServiceClient myac = new WebServiceTest.MyService.AccountServiceClient();
        CryptProvider myen = new CryptProvider();
        [WebMethod]
        public string Request(string xmlstr)
        {
            return myen.Decrypt(myac.Request(myen.Encrypt(xmlstr)));
        }
        [WebMethod]
        public string Echo()
        { return myac.Echo(); }
        [WebMethod]
        public bool Test()
        {
            try
            {
                return testDate;
            }
            catch (Exception)
            {
                throw new Exception("Exception");
            }
        }
        DateTime ndate;
        private bool testDate
        { get { return ndate == DateTime.MinValue; } }
       
    }
}
