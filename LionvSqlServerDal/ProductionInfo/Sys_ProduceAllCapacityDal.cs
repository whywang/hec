using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProduceAllCapacityDal : ISys_ProduceAllCapacityDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProduceAllCapacity");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ProduceAllCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProduceAllCapacity(");
			strSql.Append("dname,dcode,cnum,alnum,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@dname,@dcode,@cnum,@alnum,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@alnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.cnum;
			parameters[3].Value = model.alnum;
			parameters[4].Value = model.maker;
			parameters[5].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Update( Sys_ProduceAllCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProduceAllCapacity set ");
			strSql.Append("dname=@dname,");
			strSql.Append("cnum=@cnum,");
			strSql.Append("alnum=@alnum,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where dcode=@dcode");
			SqlParameter[] parameters = {
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@alnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode",  SqlDbType.NVarChar,50)};
			parameters[0].Value = model.dname;
			parameters[1].Value = model.cnum;
			parameters[2].Value = model.alnum;
			parameters[3].Value = model.maker;
			parameters[4].Value = model.cdate;
            parameters[5].Value = model.dcode;
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);
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
			strSql.Append("delete from Sys_ProduceAllCapacity ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProduceAllCapacity Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,dname,dcode,cnum,alnum,maker,cdate from Sys_ProduceAllCapacity ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProduceAllCapacity r = new Sys_ProduceAllCapacity();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
		public  Sys_ProduceAllCapacity DataRowToModel(DataRow row)
		{
			 Sys_ProduceAllCapacity model=new  Sys_ProduceAllCapacity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["cnum"]!=null && row["cnum"].ToString()!="")
				{
					model.cnum=int.Parse(row["cnum"].ToString());
				}
				if(row["alnum"]!=null && row["alnum"].ToString()!="")
				{
					model.alnum=int.Parse(row["alnum"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProduceAllCapacity> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,dname,dcode,cnum,alnum,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ProduceAllCapacity where 1=1 {0}", strWhere);
            List<Sys_ProduceAllCapacity> r = new List<Sys_ProduceAllCapacity>();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
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
