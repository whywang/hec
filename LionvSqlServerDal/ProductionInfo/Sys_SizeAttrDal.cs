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
    public class Sys_SizeAttrDal : ISys_SizeAttrDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeAttr");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeAttr(");
			strSql.Append("sname,scode,sattr,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sname,@scode,@sattr,@maker,@cdate)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@sattr", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.sattr;
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
		public bool Update( Sys_SizeAttr model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeAttr set ");
			strSql.Append("sname=@sname,");
			strSql.Append("sattr=@sattr,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where scode=@scode");
			SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,50),
					new SqlParameter("@sattr", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@scode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sname;
			parameters[1].Value = model.sattr;
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
		public bool Delete(string scode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_SizeAttr ");
            strSql.AppendFormat(" where scode='{0}'; ", scode);
            strSql.Append("delete from Sys_RInventorySize ");
            strSql.AppendFormat(" where scode='{0}' ", scode);
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
		public  Sys_SizeAttr Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sname,scode,sattr,maker,cdate from Sys_SizeAttr ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeAttr r = new Sys_SizeAttr();
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
		public  Sys_SizeAttr DataRowToModel(DataRow row)
		{
			 Sys_SizeAttr model=new  Sys_SizeAttr();
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
				if(row["sattr"]!=null)
				{
					model.sattr=row["sattr"].ToString();
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
        public List<Sys_SizeAttr> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sname,scode,sattr,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SizeAttr where 1=1 {0}", strWhere);
            List<Sys_SizeAttr> r = new List<Sys_SizeAttr>();
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
            sql = "select isnull(max(convert(int,scode)),0) as n from Sys_SizeAttr ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSizeType(List<string> icode, string[] scode)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            foreach (string icv in icode)
            {
                strSql.AppendFormat("delete from Sys_RInventorySize where pcode='{0}';", icv);
                foreach (string sv in scode)
                {
                    strSql.AppendFormat("insert into Sys_RInventorySize (pcode,scode) values ('{0}','{1}') ;", icv, sv);
                }
            }
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetSizeType(List<string> icode)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            foreach (string icv in icode)
            {
                strSql.AppendFormat("delete from Sys_RInventorySize where pcode='{0}';", icv);
            }
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetSizeType(string icode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select scode ");
            strSql.AppendFormat(" FROM Sys_RInventorySize where pcode='{0}'", icode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["scode"].ToString();
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
