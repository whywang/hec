using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvCommonBll;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.UIServer.CommonFile
{
    public partial class OrderFlowLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单工作流程
        [WebMethod(true)]
        public static ArrayList QueryFlowLine(string emcode)
        {
            ArrayList r = new ArrayList() ;
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WorkEvent> lsw = snsb.QuerySingleWorkFlow(emcode);
               if (lsw != null)
               {
                   foreach (Sys_WorkEvent w in lsw)
                   {
                       ArrayList al = new ArrayList();
                       al.Add(w.wcode);
                       al.Add(w.wname);
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

        #region//获取已完成工作节点
        [WebMethod(true)]
        public static string GetOverFlowPoint(string sid, string emcode)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = snsb.QueryOverFlowPoint(sid, emcode);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
    }
}