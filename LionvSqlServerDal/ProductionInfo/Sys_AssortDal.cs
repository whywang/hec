using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using System.Collections;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_AssortDal : ISys_AssortDal
    {
        public bool Exist(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Assort");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
        }
        #region  ExtensionMethod
        public bool DelAssort(string pcode)
        {
            bool r = false;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_Assort where pcode like '{0}%';", pcode);
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null)>0)
            {
                r = true;
            }
            return r;
        }
        public int SetAssort(string pcode,string pmtcode, ArrayList fcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_Assort where pcode like '{0}%' and ptpcode like '{1}%'; ", pcode, pmtcode);
            foreach (string f in fcode)
            {
                sql.AppendFormat(" insert into Sys_Assort (pcode,ptpcode) values ('{0}','{1}') ;", pcode, f);
            }
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetAssort(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_Assort where pcode like '{0}%';", pcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetAssort(string pcode)
        {
            string r = "";
            string sql = "select distinct (ptpcode) from Sys_Assort where pcode='" + pcode + "' ";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["ptpcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 8)
            {
                string sql = "select ptpcode from Sys_Assort where pcode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #region//门扇玻璃设置
        public int SetMsBl(string mcode, string blcode,string [] bcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsBl where mcode='{0}' and blcode='{1}';", mcode,blcode);
            for (int i = 0; i < bcode.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RMsBl (mcode,blcode,bcode) values ('{0}','{1}','{2}') ;", mcode, blcode,bcode[i]);
            }
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetMsBl(string mcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsBl where mcode ='{0}';", mcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetMsBl(string mcode,string blcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  bcode  ");
            strSql.AppendFormat(" FROM Sys_RMsBl where mcode='{0}' and blcode='{1}'", mcode,blcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r=r+dr["bcode"].ToString()+";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public bool ExistMsBl(string mcode,string blcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RMsBl");
            strSql.AppendFormat(" where  mcode='{0}' and blcode like '{1}' ", mcode.Substring(0,mcode.Length-3),blcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        public bool ExistMsBl(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RMsBl");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);

        }

        
        #endregion  ExtensionMethod
    }
}
