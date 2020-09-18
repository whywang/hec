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
   public class B_CustormOrderDal : IB_CustormOrderDal
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from B_CustormOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_CustormOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into B_CustormOrder(");
            strSql.Append("csid,ccode,wcode,ycode,customer,telephone,community,address,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,state,mname,source,ps,istax,isdf,e_city,e_citycode,e_citytype,lxtype,colorpane,yxdate,disactname,disactcode,tname,tcode,maker,cdate,cmoney)");
            strSql.Append(" values (");
            strSql.Append("@csid,@ccode,@wcode,@ycode,@customer,@telephone,@community,@address,@aname,@acode,@dname,@dcode,@gzname,@gztelephone,@saletelephone,@otype,@state,@mname,@source,@ps,@istax,@isdf,@e_city,@e_citycode,@e_citytype,@lxtype,@colorpane,@yxdate,@disactname,@disactcode,@tname,@tcode,@maker,@cdate,@cmoney)");
            SqlParameter[] parameters = {
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Bit,1),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@source", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,500),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@e_city", SqlDbType.NVarChar,20),
					new SqlParameter("@e_citycode", SqlDbType.NVarChar,20),
					new SqlParameter("@e_citytype", SqlDbType.NVarChar,20),
					new SqlParameter("@lxtype", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@yxdate", SqlDbType.Date,3),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@cmoney", SqlDbType.Decimal)};
            parameters[0].Value = model.csid;
            parameters[1].Value = model.ccode;
            parameters[2].Value = model.wcode;
            parameters[3].Value = model.ycode;
            parameters[4].Value = model.customer;
            parameters[5].Value = model.telephone;
            parameters[6].Value = model.community;
            parameters[7].Value = model.address;
            parameters[8].Value = model.aname;
            parameters[9].Value = model.acode;
            parameters[10].Value = model.dname;
            parameters[11].Value = model.dcode;
            parameters[12].Value = model.gzname;
            parameters[13].Value = model.gztelephone;
            parameters[14].Value = model.saletelephone;
            parameters[15].Value = model.otype;
            parameters[16].Value = model.state;
            parameters[17].Value = model.mname;
            parameters[18].Value = model.source;
            parameters[19].Value = model.ps;
            parameters[20].Value = model.istax;
            parameters[21].Value = model.isdf;
            parameters[22].Value = model.e_city;
            parameters[23].Value = model.e_citycode;
            parameters[24].Value = model.e_citytype;
            parameters[25].Value = model.lxtype;
            parameters[26].Value = model.colorpane;
            parameters[27].Value = model.yxdate;
            parameters[28].Value = model.disactname;
            parameters[29].Value = model.disactcode;
            parameters[30].Value = model.tname;
            parameters[31].Value = model.tcode;
            parameters[32].Value = model.maker;
            parameters[33].Value = model.cdate;
            parameters[34].Value = model.cmoney;
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
        public bool Update(B_CustormOrder model)
        {
            StringBuilder strSql = new StringBuilder();
 
            strSql.Append("update B_CustormOrder set ");
            strSql.Append("ccode=@ccode,");
            strSql.Append("wcode=@wcode,");
            strSql.Append("ycode=@ycode,");
            strSql.Append("customer=@customer,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("community=@community,");
            strSql.Append("address=@address,");
            strSql.Append("aname=@aname,");
            strSql.Append("acode=@acode,");
            strSql.Append("dname=@dname,");
            strSql.Append("dcode=@dcode,");
            strSql.Append("gzname=@gzname,");
            strSql.Append("gztelephone=@gztelephone,");
            strSql.Append("saletelephone=@saletelephone,");
            strSql.Append("otype=@otype,");
            strSql.Append("state=@state,");
            strSql.Append("mname=@mname,");
            strSql.Append("source=@source,");
            strSql.Append("ps=@ps,");
            strSql.Append("istax=@istax,");
            strSql.Append("isdf=@isdf,");
            strSql.Append("e_city=@e_city,");
            strSql.Append("e_citycode=@e_citycode,");
            strSql.Append("e_citytype=@e_citytype,");
            strSql.Append("lxtype=@lxtype,");
            strSql.Append("colorpane=@colorpane,");
            strSql.Append("yxdate=@yxdate,");
            strSql.Append("disactname=@disactname,");
            strSql.Append("disactcode=@disactcode,");
            strSql.Append("tname=@tname,");
            strSql.Append("tcode=@tcode,");
            strSql.Append("maker=@maker,");
            strSql.Append("cmoney=@cmoney,");
            strSql.Append("cdate=@cdate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@ccode", SqlDbType.NVarChar,30),
					new SqlParameter("@wcode", SqlDbType.NVarChar,30),
					new SqlParameter("@ycode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,20),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,20),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@saletelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@state", SqlDbType.Bit,1),
					new SqlParameter("@mname", SqlDbType.NVarChar,20),
					new SqlParameter("@source", SqlDbType.NVarChar,20),
					new SqlParameter("@ps", SqlDbType.NVarChar,500),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@e_city", SqlDbType.NVarChar,20),
					new SqlParameter("@e_citycode", SqlDbType.NVarChar,20),
					new SqlParameter("@e_citytype", SqlDbType.NVarChar,20),
					new SqlParameter("@lxtype", SqlDbType.NVarChar,30),
					new SqlParameter("@colorpane", SqlDbType.NVarChar,30),
					new SqlParameter("@yxdate", SqlDbType.Date,3),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,20),
					new SqlParameter("@tname", SqlDbType.NVarChar,30),
					new SqlParameter("@tcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
                    new SqlParameter("@cmoney", SqlDbType.Decimal),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@csid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ccode;
            parameters[1].Value = model.wcode;
            parameters[2].Value = model.ycode;
            parameters[3].Value = model.customer;
            parameters[4].Value = model.telephone;
            parameters[5].Value = model.community;
            parameters[6].Value = model.address;
            parameters[7].Value = model.aname;
            parameters[8].Value = model.acode;
            parameters[9].Value = model.dname;
            parameters[10].Value = model.dcode;
            parameters[11].Value = model.gzname;
            parameters[12].Value = model.gztelephone;
            parameters[13].Value = model.saletelephone;
            parameters[14].Value = model.otype;
            parameters[15].Value = model.state;
            parameters[16].Value = model.mname;
            parameters[17].Value = model.source;
            parameters[18].Value = model.ps;
            parameters[19].Value = model.istax;
            parameters[20].Value = model.isdf;
            parameters[21].Value = model.e_city;
            parameters[22].Value = model.e_citycode;
            parameters[23].Value = model.e_citytype;
            parameters[24].Value = model.lxtype;
            parameters[25].Value = model.colorpane;
            parameters[26].Value = model.yxdate;
            parameters[27].Value = model.disactname;
            parameters[28].Value = model.disactcode;
            parameters[29].Value = model.tname;
            parameters[30].Value = model.tcode;
            parameters[31].Value = model.maker;
            parameters[32].Value = model.cmoney;
            parameters[33].Value = model.cdate;
            parameters[34].Value = model.csid;
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
            strSql.AppendFormat("delete from B_CustormOrder where 1=1 {0}", where);
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
        public B_CustormOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,csid,ccode,wcode,ycode,customer,telephone,community,address,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,state,mname,source,ps,istax,isdf,e_city,e_citycode,e_citytype,lxtype,colorpane,yxdate,disactname,disactcode,tname,tcode,maker,cdate,cmoney,pstate from B_CustormOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_CustormOrder r = new B_CustormOrder();
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
        public B_CustormOrder DataRowToModel(DataRow row)
        {
            B_CustormOrder model = new B_CustormOrder();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
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
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    if ((row["state"].ToString() == "1") || (row["state"].ToString().ToLower() == "true"))
                    {
                        model.state = true;
                    }
                    else
                    {
                        model.state = false;
                    }
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["ps"] != null)
                {
                    model.ps = row["ps"].ToString();
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
                if (row["e_city"] != null)
                {
                    model.e_city = row["e_city"].ToString();
                }
                if (row["e_citycode"] != null)
                {
                    model.e_citycode = row["e_citycode"].ToString();
                }
                if (row["e_citytype"] != null)
                {
                    model.e_citytype = row["e_citytype"].ToString();
                }
                if (row["lxtype"] != null)
                {
                    model.lxtype = row["lxtype"].ToString();
                }
                if (row["colorpane"] != null)
                {
                    model.colorpane = row["colorpane"].ToString();
                }
                if (row["yxdate"] != null && row["yxdate"].ToString() != "")
                {
                    model.yxdate =  row["yxdate"].ToString( );
                }
                if (row["disactname"] != null)
                {
                    model.disactname = row["disactname"].ToString();
                }
                if (row["disactcode"] != null)
                {
                    model.disactcode = row["disactcode"].ToString();
                }
                if (row["tname"] != null)
                {
                    model.tname = row["tname"].ToString();
                }
                if (row["tcode"] != null)
                {
                    model.tcode = row["tcode"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["cmoney"] != null && row["cmoney"].ToString() != "")
                {
                    model.cmoney = decimal.Parse(row["cmoney"].ToString());
                }
                if (row["pstate"] != null && row["pstate"].ToString() != "")
                {
                    model.pstate = int.Parse(row["pstate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_CustormOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,csid,ccode,wcode,ycode,customer,telephone,community,address,aname,acode,dname,dcode,gzname,gztelephone,saletelephone,otype,state,mname,source,ps,istax,isdf,e_city,e_citycode,e_citytype,lxtype,colorpane,yxdate,disactname,disactcode,tname,tcode,cmoney,pstate,maker,cdate ");
            strSql.Append(" FROM B_CustormOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            List<B_CustormOrder> r = new List<B_CustormOrder>();
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
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_AllCoustomer", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool SetThirdDep(string tname, string tcode, string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("update  B_CustormOrder set tname='{0}',tcode='{1}' where csid='{2}'", tname,tcode,sid);
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
