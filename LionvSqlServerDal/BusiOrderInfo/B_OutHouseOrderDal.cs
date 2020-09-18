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
    public class B_OutHouseOrderDal : IB_OutHouseOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_OutHouseOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
 
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_OutHouseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_OutHouseOrder(");
            strSql.Append("sid,osid,ocode,state,estimatedate,ps,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@osid,@ocode,@state,@estimatedate,@ps,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@ocode", SqlDbType.NVarChar,30),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@estimatedate", SqlDbType.DateTime),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.osid;
            parameters[2].Value = model.ocode;
            parameters[3].Value = model.state;
            parameters[4].Value = model.estimatedate;
            parameters[5].Value = model.ps;
            parameters[6].Value = model.maker;
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
        public bool Update( B_OutHouseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_OutHouseOrder set ");
            strSql.Append("sid=@sid,");
            strSql.Append("ocode=@ocode,");
            strSql.Append("state=@state,");
            strSql.Append("estimatedate=@estimatedate,");
            strSql.Append("ps=@ps,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@ocode", SqlDbType.NVarChar,30),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@estimatedate", SqlDbType.DateTime,3),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@osid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.ocode;
            parameters[2].Value = model.state;
            parameters[3].Value = model.estimatedate;
            parameters[4].Value = model.ps;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.id;
            parameters[8].Value = model.osid;
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
            strSql.AppendFormat("delete from B_OutHouseOrder where 1=1 {0}", where);
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
        public B_OutHouseOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,osid,ocode,state,estimatedate,ps,maker,cdate from B_OutHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_OutHouseOrder r = new B_OutHouseOrder();
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
        public  B_OutHouseOrder DataRowToModel(DataRow row)
        {
             B_OutHouseOrder model = new  B_OutHouseOrder();
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
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["ocode"] != null)
                {
                    model.ocode = row["ocode"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["estimatedate"] != null && row["estimatedate"].ToString() != "")
                {
                    model.estimatedate = row["estimatedate"].ToString( );
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
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
        public List<B_OutHouseOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,osid,ocode,state,estimatedate,ps,maker,cdate ");
            strSql.Append(" FROM B_OutHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_OutHouseOrder> r = new List<B_OutHouseOrder>();
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
