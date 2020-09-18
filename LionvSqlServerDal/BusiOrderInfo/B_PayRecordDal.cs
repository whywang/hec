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
    public class B_PayRecordDal : IB_PayRecordDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_PayRecord");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_PayRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_PayRecord(");
            strSql.Append("sid,pmoney,pmoneystr,maker,sname,ps,pdate,cdate,ptype,paccount)");
            strSql.Append(" values (");
            strSql.Append("@sid,@pmoney,@pmoneystr,@maker,@sname,@ps,@pdate,@cdate,@ptype,@paccount)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pmoney", SqlDbType.Money,8),
					new SqlParameter("@pmoneystr", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@sname", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@pdate", SqlDbType.DateTime,3),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@ptype", SqlDbType.NVarChar,10),
					new SqlParameter("@paccount", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pmoney;
            parameters[2].Value = model.pmoneystr;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.sname;
            parameters[5].Value = model.ps;
            parameters[6].Value = model.pdate;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.ptype;
            parameters[9].Value = model.paccount;
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
        public bool Update( B_PayRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_PayRecord set ");
            strSql.Append("sid=@sid,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("pmoneystr=@pmoneystr,");
            strSql.Append("maker=@maker,");
            strSql.Append("sname=@sname,");
            strSql.Append("ps=@ps,");
            strSql.Append("pdate=@pdate,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pmoney", SqlDbType.Money,8),
					new SqlParameter("@pmoneystr", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@sname", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,100),
					new SqlParameter("@pdate", SqlDbType.DateTime,3),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pmoney;
            parameters[2].Value = model.pmoneystr;
            parameters[3].Value = model.maker;
            parameters[4].Value = model.sname;
            parameters[5].Value = model.ps;
            parameters[6].Value = model.pdate;
            parameters[7].Value = model.cdate;
            parameters[8].Value = model.id;
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
            strSql.AppendFormat("delete from B_PayRecord where 1=1 {0}", where);
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
        public  B_PayRecord Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,pmoney,pmoneystr,maker,sname,ps,pdate,cdate,ptype,paccount from B_PayRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_PayRecord r = new B_PayRecord();
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
        public  B_PayRecord DataRowToModel(DataRow row)
        {
            B_PayRecord model = new  B_PayRecord();
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
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["pmoneystr"] != null)
                {
                    model.pmoneystr = row["pmoneystr"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
                }
                if (row["pdate"] != null && row["pdate"].ToString() != "")
                {
                    model.pdate =  row["pdate"].ToString( );
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["ptype"] != null)
                {
                    model.ptype = row["ptype"].ToString();
                }
                if (row["paccount"] != null)
                {
                    model.paccount = row["paccount"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_PayRecord> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,pmoney,pmoneystr,maker,sname,ps,pdate,cdate,ptype,paccount ");
            strSql.Append(" FROM B_PayRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_PayRecord> r = new List<B_PayRecord>();
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
        public decimal GetSkMoney(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull( sum (pmoney),0) as pmoney ");
            strSql.Append(" FROM B_PayRecord ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            r = r + GetCustomerOrderPay(sid);
            return r;
        }
        /// <summary>
        /// 获取预定单收款金额
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public decimal GetSkMoneyEx(string where)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull( sum (pmoney),0) as pmoney ");
            strSql.Append(" FROM B_PayRecord ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                r = 0;
            }
            return r;
        }
        private decimal GetCustomerOrderPay(string sid)
        {
            decimal r = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select isnull( sum (pmoney),0) as pmoney ");
            strSql.Append(" FROM B_PayRecord ");
            strSql.AppendFormat(" where sid=(select csid from B_SaleOrder where sid='{0}')", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = Convert.ToDecimal(dt.Rows[0][0].ToString());
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
