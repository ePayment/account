using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Data.Mongo
{
    public class D_Customer
    {
        public void CreateOneCustomer(dynamic objCustomerInfo)
        {
            ePayment.DataProvider.MongoHelper.Save("Customer", objCustomerInfo);
        }

        public void EditOneCustomer(dynamic objCustomerInfo)
        {
            ePayment.DataProvider.MongoHelper.Save("Customer",objCustomerInfo);
        }

        public void RemoveOneCustomer(string id){
            ePayment.DataProvider.MongoHelper.Delete("Customer",id);
        }

        public dynamic[] GetAllCustomer()
        {
            return ePayment.DataProvider.MongoHelper.List("Customer", null);
        }

        public dynamic GetOneCustomer(string id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return ePayment.DataProvider.MongoHelper.Get("Customer", query);
        }

        public dynamic GetOneCustomerByCert(string certId)
        {
            IMongoQuery query = Query.EQ("Cust_Cert", certId);
            return ePayment.DataProvider.MongoHelper.Get("Customer", query);
        }

        public string GetCustomerIdByCert(string certId)
        {
            return GetOneCustomerByCert(certId)._id.ToString();
        }
    }
}
