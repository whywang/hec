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
   public class B_OrderFavorableDal:IB_OrderFavorableDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_OrderFavorable");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_OrderFavorable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_OrderFavorable(");
			strSql.Append("sid,fmoney,remark,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@fmoney,@remark,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fmoney", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.fmoney;
			parameters[2].Value = model.remark;
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
		public bool Update( B_OrderFavorable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_OrderFavorable set ");
			strSql.Append("fmoney=@fmoney,");
			strSql.Append("remark=@remark,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@fmoney", SqlDbType.Decimal,9),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.fmoney;
			parameters[1].Value = model.remark;
			parameters[2].Value = model.maker;
			parameters[3].Value = model.cdate;
			parameters[4].Value = model.sid;

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
            strSql.AppendFormat("delete from B_OrderFavorable where 1=1 {0}", where);
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
		public  B_OrderFavorable Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,fmoney,remark,maker,cdate from B_OrderFavorable ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_OrderFavorable r = new B_OrderFavorable();
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
		public  B_OrderFavorable DataRowToModel(DataRow row)
		{
			 B_OrderFavorable model=new  B_OrderFavorable();
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
				if(row["fmoney"]!=null && row["fmoney"].ToString()!="")
				{
					model.fmoney=decimal.Parse(row["fmoney"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
        public List<B_OrderFavorable> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,fmoney,remark,maker,cdate ");
			strSql.Append(" FROM B_OrderFavorable ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_OrderFavorable> r = new List<B_OrderFavorable>();
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
