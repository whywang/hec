using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_EventMenuDal : ISys_EventMenuDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_EventMenu");
            strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_EventMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_EventMenu(");
            strSql.Append("emname,emcode,mname,mcode,isflow,islist,isspe,isexp,emtype,emattr,emread,dcode,maker,cdate,emattrex)");
            strSql.Append(" values (");
            strSql.Append("@emname,@emcode,@mname,@mcode,@isflow,@islist,@isspe,@isexp,@emtype,@emattr,@emread,@dcode,@maker,@cdate,@emattrex)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@emname", SqlDbType.NVarChar,50),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20),
					new SqlParameter("@isflow", SqlDbType.Bit,1),
					new SqlParameter("@islist", SqlDbType.Bit,1),
					new SqlParameter("@isspe", SqlDbType.Bit,1),
					new SqlParameter("@isexp", SqlDbType.Int,4),
					new SqlParameter("@emtype", SqlDbType.NVarChar,30),
					new SqlParameter("@emattr", SqlDbType.NVarChar,10),
					new SqlParameter("@emread", SqlDbType.Bit,1),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@emattrex", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.emname;
            parameters[1].Value = model.emcode;
            parameters[2].Value = model.mname;
            parameters[3].Value = model.mcode;
            parameters[4].Value = model.isflow;
            parameters[5].Value = model.islist;
            parameters[6].Value = model.isspe;
            parameters[7].Value = model.isexp;
            parameters[8].Value = model.emtype;
            parameters[9].Value = model.emattr;
            parameters[10].Value = model.emread;
            parameters[11].Value = model.dcode;
            parameters[12].Value = model.maker;
            parameters[13].Value = model.cdate;
            parameters[14].Value = model.emattrex;
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
        public bool Update(Sys_EventMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_EventMenu set ");
            strSql.Append("emname=@emname,");
            strSql.Append("mname=@mname,");
            strSql.Append("mcode=@mcode,");
            strSql.Append("isflow=@isflow,");
            strSql.Append("islist=@islist,");
            strSql.Append("isspe=@isspe,");
            strSql.Append("isexp=@isexp,");
            strSql.Append("emtype=@emtype,");
            strSql.Append("emattr=@emattr,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("emattrex=@emattrex");
            strSql.Append(" where emcode=@emcode;");
            SqlParameter[] parameters = {
					new SqlParameter("@emname", SqlDbType.NVarChar,50),
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20),
					new SqlParameter("@isflow", SqlDbType.Bit,1),
					new SqlParameter("@islist", SqlDbType.Bit,1),
					new SqlParameter("@isspe", SqlDbType.Bit,1),
					new SqlParameter("@isexp", SqlDbType.Int,4),
					new SqlParameter("@emtype", SqlDbType.NVarChar,30),
					new SqlParameter("@emattr", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@emattrex", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.emname;
            parameters[1].Value = model.mname;
            parameters[2].Value = model.mcode;
            parameters[3].Value = model.isflow;
            parameters[4].Value = model.islist;
            parameters[5].Value = model.isspe;
            parameters[6].Value = model.isexp;
            parameters[7].Value = model.emtype;
            parameters[8].Value = model.emattr;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.emattrex;
            parameters[12].Value = model.emcode;
            strSql.AppendFormat("update Sys_Button set emname='{0}' where emcode='{1}' ;", model.emname, model.emcode);
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
        public bool Delete(string emcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_BackEvent where bcode in (select bcode from Sys_Button where wcode in (select wcode from Sys_WorkEvent where emcode='{0}'));", emcode);
            strSql.AppendFormat("delete from Sys_Button where wcode in (select wcode from Sys_WorkEvent where emcode='{0}');", emcode);
            strSql.AppendFormat("delete from Sys_EventMenu where emcode='{0}';", emcode);
            strSql.AppendFormat("delete from Sys_WorkEvent where emcode='{0}';", emcode);

            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString,  strSql ) > 0)
            {
                r = true;
            }
            return r;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_EventMenu Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,emname,emcode,mname,mcode,isflow,islist,isspe,isexp,emtype,emattr,emattrex,emread,dcode,maker,cdate from Sys_EventMenu");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_EventMenu r = new Sys_EventMenu();
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
        private Sys_EventMenu DataRowToModel(DataRow row)
        {
            Sys_EventMenu model = new Sys_EventMenu();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["mcode"] != null)
                {
                    model.mcode = row["mcode"].ToString();
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
                if (row["islist"] != null && row["islist"].ToString() != "")
                {
                    if ((row["islist"].ToString() == "1") || (row["islist"].ToString().ToLower() == "true"))
                    {
                        model.islist = true;
                    }
                    else
                    {
                        model.islist = false;
                    }
                }
                if (row["isspe"] != null && row["isspe"].ToString() != "")
                {
                    if ((row["isspe"].ToString() == "1") || (row["isspe"].ToString().ToLower() == "true"))
                    {
                        model.isspe = true;
                    }
                    else
                    {
                        model.isspe = false;
                    }
                }
                if (row["isexp"] != null && row["isexp"].ToString() != "")
                {
                    model.isexp = int.Parse(row["isexp"].ToString());
                }
                if (row["emtype"] != null)
                {
                    model.emtype = row["emtype"].ToString();
                }
                if (row["emattr"] != null)
                {
                    model.emattr = row["emattr"].ToString();
                }
                if (row["emattrex"] != null)
                {
                    model.emattrex = row["emattrex"].ToString();
                }
                if (row["emread"] != null && row["emread"].ToString() != "")
                {
                    if ((row["emread"].ToString() == "1") || (row["emread"].ToString().ToLower() == "true"))
                    {
                        model.emread = true;
                    }
                    else
                    {
                        model.emread = false;
                    }
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
                    model.cdate =  row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_EventMenu> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,emname,emcode,mname,mcode,isflow,islist,isspe,isexp,emtype,emattr,emattrex,emread,dcode,maker,cdate from Sys_EventMenu ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_EventMenu> r = new List<Sys_EventMenu>();
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

        #endregion  成员方法
        #region  MethodEx
        public int CreateCode()
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,emcode)),0) as n from Sys_EventMenu ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  MethodEx
    }
}
