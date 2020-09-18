using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_StatistcPartTypeDal : ISys_StatistcPartTypeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_StatistcPartType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_StatistcPartType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_StatistcPartType(");
            strSql.Append("tcname,tname,tcode,ttype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tcname,@tname,@tcode,@ttype,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ttype", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tname;
            parameters[2].Value = model.tcode;
            parameters[3].Value = model.ttype;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;

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
        public bool Update(Sys_StatistcPartType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_StatistcPartType set ");
            strSql.Append("tcname=@tcname,");
            strSql.Append("tname=@tname,");
            strSql.Append("ttype=@ttype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tcode=@tcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tcname", SqlDbType.NVarChar,30),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@ttype", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tcname;
            parameters[1].Value = model.tname;
            parameters[2].Value = model.ttype;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.tcode;

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
            strSql.Append("delete from Sys_StatistcPartType ");
            strSql.AppendFormat(" where tcode='{0}' ;", tcode);
            strSql.Append("delete from Sys_RInventoryStatistcPartType ");
            strSql.AppendFormat(" where tcode='{0}' ;", tcode);

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
        public Sys_StatistcPartType Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tcname,tname,tcode,ttype,maker,cdate from Sys_StatistcPartType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_StatistcPartType r = new Sys_StatistcPartType();
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
        public Sys_StatistcPartType DataRowToModel(DataRow row)
        {
            Sys_StatistcPartType model = new Sys_StatistcPartType();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tcname"] != null)
                {
                    model.tcname = row["tcname"].ToString();
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["ttype"] != null)
                {
                    model.ttype = row["ttype"].ToString();
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
        public List<Sys_StatistcPartType> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tcname,tname,tcode,ttype,maker,cdate ");
            strSql.Append(" FROM Sys_StatistcPartType ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_StatistcPartType> r = new List<Sys_StatistcPartType>();
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
            string sql = "";
            sql = "select isnull(max(convert(int, tcode)),0) as n from Sys_StatistcPartType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetInvPartType(string icode, string pcode)
        {
            StringBuilder sql = new StringBuilder();
            //sql.AppendFormat(" delete from Sys_RInventoryStatistcPartType where icode='{0}';", icode);
            string[] pl = pcode.Split(';');
            foreach (string p in pl)
            {
                sql.AppendFormat(" delete from Sys_RInventoryStatistcPartType where icode='{0}' and tcode='{1}';", icode, p);
                sql.AppendFormat(" insert into Sys_RInventoryStatistcPartType ( icode,tcode) values ('{0}','{1}')", icode, p);
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
        public int ReSetInvPartType(string icode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryStatistcPartType where icode='{0}';", icode);
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
        public string GetInvPartType(string icode)
        {
            string r = "";
            string sql = "select tcode from Sys_RInventoryStatistcPartType where icode='" + icode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["tcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
