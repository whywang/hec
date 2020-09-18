using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.Data;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;

namespace LionWap.UIServer
{
    public partial class FixOrderList : System.Web.UI.Page
    {
        private static B_FixOrderBll bfb = new B_FixOrderBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static ArrayList QueryFixOrderList( string curpage,  string emcode, string pagesize, string tabcode)
        {
            StringBuilder where = new StringBuilder();
            DataTable lsr = new DataTable();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                
                            }
                            r.Add(al);
                        }
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        
    }
}