using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvIDal.BusiOrderInfo;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_WjOrderDal:IB_WjOrderDal
   {
       #region
       /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_WjOrder");
		     strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_WjOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_WjOrder(");
			strSql.Append("sid,msid,osid,csid,zsid,scode,oscode,acode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelehpne,stelephone,otype,pbdcode,pbdname,sendtype,sdtype,qytype,mname,source,sdiscount,gdiscount,istax,isdf,iscl,disactname,disactcode,qtimg,remark,emcode,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@msid,@osid,@csid,@zsid,@scode,@oscode,@acode,@wcode,@sdcode,@bdcode,@city,@citycode,@dname,@dcode,@customer,@telephone,@community,@address,@aprovince,@acity,@saddress,@gzname,@gztelehpne,@stelephone,@otype,@pbdcode,@pbdname,@sendtype,@sdtype,@qytype,@mname,@source,@sdiscount,@gdiscount,@istax,@isdf,@iscl,@disactname,@disactcode,@qtimg,@remark,@emcode,@maker,@cdate)");
		 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@msid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@csid", SqlDbType.NVarChar,50),
					new SqlParameter("@zsid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,50),
					new SqlParameter("@acode", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,50),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,10),
					new SqlParameter("@acity", SqlDbType.NVarChar,10),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelehpne", SqlDbType.NVarChar,30),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@pbdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pbdname", SqlDbType.NVarChar,30),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdtype", SqlDbType.NVarChar,30),
					new SqlParameter("@qytype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,100),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@isdf", SqlDbType.Bit,1),
					new SqlParameter("@iscl", SqlDbType.Bit,1),
					new SqlParameter("@disactname", SqlDbType.NVarChar,30),
					new SqlParameter("@disactcode", SqlDbType.NVarChar,30),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.msid;
			parameters[2].Value = model.osid;
			parameters[3].Value = model.csid;
			parameters[4].Value = model.zsid;
			parameters[5].Value = model.scode;
			parameters[6].Value = model.oscode;
			parameters[7].Value = model.acode;
			parameters[8].Value = model.wcode;
			parameters[9].Value = model.sdcode;
			parameters[10].Value = model.bdcode;
			parameters[11].Value = model.city;
			parameters[12].Value = model.citycode;
			parameters[13].Value = model.dname;
			parameters[14].Value = model.dcode;
			parameters[15].Value = model.customer;
			parameters[16].Value = model.telephone;
			parameters[17].Value = model.community;
			parameters[18].Value = model.address;
			parameters[19].Value = model.aprovince;
			parameters[20].Value = model.acity;
			parameters[21].Value = model.saddress;
			parameters[22].Value = model.gzname;
			parameters[23].Value = model.gztelehpne;
			parameters[24].Value = model.stelephone;
			parameters[25].Value = model.otype;
			parameters[26].Value = model.pbdcode;
			parameters[27].Value = model.pbdname;
			parameters[28].Value = model.sendtype;
			parameters[29].Value = model.sdtype;
			parameters[30].Value = model.qytype;
			parameters[31].Value = model.mname;
			parameters[32].Value = model.source;
			parameters[33].Value = model.sdiscount;
			parameters[34].Value = model.gdiscount;
			parameters[35].Value = model.istax;
			parameters[36].Value = model.isdf;
			parameters[37].Value = model.iscl;
			parameters[38].Value = model.disactname;
			parameters[39].Value = model.disactcode;
			parameters[40].Value = model.qtimg;
			parameters[41].Value = model.remark;
			parameters[42].Value = model.emcode;
			parameters[43].Value = model.maker;
			parameters[44].Value = model.cdate;

			object obj =SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
		public bool Update( B_WjOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_WjOrder set ");
			strSql.Append("wcode=@wcode,");
			strSql.Append("sdcode=@sdcode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("community=@community,");
			strSql.Append("address=@address,");
			strSql.Append("aprovince=@aprovince,");
			strSql.Append("acity=@acity,");
			strSql.Append("saddress=@saddress,");
			strSql.Append("gzname=@gzname,");
			strSql.Append("gztelehpne=@gztelehpne,");
			strSql.Append("stelephone=@stelephone,");
			strSql.Append("otype=@otype,");
			strSql.Append("pbdcode=@pbdcode,");
			strSql.Append("pbdname=@pbdname,");
			strSql.Append("sendtype=@sendtype,");
			strSql.Append("sdtype=@sdtype,");
			strSql.Append("qytype=@qytype,");
			strSql.Append("mname=@mname,");
			strSql.Append("source=@source,");
			strSql.Append("remark=@remark,");
	 		strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
				 
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@sdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@community", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,10),
					new SqlParameter("@acity", SqlDbType.NVarChar,10),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@gzname", SqlDbType.NVarChar,30),
					new SqlParameter("@gztelehpne", SqlDbType.NVarChar,30),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,10),
					new SqlParameter("@pbdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@pbdname", SqlDbType.NVarChar,30),
					new SqlParameter("@sendtype", SqlDbType.NVarChar,30),
					new SqlParameter("@sdtype", SqlDbType.NVarChar,30),
					new SqlParameter("@qytype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,100),
					new SqlParameter("@sdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@istax", SqlDbType.Bit,1),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@emcode", SqlDbType.NVarChar,50),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};

			parameters[0].Value = model.wcode;
			parameters[1].Value = model.sdcode;
			parameters[2].Value = model.customer;
			parameters[3].Value = model.telephone;
			parameters[4].Value = model.community;
			parameters[5].Value = model.address;
			parameters[6].Value = model.aprovince;
			parameters[7].Value = model.acity;
			parameters[8].Value = model.saddress;
			parameters[9].Value = model.gzname;
			parameters[10].Value = model.gztelehpne;
			parameters[11].Value = model.stelephone;
			parameters[12].Value = model.otype;
			parameters[13].Value = model.pbdcode;
			parameters[14].Value = model.pbdname;
			parameters[15].Value = model.sendtype;
			parameters[16].Value = model.sdtype;
			parameters[17].Value = model.qytype;
			parameters[18].Value = model.source;
			parameters[19].Value = model.istax;
			parameters[20].Value = model.remark;
			parameters[21].Value = model.maker;
			parameters[22].Value = model.cdate;
			parameters[23].Value = model.sid;

			int rows=SqlHelp.ExecuteNonQuery(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), parameters);
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
			 strSql.AppendFormat("delete from B_WjOrder where 1=1 {0}", where);
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
		public  B_WjOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,msid,osid,csid,zsid,scode,oscode,acode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelehpne,stelephone,otype,pbdcode,pbdname,sendtype,sdtype,qytype,mname,source,sdiscount,gdiscount,istax,isdf,iscl,disactname,disactcode,qtimg,remark,emcode,maker,cdate from B_WjOrder ");
			 strSql.AppendFormat(" where 1=1 {0}", where);
            B_WjOrder r = new B_WjOrder();
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
		public  B_WjOrder DataRowToModel(DataRow row)
		{
			 B_WjOrder model=new  B_WjOrder();
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
				if(row["msid"]!=null)
				{
					model.msid=row["msid"].ToString();
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["csid"]!=null)
				{
					model.csid=row["csid"].ToString();
				}
				if(row["zsid"]!=null)
				{
					model.zsid=row["zsid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["oscode"]!=null)
				{
					model.oscode=row["oscode"].ToString();
				}
				if(row["acode"]!=null)
				{
					model.acode=row["acode"].ToString();
				}
				if(row["wcode"]!=null)
				{
					model.wcode=row["wcode"].ToString();
				}
				if(row["sdcode"]!=null)
				{
					model.sdcode=row["sdcode"].ToString();
				}
				if(row["bdcode"]!=null)
				{
					model.bdcode=row["bdcode"].ToString();
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
				if(row["community"]!=null)
				{
					model.community=row["community"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["aprovince"]!=null)
				{
					model.aprovince=row["aprovince"].ToString();
				}
				if(row["acity"]!=null)
				{
					model.acity=row["acity"].ToString();
				}
				if(row["saddress"]!=null)
				{
					model.saddress=row["saddress"].ToString();
				}
				if(row["gzname"]!=null)
				{
					model.gzname=row["gzname"].ToString();
				}
				if(row["gztelehpne"]!=null)
				{
					model.gztelehpne=row["gztelehpne"].ToString();
				}
				if(row["stelephone"]!=null)
				{
					model.stelephone=row["stelephone"].ToString();
				}
				if(row["otype"]!=null)
				{
					model.otype=row["otype"].ToString();
				}
				if(row["pbdcode"]!=null)
				{
					model.pbdcode=row["pbdcode"].ToString();
				}
				if(row["pbdname"]!=null)
				{
					model.pbdname=row["pbdname"].ToString();
				}
				if(row["sendtype"]!=null)
				{
					model.sendtype=row["sendtype"].ToString();
				}
				if(row["sdtype"]!=null)
				{
					model.sdtype=row["sdtype"].ToString();
				}
				if(row["qytype"]!=null)
				{
					model.qytype=row["qytype"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["source"]!=null)
				{
					model.source=row["source"].ToString();
				}
				if(row["sdiscount"]!=null && row["sdiscount"].ToString()!="")
				{
					model.sdiscount=decimal.Parse(row["sdiscount"].ToString());
				}
				if(row["gdiscount"]!=null && row["gdiscount"].ToString()!="")
				{
					model.gdiscount=decimal.Parse(row["gdiscount"].ToString());
				}
				if(row["istax"]!=null && row["istax"].ToString()!="")
				{
					if((row["istax"].ToString()=="1")||(row["istax"].ToString().ToLower()=="true"))
					{
						model.istax=true;
					}
					else
					{
						model.istax=false;
					}
				}
				if(row["isdf"]!=null && row["isdf"].ToString()!="")
				{
					if((row["isdf"].ToString()=="1")||(row["isdf"].ToString().ToLower()=="true"))
					{
						model.isdf=true;
					}
					else
					{
						model.isdf=false;
					}
				}
				if(row["iscl"]!=null && row["iscl"].ToString()!="")
				{
					if((row["iscl"].ToString()=="1")||(row["iscl"].ToString().ToLower()=="true"))
					{
						model.iscl=true;
					}
					else
					{
						model.iscl=false;
					}
				}
				if(row["disactname"]!=null)
				{
					model.disactname=row["disactname"].ToString();
				}
				if(row["disactcode"]!=null)
				{
					model.disactcode=row["disactcode"].ToString();
				}
				if(row["qtimg"]!=null)
				{
					model.qtimg=row["qtimg"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["emcode"]!=null)
				{
					model.emcode=row["emcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString( );
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<B_WjOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,msid,osid,csid,zsid,scode,oscode,acode,wcode,sdcode,bdcode,city,citycode,dname,dcode,customer,telephone,community,address,aprovince,acity,saddress,gzname,gztelehpne,stelephone,otype,pbdcode,pbdname,sendtype,sdtype,qytype,mname,source,sdiscount,gdiscount,istax,isdf,iscl,disactname,disactcode,qtimg,remark,emcode,maker,cdate ");
			strSql.Append(" FROM B_WjOrder ");
			strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_WjOrder> r = new List<B_WjOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_WjOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
		#endregion  ExtensionMethod
    }
}
