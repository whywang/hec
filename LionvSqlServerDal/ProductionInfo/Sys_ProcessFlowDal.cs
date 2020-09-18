using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProcessFlowDal : ISys_ProcessFlowDal
    {
        #region  BasicMethod
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProcessFlow");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ProcessFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProcessFlow(");
			strSql.Append("pname,pcode,pstate,maker,cdate,dcode)");
			strSql.Append(" values (");
			strSql.Append("@pname,@pcode,@pstate,@maker,@cdate,@dcode)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,10),
					new SqlParameter("@pstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.pcode;
			parameters[2].Value = model.pstate;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
            parameters[5].Value = model.dcode;
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
		public bool Update( Sys_ProcessFlow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProcessFlow set ");
			strSql.Append("pname=@pname,");
			strSql.Append("pstate=@pstate,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where pcode=@pcode");
			SqlParameter[] parameters = {
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pstate", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pcode", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.pname;
			parameters[1].Value = model.pstate;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.pcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}
 
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_ProcessFlow ");
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
		public Sys_ProcessFlow Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pname,pcode,pstate,maker,cdate from Sys_ProcessFlow ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProcessFlow r = new Sys_ProcessFlow();
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
		public  Sys_ProcessFlow DataRowToModel(DataRow row)
		{
			 Sys_ProcessFlow model=new  Sys_ProcessFlow();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["pname"]!=null)
				{
					model.pname=row["pname"].ToString();
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["pstate"]!=null && row["pstate"].ToString()!="")
				{
					if((row["pstate"].ToString()=="1")||(row["pstate"].ToString().ToLower()=="true"))
					{
						model.pstate=true;
					}
					else
					{
						model.pstate=false;
					}
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
        public List<Sys_ProcessFlow> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,pname,pcode,pstate,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ProcessFlow where 1=1 {0}", strWhere);
            List<Sys_ProcessFlow> r = new List<Sys_ProcessFlow>();
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
            sql = "select isnull(max(convert(int,pcode)),0) as n from Sys_ProcessFlow ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
