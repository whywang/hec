﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using System.Data;
using System.Data.SqlClient;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_YqAfterSaleOrderDal : IB_YqAfterSaleOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_YqAfterSaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_YqAfterSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_YqAfterSaleOrder(");
            strSql.Append("osid,sid,fcode,scode,oscode,pcode,khcode,customer,telephone,community,address,saddress,aname,acode,city,citycode,citytype,dname,dcode,otype,atype,mtype,mname,remark,source,areason,aduty,method,wlcompany,qtimg,omoney,designer,bdcode,ofname,ofcode,zbremark,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@osid,@sid,@fcode,@scode,@oscode,@pcode,@khcode,@customer,@telephone,@community,@address,@saddress,@aname,@acode,@city,@citycode,@citytype,@dname,@dcode,@otype,@atype,@mtype,@mname,@remark,@source,@areason,@aduty,@method,@wlcompany,@qtimg,@omoney,@designer,@bdcode,@ofname,@ofcode,@zbremark,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@fcode", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NChar,10),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@khcode", SqlDbType.NChar,10),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@saddress", SqlDbType.NChar,10),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@atype", SqlDbType.NVarChar,50),
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@areason", SqlDbType.NVarChar,20),
					new SqlParameter("@aduty", SqlDbType.NVarChar,20),
					new SqlParameter("@method", SqlDbType.NVarChar,200),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,50),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,50),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@ofname", SqlDbType.NVarChar,30),
					new SqlParameter("@ofcode", SqlDbType.NVarChar,30),
					new SqlParameter("@zbremark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.osid;
            parameters[1].Value = model.sid;
            parameters[2].Value = model.fcode;
            parameters[3].Value = model.scode;
            parameters[4].Value = model.oscode;
            parameters[5].Value = model.pcode;
            parameters[6].Value = model.khcode;
            parameters[7].Value = model.customer;
            parameters[8].Value = model.telephone;
            parameters[9].Value = model.community;
            parameters[10].Value = model.address;
            parameters[11].Value = model.saddress;
            parameters[12].Value = model.aname;
            parameters[13].Value = model.acode;
            parameters[14].Value = model.city;
            parameters[15].Value = model.citycode;
            parameters[16].Value = model.citytype;
            parameters[17].Value = model.dname;
            parameters[18].Value = model.dcode;
            parameters[19].Value = model.otype;
            parameters[20].Value = model.atype;
            parameters[21].Value = model.mtype;
            parameters[22].Value = model.mname;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.source;
            parameters[25].Value = model.areason;
            parameters[26].Value = model.aduty;
            parameters[27].Value = model.method;
            parameters[28].Value = model.wlcompany;
            parameters[29].Value = model.qtimg;
            parameters[30].Value = model.omoney;
            parameters[31].Value = model.designer;
            parameters[32].Value = model.bdcode;
            parameters[33].Value = model.ofname;
            parameters[34].Value = model.ofcode;
            parameters[35].Value = model.zbremark;
            parameters[36].Value = model.maker;
            parameters[37].Value = model.cdate;

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
        public bool Update(B_YqAfterSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_YqAfterSaleOrder set ");
            strSql.Append("osid=@osid,");
            strSql.Append("oscode=@oscode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("saddress=@saddress,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("mname=@mname,");
            strSql.Append("source=@source,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@saddress", SqlDbType.NVarChar,100),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.osid;
            parameters[1].Value = model.oscode;
            parameters[2].Value = model.customer;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.community;
            parameters[5].Value = model.address;
            parameters[6].Value = model.saddress;
            parameters[7].Value = model.aname;
            parameters[8].Value = model.acode;
            parameters[9].Value = model.mname;
            parameters[10].Value = model.source;
            parameters[11].Value = model.remark;
            parameters[12].Value = model.maker;
            parameters[13].Value = model.cdate;
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
            strSql.AppendFormat("delete from B_YqAfterSaleOrder where 1=1 {0}", where);
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
        public B_YqAfterSaleOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,osid,sid,fcode,scode,oscode,pcode,khcode,customer,telephone,community,address,saddress,aname,acode,city,citycode,citytype,dname,dcode,otype,atype,mtype,mname,remark,source,areason,aduty,method,wlcompany,qtimg,omoney,designer,bdcode,ofname,ofcode,zbremark,maker,cdate from B_YqAfterSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_YqAfterSaleOrder r = new B_YqAfterSaleOrder();
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
        public B_YqAfterSaleOrder DataRowToModel(DataRow row)
        {
            B_YqAfterSaleOrder model = new B_YqAfterSaleOrder();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["oscode"] != null)
                {
                    model.oscode = row["oscode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["khcode"] != null)
                {
                    model.khcode = row["khcode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["community"] != null)
                {
                    model.community = row["community"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["saddress"] != null)
                {
                    model.saddress = row["saddress"].ToString();
                }
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["citycode"] != null)
                {
                    model.citycode = row["citycode"].ToString();
                }
                if (row["citytype"] != null)
                {
                    model.citytype = row["citytype"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["atype"] != null)
                {
                    model.atype = row["atype"].ToString();
                }
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["areason"] != null)
                {
                    model.areason = row["areason"].ToString();
                }
                if (row["aduty"] != null)
                {
                    model.aduty = row["aduty"].ToString();
                }
                if (row["method"] != null)
                {
                    model.method = row["method"].ToString();
                }
                if (row["wlcompany"] != null)
                {
                    model.wlcompany = row["wlcompany"].ToString();
                }
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
                if (row["omoney"] != null && row["omoney"].ToString() != "")
                {
                    model.omoney = decimal.Parse(row["omoney"].ToString());
                }
                if (row["designer"] != null)
                {
                    model.designer = row["designer"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["ofname"] != null)
                {
                    model.ofname = row["ofname"].ToString();
                }
                if (row["ofcode"] != null)
                {
                    model.ofcode = row["ofcode"].ToString();
                }
                if (row["zbremark"] != null)
                {
                    model.zbremark = row["zbremark"].ToString();
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
        public List<B_YqAfterSaleOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,osid,sid,fcode,scode,oscode,pcode,khcode,customer,telephone,community,address,saddress,aname,acode,city,citycode,citytype,dname,dcode,otype,atype,mtype,mname,remark,source,areason,aduty,method,wlcompany,qtimg,omoney,designer,bdcode,ofname,ofcode,zbremark,maker,cdate ");
            strSql.Append(" FROM B_YqAfterSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_YqAfterSaleOrder> r = new List<B_YqAfterSaleOrder>();
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
        #region//获取订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_YqAfterSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        public int SetDuty(string sid, string dcode, string clfs, decimal om)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  B_YqAfterSaleOrder set aduty='{0}',method='{1}',omoney={2} where sid='{3}'", dcode, clfs, om, sid);
            int r = 0;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null) > 0)
            {
                r = 1;
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
