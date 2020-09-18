using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionAttrExDal : ISys_ProductionAttrExDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionAttrEx");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProductionAttrEx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionAttrEx(");
            strSql.Append("acode,aname,price,csql,bdcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@acode,@aname,@price,@csql,@bdcode,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@csql", SqlDbType.NVarChar,300),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.acode;
            parameters[1].Value = model.aname;
            parameters[2].Value = model.price;
            parameters[3].Value = model.csql;
            parameters[4].Value = model.bdcode;
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
        public bool Update( Sys_ProductionAttrEx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionAttrEx set ");
            strSql.Append("aname=@aname,");
            strSql.Append("price=@price,");
            strSql.Append("csql=@csql,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where acode=@acode");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@price", SqlDbType.Decimal,9),
					new SqlParameter("@csql", SqlDbType.NVarChar,300),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@acode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.price;
            parameters[2].Value = model.csql;
            parameters[3].Value = model.bdcode;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.acode;

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
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionAttrEx ");
            strSql.AppendFormat(" where 1=1 and acode='{0}' ;", where);
            strSql.Append("delete from Sys_RProductionAttrExCateAttrEx ");
            strSql.AppendFormat(" where 1=1 and acode='{0}' ;", where);
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
        public  Sys_ProductionAttrEx Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,acode,aname,price,csql,bdcode,maker,cdate from Sys_ProductionAttrEx ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionAttrEx r = new Sys_ProductionAttrEx();
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
        public  Sys_ProductionAttrEx DataRowToModel(DataRow row)
        {
             Sys_ProductionAttrEx model = new  Sys_ProductionAttrEx();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["csql"] != null)
                {
                    model.csql = row["csql"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionAttrEx> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,acode,aname,price,csql,bdcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ProductionAttrEx where 1=1 {0}", strWhere);
            List<Sys_ProductionAttrEx> r = new List<Sys_ProductionAttrEx>();
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
            sql = "select isnull(max(convert(int,acode)),0) as n from Sys_ProductionAttrEx ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
