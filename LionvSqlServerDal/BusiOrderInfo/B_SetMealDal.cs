using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_SetMealDal : IB_SetMealDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_SetMeal");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_SetMeal model)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.AppendFormat("delete from  B_SetMeal where sid='{0}' and tccode='{1}';",model.sid,model.tccode);
            strSql.Append("insert into B_SetMeal(");
            strSql.Append("sid,tsid,tcname,tccode,tgprice,tcprice,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@tsid,@tcname,@tccode,@tgprice,@tcprice,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@tsid", SqlDbType.NVarChar,50),
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30),
                    new SqlParameter("@tgprice", SqlDbType.Decimal,9),
					new SqlParameter("@tcprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.tsid;
            parameters[2].Value = model.tcname;
            parameters[3].Value = model.tccode;
            parameters[4].Value = model.tgprice;
            parameters[5].Value = model.tcprice;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;

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
        public bool Update( B_SetMeal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SetMeal set ");
            strSql.Append("sid=@sid,");
            strSql.Append("tcname=@tcname,");
            strSql.Append("tccode=@tccode,");
            strSql.Append("tcprice=@tcprice,");
            strSql.Append("tgprice=@tgprice,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tsid=@tsid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tccode", SqlDbType.NVarChar,30),
					new SqlParameter("@tcprice", SqlDbType.Decimal,9),
                    new SqlParameter("@tgprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.tcname;
            parameters[2].Value = model.tccode;
            parameters[3].Value = model.tcprice;
            parameters[4].Value = model.tgprice;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.tsid;

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
            strSql.Append("delete from B_SetMeal ");
            strSql.AppendFormat(" where 1=1 {0}",where);
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
        public  B_SetMeal Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,tsid,tcname,tccode,tcprice,tgprice,maker,cdate from B_SetMeal ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_SetMeal r = new  B_SetMeal();
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
        public  B_SetMeal DataRowToModel(DataRow row)
        {
             B_SetMeal model = new  B_SetMeal();
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
                if (row["tsid"] != null)
                {
                    model.tsid = row["tsid"].ToString();
                }
                if (row["tcname"] != null)
                {
                    model.tcname = row["tcname"].ToString();
                }
                if (row["tccode"] != null)
                {
                    model.tccode = row["tccode"].ToString();
                }
                if (row["tcprice"] != null && row["tcprice"].ToString() != "")
                {
                    model.tcprice = decimal.Parse(row["tcprice"].ToString());
                }
                if (row["tgprice"] != null && row["tgprice"].ToString() != "")
                {
                    model.tgprice = decimal.Parse(row["tgprice"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_SetMeal> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,tsid,tcname,tccode,tcprice,tgprice,maker,cdate ");
            strSql.Append(" FROM B_SetMeal ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_SetMeal> r = new List<B_SetMeal>();
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
        public bool DelTcProduction(string sid, string tsid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from B_ProductionItem where psid in (select psid from B_GroupProduction where sid='{0}' and tsid='{1}');", sid,tsid);
            strSql.AppendFormat(" delete from B_GroupProduction where sid='{0}' and tsid='{1}';", sid, tsid);
            strSql.AppendFormat(" delete from B_SetMeal where sid='{0}' and tsid='{1}';", sid, tsid);
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
        #region//订单套餐供货金额
        public decimal GQueryTcMoney(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(tgprice),0) as n  from B_SetMeal ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r =Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
