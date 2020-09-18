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
   public class Sys_JqmHzDal:ISys_JqmHzDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmHz");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmHz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmHz(");
			strSql.Append("hzname,hzcode,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@hzname,@hzcode,@mcode,@maker)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@hzname", SqlDbType.NVarChar,30),
					new SqlParameter("@hzcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.hzname;
			parameters[1].Value = model.hzcode;
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
		public bool Update( Sys_JqmHz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmHz set ");
			strSql.Append("hzname=@hzname,");
			strSql.Append("mcode=@mcode ");
            strSql.Append(" where hzcode=@hzcode");
			SqlParameter[] parameters = {
					new SqlParameter("@hzname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@hzcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.hzname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.hzcode;

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
		public bool Delete(string hzcode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmHz ");
            strSql.AppendFormat(" where hzcode='{0}'; ", hzcode);
            strSql.AppendFormat(" delete from Sys_RproductionJqmHz where fbcode='{0}' ", hzcode);
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
        public Sys_JqmHz Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,hzname,hzcode,mcode,maker,cdate from Sys_JqmHz ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmHz r = new Sys_JqmHz();
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
		public  Sys_JqmHz DataRowToModel(DataRow row)
		{
			 Sys_JqmHz model=new  Sys_JqmHz();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["hzname"]!=null)
				{
					model.hzname=row["hzname"].ToString();
				}
				if(row["hzcode"]!=null)
				{
					model.hzcode=row["hzcode"].ToString();
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
        public List<Sys_JqmHz> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,hzname,hzcode,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmHz where 1=1 {0}", strWhere);
            List<Sys_JqmHz> r = new List<Sys_JqmHz>();
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
            sql = "select isnull(max(convert(int,hzcode)),0) as n from Sys_JqmHz ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
