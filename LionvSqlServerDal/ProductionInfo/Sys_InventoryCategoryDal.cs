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
   public class Sys_InventoryCategoryDal:ISys_InventoryCategoryDal
	{
	  
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_InventoryCategory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_InventoryCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_InventoryCategory(");
            strSql.Append("icname,iccode,icpname,icpcode,icsend,icstate,icms,maker,cdate,isort,drange)");
			strSql.Append(" values (");
            strSql.Append("@icname,@iccode,@icpname,@icpcode,@icsend,@icstate,@icms,@maker,@cdate,@isort,@drange);");
			SqlParameter[] parameters = {
					new SqlParameter("@icname", SqlDbType.NVarChar,50),
					new SqlParameter("@iccode", SqlDbType.NVarChar,50),
					new SqlParameter("@icpname", SqlDbType.NVarChar,50),
					new SqlParameter("@icpcode", SqlDbType.NVarChar,50),
					new SqlParameter("@icsend", SqlDbType.Bit,1),
					new SqlParameter("@icstate", SqlDbType.Bit,1),
					new SqlParameter("@icms", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@isort", SqlDbType.Int,4),
                    new SqlParameter("@drange", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.icname;
			parameters[1].Value = model.iccode;
			parameters[2].Value = model.icpname;
			parameters[3].Value = model.icpcode;
			parameters[4].Value = model.icsend;
			parameters[5].Value = model.icstate;
			parameters[6].Value = model.icms;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;
            parameters[9].Value = model.isort;
            parameters[10].Value = model.drange;
            strSql.AppendFormat("update Sys_InventoryCategory set icstate='false' where iccode='{0}'", model.icpcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_InventoryCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_InventoryCategory set ");
			strSql.Append("icname=@icname,");
			strSql.Append("icpname=@icpname,");
			strSql.Append("icpcode=@icpcode,");
			strSql.Append("icsend=@icsend,");
			strSql.Append("icms=@icms,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("drange=@drange");
            strSql.Append(" where iccode=@iccode ;");
			SqlParameter[] parameters = {
					new SqlParameter("@icname", SqlDbType.NVarChar,50),
					new SqlParameter("@icpname", SqlDbType.NVarChar,50),
					new SqlParameter("@icpcode", SqlDbType.NVarChar,50),
					new SqlParameter("@icsend", SqlDbType.Bit,1),
					new SqlParameter("@icms", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@drange", SqlDbType.NVarChar,100),
					new SqlParameter("@iccode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.icname;
			parameters[1].Value = model.icpname;
			parameters[2].Value = model.icpcode;
			parameters[3].Value = model.icsend;
			parameters[4].Value = model.icms;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
            parameters[7].Value = model.drange;
			parameters[8].Value = model.iccode;
            strSql.AppendFormat("update Sys_InventoryCategory set icpname='{0}' where icpcode='{1}';", model.icname, model.iccode);
            strSql.AppendFormat("update Sys_InventoryDetail set icname='{0}' where iccode='{1}';", model.icname, model.iccode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
             
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string iccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            StringBuilder ustrSql = new StringBuilder();
            Sys_InventoryCategory smc = Query(" and iccode='" + iccode + "'");
            strSql.AppendFormat("delete from Sys_InventoryCategory where 1=1 and iccode='{0}';", iccode);
            strSql.AppendFormat("delete from Sys_InventoryCategory where 1=1 and icpcode like '{0}%';", iccode);
            strSql.AppendFormat("delete from Sys_InventoryDetail  where 1=1 and iccode like '{0}%';", iccode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                if (!Exists(" and icpcode='" + smc.icpcode + "'"))
                {
                    ustrSql.AppendFormat("update Sys_InventoryCategory set icstate='true' where iccode='{0}';", smc.icpcode);
                
                     SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, ustrSql.ToString(), null);
                }
                r = true;
            }
            return r;
		}
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_InventoryCategory Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,icname,iccode,icpname,icpcode,icsend,icstate,icms,maker,cdate,drange from Sys_InventoryCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_InventoryCategory r = new Sys_InventoryCategory();
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
		public  Sys_InventoryCategory DataRowToModel(DataRow row)
		{
			 Sys_InventoryCategory model=new  Sys_InventoryCategory();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["icname"]!=null)
				{
					model.icname=row["icname"].ToString();
				}
				if(row["iccode"]!=null)
				{
					model.iccode=row["iccode"].ToString();
				}
				if(row["icpname"]!=null)
				{
					model.icpname=row["icpname"].ToString();
				}
				if(row["icpcode"]!=null)
				{
					model.icpcode=row["icpcode"].ToString();
				}
				if(row["icsend"]!=null && row["icsend"].ToString()!="")
				{
					if((row["icsend"].ToString()=="1")||(row["icsend"].ToString().ToLower()=="true"))
					{
						model.icsend=true;
					}
					else
					{
						model.icsend=false;
					}
				}
				if(row["icstate"]!=null && row["icstate"].ToString()!="")
				{
					if((row["icstate"].ToString()=="1")||(row["icstate"].ToString().ToLower()=="true"))
					{
						model.icstate=true;
					}
					else
					{
						model.icstate=false;
					}
				}
				if(row["icms"]!=null)
				{
					model.icms=row["icms"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
                if (row["drange"] != null)
                {
                    model.drange = row["drange"].ToString();
                }
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_InventoryCategory> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,icname,iccode,icpname,icpcode,icsend,icstate,icms,maker,cdate,drange ");
			strSql.Append(" FROM Sys_InventoryCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_InventoryCategory> r = new List<Sys_InventoryCategory>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            if (where != "")
            {
                sql = "select isnull(max(convert(int,substring(iccode,len(iccode)-1,3))),0) as n from Sys_InventoryCategory where icpcode='" + where + "'";
            }
            else
            {
                sql = "select isnull(max(convert(int, iccode)),0) as n from Sys_InventoryCategory where icpcode='" + where + "'";
            }
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
