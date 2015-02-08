using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Account.Common.Utilities;

namespace Account.Switching
{
    [Serializable]
    public class H2HMessage
    {
        //public string ChannelID;
        public string[] Fields = new string[129];
        private int[] fieldsLength = new int[] { 0, -2, 6,  12, 0,  0,  10, 0,  0,  0,
                                                 6, 6,  4,  4,  0,  0,  0,  4,  0,  0,
                                                 0, 3,  0,  0,  2,  0,  0,  9,  0,  0,
                                                 0, -2, 0,  0,  -2, 0,  12, 6,  2,  0,
                                                 8, 15, 40, 0,  0,  0,  0,  0,  3,  0,
                                                 0, 64, 0,  -3, 0,  0,  0,  0,  0,  0,
                                                 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,
                                                 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,
                                                 0, 0,  0,  0,  0,  0,  0,  0,  0,  42,
                                                 0, 0,  0,  0,  0,  0,  0,  0,  0,  0,
                                                 0, -2, -2};

        public string Type;
        private int DataLength;
        private byte[] bData;

        public H2HMessage()
        {
            for (int i = 0; i < Fields.Length; i++)
                Fields[i] = string.Empty;
        }

        private byte[] BitMap()
        {
            int iLengthBitmap = 8;
            bool secondBitmap = false;
            string strBits = "";
            DataLength = 0;
            string strData = "";
            for (int i = 2; i <= 128; i++)
            {
                if (!String.IsNullOrEmpty(Fields[i]))
                {
                    if (i > 64) secondBitmap = true;
                    strBits = strBits + "1";
                    DataLength += Fields[i].Length;
                    strData += Fields[i];
                }
                else strBits = strBits + "0";
            }

            if (secondBitmap)
            {
                iLengthBitmap = 16;
                strBits = "1" + strBits;
            }
            else
            {
                iLengthBitmap = 8;
                strBits = "0" + strBits;
            }

            byte[] data = new byte[iLengthBitmap]; // create a byte array

            for (int i = 0; i < iLengthBitmap; i++)
            {
                string thisByte = strBits.Substring(i * 8, 8); // 8 bits = 1 byte
                byte b = Convert.ToByte(thisByte, 2); // Convert it to a byte
                data[i] = b; // assign to the byte array
            }
            bData = Encoding.ASCII.GetBytes(strData);

            return data;
        }

        public byte[] GetBytes()
        {
            List<byte> data = new List<byte>();
            byte[] bBitmap = BitMap();
            int iLength = 4 + bBitmap.Length + DataLength;
            string strLength = iLength.ToString();
            data.Add(0);
            data.Add(byte.Parse(strLength));

            data.AddRange(Encoding.ASCII.GetBytes(Type));

            data.AddRange(bBitmap);
            data.AddRange(bData);

            return data.ToArray();
        }

        private static string ConvertToBinary(string Decimal)
        {
            int i = int.Parse(Decimal);
            string strBinary = "";
            while (i > 0)
            {
                int iMod = i % 2;
                strBinary = iMod.ToString() + strBinary;
                i = (i - iMod) / 2;
            }

            return strBinary.PadLeft(8, '0');
        }

        public static H2HMessage Create(byte[] byteArray)
        {
            H2HMessage msg = new H2HMessage();
            msg.Type = Encoding.ASCII.GetString(new byte[] { byteArray[2], byteArray[3], byteArray[4], byteArray[5] });
            int bitmapLength = 8;

            string strBitmap = "";
            for (int i = 0; i < 8; i++)
            {
                strBitmap += ConvertToBinary(byteArray[i + 6].ToString());
            }

            if (strBitmap.StartsWith("1"))
            {
                bitmapLength = 16;

                for (int i = 8; i < 16; i++)
                {
                    strBitmap += ConvertToBinary(byteArray[i + 6].ToString());
                }
            }
            string strData = Encoding.ASCII.GetString(byteArray, 6 + bitmapLength, byteArray.Length - 6 - bitmapLength);
            int illvar = 0;
            for (int i = 1; i < strBitmap.Length; i++)
            {
                if (strBitmap[i].Equals('1'))
                {
                    illvar = 0;
                    if (msg.fieldsLength[i] >= 0)
                    {
                        msg.Fields[i + 1] = strData.Substring(0, msg.fieldsLength[i]);
                        strData = strData.Substring(msg.fieldsLength[i]);
                    }
                    else
                    {
                        illvar = -msg.fieldsLength[i];
                        int ilength = int.Parse(strData.Substring(0, illvar));
                        strData = strData.Substring(illvar);
                        msg.Fields[i + 1] = strData.Substring(0, ilength);
                        strData = strData.Substring(ilength);
                    }
                }
            }
            if (string.IsNullOrEmpty(msg.Fields[37]) & (!string.IsNullOrEmpty(msg.Fields[38]))) msg.Fields[37] = msg.Fields[38];

            return msg;
        }

