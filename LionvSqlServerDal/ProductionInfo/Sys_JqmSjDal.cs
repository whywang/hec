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
    public class Sys_JqmSjDal : ISys_JqmSjDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmSj");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmSj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmSj(");
			strSql.Append("sjname,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@sjname,@mcode,@maker)");
			SqlParameter[] parameters = {
					new SqlParameter("@sjname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sjname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.maker;


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
		public bool Update( Sys_JqmSj model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmSj set ");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker");
            strSql.Append(" where sjname=@sjname");
			SqlParameter[] parameters = {
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sjname", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.mcode;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.sjname;

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
		public bool Delete(string sjname)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmSj ");
            strSql.AppendFormat(" where sjname='{0}'; ", sjname);
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
		public  Sys_JqmSj Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sjname,mcode,maker,cdate from Sys_JqmSj ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmSj r = new Sys_JqmSj();
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
		public  Sys_JqmSj DataRowToModel(DataRow row)
		{
			 Sys_JqmSj model=new  Sys_JqmSj();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sjname"]!=null)
				{
					model.sjname=row["sjname"].ToString();
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
					model.cdate=row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_JqmSj> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sjname,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmSj where 1=1 {0}", strWhere);
            List<Sys_JqmSj> r = new List<Sys_JqmSj>();
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

		#endregion  ExtensionMethod
    }
}
