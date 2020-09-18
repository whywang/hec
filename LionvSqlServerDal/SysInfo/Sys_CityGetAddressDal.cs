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
    public class Sys_CityGetAddressDal : ISys_CityGetAddressDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_CityGetAddress");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionString, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_CityGetAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_CityGetAddress(");
            strSql.Append("sacode,gperson,dname,dcode,address,isfrist,maker,cdate,telephone)");
            strSql.Append(" values (");
            strSql.Append("@sacode,@gperson,@dname,@dcode,@address,@isfrist,@maker,@cdate,@telephone)");
            SqlParameter[] parameters = {
					new SqlParameter("@sacode", SqlDbType.NVarChar,10),
					new SqlParameter("@gperson", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,150),
					new SqlParameter("@isfrist", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sacode;
            parameters[1].Value = model.gperson;
            parameters[2].Value = model.dname;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.address;
            parameters[5].Value = model.isfrist;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.telephone;
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
        public bool Update(Sys_CityGetAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_CityGetAddress set ");
            strSql.Append("gperson=@gperson,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("address=@address,");
            strSql.Append("isfrist=@isfrist,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("telephone=@telephone");
            strSql.Append(" where sacode=@sacode");
            SqlParameter[] parameters = {
					new SqlParameter("@gperson", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,150),
					new SqlParameter("@isfrist", SqlDbType.Bit,1),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@sacode", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.gperson;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.address;
            parameters[4].Value = model.isfrist;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.telephone;
            parameters[8].Value = model.sacode;
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
            strSql.Append("delete from Sys_CityGetAddress ");
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
        public Sys_CityGetAddress Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sacode,gperson,dname,dcode,address,isfrist,maker,cdate,telephone from Sys_CityGetAddress ");
            strSql.AppendFormat(" where 1=1 {0}", where.ToString());
            Sys_CityGetAddress r = new Sys_CityGetAddress();
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
        public Sys_CityGetAddress DataRowToModel(DataRow row)
        {
            Sys_CityGetAddress model = new Sys_CityGetAddress();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sacode"] != null)
                {
                    model.sacode = row["sacode"].ToString();
                }
                if (row["gperson"] != null)
                {
                    model.gperson = row["gperson"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["isfrist"] != null && row["isfrist"].ToString() != "")
                {
                    if ((row["isfrist"].ToString() == "1") || (row["isfrist"].ToString().ToLower() == "true"))
                    {
                        model.isfrist = true;
                    }
                    else
                    {
                        model.isfrist = false;
                    }
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
        public List<Sys_CityGetAddress> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sacode,gperson,dname,dcode,address,isfrist,maker,cdate,telephone ");
            strSql.AppendFormat(" FROM Sys_CityGetAddress where 1=1 {0}", strWhere);
            List<Sys_CityGetAddress> r = new List<Sys_CityGetAddress>();
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
            string sql = "select isnull(max(convert(int,sacode)),0) as n from Sys_CityGetAddress ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionString, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion  ExtensionMethod
    }
}
