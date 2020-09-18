using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using LionvModel.BusiOrderInfo;
using LionvIDal.BusiOrderInfo;
using System.Data;
using System.Data.SqlClient;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_MzSaleOrderDal : IB_MzSaleOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_MzSaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_MzSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_MzSaleOrder(");
            strSql.Append("sid,csid,ycode,wcode,scode,pcode,customer,telephone,address,community,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,mname,remark,city,citycode,citytype,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,colorpane,disactname,disactcode,designer,dmoney,omoney,maker,cdate,packtype,dtype,daddress,mveneer,emcode,zbdesigner)");
            strSql.Append(" values (");
            strSql.Append("@sid,@csid,@ycode,@wcode,@scode,@pcode,@customer,@telephone,@address,@community,@aname,@acode,@dname,@dcode,@gzname,@gztelephone,@saletelephone,@otype,@mname,@remark,@city,@citycode,@citytype,@sdiscount,@gdiscount,@source,@istax,@isdf,@sname,@tax,@wlcompany,@colorpane,@disactname,@disactcode,@designer,@dmoney,@omoney,@maker,@cdate,@packtype,@dtype,@daddress,@mveneer,@emcode,@zbdesigner)");

            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@pcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@source", SqlDbType.NVarChar,50),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@sname", SqlDbType.NVarChar,30),
					new SqlParameter("@tax", SqlDbType.Bit,1),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@packtype", SqlDbType.NVarChar,30),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@daddress", SqlDbType.NVarChar,100),
					new SqlParameter("@mveneer", SqlDbType.NVarChar,30),
					new SqlParameter("@emcode", SqlDbType.NVarChar,30),
					new SqlParameter("@zbdesigner", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.csid;
            parameters[2].Value = model.ycode;
            parameters[3].Value = model.wcode;
            parameters[4].Value = model.scode;
            parameters[5].Value = model.pcode;
            parameters[6].Value = model.customer;
            parameters[7].Value = model.telephone;
            parameters[8].Value = model.address;
            parameters[9].Value = model.community;
            parameters[10].Value = model.aname;
            parameters[11].Value = model.acode;
            parameters[12].Value = model.dname;
            parameters[13].Value = model.dcode;
            parameters[14].Value = model.gzname;
            parameters[15].Value = model.gztelephone;
            parameters[16].Value = model.saletelephone;
            parameters[17].Value = model.otype;
            parameters[18].Value = model.mname;
            parameters[19].Value = model.remark;
            parameters[20].Value = model.city;
            parameters[21].Value = model.citycode;
            parameters[22].Value = model.citytype;
            parameters[23].Value = model.sdiscount;
            parameters[24].Value = model.gdiscount;
            parameters[25].Value = model.source;
            parameters[26].Value = model.istax;
            parameters[27].Value = model.isdf;
            parameters[28].Value = model.sname;
            parameters[29].Value = model.tax;
            parameters[30].Value = model.wlcompany;
            parameters[31].Value = model.colorpane;
            parameters[32].Value = model.disactname;
            parameters[33].Value = model.disactcode;
            parameters[34].Value = model.designer;
            parameters[35].Value = model.dmoney;
            parameters[36].Value = model.omoney;
            parameters[37].Value = model.maker;
            parameters[38].Value = model.cdate;
            parameters[39].Value = model.packtype;
            parameters[40].Value = model.dtype;
            parameters[41].Value = model.daddress;
            parameters[42].Value = model.mveneer;
            parameters[43].Value = model.emcode;
            parameters[44].Value = model.zbdesigner;
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
        public bool Update(B_MzSaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append("ycode=@ycode,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("address=@address,");
            strSql.Append("community=@community,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("gzname=@gzname,");
            strSql.Append("gztelephone=@gztelephone,");
            strSql.Append("saletelephone=@saletelephone,");
            strSql.Append("otype=@otype,");
            strSql.Append("mname=@mname,");
            strSql.Append("remark=@remark,");
            strSql.Append("city=@city,");
            strSql.Append("citycode=@citycode,");
            strSql.Append("source=@source,");
            strSql.Append("wlcompany=@wlcompany,");
            strSql.Append("colorpane=@colorpane,");
            strSql.Append("designer=@designer,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("dtype=@dtype,");
            strSql.Append("daddress=@daddress,");
            strSql.Append("packtype=@packtype,");
            strSql.Append("mveneer=@mveneer,");
            strSql.Append("zbdesiger=@zbdesiger");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
		 
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@e_city", SqlDbType.NVarChar,30),
					new SqlParameter("@e_citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,50),
					new SqlParameter("@wlcompany", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@dtype", SqlDbType.NVarChar,30),
                    new SqlParameter("@daddress", SqlDbType.NVarChar,100),
                    new SqlParameter("@packtype", SqlDbType.NVarChar,30),
                    new SqlParameter("@mveneer", SqlDbType.NVarChar,30),
                     new SqlParameter("@zbdesigner", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ycode;
            parameters[1].Value = model.wcode;
            parameters[2].Value = model.customer;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.address;
            parameters[5].Value = model.community;
            parameters[6].Value = model.aname;
            parameters[7].Value = model.acode;
            parameters[8].Value = model.dname;
            parameters[9].Value = model.dcode;
            parameters[10].Value = model.gzname;
            parameters[11].Value = model.gztelephone;
            parameters[12].Value = model.saletelephone;
            parameters[13].Value = model.otype;
            parameters[14].Value = model.mname;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.city;
            parameters[17].Value = model.citycode;
            parameters[18].Value = model.source;
            parameters[19].Value = model.wlcompany;
            parameters[20].Value = model.colorpane;
            parameters[21].Value = model.designer;
            parameters[22].Value = model.maker;
            parameters[23].Value = model.cdate;
            parameters[24].Value = model.dtype;
            parameters[25].Value = model.daddress;
            parameters[26].Value = model.packtype;
            parameters[27].Value = model.mveneer;
            parameters[28].Value = model.zbdesigner;
            parameters[29].Value = model.sid;
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
        public B_MzSaleOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,csid,ycode,wcode,scode,pcode,customer,telephone,address,community,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,mname,remark,city,citycode,citytype,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,colorpane,disactname,disactcode,designer,dmoney,omoney,maker,cdate,dtype,packtype,pagenum ,ndesigner,daddress,mveneer,emcode,zbdesigner,ptype from B_MzSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_MzSaleOrder r = new B_MzSaleOrder();
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
        public B_MzSaleOrder DataRowToModel(DataRow row)
        {
            B_MzSaleOrder model = new B_MzSaleOrder();
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
                if (row["aname"] != null)
                {
                    model.aname = row["aname"].ToString();
                }
                if (row["acode"] != null)
                {
                    model.acode = row["acode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
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
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
                    if ((row["tax"].ToString() == "1") || (row["tax"].ToString().ToLower() == "true"))
                    {
                        model.tax = true;
                    }
                    else
                    {
                        model.tax = false;
                    }
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
                if (row["zbdesigner"] != null)
                {
                    model.zbdesigner = row["zbdesigner"].ToString();
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
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString();
                }
                if (row["dtype"] != null && row["dtype"].ToString() != "")
                {
                    model.dtype = row["dtype"].ToString();
                }
                if (row["pagenum"] != null && row["pagenum"].ToString() != "")
                {
                    model.pagenum = int.Parse(row["pagenum"].ToString());
                }
                if (row["packtype"] != null && row["packtype"].ToString() != "")
                {
                    model.packtype = row["packtype"].ToString();
                }
                if (row["daddress"] != null && row["daddress"].ToString() != "")
                {
                    model.daddress = row["daddress"].ToString();
                }
                if (row["mveneer"] != null && row["mveneer"].ToString() != "")
                {
                    model.mveneer = row["mveneer"].ToString();
                }
                if (row["emcode"] != null && row["emcode"].ToString() != "")
                {
                    model.emcode = row["emcode"].ToString();
                }
                if (row["ptype"] != null && row["ptype"].ToString() != "")
                {
                    model.ptype = row["ptype"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_MzSaleOrder> QueryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,csid,ycode,wcode,scode,pcode,customer,telephone,address,community,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,mname,remark,city,citycode,citytype,sdiscount,gdiscount,source,istax,isdf,sname,tax,wlcompany,colorpane,disactname,disactcode,designer,dmoney,omoney,maker,cdate,dtype,packtype,pagenum,ndesigner,daddress,mveneer,emcode,zbdesigner,ptype ");
            strSql.Append(" FROM B_MzSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_MzSaleOrder> r = new List<B_MzSaleOrder>();
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
            parameters[1].Value = Convert.ToDecimal(cv);
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
        #region//设置木作产品类型
        public bool SetProductionType(string sid, string pv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_MzSaleOrder set ");
            strSql.Append(" ptype=@ptype");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@ptype",SqlDbType.NVarChar,30)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value = pv;
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
