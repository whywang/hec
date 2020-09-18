using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.SalesBusiness.DistributorDrawProductionOrder
{
    public partial class DrawProductionOrderDetail : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_DrawProductionOrderBll bmppob = new B_DrawProductionOrderBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化订单
        [WebMethod(true)]
        public static string InitOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_DrawProductionOrder ino = new B_DrawProductionOrder();
                B_DrawProductionOrder bco = bmppob.Query(" and sid='" + sid + "'");
                if (bco == null)
                {
                    B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                    if (bso != null)
                    {
                        ino.sid = "";
                        ino.osid = bso.sid;
                        ino.cityname = bso.city;
                        ino.citycode = bso.citycode;
                        ino.shopname = bso.dname;
                        ino.shopcode = bso.dcode;
                    }
                    else
                    {
                        ino.osid = "";
                        ino.cityname = "";
                        ino.citycode = "";
                        ino.shopname = "";
                        ino.shopcode = "";
                    }
                }
                else
                {
                    ino = bco;
                }
                r = js.Serialize(ino);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取订单
        [WebMethod(true)]
        public static string SaveOrder(string cityname, string citycode, string emcode, string osid, string remark, string sid, string shopcode, string shopname)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_DrawProductionOrder ino = new B_DrawProductionOrder();
                ino.bdcode = iv.u.dcode.Substring(0, 8);
                ino.cdate = DateTime.Now.ToString();
                ino.cityname = cityname;
                ino.citycode = citycode;
                ino.maker = iv.u.ename;
                ino.osid = osid;
                ino.remark = remark;
                ino.scode = "NP" + DateTime.Now.ToString("yyyyMMddHHmmss");
                if (sid == "")
                {
                    ino.sid = CommonBll.GetSid();
                    if (bmppob.Add(ino) > 0)
                    {
                        if (ino.osid != "")
                        {
                            cosb.UpState(ino.osid, "ipdraw", 1);
                        }
                        CB_OrderState cos = new CB_OrderState();
                        cos.sid = ino.sid;
                        cosb.Add(cos);
                        bwfb.CreateWorkFlow(ino.sid, emcode);
                        r = ino.sid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    ino.sid = sid;
                    if (bmppob.Update(ino))
                    {
                        r = ino.sid;
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
        #region/// 获取订单
        [WebMethod(true)]
        public static string QueryOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_DrawProductionOrder ino = new B_DrawProductionOrder();
                B_DrawProductionOrder bco = bmppob.Query(" and sid='" + sid + "'");
                if (bco == null)
                {
                    ino = bmppob.Query(" and osid='" + sid + "'");
                }
                else
                {
                    ino = bco;
                }
                r = js.Serialize(ino);
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