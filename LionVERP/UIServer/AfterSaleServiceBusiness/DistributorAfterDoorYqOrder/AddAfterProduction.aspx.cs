using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;
using System.Collections;
using LionvBll.BusiCommon;
using LionVERP.UIServer.BaseSet.WorkFlowManage;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder
{
    public partial class AddAfterProduction : System.Web.UI.Page
    {
        private static B_AfterGroupProductionBll bagpb = new B_AfterGroupProductionBll();
        private static B_AfterProductionImgBll bitb = new B_AfterProductionImgBll();
        private static B_AfterPartInHouseOrderBll bapihob = new B_AfterPartInHouseOrderBll();
        private static B_AfterReModifyOrderBll barmob = new B_AfterReModifyOrderBll();
        private static CB_OrderStateBll cosb=new CB_OrderStateBll ();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//初始化售后申请单
        [WebMethod(true)]
        public static string AddProduction(string direction, string fixs, string ggy,string glasss, string gsize, string itype, string locks, string mname, string msname, string pd, string ph,  string place,string pmsd, string pname, string pnum, string premark, string psid, string pw, string sid,string sitype,string stype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterGroupProduction ao = new B_AfterGroupProduction();
            if (iv.f)
            {
                ao.direction = direction;
                ao.fixs = fixs;
                ao.glass = glasss;
                ao.gsize = gsize;
                ao.height = Convert.ToInt32(ph);
                ao.width = Convert.ToInt32(pw);
                ao.deep = Convert.ToInt32(pd);
                ao.iheight =0;
                ao.iwidth = 0;
                ao.ideep = 0;
                ao.pnum = Convert.ToDecimal(pnum);
                ao.itype = itype;
                ao.locks = locks;
                ao.mname = mname;
                ao.place = place;
                ao.pname = pname;
                ao.remark = premark;
                ao.sid = sid;
                ao.stype = stype;
                ao.msname = msname;
                ao.sitype = sitype;
                ao.maker = iv.u.ename;
                ao.ggy = ggy;
                ao.pmsd = pmsd;
                ao.cdate = DateTime.Now.ToString();
                if (psid == "")
                {
                    ao.gnum = bagpb.GetGnum(" and sid='" + sid + "'");
                    ao.psid = CommonBll.GetSid();
                    if (bagpb.Add(ao) > 0)
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
                    ao.psid = psid;
                    if (bagpb.Update(ao))
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
        #region//初始化售后申请单
        [WebMethod(true)]
        public static string SaveProductionRemark(string sid, string gnum, string adremark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterGroupProduction ao = new B_AfterGroupProduction();
            if (iv.f)
            {
                if (bagpb.SetRemark(sid, gnum, adremark))
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
        #region//获取产品
        [WebMethod(true)]
        public static string QueryProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterGroupProduction ao = new B_AfterGroupProduction();
            if (iv.f)
            {
                ao = bagpb.Query(" and sid='" + sid + "' and gnum=" + gnum + "");
                r = js.Serialize(ao);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//删除产品
        [WebMethod(true)]
        public static string DelProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterGroupProduction ao = new B_AfterGroupProduction();
            if (iv.f)
            {
                if (bagpb.Delete(" and sid='" + sid + "' and gnum=" + gnum + ""))
                {
                    bitb.Delete(sid ,gnum);
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
        #region//设置生产车间
        [WebMethod(true)]
        public static string SetWorkFrom(string sid, ArrayList plist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList pl = new ArrayList();
                foreach(object [] o in plist)
                {
                    ArrayList p = new ArrayList();
                    p.Add(o[0].ToString());
                    p.Add(o[6].ToString());
                    pl.Add(p);
                }
                if (pl.Count > 0)
                {
                    if (bagpb.SetWorkFrom(sid, pl))
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
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]
        public static ArrayList QueryProductionList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_AfterGroupProduction> lp = bagpb.QueryList(" and sid='" + sid + "' order by id asc");
                if (lp != null)
                {
                    int xh=1;
                    foreach (B_AfterGroupProduction p in lp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(p.id);
                        al.Add(xh);
                        al.Add(p.itype);
                        al.Add(p.place);
                        al.Add(p.sitype);
                        al.Add(p.pname);
                        al.Add(p.workform);
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
        #region//产品入库
        [WebMethod(true)]
        public static string ProductionInHouse(string bcode,string sid, string psids,string remark)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterPartInHouseOrder bio = new B_AfterPartInHouseOrder();
            if (iv.f)
            {
                string eco="";
                int pc=bapihob.CreateNum(sid,psids);
                if(pc!=0)
                {
                    eco="-"+pc.ToString().PadLeft(2,'0');
                }
                B_AfterReModifyOrder bro= barmob.Query(" and sid='"+sid+"'");
                bio.sid = CommonBll.GetSid();
                bio.osid = sid;
                bio.pscode = bro.scode + eco;
                bio.scode = bro.scode;
                bio.remark = remark;
                bio.maker = iv.u.ename;
                bio.cdate = DateTime.Now.ToString();
                bio.plist = psids;
                if (bapihob.Add(bio) > 0)
                {
                    if (!bagpb.Exists(" and sid='" + sid + "' and psid not in (select psid from dbo.B_AfterPartInHouseProduction where osid='" + sid + "')"))
                    {
                        cosb.UpState(sid, "istoreget", 2);
                        cosb.UpState(sid, "iproduce", 2);
                        EventBtnDo.FireEventBtn(sid, bcode, "1", "产品全部入库");
                    }
                    else
                    {
                        EventBtnDo.FireEventBtn(sid, bcode, "1", "产品部分入库");
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
        #region//获取未入库产品
        [WebMethod(true)]
        public static ArrayList QueryProductionInHouse(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterPartInHouseOrder bio = new B_AfterPartInHouseOrder();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_AfterGroupProduction> lbp = bagpb.QueryList(" and sid='" + sid + "' and psid not in (select psid from dbo.B_AfterPartInHouseProduction where osid='" + sid + "') order by gnum asc");
                if (lbp != null)
                {
                    int xh=1;
                    foreach (B_AfterGroupProduction bp in lbp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.psid);
                        al.Add(xh);
                        al.Add(bp.place);
                        al.Add(bp.pname);
                        al.Add(bp.mname);
                        al.Add(bp.height.ToString() + "*" + bp.width.ToString() + "*" + bp.deep.ToString());
                        al.Add(bp.pnum);
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
        #region//获取已入库库产品
        [WebMethod(true)]
        public static ArrayList InQueryProductionInHouse(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            B_AfterPartInHouseOrder bio = new B_AfterPartInHouseOrder();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_AfterGroupProduction> lbp = bagpb.QueryList(" and psid in (select psid from dbo.B_AfterPartInHouseProduction where sid='" + sid + "') order by gnum asc");
                if (lbp != null)
                {
                    int xh = 1;
                    foreach (B_AfterGroupProduction bp in lbp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.psid);
                        al.Add(xh);
                        al.Add(bp.place);
                        al.Add(bp.pname);
                        al.Add(bp.mname);
                        al.Add(bp.height.ToString() + "*" + bp.width.ToString() + "*" + bp.deep.ToString());
                        al.Add(bp.pnum);
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