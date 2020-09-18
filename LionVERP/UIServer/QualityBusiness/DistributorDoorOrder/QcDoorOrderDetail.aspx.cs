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
using LionvCommonBll;
using LionvBll.BusiCommon;
using System.Collections;

namespace LionVERP.UIServer.QualityBusiness.DistributorDoorOrder
{
    public partial class QcDoorOrderDetail : System.Web.UI.Page
    {
        private static B_PartQualityOrderBll bpqob = new B_PartQualityOrderBll();
        private static B_PartQualityItemsBll bpqib = new B_PartQualityItemsBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 保存验收单
        [WebMethod(true)]
        public static string SaveQualityProduction(string sid,string qtype,string qremark,string rowid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string scode="";
                string precode = "";
                B_PartQualityOrder bpqo = new B_PartQualityOrder();
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                if (qtype == "s")
                {
                    bpqo.qstate = 1;
                }
                if (qtype == "f")
                {
                    bpqo.qstate = -1;
                    precode = "F";
                }
                if (bso != null)
                {
                    scode = bso.scode;
                }
                bpqo.cdate = DateTime.Now.ToString();
                bpqo.maker = iv.u.ename;
                bpqo.qcode = scode + "-" + precode + bpqob.QueryQorderNum(" and sid='" + sid + "' and qstate=" + bpqo.qstate + "").ToString();
                bpqo.qsid = CommonBll.GetSid();
                bpqo.remark = qremark;
                bpqo.sid = sid;

                List<B_PartQualityItems> lq = new List<B_PartQualityItems>();
                string[] arrow = rowid.ToString().Split(';');
                if (arrow.Length > 0)
                {
                    foreach (string id in arrow)
                    {
                        string idv = "";
                        string etype = "";
                        B_PartQualityItems bpi = new B_PartQualityItems();
                        if (id.IndexOf('-') > -1)
                        {
                            string []ids=id.Split('-');
                            idv = ids[0];
                            etype = ids[1];
                        }
                        else
                        {
                            idv = id;
                        }
                        B_GroupProduction bgp = bgpb.Query(" and id=" + idv + "");
                        if (bgp != null)
                        {
                            bpi.cdate = DateTime.Now.ToString();
                            //if (bgp.ptype == "ms")
                            //{
                            //    B_ProductionItem li = bpib.Query(" and psid='" + bgp.psid + "' and e_ptype='" + etype + "'");
                            //    bpi.deep = li.deep;
                            //    bpi.gnum = bgp.gnum;
                            //    bpi.height = li.height;
                            //    bpi.maker = iv.u.ename;
                            //    bpi.pcode = li.pcode;
                            //    bpi.pname = li.pname;
                            //    bpi.pnum = (int)li.pnum;
                            //    bpi.psid = li.psid;
                            //    bpi.qsid = bpqo.qsid;
                            //    bpi.sid = sid;
                            //    bpi.width = li.width;
                            //    lq.Add(bpi);
                            //}
                            //else
                            //{
                                bpi.deep = bgp.deep;
                                bpi.gnum = bgp.gnum;
                                bpi.height = bgp.height;
                                bpi.maker = iv.u.ename;
                                bpi.pcode = bgp.icode;
                                bpi.pname = bgp.iname;
                                bpi.pnum = (int)bgp.inum;
                                bpi.psid = bgp.psid;
                                bpi.qsid = bpqo.qsid;
                                bpi.sid = sid;
                                bpi.width = bgp.width;
                                lq.Add(bpi);
                            //}
                        }
                    }
                }
                if (bpqob.SaveQualityOrder(bpqo, lq))
                {
                    List<B_GroupProduction> lbpi = bgpb.QueryList(" and sid='" + sid + "' and substring(icode,9,3)<>'004' and psid not in (select psid from  B_PartQualityItems where qsid in(select qsid from B_PartQualityOrder where sid='" + sid + "' and qstate=1) ) order by gnum");
                    if (lbpi==null)
                    {
                        cosb.UpState(sid, "iquality", 2);
                        cosb.UpState(sid, "ifactorydeliver", 2);
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
        #region// 获取验收单
        [WebMethod(true)]
        public static ArrayList QueryQualityList(string sid, string qtype )
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_PartQualityOrder> bpqo = bpqob.QueryList(" and sid='" + sid + "' and qstate=" + qtype + "");
                if (bpqo != null)
                {
                    foreach (B_PartQualityOrder b in bpqo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.qsid);
                        al.Add(b.qcode);
                        al.Add(b.maker);
                        al.Add(CommonBll.GetBdate(b.cdate));
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
        #region// 获取验收单产品
        [WebMethod(true)]
        public static ArrayList QueryQualityProductionList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_PartQualityItems> bpqo = bpqib.QueryList(" and qsid='" + sid + "'");
                if (bpqo != null)
                {
                    foreach (B_PartQualityItems b in bpqo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.gnum);
                        al.Add(b.pname);
                        al.Add(b.height.ToString() + "*" + b.width.ToString()+"*"+b.deep.ToString());
                        al.Add(b.pnum.ToString());
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