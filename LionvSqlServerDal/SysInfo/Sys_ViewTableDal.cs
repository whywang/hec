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
    public class Sys_ViewTableDal : ISys_ViewTableDal
    {
        
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ViewTable");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ViewTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ViewTable(");
            strSql.Append("emname,emcode,tname,tcode,rcode,tabname,tabcode,cols,sqlcols,sqlcondition,maker,cdate,ecols,esqlcols)");
			strSql.Append(" values (");
            strSql.Append("@emname,@emcode,@tname,@tcode,@rcode,@tabname,@tabcode,@cols,@sqlcols,@sqlcondition,@maker,@cdate,@ecols,@esqlcols)");
 
			SqlParameter[] parameters = {
                    new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,20),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tabname", SqlDbType.NVarChar,20),
					new SqlParameter("@tabcode", SqlDbType.NVarChar,10),
					new SqlParameter("@cols", SqlDbType.NVarChar,2000),
					new SqlParameter("@sqlcols", SqlDbType.NVarChar,2000),
					new SqlParameter("@sqlcondition", SqlDbType.NVarChar,2000),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ecols", SqlDbType.NVarChar,500),
					new SqlParameter("@esqlcols", SqlDbType.NVarChar,2000)
                                        };
			parameters[0].Value = model.emname;
			parameters[1].Value = model.emcode;
            parameters[2].Value = model.tname;
            parameters[3].Value = model.tcode;
			parameters[4].Value = model.rcode;
			parameters[5].Value = model.tabname;
			parameters[6].Value = model.tabcode;
			parameters[7].Value = model.cols;
			parameters[8].Value = model.sqlcols;
			parameters[9].Value = model.sqlcondition;
			parameters[10].Value = model.maker;
			parameters[11].Value = model.cdate;
            parameters[12].Value = model.ecols;
            parameters[13].Value = model.esqlcols;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);

            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ViewTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ViewTable set ");
			strSql.Append("emname=@emname,");
			strSql.Append("emcode=@emcode,");
            strSql.Append("tname=@tname,");
            strSql.Append("rcode=@rcode,");
			strSql.Append("tabname=@tabname,");
			strSql.Append("tabcode=@tabcode,");
			strSql.Append("cols=@cols,");
			strSql.Append("sqlcols=@sqlcols,");
			strSql.Append("sqlcondition=@sqlcondition,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("ecols=@ecols,");
            strSql.Append("esqlcols=@esqlcols");
            strSql.Append(" where tcode=@tcode");
			SqlParameter[] parameters = {
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
                    new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tabname", SqlDbType.NVarChar,20),
					new SqlParameter("@tabcode", SqlDbType.NVarChar,10),
					new SqlParameter("@cols", SqlDbType.NVarChar,2000),
					new SqlParameter("@sqlcols", SqlDbType.NVarChar,2000),
					new SqlParameter("@sqlcondition", SqlDbType.NVarChar,2000),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcode", SqlDbType.NVarChar,20),
					new SqlParameter("@ecols", SqlDbType.NVarChar,2000),
					new SqlParameter("@esqlcols", SqlDbType.NVarChar,2000)};
			parameters[0].Value = model.emname;
			parameters[1].Value = model.emcode;
            parameters[2].Value = model.tname;
            parameters[3].Value = model.rcode;
			parameters[4].Value = model.tabname;
			parameters[5].Value = model.tabcode;
			parameters[6].Value = model.cols;
			parameters[7].Value = model.sqlcols;
			parameters[8].Value = model.sqlcondition;
			parameters[9].Value = model.maker;
			parameters[10].Value = model.cdate;
			parameters[11].Value = model.tcode;
            parameters[12].Value = model.ecols;
            parameters[13].Value = model.esqlcols;
            bool r = false;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
	 
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_ViewTable ");
			strSql.AppendFormat(" where 1=1 {0} ",where);
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
		public  Sys_ViewTable Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,emname,emcode,tname,tcode,rcode,tabname,tabcode,cols,sqlcols,ecols,esqlcols,sqlcondition,maker,cdate from Sys_ViewTable ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ViewTable r = new Sys_ViewTable();
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
		public  Sys_ViewTable DataRowToModel(DataRow row)
		{
			Sys_ViewTable model=new  Sys_ViewTable();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
				if(row["tname"]!=null)
				{
					model.tname=row["tname"].ToString();
				}
				if(row["tcode"]!=null)
				{
					model.tcode=row["tcode"].ToString();
				}
				if(row["rcode"]!=null)
				{
					model.rcode=row["rcode"].ToString();
				}
				if(row["tabname"]!=null)
				{
					model.tabname=row["tabname"].ToString();
				}
				if(row["tabcode"]!=null)
				{
					model.tabcode=row["tabcode"].ToString();
				}
				if(row["cols"]!=null)
				{
					model.cols=row["cols"].ToString();
				}
				if(row["sqlcols"]!=null)
				{
					model.sqlcols=row["sqlcols"].ToString();
				}
				if(row["sqlcondition"]!=null)
				{
					model.sqlcondition=row["sqlcondition"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
                } 
                if (row["ecols"] != null)
                {
                    model.ecols = row["ecols"].ToString();
                }
                if (row["esqlcols"] != null)
                {
                    model.esqlcols = row["esqlcols"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ViewTable> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,emname,emcode,tname,tcode,rcode,tabname,tabcode,cols,sqlcols,ecols,esqlcols,sqlcondition,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ViewTable where 1=1 {0}", where);
            List<Sys_ViewTable> r = new List<Sys_ViewTable>();
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
            string sql = "select isnull(max(convert(int,tcode)),0) as n from Sys_ViewTable ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
