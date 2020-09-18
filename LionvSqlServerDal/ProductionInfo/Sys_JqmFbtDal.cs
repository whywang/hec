using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_JqmFbtDal : ISys_JqmFbtDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmFbt");
	 	    strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmFbt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmFbt(");
			strSql.Append("fbname,fbcode,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@fbname,@fbcode,@mcode,@maker)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@fbname", SqlDbType.NVarChar,30),
					new SqlParameter("@fbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.fbname;
			parameters[1].Value = model.fbcode;
			parameters[2].Value = model.mcode;
			parameters[3].Value = model.maker;

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
		public bool Update( Sys_JqmFbt model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmFbt set ");
			strSql.Append("fbname=@fbname,");
			strSql.Append("mcode=@mcode");
            strSql.Append(" where fbcode=@fbcode");
			SqlParameter[] parameters = {
					new SqlParameter("@fbname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@fbcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.fbname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.fbcode;

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
		public bool Delete(string fbcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmFbt ");
            strSql.AppendFormat(" where fbcode='{0}'; ", fbcode);
            strSql.AppendFormat(" delete from Sys_RproductionJqmFbt where fbcode='{0}' ", fbcode);
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
        public Sys_JqmFbt Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,fbname,fbcode,mcode,maker,cdate from Sys_JqmFbt ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmFbt r = new Sys_JqmFbt();
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
		public  Sys_JqmFbt DataRowToModel(DataRow row)
		{
			 Sys_JqmFbt model=new  Sys_JqmFbt();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["fbname"]!=null)
				{
					model.fbname=row["fbname"].ToString();
				}
				if(row["fbcode"]!=null)
				{
					model.fbcode=row["fbcode"].ToString();
				}
				if(row["mcode"]!=null)
				{
					model.mcode=row["mcode"].ToString();
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
        public List<Sys_JqmFbt> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,fbname,fbcode,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmFbt where 1=1 {0}", strWhere);
            List<Sys_JqmFbt> r = new List<Sys_JqmFbt>();
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
            sql = "select isnull(max(convert(int,fbcode)),0) as n from Sys_JqmFbt ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
