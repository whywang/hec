using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Text;
using LionvBll.BusiCommon;
using LionvCommonBll;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class CommonHouse : System.Web.UI.Page
    {
        private static B_HouseProdcutionBll bhpb = new B_HouseProdcutionBll();
        private static CB_OrderStateBll bosb = new CB_OrderStateBll();
        private static B_ApartSendOrderBll basob = new B_ApartSendOrderBll();
        private static B_InHouseOrderBll bihob = new B_InHouseOrderBll();
        private static B_AfterSaleOrderBll basb = new B_AfterSaleOrderBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取产品库存列表
        [WebMethod(true)]
        public static ArrayList QueryHouseProductionList(string sid ,string itype)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (itype == "i")
                {
                    where.AppendFormat(" and istate=0");
                }
                if (itype == "o")
                {
                    where.AppendFormat(" and ostate=0");
                }
                List<B_HouseProdcution> lbhp = bhpb.QueryList(" and sid='" + sid + "' " + where.ToString() + "");
                if (lbhp != null)
                {
                    foreach (B_HouseProdcution bp in lbhp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.gnum);
                        al.Add(bp.pname);
                        al.Add(bp.psize);
                        al.Add(bp.pnum);
                        al.Add(bp.mname);
                        al.Add(bp.idate);
                        al.Add(bp.odate);
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
        #region// 产品入库
        [WebMethod(true)]
        public static string ProductionInHouse(string sid,string psid,string remark)
        {
            string r = "";
            int zt=0;
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string scode = "";
                B_AfterSaleOrder ba=basb.Query(" and sid='" + sid + "'");
                B_SaleOrder bo=bsob.Query(" and sid='" + sid + "'");
                if (bo != null)
                {
                    scode = bo.scode;
                }
                if (ba != null)
                {
                    scode = ba.scode;
                }
                B_InHouseOrder bio = new B_InHouseOrder();
                bio.isid = CommonBll.GetSid();
                bio.sid = sid;
                bio.maker = iv.u.ename;
                bio.ps = remark;
                bio.state = 0;
                bio.cdate = DateTime.Now.ToString();
                string[] arr = psid.Split(';');
                if (bhpb.InUpdate(arr,bio.isid))
                {
                     bosb.UpState(sid, "istoreget", 1);
                    if (!bhpb.Exist(" and istate=0 and sid='" + sid + "'"))
                    {
                        zt=1;
                        bosb.UpState(sid, "istoreget", 2);
                    }
                    if (!bihob.Exists(" and sid='" + sid + "'") && zt == 1)
                    {
                        bio.icode = scode;
                    }
                    else
                    {
                        List<B_InHouseOrder> bihl = bihob.QueryList(" and sid='" + sid + "'");
                        int n = bihl == null ? 1 : bihl.Count;
                        bio.icode = scode+"-"+n.ToString().PadLeft(2,'0');
                    }
                    bihob.Add(bio);
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
        #region// 产品出库
        [WebMethod(true)]
        public static string ProductionOutHouse(string sid, string psid, string remark)
        {
            string r = "";
            string code = "";
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_AfterSaleOrder ba = basb.Query(" and sid='" + sid + "'");
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    code = bso.scode;
                }
                if (ba != null)
                {
                    code = ba.scode;
                }
                List<B_HouseProdcution> lbhp = bhpb.QueryList(" and sid='" + sid + "'");
                string[] arr = psid.Split(';');
                string osid = CommonBll.GetSid();
                if (bhpb.OutUpdate(arr,osid))
                {
                    bosb.UpState(sid, "istoredeliver", 1);
                    B_ApartSendOrder bo = new B_ApartSendOrder();
                    if (lbhp.Count == arr.Length)
                    {
                        bo.fhcode = code;
                        bo.snum = 0;
                    }
                    else
                    {
                        bo.snum=basob.QueryMaxNum(sid);
                        bo.fhcode = code + "-" + bo.snum.ToString();
                    }
                    bo.sid = sid;
                    bo.osid = osid;
                    bo.maker = iv.u.ename;
                    bo.cdate = DateTime.Now.ToString();
                    basob.Add(bo);
                    if (!bhpb.Exist(" and ostate=0 and sid='" + sid + "'"))
                    {
                        bosb.UpState(sid, "istoredeliver", 2);
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
        #region//获取订单入库单
        [WebMethod(true)]
        public static ArrayList QueryInHouseList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_InHouseOrder> lbo = bihob.QueryList(" and sid='" + sid + "'");
                if (lbo != null)
                {
                    foreach (B_InHouseOrder o in lbo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(o.isid);
                        al.Add(o.icode);
                        al.Add(o.maker);
                        al.Add(CommonBll.GetBdate(o.cdate));
                        al.Add(o.ps);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r .Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region//获取入库单产品
        [WebMethod(true)]
        public static ArrayList QueryInHouseProductoinList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_HouseProdcution> lbo = bhpb.QueryList(" and isid='" + sid + "'");
                if (lbo != null)
                {
                    foreach (B_HouseProdcution bp in lbo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.gnum);
                        al.Add(bp.pname);
                        al.Add(bp.psize);
                        al.Add(bp.pnum);
                        al.Add(bp.mname);
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
        #region//获取入库产品
        [WebMethod(true)]
        public static ArrayList QueryInProductionList(string sid)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                where.AppendFormat(" and istate=1");
                List<B_HouseProdcution> lbhp = bhpb.QueryList(" and sid='" + sid + "' " + where.ToString() + "");
                if (lbhp != null)
                {
                    foreach (B_HouseProdcution bp in lbhp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.gnum);
                        al.Add(bp.pname);
                        al.Add(bp.psize);
                        al.Add(bp.pnum);
                        al.Add(bp.mname);
                        al.Add("<a href='#'>打印标签</a>");
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
        #region//获取发货产品
        [WebMethod(true)]
        public static ArrayList QueryOutProductionList(string sid)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                where.AppendFormat(" and ostate=1");
                List<B_HouseProdcution> lbhp = bhpb.QueryList(" and osid='" + sid + "' " + where.ToString() + "");
                if (lbhp != null)
                {
                    foreach (B_HouseProdcution bp in lbhp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.gnum);
                        al.Add(bp.pname);
                        al.Add(bp.psize);
                        al.Add(bp.pnum);
                        al.Add(bp.mname);
                        al.Add("<a href='#'>打印标签</a>");
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