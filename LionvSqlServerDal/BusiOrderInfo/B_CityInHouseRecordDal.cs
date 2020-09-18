using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.BusiOrderInfo
{
    class B_CityInHouseRecordDal : IB_CityInHouseRecordDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CityInHouseRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_CityInHouseRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CityInHouseRecord(");
            strSql.Append("sid,ccode,bnum,rperson,rdate,remarke,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@ccode,@bnum,@rperson,@rdate,@remarke,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@bnum", SqlDbType.Int,4),
					new SqlParameter("@rperson", SqlDbType.NVarChar,20),
					new SqlParameter("@rdate", SqlDbType.DateTime),
					new SqlParameter("@remarke", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.bnum;
            parameters[3].Value = model.rperson;
            parameters[4].Value = model.rdate;
            parameters[5].Value = model.remarke;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            int r = 0;
            try
            {
                r = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update(B_CityInHouseRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CityInHouseRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("ccode=@ccode,");
            strSql.Append("bnum=@bnum,");
            strSql.Append("rperson=@rperson,");
            strSql.Append("rdate=@rdate,");
            strSql.Append("remarke=@remarke,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@bnum", SqlDbType.Int,4),
					new SqlParameter("@rperson", SqlDbType.NVarChar,20),
					new SqlParameter("@rdate", SqlDbType.DateTime),
					new SqlParameter("@remarke", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NChar,10),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.bnum;
            parameters[3].Value = model.rperson;
            parameters[4].Value = model.rdate;
            parameters[5].Value = model.remarke;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.id;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
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
            strSql.AppendFormat("delete from B_CityInHouseRecord where 1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_CityInHouseRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,ccode,bnum,rperson,rdate,remarke,maker,cdate from B_CityInHouseRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CityInHouseRecord r = new B_CityInHouseRecord();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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
        public B_CityInHouseRecord DataRowToModel(DataRow row)
        {
            B_CityInHouseRecord model = new B_CityInHouseRecord();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["bnum"] != null && row["bnum"].ToString() != "")
                {
                    model.bnum = int.Parse(row["bnum"].ToString());
                }
                if (row["rperson"] != null)
                {
                    model.rperson = row["rperson"].ToString();
                }
                if (row["rdate"] != null && row["rdate"].ToString() != "")
                {
                    model.rdate = row["rdate"].ToString();
                }
                if (row["remarke"] != null)
                {
                    model.remarke = row["remarke"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_CityInHouseRecord> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,ccode,bnum,rperson,rdate,remarke,maker,cdate ");
            strSql.Append(" FROM B_CityInHouseRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_CityInHouseRecord> r = new List<B_CityInHouseRecord>();
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
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


        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull(sum(bnum),0) as bnum FROM B_CityInHouseRecord ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
