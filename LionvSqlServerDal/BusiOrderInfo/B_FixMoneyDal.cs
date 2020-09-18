using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using System.Collections;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_FixMoneyDal : IB_FixMoneyDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_FixMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_FixMoney(");
            strSql.Append("sid,amoney,dmoney,premark,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@amoney,@dmoney,@premark,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@amoney", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@premark", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.amoney;
            parameters[2].Value = model.dmoney;
            parameters[3].Value = model.premark;
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
        public bool Update(B_FixMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_FixMoney set ");
            strSql.Append("amoney=@amoney,");
            strSql.Append("dmoney=@dmoney,");
            strSql.Append("premark=@premark,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@amoney", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@premark", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.amoney;
            parameters[1].Value = model.dmoney;
            parameters[2].Value = model.premark;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.sid;

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
            strSql.AppendFormat("delete from B_FixMoney where 1=1 {0}", where);
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
        public B_FixMoney Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,amoney,dmoney,premark,cdate,maker from B_FixMoney ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_FixMoney r = new B_FixMoney();
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
        public B_FixMoney DataRowToModel(DataRow row)
        {
            B_FixMoney model = new B_FixMoney();
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
                if (row["amoney"] != null && row["amoney"].ToString() != "")
                {
                    model.amoney = decimal.Parse(row["amoney"].ToString());
                }
                if (row["dmoney"] != null && row["dmoney"].ToString() != "")
                {
                    model.dmoney = decimal.Parse(row["dmoney"].ToString());
                }
                if (row["premark"] != null)
                {
                    model.premark = row["premark"].ToString();
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
        public List<B_FixMoney> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,amoney,dmoney,premark,cdate,maker ");
            strSql.Append(" FROM B_FixMoney ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_FixMoney> r = new List<B_FixMoney>();
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
        public bool UpdateFixMoney(B_FixMoney model, ArrayList plist)
        {
            bool r = false;
            StringBuilder sqlStr = new StringBuilder();
            if (model != null)
            {
                sqlStr.AppendFormat(" delete from B_FixMoney where sid='{0}';", model.sid);
                sqlStr.AppendFormat(" insert into B_FixMoney (sid,amoney,dmoney,premark,cdate,maker) values ('{0}',{1},{2},'{3}','{4}','{5}');", model.sid, model.amoney, model.dmoney, model.premark, model.cdate, model.maker);
                if (plist.Count > 0)
                {
                    foreach (ArrayList p in plist)
                    {
                        sqlStr.AppendFormat(" update  B_FixProduction set pmoney={0} where sid='{1}' and pname='{2}';", Convert.ToDecimal(p[1]), model.sid, p[0]);
                    }
                }
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, sqlStr.ToString(), null) > 0)
                {
                    r = true;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