        public static H2HMessage BalanceMessage(string F11, string F2, string F14, string F41)
        {
            H2HMessage msg = new H2HMessage();
            msg.Type = "0100";
            msg.Fields[2] = F2.Length.ToString() + F2;
            msg.Fields[3] = "301000";
            msg.Fields[4] = "000000000000";

            System.DateTime transmissionDate = System.DateTime.Now;

            msg.Fields[7] = DateTime.Now.ToString("ddMMHHmmss");
            msg.Fields[11] = F11;

            string f12, f13;
            f12 = System.DateTime.Now.ToString("HHmmss");
            f13 = System.DateTime.Now.ToString("ddMM");
            msg.Fields[12] = f12;
            msg.Fields[13] = f13;
            msg.Fields[14] = F14;
            msg.Fields[18] = "5999";
            msg.Fields[22] = "012";
            msg.Fields[25] = "00";
            msg.Fields[41] = F41.PadLeft(8, '0');//E1: F2.Substring(F2.Length - 8, 8);// strCardInfos[2];
            msg.Fields[49] = "704";
            return msg;
        }
        public static H2HMessage BalanceMessageAnswer(H2HMessage msg, ResponseMessage res)
        {
            //H2HMessage msg = new H2HMessage();
            msg.Type = "0110";
            msg.Fields[2] = msg.Fields[2].Length.ToString() + msg.Fields[2];
            //msg.Fields[37] = imsg.Fields[37];
            msg.Fields[39] = res.ResponseCode;   // Response code
            msg.Fields[54] = res.Balance;        // contains account information
            return msg;
        }

        public static H2HMessage SignOn(string F11)
        {
            H2HMessage msg = new H2HMessage();
            msg.Type = "0800";
            msg.Fields[7] = DateTime.Now.ToString("ddMMHHmmss");
            msg.Fields[11] = F11.PadLeft(6, '0');
            msg.Fields[70] = "001";

            return msg;
        }

        public static H2HMessage SignOnAnswer(H2HMessage msg, ResponseMessage res)
        {
            msg.Type = "0810";
            msg.Fields[7] = DateTime.Now.ToString("ddMMHHmmss");
            msg.Fields[39] = res.ResponseCode;
            msg.Fields[70] = "001";

            return msg;
        }
        //CardNumber;ExpDate;POCode;Amount;ReceivedCard
        public static H2HMessage FundTransfer(string F11, string F2, string F14, string F41, string F4, string F103)
        {
            H2HMessage msg = new H2HMessage();
            msg.Type = "0200";
            msg.Fields[2] = F2.Length.ToString() + F2;
            msg.Fields[3] = "400000";


            System.DateTime transmissionDate = System.DateTime.Now;
            msg.Fields[7] = DateTime.Now.ToString("ddMMHHmmss");
            msg.Fields[11] = F11;

            string f12, f13;
            f12 = System.DateTime.Now.ToString("HHmmss");
            f13 = System.DateTime.Now.ToString("ddMM");
            msg.Fields[12] = f12;
            msg.Fields[13] = f13;
            //msg.Fields[28] = "000000000";


            msg.Fields[18] = "5999";
            msg.Fields[22] = "012";
            msg.Fields[25] = "00";
            //msg.Fields[32] = F32.Length.ToString().PadLeft(2, '0') + F32;
            msg.Fields[41] = F41.PadRight(8, '0');//E1: F2.Substring(F2.Length - 8, 8);
            msg.Fields[49] = "704";
            msg.Fields[4] = F4.PadLeft(12, '0');
            msg.Fields[14] = F14;
            msg.Fields[102] = msg.Fields[2];
            msg.Fields[103] = F103.Length.ToString() + F103;

            return msg;
        }
        /// <summary>
        /// Hàm trả về của hàm fundtransfer
        /// </summary>
        /// <param name="msg">message định dạng</param>
        /// <param name="F37">Số tham chiếu trả về định dạng YJJJXXNNNNNN</param>
        /// <param name="F38">mã số chuẩn chi</param>
        /// <param name="F39">mã lỗi trả về</param>
        /// <returns></returns>
        public static H2HMessage FundTransferAnswer(H2HMessage msg, ResponseMessage res)
        {
            msg.Type = "0210";
            msg.Fields[2] = msg.Fields[2].Length.ToString() + msg.Fields[2];
            msg.Fields[37] = res.RetrievalRefNum;   // Retrieval Reference Number
            msg.Fields[38] = "000000";   // Authorisation Identification Response
            msg.Fields[39] = res.ResponseCode;   // Response code
            return msg;
        }
        public static H2HMessage Retail(string F2, string F4, string F11, string F14, string F41)
        {
            H2HMessage msg = new H2HMessage();
            DateTime dt = DateTime.Now;

            msg.Type = "0200";

            msg.Fields[2] = F2.Length.ToString() + F2;
            msg.Fields[3] = "000000";
            msg.Fields[4] = F4.PadLeft(12, '0');

            msg.Fields[7] = dt.ToString("ddMMHHmmss");
            msg.Fields[11] = F11;

            string f12, f13;
            f12 = dt.ToString("hhmmss");
            f13 = dt.ToString("ddMM");
            msg.Fields[12] = f12;
            msg.Fields[13] = f13;

            msg.Fields[14] = F14;

            msg.Fields[18] = "5999";
            msg.Fields[22] = "012";
            msg.Fields[25] = "00";
            msg.Fields[41] = F41;//E1: F2.Substring(F2.Length - 8, 8);// strCardInfos[2];
            msg.Fields[49] = "704";

            return msg;
        }
        public static H2HMessage RetailAnswer(H2HMessage msg, ResponseMessage res)
        {
            msg.Type = "0210";
            msg.Fields[2] = msg.Fields[2].Length.ToString() + msg.Fields[2];
            msg.Fields[39] = res.ResponseCode;
            
            return msg;
        }

