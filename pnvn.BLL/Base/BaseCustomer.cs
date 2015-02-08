using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseCustomer:BaseError
    {
        protected D_Customer _dalCust;
        protected Exception _ex;

        public BaseCustomer()
        {
            _dalCust = new D_Customer();
        }
        protected Exception GetException
        {
            get { return _ex; }
        }
        /// <summary>
        /// Tạo khách hàng mới theo tên, địa chỉ và số CMT
        /// </summary>
        /// <param name="custName">Tên đầy đủ khách hàng</param>
        /// <param name="custAdd">Địa chỉ khách hàng</param>
        /// <param name="custCert">số CMT hoặc hộ chiếu</param>
        /// <returns>=0 nếu không thành công
        /// #0 nếu thành công</returns>
        protected int Insert(string branch, string userlogin, string custName, string custAdd, string custCert)
        {
            var ci = new Customer_Info
                         {
                             ID = GenerateNewCustId(),
                             Name = custName,
                             Address = custAdd,
                             Cust_Cert = custCert,
                             Approved = true,
                             ApprovedTime = DateTime.Now,
                             UserCreate = userlogin,
                             Branch_ID = branch
                         };
            return Insert(ci);
        }
        /// <summary>
        /// Tạo mới khách hàng theo thông tin chi tiết Customer Info
        /// </summary>
        /// <param name="custInfo">thông tin chi tiết của khách hàng</param>
        /// <returns>=0 nếu không thành công
        /// #0 nếu thành công</returns>
        protected int Insert(Customer_Info custInfo)
        {
            _dalCust.CreateOneCustomer(custInfo);
            if (_dalCust.Execute())
                return _dalCust.LastRecordsEffected;
            throw _dalCust.GetException;
        }
        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="custInfo">thông tin chi tiết của khách hàng</param>
        /// <returns>=0 nếu không thành công
        /// #0 nếu thành công</returns>
        protected int Update(Customer_Info custInfo)
        {
            _dalCust.EditOneCustomer(custInfo);
            if (_dalCust.Execute())
                return _dalCust.LastRecordsEffected;
            throw _dalCust.GetException; 
        }
        /// <summary>
        /// Xóa bản ghi khách hàng
        /// </summary>
        /// <param name="id">mã số khách hàng</param>
        /// <returns>=0 nếu không thành công
        /// #0 nếu thành công</returns>
        protected int Delete(string custId)
        {
            _dalCust.RemoveOneCustomer(custId);
            if (_dalCust.Execute())
                return _dalCust.LastRecordsEffected;
            throw _dalCust.GetException;
        }
        /// <summary>
        /// Kiểm tra khách hàng đã được kích hoạt sử dụng hay chưa
        /// điều kiện kiểm tra khách hàng đã được kích hoạt hay chưa bao gồm:
        /// khách hàng không bị khóa: Locked=true
        /// khách hàng đã được duyệt: Approved=true
        /// </summary>
        /// <param name="id">mã khách hàng</param>
        /// <returns>trả về giá trị true và đã được kích hoạt và ngược lại</returns>
        protected Customer_Info GetCustomerById(string id)
        {
            return _dalCust.GetOneCustomer(id);
        }
        /// <summary>
        /// Lấy thông tin chi tiết khách hàng qua số chứng minh thư hoặc hộ chiếu
        /// </summary>
        /// <param name="certId">Số chứng minh thư hoặc hộ chiếu</param>
        /// <returns>=null nếu không tìm thấy thông tin khách hàng
        /// #null nếu tìm thấy</returns>
        protected Customer_Info GetCustomerByCert(string certId)
        {
            return  _dalCust.GetOneCustomerByCert(certId);
        }
        /// <summary>
        /// Lấy toàn bộ danh sách khách hàng
        /// </summary>
        /// <returns>mảng toàn bộ danh sách khách hàng</returns>
        protected List<Customer_Info> GetAllCustomer()
        {
            return _dalCust.GetAllCustomer();
        }
        /// <summary>
        /// Hàm sinh mã khách hàng mới
        /// </summary>
        /// <returns>mã khách hàng mới</returns>
        protected string GenerateNewCustId()
        {
            return _dalCust.GenerateNewCustomerId();
        }
        /// <summary>
        /// Lấy danh sach tài khoản chi tiết của khách hàng
        /// </summary>
        /// <param name="custId">Mã khách hàng</param>
        /// <returns>Danh sách chi tiết khách hàng</returns>
        protected decimal Balance(string custId)
        {
            decimal amnt = 0;
            D_Account dalAc = new D_Account();
            // Lấy danh sách tài khoản theo mã khách hàng
            List<Account_Info> list = dalAc.GetListAccountByCustId(custId);
            //if (list.Count == 0)
            //    throw new Exception(string.Format("Can not find any account by customer: {0}", custId));
            foreach (Account_Info ac in list)
            {
                amnt += ac.Balance;
            }
            return amnt;
        }
    }
}
