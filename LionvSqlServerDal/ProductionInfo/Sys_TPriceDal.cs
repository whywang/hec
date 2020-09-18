using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_TPriceDal:ISys_TPriceDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_TPrice");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_TPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_TPrice(");
			strSql.Append("ptname,ptcode,lpname,lpcode,isfw,fattr,lv,tv,price,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@ptname,@ptcode,@lpname,@lpcode,@isfw,@fattr,@lv,@tv,@price,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lpname", SqlDbType.NVarChar,30),
					new SqlParameter("@lpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@isfw", SqlDbType.Bit,1),
					new SqlParameter("@fattr", SqlDbType.NVarChar,10),
					new SqlParameter("@lv", SqlDbType.Decimal,9),
					new SqlParameter("@tv", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.ptname;
			parameters[1].Value = model.ptcode;
			parameters[2].Value = model.lpname;
			parameters[3].Value = model.lpcode;
			parameters[4].Value = model.isfw;
			parameters[5].Value = model.fattr;
			parameters[6].Value = model.lv;
			parameters[7].Value = model.tv;
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
		public bool Update( Sys_TPrice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_TPrice set ");
			strSql.Append("ptname=@ptname,");
			strSql.Append("lpname=@lpname,");
			strSql.Append("lpcode=@lpcode,");
			strSql.Append("isfw=@isfw,");
			strSql.Append("fattr=@fattr,");
			strSql.Append("lv=@lv,");
			strSql.Append("tv=@tv,");
			strSql.Append("price=@price,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where ptcode=@ptcode");
			SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@lpname", SqlDbType.NVarChar,30),
					new SqlParameter("@lpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@isfw", SqlDbType.Bit,1),
					new SqlParameter("@fattr", SqlDbType.NVarChar,10),
					new SqlParameter("@lv", SqlDbType.Decimal,9),
					new SqlParameter("@tv", SqlDbType.Decimal,9),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.ptname;
			parameters[1].Value = model.lpname;
			parameters[2].Value = model.lpcode;
			parameters[3].Value = model.isfw;
			parameters[4].Value = model.fattr;
			parameters[5].Value = model.lv;
			parameters[6].Value = model.tv;
			parameters[7].Value = model.price;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;
			parameters[10].Value = model.ptcode;

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
			strSql.Append("delete from Sys_TPrice ");
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
		public  Sys_TPrice Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ptname,ptcode,lpname,lpcode,isfw,fattr,lv,tv,price,maker,cdate from Sys_TPrice ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_TPrice r = new Sys_TPrice();
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
		public  Sys_TPrice DataRowToModel(DataRow row)
		{
			 Sys_TPrice model=new  Sys_TPrice();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ptname"]!=null)
				{
					model.ptname=row["ptname"].ToString();
				}
				if(row["ptcode"]!=null)
				{
					model.ptcode=row["ptcode"].ToString();
				}
				if(row["lpname"]!=null)
				{
					model.lpname=row["lpname"].ToString();
				}
				if(row["lpcode"]!=null)
				{
					model.lpcode=row["lpcode"].ToString();
				}
				if(row["isfw"]!=null && row["isfw"].ToString()!="")
				{
					if((row["isfw"].ToString()=="1")||(row["isfw"].ToString().ToLower()=="true"))
					{
						model.isfw=true;
					}
					else
					{
						model.isfw=false;
					}
				}
				if(row["fattr"]!=null)
				{
					model.fattr=row["fattr"].ToString();
				}
				if(row["lv"]!=null && row["lv"].ToString()!="")
				{
					model.lv=decimal.Parse(row["lv"].ToString());
				}
				if(row["tv"]!=null && row["tv"].ToString()!="")
				{
					model.tv=decimal.Parse(row["tv"].ToString());
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
        public List<Sys_TPrice> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ptname,ptcode,lpname,lpcode,isfw,fattr,lv,tv,price,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_TPrice where 1=1 {0}", strWhere);
            List<Sys_TPrice> r = new List<Sys_TPrice>();
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
            sql = "select isnull(max(convert(int,ptcode)),0) as n from Sys_TPrice ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
