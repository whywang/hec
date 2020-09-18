using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_TabMenuAbcDal : ISys_TabMenuAbcDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_TabMenuAbc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_TabMenuAbc(");
            strSql.Append("tmname,tmcode,tname,tcode,rcode,tsql,cdate,ptype)");
            strSql.Append(" values (");
            strSql.Append("@tmname,@tmcode,@tname,@tcode,@rcode,@tsql,@cdate,@ptype)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tmname", SqlDbType.NVarChar,30),
					new SqlParameter("@tmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tsql", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@ptype", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tmname;
            parameters[1].Value = model.tmcode;
            parameters[2].Value = model.tname;
            parameters[3].Value = model.tcode;
            parameters[4].Value = model.rcode;
            parameters[5].Value = model.tsql;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.ptype;
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
        public bool Update( Sys_TabMenuAbc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_TabMenuAbc set ");
            strSql.Append("tmname=@tmname,");
            strSql.Append("tmcode=@tmcode,");
            strSql.Append("tname=@tname,");
            strSql.Append("tcode=@tcode,");
            strSql.Append("rcode=@rcode,");
            strSql.Append("tsql=@tsql,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("ptype=@ptype");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@tmname", SqlDbType.NVarChar,30),
					new SqlParameter("@tmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@tsql", SqlDbType.NVarChar,500),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.tmname;
            parameters[1].Value = model.tmcode;
            parameters[2].Value = model.tname;
            parameters[3].Value = model.tcode;
            parameters[4].Value = model.rcode;
            parameters[5].Value = model.tsql;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.ptype;
            parameters[8].Value = model.id;
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
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_TabMenuAbc ");
            strSql.AppendFormat(" where 1=1 {0}  ",where);
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


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_TabMenuAbc Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tmname,tmcode,tname,tcode,rcode,tsql,cdate,ptype from Sys_TabMenuAbc ");
            strSql.AppendFormat(" where 1=1 {0}",where);
 
             Sys_TabMenuAbc r = new  Sys_TabMenuAbc();
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
        public  Sys_TabMenuAbc DataRowToModel(DataRow row)
        {
             Sys_TabMenuAbc model = new  Sys_TabMenuAbc();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tmname"] != null)
                {
                    model.tmname = row["tmname"].ToString();
                }
                if (row["tmcode"] != null)
                {
                    model.tmcode = row["tmcode"].ToString();
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["tsql"] != null)
                {
                    model.tsql = row["tsql"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_TabMenuAbc> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tmname,tmcode,tname,tcode,rcode,tsql,cdate,ptype ");
            strSql.Append(" FROM Sys_TabMenuAbc ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_TabMenuAbc> r = new List<Sys_TabMenuAbc>();
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
        public bool CheckSql(Sys_TabMenuAbc m,string sid)
        {
            bool r = false;
            if (m.tsql == "")
            {
                r = true;
            }
            else
            {
                string sql=m.tsql.Replace("[ID]",sid);
               r=  SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
