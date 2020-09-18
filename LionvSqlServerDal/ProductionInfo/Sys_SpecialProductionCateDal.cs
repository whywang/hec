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
    public class Sys_SpecialProductionCateDal : ISys_SpecialProductionCateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_SpecialProductionCate");
            strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_SpecialProductionCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SpecialProductionCate(");
            strSql.Append("tjlbname,tjlbcode,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@tjlbname,@tjlbcode,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@tjlbname", SqlDbType.NVarChar,30),
					new SqlParameter("@tjlbcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.tjlbname;
            parameters[1].Value = model.tjlbcode;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;

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
        public bool Update( Sys_SpecialProductionCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SpecialProductionCate set ");
            strSql.Append("tjlbname=@tjlbname,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where tjlbcode=@tjlbcode");
            SqlParameter[] parameters = {
					new SqlParameter("@tjlbname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@tjlbcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.tjlbname;
            parameters[1].Value = model.maker;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.tjlbcode;

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
        public bool Delete(string tjlbcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_SpecialProductionCate ");
            strSql.AppendFormat(" where tjlbcode ='{0}'; ", tjlbcode);
            strSql.Append("delete from Sys_RInventorySpecialCate ");
            strSql.AppendFormat(" where tjlbcode ='{0}' ", tjlbcode);
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
        public  Sys_SpecialProductionCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,tjlbname,tjlbcode,maker,cdate from Sys_SpecialProductionCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SpecialProductionCate r = new Sys_SpecialProductionCate();
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
        public  Sys_SpecialProductionCate DataRowToModel(DataRow row)
        {
             Sys_SpecialProductionCate model = new  Sys_SpecialProductionCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tjlbname"] != null)
                {
                    model.tjlbname = row["tjlbname"].ToString();
                }
                if (row["tjlbcode"] != null)
                {
                    model.tjlbcode = row["tjlbcode"].ToString();
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
        public List<Sys_SpecialProductionCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tjlbname,tjlbcode,maker,cdate ");
            strSql.AppendFormat(" FROM Sys_SpecialProductionCate where 1=1 {0}", strWhere);
            List<Sys_SpecialProductionCate> r = new List<Sys_SpecialProductionCate>();
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
            sql = "select isnull(max(convert(int,tjlbcode)),0) as n from Sys_SpecialProductionCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetCatePCate(string ccode, string[] icode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySpecialCate where tjlbcode='{0}';", ccode);
            for (int i = 0; i < icode.Length; i++)
            {
                if (icode[i].ToString() != "")
                {
                    strSql.AppendFormat(" insert into Sys_RInventorySpecialCate  (tjlbcode,icode) values('{0}','{1}');", ccode, icode[i]);
                }
            }
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
        public bool ReSetCatePCate(string ccode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" delete from Sys_RInventorySpecialCate where tjlbcode='{0}' ;", ccode);
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
        public string GetCatePCate(string ccode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  icode ");
            strSql.AppendFormat(" FROM Sys_RInventorySpecialCate where  tjlbcode='{0}'  ;", ccode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    r = r + dr["icode"].ToString() + ";";
                }
                r = r.Substring(0, r.Length - 1);
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
