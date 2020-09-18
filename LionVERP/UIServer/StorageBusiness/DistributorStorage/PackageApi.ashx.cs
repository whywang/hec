using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using System.Data;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    /// <summary>
    /// PackageApi 的摘要说明
    /// </summary>
    public class PackageApi : IHttpHandler
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        B_SaleOrderBll bsb = new B_SaleOrderBll();
        B_AfterSaleOrderBll basb = new B_AfterSaleOrderBll();
        B_GroupProductionBll bgpb = new B_GroupProductionBll();
        B_ProductionItemBll bpib = new B_ProductionItemBll();
        B_PackageBll bpb = new B_PackageBll();
        B_PackageDateBll bpdb = new B_PackageDateBll();
        CB_OrderStateBll cbsb = new CB_OrderStateBll();
        CB_InSapRecordBll cisrb = new CB_InSapRecordBll();
        public void ProcessRequest(HttpContext context)
        {
            ApiReturns ar = new ApiReturns();
            PackageMessage pm = new PackageMessage();
            string psid = "";
            string agr = "";
            int pid=0;
        
            if(context.Request.QueryString["psid"]!=null)
            {
                 psid = context.Request.QueryString["psid"].ToString();
            }
            if (context.Request.QueryString["m"] != null)
            {
                agr = context.Request.QueryString["m"].ToString();
            }
            if (psid != "" && agr != "")
            {
                switch (agr)
                {
                    case "get":
                        #region//获取包装
                        pid = Convert.ToInt32(psid.Replace("P", ""));
                        DataRow bp = bpb.ViewQuery(" and bzid='" + pid + "'");
                        if (bp != null)
                        {
                            B_SaleOrder o = bsb.Query(" and osid='" + bp["sid"].ToString() + "'");
                            B_AfterSaleOrder ao = basb.Query(" and sid='" + bp["sid"].ToString() + "'");
                            B_GroupProduction gp = bgpb.Query(" and psid='" + bp["bsid"].ToString() + "'");
                            if (o != null)
                            {
                                pm.city = o.city;
                                pm.code = o.scode;
                                pm.customer = o.customer;
                            }
                            if (ao != null)
                            {
                                pm.city = ao.city;
                                pm.code = ao.scode;
                                pm.customer = ao.customer;
                            }
                            pm.mname = gp.mname;
                            pm.pname = gp.iname;
                            pm.size = gp.height.ToString() + "*" + gp.width.ToString() + "*" + gp.deep.ToString();
                            pm.direction = gp.direction;
                            pm.osort = "";// bgpb.QueryPackageGnum(" and psid in (select bsid from View_B_Package where bzid='"+pid+"')");
                            pm.pdate = bsb.QueryProductDate(bp["sid"].ToString());
                            if (bp != null)
                            {
                                pm.ptype = bp["btype"].ToString();
                                pm.packnum = bpb.PackageNum(bp["sid"].ToString()).ToString();
                                pm.curpacknum = bp["bnum"].ToString();
                                if (gp.icode.Substring(0, 2) == "02" || gp.icode.Substring(0, 2) == "06" || gp.icode.Substring(0, 2) == "07")
                                {
                                    if (pm.ptype == "门套" || pm.ptype == "套板")
                                    {
                                        B_ProductionItem mt = bpib.Query(" and psid='" + gp.psid + "' and  e_ptype='mt'");
                                        string mtszie = "";
                                        if (mt != null)
                                        {
                                            mtszie = mt.height.ToString() + "*" + mt.width.ToString() + "*" + mt.deep.ToString();
                                        }
                                        B_ProductionItem lb = bpib.Query(" and psid='" + gp.psid + "' and  e_ptype='lb'");
                                        string lbszie = "";
                                        if (lb != null)
                                        {
                                            lbszie = lb.height.ToString() + "*" + lb.width.ToString() + "*" + lb.deep.ToString();
                                        }
                                        if (gp.icode.Substring(0, 2) == "02")
                                        {
                                            if (mtszie != "" && lbszie != "")
                                            {
                                                pm.size2 = mtszie + ";" + lbszie;
                                            }
                                            else
                                            {
                                                pm.size2 = mtszie + lbszie;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        pm.size2 = bp["height"].ToString() + "*" + bp["width"].ToString() + "*" + bp["deep"].ToString(); ;
                                    }
                                }
                                else
                                {
                                    if (gp.icode.Substring(0, 2) == "01")
                                    {
                                        pm.size2 = bp["height"].ToString() + "*" + bp["width"].ToString() + "*" + bp["deep"].ToString();
                                    }
                                    else
                                    {
                                        pm.size2 = "";
                                    }
                                }
                                pm.pcode = "B" + bp["bzid"].ToString();
                                ar.msg = "S";
                                bpb.UpPackageState(bp["sid"].ToString(),Convert.ToInt32( bp["bnum"].ToString()), "bz", "1");
                                bpdb.UpPackageState(bp["sid"].ToString(), bp["bzid"].ToString(), "bdate");
                                cbsb.UpState(bp["sid"].ToString(), "ipackage", 1);
                                ar.o = pm;
                            }
                            else
                            {
                                ar.msg = "订单不错在";
                            }
                        }
                        else
                        {
                            ar.msg = "产品不错在";
                        }
                        #endregion
                        break;
                    case "instore":
                        #region//包装入库
                        pid = Convert.ToInt32(psid.Replace("B", ""));
                        DataRow zbrk = bpb.ViewQuery(" and bzid=" + pid + "");
                        if (zbrk != null)
                        {
                            if (bpb.UpPackageState(zbrk["sid"].ToString(), Convert.ToInt32(zbrk["bnum"].ToString()), "zbrk", "1"))
                            {
                                #region//包装入库插入待SAP导入表
                                CB_InSapRecord cisr = new CB_InSapRecord();
                                cisr.sid = pid.ToString();
                                cisr.stype = "bzrk";
                                cisr.istate = 0;
                                cisr.cdate = DateTime.Now.ToString();
                                cisrb.Add(cisr);
                                #endregion
                                bpdb.UpPackageState(zbrk["sid"].ToString(), zbrk["bzid"].ToString(), "insdate");
                                if (bpb.Exists(" and sid='" + zbrk["sid"].ToString() + "' and zbrk=0"))
                                {
                                }
                                else
                                {
                                    cbsb.UpState(zbrk["sid"].ToString(), "istoreget", 2);
                                    //订单入库销售订单 和销售返修单
                                    BaseSet.WorkFlowManage.EventBtnDo.UnUserFireEventBtn(zbrk["sid"].ToString(), "0062", "1", "入库");
                                    BaseSet.WorkFlowManage.EventBtnDo.UnUserFireEventBtn(zbrk["sid"].ToString(), "0118", "1", "入库");
                                    #region//订单入库插入待SAP导入表
                                    CB_InSapRecord cor = new CB_InSapRecord();
                                    cor.sid = zbrk["sid"].ToString();
                                    cor.stype = "ork";
                                    cor.istate = 0;
                                    cor.cdate = DateTime.Now.ToString();
                                    cisrb.Add(cor);
                                    #endregion
                                }
                                ar.msg = "S";
                            }
                            else
                            {
                                ar.msg = "入库失败";
                            }
                        }
                        else
                        {
                            ar.msg = "包装不错在";
                        }
                        #endregion
                        break;
                    case "outstore":
                        #region//包装出库
                        //pid = Convert.ToInt32(psid.Replace("B", ""));
                        // DataRow zbck = bpb.ViewQuery(" and bzid=" + pid + "");
                        //if (zbck != null)
                        //{
                        //    if (bpb.UpPackageState(zbck["sid"].ToString(), Convert.ToInt32(zbck["bnum"].ToString()), "zbck", "1"))
                        //    {
                        //        bpdb.UpPackageState(zbck["sid"].ToString(), zbck["bzid"].ToString(), "outsdate");
                        //        ar.msg = "S";
                        //    }
                        //    else
                        //    {
                        //        ar.msg = "出库失败";
                        //    }
                        //}
                        //else
                        //{
                        //    ar.msg = "包装不错在";
                        //}
                       #endregion
                        #region//订单出库
                        B_SaleOrder bso = bsb.Query(" and scode='" + psid + "'");
                        if (bso != null)
                        {
                            bpb.UpPackageState(bso.sid, "zbck", "1");
                            bpdb.UpPackageState(bso.sid, "outsdate");
                            ar.msg = "S";
                            CB_InSapRecord cisr = new CB_InSapRecord();
                            cisr.sid = bso.sid;
                            cisr.stype = "ock";
                            cisr.istate = 0;
                            cisr.cdate = DateTime.Now.ToString();
                            cisrb.Add(cisr);
                        }
                        B_AfterSaleOrder abso = basb.Query(" and scode='" + psid + "'");
                        if (abso != null)
                        {
                            bpb.UpPackageState(abso.sid, "zbck", "1");
                            bpdb.UpPackageState(abso.sid, "outsdate");
                            ar.msg = "S";
                            CB_InSapRecord cisr = new CB_InSapRecord();
                            cisr.sid = abso.sid;
                            cisr.stype = "ock";
                            cisr.istate = 0;
                            cisr.cdate = DateTime.Now.ToString();
                            cisrb.Add(cisr);
                        }
                        
                       
                        #endregion
                        break;
                    case "incity":
                         pid = Convert.ToInt32(psid.Replace("B", ""));
                         DataRow csrk = bpb.ViewQuery(" and bzid=" + pid + "");
                        if (csrk != null)
                        {
                            if (bpb.UpPackageState(csrk["sid"].ToString(), Convert.ToInt32(csrk["bnum"].ToString()), "csrk", "1"))
                            {
                                bpdb.UpPackageState(csrk["sid"].ToString(), csrk["bzid"].ToString(), "incdate");
                                ar.msg = "S";
                            }
                            else
                            {
                                ar.msg = "入库失败";
                            }
                        }
                        else
                        {
                            ar.msg = "包装不错在";
                        }
                        break;
                    case "outcity":
                         pid = Convert.ToInt32(psid.Replace("B", ""));
                         DataRow csck = bpb.ViewQuery(" and bzid=" + pid + "");
                        if (csck != null)
                        {
                            if (bpb.UpPackageState(csck["sid"].ToString(), Convert.ToInt32(csck["bnum"].ToString()), "csck", "1"))
                            {
                                bpdb.UpPackageState(csck["sid"].ToString(), csck["bzid"].ToString(), "outcdate");
                                ar.msg = "S";
                            }
                            else
                            {
                                ar.msg = "出库失败";
                            }
                        }
                        else
                        {
                            ar.msg = "包装不错在";
                        }
                        break;

                }
            }
            else
            {
                ar.msg = "参数错误";
                ar.o = null;
            }
            context.Response.Write(js.Serialize(ar));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class ApiReturns
    {
        private string _msg = "";

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private object _o=null;

        public object o
        {
            get { return _o; }
            set { _o = value; }
        }
    }
    public class PackageMessage
    {
        private string _code = "";

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _customer = "";

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _city = "";

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _mname = "";

        public string mname
        {
            get { return _mname; }
            set { _mname = value; }
        }
        private string _pname = "";

        public string pname
        {
            get { return _pname; }
            set { _pname = value; }
        }
        private string _packnum = "";

        public string packnum
        {
            get { return _packnum; }
            set { _packnum = value; }
        }
        private string _curpacknum = "";

        public string curpacknum
        {
            get { return _curpacknum; }
            set { _curpacknum = value; }
        }
        private string _ptype = "";

        public string ptype
        {
            get { return _ptype; }
            set { _ptype = value; }
        }
        private string _pcode = "";
        public string pcode
        {
            get { return _pcode; }
            set { _pcode = value; }
        }
        private string _size;

        public string size
        {
            get { return _size; }
            set { _size = value; }
        }
        private string _direction;

        public string direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        private string _osort;

        public string osort
        {
            get { return _osort; }
            set { _osort = value; }
        }
        private string _asort;

        public string asort
        {
            get { return _asort; }
            set { _asort = value; }
        }
        private string _pdate;

        public string pdate
        {
            get { return _pdate; }
            set { _pdate = value; }
        }
        private string _size2;
        public string size2
        {
            get { return _size2; }
            set { _size2 = value; }
        }
    }
}