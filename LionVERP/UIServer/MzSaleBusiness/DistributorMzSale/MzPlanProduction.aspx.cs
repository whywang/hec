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

namespace LionVERP.UIServer.MzSaleBusiness.DistributorMzSale
{
    public partial class MzPlanProduction : System.Web.UI.Page
    {
        private static B_MzRequstDesignBll brdpb = new B_MzRequstDesignBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static B_MzDesignPlanBll bmdpb = new B_MzDesignPlanBll();
        private static B_MzPriceFileBll bmpfb = new B_MzPriceFileBll();
        private static B_MzMeasureFileBll bmmfb = new B_MzMeasureFileBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      
      
        #region--获取木作报价单
        [WebMethod(true)]
        public static ArrayList QueryPriceList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_MzPriceFile> lbp = bmpfb.QueryList(" and sid='" + sid + "'");
                if (lbp != null)
                {
                    foreach (B_MzPriceFile b in lbp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.fname);
                        al.Add(b.cdate);
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
        #region--删除报价单
        [WebMethod(true)]
        public static string DelPrice(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmpfb.Delete(" and id=" + pid + ""))
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
        #region--获取店面设计测量单
        [WebMethod(true)]
        public static ArrayList QueryMeasureList(string sid, string emcode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_MzMeasureFile> lbp = bmmfb.QueryList(" and sid='" + sid + "'");
                if (lbp != null)
                {
                    foreach (B_MzMeasureFile b in lbp)
                    {
                        string cz = bebb.ItemsBtnList(sid, b.id.ToString(), emcode, iv.u.rcode);
                        ArrayList al = new ArrayList();
                        al.Add(b.mname);
                        al.Add(CommonBll.GetBdate(b.cdate));
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
        #region--删除店面设计测量单
        [WebMethod(true)]
        public static string DelMeasure(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bmmfb.Delete(" and id=" + pid + ""))
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