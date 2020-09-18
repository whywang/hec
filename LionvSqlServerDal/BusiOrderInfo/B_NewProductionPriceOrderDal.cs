﻿using System;
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
    public class B_NewProductionPriceOrderDal : IB_NewProductionPriceOrderDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_NewProductionPriceOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_NewProductionPriceOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_NewProductionPriceOrder(");
			strSql.Append("sid,osid,scode,cityname,shopname,remark,bdcode,maker,cdate,citycode,shopcode)");
			strSql.Append(" values (");
            strSql.Append("@sid,@osid,@scode,@cityname,@shopname,@remark,@bdcode,@maker,@cdate,@citycode,@shopcode)");

			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@cityname", SqlDbType.NVarChar,50),
					new SqlParameter("@shopname", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@shopcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.cityname;
			parameters[4].Value = model.shopname;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.bdcode;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;
            parameters[9].Value = model.citycode;
            parameters[10].Value = model.shopcode;
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
		public bool Update( B_NewProductionPriceOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_NewProductionPriceOrder set ");
			strSql.Append("cityname=@cityname,");
			strSql.Append("shopname=@shopname,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@cityname", SqlDbType.NVarChar,50),
					new SqlParameter("@shopname", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};

			parameters[1].Value = model.cityname;
			parameters[2].Value = model.shopname;
			parameters[3].Value = model.remark;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.sid;

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
			strSql.Append("delete from B_NewProductionPriceOrder ");
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
		public  B_NewProductionPriceOrder Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,scode,cityname,shopname,remark,bdcode,maker,cdate,citycode,shopcode from B_NewProductionPriceOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_NewProductionPriceOrder r = new B_NewProductionPriceOrder();
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
		public  B_NewProductionPriceOrder DataRowToModel(DataRow row)
		{
			 B_NewProductionPriceOrder model=new  B_NewProductionPriceOrder();
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
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["cityname"]!=null)
				{
					model.cityname=row["cityname"].ToString();
				}
				if(row["shopname"]!=null)
				{
					model.shopname=row["shopname"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["bdcode"]!=null)
				{
					model.bdcode=row["bdcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
                if (row["shopcode"] != null)
                {
                    model.shopcode = row["shopcode"].ToString();
                }
                if (row["citycode"] != null)
                {
                    model.citycode = row["citycode"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_NewProductionPriceOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,osid,scode,cityname,shopname,remark,bdcode,maker,cdate,citycode,shopcode  ");
			strSql.Append(" FROM B_NewProductionPriceOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_NewProductionPriceOrder> r = new List<B_NewProductionPriceOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_NewProductionPriceOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
