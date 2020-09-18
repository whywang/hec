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
    public class Sys_ProductionXqTempDal : ISys_ProductionXqTempDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionXqTemp");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProductionXqTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionXqTemp(");
            strSql.Append("qtname,qtcode,dcode,qtype,qread,qttemp,qtemp,maker,cdate,emcode)");
            strSql.Append(" values (");
            strSql.Append("@qtname,@qtcode,@dcode,@qtype,@qread,@qttemp,@qtemp,@maker,@cdate,@emcode)");
            SqlParameter[] parameters = {
					new SqlParameter("@qtname", SqlDbType.NVarChar,30),
					new SqlParameter("@qtcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@qtype", SqlDbType.NVarChar,30),
					new SqlParameter("@qread", SqlDbType.Bit,1),
					new SqlParameter("@qttemp", SqlDbType.NVarChar,4000),
					new SqlParameter("@qtemp", SqlDbType.NVarChar,4000),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@emcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.qtname;
            parameters[1].Value = model.qtcode;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.qtype;
            parameters[4].Value = model.qread;
            parameters[5].Value = model.qttemp;
            parameters[6].Value = model.qtemp;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.cdate;
            parameters[9].Value = model.emcode;
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
        public bool Update( Sys_ProductionXqTemp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionXqTemp set ");
            strSql.Append("qtname=@qtname,");
            strSql.Append("emcode=@emcode,");
            strSql.Append("qtype=@qtype,");
            strSql.Append("qread=@qread,");
            strSql.Append("qttemp=@qttemp,");
            strSql.Append("qtemp=@qtemp,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where qtcode=@qtcode");
            SqlParameter[] parameters = {
					new SqlParameter("@qtname", SqlDbType.NVarChar,30),
                    new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@qtype", SqlDbType.NVarChar,30),
					new SqlParameter("@qread", SqlDbType.Bit,1),
					new SqlParameter("@qttemp", SqlDbType.NVarChar,4000),
					new SqlParameter("@qtemp", SqlDbType.NVarChar,4000),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@qtcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.qtname;
            parameters[1].Value = model.emcode;
            parameters[2].Value = model.qtype;
            parameters[3].Value = model.qread;
            parameters[4].Value = model.qttemp;
            parameters[5].Value = model.qtemp;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.qtcode;

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
            strSql.AppendFormat("delete from Sys_ProductionXqTemp where 1=1 '{0}'", where);
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
        public Sys_ProductionXqTemp Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,qtname,qtcode,dcode,qtype,qread,qttemp,qtemp,maker,cdate,emcode from Sys_ProductionXqTemp ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionXqTemp r = new Sys_ProductionXqTemp();
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
        public  Sys_ProductionXqTemp DataRowToModel(DataRow row)
        {
             Sys_ProductionXqTemp model = new  Sys_ProductionXqTemp();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["qtname"] != null)
                {
                    model.qtname = row["qtname"].ToString();
                }
                if (row["qtcode"] != null)
                {
                    model.qtcode = row["qtcode"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["qtype"] != null)
                {
                    model.qtype = row["qtype"].ToString();
                }
                if (row["qread"] != null && row["qread"].ToString() != "")
                {
                    if ((row["qread"].ToString() == "1") || (row["qread"].ToString().ToLower() == "true"))
                    {
                        model.qread = true;
                    }
                    else
                    {
                        model.qread = false;
                    }
                }
                if (row["qttemp"] != null)
                {
                    model.qttemp = row["qttemp"].ToString();
                }
                if (row["qtemp"] != null)
                {
                    model.qtemp = row["qtemp"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["emcode"] != null)
                {
                    model.emcode = row["emcode"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionXqTemp> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,qtname,qtcode,dcode,qtype,qread,qttemp,qtemp,maker,cdate,emcode ");
            strSql.Append(" FROM Sys_ProductionXqTemp ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionXqTemp> r = new List<Sys_ProductionXqTemp>();
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
            sql = "select isnull(max(qtcode),0) as n from Sys_ProductionXqTemp ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetXqTemp(string pcode, string qtcode,string emcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryProductionXqTemp where pcode ='{0}' and emcode='{1}' ;", pcode,emcode);
            sql.AppendFormat(" insert into Sys_RInventoryProductionXqTemp (pcode,qtcode,emcode) values ('{0}','{1}','{2}') ;", pcode,qtcode,emcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetXqTemp(string pcode,string emcode)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(" delete from Sys_RInventoryProductionXqTemp where pcode ='{0}'  and emcode='{1}';", pcode,emcode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, sql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetXqTemp(string pcode,string emcode)
        {
            string r = "";
            r = LooqTemp(pcode,emcode);
            return r;
        }
        private string LooqTemp(string pcode, string emcode)
        {
            string r = "";
            if (pcode.Length > 8)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select qtcode ");
                strSql.AppendFormat(" FROM Sys_RInventoryProductionXqTemp where pcode='{0}' and emcode='{1}'", pcode, emcode);
                DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
                if (dt != null)
                {
                    r = dt.Rows[0]["qtcode"].ToString();
                }
                else
                {
                    r = LooqTemp(pcode.Substring(0, pcode.Length - 3),emcode);
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
