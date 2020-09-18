using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvCommonBll;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Data;
using System.Text;
using LionvModel.SysInfo;
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;
using LionvModel.BusiCommon;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.CommonFile
{
    public partial class OrderProduceProcess : System.Web.UI.Page
    {
        private static BusiProduceProcessBll bppb = new BusiProduceProcessBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static CB_OrderProduceProcessBll coppb = new CB_OrderProduceProcessBll();
        private static CB_ProcessRecordBll cprb = new CB_ProcessRecordBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static CB_ProductionProcessBll cbppb = new CB_ProductionProcessBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单生产流程
        [WebMethod(true)]
        public static string QueryProceeLine(string sid)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = bppb.GetProduceOrder(sid);
                r = r + bppb.GetOrderProcess(sid);
                r = r + bppb.GetProduceProcess(sid);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//订单生产流程计划表
        [WebMethod(true)]
        public static ArrayList QueryOrderPlan(string curpage, string emcode, string pagesize, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
              
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = coppb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), " scode desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "jstate")
                                {
                                    int i = Convert.ToInt32(dr[column].ToString());
                                    al.Add(bppb.ProduceProcessState(i));
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }

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
        #region//订单生产流程计划表
        [WebMethod(true)]
        public static ArrayList QueryProductionPlan(string curpage, string emcode, string pagesize, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;

                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = cbppb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), " scode desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "gstate")
                                {
                                    int i = Convert.ToInt32(dr[column].ToString());
                                    al.Add(bppb.ProduceProcessState(i));
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }

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
        #region//获取生产流程
        [WebMethod(true)]
        public static string QueryProcess(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_OrderProduceProcess p = new CB_OrderProduceProcess();
                p=coppb.Query(" and id=" + id + "");
                r = js.Serialize(p);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////订单生产流程完成
        [WebMethod(true)]
        public static string ProcessOver(string id)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_ProductionProcess p = new CB_ProductionProcess();
                p.id = Convert.ToInt32(id);
                p.odate = DateTime.Now.ToString();
                p.gstate = 1;
                CB_ProductionProcess pp = cbppb.Query(" and id=" + id + "");
                if (cbppb.Update(p))
                {
                    //if (pp.jtype == "h")
                    //{
                    //    cosb.UpState(pp.sid, "ifactorydeliver", 1);
                    //}
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
        #region///延期保存
        [WebMethod(true)]
        public static string SaveLongTime(string id, string ldate, string remark)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_ProcessRecord cpr = new CB_ProcessRecord();
                CB_OrderProduceProcess  p = coppb.Query(" and id=" + id + "");
                DateTime d1 = Convert.ToDateTime(ldate);
                DateTime d2 = Convert.ToDateTime(CommonBll.GetBdate(p.ydate));
                TimeSpan ts = d1 - d2;
                int d = ts.Days;
                cpr.cdate = DateTime.Now.ToString();
                cpr.jdname = p.jdname;
                cpr.jid = p.id;
                cpr.maker = iv.u.ename;
                cpr.rtext = p.jdname + "预计完成日期" + p.ydate + "延期到" + ldate+";延期说明："+remark;
                cpr.sid = p.sid;
                cprb.Add(cpr);
                List<CB_OrderProduceProcess> plist = coppb.QueryList(" and id>=" + p.id + " and sid='"+p.sid+"'");
                if (plist != null)
                {
                    foreach (CB_OrderProduceProcess cp in plist)
                    {
                        cp.ydate = Convert.ToDateTime(cp.ydate).AddDays(d).ToString();
                        coppb.SetLongTime(cp);
                    }
                }
                if (coppb.UpState(id, -1))
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
        #region///暂停保存
        [WebMethod(true)]
        public static string SaveStop(string sid,string remark)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_ProcessRecord cpr = new CB_ProcessRecord();
                CB_OrderProduceProcess p = coppb.Query(" and id=" + sid + "");
                cpr.cdate = DateTime.Now.ToString();
                cpr.jdname = p.jdname;
                cpr.jid = p.id;
                cpr.maker = iv.u.ename;
                cpr.rtext = p.jdname + "暂停;暂停说明：" + remark;
                cpr.sid = p.sid;
                cprb.Add(cpr);
                if (coppb.UpState(sid, -2))
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
        #region///恢复生产
        [WebMethod(true)]
        public static string RecoverProcess(string sid)
        {
            string r = "";
            BusiWorkFlowBll snsb = new BusiWorkFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_ProcessRecord cpr = new CB_ProcessRecord();
                CB_OrderProduceProcess p = coppb.Query(" and id=" + sid + "");
                cpr.cdate = DateTime.Now.ToString();
                cpr.jdname = p.jdname;
                cpr.jid = p.id;
                cpr.maker = iv.u.ename;
                cpr.rtext = p.jdname + "恢复生产";
                cpr.sid = p.sid;
                cprb.Add(cpr);
                if (coppb.UpState(sid, 0))
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
        #region///获取下一未完成节点
        [WebMethod(true)]
        public static ArrayList QueryNextProcess(string id, string emcode, string tabcode)
        {

            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    CB_ProductionProcess copp = cbppb.Query(" and id=" + id + "");
                    if (copp != null)
                    {
                        where.Append(" and sid='" + copp.sid + "'");
                    }
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = cbppb.QueryList(1, 15, sfield, where.ToString(), " scode desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "gstate")
                                {
                                    int i = Convert.ToInt32(dr[column].ToString());
                                    al.Add(bppb.ProduceProcessState(i));
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }
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
    }
}