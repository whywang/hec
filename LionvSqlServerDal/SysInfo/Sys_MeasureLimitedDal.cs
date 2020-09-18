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
   public class Sys_MeasureLimitedDal:ISys_MeasureLimitedDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_MeasureLimited");
			strSql.Append(" where dcode=@dcode ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
      
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_MeasureLimited model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_MeasureLimited(");
			strSql.Append("dname,dcode,lnum,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@dname,@dcode,@lnum,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@lnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.Date,3)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.lnum;
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
		public bool Update( Sys_MeasureLimited model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MeasureLimited set ");
			strSql.Append("dname=@dname,");
			strSql.Append("lnum=@lnum,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where dcode=@dcode");
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@lnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.Date,3),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.lnum;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.dcode;

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
            strSql.Append("delete from Sys_AddressList ");
            strSql.AppendFormat(" where  1=1 {0};", where);
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
		public  Sys_MeasureLimited Query(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,dname,dcode,lnum,maker,cdate from Sys_MeasureLimited ");
            strSql.AppendFormat(" where 1=1 {0}", id.ToString());
            Sys_MeasureLimited r = new Sys_MeasureLimited();
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
		public  Sys_MeasureLimited DataRowToModel(DataRow row)
		{
			 Sys_MeasureLimited model=new  Sys_MeasureLimited();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["lnum"]!=null && row["lnum"].ToString()!="")
				{
					model.lnum=int.Parse(row["lnum"].ToString());
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
        public List<Sys_MeasureLimited> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,dname,dcode,lnum,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_MeasureLimited where 1=1 {0}", strWhere);
            List<Sys_MeasureLimited> r = new List<Sys_MeasureLimited>();
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
        //查询店面对应城市测量限制数量
        public Sys_MeasureLimited QueryDepLimited(string dcode)
        {
            Sys_MeasureLimited r = new Sys_MeasureLimited();
            if (dcode.Length > 8)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select  top 1 id,dname,dcode,lnum,maker,cdate from Sys_MeasureLimited ");
                strSql.AppendFormat(" where dcode='{0}'", dcode);
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = DataRowToModel(dt.Rows[0]);
                }
                else
                {
                    r = QueryDepLimited(dcode.Substring(0, dcode.Length - 4));
                }
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
