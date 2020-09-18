using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class ApartOutHouse : System.Web.UI.Page
    {
        private static B_ApartSendOrderBll basob = new B_ApartSendOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 产品出库
        [WebMethod(true)]
        public static ArrayList ApartSendList( string sid )
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_ApartSendOrder> lbhp = basob.QueryList(" and sid='" + sid + "'");
                if (lbhp!=null)
                {
                    foreach (B_ApartSendOrder b in lbhp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.osid);
                        al.Add(b.fhcode);
                        al.Add(b.maker);
                        al.Add(b.cdate);
                        al.Add(bebb.QueryBtnListItems("0078", iv.u.rcode, "LX", b.osid));
                        r.Add(al);
                    }
                }
            }
            else
            {
                r .Add(iv.badstr);
            }
            return r;
        }
        #endregion
    }
}