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
    public class Sys_MeasureProductionDal : ISys_MeasureProductionDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_MeasureProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_MeasureProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_MeasureProduction(");
			strSql.Append("mpname,mpcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@mpname,@mpcode,@maker,@cdate)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@mpname", SqlDbType.NVarChar,30),
					new SqlParameter("@mpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.mpname;
			parameters[1].Value = model.mpcode;
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
		public bool Update( Sys_MeasureProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MeasureProduction set ");
			strSql.Append("mpname=@mpname,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where mpcode=@mpcode");
			SqlParameter[] parameters = {
					new SqlParameter("@mpname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@mpcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.mpname;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.mpcode;

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
		public bool Delete(string mpcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_MeasureProduction ");
            strSql.AppendFormat(" where mpcode='{0}' ", mpcode);
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
        public Sys_MeasureProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,mpname,mpcode,maker,cdate from Sys_MeasureProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_MeasureProduction r = new Sys_MeasureProduction();
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
		public  Sys_MeasureProduction DataRowToModel(DataRow row)
		{
			 Sys_MeasureProduction model=new  Sys_MeasureProduction();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mpname"]!=null)
				{
					model.mpname=row["mpname"].ToString();
				}
				if(row["mpcode"]!=null)
				{
					model.mpcode=row["mpcode"].ToString();
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
        public List<Sys_MeasureProduction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,mpname,mpcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_MeasureProduction where 1=1 {0}", strWhere);
            List<Sys_MeasureProduction> r = new List<Sys_MeasureProduction>();
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
            sql = "select isnull(max(convert(int,mpcode)),0) as n from Sys_MeasureProduction ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
