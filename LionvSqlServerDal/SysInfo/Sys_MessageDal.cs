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
    public class Sys_MessageDal : ISys_MessageDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Message");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Message(");
            strSql.Append("mname,mcode,rcode,ename,mstate,bcode,mcity,iused,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@mname,@mcode,@rcode,@ename,@mstate,@bcode,@mcity,@iused,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@mstate", SqlDbType.Int,4),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcity", SqlDbType.Bit,1),
					new SqlParameter("@iused", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mcode;
            parameters[2].Value = model.rcode;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.mstate;
            parameters[5].Value = model.bcode;
            parameters[6].Value = model.mcity;
            parameters[7].Value = model.iused;
            parameters[8].Value = model.maker;
            parameters[9].Value = model.cdate;

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
        public bool Update( Sys_Message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Message set ");
            strSql.Append("mname=@mname,");
            strSql.Append("rcode=@rcode,");
            strSql.Append("ename=@ename,");
            strSql.Append("mstate=@mstate,");
            strSql.Append("bcode=@bcode,");
            strSql.Append("mcity=@mcity,");
            strSql.Append("iused=@iused,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where mcode=@mcode");
            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@rcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@mstate", SqlDbType.Int,4),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mcity", SqlDbType.Bit,1),
					new SqlParameter("@iused", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.rcode;
            parameters[2].Value = model.ename;
            parameters[3].Value = model.mstate;
            parameters[4].Value = model.bcode;
            parameters[5].Value = model.mcity;
            parameters[6].Value = model.iused;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.mcode;

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
        public bool Delete(string mcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Message ");
            strSql.AppendFormat(" where  mcode='{0}';", mcode);
            strSql.Append("delete from Sys_MessageEname ");
            strSql.AppendFormat(" where  mcode='{0}';", mcode);
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
        public  Sys_Message Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mname,mcode,rcode,ename,mstate,bcode,mcity,iused,maker,cdate,murl from Sys_Message ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Message r = new Sys_Message();
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
        public  Sys_Message DataRowToModel(DataRow row)
        {
             Sys_Message model = new  Sys_Message();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["mcode"] != null)
                {
                    model.mcode = row["mcode"].ToString();
                }
                if (row["rcode"] != null)
                {
                    model.rcode = row["rcode"].ToString();
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["mstate"] != null && row["mstate"].ToString() != "")
                {
                    model.mstate = int.Parse(row["mstate"].ToString());
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["murl"] != null)
                {
                    model.murl = row["murl"].ToString();
                }
                if (row["mcity"] != null && row["mcity"].ToString() != "")
                {
                    if ((row["mcity"].ToString() == "1") || (row["mcity"].ToString().ToLower() == "true"))
                    {
                        model.mcity = true;
                    }
                    else
                    {
                        model.mcity = false;
                    }
                }
                if (row["iused"] != null && row["iused"].ToString() != "")
                {
                    if ((row["iused"].ToString() == "1") || (row["iused"].ToString().ToLower() == "true"))
                    {
                        model.iused = true;
                    }
                    else
                    {
                        model.iused = false;
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
        public List<Sys_Message> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mname,mcode,rcode,ename,mstate,bcode,mcity,iused,maker,murl,cdate ");
            strSql.AppendFormat(" FROM Sys_Message where 1=1 {0}", strWhere);
            List<Sys_Message> r = new List<Sys_Message>();
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
            string sql = "select isnull(max(convert(int,mcode)),0) as n from Sys_Message ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public string QueryEname(string where)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.AppendFormat(" FROM Sys_MessageEname where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["ename"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r="";
            }
            return r;
        }
        /// <summary>
        /// 增加人员时每个人员增加一条记录
        /// </summary>
        public int Save(Sys_Message model)
        {
            string[] ename = model.ename.Split(';');
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_Message where mcode='{0}';", model.mcode);
            strSql.AppendFormat("delete from Sys_MessageEname where mcode='{0}';", model.mcode);
            strSql.Append("insert into Sys_Message(");
            strSql.Append("mname,mcode,rcode,ename,mstate,bcode,mcity,iused,maker,cdate,murl)");
            strSql.Append(" values (");
            strSql.AppendFormat(" '{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}');", model.mname, model.mcode, model.rcode, model.ename, model.mstate, model.bcode, model.mcity, model.iused, model.maker, model.cdate, model.murl);
            if (ename.Length>0)
            {
                for (int i = 0; i < ename.Length; i++)
                {
                    strSql.Append("insert into Sys_MessageEname(");
                    strSql.Append("mcode,ename,maker,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat(" '{0}','{1}','{2}','{3}');", model.mcode,  ename[i], model.maker, model.cdate);
            
                }
            }
            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  ExtensionMethod
    }
}
