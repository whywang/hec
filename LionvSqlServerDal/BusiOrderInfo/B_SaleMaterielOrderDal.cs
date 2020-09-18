using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Data;
using LionvModel.BusiOrderInfo;
using System.Data.SqlClient;
using LionvCommonDal;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
   public class B_SaleMaterielOrderDal : IB_SaleMaterielOrderDal
    {
        	#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_SaleMaterielOrder");
			strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_SaleMaterielOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_SaleMaterielOrder(");
			strSql.Append("sid,scode,otype,aname,acode,city,citycode,dname,dcode,gdiscount,wltype,qtimg,remark,saddress,stelephone,bdcode,maker,cdate,sperson)");
			strSql.Append(" values (");
			strSql.Append("@sid,@scode,@otype,@aname,@acode,@city,@citycode,@dname,@dcode,@gdiscount,@wltype,@qtimg,@remark,@saddress,@stelephone,@bdcode,@maker,@cdate,@sperson)");
	 
			SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
					new SqlParameter("@scode", SqlDbType.NVarChar,50),
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@gdiscount", SqlDbType.Decimal,9),
					new SqlParameter("@wltype", SqlDbType.NVarChar,30),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,200),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@bdcode", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sperson", SqlDbType.NVarChar,30)};
			parameters[0].Value = model.sid;
			parameters[1].Value = model.scode;
			parameters[2].Value = model.otype;
			parameters[3].Value = model.aname;
			parameters[4].Value = model.acode;
			parameters[5].Value = model.city;
			parameters[6].Value = model.citycode;
			parameters[7].Value = model.dname;
			parameters[8].Value = model.dcode;
			parameters[9].Value = model.gdiscount;
			parameters[10].Value = model.wltype;
			parameters[11].Value = model.qtimg;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.saddress;
			parameters[14].Value = model.stelephone;
			parameters[15].Value = model.bdcode;
			parameters[16].Value = model.maker;
			parameters[17].Value = model.cdate;
            parameters[18].Value = model.sperson;
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
		public bool Update( B_SaleMaterielOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_SaleMaterielOrder set ");
			strSql.Append("otype=@otype,");
			strSql.Append("aname=@aname,");
			strSql.Append("acode=@acode,");
			strSql.Append("city=@city,");
			strSql.Append("citycode=@citycode,");
			strSql.Append("dname=@dname,");
			strSql.Append("dcode=@dcode,");
			strSql.Append("wltype=@wltype,");
			strSql.Append("remark=@remark,");
			strSql.Append("saddress=@saddress,");
			strSql.Append("stelephone=@stelephone,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate,");
            strSql.Append("sperson=@sperson");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
			 
					new SqlParameter("@otype", SqlDbType.NVarChar,30),
					new SqlParameter("@aname", SqlDbType.NVarChar,30),
					new SqlParameter("@acode", SqlDbType.NVarChar,30),
					new SqlParameter("@city", SqlDbType.NVarChar,30),
					new SqlParameter("@citycode", SqlDbType.NVarChar,30),
					new SqlParameter("@dname", SqlDbType.NVarChar,30),
					new SqlParameter("@dcode", SqlDbType.NVarChar,50),
					new SqlParameter("@wltype", SqlDbType.NVarChar,30),
					new SqlParameter("@remark", SqlDbType.NVarChar,200),
					new SqlParameter("@saddress", SqlDbType.NVarChar,200),
					new SqlParameter("@stelephone", SqlDbType.NVarChar,30),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
                    new SqlParameter("@sperson", SqlDbType.NVarChar,30),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
 
			parameters[0].Value = model.otype;
			parameters[1].Value = model.aname;
			parameters[2].Value = model.acode;
			parameters[3].Value = model.city;
			parameters[4].Value = model.citycode;
			parameters[5].Value = model.dname;
			parameters[6].Value = model.dcode;
			parameters[7].Value = model.wltype;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.saddress;
			parameters[10].Value = model.stelephone;
			parameters[11].Value = model.maker;
			parameters[12].Value = model.cdate;
            parameters[13].Value = model.sperson;
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
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_SaleMaterielOrder where 1=1 {0}", where);
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
		public  B_SaleMaterielOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,sid,scode,otype,aname,acode,city,citycode,dname,dcode,gdiscount,wltype,qtimg,remark,saddress,stelephone,bdcode,maker,cdate ,sperson from B_SaleMaterielOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_SaleMaterielOrder r = new B_SaleMaterielOrder();
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
		public  B_SaleMaterielOrder DataRowToModel(DataRow row)
		{
			 B_SaleMaterielOrder model=new  B_SaleMaterielOrder();
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
				if(row["scode"]!=null)
				{
					model.scode=row["scode"].ToString();
				}
				if(row["otype"]!=null)
				{
					model.otype=row["otype"].ToString();
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
				if(row["gdiscount"]!=null && row["gdiscount"].ToString()!="")
				{
					model.gdiscount=decimal.Parse(row["gdiscount"].ToString());
				}
				if(row["wltype"]!=null)
				{
					model.wltype=row["wltype"].ToString();
				}
				if(row["qtimg"]!=null)
				{
					model.qtimg=row["qtimg"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["saddress"]!=null)
				{
					model.saddress=row["saddress"].ToString();
				}
				if(row["stelephone"]!=null)
				{
					model.stelephone=row["stelephone"].ToString();
				}
				if(row["bdcode"]!=null)
				{
					model.bdcode=row["bdcode"].ToString();
				}
				if(row["maker"]!=null)
				{
					model.maker=row["maker"].ToString();
				}
				if(row["cdate"]!=null && row["cdate"].ToString()!="")
				{
					model.cdate= row["cdate"].ToString() ;
				}
                if (row["sperson"] != null)
                {
                    model.sperson = row["sperson"].ToString();
                }
			}
			return model;
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_SaleMaterielOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,sid,scode,otype,aname,acode,city,citycode,dname,dcode,gdiscount,wltype,qtimg,remark,saddress,stelephone,bdcode,maker,cdate,sperson ");
			strSql.Append(" FROM B_SaleMaterielOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_SaleMaterielOrder> r = new List<B_SaleMaterielOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_SaleMaterielOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
            strSql.Append("update B_SaleMaterielOrder set ");
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
