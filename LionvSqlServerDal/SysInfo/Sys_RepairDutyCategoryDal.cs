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
    public class Sys_RepairDutyCategoryDal : ISys_RepairDutyCategoryDal
    {

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_RepairDutyCategory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
			
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Sys_RepairDutyCategory model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into Sys_RepairDutyCategory(");
            strSql.Append("rcname,rccode,rcpname,rcpcode,isend,rread,rtype,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@rcname,@rccode,@rcpname,@rcpcode,@isend,@rread,@rtype,@dcode,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@rcname", SqlDbType.NVarChar,30),
					new SqlParameter("@rccode", SqlDbType.NVarChar,10),
					new SqlParameter("@rcpname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcpcode", SqlDbType.NVarChar,10),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.rcname;
            parameters[1].Value = model.rccode;
            parameters[2].Value = model.rcpname;
            parameters[3].Value = model.rcpcode;
            parameters[4].Value = model.isend;
            parameters[5].Value = model.rread;
            parameters[6].Value = model.rtype;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            int r = 0;
            strSql.AppendFormat("update Sys_RepairDutyCategory set isend='false' where rccode ='{0}';",  model.rcpcode);
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
		public bool Update(Sys_RepairDutyCategory model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("update Sys_RepairDutyCategory set ");
            strSql.Append("rcname=@rcname,");
            strSql.Append("rcpname=@rcpname,");
            strSql.Append("rcpcode=@rcpcode,");
            strSql.Append("isend=@isend,");
            strSql.Append("rread=@rread,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rccode=@rccode;");
            SqlParameter[] parameters = {
					new SqlParameter("@rcname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcpname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcpcode", SqlDbType.NVarChar,10),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rccode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.rcname;
            parameters[1].Value = model.rcpname;
            parameters[2].Value = model.rcpcode;
            parameters[3].Value = model.isend;
            parameters[4].Value = model.rread;
            parameters[5].Value = model.rtype;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.rccode;
            bool r = false;
            strSql.AppendFormat("update Sys_RepairDutyCategory set rcpname='{0}' where rcpcode like '{1}%';",model.rcname,model.rccode);
            strSql.AppendFormat("update Sys_RepairDuty set rcname='{0}' where rccode='{1}';", model.rcname, model.rccode);
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string rccode)
		{
			
			StringBuilder strSql=new StringBuilder();
            StringBuilder strSqll=new StringBuilder();
			strSql.Append("delete from Sys_RepairDutyCategory ");
            strSql.AppendFormat(" where  rccode like '{0}%';", rccode);
            strSql.AppendFormat(" delete from Sys_RepairDuty where  rccode like '{0}%';", rccode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            if (rccode.Length > 2)
            {
                string pcode = rccode.Substring(0, rccode.Length - 2);
                if (!Exists(" and rcpcode='" + pcode + "'"))
                {
                    strSqll.AppendFormat(" update Sys_RepairDutyCategory set isend='true' where  rccode ='{0}';", pcode);
                    SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSqll.ToString(), null);
                }
            }
            return r;
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_RepairDutyCategory Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,rcname,rccode,rcpname,rcpcode,isend,rread,rtype,dcode,maker,cdate from Sys_RepairDutyCategory  ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RepairDutyCategory r = new Sys_RepairDutyCategory();
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
		public Sys_RepairDutyCategory DataRowToModel(DataRow row)
		{
			Sys_RepairDutyCategory model=new Sys_RepairDutyCategory();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["rcname"]!=null)
				{
					model.rcname=row["rcname"].ToString();
				}
				if(row["rccode"]!=null)
				{
					model.rccode=row["rccode"].ToString();
				}
				if(row["rcpname"]!=null)
				{
					model.rcpname=row["rcpname"].ToString();
				}
				if(row["rcpcode"]!=null)
				{
					model.rcpcode=row["rcpcode"].ToString();
				}
				if(row["isend"]!=null && row["isend"].ToString()!="")
				{
					if((row["isend"].ToString()=="1")||(row["isend"].ToString().ToLower()=="true"))
					{
						model.isend=true;
					}
					else
					{
						model.isend=false;
					}
				}
                if (row["rread"] != null && row["rread"].ToString() != "")
                {
                    if ((row["rread"].ToString() == "1") || (row["rread"].ToString().ToLower() == "true"))
                    {
                        model.rread = true;
                    }
                    else
                    {
                        model.rread = false;
                    }
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_RepairDutyCategory> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  id,rcname,rccode,rcpname,rcpcode,isend,rread,rtype,dcode,maker,cdate   ");
            strSql.AppendFormat(" FROM Sys_RepairDutyCategory where 1=1 {0}  ", strWhere);
            List<Sys_RepairDutyCategory> r = new List<Sys_RepairDutyCategory>();
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
         public int CreateCode(string where)
         {
             int r = -1;
             string sql = "";
             if (where != "")
             {
                 sql = "select isnull(max(convert(int,substring(rccode,len(rccode)-1,2))),0) as n from Sys_RepairDutyCategory where rcpcode='" + where + "'";
             }
             else
             {
                 sql = "select isnull(max(convert(int, rccode)),0) as n from Sys_RepairDutyCategory where rcpcode='" + where + "'";
             }
             object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
             r = o == null ? 9999 : Convert.ToInt32(o) + 1;
             return r;
         }
		#endregion  ExtensionMethod
    }
}
