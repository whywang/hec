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
using LionvModel.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvCommonBll;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.CustomerBusiness
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private static B_CustomerBll bcb = new B_CustomerBll();
        private static B_OrdersBll bob = new B_OrdersBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取名称相同的所有客户
        [WebMethod(true)]
        public static string initCustomer()
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                B_Customer bc = new B_Customer();
                Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                if (sd != null)
                {
                    Sys_Depment ct = sdb.Query(" and dcode='" + sd.dpcode + "'");
                    if (ct != null)
                    {
                        bc.aprovince = ct.dpname;
                        bc.acity = ct.dcity;
                    }
                }
                r = js.Serialize(bc);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取名称相同的所有客户
        [WebMethod(true)]
        public static ArrayList QueryCustList(string sstr)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Customer> ls = bcb.QueryList(" and (dcode='" + iv.u.dcode + "' or citycode='" + iv.u.dcode + "') and ( customer='" + sstr + "' or telephone='" + sstr + "')");
                if (ls != null)
                {
                    foreach (B_Customer s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.sid);
                        al.Add(s.customer);
                        al.Add(s.telephone);
                        al.Add(s.community);
                        al.Add(s.address);
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
        #region//获取名称相同的部门客户
        [WebMethod(true)]
        public static ArrayList QueryListByDep(string customer)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Customer> ls = bcb.QueryList(" and customer like '%" + customer + "%' and '"+iv.u.dcode+"' like dcode+'%'");
                if (ls != null)
                {
                    foreach (B_Customer s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dname);
                        al.Add(s.customer);
                        al.Add(s.telephone);
                        al.Add(s.community );
                        al.Add(s.address  );
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
        #region//获取客户订单
        [WebMethod(true)]
        public static ArrayList QueryList(string emcode, string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Orders> ls = bob.QueryList(" and csid='" + sid + "' and (dcode='" + iv.u.dcode + "' or citycode='" + iv.u.dcode + "' ) order by id desc");
                if (ls != null)
                {
                    foreach (B_Orders s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.sid);
                        al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", s.sid));
                        al.Add(s.zcode);
                        al.Add(s.customer);
                        al.Add(s.telephone);
                        al.Add(s.community);
                        al.Add(s.address);
                        al.Add(s.mqmo == true ? "有" : "无");
                        al.Add(s.yqmo == true ? "有" : "无");
                        al.Add(s.qbo == true ? "有" : "无");
                        al.Add(s.ymo == true ? "有" : "无");
                        al.Add(s.czo == true ? "有" : "无");
                        al.Add(s.dso == true ? "有" : "无");
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
        #region//获取客户订单
        [WebMethod(true)]
        public static ArrayList InitQueryList(string emcode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_Orders> ls = bob.QueryList(" and ( dcode='" + iv.u.dcode + "' or citycode='" + iv.u.dcode + "') order by id desc", 10);
                if (ls != null)
                {
                    foreach (B_Orders s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.sid);
                        al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", s.sid));
                        al.Add(s.zcode);
                        al.Add(s.customer);
                        al.Add(s.telephone);
                        al.Add(s.community);
                        al.Add(s.address);
                        al.Add(s.mqmo == true ? "有" : "无");
                        al.Add(s.yqmo == true ? "有" : "无");
                        al.Add(s.qbo == true ? "有" : "无");
                        al.Add(s.ymo == true ? "有" : "无");
                        al.Add(s.czo == true ? "有" : "无");
                        al.Add(s.dso == true ? "有" : "无");
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
        #region//获取客户订单
        [WebMethod(true)]
        public static string InitQuery(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_Orders bo = new B_Orders();
                B_Customer bc = bcb.Query(" and sid='" + sid + "'");
                if (bc != null)
                {
                    bo.acity = bc.acity;
                    bo.aprovince = bc.aprovince;
                    bo.address = bc.address;
                }
                r = js.Serialize(bo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存客户
        [WebMethod(true)]
        public static string SaveCustomer(string acity, string address, string aprovince, string ctype, string customer, string telephone)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcb.Exists(" and telephone='" + telephone + "' and address='"+address.Trim()+"'"))
                {
                    r = "T";
                }
                else
                {
                    string dc = iv.u.dcode;
                    Sys_Depment sd = sdb.Query(" and dcode='" + dc + "'");
                    B_Customer bc = new B_Customer();
                    bc.sid = CommonBll.GetSid();
                    bc.address = address;
                    bc.community = "";
                    bc.ctype = ctype;
                    bc.customer = customer;
                    bc.telephone = telephone.Trim();
                    bc.acity = acity;
                    bc.aprovince = aprovince;
                    if (sd.dattr == "dm")
                    {
                        bc.dcode = sd.dcode;
                        bc.dname = sd.dname;
                        bc.city = sd.dpname;
                        bc.citycode = sd.dpcode;
                        bc.bdcode = sd.dcode.Substring(0, 8);
                    }
                    else
                    {
                        Sys_Depment sdc = sdb.Query(" and dpcode='" + sd.dcode + "'");
                        if (sdc != null)
                        {
                            bc.dcode = sdc.dcode;
                            bc.dname = sdc.dname;
                        }
                        bc.city = sd.dname;
                        bc.citycode = sd.dcode; 
                        bc.bdcode = sd.dcode.Substring(0, 8);
                    }
                    bc.maker = iv.u.ename;
                    bc.cdate = DateTime.Now.ToString();
                    if (bcb.Add(bc) > 0)
                    {
                        B_Orders bs = new B_Orders();
                        bs.address = address;
                        bs.cdate = DateTime.Now.ToString();
                        bs.city = bc.city;
                        bs.citycode = bc.citycode;
                        bs.community = bc.community;
                        bs.csid = bc.sid;
                        bs.customer = customer;
                        bs.dcode = bc.dcode;
                        bs.dname = bc.dname;
                        bs.telephone = bc.telephone;
                        bs.sid = CommonBll.GetSid();
                        bs.zcode = "Z" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        bob.Add(bs);
                        r = bs.csid;
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
        #region//保存订单
        [WebMethod(true)]
        public static string SaveOrder(string sid, string ncity, string nprovince,string nad)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dc = iv.u.dcode;
                Sys_Depment sd = sdb.Query(" and dcode='" + dc + "'");
                B_Customer bc = bcb.Query(" and sid='" + sid + "'");
                if (bc != null)
                {
                    B_Orders bs = new B_Orders();
                    bs.address = nad.Trim() == "" ? bs.address : nad;
                    bs.community = "";
                    bs.cdate = DateTime.Now.ToString();
                    bs.city = bc.city;
                    bs.citycode = bc.citycode;
                    bs.csid = bc.sid;
                    bs.customer = bc.customer;
                    bs.dcode = bc.dcode;
                    bs.dname = bc.dname;
                    bs.telephone = bc.telephone;
                    bs.sid = CommonBll.GetSid();
                    bs.acity = ncity;
                    bs.aprovince = nprovince;
                    bs.zcode = "Z" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    if (bob.Add(bs) > 0)
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
    }
}