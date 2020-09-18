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
    public class Sys_RefSizeTransformDal : ISys_RefSizeTransformDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_RefSizeTransform");
            strSql.AppendFormat(" where 1=1 {0} ",where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_RefSizeTransform model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_RefSizeTransform(");
            strSql.Append("rjname,rjcode,rheight,rwidth,rdeep,rtype,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@rjname,@rjcode,@rheight,@rwidth,@rdeep,@rtype,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@rjname", SqlDbType.NVarChar,30),
					new SqlParameter("@rjcode", SqlDbType.NVarChar,30),
					new SqlParameter("@rheight", SqlDbType.Int,4),
					new SqlParameter("@rwidth", SqlDbType.Int,4),
					new SqlParameter("@rdeep", SqlDbType.Int,4),
					new SqlParameter("@rtype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.rjname;
            parameters[1].Value = model.rjcode;
            parameters[2].Value = model.rheight;
            parameters[3].Value = model.rwidth;
            parameters[4].Value = model.rdeep;
            parameters[5].Value = model.rtype;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;

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
        public bool Update( Sys_RefSizeTransform model)
        {
            StringBuilder strSql = new StringBuilder();
            if (model.rtype == "a")
            {
                strSql.AppendFormat("delete from Sys_RInventoryRefSizeForm where rjcode='{0}' and mscode<>''; ");
            }
            strSql.Append("update Sys_RefSizeTransform set ");
            strSql.Append("rjname=@rjname,");
            strSql.Append("rheight=@rheight,");
            strSql.Append("rwidth=@rwidth,");
            strSql.Append("rdeep=@rdeep,");
            strSql.Append("rtype=@rtype,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where rjcode=@rjcode");
            SqlParameter[] parameters = {
					new SqlParameter("@rjname", SqlDbType.NVarChar,30),
					new SqlParameter("@rheight", SqlDbType.Int,4),
					new SqlParameter("@rwidth", SqlDbType.Int,4),
					new SqlParameter("@rdeep", SqlDbType.Int,4),
					new SqlParameter("@rtype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@rjcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.rjname;
            parameters[1].Value = model.rheight;
            parameters[2].Value = model.rwidth;
            parameters[3].Value = model.rdeep;
            parameters[4].Value = model.rtype;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.rjcode;

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
        public bool Delete(string rjcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_RefSizeTransform ");
            strSql.AppendFormat(" where rjcode='{0}' ;",rjcode);
            strSql.Append("delete from Sys_RInventoryRefSizeForm ");
            strSql.AppendFormat(" where rjcode=='{0}' ", rjcode);

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
        public  Sys_RefSizeTransform Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,rjname,rjcode,rheight,rwidth,rdeep,rtype,maker,cdate from Sys_RefSizeTransform ");
            strSql.AppendFormat(" where 1=1 {0}", where);
             Sys_RefSizeTransform r = new  Sys_RefSizeTransform();
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
        public  Sys_RefSizeTransform DataRowToModel(DataRow row)
        {
             Sys_RefSizeTransform model = new  Sys_RefSizeTransform();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["rjname"] != null)
                {
                    model.rjname = row["rjname"].ToString();
                }
                if (row["rjcode"] != null)
                {
                    model.rjcode = row["rjcode"].ToString();
                }
                if (row["rheight"] != null && row["rheight"].ToString() != "")
                {
                    model.rheight = int.Parse(row["rheight"].ToString());
                }
                if (row["rwidth"] != null && row["rwidth"].ToString() != "")
                {
                    model.rwidth = int.Parse(row["rwidth"].ToString());
                }
                if (row["rdeep"] != null && row["rdeep"].ToString() != "")
                {
                    model.rdeep = int.Parse(row["rdeep"].ToString());
                }
                if (row["rtype"] != null)
                {
                    model.rtype = row["rtype"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_RefSizeTransform> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,rjname,rjcode,rheight,rwidth,rdeep,rtype,maker,cdate ");
            strSql.Append(" FROM Sys_RefSizeTransform ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_RefSizeTransform> r = new List<Sys_RefSizeTransform>();
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
            sql = "select isnull(max(convert(int,rjcode)),0) as n from Sys_RefSizeTransform ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SetMtMsSize(string mtcode, string mscode, string rjcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_RInventoryRefSizeForm where mtcode='{0}' and mscode='{1}'; ",mtcode,mscode);
            strSql.AppendFormat("insert into Sys_RInventoryRefSizeForm (mtcode,mscode,rjcode)values ( '{0}','{1}','{2}'); ", mtcode, mscode,rjcode);
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
        public bool ReSetMtMsSize(string mtcode, string mscode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from Sys_RInventoryRefSizeForm where mtcode='{0}' and mscode='{1}'; ", mtcode, mscode);
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
        public string  GetMtMsSize(string mtcode, string mscode)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select rjcode  from Sys_RInventoryRefSizeForm where mtcode='{0}' and mscode='{1}' ",mtcode, mscode);
            DataTable dt = SqlHelp.GetDataTable(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0][0].ToString();
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
