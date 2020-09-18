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
    public class Sys_FixProductionDal :ISys_FixProductionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_FixProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_FixProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_FixProduction(");
            strSql.Append("apname,apcode,apunit,apprice,aptype)");
            strSql.Append(" values (");
            strSql.Append("@apname,@apcode,@apunit,@apprice,@aptype)");
            SqlParameter[] parameters = {
					new SqlParameter("@apname", SqlDbType.NVarChar,30),
					new SqlParameter("@apcode", SqlDbType.NVarChar,10),
					new SqlParameter("@apunit", SqlDbType.NVarChar,10),
					new SqlParameter("@apprice", SqlDbType.Decimal,9),
					new SqlParameter("@aptype", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.apname;
            parameters[1].Value = model.apcode;
            parameters[2].Value = model.apunit;
            parameters[3].Value = model.apprice;
            parameters[4].Value = model.aptype;

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
        public bool Update(Sys_FixProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_FixProduction set ");
            strSql.Append("apname=@apname,");
            strSql.Append("apunit=@apunit,");
            strSql.Append("apprice=@apprice,");
            strSql.Append("aptype=@aptype");
            strSql.Append(" where apcode=@apcode");
            SqlParameter[] parameters = {
					new SqlParameter("@apname", SqlDbType.NVarChar,30),
					new SqlParameter("@apunit", SqlDbType.NVarChar,10),
					new SqlParameter("@apprice", SqlDbType.Decimal,9),
					new SqlParameter("@aptype", SqlDbType.NVarChar,10),
					new SqlParameter("@apcode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.apname;
            parameters[1].Value = model.apunit;
            parameters[2].Value = model.apprice;
            parameters[3].Value = model.aptype;
            parameters[4].Value = model.apcode;

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
            strSql.Append("delete from Sys_FixProduction ");
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
        public Sys_FixProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,apname,apcode,apunit,apprice,aptype from Sys_FixProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_FixProduction r = new Sys_FixProduction();
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
        public Sys_FixProduction DataRowToModel(DataRow row)
        {
            Sys_FixProduction model = new Sys_FixProduction();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["apname"] != null)
                {
                    model.apname = row["apname"].ToString();
                }
                if (row["apcode"] != null)
                {
                    model.apcode = row["apcode"].ToString();
                }
                if (row["apunit"] != null)
                {
                    model.apunit = row["apunit"].ToString();
                }
                if (row["apprice"] != null && row["apprice"].ToString() != "")
                {
                    model.apprice = decimal.Parse(row["apprice"].ToString());
                }
                if (row["aptype"] != null)
                {
                    model.aptype = row["aptype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_FixProduction> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,apname,apcode,apunit,apprice,aptype ");
            strSql.AppendFormat(" FROM Sys_FixProduction where 1=1 {0}", strWhere);
            List<Sys_FixProduction> r = new List<Sys_FixProduction>();
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
            sql = "select isnull(max(convert(int,apcode)),0) as n from Sys_FixProduction ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public int SetFixProduction(string fcode, string icode, string[] pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventoryFixProdution where apcode='{0}' and icode='{1}' ;", fcode, icode);
            for (int i = 0; i < pcode.Length; i++)
            {
                strSql.AppendFormat(" insert into  Sys_RInventoryFixProdution (apcode,icode,pcode) values ('{0}','{1}','{2}');", fcode, icode, pcode[i]);
            }
            int r = 0;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = 1;
            }
            return r;
        }
        public int ReSetFixProduction(string fcode, string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventoryFixProdution where apcode='{0}' and icode='{1}' ;", fcode, icode);
            int r = 0;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = 1;
            }
            return r;
        }
        public string  GetFixProduction(string fcode, string icode )
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select pcode from Sys_RInventoryFixProdution where apcode='{0}' and icode='{1}' ;", fcode, icode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["pcode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
