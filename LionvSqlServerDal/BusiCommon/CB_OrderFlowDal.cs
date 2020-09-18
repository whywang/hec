using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_OrderFlowDal : ICB_OrderFlowDal
    {
        #region  BasicMethod
 

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_OrderFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_OrderFlow(");
            strSql.Append("emcode,sid,wcode,state,maker,wtype,bdate,edate,wname)");
            strSql.Append(" values (");
            strSql.Append("@emcode,@sid,@wcode,@state,@maker,@wtype,@bdate,@edate,@wname)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@wtype", SqlDbType.NVarChar,10),
					new SqlParameter("@bdate", SqlDbType.Date),
                    new SqlParameter("@edate", SqlDbType.Date),
					new SqlParameter("@wname", SqlDbType.NVarChar,10) };
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.wcode;
            parameters[3].Value = model.state;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.wtype ;
            parameters[6].Value = model.bdate;
            parameters[7].Value =model.edate;
            parameters[8].Value = model.wname;

            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update(CB_OrderFlow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_OrderFlow set ");
            strSql.Append("emcode=@emcode,");
            strSql.Append("sid=@sid,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("state=@state,");
            strSql.Append("bdate=@bdate,");
            strSql.Append("edate=@edate,");
            strSql.Append("maker=@maker,");
            strSql.Append("wtype=@wtype,");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@bdate", SqlDbType.DateTime),
					new SqlParameter("@edate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@wtype", SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.emcode;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.wcode;
            parameters[3].Value = model.state;
            parameters[4].Value = model.bdate;
            parameters[5].Value = model.edate;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.wtype;
            parameters[8].Value = model.id;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
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
            strSql.AppendFormat("delete from CB_OrderFlow where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
 

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  CB_OrderFlow Query(string  where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,emcode,wname,wcode,state,bdate,edate,maker,wtype,wrtype from CB_OrderFlow ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_OrderFlow r = new CB_OrderFlow();
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
        public CB_OrderFlow DataRowToModel(DataRow row)
        {
             CB_OrderFlow model = new CB_OrderFlow();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["bdate"] != null && row["bdate"].ToString() != "")
                {
                    model.bdate = row["bdate"].ToString();
                }
                if (row["edate"] != null && row["edate"].ToString() != "")
                {
                    model.edate = row["edate"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["wtype"] != null)
                {
                    model.wtype = row["wtype"].ToString();
                }
                if (row["wrtype"] != null)
                {
                    model.wrtype = row["wrtype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_OrderFlow> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,emcode,wname,wcode,state,bdate,edate,maker,wtype,wrtype ");
            strSql.Append(" FROM CB_OrderFlow ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<CB_OrderFlow> r = new List<CB_OrderFlow>();
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
        public bool IsDid(string where)
        {
            bool r = false;
            string sql = "select top 1 wcode from CB_OrderFlow where 1=1 " + where;
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, sql, null);
            if (dt != null)
            {
                r = true;
            }
            else
            {
                r = false;
            }
            return r;
        }
        public int CreateWorkFlow(string sql)
        {
            int r = 0;
            if (sql != "")
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            }
            return r;
        }
        public string QueryCurWorkFlow(string sid)
        {
            string r = "";
            string sql = "select top 1 wcode from CB_OrderFlow where sid='"+sid+"' and [state]=0 order by id asc ";
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, sql, null);
            if (dt != null)
            {
                r = dt.Rows[0][0].ToString();
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
