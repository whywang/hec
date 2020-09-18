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
    public class Sys_TabMenuDal : ISys_TabMenuDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_TabMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_TabMenu(");
            strSql.Append("tmname,tmcode,dcode,isflow,maker,cdate,tread)");
            strSql.Append(" values (");
            strSql.Append("@tmname,@tmcode,@dcode,@isflow,@maker,@cdate,@tread)");
            SqlParameter[] parameters = {
					new SqlParameter("@tmname", SqlDbType.NVarChar,30),
					new SqlParameter("@tmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@isflow", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tread", SqlDbType.Bit,1)};
            parameters[0].Value = model.tmname;
            parameters[1].Value = model.tmcode;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.isflow;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.tread;
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
        public bool Update( Sys_TabMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_TabMenu set ");
            strSql.Append("tmname=@tmname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("isflow=@isflow,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tmcode=@tmcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tmname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@isflow", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tmcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tmname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.isflow;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.tmcode;

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
        public bool Delete(string tcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_TabMenuAbc ");
            strSql.AppendFormat(" where tmcode='{0}';", tcode);
            strSql.Append("delete from Sys_TabMenu ");
            strSql.AppendFormat(" where tmcode='{0}';",tcode);

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
        public  Sys_TabMenu Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tmname,tmcode,dcode,isflow,maker,cdate,tread from Sys_TabMenu  ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             Sys_TabMenu r = new  Sys_TabMenu();
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
        public  Sys_TabMenu DataRowToModel(DataRow row)
        {
             Sys_TabMenu model = new  Sys_TabMenu();
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
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["isflow"] != null && row["isflow"].ToString() != "")
                {
                    if ((row["isflow"].ToString() == "1") || (row["isflow"].ToString().ToLower() == "true"))
                    {
                        model.isflow = true;
                    }
                    else
                    {
                        model.isflow = false;
                    }
                }
                if (row["tread"] != null && row["tread"].ToString() != "")
                {
                    if ((row["tread"].ToString() == "1") || (row["tread"].ToString().ToLower() == "true"))
                    {
                        model.tread = true;
                    }
                    else
                    {
                        model.tread = false;
                    }
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
        public List<Sys_TabMenu> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tmname,tmcode,dcode,isflow,maker,cdate,tread ");
            strSql.Append(" FROM Sys_TabMenu ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_TabMenu> r = new List<Sys_TabMenu>();
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
            string sql = "select isnull(max(convert(int,tmcode)),0) as n from Sys_TabMenu ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetTabMenuEvent(string tcode, string ecode, string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RTabMenuEventMenu where tmcode='{0}' and dcode='{1}';", tcode, dcode);
            strSql.AppendFormat(" insert into Sys_RTabMenuEventMenu (tmcode,emcode,dcode) values('{0}','{1}','{2}');", tcode,ecode, dcode);
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
        public bool ReSetTabMenuEvent(string tcode, string dcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RTabMenuEventMenu where tmcode='{0}' and dcode='{1}';", tcode, dcode);
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
        public string GetTabMenuEvent(string tcode, string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from Sys_RTabMenuEventMenu where tmcode='{0}' and dcode='{1}';", tcode, dcode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["emcode"].ToString();
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
