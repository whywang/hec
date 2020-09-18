using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiProduceProcessBll
   {
       private Sys_ProcessPointBll sppb=new Sys_ProcessPointBll ();
       private CB_OrderProduceProcessBll coppb=new CB_OrderProduceProcessBll ();
       private B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
       private BusiOrderStateBll bosb = new BusiOrderStateBll();
       private CB_ProductionProcessBll cbppb = new CB_ProductionProcessBll();
       #region//设置订单工艺路线
       public void SetProduceProcess(string sid,string pcode)
       {
           List<CB_OrderProduceProcess> lcp=new List<CB_OrderProduceProcess> ();
           List<Sys_ProcessPoint> lsp= QueryLineList(pcode);
           if(lsp.Count>0)
           {   
               DateTime dt=DateTime.Now;
               int i=1;
               foreach(Sys_ProcessPoint s in lsp)
               {
                   CB_OrderProduceProcess p=new CB_OrderProduceProcess ();
                   dt=dt.AddDays((double)s.usetime);
                   p.jsort=i;
                   p.sid=sid;
                   p.jdcode=s.jcode;
                   p.jdname=s.jname;
                   p.ydate=dt.ToString();
                   p.jstate = 0;
                   p.jtype = s.jtype;
                   lcp.Add(p);
                   i++;
               }
               coppb.SaveList(sid,lcp);
           }
       }
       private List<Sys_ProcessPoint> QueryLineList(string pcode)
       {
           List<Sys_ProcessPoint> r=new List<Sys_ProcessPoint> ();
           Sys_ProcessPoint spp=sppb.Query(" and pcode='"+pcode+"' and jtype='q'");
           if(spp!=null)
           {
               r.Add(spp);
               LoopLine(  pcode,spp.jcode,ref  r);
           }
           return r;
       }
       private List<Sys_ProcessPoint> LoopLine(string pcode,string precode,ref List<Sys_ProcessPoint> r)
       {
           Sys_ProcessPoint spp=sppb.Query(" and pcode='"+pcode+"' and precode='"+precode+"'");
           if(spp!=null)
           {
               r.Add(spp);
               if(spp.jtype!="h")
               {
                   LoopLine( pcode, spp.jcode,ref  r);
               }
           }
           return r;
       }
       #endregion
       #region//获取订单工艺路线
       public string GetOrderProcess(string sid)
       {
           string r = "";
           StringBuilder hje = new StringBuilder();
           List<CB_OrderProduceProcess> lcp = new List<CB_OrderProduceProcess>();
           lcp = coppb.QueryList(" and sid='" + sid + "' order by jsort asc");
           if (lcp != null)
           {
               hje.Append("<div style='clear:both'></div>");
               foreach(CB_OrderProduceProcess p in lcp)
               {
                   string odate=p.odate == null ? "" : CommonBll.GetBdate(p.odate);
                   hje.AppendFormat("<div class='jd'>");
                   hje.AppendFormat("<ul>");
                   hje.AppendFormat("<li class='li jdtxt'>{0}</li>", p.jdname);
                   hje.AppendFormat("<li class='li' >预计日期:{0}</li>", CommonBll.GetBdate(p.ydate));
                   hje.AppendFormat("<li class='li'>状态:{0}</li>", ProduceProcessState(p.jstate));
                   hje.AppendFormat("<li class='li'>实际日期:{0}</li>", odate);
                   hje.AppendFormat("<li class='sm'>说明:{0}</li>", ProduceProcessRemark(p.sid, p.jdcode));
                   hje.AppendFormat("</ul>");
                   hje.AppendFormat("</div>");
               }
              
           }
           r = hje.ToString();
           return r;
       }
       public string ProduceProcessState(int i)
       {
           string r = "";
           switch (i)
           {
               case 1:
                   r = "<span style='color:#1d6d08;font-weight:bolder'>已完成</span>";
                   break;
               case 0:
                   r = "<span style='color:#cccccc;font-weight:bolder'>未完成</span>";
                   break;
               case -1:
                   r = "<span style='color:#a09b0d;font-weight:bolder'>延期</span>";
                   break;
               case -2:
                   r = "<span style='color:#a09b0d;font-weight:bolder'>暂停</span>";
                   break;
               case -3:
                   r = "<span style='color:#c51c0a;font-weight:bolder>取消</span>";
                   break;
           }
           return r;
       }
       private string ProduceProcessRemark(string sid, string jcode)
       {
           return "";
       }
       public string GetProduceProcess(string sid)
       {
           string r = "";
           StringBuilder hje = new StringBuilder();  
           List<CB_ProductionProcess> lcp = new List<CB_ProductionProcess>();
           lcp = cbppb.QueryList(" and sid='" + sid + "' order by id asc");
           if (lcp != null)
           {
               hje.Append("<div style='clear:both'></div>");
               hje.Append("<div style='height:30px;width:100%;background:#f2f2f2;text-align:center'> <span style='display:block;margin-top:10px;font-size:16px;font-weight:bolder;color:#666666'>产品工艺进度</span></div>");
               foreach (CB_ProductionProcess p in lcp)
               {
                   string odate = p.odate == null ? "" : CommonBll.GetBdate(p.odate);
                   hje.AppendFormat("<div class='jd'>");
                   hje.AppendFormat("<ul>");
                   hje.AppendFormat("<li class='li jdtxt'>{0}</li>", p.iname);
                   hje.AppendFormat("<li class='li jdtxt'>{0}</li>", p.gname);
                   hje.AppendFormat("<li class='li' >预计日期:{0}</li>", CommonBll.GetBdate(p.bdate));
                   hje.AppendFormat("<li class='li'>状态:{0}</li>", ProduceProcessState(p.gstate));
                   hje.AppendFormat("<li class='li'>实际日期:{0}</li>", odate);
                   hje.AppendFormat("<li class='sm'>说明:{0}</li>", "");
                   hje.AppendFormat("</ul>");
                   hje.AppendFormat("</div>");
               }

           }
           r = hje.ToString();
           return r;
       }
       #endregion
       #region//获取工艺订单信息
       public string GetProduceOrder(string sid)
       {
           string r = "";
           string scode = "";
           string customer = "";
           string city = "";
           string zt = "";
           string fname = "";
           string bdate = "";
           string odate = "";
           B_SaleOrder bso=bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder baso=basob.Query(" and sid='" + sid + "'");
           B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
               scode = bso.scode;
               customer = bso.customer;
               city = bso.city;
           }
           if (baso != null)
           {
               scode = baso.scode;
               customer = baso.customer;
               city = baso.city;
           }
           if (bof != null)
           {
               fname = bof.dname;
               bdate = bof.cdate == "" ? "" : CommonBll.GetBdate(bof.cdate);
               odate = bof.overdate == "" ? "" : CommonBll.GetBdate(bof.overdate);
           }
           zt ="<img height='25' src='"+ bosb.QueryOrderStateImg(sid)+"' alt='状态'/>";
           StringBuilder hje = new StringBuilder();
           hje.AppendFormat("<div class='oinfo'>");
            hje.AppendFormat("<ul>");
            hje.AppendFormat("<li class='li'><strong>订单编号:</strong>{0}</li>", scode);
            hje.AppendFormat("<li class='li'><strong>生产工厂:</strong>{0}</li>", fname);
            hje.AppendFormat("<li class='li'><strong>生产日期:</strong>{0}</li>", bdate);
            hje.AppendFormat("<li class='li'><strong>预计完工日期:</strong>{0}</li>", odate);
            hje.AppendFormat("</ul>");
            hje.AppendFormat("</div>");
            hje.Append("<div style='clear:both'></div>");
            hje.AppendFormat("<div class='oinfo'>");
            hje.AppendFormat("<ul>");
            hje.AppendFormat("<li class='li'><strong>客户:</strong>{0}</li>", customer);
            hje.AppendFormat("<li class='li'><strong>城市:</strong>{0}</li>", city);
            hje.AppendFormat("<li class='lizt'><strong>状态:</strong></li><li >{0}</li>", zt);
            hje.AppendFormat("</ul>");
            hje.AppendFormat("</div>");
           r = hje.ToString();
           return r;
       }
       #endregion
   }
}
