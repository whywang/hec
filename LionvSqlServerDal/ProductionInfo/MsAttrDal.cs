using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvIDal.ProductionInfo;
using System.Collections;

namespace LionvSqlServerDal.ProductionInfo
{
    public class MsAttrDal : IMsAttrDal
    {
        #region//金属条设置
        public bool SetMsJst(string mscode, string jstcode)
        {
            string[] jsarr = jstcode.Split(';');
            StringBuilder sql = new StringBuilder();
            if (jsarr.Length > 0)
            {
                sql.AppendFormat(" delete from Sys_RMsJst where mscode ='{0}';", mscode);
                foreach (string jc in jsarr)
                {
                    sql.AppendFormat(" insert into Sys_RMsJst (mscode,jscode) values ('{0}','{1}') ;", mscode, jc);
                }
                int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ReSetMsJst(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsJst where mscode ='{0}';", mscode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMsJst(string mscode)
        {
            string r = "";
            string sql = "select jscode from Sys_RMsJst where mscode='" + mscode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["jscode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion
        #region//门扇套色设置
        public bool SetMsColor(string mscode, string mname)
        {
            string[] jsarr = mname.Split(';');
            StringBuilder sql = new StringBuilder();
            if (jsarr.Length > 0)
            {
                sql.AppendFormat(" delete from Sys_RMsColor where mscode ='{0}';", mscode);
                foreach (string jc in jsarr)
                {
                    sql.AppendFormat(" insert into Sys_RMsColor (mscode,mname) values ('{0}','{1}') ;", mscode, jc);
                }
               
                int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ReSetMsColor(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsColor where mscode ='{0}';", mscode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMsColor(string mscode)
        {
            string r = "";
            string sql = "select mname from Sys_RMsColor where mscode='" + mscode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["mname"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion

        #region//压条设置
        public bool SetMsYt(string mscode, string ycode)
        {
            string[] jsarr = ycode.Split(';');
            StringBuilder sql = new StringBuilder();
            if (jsarr.Length > 0)
            {
                sql.AppendFormat(" delete from Sys_RMsYt where mscode ='{0}' and ycode like'{1}%';", mscode, jsarr[0].Substring(0,17));
                foreach (string jc in jsarr)
                {
                    sql.AppendFormat(" insert into Sys_RMsYt (mscode,ycode) values ('{0}','{1}') ;", mscode, jc);
                }
                int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ReSetMsYt(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsYt where mscode ='{0}';", mscode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMsYt(string mscode)
        {
            string r = "";
            string sql = "select ycode from Sys_RMsYt where mscode='" + mscode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["ycode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion
        public bool SetMsLock(string mscode, string lname)
        {
            string[] arr = lname.Split(';');
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsLock where mscode='{0}';", mscode);
            for (int i = 0; i < arr.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RMsLock (mscode,lname) values ('{0}','{1}') ;", mscode, arr[i]);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetMsLock(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsLock where mscode='{0}';", mscode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetMsLock(string mscode)
        {

            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  lname  ");
            strSql.AppendFormat(" FROM Sys_RMsLock where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["lname"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public ArrayList GetLock(string mscode)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  lname  ");
            strSql.AppendFormat(" FROM Sys_RMsLock where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["lname"].ToString());
                }
            }
            else
            {
                r = null;
            }
            return r;
        }

        public bool SetMsHy(string mscode, string hname)
        {
            string[] arr = hname.Split(';');
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsHy where mscode='{0}' ;", mscode);
            for (int i = 0; i < arr.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RMsHy (mscode,hname) values ('{0}','{1}') ;", mscode, arr[i]);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetMsHy(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsHy where mscode='{0}';", mscode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetMsHy(string mscode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  hname  ");
            strSql.AppendFormat(" FROM Sys_RMsHy where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["hname"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public ArrayList GetHy(string mscode)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  hname  ");
            strSql.AppendFormat(" FROM Sys_RMsHy where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["hname"].ToString());
                }
            }
            else
            {
                r = null;
            }
            return r;
        }

        public bool SetMsLine(string mscode, string xxname)
        {
            string[] arr = xxname.Split(';');
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsLine where mscode='{0}' ;", mscode);
            for (int i = 0; i < arr.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RMsLine (mscode,xxname) values ('{0}','{1}') ;", mscode, arr[i]);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetMsLine(string mscode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RMsLine where mscode='{0}';", mscode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetMsLine(string mscode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select xxname  ");
            strSql.AppendFormat(" FROM Sys_RMsLine where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["xxname"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public ArrayList GetLine(string mscode)
        {
            ArrayList r = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  xxname  ");
            strSql.AppendFormat(" FROM Sys_RMsLine where mscode='{0}'", mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["xxname"].ToString());
                }
            }
            else
            {
                r = null;
            }
            return r;
        }
    }
}
