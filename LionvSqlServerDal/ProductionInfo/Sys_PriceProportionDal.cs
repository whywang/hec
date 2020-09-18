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
    public class Sys_PriceProportionDal : ISys_PriceProportionDal
    {
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_PriceProportion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_PriceProportion(");
            strSql.Append("ppname,ppcode,ppbl,pcbbl,pqtbl,maker,cdate,pbz)");
            strSql.Append(" values (");
            strSql.Append("@ppname,@ppcode,@ppbl,@pcbbl,@pqtbl,@maker,@cdate,@pbz)");
            SqlParameter[] parameters = {
					new SqlParameter("@ppname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ppbl", SqlDbType.Decimal,9),
					new SqlParameter("@pcbbl", SqlDbType.Decimal,9),
					new SqlParameter("@pqtbl", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pbz", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ppname;
            parameters[1].Value = model.ppcode;
            parameters[2].Value = model.ppbl;
            parameters[3].Value = model.pcbbl;
            parameters[4].Value = model.pqtbl;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.pbz;
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
        public bool Update(Sys_PriceProportion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_PriceProportion set ");
            strSql.Append("ppname=@ppname,");
            strSql.Append("ppbl=@ppbl,");
            strSql.Append("pcbbl=@pcbbl,");
            strSql.Append("pqtbl=@pqtbl,");
            strSql.Append("maker=@maker,");
            strSql.Append("pbz=@pbz,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ppcode=@ppcode");
            SqlParameter[] parameters = {
					new SqlParameter("@ppname", SqlDbType.NVarChar,30),
					new SqlParameter("@ppbl", SqlDbType.Decimal,9),
					new SqlParameter("@pcbbl", SqlDbType.Decimal,9),
					new SqlParameter("@pqtbl", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@pbz", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ppcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.ppname;
            parameters[1].Value = model.ppbl;
            parameters[2].Value = model.pcbbl;
            parameters[3].Value = model.pqtbl;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.pbz;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.ppcode;

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
        public bool Delete(string ppcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_PriceProportion ");
            strSql.AppendFormat(" where ppcode='{0}';", ppcode);
            strSql.AppendFormat("delete from Sys_RInventoryPriceProportion where ppcode='{0}'", ppcode);
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
        public Sys_PriceProportion Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ppname,ppcode,ppbl,pcbbl,pqtbl,maker,cdate,pbz from Sys_PriceProportion ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_PriceProportion r = new Sys_PriceProportion();
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
        public Sys_PriceProportion DataRowToModel(DataRow row)
        {
            Sys_PriceProportion model = new Sys_PriceProportion();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ppname"] != null)
                {
                    model.ppname = row["ppname"].ToString();
                }
                if (row["ppcode"] != null)
                {
                    model.ppcode = row["ppcode"].ToString();
                }
                if (row["ppbl"] != null && row["ppbl"].ToString() != "")
                {
                    model.ppbl = decimal.Parse(row["ppbl"].ToString());
                }
                if (row["pcbbl"] != null && row["pcbbl"].ToString() != "")
                {
                    model.pcbbl = decimal.Parse(row["pcbbl"].ToString());
                }
                if (row["pqtbl"] != null && row["pqtbl"].ToString() != "")
                {
                    model.pqtbl = decimal.Parse(row["pqtbl"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["pbz"] != null)
                {
                    model.pbz = row["pbz"].ToString();
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
        public List<Sys_PriceProportion> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ppname,ppcode,ppbl,pcbbl,pqtbl,maker,cdate,pbz ");
            strSql.Append(" FROM Sys_PriceProportion ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_PriceProportion> r = new List<Sys_PriceProportion>();
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
            sql = "select isnull(max(convert(int, ppcode)),0) as n from Sys_PriceProportion ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetPriceBl(string icode, string ppcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPriceProportion where icode='{0}'  ;", icode);
            sql.AppendFormat(" insert into  Sys_RInventoryPriceProportion (icode,ppcode) values ('{0}','{1}');", icode, ppcode);
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
        public int ReSetPriceBl(string icode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryPriceProportion where icode='{0}'  ;", icode);
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
        public string GetSetPriceBl(string icode)
        {
            string r = "";
            r = LoodQuery(icode);
            return r;
        }
        private string LoodQuery(string pcode)
        {
            string p = "";
            if (pcode.Length > 0)
            {
                string sql = "select ppcode from Sys_RInventoryPriceProportion where icode='" + pcode + "'";
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
                if (dt != null)
                {
                    p = dt.Rows[0][0].ToString();
                }
                else
                {
                    p = LoodQuery(pcode.Substring(0, pcode.Length - 3));
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
