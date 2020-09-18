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
   public class Sys_JqmElmDal:ISys_JqmElmDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmElm");
			 strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmElm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmElm(");
			strSql.Append("elmname,elmcode,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@elmname,@elmcode,@mcode,@maker)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@elmname", SqlDbType.NVarChar,50),
					new SqlParameter("@elmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.elmname;
			parameters[1].Value = model.elmcode;
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
		public bool Update( Sys_JqmElm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmElm set ");
			strSql.Append("elmname=@elmname,");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker ");
            strSql.Append(" where elmcode=@elmcode");
			SqlParameter[] parameters = {
					new SqlParameter("@elmname", SqlDbType.NVarChar,50),
					new SqlParameter("@mcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@elmcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.elmname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.elmcode;

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
		public bool Delete(string elmcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmElm ");
            strSql.AppendFormat(" where elmcode='{0}'; ", elmcode);
            strSql.AppendFormat(" delete from Sys_RproductionJqmElm where elmcode='{0}' ", elmcode);
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
        public Sys_JqmElm Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,elmname,elmcode,mcode,maker,cdate from Sys_JqmElm ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmElm r = new Sys_JqmElm();
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
		public  Sys_JqmElm DataRowToModel(DataRow row)
		{
			 Sys_JqmElm model=new  Sys_JqmElm();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["elmname"]!=null)
				{
					model.elmname=row["elmname"].ToString();
				}
				if(row["elmcode"]!=null)
				{
					model.elmcode=row["elmcode"].ToString();
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
        public List<Sys_JqmElm> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,elmname,elmcode,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmElm where 1=1 {0}", strWhere);
            List<Sys_JqmElm> r = new List<Sys_JqmElm>();
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
            sql = "select isnull(max(convert(int,elmcode)),0) as n from Sys_JqmElm ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
