using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvCommon;

namespace LionvSqlServerDal.BusiOrderInfo
{
    public class B_AfterSearchOrderDal : IB_AfterSearchOrderDal
    {
        #region  BasicMethod


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  B_AfterSearchOrder Query(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,sid,scode,pcode,cityname,dname,dcode,factoryname,factorycode,customer,telephone,address,mname,rccode,rrcode,method,remake,ispay,omoney,maker,cdate from B_AfterSearchOrder ");
            strSql.AppendFormat(" where 1=1 {0}", where);
            B_AfterSearchOrder r = new B_AfterSearchOrder();
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
        public  B_AfterSearchOrder DataRowToModel(DataRow row)
        {
             B_AfterSearchOrder model = new  B_AfterSearchOrder();
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
                if (row["scode"] != null)
                {
                    model.scode = row["scode"].ToString();
                }
                if (row["pcode"] != null)
                {
                    model.pcode = row["pcode"].ToString();
                }
                if (row["cityname"] != null)
                {
                    model.cityname = row["cityname"].ToString();
                }
                if (row["dname"] != null)
                {
                    model.dname = row["dname"].ToString();
                }
                if (row["dcode"] != null)
                {
                    model.dcode = row["dcode"].ToString();
                }
                if (row["factoryname"] != null)
                {
                    model.factoryname = row["factoryname"].ToString();
                }
                if (row["factorycode"] != null)
                {
                    model.factorycode = row["factorycode"].ToString();
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
                if (row["remake"] != null)
                {
                    model.remake = row["remake"].ToString();
                }
                if (row["ispay"] != null && row["ispay"].ToString() != "")
                {
                    model.ispay = int.Parse(row["ispay"].ToString());
                }
                if (row["omoney"] != null && row["omoney"].ToString() != "")
                {
                    model.omoney = decimal.Parse(row["omoney"].ToString());
                }
                if (row["maker"] != null)
                {
                    model.maker = row["maker"].ToString();
                }
                if (row["cdate"] != null && row["cdate"].ToString() != "")
                {
                    model.cdate =  row["cdate"].ToString( );
                }
            }
            return model;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
