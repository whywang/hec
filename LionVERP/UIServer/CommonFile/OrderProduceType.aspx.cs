using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    /// <summary>
    /// 订单生产方式设置
    /// </summary>
    public partial class OrderProduceType : System.Web.UI.Page
    {
        private static BusiOrderProduceTypeBll borb = new BusiOrderProduceTypeBll();
        private static BusiBtnExceBll bbeb = new BusiBtnExceBll();
        private static CB_OrderProduceTypeBll soptb = new CB_OrderProduceTypeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 设置订单编码
        [WebMethod(true)]
        public static string SetOrderProduceType(string sid, string emcode, string bcode, string gytype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = "F";
                if (borb.SetProduceType(sid, emcode, gytype))
                {
                    CB_OrderProduceType ct = new CB_OrderProduceType();
                    ct.sid = sid;
                    ct.gytype = gytype;
                    ct.maker = iv.u.ename;
                    ct.cdate = DateTime.Now.ToString();
                    soptb.Delete(sid);
                    soptb.Add(ct);
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                bbeb.WriteBtnRecoder(sid, bcode, iv.u.ename);
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