using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.StatisticsInfo;
using System.Collections;
using System.Web.Services;
using System.Data;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvCommonBll;
using LionvModel.SysInfo;
using System.Net;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.IO;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.CommonFile
{
    public partial class ProductionPlan : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static BusiPlanProducessBll bppb = new BusiPlanProducessBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static CB_OrderFlowBll cbfb = new CB_OrderFlowBll();
        private static B_ProductionCostBll bpcb = new B_ProductionCostBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        #region// 排产详情
        [WebMethod(true)]
        public static ArrayList QueryPlatList(string sid )
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable dt = tsb.QueryList("View_B_ProductionProcess", "*", " and sid='"+sid+"'", " order by id asc");
                    if (dt != null)
                    {
                        int xh=1;
                        foreach (DataRow dr in dt.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(xh);
                            al.Add(dr["place"].ToString());
                            al.Add(dr["iname"].ToString());
                            al.Add(dr["place"].ToString());
                            al.Add(dr["gname"].ToString());
                            al.Add(dr["bdate"].ToString());
                            r.Add(al);
                            xh++;
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
        #region// 自动排产
        [WebMethod(true)]
        public static string AutoPlatList(string sid)
        {
            string r = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bppb.AutoProducess(sid))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 一般自动排产
        [WebMethod(true)]
        public static string CommonAutoPlatList(string sid)
        {
            string r = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] sids = sid.Split(';');
                if (bppb.CommonAutoProduce(sids))
                {
                    foreach (string id in sids)
                    {
                         CB_OrderFlow cof= cbfb.Query(" and sid='" + id + "' order by id asc");
                         if (cof != null)
                         {
                             switch (cof.emcode)
                             {
                                 case "0001":
                                    EventBtnDo.FireEventBtn(id,"0385","1","自动排产");
                                     break;
                                 case "0009":
                                     EventBtnDo.FireEventBtn(id, "0342", "1", "自动排产");
                                     break;
                                 case "0143":
                                     EventBtnDo.FireEventBtn(id, "0416", "1", "自动排产");
                                     break;
                                 case "0163":
                                     EventBtnDo.FireEventBtn(id, "0365", "1", "自动排产");
                                     break;
                                 case "0177":
                                     break;
                                 case "0192":
                                     break;
                                 case "0213":
                                     break;

                             }
                         }
                    }
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 一般人工排产
        [WebMethod(true)]
        public static string CommonManPlatList(string msdate,string mtdate,string qtdate,string sid)
        {
            string r = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] sids = sid.Split(';');
                if (bppb.CommonManProduce(sids,msdate, mtdate, qtdate))
                {
                    foreach (string id in sids)
                    {
                         CB_OrderFlow cof= cbfb.Query(" and sid='" + id + "' order by id asc");
                         if (cof != null)
                         {
                             switch (cof.emcode)
                             {
                                 case "0001":
                                    EventBtnDo.FireEventBtn(id,"0385","1","人工排产");
                                     break;
                                 case "0009":
                                     EventBtnDo.FireEventBtn(id,"0342","1","人工排产");
                                     break;
                                 case "0143":
                                     EventBtnDo.FireEventBtn(id,"0416","1","人工排产");
                                     break;
                                 case "0163":
                                     EventBtnDo.FireEventBtn(id, "0365", "1", "人工排产");
                                     break;
                                 case "0177":
                                     break;
                                 case "0192":
                                     break;
                                 case "0213":
                                     break;

                             }
                         }
                    }
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 人工动排产
        [WebMethod(true)]
        public static string ManPlatList(string sid)
        {
            string r = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bppb.ManProducess(sid))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 排产详情
        [WebMethod(true)]
        public static ArrayList QueryMsPlanItem(string bdate, string gycode,string emcode,string pbcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != "" && bdate != null)
                {
                    bdate = CommonBll.GetBdate(bdate);
                    where.AppendFormat(" and bdate >= '{0}' and bdate<='{1}'", bdate + " 00:00:00", bdate + " 23:59:59");
                }
                if (gycode != "")
                {
                    where.AppendFormat(" and gcode = '{0}'", gycode);
                }
                if (pbcode != "")
                {
                    where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_RBrandsMaterial] where pbcode='{0}' )", pbcode);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, "a", iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    DataTable dt = tsb.QueryList(svt.tname, svt.sqlcols, where.ToString(), " order by id asc");
                    if (dt != null)
                    {
                        int xh = 1;
                        foreach (DataRow dr in dt.Rows)
                        {

                            ArrayList al = new ArrayList();
                            al.Add(xh);
                            foreach (DataColumn column in dt.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "id":
                                         break;
                                    case "acode":
                                        break;
                                    case "sid":
                                        break;
                                    case "rowId":
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                            }
                            al.Add("<a href='#'>打印标签</a>");
                            r.Add(al);
                            xh++;
                        }
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
        #region// 排产详情
        [WebMethod(true)]
        public static ArrayList QueryMtPlanItem(string bdate, string gycode, string emcode, string pbcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != "" && bdate != null)
                {
                    bdate = CommonBll.GetBdate(bdate);
                    where.AppendFormat(" and bdate >= '{0}' and bdate<='{1}'", bdate + " 00:00:00", bdate + " 23:59:59");
                }
                if (gycode != "")
                {
                    where.AppendFormat(" and gcode = '{0}'", gycode);
                }
                if (pbcode != "")
                {
                    where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_RBrandsMaterial] where pbcode='{0}' )", pbcode);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, "a", iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    DataTable dt = tsb.QueryList(svt.tname, svt.sqlcols, where.ToString(), " order by id asc");
                    if (dt != null)
                    {
                        int xh = 1;
                        foreach (DataRow dr in dt.Rows)
                        {

                            ArrayList al = new ArrayList();
                            al.Add(xh);
                            foreach (DataColumn column in dt.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "id":
                                        break;
                                    case "acode":
                                        break;
                                    case "sid":
                                        break;
                                    case "rowId":
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                            }
                            al.Add("<a href='#'>打印标签</a>");
                            r.Add(al);
                            xh++;
                        }
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
        #region// 一般自动排产
        [WebMethod(true)]
        public static string SetBatch(string pdate,string ptype)
        {
            string r = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (pdate == null || pdate == "")
                {
                    pdate = DateTime.Now.ToString();
                }
                if(ptype=="ms")
                {
                    if (bppb.SetMsBtach(CommonBll.GetBdate(pdate)))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
                if (ptype == "mt")
                {
                    if (bppb.SetMtBtach(CommonBll.GetBdate(pdate)))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region
        [WebMethod(true)]
        public static ArrayList QueryCostList(string sid,string gnum)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_ProductionCost> lc = bpcb.QueryList(" and sid='" + sid + "' and psid in(select psid from B_groupproduction where sid='"+sid+"' and gnum='"+gnum+"') order by id asc");
                if (lc != null)
                {
                    int xh = 1;
                    foreach (B_ProductionCost bc in lc)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(xh);
                        al.Add(bc.pname);
                        al.Add(bc.height);
                        al.Add(bc.width);
                        al.Add(bc.deep);
                        al.Add(bc.pnum);
                        al.Add(bc.bjtype);
                        al.Add(bc.gname);
                        al.Add(bc.gcode);
                        al.Add(bc.uname);
                        al.Add(bc.ucode);
                        al.Add(bc.ccname);
                        al.Add(bc.cccode);
                        al.Add(bc.utype);
                        al.Add(bc.unum);
                        r.Add(al);
                        xh++;
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
    }
}