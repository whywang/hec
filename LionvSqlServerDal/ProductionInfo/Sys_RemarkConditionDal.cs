using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_RemarkConditionDal : ISys_RemarkConditionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string rccode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RemarkCondition");
            strSql.AppendFormat(" where rccode= '{0}' ", rccode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_RemarkCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_RemarkCondition(");
            strSql.Append("rcname,rccode,rcode,rtype,rbottomv,rtopv,rxtext,marker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@rcname,@rccode,@rcode,@rtype,@rbottomv,@rtopv,@rxtext,@marker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@rcname", SqlDbType.NVarChar,20),
					new SqlParameter("@rccode", SqlDbType.NVarChar,20),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@rbottomv", SqlDbType.Int,4),
					new SqlParameter("@rtopv", SqlDbType.Int,4),
					new SqlParameter("@rxtext", SqlDbType.NVarChar,500),
					new SqlParameter("@marker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.rcname;
            parameters[1].Value = model.rccode;
            parameters[2].Value = model.rcode;
            parameters[3].Value = model.rtype;
            parameters[4].Value = model.rbottomv;
            parameters[5].Value = model.rtopv;
            parameters[6].Value = model.rxtext;
            parameters[7].Value = model.marker;
            parameters[8].Value = model.cdate;
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
        public bool Update( Sys_RemarkCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_RemarkCondition set ");
            strSql.Append("rcname=@rcname,");
            strSql.Append("rcode=@rcode,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("rbottomv=@rbottomv,");
            strSql.Append("rtopv=@rtopv,");
            strSql.Append("rxtext=@rxtext,");
            strSql.Append("marker=@marker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rccode=@rccode");
            SqlParameter[] parameters = {
					new SqlParameter("@rcname", SqlDbType.NVarChar,20),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@rbottomv", SqlDbType.Int,4),
					new SqlParameter("@rtopv", SqlDbType.Int,4),
					new SqlParameter("@rxtext", SqlDbType.NVarChar,500),
					new SqlParameter("@marker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rccode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.rcname;
            parameters[1].Value = model.rcode;
            parameters[2].Value = model.rtype;
            parameters[3].Value = model.rbottomv;
            parameters[4].Value = model.rtopv;
            parameters[5].Value = model.rxtext;
            parameters[6].Value = model.marker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.rccode;
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
            strSql.AppendFormat("delete from Sys_RemarkCondition where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_RemarkCondition Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,rcname,rccode,rcode,rtype,rbottomv,rtopv,rxtext,marker,cdate from Sys_RemarkCondition ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RemarkCondition r = new Sys_RemarkCondition();
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
        public  Sys_RemarkCondition DataRowToModel(DataRow row)
        {
            Sys_RemarkCondition model = new  Sys_RemarkCondition();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rcname"] != null)
                {
                    model.rcname = row["rcname"].ToString();
                }
                if (row["rccode"] != null)
                {
                    model.rccode = row["rccode"].ToString();
                }
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
                if (row["rbottomv"] != null && row["rbottomv"].ToString() != "")
                {
                    model.rbottomv = int.Parse(row["rbottomv"].ToString());
                }
                if (row["rtopv"] != null && row["rtopv"].ToString() != "")
                {
                    model.rtopv = int.Parse(row["rtopv"].ToString());
                }
                if (row["rxtext"] != null)
                {
                    model.rxtext = row["rxtext"].ToString();
                }
                if (row["marker"] != null)
                {
                    model.marker = row["marker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_RemarkCondition> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rcname,rccode,rcode,rtype,rbottomv,rtopv,rxtext,marker,cdate ");
            strSql.AppendFormat(" FROM Sys_RemarkCondition where 1=1 {0}", strWhere);
            List<Sys_RemarkCondition> r = new List<Sys_RemarkCondition>();
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
            string sql = "";
            sql = "select isnull(max(convert(int,rccode)),0) as n from Sys_RemarkCondition ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
