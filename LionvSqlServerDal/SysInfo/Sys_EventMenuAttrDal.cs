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
    public class Sys_EventMenuAttrDal:ISys_EventMenuAttrDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_EventMenuAttr");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_EventMenuAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_EventMenuAttr(");
			strSql.Append("emcode,emname,dsource)");
			strSql.Append(" values (");
			strSql.Append("@emcode,@emname,@dsource)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,50),
					new SqlParameter("@dsource", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.emcode;
			parameters[1].Value = model.emname;
			parameters[2].Value = model.dsource;

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
		public bool Update( Sys_EventMenuAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_EventMenuAttr set ");
			strSql.Append("emcode=@emcode,");
			strSql.Append("emname=@emname,");
			strSql.Append("dsource=@dsource");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@emname", SqlDbType.NVarChar,50),
					new SqlParameter("@dsource", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.emcode;
			parameters[1].Value = model.emname;
			parameters[2].Value = model.dsource;
			parameters[3].Value = model.id;

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
			strSql.Append("delete from Sys_EventMenuAttr ");
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
		public  Sys_EventMenuAttr Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,emcode,emname,dsource from Sys_EventMenuAttr ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_EventMenuAttr r = new Sys_EventMenuAttr();
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
		public  Sys_EventMenuAttr DataRowToModel(DataRow row)
		{
			 Sys_EventMenuAttr model=new  Sys_EventMenuAttr();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["emname"]!=null)
				{
					model.emname=row["emname"].ToString();
				}
				if(row["dsource"]!=null)
				{
					model.dsource=row["dsource"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_EventMenuAttr> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,emcode,emname,dsource ");
            strSql.AppendFormat(" FROM Sys_EventMenuAttr where 1=1 {0}", strWhere);
            List<Sys_EventMenuAttr> r = new List<Sys_EventMenuAttr>();
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

		#endregion  ExtensionMethod
    }
}
