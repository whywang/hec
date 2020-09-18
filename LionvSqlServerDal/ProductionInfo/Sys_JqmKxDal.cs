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
    public class Sys_JqmKxDal:ISys_JqmKxDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_JqmKx");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_JqmKx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_JqmKx(");
			strSql.Append("kxname,mcode,maker)");
			strSql.Append(" values (");
			strSql.Append("@kxname,@mcode,@maker)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@kxname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.kxname;
			parameters[1].Value = model.mcode;
			parameters[2].Value = model.maker;


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
		public bool Update( Sys_JqmKx model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_JqmKx set ");
			strSql.Append("mcode=@mcode,");
			strSql.Append("maker=@maker");
            strSql.Append(" where kxname=@kxname");
			SqlParameter[] parameters = {
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@kxname", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.mcode;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.kxname;

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
		public bool Delete(string kxname)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_JqmKx ");
            strSql.AppendFormat(" where kxname='{0}'; ", kxname);
      
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
        public Sys_JqmKx Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,kxname,mcode,maker,cdate from Sys_JqmKx ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_JqmKx r = new Sys_JqmKx();
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
		public  Sys_JqmKx DataRowToModel(DataRow row)
		{
			 Sys_JqmKx model=new  Sys_JqmKx();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["kxname"]!=null)
				{
					model.kxname=row["kxname"].ToString();
				}
				if(row["mcode"]!=null)
				{
					model.mcode=row["mcode"].ToString();
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
        public List<Sys_JqmKx> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,kxname,mcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_JqmKx where 1=1 {0}", strWhere);
            List<Sys_JqmKx> r = new List<Sys_JqmKx>();
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

		#endregion  ExtensionMethod
    }
}
