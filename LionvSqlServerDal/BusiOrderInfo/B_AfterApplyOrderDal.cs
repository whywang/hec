using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterApplyOrderDal : IB_AfterApplyOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterApplyOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(B_AfterApplyOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterApplyOrder(");
			strSql.Append("sid,scode,oscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,remark,maker,cdate,qtimg,osid)");
			strSql.Append(" values (");
            strSql.Append("@sid,@scode,@oscode,@city,@citycode,@dname,@dcode,@customer,@telephone,@aprovince,@acity,@address,@areason,@remark,@maker,@cdate,@qtimg,@osid)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,200),
					new SqlParameter("@osid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.oscode;
			parameters[3].Value = model.city;
			parameters[4].Value = model.citycode;
			parameters[5].Value = model.dname;
			parameters[6].Value = model.dcode;
			parameters[7].Value = model.customer;
			parameters[8].Value = model.telephone;
			parameters[9].Value = model.aprovince;
			parameters[10].Value = model.acity;
			parameters[11].Value = model.address;
			parameters[12].Value = model.areason;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.maker;
			parameters[15].Value = model.cdate;
            parameters[16].Value = model.qtimg;
            parameters[17].Value = model.osid;
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
		public bool Update(B_AfterApplyOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterApplyOrder set ");
			strSql.Append("oscode=@oscode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("aprovince=@aprovince,");
			strSql.Append("acity=@acity,");
			strSql.Append("address=@address,");
			strSql.Append("areason=@areason,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
 
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
 
			parameters[0].Value = model.oscode;
			parameters[1].Value = model.customer;
			parameters[2].Value = model.telephone;
			parameters[3].Value = model.aprovince;
			parameters[4].Value = model.acity;
			parameters[5].Value = model.address;
			parameters[6].Value = model.areason;
			parameters[7].Value = model.remark;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;
			parameters[10].Value = model.sid;

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
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_AfterApplyOrder where 1=1 {0}", where);
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
        public B_AfterApplyOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,osid,scode,oscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,remark,maker,cdate,qtimg  from B_AfterApplyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterApplyOrder r = new B_AfterApplyOrder();
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
		public B_AfterApplyOrder DataRowToModel(DataRow row)
		{
			B_AfterApplyOrder model=new B_AfterApplyOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["oscode"]!=null)
				{
					model.oscode=row["oscode"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["citycode"]!=null)
				{
					model.citycode=row["citycode"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["customer"]!=null)
				{
					model.customer=row["customer"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["aprovince"]!=null)
				{
					model.aprovince=row["aprovince"].ToString();
				}
				if(row["acity"]!=null)
				{
					model.acity=row["acity"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["areason"]!=null)
				{
					model.areason=row["areason"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterApplyOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,osid,scode,oscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,remark,maker,cdate,qtimg ");
			strSql.Append(" FROM B_AfterApplyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterApplyOrder> r = new List<B_AfterApplyOrder>();
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
        #region//获取订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_AfterApplyOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion
        public int GetOrderNum()
        {
            int r = -1;
            string dtv = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + "01 00:00:00";
            string sql = "select isnull(count(1),0) as n from B_AfterApplyOrder where cdate>'"+dtv+"' and cdate<getdate() ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
