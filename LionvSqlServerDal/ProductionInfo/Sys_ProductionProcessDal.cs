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
    public class Sys_ProductionProcessDal : ISys_ProductionProcessDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionProcess");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcess(");
            strSql.Append("gname,gcode,pcname,pccode,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@gname,@gcode,@pcname,@pccode,@maker,@cdate,@dcode)");

            SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.gname;
            parameters[1].Value = model.gcode;
            parameters[2].Value = model.pcname;
            parameters[3].Value = model.pccode;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.dcode;
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
        public bool Update(Sys_ProductionProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcess set ");
            strSql.Append("gname=@gname,");
            strSql.Append("pcname=@pcname,");
            strSql.Append("pccode=@pccode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where gcode=@gcode");
            SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.gname;
            parameters[1].Value = model.pcname;
            parameters[2].Value = model.pccode;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.gcode;

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
        public bool Delete(string gcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionProcess ");
            strSql.Append(" where gcode=@gcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@gcode", SqlDbType.NVarChar,30)			};
            parameters[0].Value = gcode;

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
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProductionProcess Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,gname,gcode,pcname,pccode,maker,cdate,dcode from Sys_ProductionProcess ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcess r = new Sys_ProductionProcess();
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
        public Sys_ProductionProcess DataRowToModel(DataRow row)
        {
            Sys_ProductionProcess model = new Sys_ProductionProcess();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["gcode"] != null)
                {
                    model.gcode = row["gcode"].ToString();
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
        public List<Sys_ProductionProcess> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,gname,gcode,pcname,pccode,maker,cdate ,dcode");
            strSql.AppendFormat(" FROM Sys_ProductionProcess where 1=1 {0}", strWhere);
            List<Sys_ProductionProcess> r = new List<Sys_ProductionProcess>();
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
            sql = "select isnull(max(convert(int,gcode)),0) as n from Sys_ProductionProcess ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
