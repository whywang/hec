using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SysMenuCodeDal : ISys_SysMenuCodeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SysMenuCode");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SysMenuCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SysMenuCode(");
            strSql.Append("sname,scode,stype,sremark)");
            strSql.Append(" values (");
            strSql.Append("@sname,@scode,@stype,@sremark)");

            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@sremark", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.scode;
            parameters[2].Value = model.stype;
            parameters[3].Value = model.sremark;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SysMenuCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SysMenuCode set ");
            strSql.Append("sname=@sname,");
            strSql.Append("stype=@stype,");
            strSql.Append("sremark=@sremark");
            strSql.Append(" where scode=@scode");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@sremark", SqlDbType.NVarChar,200),
					new SqlParameter("@scode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.stype;
            parameters[2].Value = model.sremark;
            parameters[3].Value = model.scode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string scode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SysMenuCode ");
            strSql.AppendFormat(" where scode='{0}' ;", scode);
            strSql.Append("delete from Sys_REventMenuMenuCode ");
            strSql.AppendFormat(" where scode='{0}' ;", scode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SysMenuCode Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sname,scode,stype,sremark from Sys_SysMenuCode ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SysMenuCode r = new Sys_SysMenuCode();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = DataRowToModel(dt.Rows[0]);
            }
            else
            {
                r = null;
            }
            return r;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SysMenuCode DataRowToModel(DataRow row)
        {
            Sys_SysMenuCode model = new Sys_SysMenuCode();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["sremark"] != null)
                {
                    model.sremark = row["sremark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SysMenuCode> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sname,scode,stype,sremark ");
            strSql.Append(" FROM Sys_SysMenuCode ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_SysMenuCode> r = new List<Sys_SysMenuCode>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(DataRowToModel(dr));
                }
            }
            else
            {
                r = null;
            }
            return r;
        }



        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,scode)),0) as n from Sys_SysMenuCode ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetEnMenuCode(string emcode, string scode, string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_REventMenuMenuCode where emcode='{0}';", emcode);
            strSql.AppendFormat(" insert into Sys_REventMenuMenuCode (emcode,scode,dcode) values('{0}','{1}','{2}' );", emcode, scode, dcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetEnMenuCode(string emcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_REventMenuMenuCode where emcode='{0}';", emcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetEnMenuCode(string emcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from Sys_REventMenuMenuCode where emcode='{0}' ;", emcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["scode"].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
        public string QueryEmcode(string scode, string bdcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from Sys_REventMenuMenuCode where scode='{0}' and dcode='{1}' ;", scode, bdcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["emcode"].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
