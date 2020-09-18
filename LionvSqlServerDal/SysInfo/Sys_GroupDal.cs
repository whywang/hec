using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_GroupDal : ISys_GroupDal
    {
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gname)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Group");
            strSql.AppendFormat(" where gname='{0}' ", gname);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Group(");
			strSql.Append("gname,gcode,gdetail)");
			strSql.Append(" values (");
			strSql.Append("@gname,@gcode,@gdetail)");
			SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@gcode", SqlDbType.NVarChar,20),
					new SqlParameter("@gdetail", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.gname;
			parameters[1].Value = model.gcode;
			parameters[2].Value = model.gdetail;
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
		public bool Update( Sys_Group model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Group set ");
			strSql.Append("gname=@gname,");
			strSql.Append("gdetail=@gdetail");
			strSql.Append(" where gcode=@gcode ");
			SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@gdetail", SqlDbType.NVarChar,50),
					new SqlParameter("@gcode", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.gname;
			parameters[1].Value = model.gdetail;
			parameters[2].Value = model.gcode;
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
		public bool Delete(string gcode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Group ");
			strSql.Append(" where gcode=@gcode ");
			SqlParameter[] parameters = {
					new SqlParameter("@gcode", SqlDbType.NVarChar,20)			};
			parameters[0].Value = gcode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_Group Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,gname,gcode,gdetail from Sys_Group ");
			strSql.AppendFormat(" where 1=1 {0} ",where);
            Sys_Group r=new Sys_Group();
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
		public  Sys_Group DataRowToModel(DataRow row)
		{
			 Sys_Group model=new Sys_Group();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["gname"]!=null)
				{
					model.gname=row["gname"].ToString();
				}
				if(row["gcode"]!=null)
				{
					model.gcode=row["gcode"].ToString();
				}
				if(row["gdetail"]!=null)
				{
					model.gdetail=row["gdetail"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Group> QueryList(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,gname,gcode,gdetail ");
			strSql.AppendFormat(" FROM Sys_Group where 1=1 {0} ",where);
            List<Sys_Group> r = new List<Sys_Group>();
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
            sql = "select isnull(max(convert(int,gcode)),0) as n from Sys_Group ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetGroupAccount(DataTable dt)
        {
            int n = 0;
            StringBuilder strSql = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string sql = string.Format("insert into Sys_RGroupUser (gcode,uname) values ('{0}','{1}');", dr[0].ToString(), dr[1].ToString());
                strSql.Append(sql);
            }
            if (strSql.ToString() != "")
            {
                n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, strSql);
            }
            return n;
        }
        public int DelGroupAccount(string gcode)
        {
            int n = 0; ;
            string sql = "delete from Sys_RGroupUser where gcode='" +gcode + "' ";
            n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            return n;
        }
        public string GetGroupAccount(string gcode)
        {
            string menuv = "";
            string sql = "select  uname from Sys_RGroupUser where gcode='" + gcode + "' ";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    menuv += ";" + dr["uname"].ToString();
                }
            }
            return menuv;
        }

        public int SetGroupMenu(DataTable dt)
        {
            int n = 0;
            StringBuilder strSql = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string sql = string.Format("insert into Sys_RGroupMenu (gcode,mcode) values ('{0}','{1}');", dr[0].ToString(), dr[1].ToString());
                strSql.Append(sql);
            }
            if (strSql.ToString() != "")
            {
                n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, strSql);
            }
            return n;
        }
        public int DelGroupMenu(string gcode)
        {
            int n = 0; ;
            string sql = "delete from Sys_RGroupMenu where gcode='" + gcode + "' ";
            n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            return n;
        }
        public string GetGroupMenu(string gcode)
        {
            string menuv = "";
            string sql = "select  mcode from Sys_RGroupMenu where gcode='" + gcode + "' ";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    menuv += ";" + dr["mcode"].ToString();
                }
            }
            return menuv;
        }
		#endregion  ExtensionMethod
    }
}
