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
    public class B_InHouseOrderDal : IB_InHouseOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_InHouseOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
          
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_InHouseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_InHouseOrder(");
            strSql.Append("sid,isid,icode,ps,state,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@isid,@icode,@ps,@state,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@isid", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.isid;
            parameters[2].Value = model.icode;
            parameters[3].Value = model.ps;
            parameters[4].Value = model.state;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
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
        public bool Update(B_InHouseOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_InHouseOrder set ");
            strSql.Append("sid=@sid,");
            strSql.Append("icode=@icode,");
            strSql.Append("ps=@ps,");
            strSql.Append("state=@state,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@icode", SqlDbType.NVarChar,30),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@isid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.icode;
            parameters[2].Value = model.ps;
            parameters[3].Value = model.state;
            parameters[4].Value = model.maker;
            parameters[5].Value = model.cdate;
            parameters[6].Value = model.id;
            parameters[7].Value = model.isid;
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
            strSql.AppendFormat("delete from B_InHouseOrder where 1=1 {0}", where);
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
        public B_InHouseOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,isid,icode,ps,state,maker,cdate from B_InHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_InHouseOrder r = new B_InHouseOrder();
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
        private B_InHouseOrder DataRowToModel(DataRow row)
        {
            B_InHouseOrder model = new B_InHouseOrder();
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
                if (row["isid"] != null)
                {
                    model.isid = row["isid"].ToString();
                }
                if (row["icode"] != null)
                {
                    model.icode = row["icode"].ToString();
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
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
        public List<B_InHouseOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,isid,icode,ps,state,maker,cdate ");
            strSql.Append(" FROM B_InHouseOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_InHouseOrder> r = new List<B_InHouseOrder>();
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
        public int QueryIorderNum(string strWhere)
        {
            int r = -1;
            string sql = "select  count(1) as n from B_InHouseOrder where 1=1 " + strWhere;
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SaveQualityOrder(B_InHouseOrder bpqo, List<B_InhousePackage> lq)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo.B_InHouseOrder(sid,isid,icode,ps,state,maker,cdate)");
            strSql.AppendFormat(" values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}'); ", bpqo.sid, bpqo.isid, bpqo.icode, bpqo.ps, bpqo.state, bpqo.maker, bpqo.cdate);
            if (lq != null)
            {
                foreach (B_InhousePackage bi in lq)
                {
                    strSql.Append("insert into dbo.B_InhousePackage (sid ,isid,pid,maker,cdate )");
                    strSql.AppendFormat(" values ('{0}','{1}',{2},'{3}','{4}'); ", bi.sid, bi.isid, bi.pid, bi.maker, bi.cdate);
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r; 
        }
        #endregion  ExtensionMethod
    }
}
