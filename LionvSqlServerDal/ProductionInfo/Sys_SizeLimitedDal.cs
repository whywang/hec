using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_SizeLimitedDal : ISys_SizeLimitedDal
    {

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SizeLimited model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SizeLimited(");
            strSql.Append("lcode,lname,dcode,hmin,hmax,kmin,kmax,dmin,dmax,ttip,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@lcode,@lname,@dcode,@hmin,@hmax,@kmin,@kmax,@dmin,@dmax,@ttip,@maker,@cdate)");
     
            SqlParameter[] parameters = {
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@hmin", SqlDbType.Int,4),
					new SqlParameter("@hmax", SqlDbType.Int,4),
					new SqlParameter("@kmin", SqlDbType.Int,4),
					new SqlParameter("@kmax", SqlDbType.Int,4),
					new SqlParameter("@dmin", SqlDbType.Int,4),
					new SqlParameter("@dmax", SqlDbType.Int,4),
					new SqlParameter("@ttip", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.lcode;
            parameters[1].Value = model.lname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.hmin;
            parameters[4].Value = model.hmax;
            parameters[5].Value = model.kmin;
            parameters[6].Value = model.kmax;
            parameters[7].Value = model.dmin;
            parameters[8].Value = model.dmax;
            parameters[9].Value = model.ttip;
            parameters[10].Value = model.maker;
            parameters[11].Value = model.cdate;

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
        public bool Update(Sys_SizeLimited model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SizeLimited set ");
            strSql.Append("lname=@lname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("hmin=@hmin,");
            strSql.Append("hmax=@hmax,");
            strSql.Append("kmin=@kmin,");
            strSql.Append("kmax=@kmax,");
            strSql.Append("dmin=@dmin,");
            strSql.Append("dmax=@dmax,");
            strSql.Append("ttip=@ttip,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where lcode=@lcode");
            SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@hmin", SqlDbType.Int,4),
					new SqlParameter("@hmax", SqlDbType.Int,4),
					new SqlParameter("@kmin", SqlDbType.Int,4),
					new SqlParameter("@kmax", SqlDbType.Int,4),
					new SqlParameter("@dmin", SqlDbType.Int,4),
					new SqlParameter("@dmax", SqlDbType.Int,4),
					new SqlParameter("@ttip", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.lname;
            parameters[1].Value = model.dcode;
            parameters[2].Value = model.hmin;
            parameters[3].Value = model.hmax;
            parameters[4].Value = model.kmin;
            parameters[5].Value = model.kmax;
            parameters[6].Value = model.dmin;
            parameters[7].Value = model.dmax;
            parameters[8].Value = model.ttip;
            parameters[9].Value = model.maker;
            parameters[10].Value = model.cdate;
            parameters[11].Value = model.lcode;

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
        public bool Delete(string lcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SizeLimited ");
            strSql.AppendFormat(" where lcode='{0}';", lcode);
            strSql.Append("delete from Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" where lcode='{0}';", lcode);
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
        public Sys_SizeLimited Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   top 1 id,lcode,lname,dcode,hmin,hmax,kmin,kmax,dmin,dmax,ttip,maker,cdate from Sys_SizeLimited  ");
            strSql.AppendFormat(" where  1=1 {0}",where);
            Sys_SizeLimited r = new Sys_SizeLimited();
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
        public Sys_SizeLimited DataRowToModel(DataRow row)
        {
            Sys_SizeLimited model = new Sys_SizeLimited();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lcode"] != null)
                {
                    model.lcode = row["lcode"].ToString();
                }
                if (row["lname"] != null)
                {
                    model.lname = row["lname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["hmin"] != null && row["hmin"].ToString() != "")
                {
                    model.hmin = int.Parse(row["hmin"].ToString());
                }
                if (row["hmax"] != null && row["hmax"].ToString() != "")
                {
                    model.hmax = int.Parse(row["hmax"].ToString());
                }
                if (row["kmin"] != null && row["kmin"].ToString() != "")
                {
                    model.kmin = int.Parse(row["kmin"].ToString());
                }
                if (row["kmax"] != null && row["kmax"].ToString() != "")
                {
                    model.kmax = int.Parse(row["kmax"].ToString());
                }
                if (row["dmin"] != null && row["dmin"].ToString() != "")
                {
                    model.dmin = int.Parse(row["dmin"].ToString());
                }
                if (row["dmax"] != null && row["dmax"].ToString() != "")
                {
                    model.dmax = int.Parse(row["dmax"].ToString());
                }
                if (row["ttip"] != null)
                {
                    model.ttip = row["ttip"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SizeLimited> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  id,lcode,lname,dcode,hmin,hmax,kmin,kmax,dmin,dmax,ttip,maker,cdate  ");
            strSql.AppendFormat(" FROM Sys_SizeLimited where 1=1 {0}",strWhere);
            List<Sys_SizeLimited> r = new List<Sys_SizeLimited>();
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
            sql = "select isnull(max(lcode),0) as n from Sys_SizeLimited ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetSizeLimitedCate(string icode, string lcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" where icode='{0}';", icode);
            strSql.Append("insert into  Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" (icode,lcode) values ('{0}','{1}') ;", icode, lcode);
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
        public bool ReSetSizeLimitedCate(string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventorySizeLimited ");
            strSql.AppendFormat(" where icode='{0}';", icode);

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
        public string GetSizeLimitedCate(string icode)
        {
            string r = "";
            string sql = "select lcode from Sys_RInventorySizeLimited where icode='" + icode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                r = dt.Rows[0][0].ToString();
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
