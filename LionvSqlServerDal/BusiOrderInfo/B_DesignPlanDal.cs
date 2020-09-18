using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_DesignPlanDal : IB_DesignPlanDal
    { 
       	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_DesignPlan");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_DesignPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_DesignPlan(");
            strSql.Append("osid,sid,dname,durl,rcode,emcode,wcode,maker,dtype)");
			strSql.Append(" values (");
            strSql.Append("@osid,@sid,@dname,@durl,@rcode,@emcode,@wcode,@maker,@dtype)");
			 
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@durl", SqlDbType.NVarChar,200),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30) };
			parameters[0].Value = model.osid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.dname;
			parameters[3].Value = model.durl;
			parameters[4].Value = model.rcode;
			parameters[5].Value = model.emcode;
			parameters[6].Value = model.wcode;
			parameters[7].Value = model.maker;
            parameters[8].Value = model.dtype;
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
		public bool Update( B_DesignPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_DesignPlan set ");
			strSql.Append("osid=@osid,");
			strSql.Append("dname=@dname,");
			strSql.Append("durl=@durl,");
			strSql.Append("rcode=@rcode,");
			strSql.Append("emcode=@emcode,");
			strSql.Append("wcode=@wcode,");
			strSql.Append("maker=@maker");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@durl", SqlDbType.NVarChar,200),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.dname;
			parameters[2].Value = model.durl;
			parameters[3].Value = model.rcode;
			parameters[4].Value = model.emcode;
			parameters[5].Value = model.wcode;
			parameters[6].Value = model.maker;
			parameters[7].Value = model.osid;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_DesignPlan ");
			strSql.AppendFormat(" where 1=1 {0}",sid);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public B_DesignPlan Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,osid,sid,dname,durl,rcode,emcode,wcode,maker,cdate,dtype from B_DesignPlan ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_DesignPlan r = new B_DesignPlan();
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
		public  B_DesignPlan DataRowToModel(DataRow row)
		{
			 B_DesignPlan model=new  B_DesignPlan();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["durl"]!=null)
				{
					model.durl=row["durl"].ToString();
				}
				if(row["rcode"]!=null)
				{
					model.rcode=row["rcode"].ToString();
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["wcode"]!=null)
				{
					model.wcode=row["wcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
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
        public List<B_DesignPlan> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,osid,sid,dname,durl,rcode,emcode,wcode,maker,cdate,dtype");
			strSql.Append(" FROM B_DesignPlan ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_DesignPlan> r = new List<B_DesignPlan>();
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
