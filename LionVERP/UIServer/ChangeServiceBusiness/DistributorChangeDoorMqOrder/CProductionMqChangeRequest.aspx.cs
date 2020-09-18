using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.ChangeServiceBusiness.DistributorChangeDoorMqOrder
{
    public partial class CProductionMqChangeRequest : System.Web.UI.Page
    {
        private static B_GroupProductionChangeRequstBll bgpcrb = new B_GroupProductionChangeRequstBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取更改订单
        [WebMethod(true)]
        public static string SaveProductionChangeRequest(string sid,ArrayList prow)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_GroupProductionChangeRequst> lr = new List<B_GroupProductionChangeRequst>();
                if (prow != null)
                {
                    foreach (object[] o in prow)
                    {
                        B_GroupProductionChangeRequst br = new B_GroupProductionChangeRequst();
                        
                        if (o[6].ToString() != "")
                        {
                            int pid = Convert.ToInt32(o[0].ToString());
                            B_GroupProduction bp=bgpb.Query(" and id=" + pid + "");
                            if (bp != null)
                            {
                                br.cdate = DateTime.Now.ToString();
                                br.crequest = o[6].ToString();
                                br.deep = bp.deep;
                                br.gnum = bp.gnum;
                                br.height = bp.height;
                                br.icode = bp.icode;
                                br.iname = bp.iname;
                                br.maker = iv.u.ename;
                                br.mname = bp.mname;
                                br.osid = bp.sid;
                                br.pnum = bp.inum;
                                br.psid = bp.psid;
                                br.remark = bp.ps;
                                br.sid = sid;
                                br.width = bp.width;
                                lr.Add(br);
                            }
                        }
                    }
                }
                if (lr.Count > 0)
                {
                    if (bgpcrb.AddList(lr, sid) > 0)
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