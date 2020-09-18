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
    public class Sys_PriceTypeDal : ISys_PriceTypeDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_PriceType");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_PriceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_PriceType(");
            strSql.Append("ptname,ptcode,ptype,pms,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@ptname,@ptcode,@ptype,@pms,@maker,@cdate,@dcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,20),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@pms", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ptname;
            parameters[1].Value = model.ptcode;
            parameters[2].Value = model.ptype;
            parameters[3].Value = model.pms;
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
        public bool Update(Sys_PriceType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_PriceType set ");
            strSql.Append("ptname=@ptname,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("pms=@pms,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ptcode=@ptcode");
            SqlParameter[] parameters = {
					new SqlParameter("@ptname", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@pms", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ptcode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ptname;
            parameters[1].Value = model.ptype;
            parameters[2].Value = model.pms;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.ptcode;
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
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_PriceType ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public  Sys_PriceType Query(string  where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ptname,ptcode,ptype,pms,maker,cdate from Sys_PriceType ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_PriceType r = new Sys_PriceType();
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
        public Sys_PriceType DataRowToModel(DataRow row)
        {
            Sys_PriceType model = new Sys_PriceType();
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
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["pms"] != null)
                {
                    model.pms = row["pms"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_PriceType> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ptname,ptcode,ptype,pms,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_PriceType where 1=1 {0}", strWhere);
            List<Sys_PriceType> r = new List<Sys_PriceType>();
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
        #region 获取价格类型编号
        public int CreateCode()
        {
            int r = -1;
            string sql = "";
            sql = "select isnull(max(convert(int,ptcode)),0) as n from Sys_PriceType ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion
        #region 设置获取价格
        public int SetPrice(string ptcode, string[] pcodearr, string plx, decimal price, decimal tcprice, decimal pprice, string uname)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            if (pcodearr.Length > 0)
            {
                for (int i = 0; i < pcodearr.Length; i++)
                {
                    sql.AppendFormat(" delete from Sys_RPriceTypeInventoryDetail where ptcode='{0}' and pcode='{1}' and plx='{2}';", ptcode, pcodearr[i], plx);
                    sql.AppendFormat(" insert into  Sys_RPriceTypeInventoryDetail (pname,pcode,ptcode,plx,price,tcprice,pprice,maker,cdate) values ('','{0}','{1}','{2}',{3},{4},{5},'{6}','{7}');", pcodearr[i], ptcode, plx, price, tcprice, pprice, uname, DateTime.Now.ToString());
                }
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
            }
            return r;
        }
        public decimal[] GetPrice(string ptcode, string pcode, string plx)
        {
            decimal []r = new decimal[3];
            string sql = "select price ,tcprice,pprice from Sys_RPriceTypeInventoryDetail where ptcode='"+ptcode+"' and pcode='"+pcode+"' and plx='"+plx+"' ";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql.ToString(), null);
            if (dt != null)
            {
               r[0] =Convert.ToDecimal( dt.Rows[0]["price"].ToString());
               r[1] =Convert.ToDecimal(dt.Rows[0]["tcprice"].ToString());
               r[2] = Convert.ToDecimal(dt.Rows[0]["pprice"].ToString());
            }
            else
            {
                r[0] = 0;
                r[1] = 0;
                r[2] = 0;
            }
            return r;

        }
        #endregion
        #region 设置代理商供货价格
        public int SetAgentsPrice(string dcode, string ptcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeAgent where ptcode in(select ptcode from Sys_PriceType where ptype=(select ptype from Sys_PriceType where ptcode='{0}')) and dcode='{1}';", ptcode, dcode);
            sql.AppendFormat(" insert into Sys_RPriceTypeAgent (ptcode,dcode) values ('{0}','{1}');", ptcode, dcode );
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
        public int ReSetAgentsPrice(string dcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeAgent where  dcode='{0}';",  dcode);
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
        #endregion
        #region 获取代理商供货价格
        public string GetAgentsPrice(string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptcode  ");
            strSql.AppendFormat(" FROM Sys_RPriceTypeAgent where dcode='{0}'", dcode);
 
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr[0].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public string GetDlsPrice(string dcode,string ptx)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            if (ptx == "xs")
            {
                strSql.Append("select top 1 ptcode  ");
                strSql.AppendFormat(" FROM Sys_RPriceTypeSaleAgent where dcode='{0}' and ", dcode);
            }
            if (ptx == "gh")
            {
                strSql.Append("select top 1 ptcode  ");
                strSql.AppendFormat(" FROM Sys_RPriceTypeAgent where dcode='{0}' and ", dcode);
            }
            if (dcode != "")
            {
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0][0].ToString();
                }
                else
                {
                    r = LoopDxlPrice(dcode.Substring(0, dcode.Length - 4),ptx);
                }
            }
            return r;
        }
        private string LoopDxlPrice(string dcode,string ptx)
        {
            string r = "";
            if (dcode.Length > 2)
            {
                StringBuilder strSql = new StringBuilder();
                if (ptx == "xs")
                {
                    strSql.Append("select top 1 ptcode  ");
                    strSql.AppendFormat(" FROM Sys_RPriceTypeSaleAgent where dcode='{0}'", dcode);
                }
                if (ptx == "gh")
                {
                    strSql.Append("select top 1 ptcode  ");
                    strSql.AppendFormat(" FROM Sys_RPriceTypeAgent where dcode='{0}'", dcode);
                }
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0][0].ToString();
                }
                else
                {
                    r = LoopDxlPrice(dcode.Substring(0, dcode.Length - 4),ptx);
                }
            }
            return r;
        }
        #endregion
        #region 设置代理商销售价格
        public int SetAgentsSalePrice(string dcode, string ptcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeSaleAgent where ptcode in(select ptcode from Sys_PriceType where ptype=(select ptype from Sys_PriceType where ptcode='{0}')) and dcode='{1}';", ptcode, dcode);
            sql.AppendFormat(" insert into Sys_RPriceTypeSaleAgent (ptcode,dcode) values ('{0}','{1}');", ptcode, dcode);
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
        public int ReSetAgentsSalePrice(string dcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeSaleAgent where dcode='{0}';", dcode);
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
        #endregion
        #region 获取代理商供货价格
        public string GetAgentsSalePrice(string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptcode  ");
            strSql.AppendFormat(" FROM Sys_RPriceTypeSaleAgent where dcode='{0}'", dcode);

            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr[0].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        public string GetDlsSalePrice(string dcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 ptcode  ");
            strSql.AppendFormat(" FROM Sys_RPriceTypeSaleAgent where dcode='{0}'", dcode);
            if (dcode != "")
            {
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0][0].ToString();
                }
                else
                {
                    r = LoopDxlSalePrice(dcode.Substring(0, dcode.Length - 2));
                }
            }
            return r;
        }
        private string LoopDxlSalePrice(string dcode)
        {
            string r = "";
            if (dcode.Length > 2)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select top 1 ptcode  ");
                strSql.AppendFormat(" FROM Sys_RPriceTypeSaleAgent where dcode='{0}'", dcode);

                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0][0].ToString();
                }
                else
                {
                    r = LoopDxlSalePrice(dcode.Substring(0, dcode.Length - 2));
                }
            }
            return r;
        }
        #endregion
        #region 设置获取工厂价格
        public int SetFactoryPrice( string ptcode,string dcode,string cdcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeFactory where ptcode in(select ptcode from Sys_PriceType where ptype=(select ptype from Sys_PriceType where ptcode='{0}')) and dcode='{1}' and cdcode='{2}';", ptcode, dcode,cdcode);
            sql.AppendFormat(" insert into  Sys_RPriceTypeFactory (ptcode,dcode,cdcode) values ('{0}','{1}','{2}');", ptcode, dcode,cdcode);
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
        public int ReSetFactoryPrice(string dcode,string cdcode)
        {
            int r = 0;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RPriceTypeFactory where  dcode='{0}' and cdcode='{1}';", dcode,cdcode);
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
        public string GetFactoryPrice(string dcode,string cdcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ptcode  ");
            strSql.AppendFormat(" FROM Sys_RPriceTypeFactory where dcode='{0}'and cdcode='{1}'", dcode,cdcode);

            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr[0].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion
        #region 获取产品组供货价格
        public decimal QueryGPrice(string dcode,string pcode,string mtcode)
        {
            string dtcode = GetDlsPrice(dcode,"gh");
            decimal r = 0;
            if (mtcode != "")
            {
                r = r + QueryGItem(dtcode, mtcode,true);
                r = r + QueryGItem(dtcode, pcode,false);
            }
            else
            {
                r = QueryGItem(dtcode, pcode,false);
            }
            return r;
        }
        private decimal QueryGItem(string acode, string pcode,bool ist)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.AppendFormat(" FROM Sys_RPriceTypeInventoryDetail where pcode='{0}' and ptcode='{1}' and plx='供货'", pcode, acode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                if (ist)
                {
                    r = r + Convert.ToDecimal(dt.Rows[0]["tcprice"].ToString());
                    r = r + Convert.ToDecimal(dt.Rows[0]["pprice"].ToString());
                }
                else
                {
                    r = r + Convert.ToDecimal(dt.Rows[0]["price"].ToString());
                    r = r + Convert.ToDecimal(dt.Rows[0]["pprice"].ToString());
                }
            }
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
