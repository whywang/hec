using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvCommon;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ProductionProcessLineDal : ISys_ProductionProcessLineDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ProductionProcessLine");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ProductionProcessLine(");
            strSql.Append("lcode,lname,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@lcode,@lname,@maker,@cdate,@dcode)");

            SqlParameter[] parameters = {
					new SqlParameter("@lcode", SqlDbType.NVarChar,30),
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.lcode;
            parameters[1].Value = model.lname;
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
        public bool Update(Sys_ProductionProcessLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ProductionProcessLine set ");
            strSql.Append("lname=@lname,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where lcode=@lcode");
            SqlParameter[] parameters = {
					new SqlParameter("@lname", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@lcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.lname;
            parameters[1].Value = model.maker;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.lcode;

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
        public bool Delete(string lcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_ProductionProcessLine ");
            strSql.AppendFormat(" where lcode='{0}'; ", lcode);
            strSql.Append("delete from Sys_ProductionProcessLinePoint ");
            strSql.AppendFormat(" where lcode='{0}'; ", lcode);
            strSql.Append("delete from Sys_RInventoryProductionProcess ");
            strSql.AppendFormat(" where lcode='{0}'; ", lcode);

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
        public Sys_ProductionProcessLine Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lcode,lname,maker,cdate,dcode,utime from Sys_ProductionProcessLine ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ProductionProcessLine r = new Sys_ProductionProcessLine();
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
        public Sys_ProductionProcessLine DataRowToModel(DataRow row)
        {
            Sys_ProductionProcessLine model = new Sys_ProductionProcessLine();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["lcode"] != null)
                {
                    model.lcode = row["lcode"].ToString();
                }
                if (row["lname"] != null)
                {
                    model.lname = row["lname"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["utime"] != null && row["utime"].ToString() != "")
                {
                    model.utime =Convert.ToInt32( row["utime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessLine> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lcode,lname,maker,cdate,dcode,utime ");
            strSql.Append(" FROM Sys_ProductionProcessLine ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ProductionProcessLine> r = new List<Sys_ProductionProcessLine>();
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
            sql = "select isnull(max(convert(int,lcode)),0) as n from Sys_ProductionProcessLine ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetProcessLine(string pcode, string lcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete  from Sys_RInventoryProductionProcess where pcode='" + pcode + "'; ");
            strSql.AppendFormat("insert into Sys_RInventoryProductionProcess (pcode,lcode) values ('{0}','{1}') ", pcode, lcode);
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
        public bool ReSetProcessLine(string pcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete  from Sys_RInventoryProductionProcess where pcode='" + pcode + "'; ");
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
        public string GetProcessLine(string pcode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select lcode from Sys_RInventoryProductionProcess where pcode='" + pcode + "'; ");
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["lcode"].ToString();
            }
            else
            {
                r = "";
            }
            return r;
        }
        public bool UpUtime(string lcode,int utime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update Sys_ProductionProcessLine set utime={0} where lcode='{1}'; ",utime,lcode);
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
        #endregion  ExtensionMethod
    }
}