        public static H2HMessage Reversal(string F11, string F2, string F4, string F41, string OF7, string OF11,
               string OF12, string OF13, string OF37, string OF38, string OMTI)
        {
            H2HMessage msg = new H2HMessage();
            msg.Type = "0420";
            msg.Fields[2] = "16" + F2.Trim();
            msg.Fields[3] = "400000";
            msg.Fields[4] = F4.PadLeft(12, '0');

            DateTime dt = DateTime.Now;
            msg.Fields[7] = OF7;
            msg.Fields[11] = OF11;

            msg.Fields[12] = OF12;
            msg.Fields[13] = OF13;
            msg.Fields[18] = "5999";
            msg.Fields[41] = F41;//E1: F2.Trim().Substring(F2.Length - 8, 8);
            msg.Fields[49] = "704";
            //msg.Fields[37] = OF37;
            //msg.Fields[38] = OF38;
            msg.Fields[90] = OMTI + OF11 + OF7 + "0000074012000000000000";// "020010013112051809360000074012000000000000";
            //msg.Fields[90] = OF11 + OF7 + "0200";// "0000074012000000000000";// "020010013112051809360000074012000000000000";
            return msg;
        }
        public static H2HMessage ReversalAnswer(H2HMessage msg, ResponseMessage res)
        {
            msg.Type = "0430";
            msg.Fields[2] = msg.Fields[2].Length.ToString() + msg.Fields[2];
            msg.Fields[39] = res.ResponseCode;
            return msg;
        }
        public string GetString()
        {
            string strFields = "";
            string strValues = "";

            for (int i = 1; i < Fields.Length; i++)
            {
                if (!String.IsNullOrEmpty(Fields[i]))
                {
                    strFields += i.ToString() + ";";
                    strValues += Fields[i] + ";";
                }
            }
            if (strFields.EndsWith(";")) strFields.Remove(strFields.Length - 1, 1);
            if (strValues.EndsWith(";")) strValues.Remove(strValues.Length - 1, 1);
            return strFields + "#" + strValues;
        }
        public string Convert2String()
        {
            string strFields = "";

            for (int i = 1; i < Fields.Length; i++)
            {
                if (!String.IsNullOrEmpty(Fields[i]))
                {
                    strFields += i.ToString() + "=" + Fields[i];
                }
            }
            return strFields;
        }
        public static H2HMessage GetMessage(string strMessage)
        {
            H2HMessage h2h = new H2HMessage();

            string[] str1 = strMessage.Split('#');
            string[] str11 = str1[0].Split(';');
            string[] str12 = str1[1].Split(';');

            for (int i = 0; i < str11.Length; i++)
            {
                if (!String.IsNullOrEmpty(str12[i])) h2h.Fields[int.Parse(str11[i])] = str12[i];
            }

            return h2h;
        }
       
    }
}
