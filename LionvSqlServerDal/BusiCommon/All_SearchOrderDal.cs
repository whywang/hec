using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using System.Data;
using LionvCommon;
using LionvCommonDal;

namespace LionvSqlServerDal.BusiCommon
{
    public class All_SearchOrderDal : IAll_SearchOrderDal
    {
        #region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public All_SearchOrder Query(string where )
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,osid,scode,pcode,fname,fcode,customer,telephone,address,city,dname,dcode,otype,mname,remake,rccode,rrcode,method,cdate from View_s_allorders ");
            strSql.AppendFormat(" where  1=1 {0}",where);
            All_SearchOrder r = new All_SearchOrder();
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
        public All_SearchOrder DataRowToModel(DataRow row)
        {
            All_SearchOrder model = new All_SearchOrder();
            if (row != null)
            {
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["osid"] != null)
                {
                    model.osid = row["osid"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["fname"] != null)
                {
                    model.fname = row["fname"].ToString();
                }
                if (row["fcode"] != null)
                {
                    model.fcode = row["fcode"].ToString();
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
                if (row["city"] != null)
                {
                    model.city = row["city"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["remake"] != null)
                {
                    model.remake = row["remake"].ToString();
                }
                if (row["rccode"] != null)
                {
                    model.rccode = row["rccode"].ToString();
                }
                if (row["rrcode"] != null)
                {
                    model.rrcode = row["rrcode"].ToString();
                }
                if (row["method"] != null)
                {
                    model.method = row["method"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
            }
            return model;
        }


        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<All_SearchOrder> QueryList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" sid,osid,scode,pcode,fname,fcode,customer,telephone,address,city,dname,dcode,otype,mname,remake,rccode,rrcode,method,cdate ");
            strSql.AppendFormat(" FROM View_s_allorders where 1=1 {0}",where);
            List<All_SearchOrder> r = new List<All_SearchOrder>();
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
            DataTable dt = new Fy().BusiPage("View_s_allorders", sfeild, sort, where, pagesize, curpage, ref rcount, ref pcount);
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
