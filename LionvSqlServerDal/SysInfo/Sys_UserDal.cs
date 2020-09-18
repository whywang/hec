using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using LionvIDal.SysInfo;
using LionvCommonDal;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_UserDal : ISys_UserDal
    {
        public Sys_UserDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User(");
			strSql.Append("uname,upass,eno,ulogin,uip,ulogintime)");
			strSql.Append(" values (");
			strSql.Append("@uname,@upass,@eno,@ulogin,@uip,@ulogintime)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@uname", SqlDbType.NVarChar,30),
					new SqlParameter("@upass", SqlDbType.NVarChar,15),
					new SqlParameter("@eno", SqlDbType.NVarChar,50),
					new SqlParameter("@ulogin", SqlDbType.Bit,1),
					new SqlParameter("@uip", SqlDbType.NVarChar,50),
					new SqlParameter("@ulogintime", SqlDbType.DateTime)};
			parameters[0].Value = model.uname;
			parameters[1].Value = model.upass;
			parameters[2].Value = model.eno;
			parameters[3].Value = model.ulogin;
			parameters[4].Value = model.uip;
			parameters[5].Value = model.ulogintime;
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
		public bool Update( Sys_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User set ");
			strSql.Append("upass=@upass,");
			strSql.Append("eno=@eno,");
			strSql.Append("ulogin=@ulogin,");
			strSql.Append("uip=@uip,");
			strSql.Append("ulogintime=@ulogintime");
            strSql.Append(" where uname=@uname");
			SqlParameter[] parameters = {
					new SqlParameter("@upass", SqlDbType.NVarChar,15),
					new SqlParameter("@eno", SqlDbType.NVarChar,50),
					new SqlParameter("@ulogin", SqlDbType.Bit,1),
					new SqlParameter("@uip", SqlDbType.NVarChar,50),
					new SqlParameter("@ulogintime", SqlDbType.DateTime),
					new SqlParameter("@uname", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.upass;
			parameters[1].Value = model.eno;
			parameters[2].Value = model.ulogin;
			parameters[3].Value = model.uip;
			parameters[4].Value = model.ulogintime;
			parameters[5].Value = model.uname;
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
			strSql.Append("delete from Sys_User ");
            strSql.AppendFormat(" where  1=1 {0}", where);
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
		public Sys_User Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,uname,upass,eno,ulogin,uip,ulogintime from Sys_User ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_User r = new Sys_User();
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
		public Sys_User DataRowToModel(DataRow row)
		{
			 Sys_User model=new  Sys_User();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["uname"]!=null)
				{
					model.uname=row["uname"].ToString();
				}
				if(row["upass"]!=null)
				{
					model.upass=row["upass"].ToString();
				}
				if(row["eno"]!=null)
				{
					model.eno=row["eno"].ToString();
				}
				if(row["ulogin"]!=null && row["ulogin"].ToString()!="")
				{
					if((row["ulogin"].ToString()=="1")||(row["ulogin"].ToString().ToLower()=="true"))
					{
						model.ulogin=true;
					}
					else
					{
						model.ulogin=false;
					}
				}
				if(row["uip"]!=null)
				{
					model.uip=row["uip"].ToString();
				}
				if(row["ulogintime"]!=null && row["ulogintime"].ToString()!="")
				{
					model.ulogintime= row["ulogintime"].ToString() ;
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_User> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,uname,upass,eno,ulogin,uip,ulogintime from Sys_User");
            strSql.AppendFormat(" where  1=1 {0}", strWhere);
            List<Sys_User> r = new List<Sys_User>();
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
        public DataTable QueryTable(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BasePage("v_user_employee", "*", sort, "", pagesize, curpage, ref rcount, ref pcount);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
        public int ReSetPass(string id ,string mm)
        {
            string sql = " update Sys_User set upass='"+mm+"' where eno='" + id + "'";
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
        public int RePersonSetPass(string eno, string mm)
        {
            string sql = " update Sys_User set upass='" + mm + "' where eno='" + eno + "'";
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
        public int SetState(string id,string v)
        {
            string sql = " update Sys_User set ulogin='"+v+"' where eno='" + id + "'";
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
        public int SetEmployeeCity(string eno, string[] ptcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_REmployeeAgent where eno='{0}'; ",eno);
            for (int i = 0; i < ptcode.Length; i++)
            {
                sql.AppendFormat(" insert into  Sys_REmployeeAgent (eno,dcode) values ('{0}','{1}');", eno, ptcode[i]);
            }
            if (sql.ToString() != "")
            {
                try
                {
                    r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);

                }
                catch
                {
                    r = -1;
                }

            }
            else
            {
                r = -1;
            }
            return r;
        }
        public int ReSetEmployeeCity(string eno)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_REmployeeAgent where eno='{0}' ", eno);

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
        public string  GetEmployeeCity(string eno)
        {
            StringBuilder strSql = new StringBuilder();
            string  r = "";
            strSql.Append("select  * from Sys_REmployeeAgent");
            strSql.AppendFormat(" where  eno='{0}'", eno);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                   r=r+dr["dcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
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
