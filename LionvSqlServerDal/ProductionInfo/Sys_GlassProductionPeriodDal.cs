using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_GlassProductionPeriodDal : ISys_GlassProductionPeriodDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_GlassProductionPeriod");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_GlassProductionPeriod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_GlassProductionPeriod(");
            strSql.Append("gqname,gqcode,fname,fcode,gqnum,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@gqname,@gqcode,@fname,@fcode,@gqnum,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@gqname", SqlDbType.NVarChar,30),
					new SqlParameter("@gqcode", SqlDbType.NVarChar,50),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@gqnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.gqname;
            parameters[1].Value = model.gqcode;
            parameters[2].Value = model.fname;
            parameters[3].Value = model.fcode;
            parameters[4].Value = model.gqnum;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;

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
        public bool Update(Sys_GlassProductionPeriod model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_GlassProductionPeriod set ");
            strSql.Append("gqname=@gqname,");
            strSql.Append("fname=@fname,");
            strSql.Append("fcode=@fcode,");
            strSql.Append("gqnum=@gqnum,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where gqcode=@gqcode");
            SqlParameter[] parameters = {
					new SqlParameter("@gqname", SqlDbType.NVarChar,30),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@gqnum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gqcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.gqname;
            parameters[1].Value = model.fname;
            parameters[2].Value = model.fcode;
            parameters[3].Value = model.gqnum;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.gqcode;

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
        public bool Delete(string gqcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_GlassProductionPeriod ");
            strSql.AppendFormat(" where gqcode='{0}';", gqcode);
            strSql.Append("delete from Sys_RProductionPeriod ");
            strSql.AppendFormat(" where gqcode='{0}';", gqcode);
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
        public Sys_GlassProductionPeriod Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,gqname,gqcode,fname,fcode,gqnum,maker,cdate from Sys_GlassProductionPeriod ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_GlassProductionPeriod r = new Sys_GlassProductionPeriod();
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
        public Sys_GlassProductionPeriod DataRowToModel(DataRow row)
        {
            Sys_GlassProductionPeriod model = new Sys_GlassProductionPeriod();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["gqname"] != null)
                {
                    model.gqname = row["gqname"].ToString();
                }
                if (row["gqcode"] != null)
                {
                    model.gqcode = row["gqcode"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
                }
                if (row["gqnum"] != null && row["gqnum"].ToString() != "")
                {
                    model.gqnum = int.Parse(row["gqnum"].ToString());
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
        public List<Sys_GlassProductionPeriod> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,gqname,gqcode,fname,fcode,gqnum,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_GlassProductionPeriod where 1=1 {0}", strWhere);
            List<Sys_GlassProductionPeriod> r = new List<Sys_GlassProductionPeriod>();
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
            sql = "select isnull(max(convert(int,gqcode)),0) as n from Sys_GlassProductionPeriod ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetGlassPeriod(string icode, string fcode, string gqcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RGlassProductionPeriod where fcode ='{0}' and icode='{1}' ;", fcode, icode);
            sql.AppendFormat(" insert into Sys_RGlassProductionPeriod (icode,fcode,gqcode) values ('{0}','{1}','{2}') ;", icode, fcode, gqcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetGlassPeriod(string icode, string fcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RGlassProductionPeriod where fcode ='{0}' and icode='{1}' ;", fcode, icode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetGlassPeriod(string icode, string fcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gqcode ");
            strSql.AppendFormat(" FROM Sys_RGlassProductionPeriod where fcode='{0}' and icode='{1}'", fcode, icode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["gqcode"].ToString() + ";";
                }
                if (r.Length > 1)
                {
                    r = r.Substring(0, r.Length - 1);
                }
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
