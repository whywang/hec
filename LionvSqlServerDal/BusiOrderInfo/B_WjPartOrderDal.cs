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
   public class B_WjPartOrderDal:IB_WjPartOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WjPartOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WjPartOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_WjPartOrder(");
			strSql.Append("sid,osid,wcode,scode,areaname,areacode,cityname,citycode,dname,dcode,customer,telephone,address,bdcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@wcode,@scode,@areaname,@areacode,@cityname,@citycode,@dname,@dcode,@customer,@telephone,@address,@bdcode,@maker,@cdate)");

			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@areaname", SqlDbType.NVarChar,30),
					new SqlParameter("@areacode", SqlDbType.NVarChar,30),
					new SqlParameter("@cityname", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.wcode;
			parameters[3].Value = model.scode;
			parameters[4].Value = model.areaname;
			parameters[5].Value = model.areacode;
			parameters[6].Value = model.cityname;
			parameters[7].Value = model.citycode;
			parameters[8].Value = model.dname;
			parameters[9].Value = model.dcode;
			parameters[10].Value = model.customer;
			parameters[11].Value = model.telephone;
			parameters[12].Value = model.address;
			parameters[13].Value = model.bdcode;
			parameters[14].Value = model.maker;
			parameters[15].Value = model.cdate;

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
		public bool Update( B_WjPartOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_WjPartOrder set ");
			strSql.Append("osid=@osid,");
			strSql.Append("wcode=@wcode,");
			strSql.Append("scode=@scode,");
			strSql.Append("areaname=@areaname,");
			strSql.Append("areacode=@areacode,");
			strSql.Append("cityname=@cityname,");
			strSql.Append("citycode=@citycode,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("address=@address,");
			strSql.Append("bdcode=@bdcode,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@areaname", SqlDbType.NVarChar,30),
					new SqlParameter("@areacode", SqlDbType.NVarChar,30),
					new SqlParameter("@cityname", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.wcode;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.areaname;
			parameters[4].Value = model.areacode;
			parameters[5].Value = model.cityname;
			parameters[6].Value = model.citycode;
			parameters[7].Value = model.dname;
			parameters[8].Value = model.dcode;
			parameters[9].Value = model.customer;
			parameters[10].Value = model.telephone;
			parameters[11].Value = model.address;
			parameters[12].Value = model.bdcode;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;
			parameters[15].Value = model.id;
			parameters[16].Value = model.sid;

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
            strSql.AppendFormat("delete from B_WjPartOrder where 1=1 {0}", where);
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
		public  B_WjPartOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,osid,wcode,scode,areaname,areacode,cityname,citycode,dname,dcode,customer,telephone,address,bdcode,maker,cdate from B_WjPartOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_WjPartOrder r = new B_WjPartOrder();
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
		public  B_WjPartOrder DataRowToModel(DataRow row)
		{
			 B_WjPartOrder model=new  B_WjPartOrder();
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
				if(row["wcode"]!=null)
				{
					model.wcode=row["wcode"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["areaname"]!=null)
				{
					model.areaname=row["areaname"].ToString();
				}
				if(row["areacode"]!=null)
				{
					model.areacode=row["areacode"].ToString();
				}
				if(row["cityname"]!=null)
				{
					model.cityname=row["cityname"].ToString();
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
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
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
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_WjPartOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,osid,wcode,scode,areaname,areacode,cityname,citycode,dname,dcode,customer,telephone,address,bdcode,maker,cdate ");
			strSql.Append(" FROM B_WjPartOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WjPartOrder> r = new List<B_WjPartOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_WjPartOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
