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
   public class Sys_SectionPriceCateDal : ISys_SectionPriceCateDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SectionPriceCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SectionPriceCate model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_SectionPriceCate(");
            strSql.Append("sname,scode,dcode,pcode,pname,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sname,@scode,@dcode,@pcode,@pname,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.scode;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.pname;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;

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
		public bool Update( Sys_SectionPriceCate model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_SectionPriceCate set ");
            strSql.Append("sname=@sname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("pname=@pname,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where scode=@scode");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@scode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.pcode;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.scode;

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
			strSql.Append("delete from Sys_SectionPriceCate ");
            strSql.AppendFormat(" where scode='{0}'; ", scode);
            strSql.Append("delete from Sys_SectionPrice ");
            strSql.AppendFormat(" where scode='{0}'; ", scode);
            strSql.Append("delete from Sys_RInventorySectionCate ");
            strSql.AppendFormat(" where scode='{0}'; ", scode);
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
        public Sys_SectionPriceCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sname,scode,dcode,pcode,pname,maker,cdate from Sys_SectionPriceCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SectionPriceCate r = new Sys_SectionPriceCate();
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
		public  Sys_SectionPriceCate DataRowToModel(DataRow row)
		{
			 Sys_SectionPriceCate model=new  Sys_SectionPriceCate();
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
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
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
        public List<Sys_SectionPriceCate> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sname,scode,dcode,pcode,pname,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SectionPriceCate where 1=1 {0}", strWhere);
            List<Sys_SectionPriceCate> r = new List<Sys_SectionPriceCate>();
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
            sql = "select isnull(max(convert(int,scode)),0) as n from Sys_SectionPriceCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSectionPrice(string[] pcode,string scode,string uname)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string p in pcode)
            {
                strSql.AppendFormat("delete from Sys_RInventorySectionCate  where pcode='{0}';", p);
            }
            foreach (string p in pcode)
            {
                strSql.AppendFormat("insert into Sys_RInventorySectionCate  (pcode,scode,maker,cdate)values('{0}','{1}','{2}',getdate())  ;", p, scode,uname);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetSectionPrice(string[] pcode)
        {
            StringBuilder strSql = new StringBuilder();
            foreach (string p in pcode)
            {
                strSql.AppendFormat("delete from Sys_RInventorySectionCate  where pcode='{0}';", p);
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetSectionPrice(string pcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select scode from Sys_RInventorySectionCate ");
            strSql.AppendFormat(" where pcode='{0}'", pcode);
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
