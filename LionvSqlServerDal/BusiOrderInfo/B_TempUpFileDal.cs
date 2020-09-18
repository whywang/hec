using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_TempUpFileDal : IB_TempUpFileDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_TempUpFile");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_TempUpFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_TempUpFile(");
            strSql.Append("sid,fname,fpname,furl,fsize,fover)");
            strSql.Append(" values (");
            strSql.Append("@sid,@fname,@fpname,@furl,@fsize,@fover)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fname", SqlDbType.NVarChar,50),
					new SqlParameter("@fpname", SqlDbType.NVarChar,50),
					new SqlParameter("@furl", SqlDbType.NVarChar,200),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@fover", SqlDbType.Int,4) };
            parameters[0].Value = model.sid;
            parameters[1].Value = model.fname;
            parameters[2].Value = model.fpname;
            parameters[3].Value = model.furl;
            parameters[4].Value = model.fsize;
            parameters[5].Value = model.fover;


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
        public bool Update(B_TempUpFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_TempUpFile set ");
            strSql.Append("sid=@sid,");
            strSql.Append("fname=@fname,");
            strSql.Append("fpname=@fpname,");
            strSql.Append("furl=@furl,");
            strSql.Append("fsize=@fsize,");
            strSql.Append("fover=@fover,");
            strSql.Append("fdate=@fdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fname", SqlDbType.NVarChar,50),
					new SqlParameter("@fpname", SqlDbType.NVarChar,50),
					new SqlParameter("@furl", SqlDbType.NVarChar,200),
					new SqlParameter("@fsize", SqlDbType.Int,4),
					new SqlParameter("@fover", SqlDbType.Int,4),
					new SqlParameter("@fdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.fname;
            parameters[2].Value = model.fpname;
            parameters[3].Value = model.furl;
            parameters[4].Value = model.fsize;
            parameters[5].Value = model.fover;
            parameters[6].Value = model.fdate;
            parameters[7].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from B_TempUpFile where 1=1 {0}", where);
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
        public B_TempUpFile Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,fname,fpname,furl,fsize,fover,fdate from B_TempUpFile ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_TempUpFile r = new B_TempUpFile();
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
        public B_TempUpFile DataRowToModel(DataRow row)
        {
            B_TempUpFile model = new B_TempUpFile();
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
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fpname"] != null)
                {
                    model.fpname = row["fpname"].ToString();
                }
                if (row["furl"] != null)
                {
                    model.furl = row["furl"].ToString();
                }
                if (row["fsize"] != null && row["fsize"].ToString() != "")
                {
                    model.fsize = int.Parse(row["fsize"].ToString());
                }
                if (row["fover"] != null && row["fover"].ToString() != "")
                {
                    model.fover = int.Parse(row["fover"].ToString());
                }
                if (row["fdate"] != null && row["fdate"].ToString() != "")
                {
                    model.fdate = row["fdate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_TempUpFile> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,fname,fpname,furl,fsize,fover,fdate ");
            strSql.Append(" FROM B_TempUpFile ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_TempUpFile> r = new List<B_TempUpFile>();
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
        public int GetNum(string fname, string sid)
        {
            int r = -1;
            string sql = "select  count(1) as n from B_TempUpFile where fname like '" + fname + "%' and sid='" + sid + "'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool UpOver(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_TempUpFile set fover=1");
            strSql.AppendFormat(" where  1=1 {0}", where);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
