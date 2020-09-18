using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_CustomerGatherDal : IB_CustomerGatherDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CustomerGather");
            strSql.AppendFormat(" where 1=1 {0} ", sid);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_CustomerGather model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CustomerGather(");
            strSql.Append("sid,gmoney,gmethod,remark,gperson,gdate,cdate,maker)");
            strSql.Append(" values (");
            strSql.Append("@sid,@gmoney,@gmethod,@remark,@gperson,@gdate,@cdate,@maker)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@gmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@gperson", SqlDbType.NVarChar,20),
                    	new SqlParameter("@gdate", SqlDbType.DateTime),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.gmoney;
            parameters[2].Value = model.gmethod;
            parameters[3].Value = model.remark;
            parameters[4].Value = model.gperson;
            parameters[5].Value = model.gdate;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.maker;

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
        public bool Update( B_CustomerGather model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_CustomerGather set ");
            strSql.Append("gmoney=@gmoney,");
            strSql.Append("gmethod=@gmethod,");
            strSql.Append("remark=@remark,");
            strSql.Append("gperson=@gperson,");
            strSql.Append("gdate=@gdate,");
            strSql.Append("maker=@maker");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@gmoney", SqlDbType.Decimal,9),
					new SqlParameter("@gmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@gperson", SqlDbType.NVarChar,20),
					new SqlParameter("@gdate", SqlDbType.DateTime),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.gmoney;
            parameters[1].Value = model.gmethod;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.gperson;
            parameters[4].Value = model.gdate;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.sid;

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
        public bool Delete(string sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from B_CustomerGather ");
            strSql.Append(" where sid=@sid ");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = sid;

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
        /// 得到一个对象实体
        /// </summary>
        public  B_CustomerGather Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,gmoney,gmethod,remark,gperson,cdate,gdate,maker from B_CustomerGather ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CustomerGather r = new B_CustomerGather();
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
        public  B_CustomerGather DataRowToModel(DataRow row)
        {
             B_CustomerGather model = new  B_CustomerGather();
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
                if (row["gmoney"] != null && row["gmoney"].ToString() != "")
                {
                    model.gmoney = decimal.Parse(row["gmoney"].ToString());
                }
                if (row["gmethod"] != null)
                {
                    model.gmethod = row["gmethod"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["gperson"] != null)
                {
                    model.gperson = row["gperson"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["gdate"] != null && row["gdate"].ToString() != "")
                {
                    model.gdate = row["gdate"].ToString();
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
        public List<B_CustomerGather> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,gmoney,gmethod,remark,gperson,gdate,cdate,maker ");
            strSql.Append(" FROM B_CustomerGather ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_CustomerGather> r = new List<B_CustomerGather>();
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
        #region//获取正常订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_CustomerGatherOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
            if (dt != null)
            {
                r = dt;
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
