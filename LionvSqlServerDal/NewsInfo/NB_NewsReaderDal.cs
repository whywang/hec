using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.NewsInfo;
using LionvModel.NewsInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.NewsInfo
{
    public class NB_NewsReaderDal : INB_NewsReaderDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( NB_NewsReader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NB_NewsReader(");
            strSql.Append("nid,dname,dcode,ename,cdate)");
            strSql.Append(" values (");
            strSql.Append("@nid,@dname,@dcode,@ename,@cdate);");
 
            SqlParameter[] parameters = {
					new SqlParameter("@nid", SqlDbType.Int,4),
					new SqlParameter("@dname", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@ename", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.nid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.cdate;
            strSql.AppendFormat("update  NB_News  set nreadnum=nreadnum+1 where id={0}", model.nid);
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
        public bool Update( NB_NewsReader model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update NB_NewsReader set ");
            strSql.Append("nid=@nid,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("ename=@ename,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@nid", SqlDbType.Int,4),
					new SqlParameter("@dname", SqlDbType.NVarChar,20),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@ename", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.nid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.id;

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
 
            strSql.AppendFormat("delete from NB_NewsReader where 1=1 {0}", where);
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
        public  NB_NewsReader Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,nid,dname,dcode,ename,cdate from NB_NewsReader ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            NB_NewsReader r = new NB_NewsReader();
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
        public  NB_NewsReader DataRowToModel(DataRow row)
        {
             NB_NewsReader model = new  NB_NewsReader();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["nid"] != null && row["nid"].ToString() != "")
                {
                    model.nid = int.Parse(row["nid"].ToString());
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["ename"] != null)
                {
                    model.ename = row["ename"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<NB_NewsReader> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,nid,dname,dcode,ename,cdate  FROM NB_NewsReader");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<NB_NewsReader> r = new List<NB_NewsReader>();
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
