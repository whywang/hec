using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using ViewModel.Account;
using LionvCommonDal;

namespace LionvSqlServerDal.Account
{
    public class A_CustomeAccountDal : IA_CustomeAccountDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from A_CustomeAccount");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( A_CustomeAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into A_CustomeAccount(");
            strSql.Append("sid,cityname,citycode,dname,dcode,customer,telephone,address,scode,pmoney,ptype,pcate,pstate,ddate,remark,cdate,gsid,pmethod)");
            strSql.Append(" values (");
            strSql.Append("@sid,@cityname,@citycode,@dname,@dcode,@customer,@telephone,@address,@scode,@pmoney,@ptype,@pcate,@pstate,@ddate,@remark,@cdate,@gsid,@pmethod)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@cityname", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@ptype", SqlDbType.Int,4),
					new SqlParameter("@pcate", SqlDbType.NVarChar,30),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@ddate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@gsid", SqlDbType.NVarChar,50),
                    new SqlParameter("@pmethod", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.cityname;
            parameters[2].Value = model.citycode;
            parameters[3].Value = model.dname;
            parameters[4].Value = model.dcode;
            parameters[5].Value = model.customer;
            parameters[6].Value = model.telephone;
            parameters[7].Value = model.address;
            parameters[8].Value = model.scode;
            parameters[9].Value = model.pmoney;
            parameters[10].Value = model.ptype;
            parameters[11].Value = model.pcate;
            parameters[12].Value = model.pstate;
            parameters[13].Value = model.ddate;
            parameters[14].Value = model.remark;
            parameters[15].Value = model.maker;
            parameters[16].Value = model.cdate;
            parameters[17].Value = model.gsid;
            parameters[18].Value = model.pmethod;
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
        public bool Update( A_CustomeAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update A_CustomeAccount set ");
            strSql.Append("cityname=@cityname,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("scode=@scode,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("ptype=@ptype,");
            strSql.Append("pcate=@pcate,");
            strSql.Append("pstate=@pstate,");
            strSql.Append("ddate=@ddate,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("pmethod=@pmethod,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where gsid=@gsid");
            SqlParameter[] parameters = {
					new SqlParameter("@cityname", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@ptype", SqlDbType.Int,4),
					new SqlParameter("@pcate", SqlDbType.NVarChar,30),
					new SqlParameter("@pstate", SqlDbType.Int,4),
					new SqlParameter("@ddate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@pmethod", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@gsid",  SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cityname;
            parameters[1].Value = model.citycode;
            parameters[2].Value = model.dname;
            parameters[3].Value = model.dcode;
            parameters[4].Value = model.customer;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.address;
            parameters[7].Value = model.scode;
            parameters[8].Value = model.pmoney;
            parameters[9].Value = model.ptype;
            parameters[10].Value = model.pcate;
            parameters[11].Value = model.pstate;
            parameters[12].Value = model.ddate;
            parameters[13].Value = model.remark;
            parameters[14].Value = model.maker;
            parameters[15].Value = model.pmethod;
            parameters[16].Value = model.cdate;
            parameters[17].Value = model.gsid;

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
            strSql.AppendFormat("delete from A_CustomeAccount where 1=1 {0}", where);
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
        public A_CustomeAccount Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,gsid,sid,cityname,citycode,dname,dcode,customer,telephone,address,scode,pmoney,ptype,pcate,pstate,ddate,remark,cdate,maker,pmethod from A_CustomeAccount ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            A_CustomeAccount r = new A_CustomeAccount();
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
        public  A_CustomeAccount DataRowToModel(DataRow row)
        {
             A_CustomeAccount model = new  A_CustomeAccount();
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
                if (row["gsid"] != null && row["gsid"].ToString() != "")
                {
                    model.gsid = row["gsid"].ToString();
                }
                if (row["cityname"] != null)
                {
                    model.cityname = row["cityname"].ToString();
                }
                if (row["citycode"] != null)
                {
                    model.citycode = row["citycode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["pmethod"] != null)
                {
                    model.pmethod = row["pmethod"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["pmoney"] != null && row["pmoney"].ToString() != "")
                {
                    model.pmoney = decimal.Parse(row["pmoney"].ToString());
                }
                if (row["ptype"] != null && row["ptype"].ToString() != "")
                {
                    model.ptype = int.Parse(row["ptype"].ToString());
                }
                if (row["pcate"] != null)
                {
                    model.pcate = row["pcate"].ToString();
                }
                if (row["pstate"] != null && row["pstate"].ToString() != "")
                {
                    model.pstate = int.Parse(row["pstate"].ToString());
                }
                if (row["ddate"] != null && row["ddate"].ToString() != "")
                {
                    model.ddate = row["ddate"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["maker"] != null && row["maker"].ToString() != "")
                {
                    model.maker = row["maker"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<A_CustomeAccount> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,gsid,sid,cityname,citycode,dname,dcode,customer,telephone,address,scode,pmoney,ptype,pcate,pstate,ddate,remark,cdate,maker,pmethod ");
            strSql.Append(" FROM A_CustomeAccount ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<A_CustomeAccount> r = new List<A_CustomeAccount>();
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
        public VCustomeAccount QueryCustomeAccount(string where)
        {
            VCustomeAccount vca = new VCustomeAccount();
            vca.amoney = QueryAllMoney(where);
            vca.kymoney = QueryKyMoney(where);
            vca.dsmoney = QueryDsMoney(where);
            vca.dfmoney = QueryDfMoney(where);
            return vca;
        }
        #region//客户账户信息
        private string QueryAllMoney(string where)
        {
            decimal am = 0;
            decimal pm = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSql.Append(" FROM A_CustomeAccount ");
            strSql.AppendFormat(" where ptype=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                am = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                am = 0;
            }
            StringBuilder strSqlt = new StringBuilder();
            strSqlt.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSqlt.Append(" FROM A_CustomeAccount ");
            strSqlt.AppendFormat(" where ptype=-1 and pstate=1 {0}", where);
            DataTable dtt = SqlHelp.GetDataTable2(CommandType.Text, strSqlt.ToString(), null);
            if (dtt != null)
            {
                pm = Convert.ToDecimal(dtt.Rows[0][0].ToString());
            }
            else
            {
                pm = 0;
            }
            return (am-pm).ToString();
        }
        private string QueryKyMoney(string where)
        {
            decimal am = 0;
            decimal pm = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSql.Append(" FROM A_CustomeAccount ");
            strSql.AppendFormat(" where ptype=1 and pstate=1 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                am = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                am = 0;
            }
            StringBuilder strSqlt = new StringBuilder();
            strSqlt.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSqlt.Append(" FROM A_CustomeAccount ");
            strSqlt.AppendFormat(" where ptype=-1 {0}", where);
            DataTable dtt = SqlHelp.GetDataTable2(CommandType.Text, strSqlt.ToString(), null);
            if (dtt != null)
            {
                pm = Convert.ToDecimal(dtt.Rows[0][0].ToString());
            }
            else
            {
                pm = 0;
            }
            return (am - pm).ToString();
        }
        private string QueryDsMoney(string where)
        {
            decimal am = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSql.Append(" FROM A_CustomeAccount ");
            strSql.AppendFormat(" where ptype=1 and pstate=0 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                am = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                am = 0;
            }
            return am.ToString();
        }
        private string QueryDfMoney(string where)
        {
            decimal am = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  isnull( sum(pmoney),0)  as omoney");
            strSql.Append(" FROM A_CustomeAccount ");
            strSql.AppendFormat(" where ptype=-1 and pstate=0 {0}", where);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                am = Convert.ToDecimal(dt.Rows[0][0].ToString());
            }
            else
            {
                am = 0;
            }
            return am.ToString();
        }
        #endregion
        #region//
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("A_CustomeAccount", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(A_CustomeAccount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update A_CustomeAccount set ");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("scode=@scode,");
            strSql.Append("pmoney=@pmoney,");
            strSql.Append("ddate=@ddate,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("pmethod=@pmethod,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {

					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,11),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pmoney", SqlDbType.Decimal,9),
					new SqlParameter("@ddate", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@maker", SqlDbType.NVarChar,30),
                    new SqlParameter("@pmethod", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
 
            parameters[0].Value = model.customer;
            parameters[1].Value = model.telephone;
            parameters[2].Value = model.address;
            parameters[3].Value = model.scode;
            parameters[4].Value = model.pmoney;
            parameters[5].Value = model.ddate;
            parameters[6].Value = model.remark;
            parameters[7].Value = model.maker;
            parameters[8].Value = model.pmethod;
            parameters[9].Value = model.cdate;
            parameters[10].Value = model.sid;

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
        #endregion  ExtensionMethod
    }
}
