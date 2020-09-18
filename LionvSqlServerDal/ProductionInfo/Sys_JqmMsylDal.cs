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
    public class Sys_JqmMsylDal : ISys_JqmMsylDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmMsyl");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);

		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmMsyl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmMsyl(");
			strSql.Append("ylname,ylcode,hyl,wyl,maker)");
			strSql.Append(" values (");
			strSql.Append("@ylname,@ylcode,@hyl,@wyl,@maker)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@ylname", SqlDbType.NVarChar,30),
					new SqlParameter("@ylcode", SqlDbType.NVarChar,30),
					new SqlParameter("@hyl", SqlDbType.Int,4),
					new SqlParameter("@wyl", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.ylname;
			parameters[1].Value = model.ylcode;
			parameters[2].Value = model.hyl;
			parameters[3].Value = model.wyl;
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
		public bool Update( Sys_JqmMsyl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmMsyl set ");
			strSql.Append("ylname=@ylname,");
			strSql.Append("hyl=@hyl,");
			strSql.Append("wyl=@wyl,");
			strSql.Append("maker=@maker ");
            strSql.Append(" where ylcode=@ylcode");
			SqlParameter[] parameters = {
					new SqlParameter("@ylname", SqlDbType.NVarChar,30),
					new SqlParameter("@hyl", SqlDbType.Int,4),
					new SqlParameter("@wyl", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@ylcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.ylname;
			parameters[1].Value = model.hyl;
			parameters[2].Value = model.wyl;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.ylcode;

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
		public bool Delete(string ylcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmMsyl ");
            strSql.AppendFormat(" where ylcode='{0}'; ", ylcode);
            strSql.AppendFormat(" delete from Sys_RproductionJqmMsyl where ylcode='{0}' ", ylcode);
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
        public Sys_JqmMsyl Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ylname,ylcode,hyl,wyl,maker,cdate from Sys_JqmMsyl ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmMsyl r = new Sys_JqmMsyl();
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
		public  Sys_JqmMsyl DataRowToModel(DataRow row)
		{
			 Sys_JqmMsyl model=new  Sys_JqmMsyl();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ylname"]!=null)
				{
					model.ylname=row["ylname"].ToString();
				}
				if(row["ylcode"]!=null)
				{
					model.ylcode=row["ylcode"].ToString();
				}
				if(row["hyl"]!=null && row["hyl"].ToString()!="")
				{
					model.hyl=int.Parse(row["hyl"].ToString());
				}
				if(row["wyl"]!=null && row["wyl"].ToString()!="")
				{
					model.wyl=int.Parse(row["wyl"].ToString());
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
        public List<Sys_JqmMsyl> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ylname,ylcode,hyl,wyl,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmMsyl where 1=1 {0}", strWhere);
            List<Sys_JqmMsyl> r = new List<Sys_JqmMsyl>();
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
            sql = "select isnull(max(convert(int,ylcode)),0) as n from Sys_JqmMsyl ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
