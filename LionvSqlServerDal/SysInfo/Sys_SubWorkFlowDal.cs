using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SubWorkFlowDal : ISys_SubWorkFlowDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SubWorkFlow");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
      
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SubWorkFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SubWorkFlow(");
			strSql.Append("socode,soname,emcode,semcode,dtable)");
			strSql.Append(" values (");
			strSql.Append("@socode,@soname,@emcode,@semcode,@dtable)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@socode", SqlDbType.NVarChar,30),
					new SqlParameter("@soname", SqlDbType.NVarChar,50),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@semcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dtable", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.socode;
			parameters[1].Value = model.soname;
			parameters[2].Value = model.emcode;
			parameters[3].Value = model.semcode;
			parameters[4].Value = model.dtable;

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
		public bool Update( Sys_SubWorkFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SubWorkFlow set ");
			strSql.Append("soname=@soname,");
			strSql.Append("emcode=@emcode,");
			strSql.Append("semcode=@semcode,");
			strSql.Append("dtable=@dtable");
            strSql.Append(" where socode=@socode");
			SqlParameter[] parameters = {
					new SqlParameter("@soname", SqlDbType.NVarChar,50),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@semcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dtable", SqlDbType.NVarChar,30),
					new SqlParameter("@socode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.soname;
			parameters[1].Value = model.emcode;
			parameters[2].Value = model.semcode;
			parameters[3].Value = model.dtable;
			parameters[4].Value = model.socode;

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
		public bool Delete(string socode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_SubWorkFlow ");
            strSql.AppendFormat(" where socode='{0}' ;", socode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
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
		public  Sys_SubWorkFlow Query(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,socode,soname,emcode,semcode,dtable,mtable  from Sys_SubWorkFlow ");
            strSql.AppendFormat(" where 1=1 {0}", id);
            Sys_SubWorkFlow r = new Sys_SubWorkFlow();
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
		public  Sys_SubWorkFlow DataRowToModel(DataRow row)
		{
			 Sys_SubWorkFlow model=new  Sys_SubWorkFlow();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["socode"]!=null)
				{
					model.socode=row["socode"].ToString();
				}
				if(row["soname"]!=null)
				{
					model.soname=row["soname"].ToString();
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["semcode"]!=null)
				{
					model.semcode=row["semcode"].ToString();
				}
				if(row["dtable"]!=null)
				{
					model.dtable=row["dtable"].ToString();
				}
                if (row["mtable"] != null)
                {
                    model.mtable = row["mtable"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SubWorkFlow> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,socode,soname,emcode,semcode,dtable,mtable  ");
			strSql.Append(" FROM Sys_SubWorkFlow ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_SubWorkFlow> r = new List<Sys_SubWorkFlow>();
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
            string sql = "select isnull(max(convert(int,socode)),0) as n from Sys_SubWorkFlow ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
