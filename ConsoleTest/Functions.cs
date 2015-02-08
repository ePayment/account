using System;

namespace pnvn.Test
{
    public class Function_Test
    {
        // 9 account
        string[] accounts = { "10200000000111", "10200000000010", "10200000000011", "10200000000012", "10200000000013" };
        Random rand = new Random();
        Random randAmnt = new Random(10000);
        //1
        public string OpenCustomer()
        {
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Address:");
            string address = Console.ReadLine();
            Console.Write("Identity card:");
            string cert = Console.ReadLine();
            try
            {
                return string.Format("<request><function_name>OpenCustomer</function_name><name>{0}</name><identity_card>{1}</identity_card><address>{2}</address></request>", name, cert, address);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //2
        public string Customer()
        {
            Console.Write("Customer id:");
            string custId = Console.ReadLine();
            Console.Write("Customer identity card:");
            string custCert = Console.ReadLine();
            try
            {
                return string.Format("<request><function_name>Customer</function_name><customer_id>{0}</customer_id><identity_card>{1}</identity_card></request>", custId, custCert);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //3
        public string OpenAccount()
        {
            Console.Write("Customer id:");
            string custId = Console.ReadLine();
            Console.Write("Categories id:");
            string catId = Console.ReadLine();
            try
            {
                return string.Format("<request><function_name>OpenAccount</function_name><categories_id>{0}</categories_id><customer_id>{1}</customer_id></request>", catId, custId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //4
        public string Account()
        {
            try
            {
                Console.Write("Account Id:");
                string accountId = Console.ReadLine();
                return string.Format("<request><function_name>Account</function_name><account_id>{0}</account_id></request>", accountId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //5
        public string CloseAccount()
        {
            try
            {
                Console.Write("Account id:");
                string accountId = Console.ReadLine();
                return string.Format("<request><function_name>CloseAccount</function_name><account_id>{0}</account_id></request>", accountId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //6
        public string AddFund()
        {
            try
            {
                //Console.Write("Trancode:");
                //string trancode = Console.ReadLine();
                string trancode = "203";
                //Console.Write("Account Id:");
                //string accountId = Console.ReadLine();
                string accountId = accounts[rand.Next(9)];
                //Console.Write("Amount:");
                //string amnt = Console.ReadLine();
                string amnt = randAmnt.Next(100000,2000000).ToString();   // nộp tối đa 2 triệu tối thiểu 100K
                //Console.Write("Description:");
                //string descript = Console.ReadLine();
                string descript = string.Format("Nộp {0}",amnt);
                return string.Format("<request><function_name>AddFund</function_name><trancode>{0}</trancode><account_id>{1}</account_id><amount>{2}</amount><descript>{3}</descript></request>", trancode, accountId, amnt, descript);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //7
        public string Retail()
        {
            try
            {
                //Console.Write("Trancode:");
                //string trancode = Console.ReadLine();
                string trancode = "201";
                //Console.Write("Account Id:");
                //string accountId = Console.ReadLine();
                string accountId = accounts[rand.Next(9)];
                //Console.Write("Amount:");
                //string amnt = Console.ReadLine();
                string amnt = randAmnt.Next(10000,500000).ToString(); // tối đa 500K, tối thiểu 10K
                //Console.Write("Description:");
                //string descript = Console.ReadLine();
                string descript = string.Format("Mua {0}", amnt);
                return string.Format("<request><function_name>Retail</function_name><trancode>{0}</trancode><account_id>{1}</account_id><amount>{2}</amount><descript>{3}</descript></request>", trancode, accountId, amnt, descript);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //8
        public string FundTransfer()
        {
            try
            {
                //Console.Write("Trancode:");
                //string trancode = Console.ReadLine();
                string trancode = "202";
                //Console.Write("From Account Id:");
                //string ac_from = Console.ReadLine();
                string ac_from = accounts[rand.Next(9)];
                //Console.Write("To Account Id:");
                //string ac_to = Console.ReadLine();
                string ac_to = accounts[rand.Next(9)];

                while (ac_from != ac_to)
                {
                    break;
                    ac_to = accounts[rand.Next(9)];
                }
                //Console.Write("Amount:");
                //string amount = Console.ReadLine();
                string amount = randAmnt.Next(500000).ToString();

                //Console.Write("Description:");
                //string descript = Console.ReadLine();
                string descript = string.Format("Chuyển tiền từ {0} sang {1} số tiền {2}",ac_from,ac_to, amount);

                return string.Format("<request><function_name>FundTransfer</function_name><trancode>{0}</trancode><db_account_id>{1}</db_account_id><cr_account_id>{2}</cr_account_id><amount>{3}</amount><descript>{4}</descript></request>", trancode,ac_from, ac_to, amount, descript);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //9
        public string Transaction()
        {
            try
            {
                Console.Write("Document Id:");
                string docId = Console.ReadLine();
                return string.Format("<request><function_name>Transaction</function_name><doc_id>{0}</doc_id></request>", docId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //10
        public string Reverse(string docId)
        {
            try
            {
                //Console.Write("Document Id:");
                //string docId = Console.ReadLine();
                return string.Format("<request><function_name>Reverse</function_name><doc_id>{0}</doc_id></request>", docId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        
        public string CheckAccountBal()
        { return string.Format("<request><function_name>CheckAccountBalance</function_name></request>"); }
    }
}
