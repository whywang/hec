using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_SendTypeDal:ISys_SendTypeDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SendType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
      
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SendType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SendType(");
			strSql.Append("sname,scode,estate,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sname,@scode,@estate,@maker,@cdate)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@estate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.estate;
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
		public bool Update( Sys_SendType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SendType set ");
			strSql.Append("sname=@sname,");
			strSql.Append("estate=@estate,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where scode=@scode");
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@estate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@scode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.estate;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.scode;

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
			strSql.Append("delete from Sys_SendType ");
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
		public  Sys_SendType Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sname,scode,estate,maker,cdate from Sys_SendType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SendType r = new Sys_SendType();
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
		public  Sys_SendType DataRowToModel(DataRow row)
		{
			 Sys_SendType model=new  Sys_SendType();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sname"]!=null)
				{
					model.sname=row["sname"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["estate"]!=null && row["estate"].ToString()!="")
				{
					if((row["estate"].ToString()=="1")||(row["estate"].ToString().ToLower()=="true"))
					{
						model.estate=true;
					}
					else
					{
						model.estate=false;
					}
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
        public List<Sys_SendType> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sname,scode,estate,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SendType where 1=1 {0}", strWhere);
            List<Sys_SendType> r = new List<Sys_SendType>();
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
            string sql = "select isnull(max(convert(int,scode)),0) as n from Sys_SendType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
