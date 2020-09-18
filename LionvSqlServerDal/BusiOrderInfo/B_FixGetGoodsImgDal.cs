using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_FixGetGoodsImgDal : IB_FixGetGoodsImgDal
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_FixGetGoodsImg");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);

        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_FixGetGoodsImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_FixGetGoodsImg(");
            strSql.Append("sid,url,fixer,gdate,ps,maker,domain,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@url,@fixer,@gdate,@ps,@maker,@domain,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,50),
					new SqlParameter("@fixer", SqlDbType.NVarChar,20),
					new SqlParameter("@gdate", SqlDbType.DateTime),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@domain", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.url;
            parameters[2].Value = model.fixer;
            parameters[3].Value = model.gdate;
            parameters[4].Value = model.ps;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.domain;
            parameters[7].Value = model.cdate;
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
        public bool Update(B_FixGetGoodsImg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_FixGetGoodsImg set ");
            strSql.Append("sid=@sid,");
            strSql.Append("url=@url,");
            strSql.Append("fixer=@fixer,");
            strSql.Append("gdate=@gdate,");
            strSql.Append("ps=@ps,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@url", SqlDbType.NVarChar,50),
					new SqlParameter("@fixer", SqlDbType.NVarChar,20),
					new SqlParameter("@gdate", SqlDbType.DateTime),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.url;
            parameters[2].Value = model.fixer;
            parameters[3].Value = model.gdate;
            parameters[4].Value = model.ps;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.id;
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
            strSql.AppendFormat("delete from B_FixGetGoodsImg where 1=1 {0}", where);
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
        public B_FixGetGoodsImg Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,url,fixer,gdate,ps,maker,cdate,domain from B_FixGetGoodsImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_FixGetGoodsImg r = new B_FixGetGoodsImg();
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
        private B_FixGetGoodsImg DataRowToModel(DataRow row)
        {
            B_FixGetGoodsImg model = new B_FixGetGoodsImg();
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
                if (row["url"] != null)
                {
                    model.url = row["url"].ToString();
                }
                if (row["fixer"] != null)
                {
                    model.fixer = row["fixer"].ToString();
                }
                if (row["gdate"] != null && row["gdate"].ToString() != "")
                {
                    model.gdate = row["gdate"].ToString();
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["domain"] != null)
                {
                    model.domain = row["domain"].ToString();
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
        public List<B_FixGetGoodsImg> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,url,fixer,gdate,ps,maker,cdate ,domain");
            strSql.Append(" FROM B_FixGetGoodsImg ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_FixGetGoodsImg> r = new List<B_FixGetGoodsImg>();
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
