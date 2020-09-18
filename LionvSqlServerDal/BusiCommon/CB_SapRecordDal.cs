using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;
using LionvIDal.BusiCommon;

namespace LionvSqlServerDal.BusiCommon
{
    public class CB_SapRecordDal : ICB_SapRecordDal
    {
        #region  BasicMethod
 

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( CB_SapRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CB_SapRecord(");
            strSql.Append("sid,backstr,mstr,cdate,itype)");
            strSql.Append(" values (");
            strSql.Append("@sid,@backstr,@mstr,@cdate,@itype)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@backstr", SqlDbType.NVarChar,200),
                    new SqlParameter("@mstr", SqlDbType.NVarChar,-1),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                                        new SqlParameter("@itype", SqlDbType.NVarChar,10)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.backstr;
            parameters[2].Value = model.mstr;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.itype;
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
        public bool Update( CB_SapRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CB_SapRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("backstr=@backstr,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@backstr", SqlDbType.NVarChar,200),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.backstr;
            parameters[2].Value = model.cdate;
            parameters[3].Value = model.id;

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
            strSql.Append("delete from CB_SapRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
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
        public  CB_SapRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,backstr,mstr,cdate ,itype from CB_SapRecord ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            CB_SapRecord r = new  CB_SapRecord();
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
        public  CB_SapRecord DataRowToModel(DataRow row)
        {
             CB_SapRecord model = new  CB_SapRecord();
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
                if (row["backstr"] != null)
                {
                    model.backstr = row["backstr"].ToString();
                }
                if (row["mstr"] != null)
                {
                    model.mstr = row["mstr"].ToString();
                }
                if (row["itype"] != null)
                {
                    model.itype = row["itype"].ToString();
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
        public List<CB_SapRecord> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,backstr,mstr,cdate,itype ");
            strSql.AppendFormat(" FROM CB_SapRecord where 1=1 {0}",strWhere);
            List<CB_SapRecord> r = new List<CB_SapRecord>();
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
        public bool AddList(string[] idarr, string backstr, string mstr, string itype)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < idarr.Length; i++)
            {
                strSql.AppendFormat(" insert into CB_SapRecord (sid,backstr,mstr,itype,cdate) values ('{0}','{1}','{2}','{3}',getdate());",  idarr[i].Replace("B", ""),backstr,  mstr,  itype);
            }
            if (strSql.ToString() != "")
            {
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
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}
