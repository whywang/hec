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
    public class B_MzDesignPlanDal : IB_MzDesignPlanDal
    {
        #region
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_MzDesignPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_MzDesignPlan(");
            strSql.Append("sid,place,pname,purl,maker,cdate,pnum,ptype)");
            strSql.Append(" values (");
            strSql.Append("@sid,@place,@pname,@purl,@maker,@cdate,@pnum,@ptype)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@purl", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@pnum", SqlDbType.Int),
                    new SqlParameter("@ptype", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.place;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.purl;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.pnum;
            parameters[7].Value = model.ptype;
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
        public bool Update(B_MzDesignPlan model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzDesignPlan set ");
            strSql.Append("sid=@sid,");
            strSql.Append("place=@place,");
            strSql.Append("pname=@pname,");
            strSql.Append("purl=@purl,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.NVarChar,30),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@purl", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.place;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.purl;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.id;

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
            strSql.Append("delete from B_MzDesignPlan ");
            strSql.AppendFormat(" where 1=1 {0} ", where);
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
        public B_MzDesignPlan Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,place,pname,purl,maker,cdate,pnum,ptype from B_MzDesignPlan ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_MzDesignPlan r = new B_MzDesignPlan();
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
        public B_MzDesignPlan DataRowToModel(DataRow row)
        {
            B_MzDesignPlan model = new B_MzDesignPlan();
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
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["purl"] != null)
                {
                    model.purl = row["purl"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = Convert.ToInt32(row["pnum"].ToString());
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_MzDesignPlan> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,place,pname,purl,maker,cdate ,pnum ,ptype ");
            strSql.Append(" FROM B_MzDesignPlan ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_MzDesignPlan> r = new List<B_MzDesignPlan>();
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
