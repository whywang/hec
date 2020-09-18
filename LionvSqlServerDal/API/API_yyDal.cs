using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Api;
using LionvModel.Api;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.API
{
   public class API_yyDal:IAPI_yyDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from API_yy");
            strSql.AppendFormat(" where 1=1 {0}", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( API_yy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into API_yy(");
			strSql.Append("dname,dcode,yycode)");
			strSql.Append(" values (");
			strSql.Append("@dname,@dcode,@yycode)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@yycode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.yycode;

			object obj =  SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(),parameters);
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
		public bool Update( API_yy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update API_yy set ");
			strSql.Append("dname=@dname,");
			strSql.Append("yycode=@yycode");
            strSql.Append(" where dcode=@dcode");
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@yycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.yycode;
			parameters[2].Value = model.dcode;

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
		public bool Delete(string dcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from API_yy ");
			strSql.Append(" where dcode=@dcode ");
			SqlParameter[] parameters = {
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)			};
			parameters[0].Value = dcode;

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
        public API_yy Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,dname,dcode,yycode from API_yy ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            API_yy r = new API_yy();
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
		public  API_yy DataRowToModel(DataRow row)
		{
			 API_yy model=new  API_yy();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["yycode"]!=null)
				{
					model.yycode=row["yycode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<API_yy> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,dname,dcode,yycode ");
            strSql.AppendFormat(" FROM API_yy where 1=1 {0} ", strWhere);
            List<API_yy> r = new List<API_yy>();
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
