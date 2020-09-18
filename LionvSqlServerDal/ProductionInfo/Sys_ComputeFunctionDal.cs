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
    public class Sys_ComputeFunctionDal : ISys_ComputeFunctionDal
    {
        #region 
        public bool Exists(string where)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select count(1) from Sys_ComputeFunction");
           strSql.AppendFormat(" where 1=1 {0} ", where);
           return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
       }
        public int Add( Sys_ComputeFunction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ComputeFunction(");
			strSql.Append("fname,fcode,fattr,fstr,ftx,maker,cdate,dcode,fminv)");
			strSql.Append(" values (");
            strSql.Append("@fname,@fcode,@fattr,@fstr,@ftx,@maker,@cdate,@dcode,@fminv)");
			SqlParameter[] parameters = {
					new SqlParameter("@fname", SqlDbType.NVarChar,20),
					new SqlParameter("@fcode", SqlDbType.NVarChar,20),
					new SqlParameter("@fattr", SqlDbType.NVarChar,10),
					new SqlParameter("@fstr", SqlDbType.NVarChar,100),
					new SqlParameter("@ftx", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@fminv", SqlDbType.Decimal)};
			parameters[0].Value = model.fname;
			parameters[1].Value = model.fcode;
			parameters[2].Value = model.fattr;
			parameters[3].Value = model.fstr;
			parameters[4].Value = model.ftx;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.fminv;
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
		public bool Update( Sys_ComputeFunction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ComputeFunction set ");
			strSql.Append("fname=@fname,");
			strSql.Append("fattr=@fattr,");
			strSql.Append("fstr=@fstr,");
			strSql.Append("ftx=@ftx,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("fminv=@fminv");
			strSql.Append(" where fcode=@fcode");
			SqlParameter[] parameters = {
					new SqlParameter("@fname", SqlDbType.NVarChar,20),
					new SqlParameter("@fattr", SqlDbType.NVarChar,10),
					new SqlParameter("@fstr", SqlDbType.NVarChar,100),
					new SqlParameter("@ftx", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@fminv", SqlDbType.Decimal),
					new SqlParameter("@fcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.fname;
			parameters[1].Value = model.fattr;
			parameters[2].Value = model.fstr;
			parameters[3].Value = model.ftx;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.fminv;
            parameters[7].Value = model.fcode;
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
			strSql.Append("delete from Sys_ComputeFunction ");
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
		public Sys_ComputeFunction Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,fname,fcode,fattr,fstr,fminv,ftx,maker,cdate from Sys_ComputeFunction ");
			 strSql.AppendFormat(" where 1=1 {0}",where);
			 Sys_ComputeFunction r=new  Sys_ComputeFunction();
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
		public  Sys_ComputeFunction DataRowToModel(DataRow row)
		{
			Sys_ComputeFunction model=new  Sys_ComputeFunction();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["fname"]!=null)
				{
					model.fname=row["fname"].ToString();
				}
				if(row["fcode"]!=null)
				{
					model.fcode=row["fcode"].ToString();
				}
				if(row["fattr"]!=null)
				{
					model.fattr=row["fattr"].ToString();
				}
				if(row["fstr"]!=null)
				{
					model.fstr=row["fstr"].ToString();
				}
				if(row["ftx"]!=null)
				{
					model.ftx=row["ftx"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["fminv"] != null && row["fminv"].ToString() != "")
                {
                    model.fminv = Convert.ToDecimal(row["fminv"].ToString());
                }
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_ComputeFunction> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,fname,fcode,fattr,fstr,ftx,maker,cdate,fminv ");
			strSql.AppendFormat(" FROM Sys_ComputeFunction where 1=1 {0}",strWhere);
            List<Sys_ComputeFunction> r = new List<Sys_ComputeFunction>();
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
            sql = "select isnull(max(convert(int,fcode)),0) as n from Sys_ComputeFunction ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionCm(string pcode, string fcode,string ptx)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryComputerFunction where pcode like '{0}%' and ptx='{1}';", pcode, ptx);
            sql.AppendFormat(" insert into Sys_RInventoryComputerFunction (pcode,fcode,ptx,cdate) values ('{0}','{1}','{2}',getdate()) ;", pcode, fcode,ptx);
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
        public int ReSetProductionCm(string pcode,string ptx)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryComputerFunction where pcode like '{0}%' and ptx='{1}';", pcode,ptx);
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
        public string GetProductionCm(string pcode,string ptx)
        {
            string r = "";
            r = LoodQuery(pcode,ptx);
            return r;
        }
        private string LoodQuery(string pcode,string ptx)
        {
            string p = "";
            if (pcode.Length > 8)
            {
                string sql = "select fcode from Sys_RInventoryComputerFunction where pcode='" + pcode + "' and ptx='"+ptx+"'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3),ptx);
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
		#endregion  ExtensionMethod
    }
}
