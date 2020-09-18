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
   public class Sys_SizeTransformRDal:ISys_SizeTransformRDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeTransformR");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeTransformR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeTransformR(");
			strSql.Append("rname,rcode,rtype,dh,dw,dcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@rname,@rcode,@rtype,@dh,@dw,@dcode,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rtype", SqlDbType.NVarChar,30),
					new SqlParameter("@dh", SqlDbType.Decimal,9),
					new SqlParameter("@dw", SqlDbType.Decimal,9),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.rcode;
			parameters[2].Value = model.rtype;
			parameters[3].Value = model.dh;
			parameters[4].Value = model.dw;
			parameters[5].Value = model.dcode;
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
		public bool Update( Sys_SizeTransformR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeTransformR set ");
			strSql.Append("rname=@rname,");
			strSql.Append("rtype=@rtype,");
			strSql.Append("dh=@dh,");
			strSql.Append("dw=@dw,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where rcode=@rcode");
			SqlParameter[] parameters = {
					new SqlParameter("@rname", SqlDbType.NVarChar,30),
					new SqlParameter("@rtype", SqlDbType.NVarChar,30),
					new SqlParameter("@dh", SqlDbType.Decimal,9),
					new SqlParameter("@dw", SqlDbType.Decimal,9),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.rname;
			parameters[1].Value = model.rtype;
			parameters[2].Value = model.dh;
			parameters[3].Value = model.dw;
			parameters[4].Value = model.dcode;
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
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_SizeTransformR ");
			strSql.AppendFormat(" where 1=1 {0} ",where);
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
		public  Sys_SizeTransformR Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,rname,rcode,rtype,dh,dw,dcode,maker,cdate from Sys_SizeTransformR ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeTransformR r = new Sys_SizeTransformR();
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
		public  Sys_SizeTransformR DataRowToModel(DataRow row)
		{
			 Sys_SizeTransformR model=new  Sys_SizeTransformR();
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
				if(row["rtype"]!=null)
				{
					model.rtype=row["rtype"].ToString();
				}
				if(row["dh"]!=null && row["dh"].ToString()!="")
				{
					model.dh=decimal.Parse(row["dh"].ToString());
				}
				if(row["dw"]!=null && row["dw"].ToString()!="")
				{
					model.dw=decimal.Parse(row["dw"].ToString());
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
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
        public List<Sys_SizeTransformR> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,rname,rcode,rtype,dh,dw,dcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SizeTransformR where 1=1 {0}", strWhere);
            List<Sys_SizeTransformR> r = new List<Sys_SizeTransformR>();
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
            sql = "select isnull(max(convert(int,rcode)),0) as n from Sys_SizeTransformR ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetRjc(string mcode, string tcode, string cname, string rcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from  Sys_RSizeFormatMsMtCave where mscode='{0}' and mtcode='{1}' and cname='{2}';", mcode, tcode, cname);
            strSql.AppendFormat(" insert into Sys_RSizeFormatMsMtCave ( mscode,mtcode ,rcode,cname) values('{0}','{1}','{2}','{3}') ;",mcode, tcode, rcode,cname);
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
        public bool ReSetRjc(string mcode, string tcode, string cname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from  Sys_RSizeFormatMsMtCave where mscode='{0}' and mtcode='{1}' and cname='{2}';", mcode, tcode, cname);
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
        public string GetRjc(string mcode, string tcode, string cname)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select rcode from  Sys_RSizeFormatMsMtCave where mscode='{0}' and mtcode='{1}' and cname='{2}';", mcode, tcode, cname);
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
        public DataTable QueryCaveType(string mcode, string tcode)
        {
            DataTable r = new DataTable ();
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select cname,rcode from  Sys_RSizeFormatMsMtCave where mscode='{0}' and mtcode='{1}';", mcode.Substring(0, mcode.Length - 3), tcode.Substring(0, tcode.Length - 3));
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
