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
   public class Sys_ContractRowTempDal:ISys_ContractRowTempDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ContractRowTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ContractRowTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ContractRowTemp(");
			strSql.Append("rname,rcode,cname,ccode,ctype,ctext,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@rname,@rcode,@cname,@ccode,@ctype,@ctext,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@ctext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.rcode;
			parameters[2].Value = model.cname;
			parameters[3].Value = model.ccode;
			parameters[4].Value = model.ctype;
			parameters[5].Value = model.ctext;
			parameters[6].Value = model.maker;
			parameters[7].Value = model.cdate;

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
		public bool Update( Sys_ContractRowTemp model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ContractRowTemp set ");
			strSql.Append("rname=@rname,");
			strSql.Append("cname=@cname,");
			strSql.Append("ccode=@ccode,");
			strSql.Append("ctype=@ctype,");
			strSql.Append("ctext=@ctext,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where rcode=@rcode");
			SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,30),
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@ctext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.ccode;
			parameters[3].Value = model.ctype;
			parameters[4].Value = model.ctext;
			parameters[5].Value = model.maker;
			parameters[6].Value = model.cdate;
			parameters[7].Value = model.rcode;

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
		public bool Delete(string rcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_ContractRowTemp ");
            strSql.AppendFormat(" where rcode='{0}' ;", rcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
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
		/// 得到一个对象实体
		/// </summary>
        public Sys_ContractRowTemp Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,rname,rcode,cname,ccode,ctype,ctext,maker,cdate from Sys_ContractRowTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ContractRowTemp r = new Sys_ContractRowTemp();
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
		public  Sys_ContractRowTemp DataRowToModel(DataRow row)
		{
			 Sys_ContractRowTemp model=new  Sys_ContractRowTemp();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["rname"]!=null)
				{
					model.rname=row["rname"].ToString();
				}
				if(row["rcode"]!=null)
				{
					model.rcode=row["rcode"].ToString();
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
				}
				if(row["ccode"]!=null)
				{
					model.ccode=row["ccode"].ToString();
				}
				if(row["ctype"]!=null)
				{
					model.ctype=row["ctype"].ToString();
				}
				if(row["ctext"]!=null)
				{
					model.ctext=row["ctext"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ContractRowTemp> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,rname,rcode,cname,ccode,ctype,ctext,maker,cdate ");
			strSql.Append(" FROM Sys_ContractRowTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ContractRowTemp> r = new List<Sys_ContractRowTemp>();
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
            string sql = "select isnull(max(convert(int,rcode)),0) as n from Sys_ContractRowTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
