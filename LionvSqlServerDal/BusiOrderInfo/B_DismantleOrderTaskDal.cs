using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_DismantleOrderTaskDal : IB_DismantleOrderTaskDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_DismantleOrderTask");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
	 
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_DismantleOrderTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_DismantleOrderTask(");
			strSql.Append("sid,cdy,dname,dcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@cdy,@dname,@dcode,@maker,@cdate)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@cdy", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.cdy;
			parameters[2].Value = model.dname;
			parameters[3].Value = model.dcode;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Update( B_DismantleOrderTask model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_DismantleOrderTask set ");
			strSql.Append("cdy=@cdy,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {

					new SqlParameter("@cdy", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.cdy;
			parameters[1].Value = model.dname;
			parameters[2].Value = model.dcode;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.sid;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
		/// 批量删除数据
		/// </summary>
        public bool Delete(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_DismantleOrderTask where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public B_DismantleOrderTask Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,cdy,dname,dcode,maker,cdate from B_DismantleOrderTask ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_DismantleOrderTask r = new B_DismantleOrderTask();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
		public  B_DismantleOrderTask DataRowToModel(DataRow row)
		{
			 B_DismantleOrderTask model=new  B_DismantleOrderTask();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["cdy"]!=null)
				{
					model.cdy=row["cdy"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
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
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_DismantleOrderTask> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,cdy,dname,dcode,maker,cdate ");
			strSql.Append(" FROM B_DismantleOrderTask ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_DismantleOrderTask> r = new List<B_DismantleOrderTask>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
