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
    public class B_GlassOrderDal : IB_GlassOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_GlassOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_GlassOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_GlassOrder(");
			strSql.Append("sid,msid,scode,sdcode,customer,telephone,address,city,citycode,dname,dcode,remark,qtimg,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@msid,@scode,@sdcode,@customer,@telephone,@address,@city,@citycode,@dname,@dcode,@remark,@qtimg,@maker,@cdate)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@msid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.msid;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.sdcode;
			parameters[4].Value = model.customer;
			parameters[5].Value = model.telephone;
			parameters[6].Value = model.address;
			parameters[7].Value = model.city;
			parameters[8].Value = model.citycode;
			parameters[9].Value = model.dname;
			parameters[10].Value = model.dcode;
			parameters[11].Value = model.remark;
			parameters[12].Value = model.qtimg;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;

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
		public bool Update( B_GlassOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_GlassOrder set ");
			strSql.Append("msid=@msid,");
			strSql.Append("scode=@scode,");
			strSql.Append("sdcode=@sdcode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("address=@address,");
			strSql.Append("city=@city,");
			strSql.Append("citycode=@citycode,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("remark=@remark,");
			strSql.Append("qtimg=@qtimg,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@msid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.msid;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.sdcode;
			parameters[3].Value = model.customer;
			parameters[4].Value = model.telephone;
			parameters[5].Value = model.address;
			parameters[6].Value = model.city;
			parameters[7].Value = model.citycode;
			parameters[8].Value = model.dname;
			parameters[9].Value = model.dcode;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.qtimg;
			parameters[12].Value = model.maker;
			parameters[13].Value = model.cdate;
			parameters[14].Value = model.id;
			parameters[15].Value = model.sid;

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
            strSql.AppendFormat("delete from B_GlassOrder where 1=1 {0}", where);
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
        public B_GlassOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,msid,scode,sdcode,customer,telephone,address,city,citycode,dname,dcode,remark,qtimg,maker,cdate from B_GlassOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_GlassOrder r = new B_GlassOrder();
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
		public  B_GlassOrder DataRowToModel(DataRow row)
		{
			 B_GlassOrder model=new  B_GlassOrder();
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
				if(row["msid"]!=null)
				{
					model.msid=row["msid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["sdcode"]!=null)
				{
					model.sdcode=row["sdcode"].ToString();
				}
				if(row["customer"]!=null)
				{
					model.customer=row["customer"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
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
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["qtimg"]!=null)
				{
					model.qtimg=row["qtimg"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_GlassOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,msid,scode,sdcode,customer,telephone,address,city,citycode,dname,dcode,remark,qtimg,maker,cdate ");
			strSql.Append(" FROM B_GlassOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_GlassOrder> r = new List<B_GlassOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_GlassOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
