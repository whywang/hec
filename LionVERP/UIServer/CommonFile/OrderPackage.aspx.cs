using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvBll.BusiCommon;
using LionvBll.SysInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class OrderPackage : System.Web.UI.Page
    {
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static B_PackageBll bpb = new B_PackageBll();
        private static B_PackageCodeBll bpcb = new B_PackageCodeBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryPackageList(string emcode, string sid, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                where.Append (" and sid='"+sid+"' ");
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bpb.QueryVList( sfield, where.ToString(), " order by bnum asc" );
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();

                            al.Add(i);
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "bzid")
                                {
                                    al.Add("B"+dr[column].ToString().PadLeft(8,'0'));
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }
                            r.Add(al);
                            i++;
                        }
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
        #region// 获取订单未入库包装明细
        [WebMethod(true)]
        public static ArrayList QueryPackageUnInHouseList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_PackageCode> lbp= bpcb.QueryList(" and sid='"+sid+"' and id not in (select pid  from B_InhousePackage where isid in (select isid from B_InHouseOrder where sid='" + sid + "'))");
                if (lbp != null)
                {
                    foreach (B_PackageCode bp in lbp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add("B"+bp.id.ToString().PadLeft(7,'0'));
                        al.Add(bp.bnum);
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