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
   public class B_MzPriceFileDal:IB_MzPriceFileDal
   {
       #region
       /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_MzPriceFile");
			strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add( B_MzPriceFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_MzPriceFile(");
			strSql.Append(" sid,fname,fmoney,furl,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@fname,@fmoney,@furl,@maker,@cdate)");
			SqlParameter[] parameters = {
		 
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fmoney", SqlDbType.Decimal,9),
					new SqlParameter("@furl", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.fname;
			parameters[2].Value = model.fmoney;
			parameters[3].Value = model.furl;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;

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
		/// 更新一条数据
		/// </summary>
		public bool Update( B_MzPriceFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_MzPriceFile set ");
			strSql.Append("sid=@sid,");
			strSql.Append("fname=@fname,");
			strSql.Append("fmoney=@fmoney,");
			strSql.Append("furl=@furl,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fmoney", SqlDbType.Decimal,9),
					new SqlParameter("@furl", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.fname;
			parameters[2].Value = model.fmoney;
			parameters[3].Value = model.furl;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from B_MzPriceFile ");
			strSql.AppendFormat(" where 1=1 {0} ",where);
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
		public  B_MzPriceFile Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,fname,fmoney,furl,maker,cdate from B_MzPriceFile ");
			strSql.AppendFormat(" where 1=1 {0}",where);
		 
			 B_MzPriceFile r=new  B_MzPriceFile();
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
		public  B_MzPriceFile DataRowToModel(DataRow row)
		{
			 B_MzPriceFile model=new  B_MzPriceFile();
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
				if(row["fname"]!=null)
				{
					model.fname=row["fname"].ToString();
				}
				if(row["fmoney"]!=null && row["fmoney"].ToString()!="")
				{
					model.fmoney=decimal.Parse(row["fmoney"].ToString());
				}
				if(row["furl"]!=null)
				{
					model.furl=row["furl"].ToString();
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
		public List<B_MzPriceFile> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,fname,fmoney,furl,maker,cdate ");
			strSql.Append(" FROM B_MzPriceFile ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_MzPriceFile> r = new List<B_MzPriceFile>();
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
