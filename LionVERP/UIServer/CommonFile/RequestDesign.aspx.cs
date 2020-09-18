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
using LionvBll.BusiOrderInfo;
using LionvCommonBll;
using LionvAopModel;

namespace LionVERP.UIServer.CommonFile
{
    public partial class RequestDesign : System.Web.UI.Page
    {
        private static B_MzRequstDesignBll brdpb = new B_MzRequstDesignBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region--获取店面设计需求
        [WebMethod(true)]
        public static ArrayList QueryRqPlanList(string sid, string emcode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_MzRequstDesign> lbp = brdpb.QueryList(" and sid='" + sid + "'");
                if (lbp != null)
                {
                    foreach (B_MzRequstDesign b in lbp)
                    {
                        string cz = bebb.ItemsBtnList(sid, b.id.ToString(), emcode, iv.u.rcode);
                        ArrayList al = new ArrayList();
                        al.Add(b.place);
                        al.Add(b.preqest);
                        al.Add(b.pdemo);
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
        #region--删除店面设计需求
        [WebMethod(true)]
        public static string DelRqPlan(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (brdpb.Delete(" and id=" + pid + ""))
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