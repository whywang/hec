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
   	public partial class Sys_LocksTypeDal:ISys_LocksTypeDal
	{
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string lcode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_LocksType");
			strSql.AppendFormat(" where 1=1 {0} ",lcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_LocksType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_LocksType(");
			strSql.Append("lname,lcode,lprice,maker,cdate,dcode)");
			strSql.Append(" values (");
			strSql.Append("@lname,@lcode,@lprice,@maker,@cdate,@dcode)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.lcode;
			parameters[2].Value = model.lprice;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
            parameters[5].Value = model.dcode;
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
		public bool Update( Sys_LocksType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_LocksType set ");
			strSql.Append("lname=@lname,");
			strSql.Append("lprice=@lprice,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where lcode=@lcode");
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lprice", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.lprice;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.lcode;

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
		public bool Delete(string lcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_LocksType ");
			strSql.Append(" where lcode=@lcode ");
			SqlParameter[] parameters = {
					new SqlParameter("@lcode", SqlDbType.NVarChar,30)			};
			parameters[0].Value = lcode;

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
		/// 得到一个对象实体
		/// </summary>
		public  Sys_LocksType Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lname,lcode,lprice,maker,cdate ,dcode from Sys_LocksType ");
			strSql.AppendFormat(" where 1=1 {0}",where);
			 Sys_LocksType r=new  Sys_LocksType();
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
		public  Sys_LocksType DataRowToModel(DataRow row)
		{
			 Sys_LocksType model=new  Sys_LocksType();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lname"]!=null)
				{
					model.lname=row["lname"].ToString();
				}
				if(row["lcode"]!=null)
				{
					model.lcode=row["lcode"].ToString();
				}
				if(row["lprice"]!=null && row["lprice"].ToString()!="")
				{
					model.lprice=decimal.Parse(row["lprice"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
                } 
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_LocksType> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,lname,lcode,lprice,maker,cdate ,dcode");
			strSql.Append(" FROM Sys_LocksType ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_LocksType> r = new List<Sys_LocksType>();
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
            sql = "select isnull(max(lcode),0) as n from Sys_LocksType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
	}
}
