using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace pnvn.Test
{
    public class Starter
    {
        public static void Main()
        {
            try
            {
                string temp = "";
                string result = "";
                string de_result = "";
                string doc_id;
                int fi;
                ArrayList Docs = new ArrayList();
                Crypto en = new Crypto();
                Function_Test func = new Function_Test();
                AccountServiceClient ac = new AccountServiceClient();
                ac.Open();
                //MenuReBuild();  // Show menus
                //Console.Write("Please choose number: ");
                string cyctemp;
                Random randFunc = new Random(1);
                Random randdocid=new Random();
                long cycMax=0;
                Console.Write("Nhap so lan goi ham:");
                cyctemp = Console.ReadLine();
                if (!long.TryParse(cyctemp,out cycMax))
                    cycMax=0;
                
                Console.Write("Thoi gian tre (ms):");
                cyctemp = Console.ReadLine();
                int timeSpace=0;
                if (!int.TryParse(cyctemp,out timeSpace))
                    timeSpace=0;
                long cycItem = 0;
                bool unlimit = true;
                while (unlimit)
                {
                    fi = randFunc.Next(1, 5);
                    Console.WriteLine("{0}", cycItem);
                    //Console.WriteLine("{0}", fi);
                    //System.Threading.Thread.Sleep(100);
                    if (fi == 5)
                        continue;
                    switch (fi)
                    {
                        //case "1":
                        // Open customer
                        //temp = func.OpenCustomer();
                        //Console.WriteLine("{0}\t 1. OpenCustomer()\n", DateTime.Now);
                        //break;
                        //case "2":
                        //    // Customer
                        //    temp = func.Customer();
                        //    Console.WriteLine("{0}\t 2. Customer()\n", DateTime.Now);
                        //    break;
                        //case "3":
                        //    // Open Account
                        //    temp = func.OpenAccount();
                        //    Console.WriteLine("{0}\t 3. OpenAccount()\n", DateTime.Now);
                        //    break;
                        //case "4":
                        //    // account info
                        //    temp = func.Account();
                        //    Console.WriteLine("{0}\t 4. Account()\n", DateTime.Now);
                        //    break;
                        //case "5":
                        //    // close account
                        //    temp = func.CloseAccount();
                        //    Console.WriteLine("{0}\t 5. CloseAccount()\n", DateTime.Now);
                        //    break;
                        case 1:
                            // AddFund
                            temp = func.AddFund();
                            Console.WriteLine("{0}\t 6. AddFund()\n", DateTime.Now);
                            break;
                        case 2:
                            // retail
                            temp = func.Retail();
                            Console.WriteLine("{0}\t 7. Retail()\n", DateTime.Now);

                            break;
                        case 3:
                            // fund transfer
                            temp = func.FundTransfer();
                            Console.WriteLine("{0}\t 8. FundTransfer()\n", DateTime.Now);
                            break;
                        //case "9":
                        //    // transaction
                        //    temp = func.Transaction();
                        //    Console.WriteLine("{0}\t 9. Transaction()\n", DateTime.Now);
                        //    break;
                        case 4:
                            // reverse
                            if (Docs.Count > 1)
                                temp = func.Reverse(Docs[randdocid.Next(Docs.Count)].ToString());
                            Console.WriteLine("{0}\t10. Reverse()\n", DateTime.Now);
                            break;
                        //case "11":
                        //    // show menus
                        //    MenuReBuild();
                        //    temp = "";
                        //    break;
                        //default:
                        //    break;
                    }
                    // hiển thị chuỗi ký tự gửi cho máy chủ
                    Console.WriteLine("{0}\n", temp);
                    // Kiểm tra chuỗi hợp lệ thì mới gửi lên cho máy chủ
                    if (temp.IndexOf("<function_name>") > 0)
                    {
                        // gửi, mã hóa và đồng thời nhận chuỗi ký tự kết quả mã hóa trả về
                        result = ac.Request(en.Encrypt(temp));
                        // giải mã chuối ký tự trả về
                        de_result = en.Decrypt(result);
                        if (de_result.IndexOf("<doc_id>") > 0)
                        {
                            doc_id = de_result.Substring(de_result.IndexOf("<doc_id>") + 8, 12);
                            Docs.Add(doc_id);
                        }

                        // Hiển thị kết quả trả về
                        Console.WriteLine("{0}\tReceived (DE):\n{1}\n", DateTime.Now, de_result);
                    }
                    // delay
                    if (timeSpace != 0)
                    { System.Threading.Thread.Sleep(timeSpace); }
                    if (cycMax == 0)
                    { cycItem++; unlimit = true; }
                    else
                    {
                        cycItem++;
                        if (cycItem == cycMax)
                            unlimit = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex);
                Console.WriteLine("Press anykey terminate program");
                Console.ReadLine();
            }
        }

        private static void MenuReBuild()
        {
            Console.Title = "Console test for Account Client";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("List command:");
            Console.WriteLine("\t 1 Open Customer (mo moi ho so khach hang)");
            Console.WriteLine("\t 2 Customer Information (thong tin khach hang)");
            Console.WriteLine("\t 3 Open Account (mo moi tai khoan)");
            Console.WriteLine("\t 4 Account Information (thong tin tai khoan)");
            Console.WriteLine("\t 5 Close Account (dong tai khoan)");
            Console.WriteLine("\t 6 AddFund (nap tien vao tai khoan)");
            Console.WriteLine("\t 7 Retail (mua hang)");
            Console.WriteLine("\t 8 Fund Transfer (chuyen khoan)");
            Console.WriteLine("\t 9 Transaction Information (thong tin giao dich)");
            Console.WriteLine("\t10 Reverse (giao dich dao nguoc)");
            Console.WriteLine("\t11 Main menu");
            Console.WriteLine("\t12 Exit Program");
            Console.WriteLine("");
        }
    }
    public class Crypto
    {
        private string key = "9F3A521B-14B7-4A73-84FB-42A13BF07FE5";
        public string Encrypt(string data)
        {
            return Encrypt(key, data);
        }
        public string Decrypt(string data)
        {
            return Decrypt(key, data);
        }
        private string Encrypt(string key, string data)
        {
            try
            {
                data = data.Trim();
                byte[] keydata = Encoding.UTF8.GetBytes(key);
                string md5String = BitConverter.ToString(new
                MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();
                byte[] tripleDesKey = Encoding.UTF8.GetBytes(md5String.Substring(0, 24));
                TripleDES tripdes = TripleDESCryptoServiceProvider.Create();
                tripdes.Mode = CipherMode.ECB;
                tripdes.Key = tripleDesKey;
                tripdes.GenerateIV();
                MemoryStream ms = new MemoryStream();
                CryptoStream encStream = new CryptoStream(ms, tripdes.CreateEncryptor(),
                CryptoStreamMode.Write);
                encStream.Write(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
                encStream.FlushFinalBlock();
                byte[] cryptoByte = ms.ToArray();
                ms.Close();
                encStream.Close();
                return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0)).Trim();
            }
            catch
            {
                return "";
            }

        }
        private string Decrypt(string key, string data)
        {
            try
            {
                byte[] keydata = Encoding.UTF8.GetBytes(key);
                string md5String = BitConverter.ToString(new
                MD5CryptoServiceProvider().ComputeHash(keydata)).Replace("-", "").ToLower();
                byte[] tripleDesKey = Encoding.UTF8.GetBytes(md5String.Substring(0, 24));
                TripleDES tripdes = TripleDESCryptoServiceProvider.Create();
                tripdes.Mode = CipherMode.ECB;
                tripdes.Key = tripleDesKey;
                byte[] cryptByte = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(cryptByte, 0, cryptByte.Length);
                ICryptoTransform cryptoTransform = tripdes.CreateDecryptor();
                CryptoStream decStream = new CryptoStream(ms, cryptoTransform,
                CryptoStreamMode.Read);
                StreamReader read = new StreamReader(decStream);
                return (read.ReadToEnd());
            }
            catch
            {
                return "";
            }
        }

    }
}
