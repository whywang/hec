using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.ProductionInfo;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_GlassCraftDal : ISys_GlassCraftDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_GlassCraft");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_GlassCraft model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_GlassCraft(");
			strSql.Append("gcname,gccode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@gcname,@gccode,@maker,@cdate)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@gcname", SqlDbType.NVarChar,30),
					new SqlParameter("@gccode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.gcname;
			parameters[1].Value = model.gccode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;

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
		public bool Update( Sys_GlassCraft model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_GlassCraft set ");
			strSql.Append("gcname=@gcname,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where gccode=@gccode");
			SqlParameter[] parameters = {
					new SqlParameter("@gcname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.gcname;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.gccode;

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
		public bool Delete(string gccode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_GlassCraft ");
            strSql.AppendFormat(" where gccode='{0}'; ", gccode);
            strSql.Append("delete from Sys_RInventoryGlassCraft ");
            strSql.AppendFormat(" where gccode='{0}'; ", gccode);
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
		public  Sys_GlassCraft Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,gcname,gccode,maker,cdate from Sys_GlassCraft ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_GlassCraft r = new Sys_GlassCraft();
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
		public  Sys_GlassCraft DataRowToModel(DataRow row)
		{
			 Sys_GlassCraft model=new  Sys_GlassCraft();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["gcname"]!=null)
				{
					model.gcname=row["gcname"].ToString();
				}
				if(row["gccode"]!=null)
				{
					model.gccode=row["gccode"].ToString();
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
        public List<Sys_GlassCraft> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,gcname,gccode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_GlassCraft where 1=1 {0}", strWhere);
            List<Sys_GlassCraft> r = new List<Sys_GlassCraft>();
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
            sql = "select isnull(max(convert(int,gccode)),0) as n from Sys_GlassCraft ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetGlassCraft(string pcode, string gccode)
        {
            string[] parr = gccode.Split(';');
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryGlassCraft where pcode ='{0}';", pcode);
            foreach (string p in parr)
            {
                sql.AppendFormat(" insert into Sys_RInventoryGlassCraft (pcode,gccode) values ('{0}','{1}') ;", pcode,p);
            }
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetGlassCraft(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryGlassCraft where pcode ='{0}';", pcode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
        public string GetGlassCraft(string pcode)
        {
            string r = "";
            string sql = "select gccode from Sys_RInventoryGlassCraft where pcode='" + pcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = dr["gccode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
           
            return r;
        }
		#endregion  ExtensionMethod
    }
}
