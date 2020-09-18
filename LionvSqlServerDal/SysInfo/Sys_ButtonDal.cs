using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvModel.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public partial class Sys_ButtonDal : ISys_ButtonDal
    {
        public Sys_ButtonDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Button");
            strSql.AppendFormat(" where 1=1 {0} " ,where);
            return SqlHelp.Exists(SqlHelp.ConnectionString,CommandType.Text,strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Button model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Button(");
            strSql.Append("bname,bcode,babc,emcode,emname,wname,wcode,btype,bstyle,battr,bstate,bcheck,bshow,burl,bfn,bsql,brname,brcode,bspeattr,bsort,biszt,bproname,bprocedure,remcode,rwcode,btip,bremark,bico)");
            strSql.Append(" values (");
            strSql.Append("@bname,@bcode,@babc,@emcode,@emname,@wname,@wcode,@btype,@bstyle,@battr,@bstate,@bcheck,@bshow,@burl,@bfn,@bsql,@brname,@brcode,@bspeattr,@bsort,@biszt,@bproname,@bprocedure,@remcode,@rwcode,@btip,@bremark,@bico)");
            SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30),
					new SqlParameter("@babc", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@btype", SqlDbType.NVarChar,10),
					new SqlParameter("@bstyle", SqlDbType.NVarChar,10),
					new SqlParameter("@battr", SqlDbType.NVarChar,10),
					new SqlParameter("@bstate", SqlDbType.Int,4),
					new SqlParameter("@bcheck", SqlDbType.Bit,1),
					new SqlParameter("@bshow", SqlDbType.Bit,1),
					new SqlParameter("@burl", SqlDbType.NVarChar,100),
					new SqlParameter("@bfn", SqlDbType.NVarChar,100),
					new SqlParameter("@bsql", SqlDbType.NVarChar,300),
					new SqlParameter("@brname", SqlDbType.NVarChar,30),
					new SqlParameter("@brcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bspeattr", SqlDbType.Int,4),
					new SqlParameter("@bsort", SqlDbType.Int,4),
					new SqlParameter("@biszt", SqlDbType.Bit,1),
					new SqlParameter("@bproname", SqlDbType.NVarChar,30),
					new SqlParameter("@bprocedure", SqlDbType.NVarChar,500),
                    new SqlParameter("@remcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rwcode", SqlDbType.NVarChar,30),
					new SqlParameter("@btip", SqlDbType.Int,4),
					new SqlParameter("@bremark", SqlDbType.NVarChar,200),
                    new SqlParameter("@btab", SqlDbType.NVarChar,30),
                    new SqlParameter("@bico", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.bname;
            parameters[1].Value = model.bcode;
            parameters[2].Value = model.babc;
            parameters[3].Value = model.emcode;
            parameters[4].Value = model.emname;
            parameters[5].Value = model.wname;
            parameters[6].Value = model.wcode;
            parameters[7].Value = model.btype;
            parameters[8].Value = model.bstyle;
            parameters[9].Value = model.battr;
            parameters[10].Value = model.bstate;
            parameters[11].Value = model.bcheck;
            parameters[12].Value = model.bshow;
            parameters[13].Value = model.burl;
            parameters[14].Value = model.bfn;
            parameters[15].Value = model.bsql;
            parameters[16].Value = model.brname;
            parameters[17].Value = model.brcode;
            parameters[18].Value = model.bspeattr;
            parameters[19].Value = model.bsort;
            parameters[20].Value = model.biszt;
            parameters[21].Value = model.bproname;
            parameters[22].Value = model.bprocedure;
            parameters[23].Value = model.remcode;
            parameters[24].Value = model.rwcode;
            parameters[25].Value = model.btip;
            parameters[26].Value = model.bremark;
            parameters[27].Value = model.btab;
            parameters[28].Value = model.bico;
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
        public bool Update( Sys_Button model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Button set ");
            strSql.Append("bname=@bname,");
            strSql.Append("babc=@babc,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("emname=@emname,");
            strSql.Append("wname=@wname,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("btype=@btype,");
            strSql.Append("bstyle=@bstyle,");
            strSql.Append("battr=@battr,");
            strSql.Append("bstate=@bstate,");
            strSql.Append("bcheck=@bcheck,");
            strSql.Append("bshow=@bshow,");
            strSql.Append("burl=@burl,");
            strSql.Append("bfn=@bfn,");
            strSql.Append("bsql=@bsql,");
            strSql.Append("brname=@brname,");
            strSql.Append("brcode=@brcode,");
            strSql.Append("bspeattr=@bspeattr,");
            strSql.Append("bsort=@bsort,");
            strSql.Append("biszt=@biszt,");
            strSql.Append("bproname=@bproname,");
            strSql.Append("bprocedure=@bprocedure,");
            strSql.Append("remcode=@remcode,");
            strSql.Append("btip=@btip,");
            strSql.Append("rwcode=@rwcode,");
            strSql.Append("bremark=@bremark,");
            strSql.Append("btab=@btab,");
            strSql.Append("bico=@bico");
            strSql.Append(" where bcode=@bcode");
            SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,30),
					new SqlParameter("@babc", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@emname", SqlDbType.NVarChar,30),
					new SqlParameter("@wname", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@btype", SqlDbType.NVarChar,10),
					new SqlParameter("@bstyle", SqlDbType.NVarChar,10),
					new SqlParameter("@battr", SqlDbType.NVarChar,10),
					new SqlParameter("@bstate", SqlDbType.Int,4),
					new SqlParameter("@bcheck", SqlDbType.Bit,1),
					new SqlParameter("@bshow", SqlDbType.Bit,1),
					new SqlParameter("@burl", SqlDbType.NVarChar,100),
					new SqlParameter("@bfn", SqlDbType.NVarChar,100),
					new SqlParameter("@bsql", SqlDbType.NVarChar,300),
					new SqlParameter("@brname", SqlDbType.NVarChar,30),
					new SqlParameter("@brcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bspeattr", SqlDbType.Int,4),
					new SqlParameter("@bsort", SqlDbType.Int,4),
					new SqlParameter("@biszt", SqlDbType.Bit,1),
					new SqlParameter("@bproname", SqlDbType.NVarChar,30),
					new SqlParameter("@bprocedure", SqlDbType.NVarChar,500),
                    new SqlParameter("@remcode", SqlDbType.NVarChar,30),
                    new SqlParameter("@btip", SqlDbType.Int,4),
					new SqlParameter("@rwcode", SqlDbType.NVarChar,30),
                    new SqlParameter("@bremark", SqlDbType.NVarChar,200),
					new SqlParameter("@btab", SqlDbType.NVarChar,30),
                    new SqlParameter("@bico", SqlDbType.NVarChar,30),
					new SqlParameter("@bcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.bname;
            parameters[1].Value = model.babc;
            parameters[2].Value = model.emcode;
            parameters[3].Value = model.emname;
            parameters[4].Value = model.wname;
            parameters[5].Value = model.wcode;
            parameters[6].Value = model.btype;
            parameters[7].Value = model.bstyle;
            parameters[8].Value = model.battr;
            parameters[9].Value = model.bstate;
            parameters[10].Value = model.bcheck;
            parameters[11].Value = model.bshow;
            parameters[12].Value = model.burl;
            parameters[13].Value = model.bfn;
            parameters[14].Value = model.bsql;
            parameters[15].Value = model.brname;
            parameters[16].Value = model.brcode;
            parameters[17].Value = model.bspeattr;
            parameters[18].Value = model.bsort;
            parameters[19].Value = model.biszt;
            parameters[20].Value = model.bproname;
            parameters[21].Value = model.bprocedure;
            parameters[22].Value = model.remcode;
            parameters[23].Value = model.btip;
            parameters[24].Value = model.rwcode;
            parameters[25].Value = model.bremark;
            parameters[26].Value = model.btab;
            parameters[27].Value = model.bico;
            parameters[28].Value = model.bcode;
            bool r =false;

            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string bcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Button ");
            strSql.AppendFormat(" where  bcode= '{0}';", bcode);
            strSql.AppendFormat(" delete from Sys_BackEvent where  bcode='{0}'", bcode);
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
        public  Sys_Button Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bname,bcode,babc,emcode,emname,wname,wcode,btype,bstyle,battr,bstate,bcheck,bshow,burl,bfn,bsql,brname,brcode,bspeattr,bsort,biszt,bproname,bprocedure,remcode,rwcode,btip,bremark,btab,bico from Sys_Button ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_Button r = new Sys_Button();
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
        public Sys_Button DataRowToModel(DataRow row)
        {
            Sys_Button model = new  Sys_Button();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bname"] != null)
                {
                    model.bname = row["bname"].ToString();
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["babc"] != null)
                {
                    model.babc = row["babc"].ToString();
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["remcode"] != null)
                {
                    model.remcode = row["remcode"].ToString();
                }
                if (row["emname"] != null)
                {
                    model.emname = row["emname"].ToString();
                }
                if (row["wname"] != null)
                {
                    model.wname = row["wname"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["rwcode"] != null)
                {
                    model.rwcode = row["rwcode"].ToString();
                }
                if (row["btype"] != null)
                {
                    model.btype = row["btype"].ToString();
                }
                if (row["bstyle"] != null)
                {
                    model.bstyle = row["bstyle"].ToString();
                }
                if (row["battr"] != null && row["battr"].ToString() != "")
                {
                    model.battr = row["battr"].ToString();
                }
                if (row["bstate"] != null && row["bstate"].ToString() != "")
                {
                    model.bstate = int.Parse(row["bstate"].ToString());
                }
                if (row["bcheck"] != null && row["bcheck"].ToString() != "")
                {
                    if ((row["bcheck"].ToString() == "1") || (row["bcheck"].ToString().ToLower() == "true"))
                    {
                        model.bcheck = true;
                    }
                    else
                    {
                        model.bcheck = false;
                    }
                }
                if (row["bshow"] != null && row["bshow"].ToString() != "")
                {
                    if ((row["bshow"].ToString() == "1") || (row["bshow"].ToString().ToLower() == "true"))
                    {
                        model.bshow = true;
                    }
                    else
                    {
                        model.bshow = false;
                    }
                }
                if (row["burl"] != null)
                {
                    model.burl = row["burl"].ToString();
                }
                if (row["bfn"] != null)
                {
                    model.bfn = row["bfn"].ToString();
                }
                if (row["bsql"] != null)
                {
                    model.bsql = row["bsql"].ToString();
                }
                if (row["brname"] != null)
                {
                    model.brname = row["brname"].ToString();
                }
                if (row["brcode"] != null)
                {
                    model.brcode = row["brcode"].ToString();
                }
                if (row["bspeattr"] != null && row["bspeattr"].ToString() != "")
                {
                    model.bspeattr = int.Parse(row["bspeattr"].ToString());
                }
                if (row["bsort"] != null && row["bsort"].ToString() != "")
                {
                    model.bsort = int.Parse(row["bsort"].ToString());
                }
                if (row["biszt"] != null && row["biszt"].ToString() != "")
                {
                    if ((row["biszt"].ToString() == "1") || (row["biszt"].ToString().ToLower() == "true"))
                    {
                        model.biszt = true;
                    }
                    else
                    {
                        model.biszt = false;
                    }
                }
                if (row["bproname"] != null)
                {
                    model.bproname = row["bproname"].ToString();
                }
                if (row["bprocedure"] != null)
                {
                    model.bprocedure = row["bprocedure"].ToString();
                }
                if (row["btip"] != null && row["btip"].ToString() != "")
                {
                    model.btip = int.Parse(row["btip"].ToString());
                }
                if (row["bremark"] != null)
                {
                    model.bremark = row["bremark"].ToString();
                }
                if (row["btab"] != null)
                {
                    model.btab = row["btab"].ToString();
                }
                if (row["bico"] != null)
                {
                    model.bico = row["bico"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Button> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,bname,bcode,babc,emcode,emname,wname,wcode,btype,bstyle,battr,bstate,bcheck,bshow,burl,bfn,bsql,brname,brcode,bspeattr,bsort,biszt,bproname,bprocedure,remcode,rwcode,btip,bremark,btab,bico ");
            strSql.AppendFormat(" FROM Sys_Button where 1=1 {0} order by bsort", strWhere);
            List<Sys_Button> r = new List<Sys_Button>();
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
            string sql = "select isnull(max(convert(int,bcode)),0) as n from Sys_Button ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
       public bool CheckBtnSql(string sql)
        {
            bool r = false;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            if (o == null || o.ToString() == "" || o.ToString() == "0")
            {

            }
            else
            {
                r = true;
            }
            return r;
        }
       public int SetRoleEmenuBtn(string rcode, string emcode, string[] bcode,string btype)
       {
           StringBuilder sql = new StringBuilder();
           sql.AppendFormat(" delete from Sys_RRoleButton where rcode='{0}' and ecode='{1}' and btype='{2}';", rcode, emcode,btype);
           if (bcode!=null)
           {
               for (int i = 0; i < bcode.Length; i++)
               {
                   sql.AppendFormat(" insert into Sys_RRoleButton (rcode,ecode,bcode,btype)values ('{0}','{1}','{2}','{3}');", rcode, emcode, bcode[i],btype);
               }
           }
           int r = 0;
           try
           {
               r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
           }
           catch
           {
               r = -1;
           }
           return r;
       }
       public List<Sys_Button> GetRolePageListBtn(string rcode, string emcode,string Btype)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat("select * from Sys_Button where btype='{0}' and bcode in (select bcode from Sys_RRoleButton where rcode='{1}' and ecode='{2}')",Btype,rcode,emcode);
           List<Sys_Button> r = new List<Sys_Button>();
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
        #endregion  ExtensionMethod
    }
}
