using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterCompensateDal : IB_AfterCompensateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_AfterCompensate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_AfterCompensate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_AfterCompensate(");
            strSql.Append("sid,customer,scode,telephone,address,reason,cljg,pmoney,pstate,maker,cdate,qtreason)");
            strSql.Append(" values (");
            strSql.Append("@sid,@customer,@scode,@telephone,@address,@reason,@cljg,@pmoney,@pstate,@maker,@cdate,@qtreason)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@reason", SqlDbType.NVarChar,100),
					new SqlParameter("@cljg", SqlDbType.NVarChar,100),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@qtreason", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.customer;
            parameters[2].Value = model.scode;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.address;
            parameters[5].Value = model.reason;
            parameters[6].Value = model.cljg;
            parameters[7].Value = model.pmoney;
            parameters[8].Value = model.pstate;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.qtreason;
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
        public bool Update( B_AfterCompensate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterCompensate set ");
            strSql.Append("customer=@customer,");
            strSql.Append("scode=@scode,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("reason=@reason,");
            strSql.Append("cljg=@cljg,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("pstate=@pstate,");
            strSql.Append("maker=@maker,");
            strSql.Append("qtreason=@qtreason,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@reason", SqlDbType.NVarChar,100),
					new SqlParameter("@cljg", SqlDbType.NVarChar,100),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@qtreason", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.customer;
            parameters[1].Value = model.scode;
            parameters[2].Value = model.telephone;
            parameters[3].Value = model.address;
            parameters[4].Value = model.reason;
            parameters[5].Value = model.cljg;
            parameters[6].Value = model.pmoney;
            parameters[7].Value = model.pstate;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.qtreason;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.sid;

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
            strSql.AppendFormat("delete from B_AfterCompensate where 1=1 {0}", where);
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
        public  B_AfterCompensate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,customer,scode,telephone,address,reason,cljg,pmoney,pstate,maker,cdate,qtreason from B_AfterCompensate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterCompensate r = new B_AfterCompensate();
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
        public  B_AfterCompensate DataRowToModel(DataRow row)
        {
             B_AfterCompensate model = new  B_AfterCompensate();
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
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["reason"] != null)
                {
                    model.reason = row["reason"].ToString();
                }
                if (row["qtreason"] != null)
                {
                    model.qtreason = row["qtreason"].ToString();
                }
                if (row["cljg"] != null)
                {
                    model.cljg = row["cljg"].ToString();
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["pstate"] != null && row["pstate"].ToString() != "")
                {
                    model.pstate = int.Parse(row["pstate"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_AfterCompensate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,customer,scode,telephone,address,reason,cljg,pmoney,pstate,maker,cdate ");
            strSql.Append(" FROM B_AfterCompensate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterCompensate> r = new List<B_AfterCompensate>();
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
