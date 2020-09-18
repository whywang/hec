using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.WxChat;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.WxChat;

namespace LionvSqlServerDal.WxChat
{
    public class Sys_EmplyeeFouseWxDal : ISys_EmplyeeFouseWxDal
    {

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_EmplyeeFouseWx");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_EmplyeeFouseWx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_EmplyeeFouseWx(");
            strSql.Append("ename,openid)");
            strSql.Append(" values (");
            strSql.Append("@ename,@openid)");
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@openid", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.openid;

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
        public bool Update( Sys_EmplyeeFouseWx model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_EmplyeeFouseWx set ");
            strSql.Append("ename=@ename,");
            strSql.Append("openid=@openid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ename", SqlDbType.NVarChar,30),
					new SqlParameter("@openid", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.ename;
            parameters[1].Value = model.openid;
            parameters[2].Value = model.id;

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
            strSql.Append("delete from Sys_EmplyeeFouseWx ");
            strSql.AppendFormat(" where 1=1 ;", where);
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
        public  Sys_EmplyeeFouseWx Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,ename,openid from Sys_EmplyeeFouseWx ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Sys_EmplyeeFouseWx r = new Sys_EmplyeeFouseWx();
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
        public  Sys_EmplyeeFouseWx DataRowToModel(DataRow row)
        {
             Sys_EmplyeeFouseWx model = new  Sys_EmplyeeFouseWx();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["openid"] != null)
                {
                    model.openid = row["openid"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_EmplyeeFouseWx> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,ename,openid ");
            strSql.AppendFormat(" FROM Sys_EmplyeeFouseWx where 1=1 {0}  ", strWhere);
            List<Sys_EmplyeeFouseWx> r = new List<Sys_EmplyeeFouseWx>();
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

        #endregion  ExtensionMethod

    }
}
