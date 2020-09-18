using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.BusiOrderInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class AddWjBh : System.Web.UI.Page
    {
        private static B_PreWjOrderBll bpwb = new B_PreWjOrderBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化五金备货单
        [WebMethod(true)]
        public static string InitOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_PreWjOrder bpw = new B_PreWjOrder();
                if (sid == "")
                {
                    bpw.wjcode = "BW" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    bpw.id = 0;
                    bpw.sid = CommonBll.GetSid();
                }
                else {
                    bpw = bpwb.Query(" and sid='" + sid + "'");
                }
                r = js.Serialize(bpw);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存五金备货单
        [WebMethod(true)]
        public static string SaveWjOrder(string city,string code,string id,string remark,string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_PreWjOrder bpw = new B_PreWjOrder();
                bpw.sid = sid;
                bpw.wjcode = code;
                bpw.cdate = DateTime.Now.ToString();
                bpw.e_city = city;
                bpw.maker = iv.u.ename;
                bpw.remark = remark;
                if (id == "0")
                {
                    if (bpwb.Add(bpw) > 0)
                    {
                        bwfb.CreateWorkFlow(bpw.sid, "0054");
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    if (bpwb.Update(bpw))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
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