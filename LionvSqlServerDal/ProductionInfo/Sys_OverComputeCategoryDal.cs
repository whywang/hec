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
    public partial class Sys_OverComputeCategoryDal : ISys_OverComputeCategoryDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ocode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_OverComputeCategory");
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_OverComputeCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_OverComputeCategory(");
            strSql.Append("oname,ocode,ounit,otype,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@oname,@ocode,@ounit,@otype,@maker,@cdate,@dcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,20),
					new SqlParameter("@ocode", SqlDbType.NVarChar,20),
					new SqlParameter("@ounit", SqlDbType.NVarChar,10),
                    new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.oname;
            parameters[1].Value = model.ocode;
            parameters[2].Value = model.ounit;
            parameters[3].Value = model.otype;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.dcode;
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
        public bool Update( Sys_OverComputeCategory model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_OverComputeCategory set ");
            strSql.Append("oname=@oname,");
            strSql.Append("ounit=@ounit,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("otype=@otype ");
            strSql.Append(" where ocode=@ocode;");
            SqlParameter[] parameters = {
					new SqlParameter("@oname", SqlDbType.NVarChar,20),
					new SqlParameter("@ounit", SqlDbType.NVarChar,10),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@ocode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.oname;
            parameters[1].Value = model.ounit;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.ocode;
            strSql.AppendFormat("update Sys_OverCondition  set oname='{0}' where ocode='{1}'", model.oname, model.ocode);
          
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
        public bool Delete(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryOverCondition ");
            strSql.AppendFormat(" where ocode='{0}';", code);
            strSql.Append("delete from Sys_OverCondition ");
            strSql.AppendFormat(" where ocode='{0}';", code);
            strSql.Append("delete from Sys_OverComputeCategory ");
            strSql.AppendFormat(" where  ocode='{0}';", code);
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
        public  Sys_OverComputeCategory Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,oname,ocode,ounit,otype,maker,cdate from Sys_OverComputeCategory ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_OverComputeCategory r = new  Sys_OverComputeCategory();
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
        public  Sys_OverComputeCategory DataRowToModel(DataRow row)
        {
             Sys_OverComputeCategory model = new  Sys_OverComputeCategory();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_OverComputeCategory> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   id,oname,ocode,ounit,otype,maker,cdate from Sys_OverComputeCategory ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<Sys_OverComputeCategory> r = new List<Sys_OverComputeCategory>();
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
            sql = "select isnull(max(convert(int,ocode)),0) as n from Sys_OverComputeCategory ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
