using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using System.Collections;
using System.Text;
using LionvModel.SysInfo;
using LionvBll.Account;
using LionvModel.Account;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class SaleCustomerOrder : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_CustormOrderBll bcob = new B_CustormOrderBll();
        private static Sys_DepmentBll sdb=new Sys_DepmentBll ();
        private static B_CustomerBll bcb = new B_CustomerBll();
        private static B_MeasureImgBll bmib = new B_MeasureImgBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static CreateOrderCodeBll cocb = new CreateOrderCodeBll();
        private static Sys_EmployeeDptBll sedb = new Sys_EmployeeDptBll();
        private static B_CustomerOrderTaskBll bcotb = new B_CustomerOrderTaskBll();
        private static Sys_SaleDiscountBll ssdb = new Sys_SaleDiscountBll();
        private static A_CustomeAccountBll acab = new A_CustomeAccountBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化预定单
        [WebMethod(true)]
        public static string InitCustomerOrder(string sid)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 获取预定单
        [WebMethod(true)]
        public static string QueryCustomerOrder(string sid)
        {
            string r = "";
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CustormOrder bco = new B_CustormOrder();
                if (sid != "")
                {
                    bco = bcob.Query(" and csid='" + sid + "'");
                }
                else
                {
                    Sys_Depment shop = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                    if (shop != null)
                    {
                        bco.dname = shop.dname;
                        bco.dcode = shop.dcode;
                        bco.e_city = shop.dpname;
                        bco.e_citycode = shop.dpcode;
                    }
                    bco.otype = "销售预定单";
                }
                r = js.Serialize(bco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存预定单
        [WebMethod(true)]
        public static string SaveCustomerOrder(string address,string citycode,string cityname,string cmoney,string colortype,string distype, string customer, string gzname,string gztelephone, 
              string lxtype,string mname, string otype, string remark,string shopcode, string shopname,   string sid, string source, string telephone,string wcode,  string yxdate)
        {
            string r = "";
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SaleDiscount ssd = ssdb.Query(" and dcode='" + distype + "'");
                B_CustormOrder bco = new B_CustormOrder();
                bco.ccode = "";
                bco.wcode = wcode;
                bco.cmoney = Convert.ToDecimal(cmoney);
                bco.customer = customer;
                bco.telephone = telephone;
                bco.community = "";
                bco.address = address;
                bco.aname = "";
                bco.acode = "";
                bco.dname = shopname;
                bco.dcode= shopcode;
                bco.e_city = cityname;
                bco.e_citycode = citycode;
                bco.e_citytype = "";
                bco.gzname = gzname;
                bco.gztelephone = gztelephone;
                bco.saletelephone = "";
                bco.otype = otype;
                bco.state = false;
                bco.mname = mname;
                bco.source = source;
                bco.ps = remark;
                bco.maker = iv.u.ename;
                bco.cdate = DateTime.Now.ToString();
                bco.istax =false;
                bco.isdf = false;
                bco.yxdate = CommonBll.GetBdate(yxdate);
                bco.lxtype = lxtype;
                bco.colorpane = colortype;
                if (distype != "")
                {
                    bco.disactname = ssd != null ? ssd.dname : "";
                    bco.disactcode = distype;
                }
                else
                {
                    bco.disactname ="";
                    bco.disactcode ="";
                }
              
                if (sid == "")
                {
                    bco.csid = CommonBll.GetSid();
                    bco.ccode = cocb.SetCustomerOrderCode();
                    if (bcob.Add(bco) > 0)
                    {
                        bwfb.CreateWorkFlow(bco.csid, "0001");
                        r = bco.csid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    bco.csid = sid;
                    if (bcob.Update(bco))
                    {
                        r = bco.csid;
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
        #region///加载测量单图片
        [WebMethod(true)]
        public static string SetThirdDep(string dcode,string dname,string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                bcotb.Delete("and sid='" + sid + "'");
                B_CustomerOrderTask t = new B_CustomerOrderTask();
                t.cdate = DateTime.Now.ToString();
                t.dcode = dcode;
                t.dname = dname;
                t.sid = sid;
                t.maker = iv.u.ename;
                if (bcotb.Add(t) > 0)
                {
                    bcob.SetThirdDep(dname, dcode, sid);
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
        [WebMethod(true)]
        public static string LoadMeasureImg(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_MeasureImg bmi = bmib.Query(" and (csid='" + sid + "' or csid =(select csid from dbo.B_SaleOrder where osid='" + sid + "'))");
                r = js.Serialize(bmi);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]
        public static string LoadMeasureImgList(string sid)
        {
            string r = "";
            StringBuilder ht = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ht.Append("<table style='width:100%'>");
                List<B_MeasureImg> bmi = bmib.QueryList(" and (csid='" + sid + "' or csid =(select csid from dbo.B_SaleOrder where sid='" + sid + "'))");
                if (bmi != null)
                {
                    foreach(B_MeasureImg b in bmi)
                    {
                        ht.AppendFormat("<tr><td><img src='{0}' alt='{1}' id='{2}' style='cursor:pointer;' onclick='nck(this.id)'/></td></tr>", b.url, b.imgname,b.id);
                    }
                }
                ht.Append("</table>");
                r = ht.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]
        public static ArrayList QueryMeasureImgList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_MeasureImg> bmi = bmib.QueryList(" and  csid='" + sid + "'");
                if (bmi != null)
                {
                    foreach(B_MeasureImg bm in bmi)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(bm.id);
                        al.Add(bm.imgname);
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
        [WebMethod(true)]
        public static string ZQueryMeasureImgList(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder divstr = new StringBuilder();
                List<B_MeasureImg> bmi = bmib.QueryList(" and  csid='" + sid + "'");
                if (bmi != null)
                {
                    divstr.Append("<div style='width:100%'>");
                    foreach (B_MeasureImg bm in bmi)
                    {
                        divstr.Append("<div style='width:100px;height:100px;float:left'>");
                        divstr.Append("<div style='width:100px;height:20px;float:left'>");
                        divstr.AppendFormat("<img id='{0}' src='../../../Image/opeimage/close.gif' style='cursor:pointer;float:right' onclick='DelShImg(this.id)'/>", bm.id);
                        divstr.Append("</div>");
                        divstr.Append("<div style='width:100px;height:80px;float:right'>");
                        divstr.AppendFormat("<img src='{0}' style='width:80px;height:80px;'/>", bm.url);
                        divstr.Append("</div>");
                        divstr.Append("</div>");
                    }
                    divstr.Append("</div>");
                    r = divstr.ToString();
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        [WebMethod(true)]
        public static string DelMeasureImg(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r=iv.badstr;
                string [] ids=id.Split(',');
                if (bmib.DeleteList(ids))
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
    }
}