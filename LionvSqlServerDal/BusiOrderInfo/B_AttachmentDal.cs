using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AttachmentDal : IB_AttachmentDal
    { 
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_Attachment");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_Attachment(");
            strSql.Append("sid,gsid,ftype,fname,furl,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@ftype,@fname,@furl,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@ftype", SqlDbType.NVarChar,20),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@furl", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.ftype;
            parameters[3].Value = model.fname;
            parameters[4].Value = model.furl;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;

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
        public bool Update(B_Attachment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_Attachment set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gsid=@gsid,");
            strSql.Append("ftype=@ftype,");
            strSql.Append("fname=@fname,");
            strSql.Append("furl=@furl,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@ftype", SqlDbType.NVarChar,20),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
					new SqlParameter("@furl", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.ftype;
            parameters[3].Value = model.fname;
            parameters[4].Value = model.furl;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
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
            strSql.Append("delete from B_Attachment ");
            strSql.AppendFormat(" where 1=1 {0}",where);
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
        public B_Attachment Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,ftype,fname,furl,maker,cdate from B_Attachment ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_Attachment r = new B_Attachment();
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
        public B_Attachment DataRowToModel(DataRow row)
        {
            B_Attachment model = new B_Attachment();
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
                if (row["gsid"] != null)
                {
                    model.gsid = row["gsid"].ToString();
                }
                if (row["ftype"] != null)
                {
                    model.ftype = row["ftype"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["furl"] != null)
                {
                    model.furl = row["furl"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_Attachment> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gsid,ftype,fname,furl,maker,cdate ");
            strSql.Append(" FROM B_Attachment ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_Attachment> r = new List<B_Attachment>();
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
