using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvCommonDal
{
    public class Fy
    {
        public DataTable BasePage(string tablename, string selfield, string sort, string sqlWhere, int PageSize, int pageIndex,ref int rcount,ref int pcount )
        {
            DataTable r = new DataTable();
            SqlParameter[] parms = { 
                                       new SqlParameter("@TableName",tablename),
                                       new SqlParameter("@Fields",selfield), 
                                       new SqlParameter("@OrderField",sort),
                                       new SqlParameter("@sqlWhere",sqlWhere),
                                       new SqlParameter("@pageSize",PageSize),
                                       new SqlParameter("@pageIndex",pageIndex),
                                       new SqlParameter("@TotalRecoder",SqlDbType.Int,4),
                                       new SqlParameter("@TotalPage",SqlDbType.Int,4)
                                   };
            parms[6].Direction = ParameterDirection.Output;
            parms[7].Direction = ParameterDirection.Output;
            using (DataTable dt = SqlHelp.GetDataTable(CommandType.StoredProcedure, "Page", parms))
            {
                if (dt != null)
                {
                    r = dt;
                }
                else
                {
                    r = null;
                }
            }
            if (parms[6].Value != null)
            {
                rcount = int.Parse(parms[6].Value.ToString());
            }
            if (parms[7].Value != null)
            {
                pcount = int.Parse(parms[7].Value.ToString());
            }
            return r;
        }

        public DataTable BusiPage(string tablename, string selfield, string sort, string sqlWhere, int PageSize, int pageIndex, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            SqlParameter[] parms = { 
                                       new SqlParameter("@TableName",tablename),
                                       new SqlParameter("@Fields",selfield), 
                                       new SqlParameter("@OrderField",sort),
                                       new SqlParameter("@sqlWhere",sqlWhere),
                                       new SqlParameter("@pageSize",PageSize),
                                       new SqlParameter("@pageIndex",pageIndex),
                                       new SqlParameter("@TotalRecoder",SqlDbType.Int,4),
                                       new SqlParameter("@TotalPage",SqlDbType.Int,4)
                                   };
            parms[6].Direction = ParameterDirection.Output;
            parms[7].Direction = ParameterDirection.Output;
            using (DataTable dt = SqlHelp.GetDataTable2(CommandType.StoredProcedure, "Page", parms))
            {
                if (dt != null)
                {
                    r = dt;
                }
                else
                {
                    r = null;
                }
            }
            if (parms[6].Value != null)
            {
                rcount = int.Parse(parms[6].Value.ToString());
            }
            if (parms[7].Value != null)
            {
                pcount = int.Parse(parms[7].Value.ToString());
            }
            return r;
        }
    
    }
}
