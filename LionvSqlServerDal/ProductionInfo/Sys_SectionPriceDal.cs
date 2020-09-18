using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SectionPriceDal : ISys_SectionPriceDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SectionPrice");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SectionPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SectionPrice(");
			strSql.Append("jname,jcode,sname,scode,jattr,isfrist,maxv,minv,price,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@jname,@jcode,@sname,@scode,@jattr,@isfrist,@maxv,@minv,@price,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@jcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@jattr", SqlDbType.NVarChar,30),
					new SqlParameter("@isfrist", SqlDbType.Bit,1),
					new SqlParameter("@maxv", SqlDbType.Int,4),
					new SqlParameter("@minv", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.jname;
			parameters[1].Value = model.jcode;
			parameters[2].Value = model.sname;
			parameters[3].Value = model.scode;
			parameters[4].Value = model.jattr;
			parameters[5].Value = model.isfrist;
			parameters[6].Value = model.maxv;
			parameters[7].Value = model.minv;
			parameters[8].Value = model.price;
			parameters[9].Value = model.maker;
			parameters[10].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Update( Sys_SectionPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SectionPrice set ");
			strSql.Append("jname=@jname,");
			strSql.Append("sname=@sname,");
			strSql.Append("scode=@scode,");
			strSql.Append("jattr=@jattr,");
			strSql.Append("isfrist=@isfrist,");
			strSql.Append("maxv=@maxv,");
			strSql.Append("minv=@minv,");
			strSql.Append("price=@price,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where jcode=@jcode");
			SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.NVarChar,30),
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@jattr", SqlDbType.NVarChar,30),
					new SqlParameter("@isfrist", SqlDbType.Bit,1),
					new SqlParameter("@maxv", SqlDbType.Int,4),
					new SqlParameter("@minv", SqlDbType.Int,4),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@jcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.jname;
			parameters[1].Value = model.sname;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.jattr;
			parameters[4].Value = model.isfrist;
			parameters[5].Value = model.maxv;
			parameters[6].Value = model.minv;
			parameters[7].Value = model.price;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;
			parameters[10].Value = model.jcode;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
			strSql.Append("delete from Sys_SectionPrice ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SectionPrice Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,jname,jcode,sname,scode,jattr,isfrist,maxv,minv,price,maker,cdate from Sys_SectionPrice ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SectionPrice r = new Sys_SectionPrice();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
		public  Sys_SectionPrice DataRowToModel(DataRow row)
		{
			 Sys_SectionPrice model=new  Sys_SectionPrice();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["jname"]!=null)
				{
					model.jname=row["jname"].ToString();
				}
				if(row["jcode"]!=null)
				{
					model.jcode=row["jcode"].ToString();
				}
				if(row["sname"]!=null)
				{
					model.sname=row["sname"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["jattr"]!=null)
				{
					model.jattr=row["jattr"].ToString();
				}
				if(row["isfrist"]!=null && row["isfrist"].ToString()!="")
				{
					if((row["isfrist"].ToString()=="1")||(row["isfrist"].ToString().ToLower()=="true"))
					{
						model.isfrist=true;
					}
					else
					{
						model.isfrist=false;
					}
				}
				if(row["maxv"]!=null && row["maxv"].ToString()!="")
				{
					model.maxv=int.Parse(row["maxv"].ToString());
				}
				if(row["minv"]!=null && row["minv"].ToString()!="")
				{
					model.minv=int.Parse(row["minv"].ToString());
				}
				if(row["price"]!=null && row["price"].ToString()!="")
				{
					model.price=decimal.Parse(row["price"].ToString());
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
        public List<Sys_SectionPrice> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,jname,jcode,sname,scode,jattr,isfrist,maxv,minv,price,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SectionPrice where 1=1 {0}", strWhere);
            List<Sys_SectionPrice> r = new List<Sys_SectionPrice>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,jcode)),0) as n from Sys_SectionPrice ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
