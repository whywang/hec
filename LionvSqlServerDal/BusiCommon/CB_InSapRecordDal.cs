using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_InSapRecordDal : ICB_InSapRecordDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CB_InSapRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }

        /// 增加一条数据
        /// </summary>
        public int Add(CB_InSapRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_InSapRecord(");
            strSql.Append("sid,stype,istate,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@stype,@istate,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@stype", SqlDbType.NVarChar,50),
					new SqlParameter("@istate", SqlDbType.Int,4),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.stype;
            parameters[2].Value = model.istate;
            parameters[3].Value = model.cdate;

            try
            {
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
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CB_InSapRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_InSapRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("stype=@stype,");
            strSql.Append("istate=@istate,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@stype", SqlDbType.NVarChar,50),
					new SqlParameter("@istate", SqlDbType.Int,4),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.stype;
            parameters[2].Value = model.istate;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.id;

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
            strSql.Append("delete from CB_InSapRecord ");
            strSql.AppendFormat(" where 1=1 {0}  ",where);
            int rows = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
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
        public CB_InSapRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,stype,istate,cdate from CB_InSapRecord ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            CB_InSapRecord r = new CB_InSapRecord();
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
        public CB_InSapRecord DataRowToModel(DataRow row)
        {
            CB_InSapRecord model = new CB_InSapRecord();
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
                if (row["stype"] != null)
                {
                    model.stype = row["stype"].ToString();
                }
                if (row["istate"] != null && row["istate"].ToString() != "")
                {
                    model.istate = int.Parse(row["istate"].ToString());
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
        public List<CB_InSapRecord> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,stype,istate,cdate ");
            strSql.AppendFormat(" FROM CB_InSapRecord where 1=1 {0}",strWhere);
            List<CB_InSapRecord> r = new List<CB_InSapRecord>();
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
