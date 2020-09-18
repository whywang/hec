using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessCateDal : ISys_ProductionProcessCateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionProcessCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcessCate(");
            strSql.Append("pcname,pccode,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@pcname,@pccode,@maker,@cdate,@dcode)");

            SqlParameter[] parameters = {
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.pcname;
            parameters[1].Value = model.pccode;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.dcode;
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
        public bool Update(Sys_ProductionProcessCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcessCate set ");
            strSql.Append("pcname=@pcname,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where pccode=@pccode");
            SqlParameter[] parameters = {
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.pcname;
            parameters[1].Value = model.maker;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.pccode;

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
        public bool Delete(string pccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionProcessCate ");
            strSql.AppendFormat(" where pccode='{0}';", pccode);
            strSql.Append("delete from Sys_ProductionProcess ");
            strSql.AppendFormat(" where pccode='{0}';", pccode);

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
        public Sys_ProductionProcessCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,pcname,pccode,maker,cdate,dcode from Sys_ProductionProcessCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessCate r = new Sys_ProductionProcessCate();
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
        public Sys_ProductionProcessCate DataRowToModel(DataRow row)
        {
            Sys_ProductionProcessCate model = new Sys_ProductionProcessCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["pcname"] != null)
                {
                    model.pcname = row["pcname"].ToString();
                }
                if (row["pccode"] != null)
                {
                    model.pccode = row["pccode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                } 
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,pcname,pccode,maker,cdate,dcode ");
            strSql.AppendFormat(" FROM Sys_ProductionProcessCate where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessCate> r = new List<Sys_ProductionProcessCate>();
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
            sql = "select isnull(max(convert(int,pccode)),0) as n from Sys_ProductionProcessCate ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
