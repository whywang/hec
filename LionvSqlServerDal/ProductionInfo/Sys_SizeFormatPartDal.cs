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
    public class Sys_SizeFormatPartDal : ISys_SizeFormatPartDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_SizeFormatPart");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_SizeFormatPart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_SizeFormatPart(");
			strSql.Append("bjcname,bjname,bjcode,bjctype,bjattr,bjattrex)");
			strSql.Append(" values (");
			strSql.Append("@bjcname,@bjname,@bjcode,@bjctype,@bjattr,@bjattrex)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@bjcname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bjctype", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattrex", SqlDbType.NVarChar,10)};
			parameters[0].Value = model.bjcname;
			parameters[1].Value = model.bjname;
			parameters[2].Value = model.bjcode;
			parameters[3].Value = model.bjctype;
			parameters[4].Value = model.bjattr;
			parameters[5].Value = model.bjattrex;

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
		public bool Update( Sys_SizeFormatPart model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_SizeFormatPart set ");
			strSql.Append("bjcname=@bjcname,");
			strSql.Append("bjname=@bjname,");
			strSql.Append("bjctype=@bjctype,");
			strSql.Append("bjattr=@bjattr,");
			strSql.Append("bjattrex=@bjattrex");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@bjcname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjname", SqlDbType.NVarChar,30),
					new SqlParameter("@bjctype", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bjattrex", SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@bjcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.bjcname;
			parameters[1].Value = model.bjname;
			parameters[2].Value = model.bjctype;
			parameters[3].Value = model.bjattr;
			parameters[4].Value = model.bjattrex;
			parameters[5].Value = model.id;
			parameters[6].Value = model.bjcode;

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
		public bool Delete(string bjcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_SizeFormatPart ");
            strSql.AppendFormat(" where bjcode='{0}' ;", bjcode);
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
		public  Sys_SizeFormatPart Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,bjcname,bjname,bjcode,bjctype,bjattr,bjattrex,ftype from Sys_SizeFormatPart ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SizeFormatPart r = new Sys_SizeFormatPart();
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
		public  Sys_SizeFormatPart DataRowToModel(DataRow row)
		{
			 Sys_SizeFormatPart model=new  Sys_SizeFormatPart();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["bjcname"]!=null)
				{
					model.bjcname=row["bjcname"].ToString();
				}
				if(row["bjname"]!=null)
				{
					model.bjname=row["bjname"].ToString();
				}
				if(row["bjcode"]!=null)
				{
					model.bjcode=row["bjcode"].ToString();
				}
				if(row["bjctype"]!=null)
				{
					model.bjctype=row["bjctype"].ToString();
				}
				if(row["bjattr"]!=null)
				{
					model.bjattr=row["bjattr"].ToString();
				}
				if(row["bjattrex"]!=null)
				{
					model.bjattrex=row["bjattrex"].ToString();
				}
                if (row["ftype"] != null)
                {
                    model.ftype = row["ftype"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeFormatPart> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,bjcname,bjname,bjcode,bjctype,bjattr,bjattrex,ftype ");
            strSql.AppendFormat(" FROM Sys_SizeFormatPart where 1=1 {0}", strWhere);
            List<Sys_SizeFormatPart> r = new List<Sys_SizeFormatPart>();
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
            sql = "select isnull(max(convert(int,bjcode)),0) as n from Sys_SizeFormatPart ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
