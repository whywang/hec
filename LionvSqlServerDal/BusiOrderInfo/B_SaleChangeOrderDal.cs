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
    public class B_SaleChangeOrderDal : IB_SaleChangeOrderDal
    {
       #region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
       public bool Exists(string where)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from B_SaleChangeOrder");
            strSql.AppendFormat(" where 1=1 {0} ", where);
            return SqlHelp.Exists(SqlHelp.ConnectionStringb, CommandType.Text, strSql.ToString(), null);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add( B_SaleChangeOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into B_SaleChangeOrder(");
			strSql.Append("osid,sid,sqcode,mtype,qtimg,creason,maker,cdate)");
			strSql.Append(" values (");
            strSql.Append("@osid,@sid,@sqcode,@mtype,@qtimg,@creason,@maker,@cdate)");
 
			SqlParameter[] parameters = {
					new SqlParameter("@osid", SqlDbType.NVarChar,50),
					new SqlParameter("@sid", SqlDbType.NVarChar,50),
                    new SqlParameter("@sqcode", SqlDbType.NVarChar,30),
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@qtimg", SqlDbType.NVarChar,200),
					new SqlParameter("@creason", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime)};
			parameters[0].Value = model.osid;
			parameters[1].Value = model.sid;
            parameters[2].Value = model.sqcode;
            parameters[3].Value = model.mtype;
            parameters[4].Value = model.qtimg;
            parameters[5].Value = model.creason;
            parameters[6].Value = model.maker;
            parameters[7].Value = model.cdate;

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
		public bool Update( B_SaleChangeOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update B_SaleChangeOrder set ");
            strSql.Append("mtype=@mtype,");
            strSql.Append("creason=@creason,");
			strSql.Append("maker=@maker,");
			strSql.Append("cdate=@cdate");
			strSql.Append(" where sid=@sid");
			SqlParameter[] parameters = {
			
					new SqlParameter("@mtype", SqlDbType.NVarChar,30),
					new SqlParameter("@creason", SqlDbType.NVarChar,500),
					new SqlParameter("@maker", SqlDbType.NVarChar,30),
					new SqlParameter("@cdate", SqlDbType.DateTime),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.mtype;
            parameters[1].Value = model.creason;
            parameters[2].Value = model.maker;
            parameters[3].Value = model.cdate;
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

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public bool Delete(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.AppendFormat("delete from B_SaleChangeOrder where 1=1 {0}", where);
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
		public  B_SaleChangeOrder Query(string where)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 id,osid,sid,oscode,sqcode,scode,customer,telephone,address,community,aname,acode,e_city,e_citycode,dname,dcode,bdcode,otype,saletelephone,mname,remark,zbremark,mtype,qbcode,clperson,azperson,saddress,source,ydate,sname,qtimg,colorpane,creason,maker,cdate,ccost,pjd,cremark from B_SaleChangeOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_SaleChangeOrder r = new B_SaleChangeOrder();
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
		public  B_SaleChangeOrder DataRowToModel(DataRow row)
		{
			 B_SaleChangeOrder model=new  B_SaleChangeOrder();
			if (row != null)
			{
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["oscode"] != null)
                {
                    model.oscode = row["oscode"].ToString();
                }
                if (row["sqcode"] != null)
                {
                    model.sqcode = row["sqcode"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
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
                if (row["e_city"] != null)
                {
                    model.e_city = row["e_city"].ToString();
                }
                if (row["e_citycode"] != null)
                {
                    model.e_citycode = row["e_citycode"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["bdcode"] != null)
                {
                    model.bdcode = row["bdcode"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["saletelephone"] != null)
                {
                    model.saletelephone = row["saletelephone"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["zbremark"] != null)
                {
                    model.zbremark = row["zbremark"].ToString();
                }
                if (row["mtype"] != null)
                {
                    model.mtype = row["mtype"].ToString();
                }
                if (row["qbcode"] != null)
                {
                    model.qbcode = row["qbcode"].ToString();
                }
                if (row["clperson"] != null)
                {
                    model.clperson = row["clperson"].ToString();
                }
                if (row["azperson"] != null)
                {
                    model.azperson = row["azperson"].ToString();
                }
                if (row["saddress"] != null)
                {
                    model.saddress = row["saddress"].ToString();
                }
                if (row["source"] != null)
                {
                    model.source = row["source"].ToString();
                }
                if (row["ydate"] != null && row["ydate"].ToString() != "")
                {
                    model.ydate = row["ydate"].ToString() ;
                }
                if (row["sname"] != null)
                {
                    model.sname = row["sname"].ToString();
                }
                if (row["qtimg"] != null)
                {
                    model.qtimg = row["qtimg"].ToString();
                }
                if (row["colorpane"] != null)
                {
                    model.colorpane = row["colorpane"].ToString();
                }
                if (row["creason"] != null)
                {
                    model.creason = row["creason"].ToString();
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString() ;
                }
                if (row["ccost"] != null)
                {
                    model.ccost =decimal.Parse(row["ccost"].ToString());
                }
                if (row["pjd"] != null)
                {
                    model.pjd = row["pjd"].ToString();
                }
                if (row["cremark"] != null)
                {
                    model.cremark = row["cremark"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_SaleChangeOrder> QueryList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,osid,sid,oscode,sqcode,scode,customer,telephone,address,community,aname,acode,e_city,e_citycode,dname,dcode,bdcode,otype,saletelephone,mname,remark,zbremark,mtype,qbcode,clperson,azperson,saddress,source,ydate,sname,qtimg,colorpane,creason,maker,cdate,ccost,pjd,cremark  ");
            strSql.Append(" FROM B_SaleChangeOrder ");
            strSql.AppendFormat(" where 1=1 {0}", strWhere);
            List<B_SaleChangeOrder> r = new List<B_SaleChangeOrder>();
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
            DataTable dt = new Fy().BusiPage("View_B_SaleChangeOrder", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
        #region//更新变更成本
        public bool UpChangeCost(string sid, decimal ccost, string pjd, string cremark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update B_SaleChangeOrder set ");
            strSql.Append("ccost=@ccost,");
            strSql.Append("pjd=@pjd,");
            strSql.Append("cremark=@cremark");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@ccost", SqlDbType.Decimal),
					new SqlParameter("@pjd", SqlDbType.NVarChar,300),
					new SqlParameter("@cremark", SqlDbType.NVarChar,300),
					new SqlParameter("@sid", SqlDbType.NVarChar,50)};
            parameters[0].Value = ccost;
            parameters[1].Value = pjd;
            parameters[2].Value = cremark;
            parameters[3].Value =sid;

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
        #endregion
		#endregion  ExtensionMethod
    }
}
