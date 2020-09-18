using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using LionvCommonBll;
using LionvBll.BusiCommon;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.StorageBusiness.DistributorWjPrepareOrder
{
    public partial class WjPreparePartOrderDetail : System.Web.UI.Page
    {
        private static B_WjPreparePartOrderBll bwppb = new B_WjPreparePartOrderBll();
        private static B_WjOrderBll bsob = new B_WjOrderBll();
        private static B_WjPreParePartGroupProductionBll bwpppgpb = new B_WjPreParePartGroupProductionBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  
        [WebMethod(true)]
        public static string QueryPreParePartOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_WjPreparePartOrder bco = bwppb.Query(" and sid='" + sid + "'");
                if (bco != null)
                {
                    r = js.Serialize(bco);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取备货单列表
        [WebMethod(true)]
        public static ArrayList QueryPreParePartOrderList(string sid)
        {
            ArrayList r = new ArrayList() ;
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_WjPreparePartOrder> bcol = bwppb.QueryList(" and wsid='" + sid + "'");
                if (bcol != null)
                {
                    foreach (B_WjPreparePartOrder b in bcol)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.sid);
                        al.Add(b.pcode);
                        al.Add(b.maker);
                        al.Add(b.cdate);
                        al.Add(b.remark);
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
        #region/// 保存备货单
        [WebMethod(true)]
        public static string SavePreParePartOrder(string sid, ArrayList itemlist, string remark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_WjOrder bwp = bsob.Query(" and sid='" + sid + "'");
                if (bwp != null)
                {
                    bool op = true;
                    bool wp = true;
                    B_WjPreparePartOrder bwpo = new B_WjPreparePartOrder();
                    bwpo.cdate = DateTime.Now.ToString();
                    bwpo.maker = iv.u.ename; ;
                    bwpo.osid = bwp.msid;
                    bwpo.remark = remark;
                    bwpo.sid = CommonBll.GetSid();
                    bwpo.wsid = bwp.sid;
                    List<B_WjPreParePartGroupProduction> pbpp = new List<B_WjPreParePartGroupProduction>();
                    foreach (object[] al in itemlist)
                    {
                        B_WjPreParePartGroupProduction bpp = new B_WjPreParePartGroupProduction();
                        bpp.cdate = DateTime.Now.ToString();
                        bpp.icode = al[0].ToString();
                        bpp.iname = al[1].ToString();
                        bpp.maker = iv.u.ename;
                        bpp.osid = bwp.msid;
                        bpp.sid = bwpo.sid;
                        bpp.wsid = bwpo.wsid;
                        if (Convert.ToDecimal(al[5].ToString()) + Convert.ToDecimal(al[4].ToString()) < Convert.ToDecimal(al[3].ToString()))
                        {
                            bpp.pnum = Convert.ToDecimal(al[5].ToString());
                            op = false;
                        }
                        else
                        {
                            bpp.pnum = Convert.ToDecimal(al[3].ToString()) - Convert.ToDecimal(al[4].ToString());
                        }
                        if (Convert.ToDecimal(al[4].ToString()) > 0)
                        {
                            wp = false;
                        }
                        if (Convert.ToDecimal(al[5].ToString()) > 0)
                        {
                            bwpppgpb.Add(bpp);
                        }
                    }
                    if (op && wp)
                    {
                        bwpo.pcode = bwp.wcode;
                    }
                    else
                    {
                        bwpo.pcode = bwp.wcode + "-" + bwppb.GetOrderNum(sid).ToString().PadLeft(2, '0');
                    }
                    if (bwppb.Add(bwpo) > 0)
                    {
                        r = "S";
                        if (op)
                        {
                            cosb.UpState(sid, "iwjbh", 2);
                            cosb.UpState(bwp.osid, "iwjbh", 2);
                        }
                        else
                        {
                            cosb.UpState(sid, "iwjbh", 1);
                            cosb.UpState(bwp.osid, "iwjbh", 1);
                        }
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
        #region/// 获取备货单列表
        [WebMethod(true)]
        public static ArrayList QueryPreParePartProduction(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_WjPreParePartGroupProduction> bcol = bwpppgpb.QueryList(" and sid='" + sid + "'");
                if (bcol != null)
                {
                    foreach (B_WjPreParePartGroupProduction b in bcol)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.iname);
                        al.Add(b.pnum);
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