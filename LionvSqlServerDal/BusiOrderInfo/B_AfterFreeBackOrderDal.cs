using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using System.Data;
using LionvCommon;
using LionvCommonDal;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterFreeBackOrderDal : IB_AfterFreeBackOrderDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterFreeBackOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterFreeBackOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterFreeBackOrder(");
			strSql.Append("sid,osid,asid,scode,oscode,sscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,qtimg,sdate,gofee,servfee,stext,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@sid,@osid,@asid,@scode,@oscode,@sscode,@city,@citycode,@dname,@dcode,@customer,@telephone,@aprovince,@acity,@address,@areason,@qtimg,@sdate,@gofee,@servfee,@stext,@maker,@cdate)");

			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@asid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,30),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@sscode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,200),
					new SqlParameter("@sdate", SqlDbType.DateTime),
					new SqlParameter("@gofee", SqlDbType.Decimal,9),
					new SqlParameter("@servfee", SqlDbType.Decimal,9),
					new SqlParameter("@stext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.osid;
			parameters[2].Value = model.asid;
			parameters[3].Value = model.scode;
			parameters[4].Value = model.oscode;
			parameters[5].Value = model.sscode;
			parameters[6].Value = model.city;
			parameters[7].Value = model.citycode;
			parameters[8].Value = model.dname;
			parameters[9].Value = model.dcode;
			parameters[10].Value = model.customer;
			parameters[11].Value = model.telephone;
			parameters[12].Value = model.aprovince;
			parameters[13].Value = model.acity;
			parameters[14].Value = model.address;
			parameters[15].Value = model.areason;
			parameters[16].Value = model.qtimg;
			parameters[17].Value = model.sdate;
			parameters[18].Value = model.gofee;
			parameters[19].Value = model.servfee;
			parameters[20].Value = model.stext;
			parameters[21].Value = model.maker;
			parameters[22].Value = model.cdate;

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
		public bool Update( B_AfterFreeBackOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterFreeBackOrder set ");
			strSql.Append("osid=@osid,");
			strSql.Append("oscode=@oscode,");
			strSql.Append("city=@city,");
			strSql.Append("citycode=@citycode,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("customer=@customer,");
			strSql.Append("telephone=@telephone,");
			strSql.Append("aprovince=@aprovince,");
			strSql.Append("acity=@acity,");
			strSql.Append("address=@address,");
			strSql.Append("areason=@areason,");
			strSql.Append("sdate=@sdate,");
			strSql.Append("gofee=@gofee,");
			strSql.Append("servfee=@servfee,");
			strSql.Append("stext=@stext,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@oscode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@customer", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,30),
					new SqlParameter("@aprovince", SqlDbType.NVarChar,30),
					new SqlParameter("@acity", SqlDbType.NVarChar,30),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@sdate", SqlDbType.DateTime),
					new SqlParameter("@gofee", SqlDbType.Decimal,9),
					new SqlParameter("@servfee", SqlDbType.Decimal,9),
					new SqlParameter("@stext", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.oscode;
			parameters[2].Value = model.city;
			parameters[3].Value = model.citycode;
			parameters[4].Value = model.dname;
			parameters[5].Value = model.dcode;
			parameters[6].Value = model.customer;
			parameters[7].Value = model.telephone;
			parameters[8].Value = model.aprovince;
			parameters[9].Value = model.acity;
			parameters[10].Value = model.address;
			parameters[11].Value = model.areason;
			parameters[12].Value = model.sdate;
			parameters[13].Value = model.gofee;
			parameters[14].Value = model.servfee;
			parameters[15].Value = model.stext;
			parameters[16].Value = model.maker;
			parameters[17].Value = model.cdate;
			parameters[18].Value = model.sid;

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
            strSql.AppendFormat("delete from B_AfterFreeBackOrder where 1=1 {0}", where);
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
        public B_AfterFreeBackOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,sid,osid,asid,scode,oscode,sscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,qtimg,sdate,gofee,servfee,stext,maker,cdate,oinfo,cinfo,otype ,azperson,odate from B_AfterFreeBackOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterFreeBackOrder r = new B_AfterFreeBackOrder();
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
		public  B_AfterFreeBackOrder DataRowToModel(DataRow row)
		{
			 B_AfterFreeBackOrder model=new  B_AfterFreeBackOrder();
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
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["asid"]!=null)
				{
					model.asid=row["asid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["oscode"]!=null)
				{
					model.oscode=row["oscode"].ToString();
				}
				if(row["sscode"]!=null)
				{
					model.sscode=row["sscode"].ToString();
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
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["areason"]!=null)
				{
					model.areason=row["areason"].ToString();
				}
				if(row["qtimg"]!=null)
				{
					model.qtimg=row["qtimg"].ToString();
				}
				if(row["sdate"]!=null && row["sdate"].ToString()!="")
				{
					model.sdate= row["sdate"].ToString();
				}
				if(row["gofee"]!=null && row["gofee"].ToString()!="")
				{
					model.gofee=decimal.Parse(row["gofee"].ToString());
				}
				if(row["servfee"]!=null && row["servfee"].ToString()!="")
				{
					model.servfee=decimal.Parse(row["servfee"].ToString());
				}
				if(row["stext"]!=null)
				{
					model.stext=row["stext"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
                if (row["cinfo"] != null)
                {
                    model.cinfo = row["cinfo"].ToString();
                }
                if (row["oinfo"] != null)
                {
                    model.oinfo = row["oinfo"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["azperson"] != null)
                {
                    model.azperson = row["azperson"].ToString();
                }
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["odate"] != null && row["odate"].ToString() != "")
                {
                    model.odate = row["odate"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterFreeBackOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,sid,osid,asid,scode,oscode,sscode,city,citycode,dname,dcode,customer,telephone,aprovince,acity,address,areason,qtimg,sdate,gofee,servfee,stext,maker,cdate,oinfo,cinfo,otype ,azperson,odate ");
			strSql.Append(" FROM B_AfterFreeBackOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterFreeBackOrder> r = new List<B_AfterFreeBackOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_AfterFreeBackOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
            string sql = "select isnull(count(1),0) as n from B_AfterFreeBackOrder where cdate>'" + dtv + "' and cdate<getdate() ";
            object o = SqlHelp.ExecuteScalar(SqlHelp.ConnectionStringb, CommandType.Text, sql, null);
            r = o == null ? 9999 : Convert.ToInt32(o) + 1;
            return r;
        }
        public bool UpdateAppointment(B_AfterFreeBackOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterFreeBackOrder set ");
            strSql.Append("sdate=@sdate,");
            strSql.Append("gofee=@gofee,");
            strSql.Append("servfee=@servfee,");
            strSql.Append("stext=@stext ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					 
					new SqlParameter("@sdate", SqlDbType.DateTime),
					new SqlParameter("@gofee", SqlDbType.Decimal,9),
					new SqlParameter("@servfee", SqlDbType.Decimal,9),
					new SqlParameter("@stext", SqlDbType.NVarChar,500),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
     
            parameters[0].Value = model.sdate;
            parameters[1].Value = model.gofee;
            parameters[2].Value = model.servfee;
            parameters[3].Value = model.stext;
            parameters[4].Value = model.sid;

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
        public bool SetOverInfo(string sid, string otype,string odate, string oinfo, string cinfo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_AfterFreeBackOrder set ");
            strSql.Append("otype=@otype,");
            strSql.Append("oinfo=@oinfo,");
            strSql.Append("cinfo=@cinfo, ");
            strSql.Append("odate=@odate ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@otype", SqlDbType.NVarChar,50),
					new SqlParameter("@oinfo", SqlDbType.NVarChar,500),
					new SqlParameter("@cinfo", SqlDbType.NVarChar,500),
                    new SqlParameter("@odate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)
       };
            parameters[0].Value = otype;
            parameters[1].Value = oinfo;
            parameters[2].Value = cinfo;
            parameters[3].Value = odate;
            parameters[4].Value = sid;

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
            strSql.Append("update B_AfterFreeBackOrder set ");
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
		#endregion  ExtensionMethod
    }
}
