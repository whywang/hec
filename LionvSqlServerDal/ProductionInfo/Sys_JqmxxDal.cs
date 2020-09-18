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
   public class Sys_JqmxxDal : ISys_JqmxxDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Jqmxx");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Jqmxx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Jqmxx(");
			strSql.Append("xxname,xxcode,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@xxname,@xxcode,@mcode,@maker)");
			SqlParameter[] parameters = {
					new SqlParameter("@xxname", SqlDbType.NVarChar,30),
					new SqlParameter("@xxcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.xxname;
			parameters[1].Value = model.xxcode;
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
		public bool Update( Sys_Jqmxx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Jqmxx set ");
			strSql.Append("xxname=@xxname,");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker");
            strSql.Append(" where xxcode=@xxcode");
			SqlParameter[] parameters = {
					new SqlParameter("@xxname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@xxcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.xxname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.xxcode;

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
		public bool Delete(string xxcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Jqmxx ");
            strSql.AppendFormat(" where xxcode='{0}'; ", xxcode);
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
        public Sys_Jqmxx Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,xxname,xxcode,mcode,maker,cdate from Sys_Jqmxx ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Jqmxx r = new Sys_Jqmxx();
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
		public  Sys_Jqmxx DataRowToModel(DataRow row)
		{
			 Sys_Jqmxx model=new  Sys_Jqmxx();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["xxname"]!=null)
				{
					model.xxname=row["xxname"].ToString();
				}
				if(row["xxcode"]!=null)
				{
					model.xxcode=row["xxcode"].ToString();
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
					model.cdate= row["cdate"].ToString() ;
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Jqmxx> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,xxname,xxcode,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_Jqmxx where 1=1 {0}", strWhere);
            List<Sys_Jqmxx> r = new List<Sys_Jqmxx>();
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
            sql = "select isnull(max(convert(int,xxcode)),0) as n from Sys_Jqmxx ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
