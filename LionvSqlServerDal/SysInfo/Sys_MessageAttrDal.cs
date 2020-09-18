using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
   public class Sys_MessageAttrDal : ISys_MessageAttrDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_MessageAttr");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_MessageAttr model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_MessageAttr(");
            strSql.Append("ename,ecode,eurl,esource,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@ename,@ecode,@eurl,@esource,@maker,@cdate,@dcode)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,50),
					new SqlParameter("@ecode", SqlDbType.NVarChar,20),
					new SqlParameter("@eurl", SqlDbType.NVarChar,200),
					new SqlParameter("@esource", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.ecode;
            parameters[2].Value = model.eurl;
            parameters[3].Value = model.esource;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.dcode;
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
        public bool Update( Sys_MessageAttr model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_MessageAttr set ");
            strSql.Append("ename=@ename,");
            strSql.Append("eurl=@eurl,");
            strSql.Append("esource=@esource,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ecode=@ecode");
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,50),
					new SqlParameter("@eurl", SqlDbType.NVarChar,200),
					new SqlParameter("@esource", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ecode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.eurl;
            parameters[2].Value = model.esource;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.ecode;

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
        public bool Delete(string ecode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_MessageAttr ");
            strSql.AppendFormat(" where ecode='{0}' ",ecode);
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
        public  Sys_MessageAttr Query(string  where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ename,ecode,eurl,esource,maker,cdate,dcode from Sys_MessageAttr ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_MessageAttr r = new Sys_MessageAttr();
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
        public  Sys_MessageAttr DataRowToModel(DataRow row)
        {
             Sys_MessageAttr model = new  Sys_MessageAttr();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["ecode"] != null)
                {
                    model.ecode = row["ecode"].ToString();
                }
                if (row["eurl"] != null)
                {
                    model.eurl = row["eurl"].ToString();
                }
                if (row["esource"] != null)
                {
                    model.esource = row["esource"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_MessageAttr> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ename,ecode,eurl,esource,maker,cdate,dcode ");
            strSql.AppendFormat(" FROM Sys_MessageAttr where 1=1 {0}  ", strWhere);
            List<Sys_MessageAttr> r = new List<Sys_MessageAttr>();
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
            string sql = "select isnull(max(convert(int,ecode)),0) as n from Sys_MessageAttr ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
