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
    public class Sys_CaveDal : ISys_CaveDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Cave");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Cave model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Cave(");
			strSql.Append("cname,ccode,dcode,cdate,maker)");
			strSql.Append(" values (");
			strSql.Append("@cname,@ccode,@dcode,@cdate,@maker)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ccode;
			parameters[2].Value = model.dcode;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.maker;

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
		public bool Update( Sys_Cave model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Cave set ");
			strSql.Append("cname=@cname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("cdate=@cdate,");
			strSql.Append("maker=@maker");
            strSql.Append(" where ccode=@ccode");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.ccode;

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
			strSql.Append("delete from Sys_Cave ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
		public  Sys_Cave Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cname,ccode,dcode,cdate,maker from Sys_Cave ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Cave r = new Sys_Cave();
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
		public  Sys_Cave DataRowToModel(DataRow row)
		{
			 Sys_Cave model=new  Sys_Cave();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
				}
				if(row["ccode"]!=null)
				{
					model.ccode=row["ccode"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Cave> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,cname,ccode,dcode,cdate,maker ");
            strSql.AppendFormat(" FROM Sys_Cave where 1=1 {0}", strWhere);
            List<Sys_Cave> r = new List<Sys_Cave>();
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
            sql = "select isnull(max(convert(int,ccode)),0) as n from Sys_Cave ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
