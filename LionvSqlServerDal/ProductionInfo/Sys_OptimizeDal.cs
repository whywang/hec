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
   public class Sys_OptimizeDal:ISys_OptimizeDal
    {
        public Sys_OptimizeDal()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Optimize");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Optimize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Optimize(");
			strSql.Append("oname,ocode,mtype,stype,ocols,cdate,maker,dcode)");
			strSql.Append(" values (");
			strSql.Append("@oname,@ocode,@mtype,@stype,@ocols,@cdate,@maker,@dcode)");
			SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,50),
					new SqlParameter("@ocode", SqlDbType.NVarChar,10),
					new SqlParameter("@mtype", SqlDbType.NVarChar,10),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@ocols", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.oname;
			parameters[1].Value = model.ocode;
			parameters[2].Value = model.mtype;
			parameters[3].Value = model.stype;
			parameters[4].Value = model.ocols;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.maker;
            parameters[7].Value = model.dcode;
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
		public bool Update(Sys_Optimize model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Optimize set ");
			strSql.Append("oname=@oname,");
			strSql.Append("mtype=@mtype,");
			strSql.Append("stype=@stype,");
			strSql.Append("ocols=@ocols,");
			strSql.Append("cdate=@cdate,");
			strSql.Append("maker=@maker");
            strSql.Append(" where ocode=@ocode");
			SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,50),
					new SqlParameter("@mtype", SqlDbType.NVarChar,10),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@ocols", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@ocode", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.oname;
			parameters[1].Value = model.mtype;
			parameters[2].Value = model.stype;
			parameters[3].Value = model.ocols;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.ocode;
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
			strSql.Append("delete from Sys_Optimize ");
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
        public Sys_Optimize Query(string strWhere)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,oname,ocode,mtype,stype,ocols,pcols,cdate,maker,dcode from Sys_Optimize ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            Sys_Optimize r = new Sys_Optimize();
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
		public Sys_Optimize DataRowToModel(DataRow row)
		{
			Sys_Optimize model=new Sys_Optimize();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["oname"]!=null)
				{
					model.oname=row["oname"].ToString();
				}
				if(row["ocode"]!=null)
				{
					model.ocode=row["ocode"].ToString();
				}
				if(row["mtype"]!=null)
				{
					model.mtype=row["mtype"].ToString();
				}
				if(row["stype"]!=null)
				{
					model.stype=row["stype"].ToString();
				}
				if(row["ocols"]!=null)
				{
					model.ocols=row["ocols"].ToString();
				}
                if (row["pcols"] != null)
                {
                    model.pcols = row["pcols"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate=row["cdate"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Optimize> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,oname,ocode,mtype,stype,ocols,pcols,cdate,maker,dcode ");
            strSql.AppendFormat(" FROM Sys_Optimize where 1=1 {0}", strWhere);
            List<Sys_Optimize> r = new List<Sys_Optimize>();
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
            sql = "select isnull(max(convert(int,ocode)),0) as n from Sys_Optimize ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetOptProduction(string ocode, string pcode, string[] ncode)
        {
            StringBuilder sql = new StringBuilder();
            for (int i = 0; i < ncode.Length; i++)
            {
                sql.AppendFormat(" delete from Sys_RInventoryOptimize where ocode ='{0}' and icode='{0}' ;", ocode, pcode);
            }
            for (int i = 0; i < ncode.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RInventoryOptimize (ocode,icode,pcode) values ('{0}','{1}','{2}') ;", ocode, pcode, ncode[i]);
            }
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetOptProduction(string ocode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryOptimize where ocode ='{0}';", ocode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetOptProduction(string ocode, string pcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" FROM Sys_RInventoryOptimize where ocode='{0}' and icode='{1}'", ocode,pcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["pcode"].ToString() + ";";
                }
                if (r.Length > 1)
                {
                    r = r.Substring(0, r.Length - 1);
                }
            }
            else
            {
                r = "";
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
