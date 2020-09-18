using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ComponentCateDal : ISys_ComponentCateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ComponentCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
         
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ComponentCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ComponentCate(");
            strSql.Append("ccname,cccode,ctype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@ccname,@cccode,@ctype,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@cccode", SqlDbType.NVarChar,20),
					new SqlParameter("@ctype", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.ccname;
            parameters[1].Value = model.cccode;
            parameters[2].Value = model.ctype;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
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
        public bool Update(Sys_ComponentCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ComponentCate set ");
            strSql.Append("ccname=@ccname,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where cccode=@cccode");
            SqlParameter[] parameters = {
					new SqlParameter("@ccname", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@cccode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ccname;
            parameters[1].Value = model.ctype;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.cccode;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }

        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_ComponentCate where cccode='{0}';", ccode);
            strSql.AppendFormat("delete from Sys_Component where cccode='{0}'", ccode);
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
        public Sys_ComponentCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ccname,cccode,ctype,maker,cdate from Sys_ComponentCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ComponentCate r = new Sys_ComponentCate();
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
        public Sys_ComponentCate DataRowToModel(DataRow row)
        {
            Sys_ComponentCate model = new  Sys_ComponentCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ccname"] != null)
                {
                    model.ccname = row["ccname"].ToString();
                }
                if (row["cccode"] != null)
                {
                    model.cccode = row["cccode"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ComponentCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ccname,cccode,ctype,maker,cdate ");
            strSql.Append(" FROM Sys_ComponentCate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ComponentCate> r = new List<Sys_ComponentCate>();
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
        public int CreateCode(string where)
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int, cccode)),0) as n from Sys_ComponentCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetInvComCate(string icode, string ccode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RinvertoryComponent where icode='{0}'  ;", icode);
            sql.AppendFormat(" insert into  Sys_RinvertoryComponent (icode,ccode) values ('{0}','{1}');", icode, ccode);
            if (sql.ToString() != "")
            {
                try
                {
                    r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                }
                catch
                {
                    r = -1;
                }
            }
            return r;
        }
        public int ReSetInvComCate(string icode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RinvertoryComponent where icode='{0}'  ;", icode);
            if (sql.ToString() != "")
            {
                try
                {
                    r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null);
                }
                catch
                {
                    r = -1;
                }
            }
            return r;
        }
        public string GetInvComCate(string icode)
        {
            string r = "";
            r = LoodQuery(icode);
            return r;
        }
        private string LoodQuery(string icode)
        {
            string p = "";
            if (icode.Length > 8)
            {

                string sql = "select ccode from Sys_RinvertoryComponent where icode='" + icode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(icode.Substring(0, icode.Length - 3));
                }
            }
            else
            {
                p = "";
            }
            return p;
        }
        #endregion  ExtensionMethod
    }
}
