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
    public class B_MeasureImgDal : IB_MeasureImgDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_MeasureImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
     
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_MeasureImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_MeasureImg(");
            strSql.Append("csid,url,imgname ,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@csid,@url,@imgname,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,80),
                    new SqlParameter("@imgname", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.url;
            parameters[2].Value = model.imgname;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.cdate;
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
        public bool Update(B_MeasureImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MeasureImg set ");
            strSql.Append("csid=@csid,");
            strSql.Append("url=@url,");
            strSql.Append("maker=@maker,");
            strSql.Append("imgname=@imgname,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,80),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@imgname", SqlDbType.NVarChar,50),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.url;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.imgname;
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
            strSql.AppendFormat("delete from B_MeasureImg where 1=1 {0}", where);
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
        public B_MeasureImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,csid,url,imgname,maker,cdate from B_MeasureImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_MeasureImg r = new B_MeasureImg();
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
        private B_MeasureImg DataRowToModel(DataRow row)
        {
             B_MeasureImg model = new  B_MeasureImg();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["csid"] != null)
                {
                    model.csid = row["csid"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["imgname"] != null)
                {
                    model.imgname = row["imgname"].ToString();
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
        public List<B_MeasureImg> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,csid,url,imgname,maker,cdate ");
            strSql.Append(" FROM B_MeasureImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_MeasureImg> r = new List<B_MeasureImg>();
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
        public bool DeleteList(string[] id)
        {
            bool r = false;
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < id.Length; i++)
            {
                strSql.AppendFormat("delete from B_MeasureImg where id= {0}", id[i]);
            }
            if (strSql.ToString() != "")
            {
                if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
                {
                    r = true;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
