using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiCommon;
using System.Data;
using System.Text;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using ViewModel.BusiOrderInfo;
using LionvBll.StatisticsInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class SearchingOrder : System.Web.UI.Page
    {
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单List
        [WebMethod(true)]
        public static ArrayList QuerySearchOrder(string stype,string sstr)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string stable = "";
                string sfield = " sid,scode,city,dname,customer,telephone,address";
                if (sstr != "")
                {
                    where.AppendFormat(" and ifactorydeliver>0 and (customer like '%{0}%' or scode like '%{0}%' or city like '%{0}%' or dname like '%{0}%' or telephone like '%{0}%')", sstr);
                }
                if (stype == "mm")
                {
                    stable = "View_B_YqSaleOrder";
                }
                DataTable dt=tsb.QueryList(stable, sfield, where.ToString(), " order by id desc");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ArrayList al = new ArrayList();
                        foreach (DataColumn column in dt.Columns)
                        {
                            al.Add(dr[column].ToString());
                        }
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        //#region/////获取订单Tab
        //[WebMethod(true)]
        //public static ArrayList QueryTabList(string sid )
        //{
        //    ArrayList r = new ArrayList();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    DataTable lsr = new DataTable();
        //    StringBuilder where = new StringBuilder();
        //    if (iv.f)
        //    {
        //        r.Add(iv.badstr);
        //        All_SearchOrder aso= asob.Query(" and sid='" + sid + "'");
        //        All_SearchOrder paso = new All_SearchOrder ();
        //        if (aso != null)
        //        {
        //            ArrayList al1 = new ArrayList();
        //            ArrayList al2 = new ArrayList();
        //            if (aso.otype.IndexOf("反馈") > -1)
        //            {
        //                paso = asob.Query(" and sid='" + aso.osid + "'");
        //                if (paso != null)
        //                {
        //                    al1.Add("a");
        //                    al1.Add("销售订单信息");
        //                    r.Add(al1);
        //                }
        //                al2.Add("b");
        //                al2.Add("反馈订单信息");
        //                r.Add(al2);
        //            }
        //            if (aso.otype.IndexOf("订单") > -1)
        //            {
        //                al1.Add("a");
        //                al1.Add("销售订单信息");
        //                r.Add(al1);
        //                paso = asob.Query(" and osid='" + aso.sid + "'");
        //                if (paso != null)
        //                {
        //                    al2.Add("b");
        //                    al2.Add("反馈订单信息");
        //                    r.Add(al2);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        r.Add(iv.badstr);
        //    }
        //    return r;
        //}
        //#endregion
        //#region/////获取订单Tab
        //[WebMethod(true)]
        //public static string QuerySid(string sid)
        //{
        //    string r ="";
        //    ViewSearchOrder wso = new ViewSearchOrder();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        All_SearchOrder aso = asob.Query(" and sid='" + sid + "'");
        //        All_SearchOrder paso = new All_SearchOrder();
        //        if (aso != null)
        //        {
                    
        //            if (aso.otype.IndexOf("反馈") > -1)
        //            {
        //                wso.nfid = sid;
        //                paso = asob.Query(" and sid='" + aso.osid + "'");
        //                if (paso != null)
        //                {
        //                  wso.nsid = paso.sid;
        //                }
        //            }
        //            if (aso.otype.IndexOf("订单") > -1)
        //            {
        //                wso.nsid = sid;
        //                paso = asob.Query(" and osid='" + aso.sid + "'");
        //                if (paso != null)
        //                {  
        //                    wso.nfid = paso.sid;
        //                }
        //            }
        //            r = js.Serialize(wso);
        //        }
        //    }
        //    else
        //    {
        //        r=iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion
        //#region/////获取销售订单
        //[WebMethod(true)]
        //public static string  QueryxOrder(string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    DataTable lsr = new DataTable();
        //    StringBuilder where = new StringBuilder();
        //    if (iv.f)
        //    {
        //        All_SearchOrder aso = asob.Query(" and sid='" + sid + "'");
        //        B_SaleOrder bso = new B_SaleOrder();
        //        if (aso != null)
        //        {
        //            if (aso.otype.IndexOf("反馈") > -1)
        //            {
        //                All_SearchOrder paso = asob.Query(" and sid='" + aso.osid + "'");
        //                if (paso != null)
        //                {
        //                    if (paso.otype == "原订单")
        //                    {
        //                       B_SearchSaleOrder bsso= bssob.Query(" and sid='" + paso.sid + "'");
        //                       bso.scode = bsso.scode;
        //                       bso.pcode = bsso.ccode;
        //                       bso.wcode = bsso.wcode;
        //                       bso.customer = bsso.customer;
        //                       bso.telephone = bsso.telephone;
        //                       bso.address = bsso.address;
        //                       bso.e_city = bsso.cityname;
        //                       bso.dname = bsso.dname;
        //                       bso.cdate = bsso.cdate;
        //                       bso.otype = "销售订单";
        //                       bso.source = "";
        //                       bso.gzname = "";
        //                       bso.gztelephone = "";
        //                       bso.mname = bsso.mname;
        //                       bso.maker = bsso.maker;
        //                       bso.isdf = false;
        //                       bso.ps = bsso.remake;
        //                    }
        //                    if (paso.otype == "新订单")
        //                    {
        //                        bso = bsob.Query(" and sid='" + paso.sid + "'");
        //                    }
        //                }
                         
        //            }
        //            if (aso.otype.IndexOf("订单") > -1)
        //            {
        //                if (aso.otype == "原订单")
        //                {
        //                    B_SearchSaleOrder bsso = bssob.Query(" and sid='" + aso.sid + "'");
        //                    bso.scode = bsso.scode;
        //                    bso.pcode = bsso.ccode;
        //                    bso.wcode = bsso.wcode;
        //                    bso.customer = bsso.customer;
        //                    bso.telephone = bsso.telephone;
        //                    bso.address = bsso.address;
        //                    bso.e_city = bsso.cityname;
        //                    bso.dname = bsso.dname;
        //                    bso.cdate = bsso.cdate;
        //                    bso.otype = "销售订单";
        //                    bso.source = "";
        //                    bso.gzname = "";
        //                    bso.gztelephone = "";
        //                    bso.mname = bsso.mname;
        //                    bso.maker = bsso.maker;
        //                    bso.isdf = false;
        //                    bso.ps = bsso.remake;
        //                }
        //                if (aso.otype == "木门订单")
        //                {
        //                    bso = bsob.Query(" and sid='" + aso.sid + "'");
        //                }
        //            }
                    
        //        }
        //        r = js.Serialize(bso);
        //    }
        //    else
        //    {
        //        r=iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion
        //#region/////获取反馈订单
        //[WebMethod(true)]
        //public static string QueryfOrder(string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    DataTable lsr = new DataTable();
        //    StringBuilder where = new StringBuilder();
        //    if (iv.f)
        //    {
        //        All_SearchOrder aso = asob.Query(" and sid='" + sid + "'");
        //        B_AfterSaleOrder baso = new B_AfterSaleOrder();
        //        if (aso != null)
        //        {
        //            if (aso.otype.IndexOf("反馈") > -1)
        //            {
        //                    if (aso.otype == "原反馈单")
        //                    {
        //                        B_AfterSearchOrder bsso = basob.Query(" and sid='" + aso.sid + "'");
        //                        baso.scode = bsso.scode;
        //                        baso.pcode = bsso.pcode;
        //                        baso.customer = bsso.customer;
        //                        baso.telephone = bsso.telephone;
        //                        baso.address = bsso.address;
        //                        baso.e_city = bsso.cityname;
        //                        baso.dname = bsso.dname;
        //                        baso.cdate = bsso.cdate;
        //                        baso.otype = "原反馈单";
        //                        baso.source = "";
        //                        baso.mname = bsso.mname;
        //                        baso.maker = bsso.maker;
        //                        baso.aduty = bsso.rccode;
        //                        baso.areason = bsso.rrcode;
        //                        baso.method=bsso.method;
        //                        baso.remark = bsso.remake;
        //                    }
        //                    if (aso.otype == "新反馈单")
        //                    {
        //                        baso = absob.Query(" and sid='" + aso.sid + "'");
        //                    }
        //            }
        //            if (aso.otype.IndexOf("订单") > -1)
        //            {
        //                if (aso.otype == "原订单")
        //                {
        //                    B_AfterSearchOrder bsso = basob.Query(" and sid='" + aso.sid + "'");
        //                    baso.scode = bsso.scode;
        //                    baso.pcode = bsso.pcode;
        //                    baso.customer = bsso.customer;
        //                    baso.telephone = bsso.telephone;
        //                    baso.address = bsso.address;
        //                    baso.e_city = bsso.cityname;
        //                    baso.dname = bsso.dname;
        //                    baso.cdate = bsso.cdate;
        //                    baso.otype = "原反馈单";
        //                    baso.source = "";
        //                    baso.mname = bsso.mname;
        //                    baso.maker = bsso.maker;
        //                    baso.aduty = bsso.rccode;
        //                    baso.areason = bsso.rrcode;
        //                    baso.method=bsso.method;
        //                    baso.remark = bsso.remake;
        //                }
        //                if (aso.otype == "新订单")
        //                {
        //                    baso = absob.Query(" and osid='" + aso.sid + "'");
        //                }
        //            }
        //        }
        //        r = js.Serialize(baso);
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion
        //#region/////获取产品
        //[WebMethod(true)]
        //public static string QueryProductionStr(string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    DataTable lsr = new DataTable();
        //    StringBuilder where = new StringBuilder();
        //    if (iv.f)
        //    {
        //        All_SearchOrder aso = asob.Query(" and sid='" + sid + "'");
        //        B_AfterSaleOrder baso = new B_AfterSaleOrder();
        //        if (aso != null)
        //        {
        //            if (aso.otype.IndexOf("反馈") > -1)
        //            {
        //                if (aso.otype == "原反馈单")
        //                {
        //                    B_AfterSearchOrder bsso = basob.Query(" and sid='" + aso.sid + "'");
        //                    baso.scode = bsso.scode;
        //                    baso.pcode = bsso.pcode;
        //                    baso.customer = bsso.customer;
        //                    baso.telephone = bsso.telephone;
        //                    baso.address = bsso.address;
        //                    baso.e_city = bsso.cityname;
        //                    baso.dname = bsso.dname;
        //                    baso.cdate = bsso.cdate;
        //                    baso.otype = "原反馈单";
        //                    baso.source = "";
        //                    baso.mname = bsso.mname;
        //                    baso.maker = bsso.maker;
        //                    baso.aduty = bsso.rccode;
        //                    baso.areason = bsso.rrcode;
        //                    baso.method = bsso.method;
        //                    baso.remark = bsso.remake;
        //                }
        //                if (aso.otype == "新反馈单")
        //                {
        //                    baso = absob.Query(" and sid='" + aso.sid + "'");
        //                }
        //            }
        //            if (aso.otype.IndexOf("订单") > -1)
        //            {
        //                if (aso.otype == "原订单")
        //                {
        //                    B_AfterSearchOrder bsso = basob.Query(" and sid='" + aso.sid + "'");
        //                    baso.scode = bsso.scode;
        //                    baso.pcode = bsso.pcode;
        //                    baso.customer = bsso.customer;
        //                    baso.telephone = bsso.telephone;
        //                    baso.address = bsso.address;
        //                    baso.e_city = bsso.cityname;
        //                    baso.dname = bsso.dname;
        //                    baso.cdate = bsso.cdate;
        //                    baso.otype = "原反馈单";
        //                    baso.source = "";
        //                    baso.mname = bsso.mname;
        //                    baso.maker = bsso.maker;
        //                    baso.areason = bsso.rccode;
        //                    baso.aduty = bsso.rrcode;
        //                    baso.method = bsso.method;
        //                    baso.remark = bsso.remake;
        //                }
        //                if (aso.otype == "新订单")
        //                {
        //                    baso = absob.Query(" and sid='" + aso.sid + "'");
        //                }
        //            }
        //        }
        //        r = js.Serialize(baso);
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion

    }
}