using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_BtnImgDal : ISys_BtnImgDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_BtnImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_BtnImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_BtnImg(");
            strSql.Append("bname,bcode,burl)");
            strSql.Append(" values (");
            strSql.Append("@bname,@bcode,@burl)");

            SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,50),
					new SqlParameter("@bcode", SqlDbType.NVarChar,50),
					new SqlParameter("@burl", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.bname;
            parameters[1].Value = model.bcode;
            parameters[2].Value = model.burl;

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
        public bool Update(Sys_BtnImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_BtnImg set ");
            strSql.Append("bname=@bname,");
            strSql.Append("burl=@burl");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@bname", SqlDbType.NVarChar,50),
					new SqlParameter("@burl", SqlDbType.NVarChar,200),
					new SqlParameter("@bcode", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.bname;
            parameters[1].Value = model.burl;
            parameters[2].Value = model.bcode;

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
        public bool Delete(string bcode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_BtnImg ");
            strSql.AppendFormat(" where  bcode= '{0}'", bcode);
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
        public Sys_BtnImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,bname,bcode,burl from Sys_BtnImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_BtnImg r = new Sys_BtnImg();
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
        public Sys_BtnImg DataRowToModel(DataRow row)
        {
            Sys_BtnImg model = new Sys_BtnImg();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["bname"] != null)
                {
                    model.bname = row["bname"].ToString();
                }
                if (row["bcode"] != null)
                {
                    model.bcode = row["bcode"].ToString();
                }
                if (row["burl"] != null)
                {
                    model.burl = row["burl"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_BtnImg> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,bname,bcode,burl ");
            strSql.Append(" FROM Sys_BtnImg ");
            strSql.AppendFormat("  where 1=1 {0}", strWhere);
            List<Sys_BtnImg> r = new List<Sys_BtnImg>();
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
            string sql = "select isnull(max(convert(int,bcode)),0) as n from Sys_BtnImg ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
