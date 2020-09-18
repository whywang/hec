using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvCommonDal;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using System.Data.SqlClient;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_OrdersDal : IB_OrdersDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Orders");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Orders(");
            strSql.Append("csid,sid,zcode,customer,telephone,community,address,city,citycode,dname,dcode,mqmo,yqmo,qbo,czo,dso,ymo,maker,cdate,acity,aprovince)");
            strSql.Append(" values (");
            strSql.Append("@csid,@sid,@zcode,@customer,@telephone,@community,@address,@city,@citycode,@dname,@dcode,@mqmo,@yqmo,@qbo,@czo,@dso,@ymo,@maker,@cdate,@acity,@aprovince)");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@zcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mqmo", SqlDbType.Bit,1),
					new SqlParameter("@yqmo", SqlDbType.Bit,1),
					new SqlParameter("@qbo", SqlDbType.Bit,1),
					new SqlParameter("@czo", SqlDbType.Bit,1),
					new SqlParameter("@dso", SqlDbType.Bit,1),
					new SqlParameter("@ymo", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.zcode;
            parameters[3].Value = model.customer;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.community;
            parameters[6].Value = model.address;
            parameters[7].Value = model.city;
            parameters[8].Value = model.citycode;
            parameters[9].Value = model.dname;
            parameters[10].Value = model.dcode;
            parameters[11].Value = model.mqmo;
            parameters[12].Value = model.yqmo;
            parameters[13].Value = model.qbo;
            parameters[14].Value = model.czo;
            parameters[15].Value = model.dso;
            parameters[16].Value = model.ymo;
            parameters[17].Value = model.maker;
            parameters[18].Value = model.cdate;
            parameters[19].Value = model.acity;
            parameters[20].Value = model.aprovince;
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
        public bool Update(B_Orders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Orders set ");
            strSql.Append("csid=@csid,");
            strSql.Append("zcode=@zcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("city=@city,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("mqmo=@mqmo,");
            strSql.Append("yqmo=@yqmo,");
            strSql.Append("qbo=@qbo,");
            strSql.Append("czo=@czo,");
            strSql.Append("dso=@dso,");
            strSql.Append("ymo=@ymo,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@zcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mqmo", SqlDbType.Bit,1),
					new SqlParameter("@yqmo", SqlDbType.Bit,1),
					new SqlParameter("@qbo", SqlDbType.Bit,1),
					new SqlParameter("@czo", SqlDbType.Bit,1),
					new SqlParameter("@dso", SqlDbType.Bit,1),
					new SqlParameter("@ymo", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.zcode;
            parameters[2].Value = model.customer;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.community;
            parameters[5].Value = model.address;
            parameters[6].Value = model.city;
            parameters[7].Value = model.citycode;
            parameters[8].Value = model.dname;
            parameters[9].Value = model.dcode;
            parameters[10].Value = model.mqmo;
            parameters[11].Value = model.yqmo;
            parameters[12].Value = model.qbo;
            parameters[13].Value = model.czo;
            parameters[14].Value = model.dso;
            parameters[15].Value = model.ymo;
            parameters[16].Value = model.maker;
            parameters[17].Value = model.cdate;
            parameters[18].Value = model.id;
            parameters[19].Value = model.sid;

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
            strSql.AppendFormat("delete from B_Orders where 1=1 {0}", where);
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
        public B_Orders Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,csid,sid,zcode,customer,telephone,community,address,city,citycode,dname,dcode,mqmo,yqmo,qbo,czo,dso,ymo,maker,cdate,acity,aprovince from B_Orders ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_Orders r = new B_Orders();
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
        /// 获得数据列表
        /// </summary>
        public List<B_Orders> QueryList(string strWhere, int tnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select top {0} id,csid,sid,zcode,customer,telephone,community,address,city,citycode,dname,dcode,mqmo,yqmo,qbo,czo,dso,ymo,maker,cdate,acity,aprovince ", tnum.ToString());
            strSql.Append(" FROM B_Orders ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_Orders> r = new List<B_Orders>();
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_Orders DataRowToModel(DataRow row)
        {
            B_Orders model = new B_Orders();
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
                if (row["zcode"] != null)
                {
                    model.zcode = row["zcode"].ToString();
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
                if (row["mqmo"] != null && row["mqmo"].ToString() != "")
                {
                    if ((row["mqmo"].ToString() == "1") || (row["mqmo"].ToString().ToLower() == "true"))
                    {
                        model.mqmo = true;
                    }
                    else
                    {
                        model.mqmo = false;
                    }
                }
                if (row["yqmo"] != null && row["yqmo"].ToString() != "")
                {
                    if ((row["yqmo"].ToString() == "1") || (row["yqmo"].ToString().ToLower() == "true"))
                    {
                        model.yqmo = true;
                    }
                    else
                    {
                        model.yqmo = false;
                    }
                }
                if (row["qbo"] != null && row["qbo"].ToString() != "")
                {
                    if ((row["qbo"].ToString() == "1") || (row["qbo"].ToString().ToLower() == "true"))
                    {
                        model.qbo = true;
                    }
                    else
                    {
                        model.qbo = false;
                    }
                }
                if (row["czo"] != null && row["czo"].ToString() != "")
                {
                    if ((row["czo"].ToString() == "1") || (row["czo"].ToString().ToLower() == "true"))
                    {
                        model.czo = true;
                    }
                    else
                    {
                        model.czo = false;
                    }
                }
                if (row["dso"] != null && row["dso"].ToString() != "")
                {
                    if ((row["dso"].ToString() == "1") || (row["dso"].ToString().ToLower() == "true"))
                    {
                        model.dso = true;
                    }
                    else
                    {
                        model.dso = false;
                    }
                }
                if (row["ymo"] != null && row["ymo"].ToString() != "")
                {
                    if ((row["ymo"].ToString() == "1") || (row["ymo"].ToString().ToLower() == "true"))
                    {
                        model.ymo = true;
                    }
                    else
                    {
                        model.ymo = false;
                    }
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
        public List<B_Orders> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,csid,sid,zcode,customer,telephone,community,address,city,citycode,dname,dcode,mqmo,yqmo,qbo,czo,dso,ymo,maker,cdate,acity,aprovince ");
            strSql.Append(" FROM B_Orders ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_Orders> r = new List<B_Orders>();
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
            DataTable dt = new Fy().BusiPage("B_Orders", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
