using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Entities;
using Account.Data.SqlServer;

namespace Account.Business.Base
{
    public partial class BaseParameters:BaseError
    {
        static D_Parameters dp = new D_Parameters();
        static List<Parameter_Info> list = dp.GetAllParameters();
        
        public static List<Parameter_Info> Parameters
        { 
            get { return list; }
        }
        /// <summary>
        /// Cập nhật giá trị tham biến mới
        /// </summary>
        /// <param name="para_name">tên tham biến</param>
        /// <param name="para_value">giá trị tham biến</param>
        /// <param name="para_descript">mô tả tham biến</param>
        /// <returns>trả về giá trị true nếu thành công và ngược lại</returns>
        public static bool Edit(string para_name, string para_value, string para_descript)
        {
            bool exec = false;
            foreach (Parameter_Info li in list)
            {
                if (li.Name == para_name)
                {
                    li.Value = para_value;
                    li.Descript = para_descript;
                    dp.EditOneParameters(li);
                    exec = dp.Execute();
                    break;
                }
            }
            return exec;
        }
        public static bool Edit(string para_name, string para_value)
        {
            bool exec = false;
            foreach (Parameter_Info li in list)
            {
                if (li.Name == para_name)
                {
                    li.Value = para_value;
                    dp.EditOneParameters(li);
                    exec = dp.Execute();
                    break;
                }
            }
            return exec;
        }
        /// <summary>
        /// Tìm kiếm tham biến
        /// </summary>
        /// <param name="para_name">tên tham biến cần tìm</param>
        /// <returns>trả về tham biến tìm thấy còn không trả về giá trị null</returns>
        public static Parameter_Info Search(string para_name)
        {
            Parameter_Info pa = null;
            foreach (Parameter_Info para in list)
            {
                if (para.Name == para_name)
                { pa = para; }
            }
            return pa;
        }
        public static Parameter_Info Search(string para_name, bool direct)
        {
            Parameter_Info pa = null;
            // lấy lại danh sách bảng mã
            if (direct == true)
                list = dp.GetAllParameters();
            pa = Search(para_name);
            return pa;
        }
        public static WorkingDay_Info ToDay()
        {
            try
            {
                D_WorkingDay dw = new D_WorkingDay();
                return dw.GetCurrentDay();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
