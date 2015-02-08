using System;
using System.Collections.Generic;
using System.Text;

using log4net;

using Account.Business.Base;
using Account.Common.Entities;

namespace Account.Business
{
    public partial class EndOfDay:BaseEndOfDay
    {
        private ILog _logger;

        public EndOfDay()
        {
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        /// <summary>
        /// Hàm chạy khóa sổ cuối ngày và mở sổ đầu ngày
        /// Hàm gọi thủ tục chạy dbo.RunEOD trên cơ sở dữ liệu
        /// </summary>
        /// <returns>Giá trị trả về lỗi hệ thống nếu có</returns>
        public new bool Run()
        {
            try
            {
                if (_logger.IsDebugEnabled)
                    _logger.Debug(string.Format("Started running EOD"));
                bool ret = base.Run();  // Thực hiện câu lệnh
                if (_logger.IsDebugEnabled)
                    _logger.Debug(string.Format("End run EOD"));
                if(ret==false)
                    if (_logger.IsErrorEnabled)
                        _logger.Error(Error_Message);
                
                return ret;
            }
            catch (Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                return false;
            }
        }
        /// <summary>
        /// Hàm kiểm tra cân đối hạch toán trong ngày
        /// </summary>
        /// <returns>true nếu cân đối
        /// false nếu lệch cân đối</returns>
        public List<CheckBalanceInfo> CheckAccountBalance()
        {
            try
            {
                return base.GetResultCheckBalance();
            }
            catch(Exception ex)
            {
                if (_logger.IsErrorEnabled)
                    _logger.Error(ex);
                throw ex;
            }
        }
    }
}
