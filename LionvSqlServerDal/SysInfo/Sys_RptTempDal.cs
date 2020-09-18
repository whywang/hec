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
    public class Sys_RptTempDal : ISys_RptTempDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_RptTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_RptTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_RptTemp(");
			strSql.Append("rtname,rtcode,emcode,emname,dbtname,thtext,dbcol,dbwhere,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@rtname,@rtcode,@emcode,@emname,@dbtname,@thtext,@dbcol,@dbwhere,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@rtname", SqlDbType.NVarChar,30),
					new SqlParameter("@rtcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@dbtname", SqlDbType.NVarChar,30),
					new SqlParameter("@thtext", SqlDbType.NVarChar,2000),
					new SqlParameter("@dbcol", SqlDbType.NVarChar,2000),
					new SqlParameter("@dbwhere", SqlDbType.NVarChar,2000),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.rtname;
			parameters[1].Value = model.rtcode;
			parameters[2].Value = model.emcode;
			parameters[3].Value = model.emname;
			parameters[4].Value = model.dbtname;
			parameters[5].Value = model.thtext;
			parameters[6].Value = model.dbcol;
			parameters[7].Value = model.dbwhere;
			parameters[8].Value = model.maker;
			parameters[9].Value = model.cdate;

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
		public bool Update(Sys_RptTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_RptTemp set ");
			strSql.Append("rtname=@rtname,");
			strSql.Append("emcode=@emcode,");
			strSql.Append("emname=@emname,");
			strSql.Append("dbtname=@dbtname,");
			strSql.Append("thtext=@thtext,");
			strSql.Append("dbcol=@dbcol,");
			strSql.Append("dbwhere=@dbwhere,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where rtcode=@rtcode");
			SqlParameter[] parameters = {
					new SqlParameter("@rtname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@dbtname", SqlDbType.NVarChar,30),
					new SqlParameter("@thtext", SqlDbType.NVarChar,2000),
					new SqlParameter("@dbcol", SqlDbType.NVarChar,2000),
					new SqlParameter("@dbwhere", SqlDbType.NVarChar,2000),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rtcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.rtname;
			parameters[1].Value = model.emcode;
			parameters[2].Value = model.emname;
			parameters[3].Value = model.dbtname;
			parameters[4].Value = model.thtext;
			parameters[5].Value = model.dbcol;
			parameters[6].Value = model.dbwhere;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;
			parameters[9].Value = model.rtcode;

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
			strSql.Append("delete from Sys_RptTemp ");
            strSql.AppendFormat(" where  1=1 {0};", where);
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
		public Sys_RptTemp Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,rtname,rtcode,emcode,emname,dbtname,thtext,dbcol,dbwhere,maker,cdate from Sys_RptTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RptTemp r = new Sys_RptTemp();
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
		public Sys_RptTemp DataRowToModel(DataRow row)
		{
			Sys_RptTemp model=new Sys_RptTemp();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["rtname"]!=null)
				{
					model.rtname=row["rtname"].ToString();
				}
				if(row["rtcode"]!=null)
				{
					model.rtcode=row["rtcode"].ToString();
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["emname"]!=null)
				{
					model.emname=row["emname"].ToString();
				}
				if(row["dbtname"]!=null)
				{
					model.dbtname=row["dbtname"].ToString();
				}
				if(row["thtext"]!=null)
				{
					model.thtext=row["thtext"].ToString();
				}
				if(row["dbcol"]!=null)
				{
					model.dbcol=row["dbcol"].ToString();
				}
				if(row["dbwhere"]!=null)
				{
					model.dbwhere=row["dbwhere"].ToString();
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
        public List<Sys_RptTemp> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,rtname,rtcode,emcode,emname,dbtname,thtext,dbcol,dbwhere,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_RptTemp where 1=1 {0}", strWhere);
            List<Sys_RptTemp> r = new List<Sys_RptTemp>();
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
            string sql = "select isnull(max(convert(int,rtcode)),0) as n from Sys_RptTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
