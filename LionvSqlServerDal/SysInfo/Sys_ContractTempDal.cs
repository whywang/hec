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
   public class Sys_ContractTempDal:ISys_ContractTempDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ContractTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ContractTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ContractTemp(");
			strSql.Append("cname,ccode,temp,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@cname,@ccode,@temp,@maker,@cdate)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@temp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.ccode;
			parameters[2].Value = model.temp;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;

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
		public bool Update( Sys_ContractTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ContractTemp set ");
			strSql.Append("cname=@cname,");
			strSql.Append("temp=@temp,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where ccode=@ccode");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@temp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.temp;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
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
		public bool Delete(string ccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Sys_ContractTemp ");
            strSql.AppendFormat(" where ccode='{0}' ;", ccode);
            strSql.Append("delete from Sys_RDepmentArea ");
            strSql.AppendFormat(" where ccode='{0}' ;", ccode);
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
		public  Sys_ContractTemp Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cname,ccode,temp,maker,cdate from Sys_ContractTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ContractTemp r = new Sys_ContractTemp();
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
		public  Sys_ContractTemp DataRowToModel(DataRow row)
		{
			 Sys_ContractTemp model=new  Sys_ContractTemp();
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
				if(row["temp"]!=null)
				{
					model.temp=row["temp"].ToString();
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
        public List<Sys_ContractTemp> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,cname,ccode,temp,maker,cdate ");
			strSql.Append(" FROM Sys_ContractTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ContractTemp> r = new List<Sys_ContractTemp>();
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
            string sql = "select isnull(max(convert(int,ccode)),0) as n from Sys_ContractTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
