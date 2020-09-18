using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_ProduceGyImgDal : IB_ProduceGyImgDal
    {
        #region  BasicMethod
 
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_ProduceGyImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_ProduceGyImg(");
            strSql.Append("sid,gsid,gname,gurl,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gsid,@gname,@gurl,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50),
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@gurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gsid;
            parameters[2].Value = model.gname;
            parameters[3].Value = model.gurl;
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
        public bool Update(B_ProduceGyImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_ProduceGyImg set ");
            strSql.Append("sid=@sid,");
            strSql.Append("gname=@gname,");
            strSql.Append("gurl=@gurl,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where gsid=@gsid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@gurl", SqlDbType.NVarChar,100),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@gsid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gname;
            parameters[2].Value = model.gurl;
            parameters[3].Value = model.cdate;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.gsid;

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
        public bool Delete(string gsid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_ProduceGyImg ");
            strSql.AppendFormat(" where gsid='{0}' ",gsid);
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
        public  B_ProduceGyImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gsid,gname,gurl,cdate,maker from B_ProduceGyImg ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_ProduceGyImg r = new B_ProduceGyImg();
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
        public  B_ProduceGyImg DataRowToModel(DataRow row)
        {
            B_ProduceGyImg model = new  B_ProduceGyImg();
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
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["gurl"] != null)
                {
                    model.gurl = row["gurl"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }
 
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<B_ProduceGyImg> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" id,sid,gsid,gname,gurl,cdate,maker ");
            strSql.Append(" FROM B_ProduceGyImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_ProduceGyImg> r = new List<B_ProduceGyImg>();
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
