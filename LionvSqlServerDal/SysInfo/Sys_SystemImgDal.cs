using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;
using LionvIDal.SysInfo;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_SystemImgDal : ISys_SystemImgDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SystemImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_SystemImg(");
            strSql.Append("murl,mtype)");
            strSql.Append(" values (");
            strSql.Append("@murl,@mtype)");
            SqlParameter[] parameters = {
					new SqlParameter("@murl", SqlDbType.NVarChar,100),
					new SqlParameter("@mtype", SqlDbType.Int,4)};
            parameters[0].Value = model.murl;
            parameters[1].Value = model.mtype;
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
        public bool Update(Sys_SystemImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_SystemImg set ");
            strSql.Append("murl=@murl,");
            strSql.Append("mtype=@mtype");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@murl", SqlDbType.NVarChar,100),
					new SqlParameter("@mtype", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.murl;
            parameters[1].Value = model.mtype;
            parameters[2].Value = model.id;

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
            strSql.Append("delete from Sys_SystemImg ");
            strSql.AppendFormat(" where  1=1 {0}", where);
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
        public Sys_SystemImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,murl,mtype from Sys_SystemImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_SystemImg r = new Sys_SystemImg();
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
        public Sys_SystemImg DataRowToModel(DataRow row)
        {
            Sys_SystemImg model = new Sys_SystemImg();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["murl"] != null)
                {
                    model.murl = row["murl"].ToString();
                }
                if (row["mtype"] != null && row["mtype"].ToString() != "")
                {
                    model.mtype = int.Parse(row["mtype"].ToString());
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
