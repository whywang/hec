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
using LionvModel.SysInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProduceCapacityController:Controller
    {
        private Sys_ProduceAllCapacityBll spacb = new Sys_ProduceAllCapacityBll();
        private Sys_ProduceCateBll spcb = new Sys_ProduceCateBll();
        private Sys_ProductionCapacityBll spscb = new Sys_ProductionCapacityBll();
        private Sys_DepmentBll sdb = new Sys_DepmentBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化 
        public JsonResult InitACapacity(string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProduceAllCapacity sal = new Sys_ProduceAllCapacity();
                sal = spacb.Query(" and  dcode='" + dcode + "'");
                if (sal!=null)
                {
                    d.d = js.Serialize(sal);
                }
                else
                {
                    Sys_ProduceAllCapacity sal1 = new Sys_ProduceAllCapacity();
                    Sys_Depment sd= sdb.Query(" and dcode='" + dcode + "'");
                    sal1.dcode = sd.dcode;
                    sal1.dname = sd.dname;
                    sal1.id = 0;
                    d.d = js.Serialize(sal1);
                }
                
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存 
        public JsonResult SaveACapacity(string fcode, string fname, string lnum, string zid, string znum)
        {
            JsonData d = new JsonData();
            Sys_ProduceAllCapacity sb = new Sys_ProduceAllCapacity();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.dcode = fcode;
                sb.dname = fname;
                sb.alnum = Convert.ToInt32(lnum);
                sb.cnum = Convert.ToInt32(znum); ;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (zid == "0")
                {
                    if (spacb.Add(sb) > 0)
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
                    if (spacb.Update(sb))
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
        #region//获取 
        public JsonResult QueryAList(string dcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProduceAllCapacity> ls = spacb.QueryList(" and dcode='"+dcode+"'");
                if (ls != null)
                {
                    foreach (Sys_ProduceAllCapacity sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.dcode);
                        al.Add(sw.dname);
                        al.Add(sw.cnum);
                        al.Add(sw.alnum);
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
        #region//删除 
        public JsonResult DelACapacity(string dcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spacb.Delete(" and dcode='" + dcode + "'"))
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

        #region//初始化
        public JsonResult InitProduceCate(string lcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProduceCate sal = new Sys_ProduceCate();
               
                if (lcode != "")
                {
                    sal = spcb.Query(" and  lcode='" + lcode + "'");
                    d.d = js.Serialize(sal);
                }
                else
                {
                    sal.lcode = spcb.CreateCode().ToString().PadLeft(4,'0');
                    sal.id = 0;
                    d.d = js.Serialize(sal);
                }

            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存
        public JsonResult SaveProduceCate(string lcode, string lname, string lid)
        {
            JsonData d = new JsonData();
            Sys_ProduceCate sb = new Sys_ProduceCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lcode = lcode;
                sb.lname = lname;
                sb.cdate = DateTime.Now.ToString();
                if (lid == "0")
                {
                    if (spcb.Add(sb) > 0)
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
                    if (spcb.Update(sb))
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
        #region//获取
        public JsonResult QueryCateList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProduceCate> ls = spcb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProduceCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lcode);
                        al.Add(sw.lname);
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
        #region//删除
        public JsonResult DelProduceCate(string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spcb.Delete(" and lcode='" + lcode + "'"))
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

        #region//初始化
        public JsonResult InitProduce(string dcode, string cccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionCapacity sal = new Sys_ProductionCapacity();

                if (cccode != "")
                {
                    sal = spscb.Query(" and  cccode='" + cccode + "'");
                    d.d = js.Serialize(sal);
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                    sal.cccode = spscb.CreateCode().ToString().PadLeft(4, '0');
                    sal.dcode = dcode;
                    sal.dname = sd.dname;
                    sal.id = 0;
                    d.d = js.Serialize(sal);
                }

            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存
        public JsonResult SaveProduce(string cccode, string cid, string plcode, string pdcode, string pdname, string pnum)
        {
            JsonData d = new JsonData();
            Sys_ProductionCapacity sb = new Sys_ProductionCapacity();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProduceCate sal = spcb.Query(" and  lcode='" + plcode + "'");
                sb.cccode = cccode;
                sb.ccname = "";
                sb.dname = pdname;
                sb.dcode = pdcode;
                sb.cnum = Convert.ToInt32(pnum);
                sb.lcode = plcode;
                sb.lname = sal.lname;
                sb.cdate = DateTime.Now.ToString();
                if (cid == "0")
                {
                    if (spscb.Add(sb) > 0)
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
                    if (spscb.Update(sb))
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
        #region//获取
        public JsonResult QueryCList(string dcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionCapacity> ls = spscb.QueryList(" and dcode='" + dcode + "'");
                if (ls != null)
                {
                    foreach (Sys_ProductionCapacity sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.cccode);
                        al.Add(sw.dname);
                        al.Add(sw.lname);
                        al.Add(sw.cnum);
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
        #region//删除
        public JsonResult DelProduce(string cccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spscb.Delete(" and cccode='" + cccode + "'"))
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

        #region//初始化
        public JsonResult SetProductionCate(string lcode, string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if( spcb.SetProductionCate(lcode,icode))
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
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存
        public JsonResult ReSetProductionCate(string lcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spcb.ReSetProductionCate(lcode))
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
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取
        public JsonResult GetProductionCate(string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = spcb.GetProductionCate(lcode);
            }
            else
            {
                r=iv.badstr;
            }
            d.d =r;
            return Json(d);
        }

        #endregion
    }
}