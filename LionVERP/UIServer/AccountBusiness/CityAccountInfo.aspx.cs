using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.Account;
using System.Web.Services;
using System.Collections;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Text;
using LionvCommonBll;
using LionvModel.Account;

namespace LionVERP.UIServer.AccountBusiness
{
    public partial class CityAccountInfo : System.Web.UI.Page
    {
        private static B_ExchangeRecordBll barb = new B_ExchangeRecordBll();
        private static Sbk_AccountBll sab = new Sbk_AccountBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表包括电话
        [WebMethod(true)]
        public static ArrayList QueryPayOrderList(string account,string bdate, string edate)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != null)
                {
                    where.AppendFormat(" and cdate>='{0}'", CommonBll.GetBdate(bdate));
                }
                else
                {
                    where.AppendFormat(" and cdate>='{0}'", CommonBll.GetBdate());
                }
                if (edate != null)
                {
                    where.AppendFormat(" and cdate<'{0}'", CommonBll.GetEdate(edate));
                }
                else
                {
                    where.AppendFormat(" and cdate<'{0}'", CommonBll.GetEdate());
                }
                if (account != "")
                {
                    where.AppendFormat(" and sacode='{0}'", account);
                }
                where.AppendFormat(" order by cdate desc");
                List<B_ExchangeRecord> blr = barb.QueryList(where.ToString());
                if (blr != null)
                {
                    foreach (B_ExchangeRecord ba in blr)
                    {
                        ArrayList al = new ArrayList();
                        Sbk_Account sa=sab.Query(" and acode='" + ba.sacode + "'");
                        al.Add(ba.sacode);
                        al.Add(sa!=null?sa.aname:"");
                        al.Add(ba.oscode);
                        al.Add(ba.otype );
                        al.Add(ba.emoney);
                        al.Add(ba.umoney);
                        al.Add(ba.cdate);
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