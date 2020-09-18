using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Services;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using System.Collections;
using System.Text;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.ProductionSet.ImageManage
{
    public partial class ImageFile : System.Web.UI.Page
    {
        private static Sys_DomainBll sdb = new Sys_DomainBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化图片
        [WebMethod(true)]
        public static string InitImage(string icode)
        {
            string r = "";
            Sys_ProduceImg spi = new Sys_ProduceImg();
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProduceImg cspi = snsb.Query(" and icode='" + icode + "'");
                if (cspi != null)
                {
                    r = js.Serialize(cspi);
                }
                else
                {
                    spi.iname = "";
                    spi.icode = snsb.CreateCode().ToString().PadLeft(4, '0');
                    r = js.Serialize(spi);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  删除图片
        [WebMethod(true)]
        public static string DelImage(string icode)
        {
            string r = "";
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (snsb.Delete(" and icode='" + icode + "'"))
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
        #region///图片列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            List<Sys_ProduceImg> lsf = new List<Sys_ProduceImg>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode != "xtgl")
                {
                    where.Append(" and dcode ='" + iv.u.dcode.Substring(0, 8) + "'  order by iname");
                }
                else
                {
                    where.Append(" order by iname");
                }
                lsf = snsb.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_ProduceImg s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add("<img src='"+s.iurl+"'/>");
                        al.Add("<img src='" + s.ifurl + "'/>");
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

        #region///   设置产品图片
        [WebMethod(true)]
        public static string SetProductionImg(string pcode, string icode)
        {
            string r = "";
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (snsb.SetProductionImg(pcode, icode) > 0)
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
        #region///  重置产品减尺
        [WebMethod(true)]
        public static string ReSetProductionImg(string pcode)
        {
            string r = "";
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (snsb.ReSetProductionImg(pcode) > 0)
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
        #region///  获取产品减尺
        [WebMethod(true)]
        public static string GetProductionImg(string pcode)
        {
            string r = "";
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = snsb.GetProductionImg(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //-----------------------------Cust---------------------------
        #region///图片列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            List<Sys_ProduceImg> lsf = new List<Sys_ProduceImg>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = snsb.QueryList(" and dcode ='"+iv.u.dcode.Substring(0,8)+"' order by iname");
                if (lsf != null)
                {
                    foreach (Sys_ProduceImg s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.icode);
                        al.Add(s.iname);
                        al.Add("<img src='" + s.iurl + "'/>");
                        al.Add("<img src='" + s.ifurl + "'/>");
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
        //------------------------------获取产品图片-------------------------
        #region///图片列表
        [WebMethod(true)]
        public static string QueryImg(string pcode)
        {
            string r = "";
            Sys_ProduceImgBll snsb = new Sys_ProduceImgBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               string icode= snsb.GetProductionImg(pcode);
               Sys_ProduceImg si = snsb.Query(" and icode='" + icode + "'");
               if (si != null)
               {
                  Sys_Domain sd= sdb.Query(" and dtype='p'");
                  if (sd != null)
                  {
                      si.iurl = sd.url + si.iurl;
                      si.ifurl = sd.url + si.ifurl;
                  }
               }
               r = js.Serialize(si);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
    }
}