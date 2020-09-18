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
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using System.Collections;

namespace LionVERP.UIServer.StorageBusiness.DistributorDoorMqOrder
{
    public partial class InDoorMqOrderDetail : System.Web.UI.Page
    {
        private static B_PackageCodeBll bpcb = new B_PackageCodeBll();
        private static B_InHouseOrderBll bihob = new B_InHouseOrderBll();
        private static B_InhousePackageBll bipb = new B_InhousePackageBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static B_PackageDateBll bpdb = new B_PackageDateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 保存入库单
        [WebMethod(true)]
        public static string SavePackage(string sid,string qremark, string rowid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string scode = "";
                string precode = "";
                B_InHouseOrder bpqo = new B_InHouseOrder();
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    scode = bso.scode;
                }
                bpqo.cdate = DateTime.Now.ToString();
                bpqo.maker = iv.u.ename;
                bpqo.icode = scode + "-" + precode + bihob.QueryIorderNum(" and sid='" + sid + "'").ToString();
                bpqo.isid = CommonBll.GetSid();
                bpqo.ps = qremark;
                bpqo.state = 1;
                bpqo.sid = sid;

                List<B_InhousePackage> lq = new List<B_InhousePackage>();
                string[] arrow = rowid.ToString().Split(';');
                if (arrow.Length > 0)
                {
                    foreach (string id in arrow)
                    {
                        B_PackageCode bgp = bpcb.Query(" and id=" + id + "");
                        if (bgp != null)
                        {
                            bpdb.UpPackageState(sid, bgp.id.ToString(), "insdate");
                            B_InhousePackage bpi = new B_InhousePackage();
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.isid = bpqo.isid;
                            bpi.pid = bgp.id;
                            bpi.sid = sid;
                            bpi.maker = iv.u.ename;
                            bpi.sid = sid;
                            lq.Add(bpi);
                        }
                    }
                }
                if (bihob.SaveQualityOrder(bpqo, lq))
                {
                    List<B_PackageCode> lbp = bpcb.QueryList(" and sid='" + sid + "' and id not in (select pid  from B_InhousePackage where isid in (select isid from B_InHouseOrder where sid='" + sid + "'))");
                    if (lbp == null)
                    {
                        cosb.UpState(sid, "istoreget", 2);
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
        #region// 获取入库单
        [WebMethod(true)]
        public static ArrayList QueryPackList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_InHouseOrder> bpqo = bihob.QueryList(" and sid='" + sid + "'");
                if (bpqo != null)
                {
                    foreach (B_InHouseOrder b in bpqo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.isid);
                        al.Add(b.icode);
                        al.Add(b.maker);
                        al.Add(CommonBll.GetBdate(b.cdate));
                        al.Add(b.ps);
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
        #region// 获取入库单包装
        [WebMethod(true)]
        public static ArrayList QueryPackPackageList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_InhousePackage> bpqo = bipb.QueryList(" and isid='" + sid + "'");
                if (bpqo != null)
                {
                    foreach (B_InhousePackage b in bpqo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add("B"+b.pid.ToString().PadLeft(7,'0'));
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
    }
}