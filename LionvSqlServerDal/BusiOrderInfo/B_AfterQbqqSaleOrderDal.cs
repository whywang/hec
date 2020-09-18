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
   public class B_AfterQbqqSaleOrderDal:IB_AfterQbqqSaleOrderDal
    {
        #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_AfterQbqqSaleOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_AfterQbqqSaleOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_AfterQbqqSaleOrder(");
			strSql.Append("osid,sid,scode,pcode,wcode,bdcode,khcode,aname,acode,city,citytype,citycode,dname,dcode,otype,atype,mname,source,areason,aduty,method,qtimg,designer,remark,zbremark,saddress,omoney,dmoney,dtype,maker,cdate)");
			strSql.Append(" values (");
			strSql.Append("@osid,@sid,@scode,@pcode,@wcode,@bdcode,@khcode,@aname,@acode,@city,@citytype,@citycode,@dname,@dcode,@otype,@atype,@mname,@source,@areason,@aduty,@method,@qtimg,@designer,@remark,@zbremark,@saddress,@omoney,@dmoney,@dtype,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@khcode", SqlDbType.NVarChar,50),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@atype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@aduty", SqlDbType.NVarChar,50),
					new SqlParameter("@method", SqlDbType.NVarChar,100),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@zbremark", SqlDbType.NVarChar,200),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.sid;
			parameters[2].Value = model.scode;
			parameters[3].Value = model.pcode;
			parameters[4].Value = model.wcode;
			parameters[5].Value = model.bdcode;
			parameters[6].Value = model.khcode;
			parameters[7].Value = model.aname;
			parameters[8].Value = model.acode;
			parameters[9].Value = model.city;
			parameters[10].Value = model.citytype;
			parameters[11].Value = model.citycode;
			parameters[12].Value = model.dname;
			parameters[13].Value = model.dcode;
			parameters[14].Value = model.otype;
			parameters[15].Value = model.atype;
			parameters[16].Value = model.mname;
			parameters[17].Value = model.source;
			parameters[18].Value = model.areason;
			parameters[19].Value = model.aduty;
			parameters[20].Value = model.method;
			parameters[21].Value = model.qtimg;
			parameters[22].Value = model.designer;
			parameters[23].Value = model.remark;
			parameters[24].Value = model.zbremark;
			parameters[25].Value = model.saddress;
			parameters[26].Value = model.omoney;
			parameters[27].Value = model.dmoney;
			parameters[28].Value = model.dtype;
			parameters[29].Value = model.maker;
			parameters[30].Value = model.cdate;

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
		public bool Update( B_AfterQbqqSaleOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_AfterQbqqSaleOrder set ");
			strSql.Append("osid=@osid,");
			strSql.Append("scode=@scode,");
			strSql.Append("pcode=@pcode,");
			strSql.Append("wcode=@wcode,");
			strSql.Append("bdcode=@bdcode,");
			strSql.Append("khcode=@khcode,");
			strSql.Append("aname=@aname,");
			strSql.Append("acode=@acode,");
			strSql.Append("city=@city,");
			strSql.Append("citytype=@citytype,");
			strSql.Append("citycode=@citycode,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("otype=@otype,");
			strSql.Append("atype=@atype,");
			strSql.Append("mname=@mname,");
			strSql.Append("source=@source,");
			strSql.Append("areason=@areason,");
			strSql.Append("aduty=@aduty,");
			strSql.Append("method=@method,");
			strSql.Append("qtimg=@qtimg,");
			strSql.Append("designer=@designer,");
			strSql.Append("remark=@remark,");
			strSql.Append("zbremark=@zbremark,");
			strSql.Append("saddress=@saddress,");
			strSql.Append("omoney=@omoney,");
			strSql.Append("dmoney=@dmoney,");
			strSql.Append("dtype=@dtype,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@pcode", SqlDbType.NVarChar,50),
					new SqlParameter("@wcode", SqlDbType.NVarChar,50),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,50),
					new SqlParameter("@khcode", SqlDbType.NVarChar,50),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citytype", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,30),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@atype", SqlDbType.NVarChar,30),
					new SqlParameter("@mname", SqlDbType.NVarChar,30),
					new SqlParameter("@source", SqlDbType.NVarChar,30),
					new SqlParameter("@areason", SqlDbType.NVarChar,50),
					new SqlParameter("@aduty", SqlDbType.NVarChar,50),
					new SqlParameter("@method", SqlDbType.NVarChar,100),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,100),
					new SqlParameter("@designer", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@zbremark", SqlDbType.NVarChar,200),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@omoney", SqlDbType.Decimal,9),
					new SqlParameter("@dmoney", SqlDbType.Decimal,9),
					new SqlParameter("@dtype", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.pcode;
			parameters[3].Value = model.wcode;
			parameters[4].Value = model.bdcode;
			parameters[5].Value = model.khcode;
			parameters[6].Value = model.aname;
			parameters[7].Value = model.acode;
			parameters[8].Value = model.city;
			parameters[9].Value = model.citytype;
			parameters[10].Value = model.citycode;
			parameters[11].Value = model.dname;
			parameters[12].Value = model.dcode;
			parameters[13].Value = model.otype;
			parameters[14].Value = model.atype;
			parameters[15].Value = model.mname;
			parameters[16].Value = model.source;
			parameters[17].Value = model.areason;
			parameters[18].Value = model.aduty;
			parameters[19].Value = model.method;
			parameters[20].Value = model.qtimg;
			parameters[21].Value = model.designer;
			parameters[22].Value = model.remark;
			parameters[23].Value = model.zbremark;
			parameters[24].Value = model.saddress;
			parameters[25].Value = model.omoney;
			parameters[26].Value = model.dmoney;
			parameters[27].Value = model.dtype;
			parameters[28].Value = model.maker;
			parameters[29].Value = model.cdate;
			parameters[30].Value = model.sid;

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
            strSql.AppendFormat("delete from B_AfterQbqqSaleOrder where 1=1 {0}", where);
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
		public  B_AfterQbqqSaleOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,osid,sid,scode,pcode,wcode,bdcode,khcode,aname,acode,city,citytype,citycode,dname,dcode,otype,atype,mname,source,areason,aduty,method,qtimg,designer,remark,zbremark,saddress,omoney,dmoney,dtype,maker,cdate from B_AfterQbqqSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterQbqqSaleOrder r = new B_AfterQbqqSaleOrder();
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
		public  B_AfterQbqqSaleOrder DataRowToModel(DataRow row)
		{
			 B_AfterQbqqSaleOrder model=new  B_AfterQbqqSaleOrder();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["osid"]!=null)
				{
					model.osid=row["osid"].ToString();
				}
				if(row["sid"]!=null)
				{
					model.sid=row["sid"].ToString();
				}
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["pcode"]!=null)
				{
					model.pcode=row["pcode"].ToString();
				}
				if(row["wcode"]!=null)
				{
					model.wcode=row["wcode"].ToString();
				}
				if(row["bdcode"]!=null)
				{
					model.bdcode=row["bdcode"].ToString();
				}
				if(row["khcode"]!=null)
				{
					model.khcode=row["khcode"].ToString();
				}
				if(row["aname"]!=null)
				{
					model.aname=row["aname"].ToString();
				}
				if(row["acode"]!=null)
				{
					model.acode=row["acode"].ToString();
				}
				if(row["city"]!=null)
				{
					model.city=row["city"].ToString();
				}
				if(row["citytype"]!=null)
				{
					model.citytype=row["citytype"].ToString();
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
				if(row["otype"]!=null)
				{
					model.otype=row["otype"].ToString();
				}
				if(row["atype"]!=null)
				{
					model.atype=row["atype"].ToString();
				}
				if(row["mname"]!=null)
				{
					model.mname=row["mname"].ToString();
				}
				if(row["source"]!=null)
				{
					model.source=row["source"].ToString();
				}
				if(row["areason"]!=null)
				{
					model.areason=row["areason"].ToString();
				}
				if(row["aduty"]!=null)
				{
					model.aduty=row["aduty"].ToString();
				}
				if(row["method"]!=null)
				{
					model.method=row["method"].ToString();
				}
				if(row["qtimg"]!=null)
				{
					model.qtimg=row["qtimg"].ToString();
				}
				if(row["designer"]!=null)
				{
					model.designer=row["designer"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["zbremark"]!=null)
				{
					model.zbremark=row["zbremark"].ToString();
				}
				if(row["saddress"]!=null)
				{
					model.saddress=row["saddress"].ToString();
				}
				if(row["omoney"]!=null && row["omoney"].ToString()!="")
				{
					model.omoney=decimal.Parse(row["omoney"].ToString());
				}
				if(row["dmoney"]!=null && row["dmoney"].ToString()!="")
				{
					model.dmoney=decimal.Parse(row["dmoney"].ToString());
				}
				if(row["dtype"]!=null)
				{
					model.dtype=row["dtype"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterQbqqSaleOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,osid,sid,scode,pcode,wcode,bdcode,khcode,aname,acode,city,citytype,citycode,dname,dcode,otype,atype,mname,source,areason,aduty,method,qtimg,designer,remark,zbremark,saddress,omoney,dmoney,dtype,maker,cdate ");
			strSql.Append(" FROM B_AfterQbqqSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_AfterQbqqSaleOrder> r = new List<B_AfterQbqqSaleOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_AfterQbqqSaleOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
		#endregion  ExtensionMethod
    }
}
