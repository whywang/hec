using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.Account;
using LionvModel.Account;
using System.Data;
using LionvCommon;
using System.Data.SqlClient;

namespace LionvSqlServerDal.Account
{
   public class Bk_PaymentOrderDal : IBk_PaymentOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Bk_PaymentOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Bk_PaymentOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Bk_PaymentOrder(");
            strSql.Append("sid,pcode,bankname,baccount,bperson,bmoney,gbank,gaccount,bremark,pdate,pmethod,pimg,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@pcode,@bankname,@baccount,@bperson,@bmoney,@gbank,@gaccount,@bremark,@pdate,@pmethod,@pimg,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bankname", SqlDbType.NVarChar,30),
					new SqlParameter("@baccount", SqlDbType.NVarChar,30),
					new SqlParameter("@bperson", SqlDbType.NVarChar,30),
					new SqlParameter("@bmoney", SqlDbType.Decimal,9),
					new SqlParameter("@gbank", SqlDbType.NVarChar,30),
					new SqlParameter("@gaccount", SqlDbType.NVarChar,30),
					new SqlParameter("@bremark", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.Date,3),
					new SqlParameter("@pmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@pimg", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.pcode;
            parameters[2].Value = model.bankname;
            parameters[3].Value = model.baccount;
            parameters[4].Value = model.bperson;
            parameters[5].Value = model.bmoney;
            parameters[6].Value = model.gbank;
            parameters[7].Value = model.gaccount;
            parameters[8].Value = model.bremark;
            parameters[9].Value = model.pdate;
            parameters[10].Value = model.pmethod;
            parameters[11].Value = model.pimg;
            parameters[12].Value = model.maker;
            parameters[13].Value = model.cdate;

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
        public bool Update( Bk_PaymentOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Bk_PaymentOrder set ");
            strSql.Append("pcode=@pcode,");
            strSql.Append("bankname=@bankname,");
            strSql.Append("baccount=@baccount,");
            strSql.Append("bperson=@bperson,");
            strSql.Append("bmoney=@bmoney,");
            strSql.Append("gbank=@gbank,");
            strSql.Append("gaccount=@gaccount,");
            strSql.Append("bremark=@bremark,");
            strSql.Append("pdate=@pdate,");
            strSql.Append("pmethod=@pmethod,");
            strSql.Append("pimg=@pimg,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bankname", SqlDbType.NVarChar,30),
					new SqlParameter("@baccount", SqlDbType.NVarChar,30),
					new SqlParameter("@bperson", SqlDbType.NVarChar,30),
					new SqlParameter("@bmoney", SqlDbType.Decimal,9),
					new SqlParameter("@gbank", SqlDbType.NVarChar,30),
					new SqlParameter("@gaccount", SqlDbType.NVarChar,30),
					new SqlParameter("@bremark", SqlDbType.NVarChar,30),
					new SqlParameter("@pdate", SqlDbType.Date,3),
					new SqlParameter("@pmethod", SqlDbType.NVarChar,30),
					new SqlParameter("@pimg", SqlDbType.NVarChar,100),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.pcode;
            parameters[1].Value = model.bankname;
            parameters[2].Value = model.baccount;
            parameters[3].Value = model.bperson;
            parameters[4].Value = model.bmoney;
            parameters[5].Value = model.gbank;
            parameters[6].Value = model.gaccount;
            parameters[7].Value = model.bremark;
            parameters[8].Value = model.pdate;
            parameters[9].Value = model.pmethod;
            parameters[10].Value = model.pimg;
            parameters[11].Value = model.maker;
            parameters[12].Value = model.cdate;
            parameters[13].Value = model.id;
            parameters[14].Value = model.sid;

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
            strSql.AppendFormat("delete from Bk_PaymentOrder where 1=1 {0}", where);
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
        public  Bk_PaymentOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,pcode,bankname,baccount,bperson,bmoney,gbank,gaccount,bremark,pdate,pmethod,pimg,maker,cdate from Bk_PaymentOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            Bk_PaymentOrder r = new Bk_PaymentOrder();
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
        public  Bk_PaymentOrder DataRowToModel(DataRow row)
        {
             Bk_PaymentOrder model = new  Bk_PaymentOrder();
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
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["bankname"] != null)
                {
                    model.bankname = row["bankname"].ToString();
                }
                if (row["baccount"] != null)
                {
                    model.baccount = row["baccount"].ToString();
                }
                if (row["bperson"] != null)
                {
                    model.bperson = row["bperson"].ToString();
                }
                if (row["bmoney"] != null && row["bmoney"].ToString() != "")
                {
                    model.bmoney = decimal.Parse(row["bmoney"].ToString());
                }
                if (row["gbank"] != null)
                {
                    model.gbank = row["gbank"].ToString();
                }
                if (row["gaccount"] != null)
                {
                    model.gaccount = row["gaccount"].ToString();
                }
                if (row["bremark"] != null)
                {
                    model.bremark = row["bremark"].ToString();
                }
                if (row["pdate"] != null && row["pdate"].ToString() != "")
                {
                    model.pdate = row["pdate"].ToString( );
                }
                if (row["pmethod"] != null)
                {
                    model.pmethod = row["pmethod"].ToString();
                }
                if (row["pimg"] != null)
                {
                    model.pimg = row["pimg"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Bk_PaymentOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,pcode,bankname,baccount,bperson,bmoney,gbank,gaccount,bremark,pdate,pmethod,pimg,maker,cdate ");
            strSql.Append(" FROM Bk_PaymentOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<Bk_PaymentOrder> r = new List<Bk_PaymentOrder>();
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
