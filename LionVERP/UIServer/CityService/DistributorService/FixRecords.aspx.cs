using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionVERP.UIServer.CityService.DistributorService
{
    public partial class FixRecords : System.Web.UI.Page
    {
        private static B_CustomeFixBll bohrb = new B_CustomeFixBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 保存入库记录信息
        [WebMethod(true)]
        public static string SaveYyRecord(string sid, string ybz, string ydate, string ysf)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_yyFixOrderRecord bihr = new B_yyFixOrderRecord();
                bihr.fixer = ysf;
                bihr.ydate = ydate;
                bihr.maker = iv.u.ename;
                bihr.ps = ybz;
                bihr.cdate = DateTime.Now.ToString();
                bihr.sid = sid;
                if (bohrb.Add(bihr) > 0)
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
        #region// 入库记录信息
        [WebMethod(true)]
        public static ArrayList QueryYyRecord(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_yyFixOrderRecord> lb = bohrb.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    foreach (B_yyFixOrderRecord p in lb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(p.id);
                        al.Add(p.ydate);
                        al.Add(p.fixer);
                        al.Add(p.ps);
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