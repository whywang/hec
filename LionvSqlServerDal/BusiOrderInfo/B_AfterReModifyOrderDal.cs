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
    public class B_AfterReModifyOrderDal : IB_AfterReModifyOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterReModifyOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterReModifyOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterReModifyOrder(");
			strSql.Append("sid,asid,osid,scode,ascode,oscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,areason,otype,ptype,isbf,remark,sendtype,maker,cdate,address,qytype)");
			strSql.Append(" values (");
            strSql.Append("@sid,@asid,@osid,@scode,@ascode,@oscode,@city,@citycode,@dname,@dcode,@customer,@telephone,@aprovince,@acity,@areason,@otype,@ptype,@isbf,@remark,@sendtype,@maker,@cdate,@address,@qytype)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@asid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@ascode", SqlDbType.NVarChar,30),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@areason", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@isbf", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@qytype", SqlDbType.NVarChar,20)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.asid;
			parameters[2].Value = model.osid;
			parameters[3].Value = model.scode;
			parameters[4].Value = model.ascode;
			parameters[5].Value = model.oscode;
			parameters[6].Value = model.city;
			parameters[7].Value = model.citycode;
			parameters[8].Value = model.dname;
			parameters[9].Value = model.dcode;
			parameters[10].Value = model.customer;
			parameters[11].Value = model.telephone;
			parameters[12].Value = model.aprovince;
			parameters[13].Value = model.acity;
			parameters[14].Value = model.areason;
			parameters[15].Value = model.otype;
			parameters[16].Value = model.ptype;
			parameters[17].Value = model.isbf;
			parameters[18].Value = model.remark;
			parameters[19].Value = model.sendtype;
			parameters[20].Value = model.maker;
			parameters[21].Value = model.cdate;
            parameters[22].Value = model.address;
            parameters[23].Value = model.qytype;
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
		public bool Update( B_AfterReModifyOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterReModifyOrder set ");
			strSql.Append("osid=@osid,");
			strSql.Append("oscode=@oscode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("aprovince=@aprovince,");
			strSql.Append("acity=@acity,");
			strSql.Append("areason=@areason,");
			strSql.Append("otype=@otype,");
			strSql.Append("ptype=@ptype,");
			strSql.Append("isbf=@isbf,");
			strSql.Append("remark=@remark,");
			strSql.Append("sperson=@sperson,");
			strSql.Append("sendtype=@sendtype,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("address=@address");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					 
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@areason", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@ptype", SqlDbType.NVarChar,30),
					new SqlParameter("@isbf", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@sperson", SqlDbType.NVarChar,20),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,20),
					new SqlParameter("@maker", SqlDbType.NVarChar,20),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
	 
			parameters[0].Value = model.osid;
			parameters[1].Value = model.oscode;
			parameters[2].Value = model.customer;
			parameters[3].Value = model.telephone;
			parameters[4].Value = model.aprovince;
			parameters[5].Value = model.acity;
			parameters[6].Value = model.areason;
			parameters[7].Value = model.otype;
			parameters[8].Value = model.ptype;
			parameters[9].Value = model.isbf;
			parameters[10].Value = model.remark;
			parameters[11].Value = model.sperson;
			parameters[12].Value = model.sendtype;
			parameters[13].Value = model.maker;
			parameters[14].Value = model.cdate;
            parameters[15].Value = model.address;
			parameters[16].Value = model.sid;

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
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_AfterReModifyOrder where 1=1 {0}", where);
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
        public B_AfterReModifyOrder Query(string where)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,asid,osid,scode,ascode,oscode,city,citycode,dname,dcode,customer,telephone,address,aprovince,acity,areason,aduty,adremark,otype,ptype,isbf,senddate,remark,sperson,settlment,omoney,qmoney,sendtype,sodate,bnum,maker,cdate,fname,premark,fcode ,sdate,gofee,servfee,stext ,azperson,fodate,fzt,cinfo,oinfo,qytype,fmoney,kfperson,tmoney,jsyf,pmethod from B_AfterReModifyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterReModifyOrder r = new B_AfterReModifyOrder();
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
		public  B_AfterReModifyOrder DataRowToModel(DataRow row)
		{
			 B_AfterReModifyOrder model=new  B_AfterReModifyOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["asid"]!=null)
				{
					model.asid=row["asid"].ToString();
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["ascode"]!=null)
				{
					model.ascode=row["ascode"].ToString();
				}
				if(row["oscode"]!=null)
				{
					model.oscode=row["oscode"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["citycode"]!=null)
				{
					model.citycode=row["citycode"].ToString();
				}
				if(row["dname"]!=null)
				{
					model.dname=row["dname"].ToString();
				}
				if(row["dcode"]!=null)
				{
					model.dcode=row["dcode"].ToString();
				}
				if(row["customer"]!=null)
				{
					model.customer=row["customer"].ToString();
				}
				if(row["telephone"]!=null)
				{
					model.telephone=row["telephone"].ToString();
				}
				if(row["aprovince"]!=null)
				{
					model.aprovince=row["aprovince"].ToString();
				}
				if(row["acity"]!=null)
				{
					model.acity=row["acity"].ToString();
				}
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
				if(row["areason"]!=null)
				{
					model.areason=row["areason"].ToString();
				}
				if(row["aduty"]!=null)
				{
					model.aduty=row["aduty"].ToString();
				}
				if(row["adremark"]!=null)
				{
					model.adremark=row["adremark"].ToString();
				}
				if(row["otype"]!=null)
				{
					model.otype=row["otype"].ToString();
				}
				if(row["ptype"]!=null)
				{
					model.ptype=row["ptype"].ToString();
				}
				if(row["isbf"]!=null && row["isbf"].ToString()!="")
				{
					if((row["isbf"].ToString()=="1")||(row["isbf"].ToString().ToLower()=="true"))
					{
						model.isbf=true;
					}
					else
					{
						model.isbf=false;
					}
				}
				if(row["senddate"]!=null && row["senddate"].ToString()!="")
				{
					model.senddate= row["senddate"].ToString( );
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["sperson"]!=null)
				{
					model.sperson=row["sperson"].ToString();
				}
				if(row["settlment"]!=null)
				{
					model.settlment=row["settlment"].ToString();
				}
				if(row["omoney"]!=null && row["omoney"].ToString()!="")
				{
					model.omoney=decimal.Parse(row["omoney"].ToString());
				}
				if(row["qmoney"]!=null && row["qmoney"].ToString()!="")
				{
					model.qmoney=decimal.Parse(row["qmoney"].ToString());
				}
				if(row["sendtype"]!=null)
				{
					model.sendtype=row["sendtype"].ToString();
				}
				if(row["sodate"]!=null && row["sodate"].ToString()!="")
				{
					model.sodate= row["sodate"].ToString() ;
				}
				if(row["bnum"]!=null && row["bnum"].ToString()!="")
				{
					model.bnum=int.Parse(row["bnum"].ToString());
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["premark"] != null)
                {
                    model.premark = row["premark"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["gofee"] != null && row["gofee"].ToString() != "")
                {
                    model.gofee = decimal.Parse(row["gofee"].ToString());
                }
                if (row["servfee"] != null && row["servfee"].ToString() != "")
                {
                    model.servfee = decimal.Parse(row["servfee"].ToString());
                }
                if (row["sdate"] != null && row["sdate"].ToString() != "")
                {
                    model.sdate = row["sdate"].ToString();
                }
                if (row["stext"] != null)
                {
                    model.stext = row["stext"].ToString();
                }
                if (row["azperson"] != null)
                {
                    model.azperson = row["azperson"].ToString();
                }
                if (row["fodate"] != null && row["fodate"].ToString() != "")
                {
                    model.fodate = row["fodate"].ToString();
                }
                if (row["cinfo"] != null)
                {
                    model.cinfo = row["cinfo"].ToString();
                }
                if (row["oinfo"] != null)
                {
                    model.oinfo = row["oinfo"].ToString();
                }
                if (row["fzt"] != null)
                {
                    model.fzt = row["fzt"].ToString();
                }
                if (row["qytype"] != null)
                {
                    model.qytype = row["qytype"].ToString();
                }
                if (row["fmoney"] != null && row["fmoney"].ToString() != "")
                {
                    model.fmoney = decimal.Parse(row["fmoney"].ToString());
                }
                if (row["kfperson"] != null)
                {
                    model.kfperson = row["kfperson"].ToString();
                }
                if (row["tmoney"] != null && row["tmoney"].ToString() != "")
                {
                    model.tmoney = decimal.Parse(row["tmoney"].ToString());
                }
                if (row["jsyf"] != null && row["jsyf"].ToString() != "")
                {
                    if ((row["jsyf"].ToString() == "1") || (row["jsyf"].ToString().ToLower() == "true"))
                    {
                        model.jsyf = true;
                    }
                    else
                    {
                        model.jsyf = false;
                    }
                }
                if (row["pmethod"] != null)
                {
                    model.pmethod = row["pmethod"].ToString();
                }
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterReModifyOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,asid,osid,scode,ascode,oscode,city,citycode,dname,dcode,customer,telephone,aprovince,address,acity,areason,aduty,adremark,otype,ptype,isbf,senddate,remark,sperson,settlment,omoney,qmoney,sendtype,sodate,bnum,maker,cdate,premark,fname,fcode,sdate,gofee,servfee,stext,azperson,fodate,fzt,cinfo,oinfo,qytype,fmoney,kfperson,tmoney,jsyf,pmethod ");
			strSql.Append(" FROM B_AfterReModifyOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterReModifyOrder> r = new List<B_AfterReModifyOrder>();
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
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            DataTable r = new DataTable();
            DataTable dt = new Fy().BusiPage("View_B_AfterReModifyOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        public int GetOrderNum()
        {
            int r = -1;
            string dtv = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + "01 00:00:00";
            string sql = "select isnull(count(1),0) as n from B_AfterReModifyOrder where cdate>'" + dtv + "' and cdate<getdate() ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool SaveDuty(B_AfterReModifyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("aduty=@aduty,");
            strSql.Append("adremark=@adremark,");
            strSql.Append("omoney=@omoney,");
            strSql.Append("qmoney=@qmoney,");
            strSql.Append("settlment=@settlment,");
            strSql.Append("premark=@premark,");
            strSql.Append("fname=@fname,");
            strSql.Append("fcode=@fcode,");
            strSql.Append("areason=@areason");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					 
					new SqlParameter("@aduty", SqlDbType.NVarChar,50),
					new SqlParameter("@adremark", SqlDbType.NVarChar,200),
					new SqlParameter("@omoney", SqlDbType.Decimal,8),
					new SqlParameter("@qmoney", SqlDbType.Decimal,8),
					new SqlParameter("@settlment", SqlDbType.NVarChar,30),
					new SqlParameter("@premark", SqlDbType.NVarChar,200),
					new SqlParameter("@fname", SqlDbType.NVarChar,30),
                    new SqlParameter("@fcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@areason", SqlDbType.NVarChar,50),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50)
				};

            parameters[0].Value = model.aduty;
            parameters[1].Value = model.adremark;
            parameters[2].Value = model.omoney;
            parameters[3].Value = model.qmoney;
            parameters[4].Value = model.settlment;
            parameters[5].Value = model.premark;
            parameters[6].Value = model.fname;
            parameters[7].Value = model.fcode;
            parameters[8].Value = model.areason;
            parameters[9].Value = model.sid;
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
        public bool SaveOverDate(string sid, string odate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("sodate=@sodate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sodate", SqlDbType.DateTime),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50)
				};

            parameters[0].Value = odate;
            parameters[1].Value = sid;
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
        public bool SetPackageNum(string sid, string bnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("bnum=@bnum");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@bnum", SqlDbType.Int),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50)
				};

            parameters[0].Value = bnum;
            parameters[1].Value = sid;
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
        public bool SaveSendDate(string sid, string odate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("senddate=@senddate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@senddate", SqlDbType.DateTime),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50)
				};

            parameters[0].Value = odate;
            parameters[1].Value = sid;
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
        public bool SetAppointment(B_AfterReModifyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("sdate=@sdate,");
            strSql.Append("gofee=@gofee,");
            strSql.Append("servfee=@servfee,");
            strSql.Append("stext=@stext,");
            strSql.Append("senddate=@senddate");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sdate", SqlDbType.DateTime),
                    new SqlParameter("@gofee", SqlDbType.Decimal,8),
                    new SqlParameter("@servfee", SqlDbType.Decimal,8),
                    new SqlParameter("@stext", SqlDbType.NVarChar,500),
                    new SqlParameter("@senddate", SqlDbType.DateTime),
                    new SqlParameter("@sid", SqlDbType.NVarChar,50)
				};

            parameters[0].Value = model.sdate;
            parameters[1].Value = model.gofee;
            parameters[2].Value = model.servfee;
            parameters[3].Value = model.stext;
            parameters[4].Value = model.senddate;
            parameters[5].Value = model.sid;
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
        public bool SetFixer(string sid, string azperson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("azperson=@azperson");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@azperson", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = azperson;
            parameters[1].Value = sid;

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
        public bool SetOverInfo(string sid, string otype, string odate, string oinfo, string cinfo,string fmoney)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("fzt=@fzt,");
            strSql.Append("oinfo=@oinfo,");
            strSql.Append("cinfo=@cinfo, ");
            strSql.Append("fodate=@fodate, ");
            strSql.Append("fmoney=@fmoney ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@fzt", SqlDbType.NVarChar,50),
					new SqlParameter("@oinfo", SqlDbType.NVarChar,500),
					new SqlParameter("@cinfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@fodate", SqlDbType.DateTime),
                    new SqlParameter("@fmoney", SqlDbType.Decimal,8),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)
       };
            parameters[0].Value = otype;
            parameters[1].Value = oinfo;
            parameters[2].Value = cinfo;
            parameters[3].Value = odate;
            parameters[4].Value = Convert.ToDecimal(fmoney);
            parameters[5].Value = sid;

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
        public bool SetTMoney(string sid, decimal tmoney)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("tmoney=@tmoney");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
                    new SqlParameter("@tmoney", SqlDbType.Decimal,8),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)
       };
            parameters[0].Value = tmoney;
            parameters[1].Value = sid;

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
        public bool SetPmethod(string sid, string pmethod)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterReModifyOrder set ");
            strSql.Append("pmethod=@pmethod");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@pmethod", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = pmethod;
            parameters[1].Value = sid;

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
