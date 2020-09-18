using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_ApartSendOrderDal : IB_ApartSendOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_ApartSendOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_ApartSendOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ApartSendOrder(");
            strSql.Append("osid,sid,snum,fhcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@osid,@sid,@snum,@fhcode,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@snum", SqlDbType.Int,4),
					new SqlParameter("@fhcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.osid;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.snum;
            parameters[3].Value = model.fhcode;
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
        public bool Update(B_ApartSendOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ApartSendOrder set ");
            strSql.Append("sid=@sid,");
            strSql.Append("snum=@snum,");
            strSql.Append("fhcode=@fhcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where osid=@osid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@snum", SqlDbType.Int,4),
					new SqlParameter("@fhcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@osid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.snum;
            parameters[2].Value = model.fhcode;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.id;
            parameters[6].Value = model.osid;

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
            strSql.AppendFormat("delete from B_ApartSendOrder where 1=1 {0}", where);
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
        public B_ApartSendOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,osid,sid,snum,fhcode,maker,cdate from B_ApartSendOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ApartSendOrder r = new B_ApartSendOrder();
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
        public B_ApartSendOrder DataRowToModel(DataRow row)
        {
            B_ApartSendOrder model = new B_ApartSendOrder();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["snum"] != null && row["snum"].ToString() != "")
                {
                    model.snum = int.Parse(row["snum"].ToString());
                }
                if (row["fhcode"] != null)
                {
                    model.fhcode = row["fhcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<B_ApartSendOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,osid,sid,snum,fhcode,maker,cdate ");
            strSql.Append(" FROM B_ApartSendOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ApartSendOrder> r = new List<B_ApartSendOrder>();
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
        public int QueryMaxNum(string sid)
        {
            int r = -1;
            string sql = "select isnull(max( snum),0) as n from B_ApartSendOrder where sid='"+sid+"'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 1 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
