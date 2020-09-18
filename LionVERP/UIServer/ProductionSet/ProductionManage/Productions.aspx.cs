using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.ProdtionManage
{
    public partial class Productions : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///////////产品类管理
        #region///初始化产品类
        [WebMethod(true)]
        public static string InitInventoryCategory(string iccode, string icode)
        {
            string r = "";
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            Sys_InventoryCategory sic = new Sys_InventoryCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_InventoryCategory smp = sicb.Query(" and iccode='" + iccode + "'");
                if (icode == "")
                {

                    if (smp != null)
                    {
                        sic.icpcode = smp.iccode;
                        sic.icpname = smp.icname;
                    }
                    else
                    {
                        sic.icpcode  = "";
                        sic.icpname = "";
                    }
                    sic.iccode = iccode + sicb.CreateCode(iccode).ToString().PadLeft(3, '0');
                    sic.icname = "";
                    sic.id = 0;
                }
                else
                {
                    sic = sicb.Query(" and iccode='" + icode + "'"); ;
                }
                r = js.Serialize(sic);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存产品类
        [WebMethod(true)]
        public static string SaveInventoryCategory(string drange,string lcode,string lid, string lname,  string lpcode, string lpname)
        {
            string r = "";
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            Sys_InventoryCategory sic = new Sys_InventoryCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sic.iccode = lcode;
                sic.icpcode = lpcode;
                sic.icname = lname;
                sic.icpname = lpname;
                sic.maker = iv.u.ename;
                sic.cdate = DateTime.Now.ToString();
                sic.icsend = true;
                sic.icstate = true;
                sic.icms = "";
                sic.drange = drange;
                if (lid == "0")
                {
                    if (sicb.Add(sic) > 0)
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
                    if (sicb.Update(sic))
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///批量保存产品类
        [WebMethod(true)]
        public static string BatchSaveInventoryCategory(string pname, string pcode)
        {
            string r = "";
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] parr = pcode.Split(';');
                for (int i = 0; i < parr.Length; i++)
                {
                    Sys_InventoryCategory sic = new Sys_InventoryCategory();
                    Sys_InventoryCategory p = sicb.Query("  and iccode='" + parr[i] + "' ");
                    sic.iccode = parr[i] + sicb.CreateCode(parr[i]).ToString().PadLeft(3, '0');
                    sic.icpcode = parr[i];
                    sic.icname = pname;
                    sic.icpname =p!=null? p.icname:"";
                    sic.maker = iv.u.ename;
                    sic.cdate = DateTime.Now.ToString();
                    sic.icsend = true;
                    sic.icstate = true;
                    sic.icms = "";
                    sic.drange = p!=null?p.drange:"";
                    if (sicb.Add(sic) > 0)
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
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///删除产品类
        [WebMethod(true)]
        public static string DelInventoryCategory(string iccode)
        {
            string r = "";
            Sys_InventoryCategoryBll sdb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(iccode))
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
        #region///产品类列表
        [WebMethod(true)]
        public static ArrayList QueryListInventoryCategory(string ipcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where = " and icpcode='" + ipcode + "' order by isort";
                }
                else
                {
                    if (ipcode == "")
                    {
                        where = " and icpcode='" + iv.u.dcode.Substring(0, 8) + "' order by isort";
                    }
                    else
                    {
                        where = " and icpcode='" + ipcode + "' order by isort";
                    }
                }
                lsr = sub.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_InventoryCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
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
        #region///Range产品类列表
        [WebMethod(true)]
        public static ArrayList QueryListInventoryCategoryRange(string ipcode, string drange)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where = " and icpcode='" + ipcode + "' and drange='" + drange + "' order by isort";
                }
                else
                {
                    if (ipcode == "")
                    {
                        where = " and icpcode='" + iv.u.dcode.Substring(0, 8) + "' and drange='" + drange + "' order by isort";
                    }
                    else
                    {
                        where = " and icpcode='" + ipcode + "' and drange='" + drange + "' order by isort";
                    }
                }
                lsr = sub.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_InventoryCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
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
        #region///材质产品类列表
        [WebMethod(true)]
        public static ArrayList CzQueryListInventoryCategory(string ipcode, string mname)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> plsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lr = new List<Sys_InventoryCategory>();
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + ipcode + "' order by isort");
                plsr = sub.QueryList(" and icpcode='" + ipcode + "'  order by isort");
                if (plsr != null)
                {
                    lr = plsr;
                }
                else
                {
                    lr = lsr;
                }
                if (lr != null)
                {
                    foreach (Sys_InventoryCategory s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
                        if (sidb.Exists(" and icode like '" + s.iccode + "%' and mname='"+mname+"'"))
                        {
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
        #region///门扇玻璃类列表
        [WebMethod(true)]
        public static ArrayList QueryListMsInventoryCategory(string mscode,string ipcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            Sys_AssortBll sab = new Sys_AssortBll();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (sab.ExistMsBl(mscode, ipcode+"___"))
                {
                    lsr = sub.QueryList(" and icpcode='" + ipcode + "' and iccode in ( select blcode from Sys_RMsBl where mcode='" + mscode.Substring(0,mscode.Length-3) + "' and blcode like '" + ipcode + "___') order by isort");
                    if (lsr != null)
                    {
                        foreach (Sys_InventoryCategory s in lsr)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(s.iccode);
                            al.Add(s.icname);
                            al.Add(s.icstate);
                            r.Add(al);
                        }
                    }
                }
                else
                {
                    lsr = sub.QueryList(" and icpcode='" + ipcode + "' order by isort");
                    if (lsr != null)
                    {
                        foreach (Sys_InventoryCategory s in lsr)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(s.iccode);
                            al.Add(s.icname);
                            al.Add(s.icstate);
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
        #region///获取查询类别最末级产品类别
        [WebMethod(true)]
        public static ArrayList QueryListLastCategory(string ipcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (iv.u.dcode == "")
                {
                    lsr = sicb.QueryList(" and icstate='true' and iccode like '00010001"+ ipcode + "%'");
                }
                else
                {
                    lsr = sicb.QueryList(" and icstate='true' and iccode like '" + iv.u.dcode.Substring(0, 8) + ipcode + "%'");
                }
                if (lsr != null)
                {
                    foreach (Sys_InventoryCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
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
        #endregion
        #region///产品管理
        #region///初始化产品
        [WebMethod(true)]
        public static string InitInventory(string iccode, string icode)
        {
            string r = "";
            Sys_InventoryDetail sid = new Sys_InventoryDetail();
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            Sys_InventoryCategory sic = new Sys_InventoryCategory();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sic = sicb.Query(" and iccode='" + iccode + "'");
                if (icode == "")
                {

                    if (sic != null)
                    {
                        sid.iccode = sic.iccode;
                        sid.icname = sic.icname;
                        sid.iname = sic.icname;
                    }
                    else
                    {
                        sid.iccode = "";
                        sid.icname = "";
                        sid.iname = "";
                    }
                    sid.icode = iccode + sidb.CreateCode(iccode).ToString().PadLeft(3, '0');
                    sid.istate = true;
                    sid.id = 0;
                }
                else
                {
                    sid = sidb.Query(" and icode='" + icode + "'");
                }
                r = js.Serialize(sid);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存产品
        [WebMethod(true)]
        public static string SaveInventory(string pbz, string pcprice, string pcode, string pcz, string pcztype, string pgprice, string pid, string plcode, string plname, string pname,string psize,  string psprice, string pstate, string ptcprice,string ptype, string punit)
        {
            string r = "";
            string dcode = "00010001";
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            Sys_InventoryDetail sid = new Sys_InventoryDetail();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sid.icname = plname;
                sid.iccode = plcode;
                sid.iname = pname;
                sid.icode = pcode;
                sid.mname = pcz;
                sid.iunit = punit;
                sid.maker = iv.u.ename;
                sid.isaleprice = Convert.ToDecimal(psprice);
                sid.isupplyprice=Convert.ToDecimal(pgprice);
                sid.ipurchaseprice=Convert.ToDecimal(pcprice);
                sid.iimage="";
                sid.istate= pstate == "1" ? true : false;
                sid.mcode="";
                sid.idef1=pbz;
                sid.idef2=true;
                sid.idef3=0;
                sid.psize = psize;
                sid.cdate = DateTime.Now.ToString();
                sid.tcprice =Convert.ToDecimal( ptcprice);
                sid.ptype = ptype;
                if (pid == "0")
                {
                    if (pcztype == "a")
                    {
                        if (iv.u.dcode != "")
                        {
                            dcode = iv.u.dcode;
                        }
                        lsr = sub.QueryList(" and mstate='true' and mccode in (select mccode from Sys_MaterialCategory where dcode='" + dcode.Substring(0, 8) + "')");
                        if (lsr != null)
                        {
                            foreach (Sys_Material s in lsr)
                            {
                                sid.mname = s.mname;
                                sid.icode = plcode + sidb.CreateCode(plcode).ToString().PadLeft(3, '0');
                                if (!sidb.Exists(" and iname='" + pname + "' and mname='" + s.mname + "'"))
                                {
                                    if (sidb.Add(sid) > 0)
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
                                    r = "T";
                                }
                            
                            }
                        }
                    }
                    if (pcztype == "b")
                    {
                        string[] czarr = pcz.Split(';');
                        for (int i = 0; i < czarr.Length; i++)
                        {
                            sid.mname = czarr[i];
                            sid.icode = plcode + sidb.CreateCode(plcode).ToString().PadLeft(3, '0');
                            if (!sidb.Exists(" and iname='" + pname + "' and mname='" + czarr[i] + "'"))
                            {
                                if (sidb.Add(sid) > 0)
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
                                r = "T";
                            }
                        }
                        
                    }
                    
                }
                else
                {
                    if (!sidb.Exists(" and iname='" + pname + "' and mname='" + pcz + "' and icode<>'" + pcode + "'"))
                    {
                        if (sidb.Update(sid))
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
                        r = "T";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///批量保存产品
        [WebMethod(true)]
        public static ArrayList BatchSaveInventory(string iccode, string plmname, string plsize, string pltype, string plunit)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            Sys_MaterialBll sub = new Sys_MaterialBll();
            List<Sys_Material> lsr = new List<Sys_Material>();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<Sys_InventoryCategory> als = new List<Sys_InventoryCategory>();
                List<Sys_InventoryDetail> lsid = new List<Sys_InventoryDetail>();
                string[] iarr = iccode.Split(';');
                if (iarr.Length > 0)
                {
                    foreach (string icv in iarr)
                    {
                        List<Sys_InventoryCategory> lic = sicb.QueryList(" and iccode like '" + icv + "%' and icstate='true'");
                        if (lic != null)
                        {
                            foreach (Sys_InventoryCategory sic in lic)
                            {
                                if (!als.Contains(sic))
                                {
                                    als.Add(sic);
                                }
                            }
                        }
                    }
                }
                if (als.Count > 0)
                {
                    r.Add("S");
                    foreach (Sys_InventoryCategory sic in als)
                    {
                        string[] arr = plmname.Split(';');
                        int pcnum = sidb.CreateCode(sic.iccode);
                        foreach (string cz in arr)
                        {
                            if (!sidb.Exists(" and iname='" + sic.icname + "' and mname='" + cz + "'"))
                            {
                                Sys_InventoryDetail sid = new Sys_InventoryDetail();
                                sid.icname = sic.icname;
                                sid.iccode = sic.iccode;
                                sid.iname = sic.icname;
                                sid.icode = sic.iccode + pcnum.ToString().PadLeft(3, '0');
                                sid.mname = cz;
                                sid.iunit = plunit;
                                sid.maker = iv.u.ename;
                                sid.isaleprice = 0;
                                sid.isupplyprice = 0;
                                sid.ipurchaseprice = 0;
                                sid.iimage = "";
                                sid.istate = true;
                                sid.mcode = "";
                                sid.idef1 = "";
                                sid.idef2 = true;
                                sid.idef3 = 0;
                                sid.psize = plsize;
                                sid.cdate = DateTime.Now.ToString();
                                sid.tcprice = 0;
                                sid.ptype = pltype;
                                if (sidb.Add(sid) < 0)
                                {
                                    lsid.Add(sid);
                                }
                                pcnum++;
                            }
                            else
                            {
                                Sys_InventoryDetail fsid = new Sys_InventoryDetail();
                                fsid.mname = cz;
                                fsid.iname = sic.icname;
                                lsid.Add(fsid);
                            }
                        }
                    }
                    if (lsid.Count > 0)
                    {
                        foreach (Sys_InventoryDetail sd in lsid)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(sd.iname);
                            al.Add(sd.mname);
                            r.Add(al);
                        }
                    }
                }
                else
                {
                    r.Add("F");
                }
            }
            else
            {
                r .Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region///删除产品
        [WebMethod(true)]
        public static string DelInventory(string icode)
        {
            string r = "";
            Sys_InventoryDetailBll sdb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and icode='" + icode + "'"))
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
        #region///获取产品类别产品列表
        [WebMethod(true)]
        public static ArrayList QueryListInventory(string mcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + mcode + "'");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
                        al.Add(s.iunit);
                        al.Add(s.isaleprice);
                        al.Add(s.isupplyprice);
                        al.Add(s.ipurchaseprice);
                        al.Add(s.tcprice);
                        al.Add(s.istate==true?"启用":"停用");
                        al.Add(s.psize);
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
        #region///获取类别及子类产品列表
        [WebMethod(true)]
        public static ArrayList QueryListCateProduce(string mcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode like'" + mcode + "%'");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
                        al.Add(s.iunit);
                        al.Add(s.isaleprice);
                        al.Add(s.isupplyprice);
                        al.Add(s.ipurchaseprice);
                        al.Add(s.tcprice);
                        al.Add(s.istate == true ? "启用" : "停用");
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
        #region///获取在售产品列表
        [WebMethod(true)]
        public static ArrayList QueryListItem()
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and istate='true'");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
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
        #region///材质产品列表
        [WebMethod(true)]
        public static ArrayList CzQueryProductionList(string mcode, string mname)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and istate='true' and iccode='" + mcode + "' and mname='" + mname + "'");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
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
        #region///价格设置
        [WebMethod(true)]
        public static string SetPrice(string cgp, string ghp, string pcodelist, string plx,string tcp, string xsp)
        {
            string r = "";
            Sys_InventoryDetailBll sdb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string [] clist=pcodelist.Split(';');
                if( sdb.SetPrice(clist,plx,xsp,ghp,cgp,tcp)>0)
                {
                    r="S";
                }
                else
                {
                    r="F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///状态设置
        [WebMethod(true)]
        public static string SetState(string plcode, string t )
        {
            string r = "";
            Sys_InventoryDetailBll sdb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] clist = plcode.Split(';');
                if (sdb.SetState(clist, t) > 0)
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
        //#region///获取门扇可选玻璃
        //[WebMethod(true)]
        //public static ArrayList MsCzQueryProductionList(string mscode, string mcode)
        //{
        //    ArrayList r = new ArrayList();
        //    Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
        //    List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
        //    Sys_AssortBll sab = new Sys_AssortBll();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r.Add(iv.badstr);
        //        if (sab.ExistMsBl(mscode, mcode))
        //        {
        //            lsr = sub.QueryList(" and istate='true' and iccode='" + mcode + "' and  icode in ( select bcode from Sys_RMsBl where mcode='" + mscode.Substring(0, mscode.Length - 3) + "' and blcode like '" + mcode + "')");
        //            if (lsr != null)
        //            {
        //                foreach (Sys_InventoryDetail s in lsr)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.Add(s.icode);
        //                    al.Add(s.iname);
        //                    al.Add(s.mname);
        //                    r.Add(al);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            lsr = sub.QueryList(" and istate='true' and iccode='" + mcode + "'");
        //            if (lsr != null)
        //            {
        //                foreach (Sys_InventoryDetail s in lsr)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.Add(s.icode);
        //                    al.Add(s.iname);
        //                    al.Add(s.mname);
        //                    r.Add(al);
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        r.Add(iv.badstr);
        //    }
        //    return r;
        //}
        //#endregion
        #region///查询材质产品类别获取产品类别
        [WebMethod(true)]
        public static ArrayList QuerySearingList(string icode, string mname, string pname)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(15," and istate='true' and iccode like '" + icode + "%' and mname='" + mname + "' and iname like '%" + pname + "%'");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
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
        #endregion

        ///----------------------------------Cust---------------------------------------
        #region///产品类列表
        [WebMethod(true)]
        public static ArrayList CustQueryListInventoryCategory(string ipcode,string drange)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where = " and icpcode='" + ipcode + "' and drange like '%" + drange + "%' order by isort";
                }
                else
                {
                    if (ipcode == "")
                    {
                        where = " and icpcode='" + iv.u.dcode.Substring(0, 8) + "' and drange like '%" + drange + "%' order by isort";
                    }
                    else
                    {
                        where = " and icpcode='" + ipcode + "' and drange like '%" + drange + "%' order by isort";
                    }
                }
                lsr = sub.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_InventoryCategory s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
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
        #region///材质产品类产品范围
        [WebMethod(true)]
        public static ArrayList CzQueryInveRangeCategory(string ipcode, string mname,string drange)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> plsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lr = new List<Sys_InventoryCategory>();
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + ipcode + "' and drange like '%" + drange + "%' order by isort");
                plsr = sub.QueryList(" and icpcode='" + ipcode + "'  and drange like '%" + drange + "%' order by isort");
                if (plsr != null)
                {
                    lr = plsr;
                }
                else
                {
                    lr = lsr;
                }
                if (lr != null)
                {
                    foreach (Sys_InventoryCategory s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
                        if (sidb.Exists(" and icode like '" + s.iccode + "%' and mname='" + mname + "'"))
                        {
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
        #region///获取选中产品
        [WebMethod(true)]
        public static string QueryProductions(string icode)
        {
            string r = "";
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] arr = icode.Split(';');
                foreach (string s in arr)
                {
                    Sys_InventoryCategory sic = sicb.Query(" and iccode='" + s + "'");
                    if (sic != null)
                    {
                        r = r + sic.icname + ";";
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
        //------------------------------------门扇可选门套------------------------------
        #region///产品类列表
        [WebMethod(true)]
        public static ArrayList QueryMsRefMtCate(string mscode, string pmtcode, string mname)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sib = new Sys_InventoryDetailBll();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> plsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lr = new List<Sys_InventoryCategory>();
            Sys_AssortBll sab=new Sys_AssortBll ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + pmtcode + "' order by isort");
                plsr = sub.QueryList(" and icpcode='" + pmtcode + "'  order by isort");
                if (plsr != null)
                {
                    lr = plsr;
                }
                else
                {
                    lr = lsr;
                }
                if (lr != null)
                {
                    foreach (Sys_InventoryCategory s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
                        if (sib.Exists(" and icode like '" + s.iccode + "%' and mname='" + mname + "'"))
                        {
                            if (sab.Exist(" and ptpcode like '" + s.iccode + "%' and pcode='" + mscode.Substring(0, mscode.Length - 3) + "'"))
                            {
                                r.Add(al);
                            }
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
        //------------------------------------门扇可选玻璃------------------------------
        #region///产品类列表
        [WebMethod(true)]
        public static ArrayList QueryMsRefBlCate(string mscode, string blcode)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sib = new Sys_InventoryDetailBll();
            Sys_InventoryCategoryBll sub = new Sys_InventoryCategoryBll();
            List<Sys_InventoryCategory> plsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lsr = new List<Sys_InventoryCategory>();
            List<Sys_InventoryCategory> lr = new List<Sys_InventoryCategory>();
            Sys_AssortBll sab = new Sys_AssortBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + blcode + "' order by isort");
                plsr = sub.QueryList(" and icpcode='" + blcode + "'  order by isort");
                if (plsr != null)
                {
                    lr = plsr;
                }
                else
                {
                    lr = lsr;
                }
                if (lr != null)
                {
                    foreach (Sys_InventoryCategory s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.iccode);
                        al.Add(s.icname);
                        al.Add(s.icstate);
                        if (sib.Exists(" and icode like '" + s.iccode + "%'"))
                        {
                            if (sab.ExistMsBl(" and bcode like '" + s.iccode + "%' and mcode='" + mscode.Substring(0, mscode.Length - 3) + "'"))
                            {
                                r.Add(al);
                            }
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
    }
}