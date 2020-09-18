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
   public class CB_SendAddressDal:ICB_SendAddressDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CB_SendAddress");
			strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( CB_SendAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CB_SendAddress(");
			strSql.Append("sid,address,cperson,telephone,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@address,@cperson,@telephone,@maker,@cdate)");
	
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@cperson", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.address;
			parameters[2].Value = model.cperson;
			parameters[3].Value = model.telephone;
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
		public bool Update( CB_SendAddress model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CB_SendAddress set ");
			strSql.Append("sid=@sid,");
			strSql.Append("address=@address,");
			strSql.Append("cperson=@cperson,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@cperson", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.address;
			parameters[2].Value = model.cperson;
			parameters[3].Value = model.telephone;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;
			parameters[6].Value = model.id;

			int rows=SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Delete(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CB_SendAddress ");
			strSql.AppendFormat(" where id={0}  ", id);
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
		public  CB_SendAddress Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,address,cperson,telephone,maker,cdate from CB_SendAddress ");
			strSql.AppendFormat(" where 1=1 {0}", where);
            CB_SendAddress r = new CB_SendAddress();
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
		public  CB_SendAddress DataRowToModel(DataRow row)
		{
			 CB_SendAddress model=new  CB_SendAddress();
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
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["cperson"]!=null)
				{
					model.cperson=row["cperson"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
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
		public List<CB_SendAddress> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,address,cperson,telephone,maker,cdate ");
			strSql.Append(" FROM CB_SendAddress ");
			List<CB_SendAddress> r = new List<CB_SendAddress>();
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
