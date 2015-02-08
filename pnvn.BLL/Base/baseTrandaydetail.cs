using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Common.Utilities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseTranDetail
    {
        private TrandayDetail_Info _trandaydetail;
        private TranCodeDetailFull_Info _trancodedetail;
        private bool _completed = false;
        public BaseTranDetail(TranCodeDetailFull_Info trancodedetail, string accountIdCust)
        {
            if (trancodedetail == null)
                throw new Exception("trancodedetail is null or empty");
            
            _trandaydetail = new TrandayDetail_Info();
            // kiểm tra gan tài khoản khách hàng.
            D_Account dalAccount = new D_Account();
            Account_Info acInfo;
            if (trancodedetail.Is_Account_Cust == true)
            {
                // Xác định sự tồn tại của tài khoản khách hàng
                acInfo = dalAccount.GetOneAccount(accountIdCust);
                if (acInfo == null)
                    throw new Exception("AccountId Customer not found");
                _trandaydetail.Account_ID = accountIdCust;
            }
            else
            {
                List<Account_Info> list = dalAccount.GetListAccountLike(trancodedetail.Account_ID, trancodedetail.Categories);
                if (list.Count>1 || list.Count == 0)
                    throw new Exception("AccountId invalid");
                _trandaydetail.Account_ID = list[0].Account_ID;
            }
            _trancodedetail = trancodedetail;
            _trandaydetail.SEQ = trancodedetail.SEQ;
            switch (trancodedetail.NumberType)
            {
                case NumberType.FixAmount:
                    if (trancodedetail.CreditDebit == "DB")
                    {
                        _trandaydetail.DB_Amount = (decimal)trancodedetail.NumberValue;
                        _completed = true;
                    }
                    else
                    {
                        _trandaydetail.CR_Amount = (decimal) trancodedetail.NumberValue;
                        _completed = true;
                    }
                    break;
                default:
                    _trandaydetail.DB_Amount = 0;
                    _trandaydetail.CR_Amount = 0;
                    _completed = false;
                    break;
            }
        }
        public TrandayDetail_Info TranDayDetailInfo
        { get { return _trandaydetail; } set { _trandaydetail = value; } }
        public TranCodeDetailFull_Info TranCodeDetailInfo
        {
            get { return _trancodedetail; }
        }
        /// <summary>
        /// Ghi nhận trạng thái hoàn chỉnh định khoản hay chưa?
        /// </summary>
        public bool IsCompleted
        {
            get { return _completed; }
            set { _completed = value; }
        }
    }
    public partial class BaseTrandayDetail:BaseTranDetail
    {
        public BaseTrandayDetail(TranCodeDetailFull_Info trancodedetail, string accountIdCust, decimal amount) :
            base(trancodedetail,accountIdCust)
        {
            switch (trancodedetail.NumberType)
            {
                case NumberType.FixAmount:
                    if (this.IsCompleted == false)
                        if (trancodedetail.CreditDebit == "DB")
                        { 
                            this.TranDayDetailInfo.DB_Amount = (decimal)trancodedetail.NumberValue;
                            this.IsCompleted = true;
                        }
                        else
                        { 
                            this.TranDayDetailInfo.CR_Amount = (decimal)trancodedetail.NumberValue;
                            this.IsCompleted = true;
                        }
                    break;
                case NumberType.Percentage:
                    if (trancodedetail.CreditDebit == "DB")
                    {
                        this.TranDayDetailInfo.DB_Amount = amount * (decimal)trancodedetail.NumberValue;
                        this.IsCompleted = true;
                    }
                    else
                    {
                        this.TranDayDetailInfo.CR_Amount = amount * (decimal)trancodedetail.NumberValue;
                        this.IsCompleted = true;
                    }
                    break;
                case NumberType.NA:
                    this.IsCompleted = false;
                    break;
            }

        }
        
    }
    public partial class BaseTranDayDetails
    {
        List<BaseTrandayDetail> list = new List<BaseTrandayDetail>();
        public BaseTranDayDetails(string trancode, string accountId, decimal amount)
        {
            D_TranCodeDetailFull dalTrancodefull = new D_TranCodeDetailFull();
            List<TranCodeDetailFull_Info> trancodefulls = dalTrancodefull.GetOneTranCodeFullByCode(trancode);
            foreach(TranCodeDetailFull_Info obj in trancodefulls)
            {
                list.Add(new BaseTrandayDetail(obj, accountId, amount));
            }
            // completed transaction
        }
    }
}
