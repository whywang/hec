using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.WxChat;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.WxChat;

namespace LionvSqlServerDal.WxChat
{
    public class Sys_WxChatTempDal : ISys_WxChatTempDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_WxChatTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_WxChatTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_WxChatTemp(");
            strSql.Append("tcode,tid,turl,ttitle,tremark,ttype,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@tcode,@tid,@turl,@ttitle,@tremark,@ttype,@cdate,@maker)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tid", SqlDbType.NVarChar,50),
					new SqlParameter("@turl", SqlDbType.NVarChar,50),
					new SqlParameter("@ttitle", SqlDbType.NVarChar,30),
					new SqlParameter("@tremark", SqlDbType.NVarChar,100),
					new SqlParameter("@ttype", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tcode;
            parameters[1].Value = model.tid;
            parameters[2].Value = model.turl;
            parameters[3].Value = model.ttitle;
            parameters[4].Value = model.tremark;
            parameters[5].Value = model.ttype;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.maker;

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
        public bool Update( Sys_WxChatTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_WxChatTemp set ");
            strSql.Append("tid=@tid,");
            strSql.Append("turl=@turl,");
            strSql.Append("ttitle=@ttitle,");
            strSql.Append("tremark=@tremark,");
            strSql.Append("ttype=@ttype,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where tcode=@tcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tid", SqlDbType.NVarChar,50),
					new SqlParameter("@turl", SqlDbType.NVarChar,50),
					new SqlParameter("@ttitle", SqlDbType.NVarChar,30),
					new SqlParameter("@tremark", SqlDbType.NVarChar,100),
					new SqlParameter("@ttype", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tid;
            parameters[1].Value = model.turl;
            parameters[2].Value = model.ttitle;
            parameters[3].Value = model.tremark;
            parameters[4].Value = model.ttype;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.tcode;

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
        public bool Delete(string tcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_WxChatTemp ");
            strSql.AppendFormat(" where  tcode= '{0}';", tcode);
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
        public  Sys_WxChatTemp Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tcode,tid,turl,ttitle,tremark,ttype,cdate,maker from Sys_WxChatTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_WxChatTemp r = new Sys_WxChatTemp();
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
        public  Sys_WxChatTemp DataRowToModel(DataRow row)
        {
             Sys_WxChatTemp model = new  Sys_WxChatTemp();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["tid"] != null)
                {
                    model.tid = row["tid"].ToString();
                }
                if (row["turl"] != null)
                {
                    model.turl = row["turl"].ToString();
                }
                if (row["ttitle"] != null)
                {
                    model.ttitle = row["ttitle"].ToString();
                }
                if (row["tremark"] != null)
                {
                    model.tremark = row["tremark"].ToString();
                }
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WxChatTemp> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tcode,tid,turl,ttitle,tremark,ttype,cdate,maker ");
            strSql.AppendFormat(" FROM Sys_WxChatTemp where 1=1 {0}  ", strWhere);
            List<Sys_WxChatTemp> r = new List<Sys_WxChatTemp>();
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
            string sql = "select isnull(max(convert(int,tcode)),0) as n from Sys_WxChatTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
