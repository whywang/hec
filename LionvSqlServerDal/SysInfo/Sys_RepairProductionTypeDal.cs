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
   public class Sys_RepairProductionTypeDal:ISys_RepairProductionTypeDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_RepairProductionType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_RepairProductionType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_RepairProductionType(");
			strSql.Append("apname,apcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@apname,@apcode,@maker,@cdate)");

			SqlParameter[] parameters = {
					new SqlParameter("@apname", SqlDbType.NVarChar,30),
					new SqlParameter("@apcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime,3)};
			parameters[0].Value = model.apname;
			parameters[1].Value = model.apcode;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;

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
		public bool Update( Sys_RepairProductionType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_RepairProductionType set ");
			strSql.Append("apname=@apname,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@apname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime,3),
					new SqlParameter("@apcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.apname;
			parameters[1].Value = model.maker;
			parameters[2].Value = model.cdate;
			parameters[3].Value = model.id;
			parameters[4].Value = model.apcode;

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
		public bool Delete(string apcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_RepairProductionType ");
            strSql.AppendFormat(" where apcode='{0}' ;", apcode);
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
        public Sys_RepairProductionType Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,apname,apcode,maker,cdate from Sys_RepairProductionType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RepairProductionType r = new Sys_RepairProductionType();
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
		public  Sys_RepairProductionType DataRowToModel(DataRow row)
		{
			 Sys_RepairProductionType model=new  Sys_RepairProductionType();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["apname"]!=null)
				{
					model.apname=row["apname"].ToString();
				}
				if(row["apcode"]!=null)
				{
					model.apcode=row["apcode"].ToString();
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
        public List<Sys_RepairProductionType> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,apname,apcode,maker,cdate ");
			strSql.Append(" FROM Sys_RepairProductionType ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_RepairProductionType> r = new List<Sys_RepairProductionType>();
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
            string sql = "select isnull(max(convert(int,apcode)),0) as n from Sys_RepairProductionType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
