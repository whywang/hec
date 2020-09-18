using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.BusiCommon;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class LogRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///标准尺寸列表
        [WebMethod(true)]
        public static ArrayList QueryList(string sid)
        {
            ArrayList r = new ArrayList();
            CB_ButtonEventBll snsb = new CB_ButtonEventBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                List<CB_OrderEventBtn>lsf = snsb.QueryList(" and sid='"+sid+"' order by cdate desc");
                if (lsf != null)
                {
                    foreach (CB_OrderEventBtn s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.bname);
                        al.Add(s.maker);
                        al.Add(s.ps);
                        al.Add(s.cdate);
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