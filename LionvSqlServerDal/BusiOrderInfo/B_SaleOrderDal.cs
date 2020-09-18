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
   public  class B_SaleOrderDal : IB_SaleOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_SaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
            
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( B_SaleOrder model)
        {
   
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into B_SaleOrder(");
            strSql.Append("sid,csid,zsid,oscode,zcode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelephone,stelephone,otype,pbdcode,sendtype,sdtype,mname,source,istax,isdf,colorpane,disactname,disactcode,floor,clperson,azperson,qtimg,remark,zbremark,maker,cdate,iscl,pbdname,qytype,ctype,package,untype)");
            strSql.Append(" values (");
            strSql.Append("@sid,@csid,@zsid,@oscode,@zcode,@wcode,@sdcode,@bdcode,@city,@citycode,@dname,@dcode,@customer,@telephone,@community,@address,@aprovince,@acity,@saddress,@gzname,@gztelephone,@stelephone,@otype,@pbdcode,@sendtype,@sdtype,@mname,@source,@istax,@isdf,@colorpane,@disactname,@disactcode,@floor,@clperson,@azperson,@qtimg,@remark,@zbremark,@maker,@cdate,@iscl,@pbdname,@qytype,@ctype,@package,@untype)");
 
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@zsid", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@zcode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,50),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@saddress", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,20),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,20),
					new SqlParameter("@pbdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdtype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@clperson", SqlDbType.NVarChar,30),
					new SqlParameter("@azperson", SqlDbType.NVarChar,30),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,50),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@zbremark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@iscl", SqlDbType.Bit,1),
					new SqlParameter("@pbdname", SqlDbType.NVarChar,30),
					new SqlParameter("@qytype", SqlDbType.NVarChar,30),
					new SqlParameter("@ctype", SqlDbType.NVarChar,30),
					new SqlParameter("@package", SqlDbType.NVarChar,30),
					new SqlParameter("@untype", SqlDbType.NVarChar,30)};
            parameters[0].Value = model.sid;
            parameters[1].Value = model.csid;
            parameters[2].Value = model.zsid;
            parameters[3].Value = model.oscode;
            parameters[4].Value = model.zcode;
            parameters[5].Value = model.wcode;
            parameters[6].Value = model.sdcode;
            parameters[7].Value = model.bdcode;
            parameters[8].Value = model.city;
            parameters[9].Value = model.citycode;
            parameters[10].Value = model.dname;
            parameters[11].Value = model.dcode;
            parameters[12].Value = model.customer;
            parameters[13].Value = model.telephone;
            parameters[14].Value = model.community;
            parameters[15].Value = model.address;
            parameters[16].Value = model.aprovince;
            parameters[17].Value = model.acity;
            parameters[18].Value = model.saddress;
            parameters[19].Value = model.gzname;
            parameters[20].Value = model.gztelephone;
            parameters[21].Value = model.stelephone;
            parameters[22].Value = model.otype;
            parameters[23].Value = model.pbdcode;
            parameters[24].Value = model.sendtype;
            parameters[25].Value = model.sdtype;
            parameters[26].Value = model.mname;
            parameters[27].Value = model.source;
            parameters[28].Value = model.istax;
            parameters[29].Value = model.isdf;
            parameters[30].Value = model.colorpane;
            parameters[31].Value = model.disactname;
            parameters[32].Value = model.disactcode;
            parameters[33].Value = model.floor;
            parameters[34].Value = model.clperson;
            parameters[35].Value = model.azperson;
            parameters[36].Value = model.qtimg;
            parameters[37].Value = model.remark;
            parameters[38].Value = model.zbremark;
            parameters[39].Value = model.maker;
            parameters[40].Value = model.cdate;
            parameters[41].Value = model.iscl;
            parameters[42].Value = model.pbdname;
            parameters[43].Value = model.qytype;
            parameters[44].Value = model.ctype;
            parameters[45].Value = model.package;
            parameters[46].Value = model.untype;
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
        public bool Update( B_SaleOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SaleOrder set ");
            strSql.Append("csid=@csid,");
            strSql.Append("oscode=@oscode,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("aprovince=@aprovince,");
            strSql.Append("acity=@acity,");
            strSql.Append("saddress=@saddress,");
            strSql.Append("gzname=@gzname,");
            strSql.Append("gztelephone=@gztelephone,");
            strSql.Append("stelephone=@stelephone,");
            strSql.Append("pbdcode=@pbdcode,");
            strSql.Append("sendtype=@sendtype,");
            strSql.Append("mname=@mname,");
            strSql.Append("source=@source,");
            strSql.Append("istax=@istax,");
            strSql.Append("isdf=@isdf,");
            strSql.Append("colorpane=@colorpane,");
            strSql.Append("disactname=@disactname,");
            strSql.Append("disactcode=@disactcode,");
            strSql.Append("floor=@floor,");
            strSql.Append("clperson=@clperson,");
            strSql.Append("azperson=@azperson,");
            strSql.Append("remark=@remark,");
            strSql.Append("zbremark=@zbremark,");
            strSql.Append("maker=@maker,");
            strSql.Append("cdate=@cdate,");
            strSql.Append("iscl=@iscl,");
            strSql.Append("pbdname=@pbdname,");
            strSql.Append("ctype=@ctype,");
            strSql.Append("untype=@untype");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,50),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@saddress", SqlDbType.NVarChar,30),
					new SqlParameter("@gzname", SqlDbType.NVarChar,20),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@pbdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@floor", SqlDbType.NVarChar,30),
					new SqlParameter("@clperson", SqlDbType.NVarChar,30),
					new SqlParameter("@azperson", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@zbremark", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@iscl", SqlDbType.Bit,1),
                    new SqlParameter("@pbdname", SqlDbType.NVarChar,30),
                    new SqlParameter("@ctype", SqlDbType.NVarChar,30),
                    new SqlParameter("@untype", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.oscode;
            parameters[2].Value = model.wcode;
            parameters[3].Value = model.customer;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.community;
            parameters[6].Value = model.address;
            parameters[7].Value = model.aprovince;
            parameters[8].Value = model.acity;
            parameters[9].Value = model.saddress;
            parameters[10].Value = model.gzname;
            parameters[11].Value = model.gztelephone;
            parameters[12].Value = model.stelephone;
            parameters[13].Value = model.pbdcode;
            parameters[14].Value = model.sendtype;
            parameters[15].Value = model.mname;
            parameters[16].Value = model.source;
            parameters[17].Value = model.istax;
            parameters[18].Value = model.isdf;
            parameters[19].Value = model.colorpane;
            parameters[20].Value = model.disactname;
            parameters[21].Value = model.disactcode;
            parameters[22].Value = model.floor;
            parameters[23].Value = model.clperson;
            parameters[24].Value = model.azperson;
            parameters[25].Value = model.remark;
            parameters[26].Value = model.zbremark;
            parameters[27].Value = model.maker;
            parameters[28].Value = model.cdate;
            parameters[29].Value = model.iscl;
            parameters[30].Value = model.pbdname;
            parameters[31].Value = model.ctype;
            parameters[32].Value = model.untype;
            parameters[33].Value = model.sid;
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
            strSql.AppendFormat("delete from B_SaleOrder where 1=1 {0}", where);
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
        public B_SaleOrder Query(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,csid,zsid,scode,oscode,zcode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelephone,stelephone,otype,pbdcode,sendtype,sdtype,mname,source,sdiscount,gdiscount,istax,isdf,colorpane,disactname,disactcode,floor,clperson,azperson,ydate,qtimg,remark,zbremark,maker,cdate,iscl,pbdname,qytype,ctype,omoney,package,untype,mremark from B_SaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_SaleOrder r = new B_SaleOrder();
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
        public  B_SaleOrder DataRowToModel(DataRow row)
        {
            B_SaleOrder model = new  B_SaleOrder();
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
                if (row["zsid"] != null)
                {
                    model.zsid = row["zsid"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["oscode"] != null)
                {
                    model.oscode = row["oscode"].ToString();
                }
                if (row["zcode"] != null)
                {
                    model.zcode = row["zcode"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["sdcode"] != null)
                {
                    model.sdcode = row["sdcode"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
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
                if (row["aprovince"] != null)
                {
                    model.aprovince = row["aprovince"].ToString();
                }
                if (row["acity"] != null)
                {
                    model.acity = row["acity"].ToString();
                }
                if (row["saddress"] != null)
                {
                    model.saddress = row["saddress"].ToString();
                }
                if (row["gzname"] != null)
                {
                    model.gzname = row["gzname"].ToString();
                }
                if (row["gztelephone"] != null)
                {
                    model.gztelephone = row["gztelephone"].ToString();
                }
                if (row["stelephone"] != null)
                {
                    model.stelephone = row["stelephone"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["pbdcode"] != null)
                {
                    model.pbdcode = row["pbdcode"].ToString();
                }
                if (row["sendtype"] != null)
                {
                    model.sendtype = row["sendtype"].ToString();
                }
                if (row["sdtype"] != null)
                {
                    model.sdtype = row["sdtype"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["sdiscount"] != null && row["sdiscount"].ToString() != "")
                {
                    model.sdiscount = decimal.Parse(row["sdiscount"].ToString());
                }
                if (row["gdiscount"] != null && row["gdiscount"].ToString() != "")
                {
                    model.gdiscount = decimal.Parse(row["gdiscount"].ToString());
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
                if (row["iscl"] != null && row["iscl"].ToString() != "")
                {
                    if ((row["iscl"].ToString() == "1") || (row["iscl"].ToString().ToLower() == "true"))
                    {
                        model.iscl = true;
                    }
                    else
                    {
                        model.iscl = false;
                    }
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
                if (row["clperson"] != null)
                {
                    model.clperson = row["clperson"].ToString();
                }
                if (row["azperson"] != null)
                {
                    model.azperson = row["azperson"].ToString();
                }
                if (row["ydate"] != null && row["ydate"].ToString() != "")
                {
                    model.ydate = row["ydate"].ToString();
                }
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["zbremark"] != null)
                {
                    model.zbremark = row["zbremark"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["pbdname"] != null)
                {
                    model.pbdname = row["pbdname"].ToString();
                }
                if (row["qytype"] != null)
                {
                    model.qytype = row["qytype"].ToString();
                }
                if (row["ctype"] != null)
                {
                    model.ctype = row["ctype"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =row["cdate"].ToString();
                }
                if (row["omoney"] != null && row["omoney"].ToString() != "")
                {
                    model.omoney = decimal.Parse(row["omoney"].ToString());
                }
                if (row["package"] != null)
                {
                    model.package = row["package"].ToString();
                }
                if (row["untype"] != null)
                {
                    model.untype = row["untype"].ToString();
                }
                if (row["mremark"] != null)
                {
                    model.mremark = row["mremark"].ToString();
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_SaleOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,sid,csid,zsid,scode,oscode,zcode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelephone,stelephone,otype,pbdcode,sendtype,sdtype,mname,source,sdiscount,gdiscount,istax,isdf,colorpane,disactname,disactcode,floor,clperson,azperson,ydate,qtimg,remark,zbremark,maker,cdate,iscl,pbdname ,qytype,ctype,omoney,package,untype,mremark");
            strSql.Append(" FROM B_SaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_SaleOrder> r = new List<B_SaleOrder>();
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
        public void ExportToSaleOrder(string csid, string sid,string maker)
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
            DataTable dt = new Fy().BusiPage("View_B_SaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
            strSql.Append("select * from View_B_SaleOrder ");
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
            strSql.Append("select * from View_B_SaleOrder ");
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
            strSql.Append("select * from View_B_SaleOrder ");
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
            strSql.AppendFormat("update dbo.B_SaleOrder set qtimg='{0}' where sid='{1}'", url, sid);
            SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }
        #endregion
        #region//设置订单供货折扣
        public bool SetGDiscount(string sid,decimal dv)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SaleOrder set ");
            strSql.Append("gdiscount=@gdiscount");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@gdiscount", SqlDbType.Float,8)
                                        };

            parameters[0].Value =sid;
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
            strSql.Append("update B_SaleOrder set ");
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
        public bool SetOrderMoney(string sid, decimal cv, string mremark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SaleOrder set ");
            strSql.Append(" omoney=@omoney,");
            strSql.Append(" mremark=@mremark");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@sid", SqlDbType.NVarChar,50),
                     new SqlParameter("@mremark", SqlDbType.NVarChar,500),
                    new SqlParameter("@omoney", SqlDbType.Decimal,8)
                                        };

            parameters[0].Value = sid;
            parameters[1].Value = mremark;
            parameters[2].Value = cv;
            bool r = false;
            if (SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters) > 0)
            {
                r = true;
            }
            return r;
        }
        #region
        public int QueryOrderNum()
        {
            int r = -1;
            string sql = "";
            sql = "select count(1) as n from B_SaleOrder where cdate>'"+DateTime.Now.ToString("yyyy-MM")+"-01'";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        #endregion
        #endregion  ExtensionMethod
    }
}
