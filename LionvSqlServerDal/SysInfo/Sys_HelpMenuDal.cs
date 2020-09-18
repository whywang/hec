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
    public class Sys_HelpMenuDal : ISys_HelpMenuDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_HelpMenu");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_HelpMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_HelpMenu(");
            strSql.Append("hname,hcode,hpcode,isend,htext,cdate,maker,hpname,dcode)");
            strSql.Append(" values (");
            strSql.Append("@hname,@hcode,@hpcode,@isend,@htext,@cdate,@maker,@hpname,@dcode);");
            SqlParameter[] parameters = {
					new SqlParameter("@hname", SqlDbType.NVarChar,100),
					new SqlParameter("@hcode", SqlDbType.NVarChar,20),
					new SqlParameter("@hpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@htext", SqlDbType.Bit,1),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@hpname", SqlDbType.NVarChar,100),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.hname;
            parameters[1].Value = model.hcode;
            parameters[2].Value = model.hpcode;
            parameters[3].Value = model.isend;
            parameters[4].Value = model.htext;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.hpname;
            parameters[8].Value = model.dcode;
            if (model.hpcode != "")
            {
                strSql.Append(" update Sys_HelpMenu set isend='false' where hcode='" + model.hpcode + "' ;");
            }
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
        public bool Update(Sys_HelpMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_HelpMenu set ");
            strSql.Append("hname=@hname,");
            strSql.Append("hpcode=@hpcode,");
            strSql.Append("htext=@htext,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker,");
            strSql.Append("hpname=@hpname");
            strSql.Append(" where hcode=@hcode;");
            SqlParameter[] parameters = {
					new SqlParameter("@hname", SqlDbType.NVarChar,50),
					new SqlParameter("@hpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@htext", SqlDbType.Bit,1),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@hpname", SqlDbType.NVarChar,50),
					new SqlParameter("@hcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.hname;
            parameters[1].Value = model.hpcode;
            parameters[2].Value = model.htext;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.hpname;
            parameters[6].Value = model.hcode;
            strSql.AppendFormat("update Sys_HelpMenu set hpname='{0}' where hpcode='{1}' ", model.hpname, model.hpcode);
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
        public bool Delete(string hcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_HelpMenu ");
            strSql.AppendFormat(" where  hcode='{0}';", hcode);
            strSql.Append("delete from Sys_HelpMenu ");
            strSql.AppendFormat(" where  hpcode like '{0}%';", hcode);
            strSql.AppendFormat("delete from Sys_HelpContext where hcode='{0}';", hcode);
            if (HasChild(hcode))
            {
            }
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
        public Sys_HelpMenu Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hname,hcode,hpcode,isend,htext,cdate,maker,hpname ,dcode from Sys_HelpMenu ");
            strSql.AppendFormat(" where 1=1 {0}", where.ToString());
            Sys_HelpMenu r = new Sys_HelpMenu();
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
        public Sys_HelpMenu DataRowToModel(DataRow row)
        {
            Sys_HelpMenu model = new Sys_HelpMenu();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["hname"] != null)
                {
                    model.hname = row["hname"].ToString();
                }
                if (row["hpname"] != null)
                {
                    model.hpname = row["hpname"].ToString();
                }
                if (row["hcode"] != null)
                {
                    model.hcode = row["hcode"].ToString();
                }
                if (row["hpcode"] != null)
                {
                    model.hpcode = row["hpcode"].ToString();
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
                if (row["htext"] != null && row["htext"].ToString() != "")
                {
                    if ((row["htext"].ToString() == "1") || (row["htext"].ToString().ToLower() == "true"))
                    {
                        model.htext = true;
                    }
                    else
                    {
                        model.htext = false;
                    }
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<Sys_HelpMenu> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,hname,hcode,hpcode,isend,htext,cdate,maker,hpname,dcode ");
            strSql.AppendFormat(" FROM Sys_HelpMenu where 1=1 {0}", strWhere);
            List<Sys_HelpMenu> r = new List<Sys_HelpMenu>();
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
        public int CreateCode(string hcode)
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,hcode)),0) as n from Sys_HelpMenu where hpcode='" + hcode + "' ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        private bool HasChild(string where)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Sys_HelpMenu");
            strSql.AppendFormat(" where hpcode=(select phcode from Sys_HelpMenu where hcode='{0}') ", where);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r =dt.Rows.Count>1?true:false;
            }
            else
            {
                r = false;
            }
            return r;
        }

        #endregion  ExtensionMethod
    }
}
