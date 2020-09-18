using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using ViewModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiProductionPriceBll
    {
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       #region//OutTime--正常产品价格编辑
       public string EditPriceForm(string sid, int gnum)
       {
           StringBuilder eptable = new StringBuilder();
           List<B_GroupProduction> lbp = bgpb.QueryList(" and sid='"+sid+"' and gnum="+gnum+"");
           if (lbp !=null)
           {
               eptable.Append("<form id='EditPriceProduction'><table class='editprice' border='1'>");
               eptable.Append("<tr><td>序号</td><td>产品</td><td>金额</td><td>非标金额</td><td>其他费用</td><td>说明</td></tr>");
               eptable.Append(ProductionPriceForm(lbp));
               eptable.Append("</table></form>");
           }
           else
           {
               eptable.Append("");
           }
           return eptable.ToString();
       }
       private string ProductionPriceForm(List<B_GroupProduction> lbp)
       {
           StringBuilder ItemHtml = new StringBuilder();
           if (lbp != null)
           {
               int xh = 1;
               foreach (B_GroupProduction gp in lbp)
               {
                   ItemHtml.Append("<tr>");
                   ItemHtml.AppendFormat("<td>{0}</td>",xh);
                   ItemHtml.AppendFormat("<td>{0}<input id='P{1}' name='P{1}' value='{2}' style='display:none'/></td>", gp.iname,xh, gp.psid);
                   ItemHtml.AppendFormat("<td><input readonly='true' id='G{0}' name='G{0}' value='{1}'/></td>",xh,gp.gmoney);
                   ItemHtml.AppendFormat("<td><input  readonly='true' id='O{0}' name='O{0}' value='{1}'/></td>", xh, gp.govermoney);
                   ItemHtml.AppendFormat("<td><input  id='Q{0}' name='Q{0}' value='{1}'/></td>", xh, gp.gothermoney);
                   ItemHtml.AppendFormat("<td><input  id='T{0}' name='T{0}' value='{1}'/></td>", xh, gp.priceps);
                   ItemHtml.AppendFormat("</tr>");
                   xh++;
               }
           }
           return ItemHtml.ToString();
       }
       #endregion
       #region//套餐产品价格编辑
       public string TcEditPriceForm(string sid, string tsid)
       {
           StringBuilder eptable = new StringBuilder();
           List<B_GroupProduction> lbp = bgpb.QueryList(" and sid='" + sid + "' and tsid='" + tsid + "' order by gnum asc ,icode asc");
           if (lbp != null)
           {
               eptable.Append("<form id='EditPriceProduction'><table class='editprice' border='1'>");
               eptable.Append("<tr><td>序号</td><td>产品</td><td>金额</td><td>非标金额</td><td>其他费用</td><td>说明</td></tr>");
               eptable.Append(ProductionPriceForm(lbp));
               eptable.Append("</table></form>");
           }
           else
           {
               eptable.Append("");
           }
           return eptable.ToString();
       }
        #endregion
    }
}
