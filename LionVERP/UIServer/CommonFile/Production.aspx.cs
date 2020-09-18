using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.BusiOrderInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Data;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class Production : System.Web.UI.Page
    {
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static Sys_SizeFormatPartBll ssfbb = new Sys_SizeFormatPartBll();
        private static B_GroupProductionChangeRequstBll bgpcrb = new B_GroupProductionChangeRequstBll();
        private static B_WjPreParePartGroupProductionBll bwppppb = new B_WjPreParePartGroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取产品编辑部件
        [WebMethod(true)]
        public static ArrayList QueryItemProduction(string sid, string gnum)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_ProductionItem> lbpi = bpib.QueryList(" and psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ") order by id");
                if (lbpi != null)
                {
                    foreach (B_ProductionItem bp in lbpi)
                    {
                        Sys_SizeFormatPart ssfp = ssfbb.Query(" and bjattr='" + bp.e_ptype + "' and bjattrex='" + bp.e_ptypeex + "'");
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.pname);
                        al.Add(bp.pcode);
                        al.Add(bp.height);
                        al.Add(bp.width);
                        al.Add(bp.deep);
                        al.Add(bp.pnum);
                        if(ssfp!=null)
                        {
                           al.Add(ssfp.bjname);
                        }else
                        {
                            al.Add("");
                        }
                        al.Add(bp.ptype);
                        al.Add(bp.e_ptype);
                        al.Add(bp.e_ptypeex);
                        al.Add(bp.addattr == "" ? "o" : bp.addattr);
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

        #region//保存产品部件
        [WebMethod(true)]
        public static string SaveItemProduction(string sid, string gnum, ArrayList itemlist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_ProductionItem> uplbi = new List<B_ProductionItem>();
                List<B_ProductionItem> inlbi = new List<B_ProductionItem>();
                foreach (object[] o in itemlist)
                {
                    object[] b = o;
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.pname = b[1].ToString();
                    bpi.pcode = b[2].ToString();
                    bpi.height = Convert.ToInt32(b[3].ToString());
                    bpi.width = Convert.ToInt32(b[4].ToString());
                    bpi.deep = Convert.ToInt32(b[5].ToString());
                    bpi.pnum= Convert.ToInt32(b[6].ToString());
                    bpi.ptype=b[7].ToString();
                    bpi.e_ptype = b[9].ToString();
                    bpi.e_ptypeex = b[10].ToString();
                    bpi.addattr=b[11].ToString();
                    if(b[0].ToString()!="")
                    {
                        bpi.id = Convert.ToInt32(b[0].ToString());
                        uplbi.Add(bpi);
                    }
                    else
                    {
                        inlbi.Add(bpi);
                    }
                }
               if( bpib.InsertAddUpdateItems(sid,Convert.ToInt32(gnum), uplbi, inlbi)>0)
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

        #region//售后保存产品部件
        [WebMethod(true)]
        public static string AfterSaveItemProduction(ArrayList itemlist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_ProductionItem> ebi = new List<B_ProductionItem>();
                List<B_ProductionItem> dbi = new List<B_ProductionItem>();
                Hashtable dht = new Hashtable();
                Hashtable eht = new Hashtable();
                ArrayList darr = new ArrayList();
                foreach (object[] o in itemlist)
                {
                    object[] b = o;
                    B_ProductionItem bpi = bpib.Query(" and id=" + Convert.ToInt32(b[0].ToString()) + "");
                    if (bpi != null)
                    {
                       int pnum= Convert.ToInt32(b[5].ToString());
                       if (pnum > 0)
                       {
                           if (!eht.Contains(bpi.psid))
                           {
                               eht.Add(bpi.psid, bpi.psid);
                           }
                           bpi.height = Convert.ToInt32(b[2].ToString());
                           bpi.width = Convert.ToInt32(b[3].ToString());
                           bpi.deep = Convert.ToInt32(b[4].ToString());
                           bpi.pnum = Convert.ToInt32(b[5].ToString());
                           ebi.Add(bpi);
                       }
                       else
                       {
                           if (!dht.Contains(bpi.psid))
                           {
                               dht.Add(bpi.psid, bpi.psid);
                           }
                           dbi.Add(bpi);
                       }
                    }
                    foreach(string key in dht.Keys)
                    {
                        if (!eht.Contains(key))
                        {
                            darr.Add(key);
                        }
                    }
                }
                if (bpib.AfterUpdateItems(ebi, dbi, darr) > 0)
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                dht.Clear();
                eht.Clear();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region//获取产品检验产品
        [WebMethod(true)]
        public static ArrayList QueryQualityProduction(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_GroupProduction> lbpi = bgpb.QueryList(" and sid='" + sid + "' and substring(icode,9,3)<>'004' and psid not in (select psid from  B_PartQualityItems where qsid in(select qsid from B_PartQualityOrder where sid='"+sid+"' and qstate=1) ) order by gnum");
                if (lbpi != null)
                {
                    int xh = 1;
                    foreach (B_GroupProduction bp in lbpi)
                    {
                        ArrayList al = new ArrayList();
                        if (bp.ptype == "ms")
                        {
                           List<B_ProductionItem> li= bpib.QueryList(" and psid='" + bp.psid + "'");
                           if (li != null)
                           {
                               foreach (B_ProductionItem bi in li)
                               {
                                   al.Add(bp.id+"-"+bi.e_ptype);
                                   al.Add(xh);
                                   al.Add(bp.iname);
                                   al.Add(bi.height);
                                   al.Add(bi.width);
                                   al.Add(bi.deep);
                                   al.Add(bi.pnum);
                                   al.Add(bp.mname);
                                   al.Add(bp.ps);
                                   r.Add(al);
                                   xh++;
                               }
                           }
                        }
                        else
                        {
                            al.Add(bp.id);
                            al.Add(xh);
                            al.Add(bp.iname);
                            al.Add(bp.height);
                            al.Add(bp.width);
                            al.Add(bp.deep);
                            al.Add(bp.inum);
                            al.Add(bp.mname);
                            al.Add(bp.ps);
                            r.Add(al);
                            xh++;
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

        #region//获取组产品信息
        [WebMethod(true)]
        public static ArrayList QueryGroupProduction(string sid,string osid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_GroupProduction> lbpi = bgpb.QueryList(" and sid='"+osid+"' order by gnum");
                if (lbpi != null)
                {
                    foreach (B_GroupProduction bp in lbpi)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bp.id);
                        al.Add(bp.gnum);
                        al.Add(bp.iname);
                        al.Add(bp.mname);
                        al.Add(bp.height.ToString() + "*" + bp.width.ToString() + "*" + bp.deep.ToString());
                        al.Add(bp.ps);
                        B_GroupProductionChangeRequst br=bgpcrb.Query(" and psid='" + bp.psid + "' and sid='"+sid+"'");
                        if (br != null)
                        {
                            al.Add(br.crequest);
                        }
                        else
                        {
                            al.Add("");
                        }
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

        #region//获取组可编辑产品信息
        [WebMethod(true)]
        public static ArrayList QueryGroupEditProductionNum(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                Hashtable hs = new Hashtable();
                List<B_GroupProductionChangeRequst> lr = bgpcrb.QueryList(" and sid='" + sid + "'");
                if (lr != null)
                {
                    foreach (B_GroupProductionChangeRequst br in lr)
                    {
                        if (!hs.Contains(br.gnum))
                        {
                            ArrayList al = new ArrayList();
                            al.Add(br.gnum);
                            hs.Add(br.gnum, br.gnum);
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

        #region//获取五金产品列表
        [WebMethod(true)]
        public static ArrayList QueryWjProduction(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable dt = bgpb.QueryWjTable(sid);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ArrayList al = new ArrayList();
                        int znum = Convert.ToInt32(dr["inum"].ToString());
                        int pnum = bwppppb.QueryWjNum(sid, dr["icode"].ToString());
                        al.Add(dr["icode"].ToString());
                        al.Add(dr["iname"].ToString());
                        al.Add(dr["uname"].ToString());
                        al.Add(znum);
                        al.Add(pnum);
                        al.Add(znum-pnum);
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
        #region//获取五金产品列表
        [WebMethod(true)]
        public static ArrayList QueryBlProduction(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_ProductionItem> dt = bpib.QueryList(" and sid='"+sid+"' and substring(pcode,9,3)='005'");
                if (dt != null)
                {
                    foreach (B_ProductionItem dr in dt)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr.id);
                        al.Add(dr.pname);
                        al.Add(dr.height);
                        al.Add(dr.width);
                        al.Add(dr.deep);
                        al.Add(dr.pnum);
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