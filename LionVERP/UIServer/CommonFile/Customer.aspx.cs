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

namespace LionVERP.UIServer.CommonFile
{
    public partial class Customer : System.Web.UI.Page
    {
        private static B_CustomerBll bcb = new B_CustomerBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//模糊获取部门和角色人员
        [WebMethod(true)]
        public static ArrayList QueryList(string customer)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Customer> ls = bcb.QueryList(" and customer like '%" + customer + "%' and bdcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (ls != null)
                {
                    int i = 0;
                    foreach (B_Customer s in ls)
                    {
                        if (i > 49)
                        {
                            break;
                        }
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.customer);
                        al.Add(s.telephone);
                        al.Add(s.address);
                        r.Add(al);
                        i++;
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