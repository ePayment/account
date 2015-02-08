using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace pnvn.DAL
{
    internal static class SqlServerHelper
    {
        public static void AddParam(SqlCommand cmd, string columnName, SqlDbType dbType, object paramvalue)
        {
            if (paramvalue is DateTime)
            {
                if (((DateTime)paramvalue).Date == DateTime.MinValue.Date)
                {
                    paramvalue = DBNull.Value;
                }

            }

            if (paramvalue == null)
            {
                paramvalue = DBNull.Value;
            }

            string param = "@" + columnName;
            if (dbType == SqlDbType.VarChar || dbType == SqlDbType.NVarChar || dbType == SqlDbType.Char || dbType == SqlDbType.NChar)
                cmd.Parameters.Add(param, dbType, 4000);
            else
                cmd.Parameters.Add(param, dbType);
            cmd.Parameters[param].SourceColumn = columnName;
            cmd.Parameters[param].Value = paramvalue;
        }
    }
}
