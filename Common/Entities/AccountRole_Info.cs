using System;
using System.Collections.Generic;
using System.Text;
using Account.Common.Utilities;

namespace Account.Common.Entities
{
    public class AccountRoles_Info
    {
        int id;
        string name;
        AccountRoleType type;
        string account_id;
        OperatorType operate;
        decimal myvalue;
        int seq;
        bool active;
        DateTime active_date;
        DateTime createdate;
        DateTime last_update;
        string usercreated;

        public AccountRoles_Info()
        { }
        public AccountRoles_Info(int id_, string name_, AccountRoleType type_,
                                 string account_id_, OperatorType operate_, decimal value_,
                                 int seq_, bool active_, DateTime active_date_, DateTime create_date, DateTime last_date,
                                 string user)
        {
            this.id = id_;
            this.name = name_;
            this.type = type_;
            this.account_id = account_id_;
            this.operate = operate_;
            this.myvalue = value_;
            this.seq = seq_;
            this.active = active_;
            this.active_date = active_date_;
            this.CreateDate = create_date;
            this.Last_Update = last_date;
            this.UserCreated = user;
        }
        public int ID
        { get { return id; } set { id = value; } }
        public string Name
        { get { return name; } set { name = value; } }
        public AccountRoleType Type
        { get { return type; } set { type = value; } }
        public string Account_ID
        { get { return account_id; } set { account_id = value; } }
        public OperatorType Operator
        { get { return operate; } set { operate = value; } }
        public decimal Value
        { get { return myvalue; } set { myvalue = value; } }
        public int Seq
        { get { return seq; } set { seq = value; } }
        public bool Active
        { get { return active; } set { active = value; } }
        public DateTime Active_Date
        { get { return active_date; } set { active_date = value; } }
        public DateTime CreateDate
        { get { return createdate; } set { createdate = value; } }
        public DateTime Last_Update
        { get { return last_update; } set { last_update = value; } }
        public string UserCreated
        { get { return usercreated; } set { usercreated = value; } }
    }
}