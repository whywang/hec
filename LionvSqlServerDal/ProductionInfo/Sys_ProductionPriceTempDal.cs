using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.ProductionInfo
{
     
    public class Sys_ProductionPriceTempDal : ISys_ProductionPriceTempDal
    {
        
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ptcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionPriceTemp");
            strSql.AppendFormat(" where 1=1 {0} ", ptcode);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionPriceTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionPriceTemp(");
            strSql.Append("ptname,ptcode,ppname,ppcode,ptemp,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@ptname,@ptcode,@ppname,@ppcode,@ptemp,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ppname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptemp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.ptname;
            parameters[1].Value = model.ptcode;
            parameters[2].Value = model.ppname;
            parameters[3].Value = model.ppcode;
            parameters[4].Value = model.ptemp;
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
        public bool Update(Sys_ProductionPriceTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionPriceTemp set ");
            strSql.Append("ptname=@ptname,");
            strSql.Append("ppname=@ppname,");
            strSql.Append("ppcode=@ppcode,");
            strSql.Append("ptemp=@ptemp,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ptcode=@ptcode");
            SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ptemp", SqlDbType.NVarChar,-1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ptname;
            parameters[1].Value = model.ppname;
            parameters[2].Value = model.ppcode;
            parameters[3].Value = model.ptemp;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.ptcode;

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
        public bool Delete(string ptcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionPriceTemp ");
            strSql.AppendFormat(" where ptcode='{0}' ; ", ptcode);
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
        public Sys_ProductionPriceTemp Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ptname,ptcode,ppname,ppcode,ptemp,maker,cdate from Sys_ProductionPriceTemp ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            Sys_ProductionPriceTemp r = new Sys_ProductionPriceTemp();
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
        public Sys_ProductionPriceTemp DataRowToModel(DataRow row)
        {
            Sys_ProductionPriceTemp model = new Sys_ProductionPriceTemp();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ptname"] != null)
                {
                    model.ptname = row["ptname"].ToString();
                }
                if (row["ptcode"] != null)
                {
                    model.ptcode = row["ptcode"].ToString();
                }
                if (row["ppname"] != null)
                {
                    model.ppname = row["ppname"].ToString();
                }
                if (row["ppcode"] != null)
                {
                    model.ppcode = row["ppcode"].ToString();
                }
                if (row["ptemp"] != null)
                {
                    model.ptemp = row["ptemp"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionPriceTemp> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ptname,ptcode,ppname,ppcode,ptemp,maker,cdate ");
            strSql.Append(" FROM Sys_ProductionPriceTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionPriceTemp> r = new List<Sys_ProductionPriceTemp>();
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
            sql = "select isnull(max(convert(int, ptcode)),0) as n from Sys_ProductionPriceTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
