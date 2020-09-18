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
   public  class Sys_MsCzDal:ISys_MsCzDal
	{
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_MsCz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_MsCz(");
			strSql.Append("czname,czcode)");
			strSql.Append(" values (");
			strSql.Append("@czname,@czcode)");
			SqlParameter[] parameters = {
					new SqlParameter("@czname", SqlDbType.NVarChar,30),
					new SqlParameter("@czcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.czname;
			parameters[1].Value = model.czcode;

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
		public bool Update(Sys_MsCz model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_MsCz set ");
			strSql.Append("czname=@czname");
            strSql.Append(" where czcode=@czcode");
			SqlParameter[] parameters = {
					new SqlParameter("@czname", SqlDbType.NVarChar,30),
					new SqlParameter("@czcode", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.czname;
			parameters[1].Value = model.czcode;

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
		public bool Delete(string czcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_MsCz ");
			strSql.Append(" where czcode=@czcode ");
			SqlParameter[] parameters = {
					new SqlParameter("@czcode", SqlDbType.NVarChar,30)			};
			parameters[0].Value = czcode;

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
		/// 得到一个对象实体
		/// </summary>
		public Sys_MsCz Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,czname,czcode from Sys_MsCz ");
			strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_MsCz r = new Sys_MsCz();
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
		public Sys_MsCz DataRowToModel(DataRow row)
		{
			Sys_MsCz model=new Sys_MsCz();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["czname"]!=null)
				{
					model.czname=row["czname"].ToString();
				}
				if(row["czcode"]!=null)
				{
					model.czcode=row["czcode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_MsCz> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,czname,czcode ");
			strSql.Append(" FROM Sys_MsCz ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_MsCz> r = new List<Sys_MsCz>();
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
            sql = "select isnull(max(czcode),0) as n from Sys_MsCz ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetMsCz(string icode, string czcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryMsCz ");
            strSql.AppendFormat(" where icode='{0}';", icode);
            strSql.Append("insert into  Sys_RInventoryMsCz ");
            strSql.AppendFormat(" (icode,czcode) values ('{0}','{1}') ;", icode, czcode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReSetMsCz(string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryMsCz ");
            strSql.AppendFormat(" where icode='{0}';", icode);

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetMsCz(string icode)
        {
            string r = "";
            r = LoodQuery(icode);
            return r;
        }
        private string LoodQuery(string icode)
        {
            string p = "";
            if (icode.Length >8)
            {
                string sql = "select czcode from Sys_RInventoryMsCz where icode='" + icode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(icode.Substring(0, icode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
		#endregion  ExtensionMethod
	}
}
