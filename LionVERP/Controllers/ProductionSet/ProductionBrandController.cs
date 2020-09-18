using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionBrandController : Controller
    {
        private  Sys_BrandsBll sbb = new Sys_BrandsBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region// 
        public JsonResult InitBrand(string pbcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Brands sal = new Sys_Brands();
                if (pbcode != "")
                {
                    sal = sbb.Query(" and  pbcode='" + pbcode + "'");
                }
                else
                {
                    sal.pbcode = sbb.CreateCode().ToString().PadLeft(4, '0');
                    sal.id = 0;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region// 
        public JsonResult SaveBrand(string id ,string pccode, string pcname)
        {
            JsonData d = new JsonData();
            Sys_Brands sb = new Sys_Brands();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.pbcode = pccode;
                sb.pbname = pcname;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sbb.Add(sb) > 0)
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    if (sbb.Update(sb))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region// 
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Brands> ls = sbb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_Brands sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.pbcode);
                        al.Add(sw.pbname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
        #region// 
        public JsonResult DelBrand(string pbcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.Delete(pbcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion

        #region// 店面 工厂 品牌设置
        public JsonResult SetDepBrand(string pcode, string pbcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.SetDepBrand(pcode,pbcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//重置店面 工厂 品牌设置
        public JsonResult ReSetDepBrand(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.ReSetDepBrand(pcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//获取店面 工厂 品牌设置
        public JsonResult GetDepBrand(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sbb.GetDepBrand(pcode);
                r = sv;
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//获取店面可选品牌
        public JsonResult DepBrandList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Brands> ls = sbb.QueryList(" and pbcode in (select pbcode from Sys_RDepBrands where dcode like '"+iv.u.dcode+"%')");
                if (ls != null)
                {
                    foreach (Sys_Brands sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.pbcode);
                        al.Add(sw.pbname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
        #region//获取品牌默认生产厂
        public JsonResult QueryBrandFactory(string bcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f){
                r = sbb.QueryDepByBcode(bcode);
            }
            else
            {
                r=iv.badstr;
            }
            d.d =r;
            return Json(d);
        }
        #endregion

        #region//设置品牌材质
        public JsonResult SetMaterialBrand(string pbcode,string mpcode, string mcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.SetMaterialBrand(pbcode, mpcode, mcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//重置材质品牌设置
        public JsonResult ReSetMaterialBrand(string pbcode, string mcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.ReSetMaterialBrand(pbcode, mcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//获取材质品牌设置
        public JsonResult GetMaterialBrand(string pbcode,string mpcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sbb.GetMaterialBrand(pbcode, mpcode);
                r = sv;
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion

        #region//设置品牌产品
        public JsonResult SetInventroyBrand(string pbcode, string icode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.SetInventroyBrand(pbcode, icode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//重置产品品牌设置
        public JsonResult ReSetInventroyBrand(string pbcode, string icode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sbb.ReSetInventroyBrand(pbcode, icode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//获取产品品牌设置
        public JsonResult GetInventroyBrand(string pbcode, string icode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sbb.GetInventroyBrand(pbcode, icode);
                r = sv;
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
    }
}