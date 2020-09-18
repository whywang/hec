using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.ProductionInfo;
using System.Data.SqlClient;
using LionvIDal.ProductionInfo;

namespace LionvSqlServerDal.ProductionInfo
{
    public class Sys_ConsumeMaterialCateDal : ISys_ConsumeMaterialCateDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_ConsumeMaterialCate");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ConsumeMaterialCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_ConsumeMaterialCate(");
            strSql.Append("cname,ccode,pcname,pccode,isend,isuse,maker,cdate,dcode)");
            strSql.Append(" values (");
            strSql.Append("@cname,@ccode,@pcname,@pccode,@isend,@isuse,@maker,@cdate,@dcode)");

            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30),
					new SqlParameter("@isend", SqlDbType.Bit,1),
					new SqlParameter("@isuse", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.pcname;
            parameters[3].Value = model.pccode;
            parameters[4].Value = model.isend;
            parameters[5].Value = model.isuse;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.dcode;
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
        public bool Update(Sys_ConsumeMaterialCate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ConsumeMaterialCate set ");
            strSql.Append("cname=@cname,");
            strSql.Append("pcname=@pcname,");
            strSql.Append("pccode=@pccode,");
            strSql.Append("isuse=@isuse,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where ccode=@ccode");
            SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcname", SqlDbType.NVarChar,30),
					new SqlParameter("@pccode", SqlDbType.NVarChar,30),
					new SqlParameter("@isuse", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.cname;
            parameters[1].Value = model.pcname;
            parameters[2].Value = model.pccode;
            parameters[3].Value = model.isuse;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.ccode;

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
        public bool Delete(string ccode)
        {

            StringBuilder strSql = new StringBuilder();
            List<Sys_ConsumeMaterialCate> lc = QueryList(" and pccode='" + ccode.Substring(0, ccode.Length - 3) + "'");
            if (lc != null)
            {
                if (lc.Count == 1)
                {
                    strSql.Append("update Sys_ConsumeMaterialCate ");
                    strSql.AppendFormat("  set isend='true'  where ccode ='{0}'; ", ccode.Substring(0, ccode.Length - 3));
                }
            }
            strSql.Append("delete from Sys_ConsumeMaterialCate ");
            strSql.AppendFormat(" where ccode like '{0}%'; ", ccode);
            strSql.Append("delete from Sys_ConsumeMaterial ");
            strSql.AppendFormat(" where pmcode like '{0}%'; ", ccode);

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
        public Sys_ConsumeMaterialCate Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,cname,ccode,pcname,pccode,isend,isuse,maker,cdate,dcode from Sys_ConsumeMaterialCate ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_ConsumeMaterialCate r = new Sys_ConsumeMaterialCate();
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
        public Sys_ConsumeMaterialCate DataRowToModel(DataRow row)
        {
            Sys_ConsumeMaterialCate model = new Sys_ConsumeMaterialCate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["cname"] != null)
                {
                    model.cname = row["cname"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["pcname"] != null)
                {
                    model.pcname = row["pcname"].ToString();
                }
                if (row["pccode"] != null)
                {
                    model.pccode = row["pccode"].ToString();
                }
                if (row["isend"] != null && row["isend"].ToString() != "")
                {
                    if ((row["isend"].ToString() == "1") || (row["isend"].ToString().ToLower() == "true"))
                    {
                        model.isend = true;
                    }
                    else
                    {
                        model.isend = false;
                    }
                }
                if (row["isuse"] != null && row["isuse"].ToString() != "")
                {
                    if ((row["isuse"].ToString() == "1") || (row["isuse"].ToString().ToLower() == "true"))
                    {
                        model.isuse = true;
                    }
                    else
                    {
                        model.isuse = false;
                    }
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
        public List<Sys_ConsumeMaterialCate> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,cname,ccode,pcname,pccode,isend,isuse,maker,cdate,dcode  ");
            strSql.Append(" FROM Sys_ConsumeMaterialCate ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Sys_ConsumeMaterialCate> r = new List<Sys_ConsumeMaterialCate>();
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
        public int CreateCode(string pmcode)
        {
            int r = -1;
            string sql = "select isnull(max(convert(int,substring(ccode,len(ccode)-2,3))),0) as n from Sys_ConsumeMaterialCate where pccode='" + pmcode + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool UpdateEnd(string ccode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_ConsumeMaterialCate ");
            strSql.AppendFormat(" set isend='false' where ccode='{0}'; ", ccode);

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
