using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvCommonBll;
using ViewModel.BusiOrderInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvMgModel;
using LionvBll.BusiMgOrderInfo;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class SetMealProduction : System.Web.UI.Page
    {
        private static BusiSetMealBll bsmb = new BusiSetMealBll();
        private static Sys_SetMealBll ssmb = new Sys_SetMealBll();
        private static B_SetMealBll bsmbs = new B_SetMealBll();
        private static Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static Sys_RemarkBll srb = new Sys_RemarkBll();
        private static Sys_ProduceImgBll spib = new Sys_ProduceImgBll();
        private static Sys_MsCzBll smcb = new Sys_MsCzBll();
        private static BusiInvSizeTransFormBll bistfb = new BusiInvSizeTransFormBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static VProductionsBll vpb = new VProductionsBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static BusiComputePriceBll bcpb = new BusiComputePriceBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取套餐产品
        [WebMethod(true)]
        public static ArrayList QueryTcProduction(string sid,string tsid, string tccode)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<VStProduction> lv = bsmb.QueryStMProductionList(sid, tsid,tccode);
                if (lv != null)
                {
                    foreach (VStProduction v in lv)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(v.id);
                        al.Add(v.sid);
                        al.Add(v.psid);
                        al.Add(v.gnum);
                        al.Add(v.place);
                        al.Add(v.ptype);
                        al.Add(v.direction);
                        al.Add(v.fix);
                        al.Add(v.locks);
                        al.Add(v.locktype);
                        al.Add(v.jybj);
                        al.Add(v.pname);
                        al.Add(v.pcode);
                        al.Add(v.pmname);
                        al.Add(v.mtname);
                        al.Add(v.mtcode);
                        al.Add(v.mtmname);
                        al.Add(v.tbtype);
                        al.Add(v.lxtype);
                        al.Add(v.blname);
                        al.Add(v.pheight);
                        al.Add(v.pwidth);
                        al.Add(v.pdeep);
                        al.Add(v.pnum);
                        al.Add(v.remark);
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
        #region/// 获取套餐赠品
        [WebMethod(true)]
        public static ArrayList QueryTcZProduction(string sid, string tsid, string tccode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<VStProduction> lv = bsmb.QueryStZProductionList(sid, tsid, tccode);
                if (lv != null)
                {
                    foreach (VStProduction v in lv)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(v.id);
                        al.Add(v.sid);
                        al.Add(v.psid);
                        al.Add(v.gnum);
                        al.Add(v.place);
                        al.Add(v.ptype);
                        al.Add(v.direction);
                        al.Add(v.fix);
                        al.Add(v.locks);
                        al.Add(v.locktype);
                        al.Add(v.jybj);
                        al.Add(v.pname);
                        al.Add(v.pcode);
                        al.Add(v.pmname);
                        al.Add(v.mtname);
                        al.Add(v.mtcode);
                        al.Add(v.mtmname);
                        al.Add(v.tbtype);
                        al.Add(v.lxtype);
                        al.Add(v.blname);
                        al.Add(v.pheight);
                        al.Add(v.pwidth);
                        al.Add(v.pdeep);
                        al.Add(v.pnum);
                        al.Add(v.remark);
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
        #region//获取套餐
        [WebMethod(true)]
        public static string QueryTc(  string tsid )
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SetMeal bsm = bsmbs.Query(" and tsid='" + tsid + "'");
                r = js.Serialize(bsm);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//删除套餐
        [WebMethod(true)]
        public static string DelTc(string sid,string tsid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bsmbs.DelTcProduction(sid, tsid))
                {
                    bsdb.CheckSetOrderDiscount(sid);
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
    }
}