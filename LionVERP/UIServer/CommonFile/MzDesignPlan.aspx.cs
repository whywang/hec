using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.CommonFile
{
    public partial class MzDesignPlan : System.Web.UI.Page
    {
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static B_MzDesignPlanBll bmdpb = new B_MzDesignPlanBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region--获取设计方案
        [WebMethod(true)]
        public static ArrayList QueryPlanList(string sid, string emcode,string ptype)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_MzDesignPlan> lbp = bmdpb.QueryList(" and sid='" + sid + "' and ptype='"+ptype+"'");
                if (lbp != null)
                {
                    foreach (B_MzDesignPlan b in lbp)
                    {
                        string cz = bebb.ItemsBtnList(sid, b.id.ToString(), emcode, iv.u.rcode);
                        ArrayList al = new ArrayList();
                        al.Add(b.place);
                        al.Add(b.pname);
                        al.Add(b.pnum);
                        al.Add(cz);
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
        #region--删除设计方案
        [WebMethod(true)]
        public static string DelPlan(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmdpb.Delete(" and id=" + pid + ""))
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
    }
}