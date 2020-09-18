using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterProductionImgDal:IB_AfterProductionImgDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterProductionImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterProductionImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterProductionImg(");
			strSql.Append("sid,gnum,url,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@gnum,@url,@maker,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gnum", SqlDbType.Int,4),
					new SqlParameter("@url", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.gnum;
			parameters[2].Value = model.url;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from B_AfterProductionImg ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
       public  bool Delete(string sid, string gnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_AfterProductionImg ");
            strSql.AppendFormat(" where sid='{0}' and gnum={1}", sid, gnum);
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
        public B_AfterProductionImg Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,gnum,url,maker,cdate from B_AfterProductionImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterProductionImg r = new B_AfterProductionImg();
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
		public  B_AfterProductionImg DataRowToModel(DataRow row)
		{
			 B_AfterProductionImg model=new  B_AfterProductionImg();
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
				if(row["gnum"]!=null && row["gnum"].ToString()!="")
				{
					model.gnum=int.Parse(row["gnum"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
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
        public List<B_AfterProductionImg> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,gnum,url,maker,cdate ");
			strSql.Append(" FROM B_AfterProductionImg ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterProductionImg> r = new List<B_AfterProductionImg>();
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
