using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using LionvCommonDal;

namespace LionvSqlServerDal.SysInfo
{
    class Sys_UnitDal:ISys_UnitDal
	{
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Unit");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Unit model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_Unit(");
            strSql.Append("uname,ucode,utype,uread,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@uname,@ucode,@utype,@uread,@dcode,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,2),
					new SqlParameter("@ucode", SqlDbType.NVarChar,4),
					new SqlParameter("@utype", SqlDbType.NVarChar,30),
					new SqlParameter("@uread", SqlDbType.Bit,1),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.uname;
            parameters[1].Value = model.ucode;
            parameters[2].Value = model.utype;
            parameters[3].Value = model.uread;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
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
		public bool Update(Sys_Unit model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_Unit set ");
            strSql.Append("uname=@uname,");
            strSql.Append("utype=@utype,");
            strSql.Append("uread=@uread,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ucode=@ucode");
            SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,2),
					new SqlParameter("@utype", SqlDbType.NVarChar,30),
					new SqlParameter("@uread", SqlDbType.Bit,1),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ucode", SqlDbType.NVarChar,4)};
            parameters[0].Value = model.uname;
            parameters[1].Value = model.utype;
            parameters[2].Value = model.uread;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.ucode;
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
            strSql.AppendFormat("delete from Sys_Unit where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
 
	
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_Unit Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,uname,ucode,utype,uread,dcode,maker,cdate from Sys_Unit ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Unit r = new Sys_Unit();
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
		private Sys_Unit DataRowToModel(DataRow row)
		{
			 Sys_Unit model=new  Sys_Unit();
			if (row != null)
			{
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["uname"] != null)
                {
                    model.uname = row["uname"].ToString();
                }
                if (row["ucode"] != null)
                {
                    model.ucode = row["ucode"].ToString();
                }
                if (row["utype"] != null)
                {
                    model.utype = row["utype"].ToString();
                }
                if (row["uread"] != null && row["uread"].ToString() != "")
                {
                    if ((row["uread"].ToString() == "1") || (row["uread"].ToString().ToLower() == "true"))
                    {
                        model.uread = true;
                    }
                    else
                    {
                        model.uread = false;
                    }
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Unit> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,uname,ucode,utype,uread,dcode,maker,cdate  from Sys_Unit");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_Unit> r = new List<Sys_Unit>();
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

        public List<Sys_Unit> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            List<Sys_Unit> r = new List<Sys_Unit>();
            DataTable dt = new Fy().BasePage("Sys_Unit", "*", sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion
        #region  MethodEx
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,ucode)),0) as n from Sys_Unit ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  MethodEx
    }
}
