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
using LionvBll.StatisticsInfo;
using System.Data;

namespace LionVERP.UIServer.CommonFile
{
    public partial class ProductionPackage : System.Web.UI.Page
    {
        private static B_PackageBll bpb = new B_PackageBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static B_PartQualityItemsBll bpqib = new B_PartQualityItemsBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取包装单产品
        [WebMethod(true)]
        public static ArrayList QueryPackageProductionList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable bpqo = tsb.QueryList("View_GPitems" ,"*","and sid='" + sid + "' and psid in(select psid from B_PartQualityItems where sid='" + sid + "') and psid not in (select bsid from B_Package where sid='" + sid + "' and bz=1) ","order by gnum,id ");
                if (bpqo != null)
                {
                    foreach (DataRow dr in bpqo.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr["id"].ToString());
                        al.Add(dr["bnum"].ToString());
                        al.Add(dr["gnum"].ToString());
                        al.Add(dr["pname"].ToString());
                        al.Add(dr["mname"].ToString());
                        al.Add(dr["height"].ToString() + "*" + dr["width"].ToString() + "*" + dr["deep"].ToString());
                        al.Add(dr["pnum"].ToString());
                        for (int i = 0; i < Convert.ToInt32(dr["pnum"].ToString()); i++)
                        {
                            al.Add(1);
                            r.Add(al);
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
        #region// 获取包装单产品
        [WebMethod(true)]
        public static string SavePackageProduction(string sid,ArrayList blist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_Package> lbp = new List<B_Package>();
                DataTable dt= bpib.QueryTable(" and sid='"+sid+"'");
                Hashtable garr = new Hashtable();
                ArrayList gsid = new ArrayList();
                foreach (object[] obj in blist)
                {
                    DataRow []dr= dt.Select(" id="+obj[0].ToString()+"");
                    B_Package bp = new B_Package();
                    string bnum = obj[1].ToString();
                    bp.bnum = Convert.ToInt32(bnum == "" ? "0" : bnum);
                    bp.bsid = dr[0]["psid"].ToString();
                    bp.btype = dr[0]["ptype"].ToString();
                    bp.bz = 1;
                    bp.bzid = dr[0]["id"].ToString();
                    bp.cdate = DateTime.Now.ToString();
                    bp.csck = 0;
                    bp.csrk = 0;
                    bp.deep = Convert.ToInt32(dr[0]["deep"].ToString());
                    bp.height = Convert.ToInt32(dr[0]["height"].ToString());
                    bp.maker = iv.u.ename;
                    bp.pname = dr[0]["pname"].ToString();
                    bp.pcode = dr[0]["pcode"].ToString();
                    bp.pnum = 1;
                    bp.sid = sid;
                    bp.sortnum = 0;
                    bp.width = Convert.ToInt32(dr[0]["width"].ToString());
                    bp.zbck = 0;
                    bp.zbrk = 0;
                    if (!garr.Contains(bp.bsid))
                    {
                        garr.Add(bp.bsid, bp.bsid);
                    }
                    lbp.Add(bp);
                }
                if (lbp.Count > 0)
                {
                    foreach (DictionaryEntry de in garr)
                    {
                        gsid.Add(de.Value);
                    }
                    if (bpb.SavePackageList(gsid, lbp))
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 获取包装单产品
        [WebMethod(true)]
        public static ArrayList QueryPackageList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Package> bl = bpb.QueryList("and sid='" + sid + "' and bnum>0 order by bnum ,id");
                if (bl != null)
                {
                    int xh = 1;
                    foreach (B_Package dr in bl)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(xh);
                        al.Add(dr.bnum);
                        al.Add(dr.pname);
                        al.Add(dr.height.ToString() );
                        al.Add(dr.width.ToString());
                        al.Add(dr.deep.ToString());
                        al.Add(dr.pnum.ToString());
                        al.Add("<a>打印标签</a>");
                        r.Add(al);
                        xh++;
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