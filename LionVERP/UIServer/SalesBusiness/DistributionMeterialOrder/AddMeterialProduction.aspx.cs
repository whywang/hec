using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvModel.BusiOrderInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvCommonBll;
using System.Web.Services;
using LionvBll.BusiOrderInfo;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributionMeterialOrder
{
    public partial class AddMeterialProduction : System.Web.UI.Page
    {
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static BusiComputePriceBll bcpb = new BusiComputePriceBll();
        private static BusiInvSizeTransFormBll bistfb = new BusiInvSizeTransFormBll();
        private static Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        private static Sys_RemarkBll srb = new Sys_RemarkBll();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//保存产品
        [WebMethod(true)]
        public static string SaveProduction( string gnum, string pbz,string pcode, string pname,string pnum, string psize, string sid)
        {
            string r = "";
            List<B_GroupProduction> lbgp = new List<B_GroupProduction>();
            string invcate = pcode.Substring(8, 3);
            string egnum = "0";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string gsid = CommonBll.GetSid();
                pbz = pbz.Replace(",", " ");
                if (gnum == "" || gnum == "0")
                {
                    egnum = bgpb.GetGnum(" and sid='" + sid + "' and gnum<1000").ToString();
                }
                else
                {
                    egnum = gnum;
                }
                B_GroupProduction wl = new B_GroupProduction();
                #region//物料
                if (pcode != "")
                {
                    Sys_InventoryDetail iwl = sidb.Query(" and icode='" + pcode + "'");
                    wl.sid = sid;
                    wl.tsid = "";
                    wl.gsid = gsid;
                    wl.psid = CommonBll.GetSid();
                    wl.itype = invcate;
                    wl.fix = "";
                    wl.direction = "";
                    wl.place = "";
                    wl.inum = Convert.ToDecimal(pnum);
                    wl.gnum = Convert.ToInt32(egnum);
                    wl.locktype = "";
                    wl.mname = "";
                    wl.icode = pcode;
                    wl.iname = pname;
                    wl.height = 0;
                    wl.ptype = "wl";
                    wl.width = 0;
                    wl.deep = 0;
                    wl.fsize = 0;
                    wl.isjc = "";
                    wl.allprice = 0;
                    wl.serverprice = 0;
                    wl.uname = iwl == null ? "" : iwl.iunit;
                    wl.maker = iv.u.ename;
                    wl.cdate = DateTime.Now.ToString();
                    if (pcode != "")
                    {
                        wl.ps = srb.QueryGByIcode(pcode) + pbz;
                    }
                    wl.zjname = "";
                    wl.zjcode = "";
                    wl.zjmname = "";
                    wl.zsize = 0;
                    wl.tbcz = "";
                    wl.lxcz = "";
                    wl.idiscount= 1;
                    wl.floor = "";
                    wl.spec = psize;
                }
                #endregion
                lbgp.Add(wl);
                if (bgpb.SaveList(lbgp, sid, Convert.ToInt32(egnum)) > 0)
                { 
                    bcpb.InvComputePrice(sid, Convert.ToInt32(egnum), iv.u.dcode, "gh");
                    bpib.SaveItemList(bistfb.CreateTranFormList(sid, Convert.ToInt32(egnum), iv.u.ename));
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