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
    public class B_FixProductionDal : IB_FixProductionDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_FixProduction");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_FixProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_FixProduction(");
            strSql.Append("sid,psid,pname,pcode,pnum,pmoney,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@psid,@pname,@pcode,@pnum,@pmoney,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@psid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@pmoney", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.psid;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.pcode;
            parameters[4].Value = model.pnum;
            parameters[5].Value = model.pmoney;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;

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
        public bool Update(B_FixProduction model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_FixProduction set ");
            strSql.Append("sid=@sid,");
            strSql.Append("pname=@pname,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("pnum=@pnum,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where psid=@psid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pname", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,20),
					new SqlParameter("@pnum", SqlDbType.Decimal,9),
					new SqlParameter("@pmoney", SqlDbType.Money,8),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@psid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pname;
            parameters[2].Value = model.pcode;
            parameters[3].Value = model.pnum;
            parameters[4].Value = model.pmoney;
            parameters[5].Value = model.maker;
            parameters[6].Value = model.cdate;
            parameters[7].Value = model.psid;

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
        public bool Delete(string psid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from B_FixProduction where 1=1 {0}", psid);
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
        public B_FixProduction Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,psid,pname,pcode,pnum,pmoney,maker,cdate from B_FixProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_FixProduction r = new B_FixProduction();
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
        public B_FixProduction DataRowToModel(DataRow row)
        {
            B_FixProduction model = new B_FixProduction();
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
                if (row["psid"] != null)
                {
                    model.psid = row["psid"].ToString();
                }
                if (row["pname"] != null)
                {
                    model.pname = row["pname"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["pnum"] != null && row["pnum"].ToString() != "")
                {
                    model.pnum = decimal.Parse(row["pnum"].ToString());
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
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
        public List<B_FixProduction> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,psid,pname,pcode,pnum,pmoney,maker,cdate ");
            strSql.Append(" FROM B_FixProduction ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_FixProduction> r = new List<B_FixProduction>();
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
        public bool SaveFixProductionList(string sid, List<B_FixProduction> lbf)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from B_FixProduction where sid='" + sid + "'; ",sid);
            if (lbf != null)
            {
                foreach (B_FixProduction bf in lbf)
                {
                    strSql.AppendFormat(" insert into B_FixProduction ( sid , psid , pname , pcode , pnum , pmoney , maker , cdate ) values ('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}');",bf.sid,bf.psid,bf.pname,bf.pcode,bf.pnum,bf.pmoney,bf.maker,DateTime.Now.ToString());
                }
            }
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = true;
            }
            return r;
        }
        public decimal QueryOrderMoney(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(pnum*pmoney),0) as omoney from B_FixProduction ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            decimal r = 0;
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r =Convert.ToDecimal(dt.Rows[0][0]);
            }
            else
            {
                r = 0;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
