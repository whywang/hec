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
   public class Sys_DesignerDal:ISys_DesignerDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Designer");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Designer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Designer(");
			strSql.Append("eno,dname,dtelephone,dqq,dintroduce,dappraise,dimg,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@eno,@dname,@dtelephone,@dqq,@dintroduce,@dappraise,@dimg,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@eno", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@dqq", SqlDbType.NVarChar,30),
					new SqlParameter("@dintroduce", SqlDbType.NVarChar,500),
					new SqlParameter("@dappraise", SqlDbType.NVarChar,500),
					new SqlParameter("@dimg", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.eno;
			parameters[1].Value = model.dname;
			parameters[2].Value = model.dtelephone;
			parameters[3].Value = model.dqq;
			parameters[4].Value = model.dintroduce;
			parameters[5].Value = model.dappraise;
			parameters[6].Value = model.dimg;
			parameters[7].Value = model.maker;
			parameters[8].Value = model.cdate;

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
		public bool Update(Sys_Designer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Designer set ");
			strSql.Append("dname=@dname,");
			strSql.Append("dtelephone=@dtelephone,");
			strSql.Append("dqq=@dqq,");
			strSql.Append("dintroduce=@dintroduce,");
			strSql.Append("dappraise=@dappraise");
			strSql.Append(" where eno=@eno");
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dtelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@dqq", SqlDbType.NVarChar,30),
					new SqlParameter("@dintroduce", SqlDbType.NVarChar,500),
					new SqlParameter("@dappraise", SqlDbType.NVarChar,500),
					new SqlParameter("@eno", SqlDbType.Int,4)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.dtelephone;
			parameters[2].Value = model.dqq;
			parameters[3].Value = model.dintroduce;
			parameters[4].Value = model.dappraise;
            parameters[5].Value = model.eno;

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
			strSql.Append("delete from Sys_Designer ");
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
        public Sys_Designer Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,eno,dname,dtelephone,dqq,dintroduce,dappraise,dimg,maker,cdate from Sys_Designer ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Designer r = new Sys_Designer();
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
		public Sys_Designer DataRowToModel(DataRow row)
		{
			 Sys_Designer model=new  Sys_Designer();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["eno"]!=null)
				{
					model.eno=row["eno"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dtelephone"]!=null)
				{
					model.dtelephone=row["dtelephone"].ToString();
				}
				if(row["dqq"]!=null)
				{
					model.dqq=row["dqq"].ToString();
				}
				if(row["dintroduce"]!=null)
				{
					model.dintroduce=row["dintroduce"].ToString();
				}
				if(row["dappraise"]!=null)
				{
					model.dappraise=row["dappraise"].ToString();
				}
				if(row["dimg"]!=null)
				{
					model.dimg=row["dimg"].ToString();
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
		/// 获得数据列表
		/// </summary>
        public List<Sys_Designer> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,eno,dname,dtelephone,dqq,dintroduce,dappraise,dimg,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_Designer where 1=1 {0}", strWhere);
            List<Sys_Designer> r = new List<Sys_Designer>();
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
