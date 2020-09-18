using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.PriceManage
{
    public partial class Prices : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化价格类型
        [WebMethod(true)]
        public static string InitPriceType(string ptcode)
        {
            string r = "";
            Sys_PriceType sr = new Sys_PriceType();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PriceType csr = srb.Query(" and ptcode='" + ptcode + "'");
                if (csr != null)
                {
                    r = js.Serialize(csr);
                }
                else
                {
                    sr.ptname = "";
                    sr.ptcode = srb.CreateCode().ToString().PadLeft(4, '0');
                    sr.id = 0;
                    r = js.Serialize(sr);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存价格类型
        [WebMethod(true)]
        public static string SavePriceType(string lcode, string lid, string lms, string lname, string ltype)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PriceType sr = new Sys_PriceType();
                if (iv.u.rcode == "xtgl")
                {
                    sr.dcode = "";
                }
                else
                {
                    sr.dcode = iv.u.dcode.Substring(0, 8);
                }
                sr.ptname = lname;
                sr.ptcode = lcode;
                sr.ptype = ltype;
                sr.pms = lms;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (lid == "0")
                {
                    if (!srb.Exists(" and ptname='" + lname + "'"))
                    {
                        if (srb.Add(sr) > 0)
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
                else
                {
                    if (!srb.Exists(" and ptname='" + lname + "' and ptcode<>'" + lcode + "'"))
                    {
                        if (srb.Update(sr))
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
        #region///  类型价格类型列表
        [WebMethod(true)]
        public static ArrayList QueryList(string ptype)
        {
            ArrayList r = new ArrayList();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            List<Sys_PriceType> lsf = new List<Sys_PriceType>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsf = srb.QueryList(" and ptype='" + ptype + "' "+where+"");
                if (lsf != null)
                {
                    foreach (Sys_PriceType s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ptcode);
                        al.Add(s.ptname);
                        al.Add(s.ptype);
                        al.Add(s.pms);
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
        #region///  删除价格类型
        [WebMethod(true)]
        public static string DelPriceType(string ptcode)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Delete(" and ptcode='" + ptcode + "'"))
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
        #region/// 全部价格类型列表
        [WebMethod(true)]
        public static ArrayList QueryListAll()
        {
            ArrayList r = new ArrayList();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            List<Sys_PriceType> lsf = new List<Sys_PriceType>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsf = srb.QueryList( where);
                if (lsf != null)
                {
                    foreach (Sys_PriceType s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ptcode);
                        al.Add(s.ptname);
                        al.Add(s.ptype);
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

        #region///  价格设置
        [WebMethod(true)]
        public static string SetPrice(string plb, string plist, string plx, string price, string tcprice,string pprice)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] parr = plist.Split(';');
                if (srb.SetPrice(plb, parr, plx, Convert.ToDecimal(price), Convert.ToDecimal(tcprice), Convert.ToDecimal(pprice), iv.u.ename) > 0)
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
        #region///产品列表
        [WebMethod(true)]
        public static ArrayList QueryListInventory(string mcode,string plb,string plx)
        {
            ArrayList r = new ArrayList();
            Sys_InventoryDetailBll sub = new Sys_InventoryDetailBll();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            List<Sys_InventoryDetail> lsr = new List<Sys_InventoryDetail>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = sub.QueryList(" and iccode='" + mcode + "'  ");
                if (lsr != null)
                {
                    foreach (Sys_InventoryDetail s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        decimal[] dprice = new decimal[3];
                        dprice = srb.GetPrice(plb, s.icode, plx);
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add(s.mname);
                        al.Add(s.iunit);
                        if (dprice != null)
                        {
                            al.Add(dprice[0]);
                            al.Add(dprice[1]);
                            al.Add(dprice[2]);
                        }
                        else
                        {
                            al.Add(0);
                            al.Add(0);
                            al.Add(0);
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

        //----------------------------------Cust----------------------------------
        #region///  保存价格类型
        [WebMethod(true)]
        public static string CustSaveComputeMethod(string ptcode, string ptid, string ptlx, string ptname, string ptms)
        {
            string r = "";
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PriceType sr = new Sys_PriceType();
                sr.ptname = ptname;
                sr.ptcode = ptcode;
                sr.ptype = ptlx;
                sr.pms = ptms;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                sr.dcode = iv.u.dcode.Substring(0, 8);
                if (ptid == "0")
                {
                    if (!srb.Exists(" and ptname='" + ptname + "'"))
                    {
                        if (srb.Add(sr) > 0)
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
                else
                {
                    if (!srb.Exists(" and ptname='" + ptname + "' and ptcode<>'" + ptcode + "'"))
                    {
                        if (srb.Update(sr))
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
        #region///  类型价格类型列表
        [WebMethod(true)]
        public static ArrayList CustQueryList(string ptype)
        {
            ArrayList r = new ArrayList();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            List<Sys_PriceType> lsf = new List<Sys_PriceType>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and ptype='" + ptype + "' and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_PriceType s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ptcode);
                        al.Add(s.ptname);
                        al.Add(s.pms);
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
        #region/// 全部价格类型列表
        [WebMethod(true)]
        public static ArrayList CustQueryListAll()
        {
            ArrayList r = new ArrayList();
            Sys_PriceTypeBll srb = new Sys_PriceTypeBll();
            List<Sys_PriceType> lsf = new List<Sys_PriceType>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_PriceType s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ptcode);
                        al.Add(s.ptname);
                        al.Add(s.ptype);
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