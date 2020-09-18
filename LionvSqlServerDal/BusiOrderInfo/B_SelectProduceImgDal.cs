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
    public class B_SelectProduceImgDal : IB_SelectProduceImgDal
    {
        #region  BasicMethod
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_SelectProduceImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_SelectProduceImg(");
            strSql.Append("sid,xsid,xpname,xpurl,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@xsid,@xpname,@xpurl,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@xsid", SqlDbType.NVarChar,50),
					new SqlParameter("@xpname", SqlDbType.NVarChar,50),
					new SqlParameter("@xpurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.xsid;
            parameters[2].Value = model.xpname;
            parameters[3].Value = model.xpurl;
            parameters[4].Value = model.cdate;
            parameters[5].Value = model.maker;

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
        public bool Update( B_SelectProduceImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SelectProduceImg set ");
            strSql.Append("sid=@sid,");
            strSql.Append("xpname=@xpname,");
            strSql.Append("xpurl=@xpurl,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where xsid=@xsid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@xpname", SqlDbType.NVarChar,50),
					new SqlParameter("@xpurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@xsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.xpname;
            parameters[2].Value = model.xpurl;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.xsid;

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
        public bool Delete(string xsid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_SelectProduceImg ");
            strSql.AppendFormat(" where xsid='{0}' ", xsid);
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
        public  B_SelectProduceImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,xsid,xpname,xpurl,cdate,maker from B_SelectProduceImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_SelectProduceImg r = new B_SelectProduceImg();
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
        public  B_SelectProduceImg DataRowToModel(DataRow row)
        {
             B_SelectProduceImg model = new  B_SelectProduceImg();
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
                if (row["xsid"] != null)
                {
                    model.xsid = row["xsid"].ToString();
                }
                if (row["xpname"] != null)
                {
                    model.xpname = row["xpname"].ToString();
                }
                if (row["xpurl"] != null)
                {
                    model.xpurl = row["xpurl"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_SelectProduceImg> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,xsid,xpname,xpurl,cdate,maker ");
            strSql.Append(" FROM B_SelectProduceImg ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_SelectProduceImg> r = new List<B_SelectProduceImg>();
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

        /// <summary>
        /// 获得前几行数据
        /// </summary>
       
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
