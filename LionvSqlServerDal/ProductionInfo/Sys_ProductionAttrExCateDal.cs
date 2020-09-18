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
    public class Sys_ProductionAttrExCateDal : ISys_ProductionAttrExCateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionAttrExCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ProductionAttrExCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionAttrExCate(");
            strSql.Append("accode,acname,bdcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@accode,@acname,@bdcode,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@accode", SqlDbType.NVarChar,30),
					new SqlParameter("@acname", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.accode;
            parameters[1].Value = model.acname;
            parameters[2].Value = model.bdcode;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;

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
        public bool Update( Sys_ProductionAttrExCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionAttrExCate set ");
            strSql.Append("acname=@acname,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where accode=@accode");
            SqlParameter[] parameters = {
					new SqlParameter("@acname", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@accode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.acname;
            parameters[1].Value = model.bdcode;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.accode;

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
            strSql.Append("delete from Sys_ProductionAttrExCate ");
            strSql.AppendFormat(" where 1=1 and accode='{0}' ;", where);
            strSql.Append("delete from Sys_RInventoryAttrExCate ");
            strSql.AppendFormat(" where 1=1 and accode='{0}' ;", where);
            strSql.Append("delete from Sys_RProductionAttrExCateAttrEx ");
            strSql.AppendFormat(" where 1=1 and accode='{0}' ;", where);
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
        public  Sys_ProductionAttrExCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,accode,acname,bdcode,maker,cdate from Sys_ProductionAttrExCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionAttrExCate r = new Sys_ProductionAttrExCate();
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
        public  Sys_ProductionAttrExCate DataRowToModel(DataRow row)
        {
             Sys_ProductionAttrExCate model = new  Sys_ProductionAttrExCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["accode"] != null)
                {
                    model.accode = row["accode"].ToString();
                }
                if (row["acname"] != null)
                {
                    model.acname = row["acname"].ToString();
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
        public List<Sys_ProductionAttrExCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,accode,acname,bdcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_ProductionAttrExCate where 1=1 {0}", strWhere);
            List<Sys_ProductionAttrExCate> r = new List<Sys_ProductionAttrExCate>();
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
            sql = "select isnull(max(convert(int,accode)),0) as n from Sys_ProductionAttrExCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetAttrCateAttr(string accode, string acode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RProductionAttrExCateAttrEx ");
            strSql.AppendFormat(" where 1=1 and accode='{0}' ;", accode);
            if (acode != "")
            {
                string []ac=acode.Split(';');
                for (int i = 0; i < ac.Length; i++)
                {
                    strSql.Append(" insert into Sys_RProductionAttrExCateAttrEx (accode,acode)");
                    strSql.AppendFormat(" values ( '{0}' ,'{1}');", accode,ac[i]);
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetAttrCateAttr(string accode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RProductionAttrExCateAttrEx ");
            strSql.AppendFormat(" where 1=1 and accode='{0}' ;", accode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetAttrCateAttr(string accode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select acode");
            strSql.AppendFormat(" FROM Sys_RProductionAttrExCateAttrEx where accode='{0}'", accode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r=r+dr["acode"].ToString()+";";
                }
                r = r.Substring(0, r.Length - 1);
            }
            else
            {
                r = "";
            }
            return r;
        }

        public bool SetInvAttrCate(string icode, string accode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryAttrExCate ");
            strSql.AppendFormat(" where 1=1 and icode='{0}' ;", icode);
            strSql.Append(" insert into Sys_RInventoryAttrExCate (icode,accode)");
            strSql.AppendFormat(" values ( '{0}' ,'{1}');", icode, accode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public bool ReSetInvAttrCate(string icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RInventoryAttrExCate ");
            strSql.AppendFormat(" where 1=1 and icode='{0}' ;", icode);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public string GetInvAttrCate(string icode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select accode");
            strSql.AppendFormat(" FROM Sys_RInventoryAttrExCate where icode='{0}'", icode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["accode"].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
