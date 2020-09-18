using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SettlementDal : ISys_SettlementDal
    {
		#region  BasicMethod

        public bool Exists(string sname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Settlement");
            strSql.AppendFormat(" where sname='{0}' ", sname);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Settlement model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_Settlement(");
            strSql.Append("scode,sname,stype,sread,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@scode,@sname,@stype,@sread,@dcode,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@scode", SqlDbType.NVarChar,20),
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@sread", SqlDbType.Bit,1),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.scode;
            parameters[1].Value = model.sname;
            parameters[2].Value = model.stype;
            parameters[3].Value = model.sread;
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
		public bool Update(Sys_Settlement model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_Settlement set ");
            strSql.Append("sname=@sname,");
            strSql.Append("stype=@stype,");
            strSql.Append("sread=@sread,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where scode=@scode");
            SqlParameter[] parameters = {
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@stype", SqlDbType.NVarChar,10),
					new SqlParameter("@sread", SqlDbType.Bit,1),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@scode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sname;
            parameters[1].Value = model.stype;
            parameters[2].Value = model.sread;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.scode;
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
		public bool Delete(string scode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Settlement ");
            strSql.AppendFormat(" where 1=1 and scode='{0}'", scode);
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
		public Sys_Settlement Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,scode,sname,stype,sread,dcode,maker,cdate from Sys_Settlement ");
			strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_Settlement r = new Sys_Settlement();
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
		public Sys_Settlement DataRowToModel(DataRow row)
		{
			Sys_Settlement model=new Sys_Settlement();
			if (row != null)
			{
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["sread"] != null && row["sread"].ToString() != "")
                {
                    if ((row["sread"].ToString() == "1") || (row["sread"].ToString().ToLower() == "true"))
                    {
                        model.sread = true;
                    }
                    else
                    {
                        model.sread = false;
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
        public List<Sys_Settlement> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,scode,sname,stype,sread,dcode,maker,cdate  ");
            strSql.AppendFormat(" FROM Sys_Settlement where 1=1 {0}", strWhere);
            List<Sys_Settlement> r = new List<Sys_Settlement>();
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
            string sql = "select isnull(max(convert(int,scode)),0) as n from Sys_Settlement ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetSettlemnt(string depcode, string scode)
        {
            StringBuilder sql=new StringBuilder ();
            sql.AppendFormat(" delete from Sys_RSettlementDepment where dcode='{0}';",depcode);
            sql.AppendFormat(" insert into Sys_RSettlementDepment ( dcode,scode) values ('{0}','{1}')", depcode, scode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int ReSetSettlemnt(string depcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RSettlementDepment where dcode='{0}';", depcode);
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public string GetSettlemnt(string depcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  scode  from Sys_RSettlementDepment ");
            strSql.AppendFormat(" where dcode='{0}'", depcode);
 
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r =  dt.Rows[0][0].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
