using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;
using LionvIDal.BusiOrderInfo;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_CustomeMoneyOrderDal : IB_CustomeMoneyOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CustomeMoneyOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_CustomeMoneyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CustomeMoneyOrder(");
            strSql.Append("csid,sid,ycode,ccode,customer,telephone,address,omoney,maker,cdate,remark,settlement,bdcode)");
            strSql.Append(" values (");
            strSql.Append("@csid,@sid,@ycode,@ccode,@customer,@telephone,@address,@omoney,@maker,@cdate,@remark,@settlement,@bdcode)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@settlement", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.ycode;
            parameters[3].Value = model.ccode;
            parameters[4].Value = model.customer;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.address;
            parameters[7].Value = model.omoney;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.remark;
            parameters[11].Value = model.settlement;
            parameters[12].Value = model.bdcode;
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
        public bool Update( B_CustomeMoneyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CustomeMoneyOrder set ");
            strSql.Append("sid=@sid,");
            strSql.Append("ycode=@ycode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("omoney=@omoney,");
            strSql.Append("maker=@maker,");
            strSql.Append("settlement=@settlement,");
            strSql.Append("remark=@remark,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where csid=@csid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@settlement", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@csid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ycode;
            parameters[2].Value = model.customer;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.address;
            parameters[5].Value = model.omoney;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.settlement;
            parameters[8].Value = model.remark;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.csid;

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
            strSql.AppendFormat("delete from B_CustomeMoneyOrder where 1=1 {0}", where);
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
        public  B_CustomeMoneyOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,csid,sid,ycode,ccode,customer,telephone,address,omoney,maker,cdate,remark,bdcode,settlement from B_CustomeMoneyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CustomeMoneyOrder r = new B_CustomeMoneyOrder();
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
        public  B_CustomeMoneyOrder DataRowToModel(DataRow row)
        {
             B_CustomeMoneyOrder model = new  B_CustomeMoneyOrder();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["csid"] != null)
                {
                    model.csid = row["csid"].ToString();
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["ycode"] != null)
                {
                    model.ycode = row["ycode"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["omoney"] != null && row["omoney"].ToString() != "")
                {
                    model.omoney = decimal.Parse(row["omoney"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
                if (row["bdcode"] != null && row["bdcode"].ToString() != "")
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["remark"] != null && row["remark"].ToString() != "")
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["settlement"] != null && row["settlement"].ToString() != "")
                {
                    model.settlement = row["settlement"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_CustomeMoneyOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,csid,sid,ycode,ccode,customer,telephone,address,omoney,maker,cdate,remark,bdcode,settlement ");
            strSql.Append(" FROM B_CustomeMoneyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_CustomeMoneyOrder> r = new List<B_CustomeMoneyOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_CustomeMoneyOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
