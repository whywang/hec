using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvBll.StatisticsInfo;

namespace LionvCommonBll
{
   public class BusiOutOrderTempBll
    {
       BusiTempletBll btb = new BusiTempletBll();
       B_SaleOrderBll bsob = new B_SaleOrderBll();
       B_AfterSaleOrderBll absob = new B_AfterSaleOrderBll();
       B_PackageBll bpb = new B_PackageBll();
       QrCodeBll qcb = new QrCodeBll();
       T_StatisticsBll tsb = new T_StatisticsBll();
       B_ApartSendOrderBll basob = new B_ApartSendOrderBll();
       B_HouseProdcutionBll bhpb = new B_HouseProdcutionBll();
       public string TempOutOrder(string asid,string emcode)
       {
           string city = "";
           string sjr = "";
           string telephone = "";
           string scode = "";
           string customer = "";
           string eqr = "";
           string wlname = "";
           string isdf = "";
           string sid = "";
           string pbody = "";
           B_ApartSendOrder abs= basob.Query(" and osid='" + asid + "'");
           sid = abs.sid;
           scode = abs.fhcode;
           UpdateQrImg(sid);
           B_SaleOrder so = bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder aso = absob.Query(" and sid='" + sid + "'");
           if (so != null)
           {
               city = so.city;
               sjr = so.customer;
               telephone = so.telephone;
               //scode = so.scode;
               customer = so.customer;
               eqr = so.qtimg;
               wlname = "";// so.wlcompany;
               isdf = so.isdf == true ? "是" : "否";
           }
           if (aso != null)
           {
               city = aso.city;
               sjr = aso.customer;
               telephone = aso.telephone;
               //scode = aso.scode;
               customer = aso.customer;
               eqr = aso.qtimg;
               wlname = aso.wlcompany;
               isdf ="否";
           }
           string temp= btb.TempBody(emcode, "");
           temp = temp.Replace("[CITY]",city) ;
           temp = temp.Replace("[FHDATE]", DateTime.Now.ToString("yyyy-MM-dd"));
           temp = temp.Replace("[SJR]", sjr);
           temp = temp.Replace("[TELEPHONE]", telephone);
           temp = temp.Replace("[SCODE]", scode);
           temp = temp.Replace("[CUSTOMER]", customer);
           temp = temp.Replace("[EIMG]", "<img src='"+eqr+"'/>");
           temp = temp.Replace("[FHR]","");
           temp = temp.Replace("[WLCOMPANY]", wlname);
           temp = temp.Replace("[DF]", isdf);
           List<B_HouseProdcution> lbh=bhpb.QueryList(" and osid='" + asid + "'");
           if (lbh != null)
           {
               foreach (B_HouseProdcution bp in lbh)
               {
                   pbody = pbody + "<tr>";
                   pbody = pbody + "<td align='center'>" + bp.gnum + "</td>";
                   pbody = pbody + "<td align='center'>" + bp.pname + "</td>";
                   pbody = pbody + "<td align='center'>" + bp.psize + "</td>";
                   pbody = pbody + "<td align='center'>" + bp.mname + "</td>";
                   pbody = pbody + "<td align='center'>" + bp.pnum + "</td>";
                   pbody = pbody + "</tr>";
               }
           }
           temp = temp.Replace("[PLIST]", pbody);
           #region//包发货单取消
           /*
           DataTable dr = tsb.QueryList("CB_OrderProductionNum","*"," and sid='"+sid+"'"," order by id desc");
           if (dr != null)
           {
               temp = temp.Replace("[MSB]", dr.Rows[0]["msnum"].ToString());
               temp = temp.Replace("[MTB]", (Convert.ToDecimal(dr.Rows[0]["mtmnum"]) + Convert.ToDecimal(dr.Rows[0]["mttnum"])).ToString());
               temp = temp.Replace("[YKB]", dr.Rows[0]["yknum"].ToString());
               temp = temp.Replace("[CTB]", dr.Rows[0]["ctnum"].ToString());
               temp = temp.Replace("[LXG]", dr.Rows[0]["lxnum"].ToString());
               temp = temp.Replace("[HJB]", (Convert.ToDecimal(dr.Rows[0]["dhjnum"]) + Convert.ToDecimal(dr.Rows[0]["chjnum"])).ToString());
               temp = temp.Replace("[TJXB]", dr.Rows[0]["tjxnum"].ToString());
             
           }
           else
           {
               temp = temp.Replace("[MSB]", "0");
               temp = temp.Replace("[MTB]", "0");
               temp = temp.Replace("[YKB]", "0");
               temp = temp.Replace("[CTB]", "0");
               temp = temp.Replace("[LXG]", "0");
               temp = temp.Replace("[LXB]", "0");
               temp = temp.Replace("[TSCPG]", "0");
               temp = temp.Replace("[TSCPB]", "0");
               temp = temp.Replace("[HJB]", "0");
               temp = temp.Replace("[TJXB]", "0");
               temp = temp.Replace("[DB]", "0");
               temp = temp.Replace("[XB]", "0");
           }*/
           #endregion
           return temp;
       }
       private void UpdateQrImg(string sid)
       {
           string scode = "";
           string ourl = "";
           string iurl = "";
           B_SaleOrder so = bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder aso = absob.Query(" and sid='" + sid + "'");
           if (so != null)
           {
               scode = so.scode;
               ourl = so.qtimg;
               if (ourl == "")
               {
                   iurl = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/ImageMeasure/"), scode);
                   bsob.UpdateQr(sid,"/UpFile/ImageMeasure/"+iurl);
               }
           }
           if (aso != null)
           {
               scode = aso.scode;
               ourl = aso.qtimg;
               if (ourl == "")
               {
                   iurl = qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/ImageMeasure/"), scode);
                  //absob.UpdateQr(sid, "/UpFile/ImageMeasure/" + iurl);
               }
           }
           
       }
    }
}
