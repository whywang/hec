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
   public class Sys_XsOverCondtionCategoryDal : ISys_XsOverCondtionCategoryDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_XsOverCondtionCategory");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_XsOverCondtionCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_XsOverCondtionCategory(");
            strSql.Append("oname,ocode,ounit,otype,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@oname,@ocode,@ounit,@otype,@maker,@cdate,@dcode)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,30),
					new SqlParameter("@ocode", SqlDbType.NVarChar,30),
					new SqlParameter("@ounit", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.oname;
            parameters[1].Value = model.ocode;
            parameters[2].Value = model.ounit;
            parameters[3].Value = model.otype;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.dcode;
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
        public bool Update( Sys_XsOverCondtionCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_XsOverCondtionCategory set ");
            strSql.Append("oname=@oname,");
            strSql.Append("ounit=@ounit,");
            strSql.Append("otype=@otype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ocode=@ocode");
            SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,30),
					new SqlParameter("@ounit", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ocode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.oname;
            parameters[1].Value = model.ounit;
            parameters[2].Value = model.otype;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.ocode;

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
        public bool Delete(string ocode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_XsOverCondtionCategory ");
            strSql.AppendFormat(" where ocode='{0}'; ", ocode);
            strSql.Append("delete from Sys_RInventoryXsOverCondition ");
            strSql.AppendFormat(" where ocode='{0}'; ", ocode);
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
        public  Sys_XsOverCondtionCategory Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,oname,ocode,ounit,otype,maker,cdate,dcode from Sys_XsOverCondtionCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_XsOverCondtionCategory r = new Sys_XsOverCondtionCategory();
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
        public  Sys_XsOverCondtionCategory DataRowToModel(DataRow row)
        {
             Sys_XsOverCondtionCategory model = new  Sys_XsOverCondtionCategory();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["oname"] != null)
                {
                    model.oname = row["oname"].ToString();
                }
                if (row["ocode"] != null)
                {
                    model.ocode = row["ocode"].ToString();
                }
                if (row["ounit"] != null)
                {
                    model.ounit = row["ounit"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_XsOverCondtionCategory> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,oname,ocode,ounit,otype,maker,cdate,dcode ");
            strSql.AppendFormat(" FROM Sys_XsOverCondtionCategory where 1=1 {0}", strWhere);
            List<Sys_XsOverCondtionCategory> r = new List<Sys_XsOverCondtionCategory>();
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
            sql = "select isnull(max(convert(int,ocode)),0) as n from Sys_XsOverCondtionCategory ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
