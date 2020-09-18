using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvCommon;
using System.Data;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Collections;

namespace LionvSqlServerDal.SysInfo
{
    public partial class Sys_MenuDal : ISys_MenuDal
    {
        public Sys_MenuDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Menu");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Menu(");
            strSql.Append("mname,mcode,mpcode,mpname,mhaschild,murl,msort,mtype,mshow,mdate,mgroup,mstyle)");
            strSql.Append(" values (");
            strSql.Append("@mname,@mcode,@mpcode,@mpname,@mhaschild,@murl,@msort,@mtype,@mshow,@mdate,@mgroup,@mstyle)");

            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mpname", SqlDbType.NVarChar,50),
					new SqlParameter("@mhaschild", SqlDbType.Bit,1),
					new SqlParameter("@murl", SqlDbType.NVarChar,100),
					new SqlParameter("@msort", SqlDbType.Int,4),
					new SqlParameter("@mtype", SqlDbType.NVarChar,5),
					new SqlParameter("@mshow", SqlDbType.Bit,1),
					new SqlParameter("@mdate", SqlDbType.DateTime),
					new SqlParameter("@mgroup", SqlDbType.NVarChar,30),
					new SqlParameter("@mstyle", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mcode;
            parameters[2].Value = model.mpcode;
            parameters[3].Value = model.mpname;
            parameters[4].Value = model.mhaschild;
            parameters[5].Value = model.murl;
            parameters[6].Value = model.msort;
            parameters[7].Value = model.mtype;
            parameters[8].Value = model.mshow;
            parameters[9].Value = model.mdate;
            parameters[10].Value = model.mgroup;
            parameters[11].Value = model.mstyle;
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
        public bool Update(Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Menu set ");
            strSql.Append("mname=@mname,");
            strSql.Append("mpcode=@mpcode,");
            strSql.Append("mpname=@mpname,");
            strSql.Append("mhaschild=@mhaschild,");
            strSql.Append("murl=@murl,");
            strSql.Append("msort=@msort,");
            strSql.Append("mtype=@mtype,");
            strSql.Append("mshow=@mshow,");
            strSql.Append("mdate=@mdate,");
            strSql.Append("mgroup=@mgroup,");
            strSql.Append("mstyle=@mstyle");
            strSql.Append(" where mcode=@mcode");
            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,50),
					new SqlParameter("@mpcode", SqlDbType.NVarChar,20),
					new SqlParameter("@mpname", SqlDbType.NVarChar,50),
					new SqlParameter("@mhaschild", SqlDbType.Bit,1),
					new SqlParameter("@murl", SqlDbType.NVarChar,100),
					new SqlParameter("@msort", SqlDbType.Int,4),
					new SqlParameter("@mtype", SqlDbType.NVarChar,5),
					new SqlParameter("@mshow", SqlDbType.Bit,1),
					new SqlParameter("@mdate", SqlDbType.DateTime),
                    new SqlParameter("@mgroup", SqlDbType.NVarChar,30),
                    new SqlParameter("@mstyle", SqlDbType.NVarChar,50),
					new SqlParameter("@mcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mpcode;
            parameters[2].Value = model.mpname;
            parameters[3].Value = model.mhaschild;
            parameters[4].Value = model.murl;
            parameters[5].Value = model.msort;
            parameters[6].Value = model.mtype;
            parameters[7].Value = model.mshow;
            parameters[8].Value = model.mdate;
            parameters[9].Value = model.mgroup;
            parameters[10].Value = model.mstyle;
            parameters[11].Value = model.mcode;
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
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Menu ");
            strSql.AppendFormat(" where  1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
 
        /// 得到一个对象实体
        /// </summary>
        public  Sys_Menu Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mname,mcode,mpcode,mpname,mhaschild,murl,msort,mtype,mshow,mdate,mgroup,mstyle from Sys_Menu ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_Menu r = new Sys_Menu();
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
        public  Sys_Menu DataRowToModel(DataRow row)
        {
             Sys_Menu model = new  Sys_Menu();
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
                if (row["mpcode"] != null)
                {
                    model.mpcode = row["mpcode"].ToString();
                }
                if (row["mpname"] != null)
                {
                    model.mpname = row["mpname"].ToString();
                }
                if (row["mhaschild"] != null && row["mhaschild"].ToString() != "")
                {
                    if ((row["mhaschild"].ToString() == "1") || (row["mhaschild"].ToString().ToLower() == "true"))
                    {
                        model.mhaschild = true;
                    }
                    else
                    {
                        model.mhaschild = false;
                    }
                }
                if (row["murl"] != null)
                {
                    model.murl = row["murl"].ToString();
                }
                if (row["msort"] != null && row["msort"].ToString() != "")
                {
                    model.msort = int.Parse(row["msort"].ToString());
                }
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["mshow"] != null && row["mshow"].ToString() != "")
                {
                    if ((row["mshow"].ToString() == "1") || (row["mshow"].ToString().ToLower() == "true"))
                    {
                        model.mshow = true;
                    }
                    else
                    {
                        model.mshow = false;
                    }
                }
                if (row["mdate"] != null && row["mdate"].ToString() != "")
                {
                    model.mdate = row["mdate"].ToString() ;
                }
                if (row["mgroup"] != null)
                {
                    model.mtype = row["mgroup"].ToString();
                }
                if (row["mstyle"] != null && row["mstyle"].ToString() != "")
                {
                    model.mstyle = row["mstyle"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Menu> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mname,mcode,mpcode,mpname,mhaschild,murl,msort,mtype,mshow,mdate,mgroup,mstyle ");
            strSql.AppendFormat(" FROM Sys_Menu where mshow='true' {0}", strWhere);
            List<Sys_Menu> r = new List<Sys_Menu>();
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
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Menu> QueryAllList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mname,mcode,mpcode,mpname,mhaschild,murl,msort,mtype,mshow,mdate,mgroup ,mstyle ");
            strSql.AppendFormat(" FROM Sys_Menu where 1=1 {0}", strWhere);
            List<Sys_Menu> r = new List<Sys_Menu>();
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
        public int DelRoleMenu(string rcode)
        {
            int n = 0; ;
            string sql = "delete from Sys_RMenuRole where rcode='" + rcode + "' ";
            n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            return n;
        }
        public int SetRoleMenu(DataTable dt)
        {
            int n = 0;
            StringBuilder strSql = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                string sql = string.Format("insert into Sys_RMenuRole (mcode,rcode) values ('{0}','{1}');", dr[0].ToString(), dr[1].ToString());
                strSql.Append(sql);
            }
            if (strSql.ToString() != "")
            {
                n = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, strSql);
            }
            return n;
        }
        public string GetRoleMenu(string rcode)
        {
            string menuv = "";
            string sql = "select  mcode from Sys_RMenuRole where rcode='" + rcode + "' ";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            { 
                foreach (DataRow dr in  dt.Rows)
                {
                    menuv += ";" + dr["mcode"].ToString();
                }
            }
            return menuv;
        }
        public int CreateCode(string pmcode)
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,mcode)),0) as n from Sys_Menu where mpcode='" + pmcode + "' ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public ArrayList QueryMenuGroup(string pmcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct (mgroup)  ");
            strSql.AppendFormat(" FROM Sys_Menu where mpcode='{0}' order by mgroup", pmcode);
            ArrayList r = new ArrayList();
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r.Add(dr["mgroup"].ToString());
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
