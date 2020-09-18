using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
   public class CB_ProduceStartDateDal:ICB_ProduceStartDateDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CB_ProduceStartDate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
      
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( CB_ProduceStartDate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CB_ProduceStartDate(");
			strSql.Append("sid,msid,sdate,dname,dcode,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@msid,@sdate,@dname,@dcode,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@msid", SqlDbType.NVarChar,50),
					new SqlParameter("@sdate", SqlDbType.Date,3),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.msid;
			parameters[2].Value = model.sdate;
			parameters[3].Value = model.dname;
			parameters[4].Value = model.dcode;
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
		public bool Update( CB_ProduceStartDate model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CB_ProduceStartDate set ");
			strSql.Append("sid=@sid,");
			strSql.Append("sdate=@sdate,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@sdate", SqlDbType.Date,3),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@msid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.sdate;
			parameters[2].Value = model.dname;
			parameters[3].Value = model.dcode;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.msid;

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
        public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from CB_ProduceStartDate where 1=1 {0}", where);
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
        public CB_ProduceStartDate Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,msid,sdate,dname,dcode,cdate from CB_ProduceStartDate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_ProduceStartDate r = new CB_ProduceStartDate();
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
		public  CB_ProduceStartDate DataRowToModel(DataRow row)
		{
			 CB_ProduceStartDate model=new  CB_ProduceStartDate();
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
				if(row["msid"]!=null)
				{
					model.msid=row["msid"].ToString();
				}
				if(row["sdate"]!=null && row["sdate"].ToString()!="")
				{
					model.sdate= row["sdate"].ToString( );
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
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
        public List<CB_ProduceStartDate> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,msid,sdate,dname,dcode,cdate ");
			strSql.Append(" FROM CB_ProduceStartDate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<CB_ProduceStartDate> r = new List<CB_ProduceStartDate>();
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
