using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.ProduceServiceManage
{
    public partial class Producefees : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化服务费
        [WebMethod(true)]
        public static string InitFee(string ptcode,string pcode,string id)
        {
            string r = "";
            Sys_AgentFee sr = new Sys_AgentFee();
            Sys_AgentFeeBll srb = new Sys_AgentFeeBll();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_InventoryCategory ic = new Sys_InventoryCategory();
                Sys_Depment dt = new Sys_Depment();
                if (id == "0" || id == "")
                {
                    ic = sicb.Query(" and iccode='" + pcode + "'");
                    dt = sdb.Query(" and dcode='" + ptcode + "'");
                    sr.acode = ptcode;
                    sr.aname = dt.dname;
                    sr.iname = ic.icname;
                    sr.icode = pcode;
                    sr.id = 0;
                    r = js.Serialize(sr);
                }
                else
                {
                    sr = srb.Query(" and id=" + id + "");
                    sr.iname = sicb.Query(" and iccode='" + sr.icode + "'").icname;
                    sr.aname = sdb.Query(" and dcode='" + sr.acode + "'").dname;
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
        #region///  保存服务费
        [WebMethod(true)]
        public static string SaveFee(string ptcode, string pcode, string fff, string fid,string tfff)
        {
            string r = "";
            Sys_AgentFeeBll srb = new Sys_AgentFeeBll();
            
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_AgentFee sr = new Sys_AgentFee();
                sr.acode = ptcode;
                sr.icode = pcode;
                sr.fmoney = Convert.ToInt32(fff);
                sr.cdate = DateTime.Now.ToString();
                sr.tfmoney = Convert.ToInt32(tfff);
                sr.maker = iv.u.ename;
                if (fid == "0")
                {
                    if (!srb.Exists(" and acode='" + ptcode + "' and icode='" + pcode + "'"))
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
                    sr.id=Convert.ToInt32(fid);
                    if (srb.Update(sr))
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
        #region///  删除服务费
        [WebMethod(true)]
        public static string DelFee(string fid)
        {
            string r = "";
            Sys_AgentFeeBll srb = new Sys_AgentFeeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Delete(" and id=" + fid + ""))
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
        #region/// 获取服务费列表
        [WebMethod(true)]
        public static ArrayList QueryList(string ptcode)
        {
            ArrayList r = new ArrayList();
            Sys_AgentFeeBll srb = new Sys_AgentFeeBll();
            List<Sys_AgentFee> lsf = new List<Sys_AgentFee>();
            Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and acode='"+ptcode+"'");
                if (lsf != null)
                {
                    foreach (Sys_AgentFee s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        Sys_InventoryCategory sic = sicb.Query(" and iccode='" + s.icode + "'");
                        Sys_Depment dt = sdb.Query(" and dcode='" + s.acode + "'");
                        al.Add(s.id);
                        al.Add(dt==null?"":dt.dname);
                        al.Add(sic==null?"":sic.icname);
                        al.Add(s.fmoney);
                        al.Add(s.tfmoney);
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
        #region/// 获取服务费列表
        [WebMethod(true)]
        public static string GetProduceFee(string ptcode,string pcode)
        {
            string r = "";
            Sys_AgentFeeBll srb = new Sys_AgentFeeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetProductionFee(ptcode,pcode);
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