using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_OrderTraceRecordDal : ICB_OrderTraceRecordDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CB_OrderTraceRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OrderTraceRecord(");
            strSql.Append("sid,ttext,ttype,tdate,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@ttext,@ttype,@tdate,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ttext", SqlDbType.Text),
					new SqlParameter("@ttype", SqlDbType.NVarChar,30),
					new SqlParameter("@tdate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ttext;
            parameters[2].Value = model.ttype;
            parameters[3].Value = model.tdate;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;

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
        public bool Update(CB_OrderTraceRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OrderTraceRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("ttext=@ttext,");
            strSql.Append("ttype=@ttype,");
            strSql.Append("tdate=@tdate,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ttext", SqlDbType.Text),
					new SqlParameter("@ttype", SqlDbType.NVarChar,30),
					new SqlParameter("@tdate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ttext;
            parameters[2].Value = model.ttype;
            parameters[3].Value = model.tdate;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;
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
        public bool Delete(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CB_OrderTraceRecord ");
            strSql.AppendFormat(" where 1=1 {0}",id);

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
        public CB_OrderTraceRecord Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,ttext,ttype,tdate,cdate,maker from CB_OrderTraceRecord ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            CB_OrderTraceRecord r = new CB_OrderTraceRecord();
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
        public CB_OrderTraceRecord DataRowToModel(DataRow row)
        {
            CB_OrderTraceRecord model = new CB_OrderTraceRecord();
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
                if (row["ttext"] != null)
                {
                    model.ttext = row["ttext"].ToString();
                }
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
                }
                if (row["tdate"] != null && row["tdate"].ToString() != "")
                {
                    model.tdate = row["tdate"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
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
        public List<CB_OrderTraceRecord> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,ttext,ttype,tdate,cdate,maker ");
            strSql.AppendFormat(" FROM CB_OrderTraceRecord where 1=1 {0}", strWhere);
            List<CB_OrderTraceRecord> r = new List<CB_OrderTraceRecord>();
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
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage(" View_CB_OrderTrace ", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
