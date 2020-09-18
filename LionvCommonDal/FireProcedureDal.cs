using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LionvCommon;
using System.Data;

namespace LionvCommonDal
{
    public class FireProcedureDal
    {
        public void FireProcedure(string sid, string proname, string maker)
        {
            SqlParameter[] parms = { 
                                       new SqlParameter("@sid",sid),
                                       new SqlParameter("@maker",maker),
                                   };
             SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, proname, parms);
        }
    }
}
