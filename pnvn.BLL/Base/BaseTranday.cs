using System;
using System.Collections.Generic;
using System.Text;

using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseTranday:BaseError
    {
        protected D_Tranday _dalTranday;
        public BaseTranday()
        { _dalTranday = new D_Tranday(); }
        protected Account_Info Balance(string accountId)
        {
            D_Account da = new D_Account();
            return da.GetOneAccount(accountId);
        }
        protected Tranday_Info GetTrandayById(string docId)
        {
            D_Tranday dt = new D_Tranday();
            return dt.GetOneTranday(docId);
        }
        protected List<Tranday_Info> GetTrandayByAccount(string accountId)
        {
            return _dalTranday.GetManyTranday(accountId, 0);
        }
        protected List<Tranday_Info> GetTranAllByAccount(string accountId,DateTime dateFrom, DateTime dateTo)
        { return _dalTranday.GetManyTranALL(accountId,dateFrom,dateTo); }
        #region Base Generate document id
        /// <summary>
        /// Hàm sinh mã chứng từ mới
        /// </summary>
        /// <returns>số chứng từ mới</returns>
        protected string GenerateDocId()
        {
            string str_return = "";
            StringBuilder returnstr = new StringBuilder();
            // ký tự phân cách
            char[] sp = new char[] { '%' };
            //AppSetting ast = new AppSetting();
            Parameter_Info pi = BaseParameters.Search("document_id_format");
            // lấy định dạng của số chứng từ
            //string doc_format = ast.GetValue("document_id_format");
            string doc_format = pi.Value;

            if (string.IsNullOrEmpty(doc_format))
            {
                // mặc định nếu không có format định dạng cụ thể thì số
                // chứng từ sẽ được định dạng là 14 ký tự theo kiểu yyMMdd########
                // yyMMdd là ngày tháng
                // ######## là số thứ tự tăng dần
                doc_format = "";
                str_return = DateTime.Now.ToString("yyMMdd") + Mark2Docid("#6");
            }
            else
            {
                foreach (string b in doc_format.Split(sp))
                {
                    if (!string.IsNullOrEmpty(b))
                    {
                        switch (b.Substring(0, 1).ToLower())
                        {
                            case "y":  // ký tự năm
                                returnstr.Append(Y2Docid(b));
                                break;
                            case "M":  // ký tự tháng
                                if (b == "MM")
                                { returnstr.Append(BaseParameters.ToDay().TransDate.ToString("MM")); }
                                else
                                { returnstr.Append(BaseParameters.ToDay().TransDate.ToString("M")); }
                                break;
                            case "d":  // ký tự ngày
                                if (b == "dd")
                                { returnstr.Append(BaseParameters.ToDay().TransDate.ToString("dd")); }
                                else
                                { returnstr.Append(BaseParameters.ToDay().TransDate.ToString("d")); }
                                break;
                            case "c":   // mã categories code
                                // để dự phòng chưa dùng
                                break;
                            case "#":   // số thứ tự tăng dần, 6 ký tự.
                                returnstr.Append(Mark2Docid(b));
                                break;
                            case "j":   // số thứ tự ngày trong năm (julian date)
                                returnstr.Append(BaseParameters.ToDay().TransDate.DayOfYear.ToString().PadLeft(3, '0'));
                                break;
                            default:  // Mặc định ký tự
                                returnstr.Append(b);
                                break;
                        }
                        str_return = returnstr.ToString();
                    }
                }
            }
            return str_return;
        }
        /// <summary>
        /// Hàm sinh số năm giao dịch theo các định dạng
        /// </summary>
        /// <param name="formatstr">chuỗi ký tự định dạng</param>
        /// <returns></returns>
        private static string Y2Docid(string formatstr)
        {
            string restr="";
            switch (formatstr)
            {
                case "y":
                    restr = BaseParameters.ToDay().TransDate.Year.ToString().Substring(3, 1);
                    break;
                case "yy":
                    restr = BaseParameters.ToDay().TransDate.ToString("yy");
                    break;
                case "yyyy":
                    restr = BaseParameters.ToDay().TransDate.ToString("yyyy");
                    break;
            }
            return restr;
        }
        /// <summary>
        /// Hàm trả về số thứ tự mới trong ngày theo định dạng
        /// </summary>
        /// <param name="formatstr">tham số định dang chuỗi kỹ tự</param>
        /// <returns>chuỗi ký tự tăng dần theo định dạng</returns>
        private static string Mark2Docid(string formatstr)
        {
            // lấy biến quy định độ dài chuỗi thứ tự
            int temp_length = Convert.ToInt32(formatstr.Substring(1));
            return DocumentIdNewSeqRegister().PadLeft(temp_length, '0');
        }
        /// <summary>
        /// Hàm trả về số thứ tự mới của giao dịch trong ngày
        /// </summary>
        /// <returns></returns>
        private static string DocumentIdNewSeqRegister()
        {
            // tìm số thứ tự lớn nhất của giao dịch trong ngày.
            string temp_curr_max = BaseParameters.Search("transaction_id_max_seq", true).Value;
            long seq = Convert.ToInt64(temp_curr_max);
            // tăng thứ tự thêm 1
            seq++;
            // cập nhật số thứ tự mới
            BaseParameters.Edit("transaction_id_max_seq", seq.ToString());
            return seq.ToString();
        }
        #endregion
    }
}
