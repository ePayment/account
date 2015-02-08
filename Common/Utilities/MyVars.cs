using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Utilities
{
    /// <summary>
    /// Ngôn ngữ sử dụng
    /// </summary>
    public enum AccountLanguage
    { VN, EN }

    /// <summary>
    /// Loại tài khoản
    /// nếu là tài khoản nợ thì số dư luôn phải là số dư nợ
    /// nếu là tài khoản có thì số dư luôn phải là số dư có
    /// còn loại tài khoản đều có thể dư
    /// </summary>
    public enum AccountType
    {
        DB, // loại tài khoản nợ
        CR, // loại tài khoản có
        DC  // loại tài khoản lưỡng tính (cả nợ và có)
    }
    /// <summary>
    /// Loại định khoản
    /// DB là định khoản nợ (ghi nợ tài khoản)
    /// CR là định khoản có (ghi có tài khoản)
    /// </summary>
    public enum CreditDebit
    {
        DB, // định khoản ghi nợ
        CR  // định khoản ghi có
    }
    /// <summary>
    /// các loại luật so sánh
    /// </summary>
    public enum AccountRoleType
    {
        DebitPerDay,        // doanh số ghi nợ theo ngày
        CreditPerDay,       // doanh số ghi có theo ngày
        DebitPerWeek,       // doanh số ghi nợ theo tuần
        CreditPerWeek,      // doanh số ghi có theo tuần
        DebitPerMonth,      // doanh số ghi nợ theo tháng
        CreditPerMonth,     // doanh số ghi có theo tháng
        DebitPerQuarter,    // doanh số ghi nợ theo quý
        CreditPerQuarter,   // doanh số ghi có theo quý
        DebitPerYear,       // doanh số ghi nợ theo năm
        CreditPerYear,      // doanh số ghi có theo năm
        DebitPerDeal,       // số dư cho mỗi giao dịch ghi nợ
        CreditPerDeal,      // số dư cho mỗi giao dịch ghi có
        OnBalance           // số dư còn lại sau thực hiện giao dịch
    }

    /// <summary>
    /// toán tử so sánh tài khoản
    /// </summary>
    public enum OperatorType
    {
        Equal,                  // so sánh bằng
        NotEqual,               // so sánh không bằng
        GreaterThan,            // so sánh lớn hơn
        GreaterThanOrEqual,     // so sánh lớn hơn hoặc bằng
        LessThan,               // so sánh nhỏ hơn
        LessThanOrEqual        // so sánh nhỏ hơn hoặc bằng
    }

    /// <summary>
    /// Trạng thái ngày làm việc
    /// Opened: ngày làm việc đã được mở
    /// Opening: ngày làm việc đang mở (xảy ra trong quá trình khóa sổ cuối ngày)
    /// Closed: ngày làm việc đã đóng.
    /// </summary>
    public enum WorkingStatus
    {Opened,Opening,Closed}

    /// <summary>
    /// Trạng thái chứng từ 
    /// Modify: chứng từ có thể sửa 
    /// Verify: chứng từ đã được kiểm soát (không được sửa)
    /// Approved: chứng từ đã được duyệt (không được sửa)
    /// </summary>
    public enum TransactionStatus
    {Modify,Verify,Approved}

    /// <summary>
    /// Trạng thái kênh giao dịch
    /// </summary>
    public enum ChannelStatus
    {Stop,Stat}

    /// <summary>
    /// kiểu dữ liệu số
    /// </summary>
    public enum NumberType
    {NA, Percentage, FixAmount}
    /// <summary>
    /// loại bút toán định khoản
    /// </summary>
    public enum CodeType
    {Retail, AddFund, FundTransfer}
}