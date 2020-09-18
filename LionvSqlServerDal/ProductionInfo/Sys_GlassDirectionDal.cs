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
    public class Sys_GlassDirectionDal : ISys_GlassDirectionDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_GlassDirection");
			  strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_GlassDirection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_GlassDirection(");
			strSql.Append("gdname,gdcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@gdname,@gdcode,@maker,@cdate)");

			SqlParameter[] parameters = {
					new SqlParameter("@gdname", SqlDbType.NVarChar,30),
					new SqlParameter("@gdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.gdname;
			parameters[1].Value = model.gdcode;
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
		public bool Update( Sys_GlassDirection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_GlassDirection set ");
			strSql.Append("gdname=@gdname,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where gdcode=@gdcode");
			SqlParameter[] parameters = {
					new SqlParameter("@gdname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gdcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.gdname;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.gdcode;

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
		public bool Delete(string gdcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_GlassDirection ");
            strSql.AppendFormat(" where gdcode='{0}'; ", gdcode);
            strSql.Append("delete from Sys_RInventoryGlassDirection ");
            strSql.AppendFormat(" where gdcode='{0}'; ", gdcode);
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
        public Sys_GlassDirection Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,gdname,gdcode,maker,cdate from Sys_GlassDirection ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_GlassDirection r = new Sys_GlassDirection();
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
		public  Sys_GlassDirection DataRowToModel(DataRow row)
		{
			 Sys_GlassDirection model=new  Sys_GlassDirection();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["gdname"]!=null)
				{
					model.gdname=row["gdname"].ToString();
				}
				if(row["gdcode"]!=null)
				{
					model.gdcode=row["gdcode"].ToString();
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
        public List<Sys_GlassDirection> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,gdname,gdcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_GlassDirection  where 1=1 {0}", strWhere);
            List<Sys_GlassDirection> r = new List<Sys_GlassDirection>();
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
            sql = "select isnull(max(convert(int,gdcode)),0) as n from Sys_GlassDirection ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetGlassDire(string pcode, string gdcode)
        {
            string[] parr = gdcode.Split(';');
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryGlassDirection where pcode ='{0}';", pcode);
            foreach (string p in parr)
            {
                sql.AppendFormat(" insert into Sys_RInventoryGlassDirection (pcode,gdcode) values ('{0}','{1}') ;", pcode, p);
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
        public bool ReSetGlassDire(string pcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryGlassDirection where pcode ='{0}';", pcode);
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
        public string GetGlassDire(string pcode)
        {
            string r = "";
            string sql = "select gdcode from Sys_RInventoryGlassDirection where pcode='" + pcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = dr["gdcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            
            return r;
        }
		#endregion  ExtensionMethod
    }
}
