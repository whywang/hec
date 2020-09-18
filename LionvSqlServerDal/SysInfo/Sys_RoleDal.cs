using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using LionvCommonDal;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_RoleDal : ISys_RoleDal
    {
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Role");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Role(");
            strSql.Append("rname,rcode,rdetail,rtype,dcode,maker,cdate,rread)");
            strSql.Append(" values (");
            strSql.Append("@rname,@rcode,@rdetail,@rtype,@dcode,@maker,@cdate,@rread)");
            SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,50),
					new SqlParameter("@rcode", SqlDbType.NVarChar,4),
					new SqlParameter("@rdetail", SqlDbType.NVarChar,50),
					new SqlParameter("@rtype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.NVarChar,30),
                    new SqlParameter("@rread", SqlDbType.Bit,1)};
            parameters[0].Value = model.rname;
            parameters[1].Value = model.rcode;
            parameters[2].Value = model.rdetail;
            parameters[3].Value = model.rtype;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.rread;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_Role model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Role set ");
            strSql.Append("rname=@rname,");
            strSql.Append("rdetail=@rdetail,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rcode=@rcode");
            SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,50),
					new SqlParameter("@rdetail", SqlDbType.NVarChar,50),
					new SqlParameter("@rtype", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.rname;
            parameters[1].Value = model.rdetail;
            parameters[2].Value = model.rtype;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.rcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_Role where 1=1 {0}",where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public Sys_Role Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,rname,rcode,rdetail,rtype,dcode,maker,cdate,rread from Sys_Role ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Role r = new Sys_Role();
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
        private Sys_Role DataRowToModel(DataRow row)
        {
            Sys_Role model = new Sys_Role();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rname"] != null)
                {
                    model.rname = row["rname"].ToString();
                }
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["rdetail"] != null)
                {
                    model.rdetail = row["rdetail"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cdate"] != null)
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["rread"] != null && row["rread"].ToString() != "")
                {
                    if ((row["rread"].ToString() == "1") || (row["rread"].ToString().ToLower() == "true"))
                    {
                        model.rread = true;
                    }
                    else
                    {
                        model.rread = false;
                    }
                }
            }
            return model;
        }
        public List<Sys_Role> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,rname,rcode,rdetail,rtype,dcode,maker,cdate,rread from Sys_Role ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_Role> r = new List<Sys_Role>();
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
        public List<Sys_Role> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            List<Sys_Role> r = new List<Sys_Role>();
            DataTable dt = new Fy().BasePage("Sys_Role", "*", sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #region  MethodEx
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,rcode)),0) as n from Sys_Role ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  MethodEx
    }
}
