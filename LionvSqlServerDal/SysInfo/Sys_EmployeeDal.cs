using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvModel.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    class Sys_EmployeeDal : ISys_EmployeeDal
    {
        public Sys_EmployeeDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Employee");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( Sys_Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Employee(");
			strSql.Append(" ename,eno,dcode,dname,estate,dtcode,elogin,ecdate,emaker,rcode)");
			strSql.Append(" values (");
			strSql.Append(" @ename,@eno,@dcode,@dname,@estate,@dtcode,@elogin,@ecdate,@emaker,@rcode)");
			SqlParameter[] parameters = {
	 
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@eno", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@estate", SqlDbType.Bit,1),
					new SqlParameter("@dtcode", SqlDbType.NVarChar,20),
					new SqlParameter("@elogin", SqlDbType.Bit,1),
					new SqlParameter("@ecdate", SqlDbType.DateTime),
					new SqlParameter("@emaker", SqlDbType.NVarChar,50),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.ename;
			parameters[1].Value = model.eno;
			parameters[2].Value = model.dcode;
			parameters[3].Value = model.dname;
			parameters[4].Value = model.estate;
			parameters[5].Value = model.dtcode;
			parameters[6].Value = model.elogin;
			parameters[7].Value = model.ecdate;
			parameters[8].Value = model.emaker;
			parameters[9].Value = model.rcode;

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
		public bool Update( Sys_Employee model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Employee set ");
			strSql.Append("ename=@ename,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("dname=@dname,");
			strSql.Append("estate=@estate,");
			strSql.Append("dtcode=@dtcode,");
			strSql.Append("elogin=@elogin,");
			strSql.Append("ecdate=@ecdate,");
			strSql.Append("emaker=@emaker,");
			strSql.Append("rcode=@rcode");
			strSql.Append(" where eno=@eno ");
			SqlParameter[] parameters = {
 
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@dname", SqlDbType.NVarChar,50),
					new SqlParameter("@estate", SqlDbType.Bit,1),
					new SqlParameter("@dtcode", SqlDbType.NVarChar,20),
					new SqlParameter("@elogin", SqlDbType.Bit,1),
					new SqlParameter("@ecdate", SqlDbType.DateTime),
					new SqlParameter("@emaker", SqlDbType.NVarChar,50),
					new SqlParameter("@rcode", SqlDbType.NVarChar,20),
					new SqlParameter("@eno", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.ename;
			parameters[1].Value = model.dcode;
			parameters[2].Value = model.dname;
			parameters[3].Value = model.estate;
			parameters[4].Value = model.dtcode;
			parameters[5].Value = model.elogin;
			parameters[6].Value = model.ecdate;
			parameters[7].Value = model.emaker;
			parameters[8].Value = model.rcode;
			parameters[9].Value = model.eno;
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
			strSql.Append("delete from Sys_Employee ");
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
		public  Sys_Employee Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,ename,eno,dcode,dname,estate,dtcode,elogin,ecdate,emaker,rcode from Sys_Employee ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Employee r = new Sys_Employee();
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
		public Sys_Employee DataRowToModel(DataRow row)
		{
			 Sys_Employee model=new  Sys_Employee();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["ename"]!=null)
				{
					model.ename=row["ename"].ToString();
				}
				if(row["eno"]!=null)
				{
					model.eno=row["eno"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["estate"]!=null && row["estate"].ToString()!="")
				{
					if((row["estate"].ToString()=="1")||(row["estate"].ToString().ToLower()=="true"))
					{
						model.estate=true;
					}
					else
					{
						model.estate=false;
					}
				}
				if(row["dtcode"]!=null)
				{
					model.dtcode=row["dtcode"].ToString();
				}
				if(row["elogin"]!=null && row["elogin"].ToString()!="")
				{
					if((row["elogin"].ToString()=="1")||(row["elogin"].ToString().ToLower()=="true"))
					{
						model.elogin=true;
					}
					else
					{
						model.elogin=false;
					}
				}
				if(row["ecdate"]!=null && row["ecdate"].ToString()!="")
				{
					model.ecdate= row["ecdate"].ToString() ;
				}
				if(row["emaker"]!=null)
				{
					model.emaker=row["emaker"].ToString();
				}
				if(row["rcode"]!=null)
				{
					model.rcode=row["rcode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_Employee> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,ename,eno,dcode,dname,estate,dtcode,elogin,ecdate,emaker,rcode ");
            strSql.AppendFormat(" FROM Sys_Employee where 1=1 {0}", strWhere);
            List<Sys_Employee> r = new List<Sys_Employee>();
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
        public int AddList(Sys_Employee se,Sys_EmployeeDpt sed,Sys_User su)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from  Sys_User where eno='"+se.eno+"';");
            strSql.Append("insert into Sys_Employee(");
            strSql.Append(" ename,eno,dcode,dname,estate,dtcode,elogin,ecdate,emaker,rcode)");
            strSql.Append(" values (");
            strSql.AppendFormat(" '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');"
                ,se.ename,se.eno,se.dcode,se.dname,se.estate,se.dtcode,se.elogin,se.ecdate,se.emaker,se.rcode);

            strSql.Append("insert into Sys_EmployeeDpt(");
            strSql.Append("eno,eage,esex,etelephone,eaddress,eidentity,eeducation,enativeplace,eheadimage,eworkdate,eemail)");
            strSql.Append(" values (");
            strSql.AppendFormat("'{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
               sed.eno,sed.eage,sed.esex ,sed.etelephone,sed.eaddress,sed.eidentity,sed.eeducation,sed.enativeplace,sed.eheadimage,sed.eworkdate,sed.eemail);
            if (su != null)
            {
                strSql.Append("insert into Sys_User(");
                strSql.Append("uname,upass,eno,ulogin,uip,ulogintime)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}');" ,
                su.uname, su.upass, su.eno, su.ulogin, su.uip, su.ulogintime);
            }
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);

            }
            catch
            {
                r = -1;
            }
            return r;
        }
        public int UpdateList(string eno, Sys_Employee se, Sys_EmployeeDpt sed, Sys_User su)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Sys_Employee set ");
            strSql.AppendFormat("ename='{0}',",se.ename);
            strSql.AppendFormat("dcode='{0}',",se.dcode);
            strSql.AppendFormat("dname='{0}',",se.dname);
            strSql.AppendFormat("estate='{0}',",se.estate);
            strSql.AppendFormat("dtcode='{0}',",se.dtcode);
            strSql.AppendFormat("elogin='{0}',",se.elogin);
            strSql.AppendFormat("ecdate='{0}',",se.ecdate);
            strSql.AppendFormat("emaker='{0}',",se.emaker);
            strSql.AppendFormat("rcode='{0}',",se.rcode);
            strSql.AppendFormat("eno='{0}'",se.eno);
            strSql.AppendFormat(" where eno='{0}'; ", eno);

            strSql.AppendFormat("update Sys_EmployeeDpt set ");
            strSql.AppendFormat("eno='{0}',",sed.eno);
            strSql.AppendFormat("eage={0},",sed.eage);
            strSql.AppendFormat("esex='{0}',",sed.esex);
            strSql.AppendFormat("etelephone='{0}',",sed.etelephone);
            strSql.AppendFormat("eaddress='{0}',",sed.eaddress);
            strSql.AppendFormat("eidentity='{0}',",sed.eidentity);
            strSql.AppendFormat("eeducation='{0}',",sed.eeducation);
            strSql.AppendFormat("enativeplace='{0}',",sed.enativeplace);
            strSql.AppendFormat("eheadimage='{0}',",sed.eheadimage);
            strSql.AppendFormat("eworkdate='{0}',",sed.eworkdate);
            strSql.AppendFormat("eemail='{0}'",sed.eemail);
            strSql.AppendFormat(" where eno='{0}';", eno);

            strSql.AppendFormat("delete from Sys_User where eno='{0}';", su.eno);
            if (su != null)
            {
                strSql.Append("insert into Sys_User(");
                strSql.Append("uname,upass,eno,ulogin,uip,ulogintime)");
                strSql.Append(" values (");
                strSql.AppendFormat("'{0}','{1}','{2}','{3}','{4}','{5}');",
                su.uname, su.upass, su.eno, su.ulogin, su.uip, su.ulogintime);
            }
           
          
            int r = 0;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r =1  ;
            }
            return r;
        }
        public int GetEno()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,substring(eno,2,len(eno)-1))),0) as n from Sys_Employee where eno<>'admin'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public DataTable QueryEmploy(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_SysDepEmploy ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            return dt;
        }
		#endregion  ExtensionMethod
    }
}
