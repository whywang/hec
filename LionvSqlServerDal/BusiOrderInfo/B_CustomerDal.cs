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
    public class B_CustomerDal : IB_CustomerDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Customer");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Customer(");
            strSql.Append("sid,city,citycode,dname,dcode,customer,telephone,community,address,bdcode,ctype,maker,cdate,acity,aprovince)");
            strSql.Append(" values (");
            strSql.Append("@sid,@city,@citycode,@dname,@dcode,@customer,@telephone,@community,@address,@bdcode,@ctype,@maker,@cdate,@acity,@aprovince)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.city;
            parameters[2].Value = model.citycode;
            parameters[3].Value = model.dname;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.customer;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.community;
            parameters[8].Value = model.address;
            parameters[9].Value = model.bdcode;
            parameters[10].Value = model.ctype;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
            parameters[13].Value = model.acity;
            parameters[14].Value = model.aprovince;
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
        public bool Update(B_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Customer set ");
            strSql.Append("city=@city,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.city;
            parameters[1].Value = model.citycode;
            parameters[2].Value = model.dname;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.customer;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.community;
            parameters[7].Value = model.address;
            parameters[8].Value = model.bdcode;
            parameters[9].Value = model.ctype;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;
            parameters[12].Value = model.sid;

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
            strSql.AppendFormat("delete from B_Customer where 1=1 {0}", where);
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
        public B_Customer Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,city,citycode,dname,dcode,customer,telephone,community,address,bdcode,ctype,maker,cdate,acity,aprovince from B_Customer ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_Customer r = new B_Customer();
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
        public B_Customer DataRowToModel(DataRow row)
        {
            B_Customer model = new B_Customer();
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
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["citycode"] != null)
                {
                    model.citycode = row["citycode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["community"] != null)
                {
                    model.community = row["community"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                } 
                if (row["acity"] != null)
                {
                    model.acity = row["acity"].ToString();
                }
                if (row["aprovince"] != null)
                {
                    model.aprovince = row["aprovince"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_Customer> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,city,citycode,dname,dcode,customer,telephone,community,address,bdcode,ctype,maker,cdate,acity,aprovince ");
            strSql.Append(" FROM B_Customer ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_Customer> r = new List<B_Customer>();
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
