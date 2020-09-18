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
   public class Sys_HingeIntervalDal:ISys_HingeIntervalDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_HingeInterval");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_HingeInterval model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_HingeInterval(");
			strSql.Append("hname,hcode,lv,tv,iv)");
			strSql.Append(" values (");
			strSql.Append("@hname,@hcode,@lv,@tv,@iv)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@hname", SqlDbType.NVarChar,30),
					new SqlParameter("@hcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@tv", SqlDbType.Int,4),
					new SqlParameter("@iv", SqlDbType.Int,4)};
			parameters[0].Value = model.hname;
			parameters[1].Value = model.hcode;
			parameters[2].Value = model.lv;
			parameters[3].Value = model.tv;
			parameters[4].Value = model.iv;

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
		public bool Update( Sys_HingeInterval model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_HingeInterval set ");
			strSql.Append("hname=@hname,");
			strSql.Append("lv=@lv,");
			strSql.Append("tv=@tv,");
			strSql.Append("iv=@iv");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@hname", SqlDbType.NVarChar,30),
					new SqlParameter("@lv", SqlDbType.Int,4),
					new SqlParameter("@tv", SqlDbType.Int,4),
					new SqlParameter("@iv", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@hcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.hname;
			parameters[1].Value = model.lv;
			parameters[2].Value = model.tv;
			parameters[3].Value = model.iv;
			parameters[4].Value = model.id;
			parameters[5].Value = model.hcode;

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
		public bool Delete(string hcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_HingeInterval ");
            strSql.AppendFormat(" where hcode='{0}' ", hcode);
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
		public  Sys_HingeInterval Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,hname,hcode,lv,tv,iv from Sys_HingeInterval ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_HingeInterval r = new Sys_HingeInterval();
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
		public  Sys_HingeInterval DataRowToModel(DataRow row)
		{
			 Sys_HingeInterval model=new  Sys_HingeInterval();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["hname"]!=null)
				{
					model.hname=row["hname"].ToString();
				}
				if(row["hcode"]!=null)
				{
					model.hcode=row["hcode"].ToString();
				}
				if(row["lv"]!=null && row["lv"].ToString()!="")
				{
					model.lv=int.Parse(row["lv"].ToString());
				}
				if(row["tv"]!=null && row["tv"].ToString()!="")
				{
					model.tv=int.Parse(row["tv"].ToString());
				}
				if(row["iv"]!=null && row["iv"].ToString()!="")
				{
					model.iv=int.Parse(row["iv"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_HingeInterval> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,hname,hcode,lv,tv,iv ");
            strSql.AppendFormat(" FROM Sys_HingeInterval where 1=1 {0}", strWhere);
            List<Sys_HingeInterval> r = new List<Sys_HingeInterval>();
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
            sql = "select isnull(max(convert(int,hcode)),0) as n from Sys_HingeInterval ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        
		#endregion  ExtensionMethod
    }
}
