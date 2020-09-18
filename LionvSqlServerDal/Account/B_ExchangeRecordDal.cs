using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.Account
{
    public class B_ExchangeRecordDal : IB_ExchangeRecordDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_ExchangeRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_ExchangeRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ExchangeRecord(");
            strSql.Append("sid,osid,sacode,oscode,etype,otype,emoney,umoney,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@osid,@sacode,@oscode,@etype,@otype,@emoney,@umoney,@cdate)");
     
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@etype", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@emoney", SqlDbType.Decimal,9),
					new SqlParameter("@umoney", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.osid;
            parameters[2].Value = model.sacode;
            parameters[3].Value = model.oscode;
            parameters[4].Value = model.etype;
            parameters[5].Value = model.otype;
            parameters[6].Value = model.emoney;
            parameters[7].Value = model.umoney;
            parameters[8].Value = model.cdate;

            object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
        public bool Update(B_ExchangeRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ExchangeRecord set ");
            strSql.Append("osid=@osid,");
            strSql.Append("sacode=@sacode,");
            strSql.Append("oscode=@oscode,");
            strSql.Append("etype=@etype,");
            strSql.Append("otype=@otype,");
            strSql.Append("emoney=@emoney,");
            strSql.Append("umoney=@umoney,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sacode", SqlDbType.NVarChar,30),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@etype", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@emoney", SqlDbType.Decimal,9),
					new SqlParameter("@umoney", SqlDbType.Decimal,9),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.osid;
            parameters[1].Value = model.sacode;
            parameters[2].Value = model.oscode;
            parameters[3].Value = model.etype;
            parameters[4].Value = model.otype;
            parameters[5].Value = model.emoney;
            parameters[6].Value = model.umoney;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.id;
            parameters[9].Value = model.sid;

            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
            strSql.AppendFormat("delete from B_ExchangeRecord where 1=1 {0}", where);
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
        public B_ExchangeRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,osid,sacode,oscode,etype,otype,emoney,umoney,cdate from B_ExchangeRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_ExchangeRecord r = new B_ExchangeRecord();
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
        public B_ExchangeRecord DataRowToModel(DataRow row)
        {
            B_ExchangeRecord model = new B_ExchangeRecord();
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
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["sacode"] != null)
                {
                    model.sacode = row["sacode"].ToString();
                }
                if (row["oscode"] != null)
                {
                    model.oscode = row["oscode"].ToString();
                }
                if (row["etype"] != null)
                {
                    model.etype = row["etype"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["emoney"] != null && row["emoney"].ToString() != "")
                {
                    model.emoney = decimal.Parse(row["emoney"].ToString());
                }
                if (row["umoney"] != null && row["umoney"].ToString() != "")
                {
                    model.umoney = decimal.Parse(row["umoney"].ToString());
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
        public List<B_ExchangeRecord> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,osid,sacode,oscode,etype,otype,emoney,umoney,cdate ");
            strSql.Append(" FROM B_ExchangeRecord ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_ExchangeRecord> r = new List<B_ExchangeRecord>();
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

      
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
