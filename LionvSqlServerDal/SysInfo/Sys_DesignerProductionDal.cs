using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_DesignerProductionDal:ISys_DesignerProductionDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_DesignerProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_DesignerProduction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_DesignerProduction(");
			strSql.Append("eno,pname,purl,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@eno,@pname,@purl,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@eno", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@purl", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.eno;
			parameters[1].Value = model.pname;
			parameters[2].Value = model.purl;
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_DesignerProduction ");
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
		public  Sys_DesignerProduction Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,eno,pname,purl,maker,cdate from Sys_DesignerProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_DesignerProduction r = new Sys_DesignerProduction();
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
		public  Sys_DesignerProduction DataRowToModel(DataRow row)
		{
			 Sys_DesignerProduction model=new  Sys_DesignerProduction();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["eno"]!=null)
				{
					model.eno=row["eno"].ToString();
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
				}
				if(row["purl"]!=null)
				{
					model.purl=row["purl"].ToString();
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
        public List<Sys_DesignerProduction> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,eno,pname,purl,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_DesignerProduction where 1=1 {0}", where);
            List<Sys_DesignerProduction> r = new List<Sys_DesignerProduction>();
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
