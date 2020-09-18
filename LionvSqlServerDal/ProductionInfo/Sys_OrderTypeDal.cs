using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvModel.SysInfo;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_OrderTypeDal : ISys_OrderTypeDal
    {
     
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_OrderType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_OrderType model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_OrderType(");
            strSql.Append("tname,tcode,emname,emcode,tread,ttype,dcode,maker,cdate,tsource)");
            strSql.Append(" values (");
            strSql.Append("@tname,@tcode,@emname,@emcode,@tread,@ttype,@dcode,@maker,@cdate,@tsource)");
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,20),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tread", SqlDbType.Bit,1),
					new SqlParameter("@ttype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@tsource", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.tname;
            parameters[1].Value = model.tcode;
            parameters[2].Value = model.emname;
            parameters[3].Value = model.emcode;
            parameters[4].Value = model.tread;
            parameters[5].Value = model.ttype;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.tsource;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters);

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
		public bool Update( Sys_OrderType model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_OrderType set ");
            strSql.Append("tname=@tname,");
            strSql.Append("emname=@emname,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("tread=@tread,");
            strSql.Append("ttype=@ttype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("tsource=@tsource");
            strSql.Append(" where tcode=@tcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tread", SqlDbType.Bit,1),
					new SqlParameter("@ttype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@tsource", SqlDbType.NVarChar,20), 
					new SqlParameter("@tcode", SqlDbType.NVarChar,20)
                                       };
            parameters[0].Value = model.tname;
            parameters[1].Value = model.emname;
            parameters[2].Value = model.emcode;
            parameters[3].Value = model.tread;
            parameters[4].Value = model.ttype;
            parameters[5].Value = model.dcode;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.tsource;
            parameters[9].Value = model.tcode;
            bool r = false;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
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
			strSql.Append("delete from Sys_OrderType ");
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
		public Sys_OrderType Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,tname,tcode,emname,emcode,tread,ttype,dcode,maker,cdate,tsource from Sys_OrderType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
	 
             Sys_OrderType r=new  Sys_OrderType();
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
		public Sys_OrderType DataRowToModel(DataRow row)
		{
			 Sys_OrderType model=new Sys_OrderType();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["tname"]!=null)
				{
					model.tname=row["tname"].ToString();
				}
				if(row["tcode"]!=null)
				{
					model.tcode=row["tcode"].ToString();
				}
				if(row["emname"]!=null)
				{
					model.emname=row["emname"].ToString();
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["tread"] != null && row["tread"].ToString() != "")
                {
                    if ((row["tread"].ToString() == "1") || (row["tread"].ToString().ToLower() == "true"))
                    {
                        model.tread = true;
                    }
                    else
                    {
                        model.tread = false;
                    }
                }
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["tsource"] != null)
                {
                    model.tsource = row["tsource"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_OrderType> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,tname,tcode,emname,emcode,tread,ttype,dcode,maker,cdate ,tsource  ");
            strSql.AppendFormat(" FROM Sys_OrderType where 1=1 {0}", where);
            List<Sys_OrderType> r = new List<Sys_OrderType>();
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
            string sql = "select isnull(max(convert(int,tcode)),0) as n from Sys_OrderType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
		#endregion  ExtensionMethod
    }
}
