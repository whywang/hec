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
   public class Sys_TPriceCateDal:ISys_TPriceCateDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_TPriceCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        
		 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_TPriceCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_TPriceCate(");
			strSql.Append("lpname,lpcode,ptype,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@lpname,@lpcode,@ptype,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@lpname", SqlDbType.NVarChar,30),
					new SqlParameter("@lpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.lpname;
			parameters[1].Value = model.lpcode;
			parameters[2].Value = model.ptype;
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
		public bool Update( Sys_TPriceCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_TPriceCate set ");
			strSql.Append("lpname=@lpname,");
			strSql.Append("ptype=@ptype,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where lpcode=@lpcode");
			SqlParameter[] parameters = {
					new SqlParameter("@lpname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@lpcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.lpname;
			parameters[1].Value = model.ptype;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.lpcode;

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
		public bool Delete(string lpcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_TPriceCate ");
            strSql.AppendFormat(" where lpcode='{0}'; ", lpcode);
            strSql.Append("delete from Sys_TPrice ");
            strSql.AppendFormat(" where lpcode='{0}'; ", lpcode);
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
		public  Sys_TPriceCate Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lpname,lpcode,ptype,maker,cdate from Sys_TPriceCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_TPriceCate r = new Sys_TPriceCate();
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
		public  Sys_TPriceCate DataRowToModel(DataRow row)
		{
			 Sys_TPriceCate model=new  Sys_TPriceCate();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lpname"]!=null)
				{
					model.lpname=row["lpname"].ToString();
				}
				if(row["lpcode"]!=null)
				{
					model.lpcode=row["lpcode"].ToString();
				}
				if(row["ptype"]!=null)
				{
					model.ptype=row["ptype"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}

 
		/// <summary>
		/// 获得前几行数据
		/// </summary>
        public List<Sys_TPriceCate> QueryList(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lpname,lpcode,ptype,maker,cdate");
            strSql.AppendFormat(" FROM Sys_TPriceCate where 1=1 {0}", strWhere);
            List<Sys_TPriceCate> r = new List<Sys_TPriceCate>();
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
            sql = "select isnull(max(convert(int,lpcode)),0) as n from Sys_TPriceCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetMsMtPrice(string ptype, string mscode, string mtcode, string lpcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RMsMtPrice ");
            strSql.AppendFormat(" where ptype='{0}' and mscode='{1}' and mtcode='{2}' and lpcode='{3}'; ",  ptype,  mscode,  mtcode,  lpcode);
            strSql.Append("insert into Sys_RMsMtPrice (ptype,mscode,mtcode,lpcode)");
            strSql.AppendFormat(" values ('{0}','{1}','{2}','{3}'); ", ptype, mscode, mtcode, lpcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetMsMtPrice(string ptype, string mscode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RMsMtPrice ");
            strSql.AppendFormat(" where ptype='{0}' and mscode='{1}'; ", ptype, mscode);
          
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetMsMtPrice(string ptype, string mscode, string mtcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select lpcode");
            strSql.AppendFormat(" FROM Sys_RMsMtPrice where  ptype='{0}' and mscode='{1}' and mtcode='{2}';",  ptype, mscode,  mtcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["lpcode"].ToString()+';';
                }
                r = r.Substring(0, r.Length - 1);
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
