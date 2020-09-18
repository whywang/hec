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
   public class Sys_RepairReasonCategoryDal : ISys_RepairReasonCategoryDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RepairReasonCategory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_RepairReasonCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_RepairReasonCategory(");
            strSql.Append("rrname,rrcode,rrpcode,rrpname,isend,rread,rtype,dcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@rrname,@rrcode,@rrpcode,@rrpname,@isend,@rread,@rtype,@dcode,@maker,@cdate);");
            SqlParameter[] parameters = {
					new SqlParameter("@rrname", SqlDbType.NVarChar,30),
					new SqlParameter("@rrcode", SqlDbType.NVarChar,10),
					new SqlParameter("@rrpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rrpname", SqlDbType.NVarChar,10),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.rrname;
            parameters[1].Value = model.rrcode;
            parameters[2].Value = model.rrpcode;
            parameters[3].Value = model.rrpname;
            parameters[4].Value = model.isend;
            parameters[5].Value = model.rread;
            parameters[6].Value = model.rtype;
            parameters[7].Value = model.dcode;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;
            int r = 0;
            strSql.AppendFormat("update Sys_RepairReasonCategory set isend='false' where rrcode ='{0}';", model.rrpcode);
            
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
        public bool Update(Sys_RepairReasonCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_RepairReasonCategory set ");
            strSql.Append("rrname=@rrname,");
            strSql.Append("rrpcode=@rrpcode,");
            strSql.Append("rrpname=@rrpname,");
            strSql.Append("isend=@isend,");
            strSql.Append("rread=@rread,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rrcode=@rrcode;");
            SqlParameter[] parameters = {
					new SqlParameter("@rrname", SqlDbType.NVarChar,30),
					new SqlParameter("@rrpcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rrpname", SqlDbType.NVarChar,10),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@rread", SqlDbType.Bit,1),
					new SqlParameter("@rtype", SqlDbType.NVarChar,10),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rrcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.rrname;
            parameters[1].Value = model.rrpcode;
            parameters[2].Value = model.rrpname;
            parameters[3].Value = model.isend;
            parameters[4].Value = model.rread;
            parameters[5].Value = model.rtype;
            parameters[6].Value = model.dcode;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.rrcode;
            bool r = false;
            strSql.AppendFormat("update Sys_RepairReasonCategory set rrpname='{0}' where rrpcode like '{1}%';", model.rrname, model.rrcode);
            strSql.AppendFormat("update Sys_RepairReason set rrname='{0}' where rrcode='{1}';", model.rrname, model.rrcode);
            
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string rrcode)
        {

            StringBuilder strSql = new StringBuilder();
            StringBuilder strSqll = new StringBuilder();
            strSql.Append("delete from Sys_RepairReasonCategory ");
            strSql.AppendFormat(" where  rrcode like '{0}%';", rrcode);
            strSql.AppendFormat(" delete from Sys_RepairReason where  rcode like '{0}%'", rrcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            if (rrcode.Length > 2)
            {
                string pcode = rrcode.Substring(0, rrcode.Length - 2);
                if (!Exists(" and rrpcode='" + pcode + "'"))
                {
                    strSqll.AppendFormat(" update Sys_RepairReasonCategory set isend='true' where  rrcode ='{0}';", pcode);
                    SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSqll.ToString(), null);
                }
            }
            return r;
      
        }
  

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_RepairReasonCategory Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,rrname,rrcode,rrpcode,rrpname,isend,rread,rtype,dcode,maker,cdate from Sys_RepairReasonCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_RepairReasonCategory r = new Sys_RepairReasonCategory();
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
        public Sys_RepairReasonCategory DataRowToModel(DataRow row)
        {
             Sys_RepairReasonCategory model = new  Sys_RepairReasonCategory();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rrname"] != null)
                {
                    model.rrname = row["rrname"].ToString();
                }
                if (row["rrcode"] != null)
                {
                    model.rrcode = row["rrcode"].ToString();
                }
                if (row["rrpcode"] != null)
                {
                    model.rrpcode = row["rrpcode"].ToString();
                }
                if (row["rrpname"] != null)
                {
                    model.rrpname = row["rrpname"].ToString();
                }
                if (row["isend"] != null && row["isend"].ToString() != "")
                {
                    if ((row["isend"].ToString() == "1") || (row["isend"].ToString().ToLower() == "true"))
                    {
                        model.isend = true;
                    }
                    else
                    {
                        model.isend = false;
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
       public List<Sys_RepairReasonCategory> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rrname,rrcode,rrpcode,rrpname,isend,rread,rtype,dcode,maker,cdate");
            strSql.AppendFormat(" FROM Sys_RepairReasonCategory where 1=1 {0}  ", strWhere);
            List<Sys_RepairReasonCategory> r = new List<Sys_RepairReasonCategory>();
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
                sql = "select isnull(max(convert(int,substring(rrcode,len(rrcode)-1,2))),0) as n from Sys_RepairReasonCategory where rrpcode='" + where + "'";
            }
            else
            {
                sql = "select isnull(max(convert(int, rrcode)),0) as n from Sys_RepairReasonCategory where rrpcode='" + where + "'";
            }
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
