using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_QbqqSaleOrderDal : IB_QbqqSaleOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_QbqqSaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_QbqqSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_QbqqSaleOrder(");
            strSql.Append("sid,csid,ccode,ycode,wcode,scode,pcode,bdcode,aname,acode,city,citycode,citytype,dname,dcode,khcode,customer,telephone,address,community,clperson,azperson,saletelephone,otype,mname,remark,sdiscount,gdiscount,cdiscount,source,wlcompany,colorpane,disactname,disactcode,designer,ndesigner,dmoney,omoney,dtype,packtype,pagenum,maker,cdate)");
            strSql.Append(" values (");
            strSql.Append("@sid,@csid,@ccode,@ycode,@wcode,@scode,@pcode,@bdcode,@aname,@acode,@city,@citycode,@citytype,@dname,@dcode,@khcode,@customer,@telephone,@address,@community,@clperson,@azperson,@saletelephone,@otype,@mname,@remark,@sdiscount,@gdiscount,@cdiscount,@source,@wlcompany,@colorpane,@disactname,@disactcode,@designer,@ndesigner,@dmoney,@omoney,@dtype,@packtype,@pagenum,@maker,@cdate)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@khcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@clperson", SqlDbType.NVarChar,30),
					new SqlParameter("@azperson", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@source", SqlDbType.NVarChar,50),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@ndesigner", SqlDbType.NVarChar,30),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@packtype", SqlDbType.NVarChar,30),
					new SqlParameter("@pagenum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.csid;
            parameters[2].Value = model.ccode;
            parameters[3].Value = model.ycode;
            parameters[4].Value = model.wcode;
            parameters[5].Value = model.scode;
            parameters[6].Value = model.pcode;
            parameters[7].Value = model.bdcode;
            parameters[8].Value = model.aname;
            parameters[9].Value = model.acode;
            parameters[10].Value = model.city;
            parameters[11].Value = model.citycode;
            parameters[12].Value = model.citytype;
            parameters[13].Value = model.dname;
            parameters[14].Value = model.dcode;
            parameters[15].Value = model.khcode;
            parameters[16].Value = model.customer;
            parameters[17].Value = model.telephone;
            parameters[18].Value = model.address;
            parameters[19].Value = model.community;
            parameters[20].Value = model.clperson;
            parameters[21].Value = model.azperson;
            parameters[22].Value = model.saletelephone;
            parameters[23].Value = model.otype;
            parameters[24].Value = model.mname;
            parameters[25].Value = model.remark;
            parameters[26].Value = model.sdiscount;
            parameters[27].Value = model.gdiscount;
            parameters[28].Value = model.cdiscount;
            parameters[29].Value = model.source;
            parameters[30].Value = model.wlcompany;
            parameters[31].Value = model.colorpane;
            parameters[32].Value = model.disactname;
            parameters[33].Value = model.disactcode;
            parameters[34].Value = model.designer;
            parameters[35].Value = model.ndesigner;
            parameters[36].Value = model.dmoney;
            parameters[37].Value = model.omoney;
            parameters[38].Value = model.dtype;
            parameters[39].Value = model.packtype;
            parameters[40].Value = model.pagenum;
            parameters[41].Value = model.maker;
            parameters[42].Value = model.cdate;
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
        public bool Update( B_QbqqSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_QbqqSaleOrder set ");
            strSql.Append("csid=@csid,");
            strSql.Append("ccode=@ccode,");
            strSql.Append("ycode=@ycode,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("scode=@scode,");
            strSql.Append("pcode=@pcode,");
            strSql.Append("bdcode=@bdcode,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("city=@city,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("citytype=@citytype,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("khcode=@khcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("community=@community,");
            strSql.Append("clperson=@clperson,");
            strSql.Append("azperson=@azperson,");
            strSql.Append("saletelephone=@saletelephone,");
            strSql.Append("otype=@otype,");
            strSql.Append("mname=@mname,");
            strSql.Append("remark=@remark,");
            strSql.Append("sdiscount=@sdiscount,");
            strSql.Append("gdiscount=@gdiscount,");
            strSql.Append("cdiscount=@cdiscount,");
            strSql.Append("source=@source,");
            strSql.Append("wlcompany=@wlcompany,");
            strSql.Append("colorpane=@colorpane,");
            strSql.Append("disactname=@disactname,");
            strSql.Append("disactcode=@disactcode,");
            strSql.Append("designer=@designer,");
            strSql.Append("ndesigner=@ndesigner,");
            strSql.Append("dmoney=@dmoney,");
            strSql.Append("omoney=@omoney,");
            strSql.Append("dtype=@dtype,");
            strSql.Append("packtype=@packtype,");
            strSql.Append("pagenum=@pagenum,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@khcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@clperson", SqlDbType.NVarChar,30),
					new SqlParameter("@azperson", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@cdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@source", SqlDbType.NVarChar,50),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@ndesigner", SqlDbType.NVarChar,30),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@packtype", SqlDbType.NVarChar,30),
					new SqlParameter("@pagenum", SqlDbType.Int,4),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.ycode;
            parameters[3].Value = model.wcode;
            parameters[4].Value = model.scode;
            parameters[5].Value = model.pcode;
            parameters[6].Value = model.bdcode;
            parameters[7].Value = model.aname;
            parameters[8].Value = model.acode;
            parameters[9].Value = model.city;
            parameters[10].Value = model.citycode;
            parameters[11].Value = model.citytype;
            parameters[12].Value = model.dname;
            parameters[13].Value = model.dcode;
            parameters[14].Value = model.khcode;
            parameters[15].Value = model.customer;
            parameters[16].Value = model.telephone;
            parameters[17].Value = model.address;
            parameters[18].Value = model.community;
            parameters[19].Value = model.clperson;
            parameters[20].Value = model.azperson;
            parameters[21].Value = model.saletelephone;
            parameters[22].Value = model.otype;
            parameters[23].Value = model.mname;
            parameters[24].Value = model.remark;
            parameters[25].Value = model.sdiscount;
            parameters[26].Value = model.gdiscount;
            parameters[27].Value = model.cdiscount;
            parameters[28].Value = model.source;
            parameters[29].Value = model.wlcompany;
            parameters[30].Value = model.colorpane;
            parameters[31].Value = model.disactname;
            parameters[32].Value = model.disactcode;
            parameters[33].Value = model.designer;
            parameters[34].Value = model.ndesigner;
            parameters[35].Value = model.dmoney;
            parameters[36].Value = model.omoney;
            parameters[37].Value = model.dtype;
            parameters[38].Value = model.packtype;
            parameters[39].Value = model.pagenum;
            parameters[40].Value = model.maker;
            parameters[41].Value = model.cdate;
            parameters[42].Value = model.sid;
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
            strSql.AppendFormat("delete from B_MzSaleOrder where 1=1 {0}", where);
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
        public  B_QbqqSaleOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,csid,ccode,ycode,wcode,scode,pcode,bdcode,aname,acode,city,citycode,citytype,dname,dcode,khcode,customer,telephone,address,community,clperson,azperson,saletelephone,otype,mname,remark,sdiscount,gdiscount,cdiscount,source,wlcompany,colorpane,disactname,disactcode,designer,ndesigner,dmoney,omoney,dtype,packtype,pagenum,maker,cdate from B_QbqqSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_QbqqSaleOrder r = new B_QbqqSaleOrder();
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
        public  B_QbqqSaleOrder DataRowToModel(DataRow row)
        {
             B_QbqqSaleOrder model = new  B_QbqqSaleOrder();
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
                if (row["ycode"] != null)
                {
                    model.ycode = row["ycode"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
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
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["community"] != null)
                {
                    model.community = row["community"].ToString();
                }
                if (row["clperson"] != null)
                {
                    model.clperson = row["clperson"].ToString();
                }
                if (row["azperson"] != null)
                {
                    model.azperson = row["azperson"].ToString();
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
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["sdiscount"] != null && row["sdiscount"].ToString() != "")
                {
                    model.sdiscount = decimal.Parse(row["sdiscount"].ToString());
                }
                if (row["gdiscount"] != null && row["gdiscount"].ToString() != "")
                {
                    model.gdiscount = decimal.Parse(row["gdiscount"].ToString());
                }
                if (row["cdiscount"] != null && row["cdiscount"].ToString() != "")
                {
                    model.cdiscount = decimal.Parse(row["cdiscount"].ToString());
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["wlcompany"] != null)
                {
                    model.wlcompany = row["wlcompany"].ToString();
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
                if (row["designer"] != null)
                {
                    model.designer = row["designer"].ToString();
                }
                if (row["ndesigner"] != null)
                {
                    model.ndesigner = row["ndesigner"].ToString();
                }
                if (row["dmoney"] != null && row["dmoney"].ToString() != "")
                {
                    model.dmoney = decimal.Parse(row["dmoney"].ToString());
                }
                if (row["omoney"] != null && row["omoney"].ToString() != "")
                {
                    model.omoney = decimal.Parse(row["omoney"].ToString());
                }
                if (row["dtype"] != null)
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["packtype"] != null)
                {
                    model.packtype = row["packtype"].ToString();
                }
                if (row["pagenum"] != null && row["pagenum"].ToString() != "")
                {
                    model.pagenum = int.Parse(row["pagenum"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_QbqqSaleOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,csid,ccode,ycode,wcode,scode,pcode,bdcode,aname,acode,city,citycode,citytype,dname,dcode,khcode,customer,telephone,address,community,clperson,azperson,saletelephone,otype,mname,remark,sdiscount,gdiscount,cdiscount,source,wlcompany,colorpane,disactname,disactcode,designer,ndesigner,dmoney,omoney,dtype,packtype,pagenum,maker,cdate ");
            strSql.Append(" FROM B_MzSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_QbqqSaleOrder> r = new List<B_QbqqSaleOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_MzSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
            DataTable dt = new Fy().BusiPage("View_B_CanelMzSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #region//设置订单编码
        public bool SetOrderCode(string sid, string cv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
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
        #region//设置类型
        public bool SetOrderType(string sid, string cv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append(" dtype=@dtype");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@dtype", SqlDbType.NVarChar,50)
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
        #region//设置木作订金
        public bool SetCustomMoney(string sid, string cv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append(" dmoney=@dmoney");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@dmoney",SqlDbType.Decimal,9)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value =Convert.ToDecimal(cv);
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        #endregion
        #region//设置木作设计师
        public bool SetDesign(string sid, string dv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append(" ndesigner=@designer");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@designer",SqlDbType.NVarChar,30)
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
        #region//设置木作金额
        public bool SetOrderMoney(string sid, string cv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append(" omoney=@omoney");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@omoney",SqlDbType.Decimal,9)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value = Convert.ToDecimal(cv);
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
