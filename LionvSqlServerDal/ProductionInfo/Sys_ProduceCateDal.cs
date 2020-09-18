﻿using System;
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
    public class Sys_ProduceCateDal : ISys_ProduceCateDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProduceCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ProduceCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProduceCate(");
			strSql.Append("lname,lcode,cdate)");
			strSql.Append(" values (");
			strSql.Append("@lname,@lcode,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.lcode;
			parameters[2].Value = model.cdate;

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
		public bool Update( Sys_ProduceCate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProduceCate set ");
			strSql.Append("lname=@lname,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where lcode=@lcode");
			SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
		 
					new SqlParameter("@lcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.lname;
			parameters[1].Value = model.cdate;
			parameters[2].Value = model.lcode;

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
			strSql.Append("delete from Sys_ProduceCate ");
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
        public Sys_ProduceCate Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,lname,lcode,cdate from Sys_ProduceCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProduceCate r = new Sys_ProduceCate();
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
		public  Sys_ProduceCate DataRowToModel(DataRow row)
		{
			 Sys_ProduceCate model=new  Sys_ProduceCate();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["lname"]!=null)
				{
					model.lname=row["lname"].ToString();
				}
				if(row["lcode"]!=null)
				{
					model.lcode=row["lcode"].ToString();
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
        public List<Sys_ProduceCate> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,lname,lcode,cdate ");
            strSql.AppendFormat(" FROM Sys_ProduceCate where 1=1 {0}", strWhere);
            List<Sys_ProduceCate> r = new List<Sys_ProduceCate>();
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
            sql = "select isnull(max(convert(int,lcode)),0) as n from Sys_ProduceCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetProductionCate(string lcode, string icode)
        {
            StringBuilder sql = new StringBuilder();
            string[] arr = icode.Split(';');
            sql.AppendFormat(" delete from Sys_RProductionProduceCate where lcode ='{0}' ;", lcode);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != "")
                {
                    sql.AppendFormat(" insert into Sys_RProductionProduceCate (lcode,icode) values ('{0}','{1}') ;", lcode, arr[i]);
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetProductionCate(string lcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RProductionProduceCate where lcode ='{0}' ;", lcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetProductionCate(string lcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" FROM Sys_RProductionProduceCate where lcode='{0}' ", lcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["icode"].ToString() + ";";
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
