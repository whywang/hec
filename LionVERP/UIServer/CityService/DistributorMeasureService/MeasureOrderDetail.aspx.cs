using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;
using LionvModel.BusiCommon;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.CityService.DistributorMeasureService
{
    public partial class MeasureOrderDetail : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_MeasureOrderBll bmob = new B_MeasureOrderBll();
        private static B_MeasureProductionBll bmpb = new B_MeasureProductionBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static QrCodeBll qcb = new QrCodeBll();
        private static Sys_MeasureProductionBll smpb = new Sys_MeasureProductionBll();
        private static BusiMeasureLimitedBll bmlb = new BusiMeasureLimitedBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化测量单
        [WebMethod(true)]
        public static string InitOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MeasureOrder bco = new B_MeasureOrder();
                if (bmob.Exists(" and osid='" + sid + "'"))
                {
                    bco = bmob.Query(" and osid='" + sid + "'");
                    bco.bplist = bmpb.QueryList(" and sid='" + bco.sid + "' order by id");
                }
                else
                {
                   B_SaleOrder bso= bsob.Query(" and sid='" + sid + "'");
                   if (bso != null)
                   {
                       bco.acity = bso.acity;
                       bco.address = bso.address;
                       bco.aprovince = bso.aprovince;
                       bco.customer = bso.customer;
                       bco.gzname = bso.gzname;
                       bco.telephone = bso.telephone;
                       bco.mremark = "";
                       List<B_MeasureProduction> lbp = new List<B_MeasureProduction>();
                       List<Sys_MeasureProduction> lsp = smpb.QueryList("");
                       if (lsp != null)
                       {
                           foreach (Sys_MeasureProduction smp in lsp)
                           {
                               B_MeasureProduction bp = new B_MeasureProduction();
                               bp.pcname = smp.mpname;
                               bp.pcnum = 0;
                               lbp.Add(bp);
                           }
                       }
                       bco.bplist = lbp;
                   }
                }
                r = js.Serialize(bco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存测量单
        [WebMethod(true)]
        public static string SaveOrder(string acity, string address, string aprovince, string bcode, string csid, string customer, string emcode, string gzname, string mdate, string mremark, ArrayList plist, string sid, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                B_MeasureOrder bco = new B_MeasureOrder();
                bco.acity = acity;
                bco.address = address;
                bco.aprovince = aprovince;
                bco.customer = customer;
                bco.gzname = gzname;
                bco.maker = iv.u.ename;
                bco.mdate = mdate;
                bco.mremark = mremark;
                bco.osid = sid;
                bco.telephone = telephone;
                bco.city = bso.city;
                bco.citycode = bso.citycode;
                bco.dcode = bso.dcode;
                bco.dname = bso.dname;
                bco.mname = bso.mname;
                bco.cdate = DateTime.Now.ToString();
                bco.sdcode = DateTime.Now.ToString("yyyymmddhhMMss");
                if(csid == "")
                {
                    bco.sid = CommonBll.GetSid();
                }
                else
                {
                    bco.sid=csid;
                }
                List<B_MeasureProduction> lbp = new List<B_MeasureProduction>(); 
                foreach (object[] o in plist)
                {
                    B_MeasureProduction bmp = new B_MeasureProduction();
                    var p = o;
                    bmp.cdate = DateTime.Now.ToString();
                    bmp.maker = iv.u.ename;
                    bmp.pcname = p[0].ToString();
                    bmp.pcnum = Convert.ToInt32(p[1].ToString());
                    bmp.sid= bco.sid;
                    lbp.Add(bmp);
                }
                bco.bplist = lbp;
                if (bmlb.CheckLimited(bco.dcode, bco.mdate))
                {
                    r = "MOB";
                }
                else
                {
                    if (csid == "")
                    {
                        CB_OrderState cos = new CB_OrderState();
                        bco.qtimg = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/OrderQt/"), CommonBll.GetHost() + "UIClient/SalesBusiness/DistributorOrder/SaleOrderDetail.htm?Sid=" + bco.sid);
                        if (bmob.Add(bco) > 0)
                        {
                            bwfb.CreateWorkFlow(bco.sid, emcode);
                            cos.sid = bco.sid;
                            cosb.Add(cos);
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
                        EventBtnDo.FireEventBtn(bco.sid, bcode, "1", " 保存测量单");
                    }
                    else
                    {
                        if (bmob.Update(bco))
                        {
                            r = "S";
                        }
                        else
                        {
                            r = "F";
                        }
                        EventBtnDo.FireEventBtn(bco.sid, bcode, "1", " 更改测量单");
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
        #region/// 初始化测量单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string bpliststr = "";
                B_MeasureOrder bco = new B_MeasureOrder();
                bco = bmob.Query(" and sid='" + sid + "'");
                bco.bplist = bmpb.QueryList(" and sid='" + bco.sid + "' and pcnum>0 order by id");
                if (bco.bplist != null)
                {
                    foreach (B_MeasureProduction bp in bco.bplist)
                    {
                        bpliststr=bpliststr+bp.pcname+"-"+bp.pcnum.ToString()+";";
                    }
                }
                bco.bpliststr=bpliststr;
                r = js.Serialize(bco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}