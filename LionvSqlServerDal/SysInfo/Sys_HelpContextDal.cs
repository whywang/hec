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
    public class Sys_HelpContextDal : ISys_HelpContextDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_HelpContext model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_HelpContext where hcode='{0}';",model.hcode);
            strSql.AppendFormat("update  Sys_HelpMenu set htext='true' where hcode='{0}';", model.hcode);
            strSql.Append("insert into Sys_HelpContext(");
            strSql.Append("hcode,hname,hcontext,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@hcode,@hname,@hcontext,@maker,@cdate);");
            SqlParameter[] parameters = {
					new SqlParameter("@hcode", SqlDbType.NVarChar,20),
					new SqlParameter("@hname", SqlDbType.NVarChar,50),
					new SqlParameter("@hcontext", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.hcode;
            parameters[1].Value = model.hname;
            parameters[2].Value = model.hcontext;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;

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
        /// 得到一个对象实体
        /// </summary>
        public Sys_HelpContext Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,hcode,hname,hcontext,maker,cdate from Sys_HelpContext ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_HelpContext r = new Sys_HelpContext();
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
        public Sys_HelpContext DataRowToModel(DataRow row)
        {
            Sys_HelpContext model = new Sys_HelpContext();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["hcode"] != null)
                {
                    model.hcode = row["hcode"].ToString();
                }
                if (row["hname"] != null)
                {
                    model.hname = row["hname"].ToString();
                }
                if (row["hcontext"] != null)
                {
                    model.hcontext = row["hcontext"].ToString();
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
