using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
   public class Sys_JqmSlmDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmSlm");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmSlm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmSlm(");
			strSql.Append("slmname,slmcode,mcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@slmname,@slmcode,@mcode,@maker,@cdate)");

			SqlParameter[] parameters = {
					new SqlParameter("@slmname", SqlDbType.NVarChar,30),
					new SqlParameter("@slmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.slmname;
			parameters[1].Value = model.slmcode;
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
		public bool Update( Sys_JqmSlm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmSlm set ");
			strSql.Append("slmname=@slmname,");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker");
            strSql.Append(" where slmcode=@slmcode");
			SqlParameter[] parameters = {
					new SqlParameter("@slmname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@slmcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.slmname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.slmcode;

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
		public bool Delete(string slmcode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmSlm ");
            strSql.AppendFormat(" where slmcode='{0}'; ", slmcode);
            strSql.AppendFormat(" delete from Sys_RproductionJqmMsyl where ylcode='{0}' ", slmcode);
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
        public Sys_JqmSlm Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,slmname,slmcode,mcode,maker,cdate from Sys_JqmSlm ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmSlm r = new Sys_JqmSlm();
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
		public  Sys_JqmSlm DataRowToModel(DataRow row)
		{
			 Sys_JqmSlm model=new  Sys_JqmSlm();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["slmname"]!=null)
				{
					model.slmname=row["slmname"].ToString();
				}
				if(row["slmcode"]!=null)
				{
					model.slmcode=row["slmcode"].ToString();
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
		public List<Sys_JqmSlm>  QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,slmname,slmcode,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmSlm where 1=1 {0}", strWhere);
            List<Sys_JqmSlm> r = new List<Sys_JqmSlm>();
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
            sql = "select isnull(max(convert(int,slmcode)),0) as n from Sys_JqmSlm ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
