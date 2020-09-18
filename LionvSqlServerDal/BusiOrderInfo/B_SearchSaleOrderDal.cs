using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvCommon;
using LionvIDal.BusiOrderInfo;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_SearchSaleOrderDal : IB_SearchSaleOrderDal
    {
        #region  BasicMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  B_SearchSaleOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,csid,sid,ccode,wcode,scode,otype,dname,dcode,cityname,customer,telephone,address,mname,remake,factoryname,factorycode,gmoney,dmoney,ostate,pdate,maker,cdate,fixs from B_SearchSaleOrder ");
            strSql.AppendFormat(" where 1=1 {0}",where);
            B_SearchSaleOrder r = new  B_SearchSaleOrder();
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
        public  B_SearchSaleOrder DataRowToModel(DataRow row)
        {
             B_SearchSaleOrder model = new  B_SearchSaleOrder();
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
                if (row["sid"] != null)
                {
                    model.sid = row["sid"].ToString();
                }
                if (row["ccode"] != null)
                {
                    model.ccode = row["ccode"].ToString();
                }
                if (row["wcode"] != null)
                {
                    model.wcode = row["wcode"].ToString();
                }
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["otype"] != null)
                {
                    model.otype = row["otype"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["cityname"] != null)
                {
                    model.cityname = row["cityname"].ToString();
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
                if (row["mname"] != null)
                {
                    model.mname = row["mname"].ToString();
                }
                if (row["remake"] != null)
                {
                    model.remake = row["remake"].ToString();
                }
                if (row["factoryname"] != null)
                {
                    model.factoryname = row["factoryname"].ToString();
                }
                if (row["factorycode"] != null)
                {
                    model.factorycode = row["factorycode"].ToString();
                }
                if (row["gmoney"] != null && row["gmoney"].ToString() != "")
                {
                    model.gmoney = decimal.Parse(row["gmoney"].ToString());
                }
                if (row["dmoney"] != null && row["dmoney"].ToString() != "")
                {
                    model.dmoney = decimal.Parse(row["dmoney"].ToString());
                }
                if (row["ostate"] != null && row["ostate"].ToString() != "")
                {
                    model.ostate = int.Parse(row["ostate"].ToString());
                }
                if (row["pdate"] != null && row["pdate"].ToString() != "")
                {
                    model.pdate = row["pdate"].ToString( );
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate = row["cdate"].ToString() ;
                }
                if (row["fixs"] != null && row["fixs"].ToString() != "")
                {
                    model.fixs = row["fixs"].ToString();
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
