using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionvModel.SysInfo;
using System.Text;
using System.Data;
using System.Collections;

namespace LionVERP.Controllers.BjFixOrder
{
    public class BjFixOrdersController:Controller
    {
        private B_FixOrderBll bfb = new B_FixOrderBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        private Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private BusiEventButtonBll bebb = new BusiEventButtonBll();
        private CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private B_FixOrderTaskBll bfotb = new B_FixOrderTaskBll();
        private B_FixGetGoodsImgBll bfggib = new B_FixGetGoodsImgBll();
        private B_FixecImgBll bfib = new B_FixecImgBll();
        private B_FixVisitInfoBll bfvifb = new B_FixVisitInfoBll();
        private B_FixMoneyBll bfmb = new B_FixMoneyBll();
        private Sys_DomainBll sdb = new Sys_DomainBll();
        private B_FixProductionBll bfpb = new B_FixProductionBll();
        private Sys_EmployeeBll seb = new Sys_EmployeeBll();
        private B_YySendBll bysb = new B_YySendBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//北京安装单
        public JsonResult QueryFixOrder(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string azs = "";
                string odate = "";
                B_FixOrder sal = new B_FixOrder();
                sal = bfb.Query(" and  sid='" + sid + "'");
                List<B_FixOrderTask> bfot = bfotb.QueryList(" and sid='" + sid + "'");
                if (bfot != null)
                {
                    foreach (B_FixOrderTask bt in bfot)
                    {
                        azs = azs + bt.azs+";";
                        odate = bt.odate;
                    }
                }
                if (sal != null)
                {
                    sal.fixter = azs;
                    sal.fixdate = odate;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveFixOrder(string address,string code, string customer,string remark,string sid,string telephone)
        {
            JsonData d = new JsonData();
            B_FixOrder bf = new B_FixOrder();
            CB_OrderState cos = new CB_OrderState();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                bf.cdate = DateTime.Now.ToString();
                bf.scode = code;
                bf.customer =customer;
                bf.telephone = telephone;
                bf.address = address;
                bf.dcode = "01080101";
                bf.dname = "北京市";
                bf.remark = remark;
                bf.maker = iv.u.ename;
                if (sid == "")
                {
                    if (bfb.Exists(" and scode='" + bf.scode + "'"))
                    {
                        d.d = "T";
                    }
                    else
                    {
                        bf.sid = CommonBll.GetSid();
                        if (bfb.Add(bf) > 0)
                        {
                            cos.sid = bf.sid;
                            cosb.Add(cos);
                            bwfb.CreateWorkFlow(bf.sid, "0077");
                            d.d = bf.sid;
                        }
                        else
                        {
                            d.d = "F";
                        }
                    }
                }
                else
                {
                    bf.sid = sid;
                    if (bfb.Exists(" and scode='" + bf.scode + "' and sid<>'" + sid + "'"))
                    {
                        d.d = "T";
                    }
                    else
                    {
                        if (bfb.Update(bf))
                        {
                            d.d = bf.sid;
                        }
                        else
                        {
                            d.d = "F";
                        }
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryFixOrderList(string bdate, string city, string code, string curpage, string customer, string edate, string emcode, string pagesize, string platform, string tabcode,string telephone)
        {
            JsonData d = new JsonData();
            StringBuilder where = new StringBuilder();
            DataTable lsr = new DataTable();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (customer != "")
                {
                    where.AppendFormat(" and customer like '%{0}%'", customer);
                }
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (telephone != "")
                {
                    where.AppendFormat(" and telephone like '%{0}%'", telephone);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "zt")
                                {
                                    al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            r.Add(al);

                        }
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//安装任务分配
        public JsonResult DistributionFixTask(string sid, string fixter, string dtype)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (fixter != "")
                {
                    string [] fixterarr=fixter.Split(';');
                    if (dtype == "0")
                    {
                        if (bfotb.SetAzs(sid, fixterarr, iv.u.ename))
                        {
                            d.d = "S";
                        }
                        else
                        {
                            d.d = "F";
                        }
                    }
                    if (dtype == "1")
                    {
                        if (bfotb.ASetAzs(sid, fixterarr, iv.u.ename))
                        {
                            d.d = "S";
                        }
                        else
                        {
                            d.d = "F";
                        }
                    }
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取收货图片缩略图列表
        public JsonResult QueryShFixImgListZip(string sid)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
              List<B_FixGetGoodsImg> bfggi= bfggib.QueryList(" and sid='"+sid+"' order by id ");
              if (bfggi != null)
              {
                  Sys_Domain wd = sdb.Query(" and dtype='w'");
                  Sys_Domain pd = sdb.Query(" and dtype='p'");
                  string wurl = wd == null ? "" : wd.url;
                  string purl = pd == null ? "" : pd.url;
                  divstr.Append("<div style='width:100%'>");
                  foreach (B_FixGetGoodsImg bg in bfggi)
                  {
                      divstr.Append("<div style='width:100px;height:100px;float:left'>");
                      divstr.Append("<div style='width:100px;height:20px;float:left'>");
                      divstr.AppendFormat("<img id='{0}' src='../../../Image/opeimage/close.gif' style='cursor:pointer;float:right' onclick='DelShImg(this.id)'/>", bg.id);
                      divstr.Append("</div>");
                      divstr.Append("<div style='width:100px;height:80px;float:right'>");
                      if (bg.domain == "w")
                      {
                          divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>",wurl+ bg.url);
                      }
                      if (bg.domain == "p")
                      {
                          divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", purl + bg.url);
                      }
                      divstr.Append("</div>");
                      divstr.Append("</div>");
                  }
                  divstr.Append("</div>");
              }
                d.d = divstr.ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取收货图片列表
        public JsonResult QueryShFixImgList(string sid)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixGetGoodsImg> bfggi = bfggib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    Sys_Domain wd = sdb.Query(" and dtype='w'");
                    Sys_Domain pd = sdb.Query(" and dtype='p'");
                    string wurl = wd == null ? "" : wd.url;
                    string purl = pd == null ? "" : pd.url;
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_FixGetGoodsImg bg in bfggi)
                    {
                        divstr.Append("<div>");
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<img src='{0}'/>", wurl+bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<img src='{0}'/>",purl+ bg.url);
                        }
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                }
                d.d = divstr.ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//删除收货图片
        public JsonResult DelShFixImg(string id)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bfggib.Delete(" and id=" + id + " "))
                {
                    d.d ="S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取收货图片缩略图列表
        public JsonResult QueryAzFixImgListZip(string sid)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixecImg> bfggi = bfib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    Sys_Domain wd = sdb.Query(" and dtype='w'");
                    Sys_Domain pd = sdb.Query(" and dtype='p'");
                    string wurl = wd == null ? "" : wd.url;
                    string purl = pd == null ? "" : pd.url;
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_FixecImg bg in bfggi)
                    {
                        divstr.Append("<div style='width:100px;height:100px;float:left'>");
                        divstr.Append("<div style='width:100px;height:20px;float:left'>");
                        divstr.AppendFormat("<img id='{0}' src='../../../Image/opeimage/close.gif' style='cursor:pointer;float:right' onclick='DelAzImg(this.id)'/>", bg.id);
                        divstr.Append("</div>");
                        divstr.Append("<div style='width:100px;height:80px;float:right'>");
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>",wurl+ bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", purl+bg.url);
                        }
                        divstr.Append("</div>");
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                }
                d.d = divstr.ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取收货图片缩略图列表
        public JsonResult QueryAzFixImgList(string sid)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixecImg> bfggi = bfib.QueryList(" and sid='" + sid + "' order by id ");
                if (bfggi != null)
                {
                    Sys_Domain wd = sdb.Query(" and dtype='w'");
                    Sys_Domain pd = sdb.Query(" and dtype='p'");
                    string wurl = wd == null ? "" : wd.url;
                    string purl = pd == null ? "" : pd.url;
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_FixecImg bg in bfggi)
                    {
                        divstr.Append("<div >");
                        if (bg.domain == "w")
                        {
                            divstr.AppendFormat("<img src='{0}'/>", wurl + bg.url);
                        }
                        if (bg.domain == "p")
                        {
                            divstr.AppendFormat("<img src='{0}'/>", purl + bg.url);
                        }
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                }
                d.d = divstr.ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//删除收货图片
        public JsonResult DelAzFixImg(string id)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bfib.Delete(" and id=" + id + " "))
                {
                    d.d = "S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//新增回访信息
        public JsonResult AddVisitInfo(string sid,string vinfo)
        {
            JsonData d = new JsonData();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_FixVisitInfo bi = new B_FixVisitInfo();
                bi.sid = sid;
                bi.vinfo = vinfo;
                bi.cdate = DateTime.Now.ToString();
                bi.maker = iv.u.ename;
                if (bfvifb.Add(bi) > 0)
                {
                    d.d = "S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取回访信息
        public JsonResult QueryVisitInfoList(string sid)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            StringBuilder divstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_FixVisitInfo> bil = bfvifb.QueryList(" and sid='"+sid+"'");
                if (bil != null)
                {
                    foreach (B_FixVisitInfo bi in bil)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bi.vinfo);
                        al.Add(bi.maker);
                        al.Add(bi.cdate);
                        r.Add(al);
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取订单费用信息
        public JsonResult QueryFixOrderMoney(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_FixMoney sal = new B_FixMoney();
                sal = bfmb.Query(" and  sid='" + sid + "'");
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//更新订单费用信息
        public JsonResult UpdateFixOrderMoney(string sid, string amoney, string dmoney, string mremark, List<String[]> prow)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList pml = new ArrayList();
                B_FixMoney bfm= new B_FixMoney();
                bfm.amoney = Convert.ToDecimal(amoney);
                bfm.dmoney =0- Convert.ToDecimal(dmoney);
                bfm.sid = sid;
                bfm.premark = mremark;
                bfm.cdate = DateTime.Now.ToString();
                bfm.maker = iv.u.ename;
                if (prow != null)
                {
                    foreach (String[] s in prow)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s[0]);
                        al.Add(s[2]);
                        pml.Add(al);
                    }
                }
                if (bfmb.UpdateFixMoney(bfm, pml))
                {
                    d.d = "S";
                }
                else
                {
                    d.d ="F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取订单总安装费
        public JsonResult QueryFixAllMoney(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                decimal amoney = 0;
                decimal dmoney = 0;
                B_FixMoney bfm = bfmb.Query(" and sid='"+sid+"'");
                if (bfm != null)
                {
                    amoney = bfm.amoney;
                    dmoney = bfm.dmoney;
                }
                decimal pmoney=  bfpb.QueryOrderMoney(" and sid='" + sid + "'");
                d.d = (amoney+dmoney+pmoney).ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取安装师安装费
        public JsonResult QueryAzsFixListMoney(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int i = 0;
                ArrayList r = new ArrayList();
                List<B_FixOrderTask> lbt = bfotb.QueryList(" and sid='" + sid + "' and azstype<>'x'");
                if (lbt != null)
                {
                    foreach (B_FixOrderTask bt in lbt)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(i);
                        al.Add(bt.azs);
                        al.Add(bt.otype);
                        al.Add(bt.oratio);
                        al.Add(bt.remark);
                        r.Add(al);
                        i++;
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存
        public JsonResult SaveAzsFixListMoney(string sid,List<String[]> prow,string fmoney)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                decimal famoney = Convert.ToDecimal(fmoney);
                decimal camoney = 0;
                decimal wamoney = 0;
                ArrayList ga = new ArrayList();
                ArrayList wga = new ArrayList();
                if (prow != null)
                {
                    foreach (String[] s in prow)
                    {
                        ArrayList al = new ArrayList();
                        if (s[0].ToString() != "" && s[1].ToString() != "" && s[2].ToString() != "" && s[2].ToString() != "0")
                        {
                            al.Add(s[0].ToString());
                            al.Add(s[1].ToString());
                            decimal azsmoney = Convert.ToDecimal(s[2].ToString());
                            if (s[1].ToString() == "金额")
                            {
                                camoney = camoney + azsmoney;
                                al.Add(azsmoney);
                                al.Add(azsmoney);
                                al.Add(s[3].ToString());
                            }
                            if (s[1].ToString() == "比例")
                            {
                                camoney = camoney + famoney * azsmoney;
                                al.Add(azsmoney);
                                al.Add(famoney * azsmoney);
                                al.Add(s[3].ToString());
                            }
                            ga.Add(al);
                        }
                        else
                        {
                            al.Add(s[0].ToString());
                            al.Add(s[3].ToString());
                            wga.Add(al);
                        }
                    }
                }
                wamoney = famoney - camoney;
                if (wamoney >= 0)
                {
                    if (bfotb.SaveDisMoney(sid, ga, wga, wamoney))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    d.d = "MB";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存预约配送信息
        public JsonResult SaveYySend(string psbz, string psdate , string psy, string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_YySend bfm = new B_YySend();
                bfm.sid = sid;
                bfm.sperson = psy;
                bfm.pdate = CommonBll.GetBdate(psdate);
                bfm.pbz = psbz;
                bfm.maker = iv.u.ename;
                bfm.cdate = DateTime.Now.ToString();
                if (bysb.Add(bfm)>0)
                {
                    d.d = "S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取预约配送信息集合
        public JsonResult QueryYySendList(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList r = new ArrayList();
                List<B_YySend> bfm = bysb.QueryList(" and sid='"+sid+"' order by id desc");
                if (bfm != null)
                {
                    foreach (B_YySend b in bfm)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.sperson);
                        al.Add(b.pdate);
                        al.Add(b.pbz);
                        r.Add(al);
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取预约配送信息
        public JsonResult QueryYySend(string sid)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_YySend  bfm = bysb.Query(" and sid='" + sid + "' order by id desc");
                d.d = js.Serialize(bfm);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
    }
}