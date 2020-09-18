using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ConsumeMaterialDal : ISys_ConsumeMaterialDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ConsumeMaterial");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ConsumeMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ConsumeMaterial(");
            strSql.Append("mname,mcode,pmcode,pmname,mlength,mwidth,mdeep,munit,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@mname,@mcode,@pmcode,@pmname,@mlength,@mwidth,@mdeep,@munit,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmname", SqlDbType.NVarChar,30),
					new SqlParameter("@mlength", SqlDbType.Int,4),
					new SqlParameter("@mwidth", SqlDbType.Int,4),
					new SqlParameter("@mdeep", SqlDbType.Int,4),
					new SqlParameter("@munit", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.mcode;
            parameters[2].Value = model.pmcode;
            parameters[3].Value = model.pmname;
            parameters[4].Value = model.mlength;
            parameters[5].Value = model.mwidth;
            parameters[6].Value = model.mdeep;
            parameters[7].Value = model.munit;
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
        public bool Update(Sys_ConsumeMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ConsumeMaterial set ");
            strSql.Append("mname=@mname,");
            strSql.Append("pmcode=@pmcode,");
            strSql.Append("pmname=@pmname,");
            strSql.Append("mlength=@mlength,");
            strSql.Append("mwidth=@mwidth,");
            strSql.Append("mdeep=@mdeep,");
            strSql.Append("munit=@munit,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where mcode=@mcode");
            SqlParameter[] parameters = {
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@pmcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmname", SqlDbType.NVarChar,30),
					new SqlParameter("@mlength", SqlDbType.Int,4),
					new SqlParameter("@mwidth", SqlDbType.Int,4),
					new SqlParameter("@mdeep", SqlDbType.Int,4),
					new SqlParameter("@munit", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@mcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.mname;
            parameters[1].Value = model.pmcode;
            parameters[2].Value = model.pmname;
            parameters[3].Value = model.mlength;
            parameters[4].Value = model.mwidth;
            parameters[5].Value = model.mdeep;
            parameters[6].Value = model.munit;
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
            strSql.Append("delete from Sys_ConsumeMaterial ");
            strSql.AppendFormat(" where mcode='{0}' ", mcode);

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
        public Sys_ConsumeMaterial Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,mname,mcode,pmcode,pmname,mlength,mwidth,mdeep,munit,maker,cdate from Sys_ConsumeMaterial ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ConsumeMaterial r = new Sys_ConsumeMaterial();
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
        public Sys_ConsumeMaterial DataRowToModel(DataRow row)
        {
            Sys_ConsumeMaterial model = new Sys_ConsumeMaterial();
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
                if (row["pmcode"] != null)
                {
                    model.pmcode = row["pmcode"].ToString();
                }
                if (row["pmname"] != null)
                {
                    model.pmname = row["pmname"].ToString();
                }
                if (row["mlength"] != null && row["mlength"].ToString() != "")
                {
                    model.mlength = int.Parse(row["mlength"].ToString());
                }
                if (row["mwidth"] != null && row["mwidth"].ToString() != "")
                {
                    model.mwidth = int.Parse(row["mwidth"].ToString());
                }
                if (row["mdeep"] != null && row["mdeep"].ToString() != "")
                {
                    model.mdeep = int.Parse(row["mdeep"].ToString());
                }
                if (row["munit"] != null)
                {
                    model.munit = row["munit"].ToString();
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
        public List<Sys_ConsumeMaterial> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,mname,mcode,pmcode,pmname,mlength,mwidth,mdeep,munit,maker,cdate ");
            strSql.Append(" FROM Sys_ConsumeMaterial ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ConsumeMaterial> r = new List<Sys_ConsumeMaterial>();
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
        public int CreateCode(string pmcode)
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,substring(mcode,len(mcode)-2,3))),0) as n from Sys_ConsumeMaterial where pmcode='" + pmcode + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
