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
    public class B_FeedBackImgDal : IB_FeedBackImgDal
    {
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_FeedBackImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_FeedBackImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_FeedBackImg(");
            strSql.Append("iname,url,sid,maker,remark,cdate)");
			strSql.Append(" values (");
            strSql.Append("@iname,@url,@sid,@maker,@remark,@cdate)");
			SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.iname;
			parameters[1].Value = model.url;
			parameters[2].Value = model.sid;
			parameters[3].Value = model.maker;
            parameters[4].Value = model.remark;
			parameters[5].Value = model.cdate;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
            }
            catch
            {
                r = -1;
            }
            return r;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_FeedBackImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_FeedBackImg set ");
			strSql.Append("iname=@iname,");
			strSql.Append("url=@url,");
			strSql.Append("sid=@sid,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@iname", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.iname;
			parameters[1].Value = model.url;
			parameters[2].Value = model.sid;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.id;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_FeedBackImg where 1=1 {0}", where);
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
		public  B_FeedBackImg Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,iname,url,sid,maker,cdate,remark from B_FeedBackImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_FeedBackImg r = new B_FeedBackImg();
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
		public  B_FeedBackImg DataRowToModel(DataRow row)
		{
			 B_FeedBackImg model=new  B_FeedBackImg();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["iname"]!=null)
				{
					model.iname=row["iname"].ToString();
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
        public List<B_FeedBackImg> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,iname,url,sid,maker,cdate,remark ");
			strSql.Append(" FROM B_FeedBackImg ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_FeedBackImg> r = new List<B_FeedBackImg>();
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
