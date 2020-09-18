using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class MeasureOrderDetail : System.Web.UI.Page
    {
        private static B_MeasureOrderBll bmob = new B_MeasureOrderBll();
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        #region/// 保存测量记录
        [WebMethod(true)]
        public static string SaveMeasureOrder(string clbz,string cldate,string cldh,string cls, string sid )
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MeasureOrder bmo = new B_MeasureOrder();
                //bmo.csid = sid;
                //bmo.cdate = DateTime.Now.ToString();
                //bmo.maker = iv.u.ename;
                //bmo.ps = clbz;
                //bmo.surveyor = cls;
                //bmo.mdate = cldate;
                //bmo.cldh = cldh;
                if (bmob.Add(bmo) > 0)
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

        #region/// 获取测量记录
        [WebMethod(true)]
        public static ArrayList QueryMeasureList( string sid)
        {
            ArrayList r = new ArrayList ();
            List<B_MeasureOrder> lbo = new List<B_MeasureOrder>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lbo = bmob.QueryList(" and csid='" + sid + "'");
                if (lbo != null)
                {
                    foreach (B_MeasureOrder s in lbo)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        //al.Add(s.surveyor);
                        //al.Add(s.cldh);
                        //al.Add(Convert.ToDateTime( s.mdate).ToString("yyyy-MM-dd"));
                        //al.Add(s.ps);
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
    }
}