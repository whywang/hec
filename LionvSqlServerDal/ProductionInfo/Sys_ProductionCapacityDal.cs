using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LionvModel.ProductionInfo;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionCapacityDal : ISys_ProductionCapacityDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_ProductionCapacity");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_ProductionCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_ProductionCapacity(");
			strSql.Append("cccode,ccname,dcode,dname,lcode,lname,cnum,cdate)");
			strSql.Append(" values (");
			strSql.Append("@cccode,@ccname,@dcode,@dname,@lcode,@lname,@cnum,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@cccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.cccode;
			parameters[1].Value = model.ccname;
			parameters[2].Value = model.dcode;
			parameters[3].Value = model.dname;
			parameters[4].Value = model.lcode;
			parameters[5].Value = model.lname;
			parameters[6].Value = model.cnum;
			parameters[7].Value = model.cdate;

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
		public bool Update( Sys_ProductionCapacity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_ProductionCapacity set ");
			strSql.Append("ccname=@ccname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("dname=@dname,");
			strSql.Append("lcode=@lcode,");
			strSql.Append("lname=@lname,");
			strSql.Append("cnum=@cnum,");
			strSql.Append("cdate=@cdate");
            strSql.Append(" where cccode=@cccode");
			SqlParameter[] parameters = {
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@cnum", SqlDbType.Int,4),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@cccode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.ccname;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.dname;
			parameters[3].Value = model.lcode;
			parameters[4].Value = model.lname;
			parameters[5].Value = model.cnum;
			parameters[6].Value = model.cdate;
			parameters[7].Value = model.cccode;

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
			strSql.Append("delete from Sys_ProductionCapacity ");
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
		public  Sys_ProductionCapacity Query(string id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,cccode,ccname,dcode,dname,lcode,lname,cnum,cdate from Sys_ProductionCapacity ");
            strSql.AppendFormat(" where 1=1 {0}", id);
            Sys_ProductionCapacity r = new Sys_ProductionCapacity();
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
		public  Sys_ProductionCapacity DataRowToModel(DataRow row)
		{
			 Sys_ProductionCapacity model=new  Sys_ProductionCapacity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["cccode"]!=null)
				{
					model.cccode=row["cccode"].ToString();
				}
				if(row["ccname"]!=null)
				{
					model.ccname=row["ccname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["lcode"]!=null)
				{
					model.lcode=row["lcode"].ToString();
				}
				if(row["lname"]!=null)
				{
					model.lname=row["lname"].ToString();
				}
				if(row["cnum"]!=null && row["cnum"].ToString()!="")
				{
					model.cnum=int.Parse(row["cnum"].ToString());
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
        public List<Sys_ProductionCapacity> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,cccode,ccname,dcode,dname,lcode,lname,cnum,cdate ");
 
            strSql.AppendFormat(" FROM Sys_ProductionCapacity where 1=1 {0}", strWhere);
            List<Sys_ProductionCapacity> r = new List<Sys_ProductionCapacity>();
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
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,cccode)),0) as n from Sys_ProductionCapacity ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
