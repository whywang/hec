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
    public class Sys_MaterialCategoryDal : ISys_MaterialCategoryDal
    {
        #region  BasicMethod
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_MaterialCategory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_MaterialCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_MaterialCategory(");
			strSql.Append("mcname,mccode,mcpname,mcpcode,mcstate,maker,cdate,dcode,mtype,btype)");
			strSql.Append(" values (");
            strSql.Append("@mcname,@mccode,@mcpname,@mcpcode,@mcstate,@maker,@cdate,@dcode,@mtype,@btype);");
			SqlParameter[] parameters = {
					new SqlParameter("@mcname", SqlDbType.NVarChar,20),
					new SqlParameter("@mccode", SqlDbType.NVarChar,20),
					new SqlParameter("@mcpname", SqlDbType.NVarChar,20),
					new SqlParameter("@mcpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mcstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@btype", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.mcname;
			parameters[1].Value = model.mccode;
			parameters[2].Value = model.mcpname;
			parameters[3].Value = model.mcpcode;
			parameters[4].Value = model.mcstate;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.mtype;
            parameters[9].Value = model.btype;
            strSql.AppendFormat("update Sys_MaterialCategory set mcstate='false' where mccode='{0}'", model.mcpcode);
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
		public bool Update( Sys_MaterialCategory model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MaterialCategory set ");
			strSql.Append("mcname=@mcname,");
			strSql.Append("mcpname=@mcpname,");
			strSql.Append("mcpcode=@mcpcode,");
			strSql.Append("mcstate=@mcstate,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("mtype=@mtype,");
            strSql.Append("btype=@btype");
            strSql.Append(" where mccode=@mccode ;");
			SqlParameter[] parameters = {
					new SqlParameter("@mcname", SqlDbType.NVarChar,20),
					new SqlParameter("@mcpname", SqlDbType.NVarChar,20),
					new SqlParameter("@mcpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mcstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@mtype", SqlDbType.NVarChar,30),
                    new SqlParameter("@btype", SqlDbType.NVarChar,30),
					new SqlParameter("@mccode", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.mcname;
			parameters[1].Value = model.mcpname;
			parameters[2].Value = model.mcpcode;
			parameters[3].Value = model.mcstate;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
            parameters[6].Value = model.mtype;
            parameters[7].Value = model.btype;
			parameters[8].Value = model.mccode;
            strSql.AppendFormat("update Sys_MaterialCategory set mcpname='{0}' where mcpcode='{1}';", model.mcname,model.mccode);
            strSql.AppendFormat("update Sys_Material set mcname='{0}' where mccode='{1}';", model.mcname, model.mccode);
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
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            StringBuilder ustrSql = new StringBuilder();
            Sys_MaterialCategory smc = Query(" and mccode='"+where+"'");
            strSql.AppendFormat("delete from Sys_MaterialCategory where 1=1 and mccode='{0}';", where);
            strSql.AppendFormat("delete from Sys_MaterialCategory where 1=1 and mcpcode like '{0}%';", where);
            strSql.AppendFormat("delete from Sys_Material  where 1=1 and mccode like '{0}%';", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                if(!Exists(" and mcpcode='"+smc.mcpcode+"'"))
                {
                    ustrSql.AppendFormat("update Sys_MaterialCategory set mcstate='true' where mccode='{0}';", smc.mcpcode);
                    SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, ustrSql.ToString(), null);
                }
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_MaterialCategory Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,mcname,mccode,mcpname,mcpcode,mcstate,maker,cdate,mtype,btype from Sys_MaterialCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_MaterialCategory r = new Sys_MaterialCategory();
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
		public Sys_MaterialCategory DataRowToModel(DataRow row)
		{
			 Sys_MaterialCategory model=new  Sys_MaterialCategory();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mcname"]!=null)
				{
					model.mcname=row["mcname"].ToString();
				}
				if(row["mccode"]!=null)
				{
					model.mccode=row["mccode"].ToString();
				}
				if(row["mcpname"]!=null)
				{
					model.mcpname=row["mcpname"].ToString();
				}
				if(row["mcpcode"]!=null)
				{
					model.mcpcode=row["mcpcode"].ToString();
				}
				if(row["mcstate"]!=null && row["mcstate"].ToString()!="")
				{
					if((row["mcstate"].ToString()=="1")||(row["mcstate"].ToString().ToLower()=="true"))
					{
						model.mcstate=true;
					}
					else
					{
						model.mcstate=false;
					}
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["btype"] != null)
                {
                    model.btype = row["btype"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_MaterialCategory> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,mcname,mccode,mcpname,mcpcode,mcstate,maker,cdate,mtype,btype from Sys_MaterialCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_MaterialCategory> r = new List<Sys_MaterialCategory>();
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
                sql = "select isnull(max(convert(int,substring(mccode,len(mccode)-1,3))),0) as n from Sys_MaterialCategory where mcpcode='" + where + "'";
            }
            else
            {
                sql = "select isnull(max(convert(int, mccode)),0) as n from Sys_MaterialCategory where mcpcode='" + where + "'";
            }
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
