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
    public  class Sys_OverConditionDal : ISys_OverConditionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_OverCondition");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_OverCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_OverCondition(");
            strSql.Append("ccode,cname,oname,ocode,cattr,bvalue,tvalue,cfstr,cfscale,cxs,cpricetype,pricetx,pricetxtype,pcity,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@ccode,@cname,@oname,@ocode,@cattr,@bvalue,@tvalue,@cfstr,@cfscale,@cxs,@cpricetype,@pricetx,@pricetxtype,@pcity,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@ccode", SqlDbType.NVarChar,20),
					new SqlParameter("@cname", SqlDbType.NVarChar,20),
					new SqlParameter("@oname", SqlDbType.NVarChar,20),
					new SqlParameter("@ocode", SqlDbType.NVarChar,20),
					new SqlParameter("@cattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bvalue", SqlDbType.Decimal,9),
					new SqlParameter("@tvalue", SqlDbType.Decimal,9),
					new SqlParameter("@cfstr", SqlDbType.NVarChar,50),
					new SqlParameter("@cfscale", SqlDbType.Decimal,9),
					new SqlParameter("@cxs", SqlDbType.Decimal,9),
					new SqlParameter("@cpricetype", SqlDbType.NVarChar,10),
					new SqlParameter("@pricetx", SqlDbType.NVarChar,10),
					new SqlParameter("@pricetxtype", SqlDbType.NVarChar,5),
					new SqlParameter("@pcity", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.ccode;
            parameters[1].Value = model.cname;
            parameters[2].Value = model.oname;
            parameters[3].Value = model.ocode;
            parameters[4].Value = model.cattr;
            parameters[5].Value = model.bvalue;
            parameters[6].Value = model.tvalue;
            parameters[7].Value = model.cfstr;
            parameters[8].Value = model.cfscale;
            parameters[9].Value = model.cxs;
            parameters[10].Value = model.cpricetype;
            parameters[11].Value = model.pricetx;
            parameters[12].Value = model.pricetxtype;
            parameters[13].Value = model.pcity;
            parameters[14].Value = model.maker;
            parameters[15].Value = model.cdate;
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
        public bool Update( Sys_OverCondition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_OverCondition set ");
            strSql.Append("cname=@cname,");
            strSql.Append("oname=@oname,");
            strSql.Append("ocode=@ocode,");
            strSql.Append("cattr=@cattr,");
            strSql.Append("bvalue=@bvalue,");
            strSql.Append("tvalue=@tvalue,");
            strSql.Append("cfstr=@cfstr,");
            strSql.Append("cfscale=@cfscale,");
            strSql.Append("cxs=@cxs,");
            strSql.Append("cpricetype=@cpricetype,");
            strSql.Append("pricetx=@pricetx,");
            strSql.Append("pricetxtype=@pricetxtype,");
            strSql.Append("pcity=@pcity,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,20),
					new SqlParameter("@oname", SqlDbType.NVarChar,20),
					new SqlParameter("@ocode", SqlDbType.NVarChar,20),
					new SqlParameter("@cattr", SqlDbType.NVarChar,10),
					new SqlParameter("@bvalue", SqlDbType.Decimal,9),
					new SqlParameter("@tvalue", SqlDbType.Decimal,9),
					new SqlParameter("@cfstr", SqlDbType.NVarChar,50),
					new SqlParameter("@cfscale", SqlDbType.Decimal,9),
					new SqlParameter("@cxs", SqlDbType.Decimal,9),
					new SqlParameter("@cpricetype", SqlDbType.NVarChar,10),
					new SqlParameter("@pricetx", SqlDbType.NVarChar,10),
					new SqlParameter("@pricetxtype", SqlDbType.NVarChar,5),
					new SqlParameter("@pcity", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ccode", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.oname;
            parameters[2].Value = model.ocode;
            parameters[3].Value = model.cattr;
            parameters[4].Value = model.bvalue;
            parameters[5].Value = model.tvalue;
            parameters[6].Value = model.cfstr;
            parameters[7].Value = model.cfscale;
            parameters[8].Value = model.cxs;
            parameters[9].Value = model.cpricetype;
            parameters[10].Value = model.pricetx;
            parameters[11].Value = model.pricetxtype;
            parameters[12].Value = model.pcity;
            parameters[13].Value = model.maker;
            parameters[14].Value = model.cdate;
            parameters[15].Value = model.ccode;
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
   
        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_OverCondition ");
            strSql.AppendFormat(" where 1=1  {0} ", ccode);
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
        public  Sys_OverCondition Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ccode,cname,oname,ocode,cattr,bvalue,tvalue,cfstr,cfscale,cxs,cpricetype,pricetx,pricetxtype,pcity,maker,cdate from Sys_OverCondition ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_OverCondition r = new Sys_OverCondition();
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
        public  Sys_OverCondition DataRowToModel(DataRow row)
        {
             Sys_OverCondition model = new  Sys_OverCondition();
             if (row != null)
             {
                 if (row["id"] != null && row["id"].ToString() != "")
                 {
                     model.id = int.Parse(row["id"].ToString());
                 }
                 if (row["ccode"] != null)
                 {
                     model.ccode = row["ccode"].ToString();
                 }
                 if (row["cname"] != null)
                 {
                     model.cname = row["cname"].ToString();
                 }
                 if (row["oname"] != null)
                 {
                     model.oname = row["oname"].ToString();
                 }
                 if (row["ocode"] != null)
                 {
                     model.ocode = row["ocode"].ToString();
                 }
                 if (row["cattr"] != null)
                 {
                     model.cattr = row["cattr"].ToString();
                 }
                 if (row["bvalue"] != null && row["bvalue"].ToString() != "")
                 {
                     model.bvalue = decimal.Parse(row["bvalue"].ToString());
                 }
                 if (row["tvalue"] != null && row["tvalue"].ToString() != "")
                 {
                     model.tvalue = decimal.Parse(row["tvalue"].ToString());
                 }
                 if (row["cfstr"] != null)
                 {
                     model.cfstr = row["cfstr"].ToString();
                 }
                 if (row["cfscale"] != null && row["cfscale"].ToString() != "")
                 {
                     model.cfscale = decimal.Parse(row["cfscale"].ToString());
                 }
                 if (row["cxs"] != null && row["cxs"].ToString() != "")
                 {
                     model.cxs = decimal.Parse(row["cxs"].ToString());
                 }
                 if (row["cpricetype"] != null)
                 {
                     model.cpricetype = row["cpricetype"].ToString();
                 }
                 if (row["pricetx"] != null)
                 {
                     model.pricetx = row["pricetx"].ToString();
                 }
                 if (row["pricetxtype"] != null)
                 {
                     model.pricetxtype = row["pricetxtype"].ToString();
                 }
                 if (row["pcity"] != null)
                 {
                     model.pcity = row["pcity"].ToString();
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
        public List<Sys_OverCondition> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ccode,cname,oname,ocode,cattr,bvalue,tvalue,cfstr,cfscale,cxs,cpricetype,pricetx,pricetxtype,maker,cdate,pcity  ");
            strSql.AppendFormat(" FROM Sys_OverCondition where 1=1 {0} ",where);
            List<Sys_OverCondition> r = new List<Sys_OverCondition>();
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
            sql = "select isnull(max(convert(int,ccode)),0) as n from Sys_OverCondition ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetProductionOc(string icode,string pcode, string ocode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryOverCondition where icode='{0}' and ocode='{1}';", icode,ocode);
            string[] clist = pcode.Split(';');
            for (int i = 0; i < clist.Length; i++)
            {
                sql.AppendFormat(" insert into Sys_RInventoryOverCondition (icode,pcode,ocode) values ('{0}','{1}','{2}') ;", icode, clist[i], ocode);
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
        public int ReSetProductionOc(string icode,string ocode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryOverCondition where icode='{0}' and ocode='{1}';", icode,ocode);
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
        public string GetProductionOc(string pcode)
        {
            string r = "";
            string sql = "select ocode from Sys_RInventoryOverCondition where pcode='" + pcode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = dr[0].ToString();
                }
            }
            return r;
        }
        public string GetProductionOcEx(string icode, string ocode)
        {
            string r = "";
            string sql = "select pcode from Sys_RInventoryOverCondition where ocode='" + ocode + "' and icode='" + icode + "'";
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, sql, null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr[0].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
