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
    public class Sys_AreaDal : ISys_AreaDal
    {
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Area model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Area(");
            strSql.Append("aname,acode,atype,cdate,maker,bdcode)");
            strSql.Append(" values (");
            strSql.Append("@aname,@acode,@atype,@cdate,@maker,@bdcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@atype", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.acode;
            parameters[2].Value = model.atype;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.bdcode;
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
        public bool Update(Sys_Area model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Area set ");
            strSql.Append("aname=@aname,");
            strSql.Append("atype=@atype,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker,");
            strSql.Append("bdcode=@bdcode");
            strSql.Append(" where acode=@acode");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@atype", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@bdcode", SqlDbType.NVarChar,20),
					new SqlParameter("@acode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.atype;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.bdcode;
            parameters[5].Value = model.acode;

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
        public bool Delete(string acode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Area ");
            strSql.AppendFormat(" where acode='{0}' ;",acode);
            strSql.Append("delete from Sys_RDepmentArea ");
            strSql.AppendFormat(" where acode='{0}' ;", acode);
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
        public Sys_Area Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,aname,acode,atype,cdate,maker,bdcode from Sys_Area ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_Area r = new Sys_Area();
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
        public Sys_Area DataRowToModel(DataRow row)
        {
            Sys_Area model = new Sys_Area();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["atype"] != null)
                {
                    model.atype = row["atype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Area> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,aname,acode,atype,cdate,maker,bdcode ");
            strSql.Append(" FROM Sys_Area ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_Area> r = new List<Sys_Area>();
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
            string sql = "select isnull(max(convert(int,acode)),0) as n from Sys_Area ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetAreaDepment(string acode, string[] adcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RDepmentArea ");
            strSql.AppendFormat(" where acode='{0}' ;", acode);
            for (int i = 0; i < adcode.Length; i++)
            {
                strSql.Append("insert into Sys_RDepmentArea ");
                strSql.AppendFormat("  (acode,dcode) values ('{0}','{1}') ;", acode,adcode[i]);
            }
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return 0;
            }
        }
        public int ReSetAreaDepment(string acode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RDepmentArea ");
            strSql.AppendFormat(" where acode='{0}' ;", acode);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return 0;
            }
        }
        public string GetAreaDepment(string acode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   dcode from Sys_RDepmentArea ");
            strSql.AppendFormat(" where acode='{0}'", acode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["dcode"].ToString() + ";";
                }
                r = r.Substring(0,r.Length - 1);
            }
            else
            {
                r ="";
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
