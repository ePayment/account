using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseAccount:BaseError
    {
        protected D_Account dalAc;

        /// <summary>
        /// Lớp thư viện tài khoản cơ sở
        /// </summary>
        protected BaseAccount() { dalAc = new D_Account(); }
        /// <summary>
        /// Hàm thực thi mở mới tài khoản 
        /// </summary>
        /// <param name="accountInfo">thông tin tài khoản chi tiết</param>
        /// <returns>#0 nếu không thành công</returns>
        protected int Insert(Account_Info accountInfo)
        {
            dalAc.CreateOneAccount(accountInfo);
            if (dalAc.Execute())
                return dalAc.LastRecordsEffected;
            throw dalAc.GetException;
        }
        /// <summary>
        /// Sửa thông tin tài khoản
        /// </summary>
        /// <param name="accountInfo">Thông tin tài khoản chi tiết</param>
        /// <returns>#0 nếu thành công</returns>
        protected int Update(Account_Info accountInfo)
        {
            dalAc.EditOneAccount(accountInfo);
            if (dalAc.Execute())
                return dalAc.LastRecordsEffected;
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm khóa số dư tài khoản.
        /// </summary>
        /// <param name="acInfo">Tài khoản chi tiết</param>
        /// <param name="amnt">Số tiền cần khóa</param>
        /// <returns>#0 nếu thành công và =0 nếu gặp lỗi</returns>
        protected int Block(Account_Info acInfo, decimal amnt)
        {
            if (acInfo == null)
                throw new Exception("acInfo is null or empty");
            acInfo.Amount_Blocked += amnt;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
            { return dalAc.LastRecordsEffected; }
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm bỏ khóa số dư tài khoản.
        /// </summary>
        /// <param name="acInfo">Mã tài khoản chi tiết</param>
        /// <param name="amnt">Số tiền cần bỏ khóa</param>
        /// <returns>=0 nếu thành công và #0 nếu gặp lỗi</returns>
        protected int UnBlock(Account_Info acInfo, decimal amnt)
        {
            if (acInfo==null)
                throw new Exception("acInfo is null or empty");
            acInfo.Amount_Blocked -= amnt;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
            { return dalAc.LastRecordsEffected; }
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm thực hiện tạm khóa không cho sử dụng tài khoản
        /// </summary>
        /// <param name="acInfo">Thông tin tài khoản chi tiết</param>
        /// <returns></returns>
        protected int Lock(Account_Info acInfo)
        {
            if (acInfo == null)
                throw new Exception("acInfo is null or empty");
            acInfo.Locked = true;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
            { return dalAc.LastRecordsEffected; }
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm bỏ khóa tài khoản.
        /// </summary>
        /// <param name="acInfo">thông tin tài khoản chi tiết</param>
        /// <returns></returns>
        protected int UnLock(Account_Info acInfo)
        {
            if (acInfo == null)
                throw new Exception("acInfo is null or empty");
            acInfo.Locked = false;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
            { return dalAc.LastRecordsEffected; }
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm tự động sinh mã khách hàng mới
        /// </summary>
        /// <param name="branchId">mã chi nhánh</param>
        /// <param name="categories">mã sản phẩm</param>
        /// <param name="customerId">mã khách hàng</param>
        /// <returns>mã khách hàng mới</returns>
        protected string GenerateNewAccountId(string branchId, string categories)
        {
            return dalAc.GenerateNewAccountId(branchId, categories);
        }
        /// <summary>
        /// Hàm đóng tài khoản.
        /// </summary>
        /// <param name="acInfo">Tài khoản chi tiết</param>
        /// <returns>=0 nếu thực hiện thành công, 
        /// #0 nếu thực hiện không thành công</returns>
        protected int Close(Account_Info acInfo)
        {
            if (acInfo == null)
                throw new Exception("acInfo is null or empty");
            acInfo.Closed = true;
            acInfo.Closed_date = DateTime.Now;
            acInfo.Last_Date = DateTime.Now;
            dalAc.EditOneAccount(acInfo);
            if (dalAc.Execute())
                return dalAc.LastRecordsEffected;
            throw dalAc.GetException;
        }
        /// <summary>
        /// Hàm xóa tài khoản đã được tạo
        /// </summary>
        /// <param name="acInfo">Tài khoản chi tiết</param>
        /// <returns>=0 nếu thực hiện thành công
        /// #0 nếu không thành công</returns>
        protected int Delete(string accountId)
        {
            dalAc.RemoveOneAccount(accountId);
            if (dalAc.Execute())
                return dalAc.LastRecordsEffected;
            throw dalAc.GetException;
        }
        /// <summary>
        /// Lấy thông tin tài khoản chi tiết
        /// </summary>
        /// <param name="accountId">Mã số tài khoản</param>
        /// <returns>=null nếu không có
        /// #null nếu tìm thấy</returns>
        protected Account_Info GetAccountById(string accountId)
        {
            return dalAc.GetOneAccount(accountId);
        }
        /// <summary>
        /// Lấy thông tin tài khoản chi tiết
        /// </summary>
        /// <param name="branch">Mã chi nhánh</param>
        /// <param name="categories">Mã sản phẩm</param>
        /// <param name="custId">Mã khách hàng</param>
        /// <returns>=null nếu không tìm thấy thông tin tài khoản chi tiết
        /// #null nếu tìm thấy</returns>
        protected Account_Info GetAccountBy(string branch, string categories, string custId)
        {
            return dalAc.GetOneAccount(branch, categories, custId);
        }
    }
}
