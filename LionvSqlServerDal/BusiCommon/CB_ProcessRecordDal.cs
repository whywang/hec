using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiCommon;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_ProcessRecordDal : ICB_ProcessRecordDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_ProcessRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_ProcessRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_ProcessRecord(");
            strSql.Append("sid,jid,rtext,jdname,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@jid,@rtext,@jdname,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@jid", SqlDbType.Int,4),
					new SqlParameter("@rtext", SqlDbType.NVarChar,500),
					new SqlParameter("@jdname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.jid;
            parameters[2].Value = model.rtext;
            parameters[3].Value = model.jdname;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update( CB_ProcessRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_ProcessRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("jid=@jid,");
            strSql.Append("rtext=@rtext,");
            strSql.Append("jdname=@jdname,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@jid", SqlDbType.Int,4),
					new SqlParameter("@rtext", SqlDbType.NVarChar,500),
					new SqlParameter("@jdname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.jid;
            parameters[2].Value = model.rtext;
            parameters[3].Value = model.jdname;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.id;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CB_ProcessRecord ");
            strSql.AppendFormat(" where 1=1 {0}  ", where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public  CB_ProcessRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,jid,rtext,jdname,maker,cdate from CB_ProcessRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_ProcessRecord r = new CB_ProcessRecord();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
        public  CB_ProcessRecord DataRowToModel(DataRow row)
        {
             CB_ProcessRecord model = new  CB_ProcessRecord();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["jid"] != null && row["jid"].ToString() != "")
                {
                    model.jid = int.Parse(row["jid"].ToString());
                }
                if (row["rtext"] != null)
                {
                    model.rtext = row["rtext"].ToString();
                }
                if (row["jdname"] != null)
                {
                    model.jdname = row["jdname"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_ProcessRecord> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,jid,rtext,jdname,maker,cdate ");
            strSql.AppendFormat(" FROM CB_ProcessRecord where 1=1 {0}", strWhere);
            List<CB_ProcessRecord> r = new List<CB_ProcessRecord>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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

        #endregion  ExtensionMethod
    }
}
