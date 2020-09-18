using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.AssortManage
{
    public partial class Assorts : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  设置配套产品
        [WebMethod(true)]
        public static string SetAssort(string pcode, string ptpcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                
                srb.DelAssort(pcode);
                string[] arr = ptpcode.Split(';');
                try
                {
                    foreach (string pv in arr)
                    {
                        ArrayList ls = new ArrayList();
                        List<Sys_InventoryCategory> lsic = sicb.QueryList(" and iccode like '" + pv + "%' order by id asc");
                        if (lsic != null)
                        {
                            foreach (Sys_InventoryCategory sic in lsic)
                            {
                                ls.Add(sic.iccode);
                            }
                        }
                        srb.SetAssort(pcode,pv, ls);
                    }
                    r = "S";
                }
                catch 
                {
                    r = "F";
                    srb.DelAssort(pcode);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  重置配套产品
        [WebMethod(true)]
        public static string ReSetAssort(string pcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.ReSetAssort(pcode) > 0)
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
        #region///  获取配套产品
        [WebMethod(true)]
        public static string GetAssort(string pcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetAssort(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region///  获取关联产品
        [WebMethod(true)]
        public static string GetRefInv(string invcode, string mname)
        {
            string r = "";
            string rcode = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                 rcode= srb.GetAssort(invcode.Substring(0,invcode.Length-3));
                 if (rcode != "")
                 {
                     string[] rv = rcode.Split(';');
                     Sys_InventoryDetail si = new Sys_InventoryDetail();
                     Sys_InventoryDetail sid = sidb.Query(" and  icode like '" + rv[0] + "%' and mname='" + mname + "'");
                     if (sid == null)
                     {
                         si.icname = "";
                         si.iccode = "";
                     }
                     else
                     {
                         si = sid;
                     }
                     r = js.Serialize(si);
                 }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion


        #region///  设置玻璃产品
        [WebMethod(true)]
        public static string SetMsBl(string mcode, string blcode,string bcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] barr = bcode.Split(';');
                if (srb.SetMsBl(mcode, blcode, barr) > 0)
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
        #region///  重置玻璃产品
        [WebMethod(true)]
        public static string ReSetMsBl(string mcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.ReSetMsBl(mcode) > 0)
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
        #region///  获取玻璃产品
        [WebMethod(true)]
        public static string GetMsBl(string mcode,string blcode)
        {
            string r = "";
            Sys_AssortBll srb = new Sys_AssortBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetMsBl(mcode,blcode);
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