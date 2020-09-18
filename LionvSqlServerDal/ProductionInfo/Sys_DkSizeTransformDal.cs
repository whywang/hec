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
    public class Sys_DkSizeTransformDal : ISys_DkSizeTransformDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_DkSizeTransform");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_DkSizeTransform model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_DkSizeTransform(");
            strSql.Append("sfname,sfcode,ntdh,wtdh,ntdw,wtdw,bdcode,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sfname,@sfcode,@ntdh,@wtdh,@ntdw,@wtdw,@bdcode,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@sfname", SqlDbType.NVarChar,50),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ntdh", SqlDbType.NVarChar,100),
					new SqlParameter("@wtdh", SqlDbType.NVarChar,100),
					new SqlParameter("@ntdw", SqlDbType.NVarChar,100),
					new SqlParameter("@wtdw", SqlDbType.NVarChar,100),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sfname;
            parameters[1].Value = model.sfcode;
            parameters[2].Value = model.ntdh;
            parameters[3].Value = model.wtdh;
            parameters[4].Value = model.ntdw;
            parameters[5].Value = model.wtdw;
            parameters[6].Value = model.bdcode;
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
		public bool Update( Sys_DkSizeTransform model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_DkSizeTransform set ");
            strSql.Append("sfname=@sfname,");
            strSql.Append("ntdh=@ntdh,");
            strSql.Append("wtdh=@wtdh,");
            strSql.Append("ntdw=@ntdw,");
            strSql.Append("wtdw=@wtdw,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sfcode=@sfcode");
            SqlParameter[] parameters = {
					new SqlParameter("@sfname", SqlDbType.NVarChar,50),
					new SqlParameter("@ntdh", SqlDbType.NVarChar,100),
					new SqlParameter("@wtdh", SqlDbType.NVarChar,100),
					new SqlParameter("@ntdw", SqlDbType.NVarChar,100),
					new SqlParameter("@wtdw", SqlDbType.NVarChar,100),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sfcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sfname;
            parameters[1].Value = model.ntdh;
            parameters[2].Value = model.wtdh;
            parameters[3].Value = model.ntdw;
            parameters[4].Value = model.wtdw;
            parameters[5].Value = model.bdcode;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.sfcode;

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
		public bool Delete(string sfcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_DkSizeTransform ");
            strSql.AppendFormat(" where sfcode='{0}' ", sfcode);
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
        public Sys_DkSizeTransform Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sfname,sfcode,ntdh,wtdh,ntdw,wtdw,bdcode,cdate from Sys_DkSizeTransform ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_DkSizeTransform r = new Sys_DkSizeTransform();
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
		public  Sys_DkSizeTransform DataRowToModel(DataRow row)
		{
			 Sys_DkSizeTransform model=new  Sys_DkSizeTransform();
			if (row != null)
			{
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sfname"] != null)
                {
                    model.sfname = row["sfname"].ToString();
                }
                if (row["sfcode"] != null)
                {
                    model.sfcode = row["sfcode"].ToString();
                }
                if (row["ntdh"] != null)
                {
                    model.ntdh = row["ntdh"].ToString();
                }
                if (row["wtdh"] != null)
                {
                    model.wtdh = row["wtdh"].ToString();
                }
                if (row["ntdw"] != null)
                {
                    model.ntdw = row["ntdw"].ToString();
                }
                if (row["wtdw"] != null)
                {
                    model.wtdw = row["wtdw"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_DkSizeTransform> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sfname,sfcode,ntdh,wtdh,ntdw,wtdw,bdcode,cdate ");
            strSql.AppendFormat(" FROM Sys_DkSizeTransform where 1=1 {0}", strWhere);
            List<Sys_DkSizeTransform> r = new List<Sys_DkSizeTransform>();
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
            sql = "select isnull(max(convert(int,sfcode)),0) as n from Sys_DkSizeTransform ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetRDsize(string icode, string sfcode)
        {

            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryDsize where icode ='{0}';", icode);
            sql.AppendFormat(" insert into Sys_RInventoryDsize (icode,sfcode) values ('{0}','{1}') ;", icode, sfcode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetRDsize(string icode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryDsize where icode ='{0}';", icode);
            int r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
            if (r > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetRDsize(string icode)
        {
            string r = "";
            string sql = "select sfcode from Sys_RInventoryDsize where icode='" + icode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                r = dt.Rows[0]["sfcode"].ToString();
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
