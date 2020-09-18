using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_MzRequstDesignDal : IB_MzRequstDesignDal
    {
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_MzRequstDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_MzRequstDesign(");
            strSql.Append("sid,place,url,preqest,pdemo,maker,cdate,pname)");
            strSql.Append(" values (");
            strSql.Append("@sid,@place,@url,@preqest,@pdemo,@maker,@cdate,@pname)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@preqest", SqlDbType.NVarChar,200),
					new SqlParameter("@pdemo", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pname", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.place;
            parameters[2].Value = model.url;
            parameters[3].Value = model.preqest;
            parameters[4].Value = model.pdemo;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.pname;
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
        public bool Update( B_MzRequstDesign model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzRequstDesign set ");
            strSql.Append("sid=@sid,");
            strSql.Append("place=@place,");
            strSql.Append("url=@url,");
            strSql.Append("preqest=@preqest,");
            strSql.Append("pdemo=@pdemo,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.NVarChar,20),
					new SqlParameter("@url", SqlDbType.NVarChar,100),
					new SqlParameter("@preqest", SqlDbType.NVarChar,200),
					new SqlParameter("@pdemo", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.place;
            parameters[2].Value = model.url;
            parameters[3].Value = model.preqest;
            parameters[4].Value = model.pdemo;
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
            strSql.Append("delete from B_MzRequstDesign ");
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
        public  B_MzRequstDesign Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,place,url,preqest,pdemo,maker,cdate,pname from B_MzRequstDesign ");
            strSql.AppendFormat(" where 1=1 {0}",where);
             B_MzRequstDesign r = new  B_MzRequstDesign();
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
        public  B_MzRequstDesign DataRowToModel(DataRow row)
        {
             B_MzRequstDesign model = new  B_MzRequstDesign();
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
                if (row["place"] != null)
                {
                    model.place = row["place"].ToString();
                }
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["preqest"] != null)
                {
                    model.preqest = row["preqest"].ToString();
                }
                if (row["pdemo"] != null)
                {
                    model.pdemo = row["pdemo"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString( );
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_MzRequstDesign> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,place,url,preqest,pdemo,maker,cdate,pname ");
            strSql.Append(" FROM B_MzRequstDesign ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_MzRequstDesign> r = new List<B_MzRequstDesign>();
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
