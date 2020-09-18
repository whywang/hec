using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.WxChat;
using LionvModel.WxChat;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.WxChat
{
    public class Sys_WxChatConfigDal : ISys_WxChatConfigDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_WxChatConfig");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_WxChatConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_WxChatConfig(");
            strSql.Append("acode,appid,appsec,aurl,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@acode,@appid,@appsec,@aurl,@cdate,@maker)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@appid", SqlDbType.NVarChar,50),
					new SqlParameter("@appsec", SqlDbType.NVarChar,50),
					new SqlParameter("@aurl", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.acode;
            parameters[1].Value = model.appid;
            parameters[2].Value = model.appsec;
            parameters[3].Value = model.aurl;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;

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
        public bool Update( Sys_WxChatConfig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WxChatConfig set ");
            strSql.Append("appid=@appid,");
            strSql.Append("appsec=@appsec,");
            strSql.Append("aurl=@aurl,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where acode=@acode");
            SqlParameter[] parameters = {
					new SqlParameter("@appid", SqlDbType.NVarChar,50),
					new SqlParameter("@appsec", SqlDbType.NVarChar,50),
					new SqlParameter("@aurl", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.appid;
            parameters[1].Value = model.appsec;
            parameters[2].Value = model.aurl;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.acode;

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
        public bool Delete(string acode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_WxChatConfig ");
            strSql.AppendFormat(" where  acode= '{0}';", acode);
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
        public  Sys_WxChatConfig Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,acode,appid,appsec,aurl,cdate,maker,ewmimg from Sys_WxChatConfig ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_WxChatConfig r = new Sys_WxChatConfig();
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
        public  Sys_WxChatConfig DataRowToModel(DataRow row)
        {
             Sys_WxChatConfig model = new  Sys_WxChatConfig();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["appid"] != null)
                {
                    model.appid = row["appid"].ToString();
                }
                if (row["appsec"] != null)
                {
                    model.appsec = row["appsec"].ToString();
                }
                if (row["aurl"] != null)
                {
                    model.aurl = row["aurl"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["ewmimg"] != null)
                {
                    model.ewmimg = row["ewmimg"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WxChatConfig> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,acode,appid,appsec,aurl,cdate,maker,ewmimg ");
            strSql.AppendFormat(" FROM Sys_WxChatConfig where 1=1 {0}  ", strWhere);
            List<Sys_WxChatConfig> r = new List<Sys_WxChatConfig>();
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
            string sql = "select isnull(max(convert(int,acode)),0) as n from Sys_WxChatConfig ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public void setImg(string tcode, string img)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WxChatConfig set ");
            strSql.Append("ewmimg=@ewmimg");
            strSql.Append(" where acode=@acode");
            SqlParameter[] parameters = {
					new SqlParameter("@ewmimg", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30)};
            parameters[0].Value = img;
            parameters[1].Value = tcode;
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}
