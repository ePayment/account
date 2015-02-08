using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Common.Utilities
{
    /// <summary>
    /// Thư viện kết quả trả về của các giao dịch
    /// </summary>
    public class ResponseMessage
    {
        string _responsecode;   // F39
        string _docid;          // F37
        string _localdate;      // F13
        string _localtime;      // F12
        string _trace;          // F11
        string _masterdata;     // F35 (track 2)
        string _balance;        // F54
        string _currencycode;   // F49

        /// <summary>
        /// F39:
        /// A code that defines the response to request or the message disposition. 
        /// Code 00 indicates both approval (a positive authorisation decision) 
        /// and acceptance (acknowledgement of receipt of a transaction or a message).  
        /// </summary>
        public string ResponseCode
        { get { return _responsecode; } set { _responsecode = value; } }
        /// <summary>
        /// F37:
        /// A number that is used with other data elements as a key to identify and track 
        /// all messages related to a given cardholder transaction. The retrieval reference 
        /// number is a key data element for matching a message to others within a given 
        /// transaction set. The reference number must be the same in all messages for 
        /// the set. For example, a new retrieval number is assigned when a financial 
        /// transaction is processed. The same number appears in all related messages: 
        /// response, advice, and reversal. 
        /// The combination of DE37 and field DE32 must be unique to link the 
        /// messages belonging to the same transaction into a message chain. The valid 
        /// value for this field is YJJJXXNNNNNN, where are  
        /// Y - a last digit of year,  
        /// JJJ - a Julian date,  
        /// </summary>
        public string RetrievalRefNum
        { get { return _docid; } set { _docid = value; } }
        /// <summary>
        /// F12:
        /// This field contains the time the transaction took place, expressed in the local 
        /// time of the card acceptor location. The date is in 'hhmmss' format where:  
        /// hh = hours 
        /// mm = minutes 
        /// ss = seconds 
        /// </summary>
        public string LocalDate
        { get { return _localdate; } set { _localdate = value; } }
        /// <summary>
        /// F13:
        /// This field contains the month and day on which the cardholder originated the 
        /// transaction. For recurring payments, this field contains the cardholder 
        /// requested payment date. The date is in 'mmdd' format where:  
        /// mm = month 
        /// dd = day 
        /// </summary>
        public string LocalTime
        { get { return _localtime; } set { _localtime = value; } }
        /// <summary>
        /// F11:
        /// A number assigned by the originator of request message. The same value of 
        /// System Trace Audit Number (STAN) must be used for response message. 
        /// The STAN of request message must be as unique as possible. The good 
        /// assumption is that it's unique during 24 hours. 
        /// </summary>
        public String SystemTrace
        { get { return _trace; } set { _trace = value; } }
        /// <summary>
        /// Track2 Data
        /// </summary>
        public string MasterData
        { get { return _masterdata; } set { _masterdata = value; } }
        /// <summary>
        /// F54:
        /// This field contains account balance information. Balance information is for 
        /// cardholder benefit. This field is used for returning account balance 
        /// information. After the length subfield, there are six possible sets of the 
        /// following subfields: 
        /// Positions 1–2, Account Type: A 2-digit code identifying the account type 
        /// affected by the balance inquiry. Valid codes are: 
        /// '00' Not Applicable or Not Specified 
        /// '10' Savings Account 
        /// '20' Checking Account 
        /// '30' Credit Card Account 
        /// Positions 3–4, Amount Type: A 2-digit code describing the use of the 
        /// amount. Valid codes are: 
        /// '01' Current ledger (posted) balance 
        /// '02' Current available balance (typically, ledger balance less outstanding 
        /// authorisations) 
        /// '90' Available Credit 
        /// '91' Credit Limit 
        /// Positions 5–7, Currency Code: A 3-digit code that defines the currency used 
        /// in Positions 9–20. 
        /// Position 8, Amount, Sign: A 1-digit code that defines the value of the 
        /// amount as either positive or negative. 
        /// 'C' Positive balance 
        /// 'D' Negative balance 
        /// Positions 9–20, Amount: A twelve-character amount that is right-justified 
        /// and contains leading zeros. The amount also includes an implied decimal 
        /// relative to the currency code specified in positions 5–7.
        /// 
        /// </summary>
        public string Balance
        { get { return _balance; } }
        /// <summary>
        /// F49:
        /// This field contains a 3-digit numeric code that identifies the transaction currency in the following amount fields:  
        /// DE04—Amount, Transaction, 
        /// DE95.1—Actual Amount, Transaction.  
        /// This code is used to determine the number of decimal places in the above 
        /// amount fields. 
        /// This field is used in any message related to a cardholder transaction that 
        /// contains one or more of the amount fields listed above, even when the 
        /// amount is zero. Also this field is used in balance inquiry requests, even when 
        /// field 4 is equal to zero. This code specifies the currency in which the acquirer 
        /// wants the balance amount. 
        /// </summary>
        public string CurrencyCode
        {
            get { return _currencycode; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 3)
                    throw new Exception("Currency code not valid");
                _currencycode = value;
            }
        }
        /// <summary>
        /// convert F54 format
        /// </summary>
        /// <param name="amnt"></param>
        public void BalanceParse(decimal amnt)
        {
            string pos57;
            if (amnt > 0)
            { pos57 = "C"; }
            else
            { pos57 = "D"; }
            _balance = "00" + "01" + _currencycode + pos57 + amnt.ToString("#00.00").PadLeft(13, '0').Remove(10, 1);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            StringBuilder bstr = new StringBuilder("");
            if (!string.IsNullOrEmpty(_trace))
                bstr.Append("F11=" + _trace + " (System Trace Audit Number)\n");
            if (!string.IsNullOrEmpty(_localtime))
                bstr.Append("F12=" + _localtime + " (Time, Local Transaction)\n");
            if (!string.IsNullOrEmpty(_localdate))
                bstr.Append("F13=" + _localdate + " (Date, Local Transaction)\n");
            if (!string.IsNullOrEmpty(_masterdata))
                bstr.Append("F35=" + _masterdata + " (Track-2, Data)\n");
            if (!string.IsNullOrEmpty(_docid))
                bstr.Append("F37=" + _docid + " (Retrieval Reference Number)\n");
            if (!string.IsNullOrEmpty(_responsecode))
                bstr.Append("F39=" + _responsecode + " (Response code)\n");
            if (!string.IsNullOrEmpty(_currencycode))
                bstr.Append("F49=" + _currencycode + " (Currency Code, Transaction )\n");
            if (!string.IsNullOrEmpty(_balance))
                bstr.Append("F54=" + _balance + " (Additional Amounts)");

            return bstr.ToString();
        }
    }

}
