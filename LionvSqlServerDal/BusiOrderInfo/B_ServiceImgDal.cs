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
   public class B_ServiceImgDal:IB_ServiceImgDal
    {
        #region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_ServiceImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_ServiceImg(");
			strSql.Append("sid,iurl,itype,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@iurl,@itype,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@iurl", SqlDbType.NVarChar,200),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.iurl;
			parameters[2].Value = model.itype;
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
		/// 更新一条数据
		/// </summary>
		public bool Update( B_ServiceImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_ServiceImg set ");
			strSql.Append("sid=@sid,");
			strSql.Append("iurl=@iurl,");
			strSql.Append("itype=@itype,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@iurl", SqlDbType.NVarChar,200),
					new SqlParameter("@itype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.iurl;
			parameters[2].Value = model.itype;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
			parameters[5].Value = model.id;

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
			strSql.Append("delete from B_ServiceImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
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
		public  B_ServiceImg Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,iurl,itype,maker,cdate from B_ServiceImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ServiceImg r = new B_ServiceImg();
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
		public  B_ServiceImg DataRowToModel(DataRow row)
		{
			 B_ServiceImg model=new  B_ServiceImg();
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
				if(row["iurl"]!=null)
				{
					model.iurl=row["iurl"].ToString();
				}
				if(row["itype"]!=null)
				{
					model.itype=row["itype"].ToString();
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
        public List<B_ServiceImg> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,iurl,itype,maker,cdate ");
			strSql.Append(" FROM B_ServiceImg ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ServiceImg> r = new List<B_ServiceImg>();
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
