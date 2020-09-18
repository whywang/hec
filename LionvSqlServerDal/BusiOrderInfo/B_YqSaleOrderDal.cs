using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_YqSaleOrderDal : IB_YqSaleOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_YqSaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);

        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_YqSaleOrder model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_YqSaleOrder(");
            strSql.Append("sid,csid,ccode,wcode,ycode,scode,pcode,aname,acode,city,citytype,citycode,dname,dcode,customer,telephone,community,address,gzname,gztelephone,saletelephone,otype,mname,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,qtimg,lxtype,colorpane,disactname,disactcode,floor,bdcode,mtype,ismb,iswj,saddress,gytype,khcode,remark,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@csid,@ccode,@wcode,@ycode,@scode,@pcode,@aname,@acode,@city,@citytype,@citycode,@dname,@dcode,@customer,@telephone,@community,@address,@gzname,@gztelephone,@saletelephone,@otype,@mname,@sdiscount,@gdiscount,@source,@istax,@isdf,@sname,@tax,@wlcompany,@qtimg,@lxtype,@colorpane,@disactname,@disactcode,@floor,@bdcode,@mtype,@ismb,@iswj,@saddress,@gytype,@khcode,@remark,@maker,@cdate)");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,20),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@gzname", SqlDbType.NVarChar,20),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@sname", SqlDbType.NVarChar,20),
					new SqlParameter("@tax", SqlDbType.Money,8),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,50),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,50),
					new SqlParameter("@lxtype", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@ismb", SqlDbType.Bit,1),
					new SqlParameter("@iswj", SqlDbType.Bit,1),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@gytype", SqlDbType.NVarChar,30),
					new SqlParameter("@khcode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.csid;
            parameters[2].Value = model.ccode;
            parameters[3].Value = model.wcode;
            parameters[4].Value = model.ycode;
            parameters[5].Value = model.scode;
            parameters[6].Value = model.pcode;
            parameters[7].Value = model.aname;
            parameters[8].Value = model.acode;
            parameters[9].Value = model.city;
            parameters[10].Value = model.citytype;
            parameters[11].Value = model.citycode;
            parameters[12].Value = model.dname;
            parameters[13].Value = model.dcode;
            parameters[14].Value = model.customer;
            parameters[15].Value = model.telephone;
            parameters[16].Value = model.community;
            parameters[17].Value = model.address;
            parameters[18].Value = model.gzname;
            parameters[19].Value = model.gztelephone;
            parameters[20].Value = model.saletelephone;
            parameters[21].Value = model.otype;
            parameters[22].Value = model.mname;
            parameters[23].Value = model.sdiscount;
            parameters[24].Value = model.gdiscount;
            parameters[25].Value = model.source;
            parameters[26].Value = model.istax;
            parameters[27].Value = model.isdf;
            parameters[28].Value = model.sname;
            parameters[29].Value = model.tax;
            parameters[30].Value = model.wlcompany;
            parameters[31].Value = model.qtimg;
            parameters[32].Value = model.lxtype;
            parameters[33].Value = model.colorpane;
            parameters[34].Value = model.disactname;
            parameters[35].Value = model.disactcode;
            parameters[36].Value = model.floor;
            parameters[37].Value = model.bdcode;
            parameters[38].Value = model.mtype;
            parameters[39].Value = model.ismb;
            parameters[40].Value = model.iswj;
            parameters[41].Value = model.saddress;
            parameters[42].Value = model.gytype;
            parameters[43].Value = model.khcode;
            parameters[44].Value = model.remark;
            parameters[45].Value = model.maker;
            parameters[46].Value = model.cdate;
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
        public bool Update(B_YqSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_YqSaleOrder set ");
            strSql.Append("csid=@csid,");
            strSql.Append("ccode=@ccode,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("ycode=@ycode,");
            strSql.Append("scode=@scode,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("city=@city,");
            strSql.Append("citytype=@citytype,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("gzname=@gzname,");
            strSql.Append("gztelephone=@gztelephone,");
            strSql.Append("saletelephone=@saletelephone,");
            strSql.Append("otype=@otype,");
            strSql.Append("mname=@mname,");
            strSql.Append("sdiscount=@sdiscount,");
            strSql.Append("gdiscount=@gdiscount,");
            strSql.Append("source=@source,");
            strSql.Append("istax=@istax,");
            strSql.Append("isdf=@isdf,");
            strSql.Append("sname=@sname,");
            strSql.Append("tax=@tax,");
            strSql.Append("wlcompany=@wlcompany,");
            strSql.Append("qtimg=@qtimg,");
            strSql.Append("lxtype=@lxtype,");
            strSql.Append("colorpane=@colorpane,");
            strSql.Append("disactname=@disactname,");
            strSql.Append("disactcode=@disactcode,");
            strSql.Append("floor=@floor,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("mtype=@mtype,");
            strSql.Append("ismb=@ismb,");
            strSql.Append("iswj=@iswj,");
            strSql.Append("saddress=@saddress,");
            strSql.Append("gytype=@gytype,");
            strSql.Append("khcode=@khcode,");
            strSql.Append("remark=@remark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,20),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@gzname", SqlDbType.NVarChar,20),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@sname", SqlDbType.NVarChar,20),
					new SqlParameter("@tax", SqlDbType.Money,8),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,50),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,50),
					new SqlParameter("@lxtype", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@ismb", SqlDbType.Bit,1),
					new SqlParameter("@iswj", SqlDbType.Bit,1),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@gytype", SqlDbType.NVarChar,30),
					new SqlParameter("@khcode", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.wcode;
            parameters[3].Value = model.ycode;
            parameters[4].Value = model.scode;
            parameters[5].Value = model.pcode;
            parameters[6].Value = model.aname;
            parameters[7].Value = model.acode;
            parameters[8].Value = model.city;
            parameters[9].Value = model.citytype;
            parameters[10].Value = model.citycode;
            parameters[11].Value = model.dname;
            parameters[12].Value = model.dcode;
            parameters[13].Value = model.customer;
            parameters[14].Value = model.telephone;
            parameters[15].Value = model.community;
            parameters[16].Value = model.address;
            parameters[17].Value = model.gzname;
            parameters[18].Value = model.gztelephone;
            parameters[19].Value = model.saletelephone;
            parameters[20].Value = model.otype;
            parameters[21].Value = model.mname;
            parameters[22].Value = model.sdiscount;
            parameters[23].Value = model.gdiscount;
            parameters[24].Value = model.source;
            parameters[25].Value = model.istax;
            parameters[26].Value = model.isdf;
            parameters[27].Value = model.sname;
            parameters[28].Value = model.tax;
            parameters[29].Value = model.wlcompany;
            parameters[30].Value = model.qtimg;
            parameters[31].Value = model.lxtype;
            parameters[32].Value = model.colorpane;
            parameters[33].Value = model.disactname;
            parameters[34].Value = model.disactcode;
            parameters[35].Value = model.floor;
            parameters[36].Value = model.bdcode;
            parameters[37].Value = model.mtype;
            parameters[38].Value = model.ismb;
            parameters[39].Value = model.iswj;
            parameters[40].Value = model.saddress;
            parameters[41].Value = model.gytype;
            parameters[42].Value = model.khcode;
            parameters[43].Value = model.remark;
            parameters[44].Value = model.maker;
            parameters[45].Value = model.cdate;
            parameters[46].Value = model.sid;
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
            strSql.AppendFormat("delete from B_YqSaleOrder where 1=1 {0}", where);
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
        public B_YqSaleOrder Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,csid,ccode,wcode,ycode,scode,pcode,aname,acode,city,citytype,citycode,dname,dcode,customer,telephone,community,address,gzname,gztelephone,saletelephone,otype,mname,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,qtimg,lxtype,colorpane,disactname,disactcode,floor,bdcode,mtype,ismb,iswj,saddress,gytype,khcode,remark,maker,cdate,zbremark from B_YqSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_YqSaleOrder r = new B_YqSaleOrder();
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
        public B_YqSaleOrder DataRowToModel(DataRow row)
        {
            B_YqSaleOrder model = new B_YqSaleOrder();
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
                if (row["csid"] != null)
                {
                    model.csid = row["csid"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["ycode"] != null)
                {
                    model.ycode = row["ycode"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
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
                if (row["citytype"] != null)
                {
                    model.citytype = row["citytype"].ToString();
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
                if (row["gzname"] != null)
                {
                    model.gzname = row["gzname"].ToString();
                }
                if (row["gztelephone"] != null)
                {
                    model.gztelephone = row["gztelephone"].ToString();
                }
                if (row["saletelephone"] != null)
                {
                    model.saletelephone = row["saletelephone"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["sdiscount"] != null && row["sdiscount"].ToString() != "")
                {
                    model.sdiscount = decimal.Parse(row["sdiscount"].ToString());
                }
                if (row["gdiscount"] != null && row["gdiscount"].ToString() != "")
                {
                    model.gdiscount = decimal.Parse(row["gdiscount"].ToString());
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["istax"] != null && row["istax"].ToString() != "")
                {
                    if ((row["istax"].ToString() == "1") || (row["istax"].ToString().ToLower() == "true"))
                    {
                        model.istax = true;
                    }
                    else
                    {
                        model.istax = false;
                    }
                }
                if (row["isdf"] != null && row["isdf"].ToString() != "")
                {
                    if ((row["isdf"].ToString() == "1") || (row["isdf"].ToString().ToLower() == "true"))
                    {
                        model.isdf = true;
                    }
                    else
                    {
                        model.isdf = false;
                    }
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["tax"] != null && row["tax"].ToString() != "")
                {
                    model.tax = decimal.Parse(row["tax"].ToString());
                }
                if (row["wlcompany"] != null)
                {
                    model.wlcompany = row["wlcompany"].ToString();
                }
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
                if (row["lxtype"] != null)
                {
                    model.lxtype = row["lxtype"].ToString();
                }
                if (row["colorpane"] != null)
                {
                    model.colorpane = row["colorpane"].ToString();
                }
                if (row["disactname"] != null)
                {
                    model.disactname = row["disactname"].ToString();
                }
                if (row["disactcode"] != null)
                {
                    model.disactcode = row["disactcode"].ToString();
                }
                if (row["floor"] != null)
                {
                    model.floor = row["floor"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["ismb"] != null && row["ismb"].ToString() != "")
                {
                    if ((row["ismb"].ToString() == "1") || (row["ismb"].ToString().ToLower() == "true"))
                    {
                        model.ismb = true;
                    }
                    else
                    {
                        model.ismb = false;
                    }
                }
                if (row["iswj"] != null && row["iswj"].ToString() != "")
                {
                    if ((row["iswj"].ToString() == "1") || (row["iswj"].ToString().ToLower() == "true"))
                    {
                        model.iswj = true;
                    }
                    else
                    {
                        model.iswj = false;
                    }
                }
                if (row["saddress"] != null)
                {
                    model.saddress = row["saddress"].ToString();
                }
                if (row["gytype"] != null)
                {
                    model.gytype = row["gytype"].ToString();
                }
                if (row["khcode"] != null)
                {
                    model.khcode = row["khcode"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["zbremark"] != null)
                {
                    model.zbremark = row["zbremark"].ToString();
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
        public List<B_YqSaleOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,csid,ccode,wcode,ycode,scode,pcode,aname,acode,city,citytype,citycode,dname,dcode,customer,telephone,community,address,gzname,gztelephone,saletelephone,otype,mname,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,qtimg,lxtype,colorpane,disactname,disactcode,floor,bdcode,mtype,ismb,iswj,saddress,gytype,khcode,remark,maker,cdate ,zbremark");
            strSql.Append(" FROM B_YqSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_YqSaleOrder> r = new List<B_YqSaleOrder>();
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
        #region//预订单导入销售订单
        public void ExportToSaleOrder(string csid, string sid, string maker)
        {
            SqlParameter[] parms = { new SqlParameter("@csid", csid), new SqlParameter("@sid", sid), new SqlParameter("@maker", maker) };
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, "CopyCustomerOrderToSaleOrder", parms);
        }
        #endregion
        #region//销售订单导入安装单
        public void ExportToFixOrder(string csid, string sid, string maker)
        {
            SqlParameter[] parms = { new SqlParameter("@sid", csid), new SqlParameter("@osid", sid), new SqlParameter("@maker", maker) };
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.StoredProcedure, "CopySaleOrderToFixOrder", parms);
        }
        #endregion
        #region//获取正常订单
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_YqSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #region//获取取消订单
        public DataTable CanalQueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_CanalSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #region//订单生产日期
        public string QueryProductDate(string sid)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_B_YqSaleOrder ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["scdate"].ToString();
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region//分厂日期
        public string QueryFactoryDate(string sid)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_B_YqSaleOrder ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["fcdate"].ToString();
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region//发货日期
        public string QuerySendDate(string sid)
        {
            string r = "";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from View_B_YqSaleOrder ");
            strSql.AppendFormat(" where sid='{0}'", sid);
            DataTable dt = SqlHelp.GetDataTable2(CommandType.Text, strSql.ToString(), null);
            if (dt != null)
            {
                r = dt.Rows[0]["fhdate"].ToString();
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region//更新二维码地址
        public void UpdateQr(string sid, string url)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update dbo.B_YqSaleOrder set qtimg='{0}' where sid='{1}'", url, sid);
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        #region//设置订单供货折扣
        public bool SetGDiscount(string sid, decimal dv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_YqSaleOrder set ");
            strSql.Append("gdiscount=@gdiscount");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gdiscount", SqlDbType.Float,8)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value = dv;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #region//设置订单编码
        public bool SetOrderCode(string sid, string cv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_YqSaleOrder set ");
            strSql.Append(" scode=@scode");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@scode", SqlDbType.NVarChar,50)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value = cv;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
