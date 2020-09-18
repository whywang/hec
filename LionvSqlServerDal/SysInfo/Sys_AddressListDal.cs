using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.SysInfo
{
    public class Sys_AddressListDal : ISys_AddressListDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_AddressList");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_AddressList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_AddressList(");
            strSql.Append("aname,adname,adcode,tel1,ftel,tel2)");
            strSql.Append(" values (");
            strSql.Append("@aname,@adname,@adcode,@tel1,@ftel,@tel2)");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,50),
					new SqlParameter("@adname", SqlDbType.NVarChar,30),
					new SqlParameter("@adcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tel1", SqlDbType.NVarChar,20),
					new SqlParameter("@ftel", SqlDbType.NVarChar,20),
					new SqlParameter("@tel2", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.adname;
            parameters[2].Value = model.adcode;
            parameters[3].Value = model.tel1;
            parameters[4].Value = model.ftel;
            parameters[5].Value = model.tel2;

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
        public bool Update(Sys_AddressList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_AddressList set ");
            strSql.Append("aname=@aname,");
            strSql.Append("adname=@adname,");
            strSql.Append("adcode=@adcode,");
            strSql.Append("tel1=@tel1,");
            strSql.Append("ftel=@ftel,");
            strSql.Append("tel2=@tel2");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@aname", SqlDbType.NVarChar,50),
					new SqlParameter("@adname", SqlDbType.NVarChar,30),
					new SqlParameter("@adcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tel1", SqlDbType.NVarChar,20),
					new SqlParameter("@ftel", SqlDbType.NVarChar,20),
					new SqlParameter("@tel2", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.aname;
            parameters[1].Value = model.adname;
            parameters[2].Value = model.adcode;
            parameters[3].Value = model.tel1;
            parameters[4].Value = model.ftel;
            parameters[5].Value = model.tel2;
            parameters[6].Value = model.id;

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
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_AddressList ");
            strSql.AppendFormat(" where  1=1 {0};", where);
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
        public Sys_AddressList Query(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,aname,adname,adcode,tel1,ftel,tel2 from Sys_AddressList ");
            strSql.AppendFormat(" where 1=1 {0}",id.ToString());
            Sys_AddressList r = new Sys_AddressList();
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
        public Sys_AddressList DataRowToModel(DataRow row)
        {
            Sys_AddressList model = new Sys_AddressList();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["adname"] != null)
                {
                    model.adname = row["adname"].ToString();
                }
                if (row["adcode"] != null)
                {
                    model.adcode = row["adcode"].ToString();
                }
                if (row["tel1"] != null)
                {
                    model.tel1 = row["tel1"].ToString();
                }
                if (row["ftel"] != null)
                {
                    model.ftel = row["ftel"].ToString();
                }
                if (row["tel2"] != null)
                {
                    model.tel2 = row["tel2"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_AddressList> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,aname,adname,adcode,tel1,ftel,tel2 ");
            strSql.AppendFormat(" FROM Sys_AddressList where 1=1 {0}", strWhere);
            List<Sys_AddressList> r = new List<Sys_AddressList>();
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
