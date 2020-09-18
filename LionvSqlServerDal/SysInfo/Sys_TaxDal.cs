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
    public class Sys_TaxDal:ISys_TaxDal
    {
       
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Tax");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Tax model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Tax(");
			strSql.Append("tname,tcode,tax,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@tname,@tcode,@tax,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,10),
					new SqlParameter("@tax", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.tname;
			parameters[1].Value = model.tcode;
			parameters[2].Value = model.tax;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
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
		public bool Update(Sys_Tax model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Tax set ");
			strSql.Append("tname=@tname,");
			strSql.Append("tax=@tax,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tax", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@tcode", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.tname;
			parameters[1].Value = model.tax;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.id;
			parameters[5].Value = model.tcode;
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
			strSql.Append("delete from Sys_Tax ");
            strSql.AppendFormat(" where  1=1 {0}", where);
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
		public Sys_Tax Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,tname,tcode,tax,maker,cdate from Sys_Tax ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Tax r = new Sys_Tax();
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
		public Sys_Tax DataRowToModel(DataRow row)
		{
			Sys_Tax model=new  Sys_Tax();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["tname"]!=null)
				{
					model.tname=row["tname"].ToString();
				}
				if(row["tcode"]!=null)
				{
					model.tcode=row["tcode"].ToString();
				}
				if(row["tax"]!=null && row["tax"].ToString()!="")
				{
					model.tax=decimal.Parse(row["tax"].ToString());
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
        public List<Sys_Tax> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,tname,tcode,tax,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_Tax where 1=1 {0}", where);
            List<Sys_Tax> r = new List<Sys_Tax>();
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
            sql = "select isnull(max(convert(int,tcode)),0) as n from Sys_Tax ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetAgentTax(string dcode, string tcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RAgentTax where dcode='{0}';", dcode);
            sql.AppendFormat(" insert into Sys_RAgentTax ( dcode,tcode) values ('{0}','{1}')", dcode, tcode);
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
        public int ReSetAgentTax(string dcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RAgentTax where dcode='{0}';", dcode);
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
        public string  GetAgentTax(string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  tcode  from Sys_RAgentTax ");
            strSql.AppendFormat(" where dcode='{0}'", dcode);

            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0][0].ToString();
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
