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
   public class Sys_DataTableDal:ISys_DataTableDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_DataTable");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_DataTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_DataTable(");
			strSql.Append("sname,stable)");
			strSql.Append(" values (");
			strSql.Append("@sname,@stable)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@stable", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.stable;

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
		public bool Update( Sys_DataTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_DataTable set ");
			strSql.Append("sname=@sname,");
			strSql.Append("stable=@stable");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@stable", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.stable;
			parameters[2].Value = model.id;

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
			strSql.Append("delete from Sys_DataTable ");
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
		public  Sys_DataTable Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sname,stable from Sys_DataTable ");
            strSql.AppendFormat(" where 1=1 {0}", where);
			 Sys_DataTable r=new  Sys_DataTable();
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
		public  Sys_DataTable DataRowToModel(DataRow row)
		{
			 Sys_DataTable model=new  Sys_DataTable();
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
				if(row["stable"]!=null)
				{
					model.stable=row["stable"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_DataTable> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sname,stable ");
            strSql.AppendFormat(" FROM Sys_DataTable where 1=1 {0}", strWhere);
            List<Sys_DataTable> r = new List<Sys_DataTable>();
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
        public DataTable QueryTables()
        {
            DataTable r = new DataTable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT NAME FROM SYSOBJECTS WHERE TYPE='U' order by name");
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
