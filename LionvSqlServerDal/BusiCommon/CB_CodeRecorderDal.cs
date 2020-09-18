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
   public class CB_CodeRecorderDal:ICB_CodeRecorderDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CB_CodeRecorder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
       
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( CB_CodeRecorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CB_CodeRecorder(");
			strSql.Append("sid,emcode,ynum,areatype,citytype,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@emcode,@ynum,@areatype,@citytype,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@emcode", SqlDbType.NVarChar,10),
					new SqlParameter("@ynum", SqlDbType.Int,4),
					new SqlParameter("@areatype", SqlDbType.NVarChar,50),
					new SqlParameter("@citytype", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.emcode;
			parameters[2].Value = model.ynum;
			parameters[3].Value = model.areatype;
			parameters[4].Value = model.citytype;
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
		/// 得到一个对象实体
		/// </summary>
		public  CB_CodeRecorder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,emcode,ynum,areatype,citytype,cdate from CB_CodeRecorder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            CB_CodeRecorder r = new CB_CodeRecorder();
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
		public  CB_CodeRecorder DataRowToModel(DataRow row)
		{
			 CB_CodeRecorder model=new  CB_CodeRecorder();
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
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["ynum"]!=null && row["ynum"].ToString()!="")
				{
					model.ynum=int.Parse(row["ynum"].ToString());
				}
				if(row["areatype"]!=null)
				{
					model.areatype=row["areatype"].ToString();
				}
				if(row["citytype"]!=null)
				{
					model.citytype=row["citytype"].ToString();
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
        public List<CB_CodeRecorder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,emcode,ynum,areatype,citytype,cdate ");
            strSql.AppendFormat(" FROM CB_CodeRecorder where 1=1 {0}", strWhere);
            List<CB_CodeRecorder> r = new List<CB_CodeRecorder>();
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
        public int QueryCount(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(count(1)),0) as n from CB_CodeRecorder where  1=1 "+where;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
