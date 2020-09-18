using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterOrderDutyDal : IB_AfterOrderDutyDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_AfterOrderDuty");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_AfterOrderDuty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_AfterOrderDuty(");
            strSql.Append("sid,dname,dcode,dprev,dmoney,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@dname,@dcode,@dprev,@dmoney,@maker,@cdate)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dprev", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.dprev;
            parameters[4].Value = model.dmoney;
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
        public bool Update(B_AfterOrderDuty model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterOrderDuty set ");
            strSql.Append("sid=@sid,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("dprev=@dprev,");
            strSql.Append("dmoney=@dmoney,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@dprev", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.dname;
            parameters[2].Value = model.dcode;
            parameters[3].Value = model.dprev;
            parameters[4].Value = model.dmoney;
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
            strSql.Append("delete from B_AfterOrderDuty ");
            strSql.AppendFormat(" where 1=1 {0}", where);
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
        public B_AfterOrderDuty Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,dname,dcode,dprev,dmoney,maker,cdate from B_AfterOrderDuty ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterOrderDuty r = new B_AfterOrderDuty();
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
        public B_AfterOrderDuty DataRowToModel(DataRow row)
        {
            B_AfterOrderDuty model = new B_AfterOrderDuty();
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
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["dprev"] != null && row["dprev"].ToString() != "")
                {
                    model.dprev = decimal.Parse(row["dprev"].ToString());
                }
                if (row["dmoney"] != null && row["dmoney"].ToString() != "")
                {
                    model.dmoney = decimal.Parse(row["dmoney"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
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
        public List<B_AfterOrderDuty> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,dname,dcode,dprev,dmoney,maker,cdate ");
            strSql.Append(" FROM B_AfterOrderDuty ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterOrderDuty> r = new List<B_AfterOrderDuty>();
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
        public int AddList(List<B_AfterOrderDuty> blist)
        {
            StringBuilder strSql = new StringBuilder();
            if (blist != null)
            {
                foreach (B_AfterOrderDuty b in blist)
                {
                    strSql.Append("insert into B_AfterOrderDuty(");
                    strSql.Append("sid,dname,dcode,dprev,dmoney,maker,cdate)");
                    strSql.Append(" values (");
                    strSql.AppendFormat("'{0}','{1}','{2}',{3},{4},'{5}','{6}');", b.sid, b.dname, b.dcode, b.dprev, b.dmoney, b.maker, b.cdate);
                }
                object obj = SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion  ExtensionMethod
    }
}
