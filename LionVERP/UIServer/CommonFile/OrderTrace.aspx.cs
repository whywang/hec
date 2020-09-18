using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.SysInfo;
using System.Data;
using LionvAopModel;
using System.Text;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class OrderTrace : System.Web.UI.Page
    {
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_OrderTraceRecordBll ctrb = new CB_OrderTraceRecordBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单List
        [WebMethod(true)]
        public static ArrayList QueryListOrder(string curpage, string emcode, string pagesize, string sstr)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (sstr != "")
                {
                    where.AppendFormat(" and (customer like '%{0}%' or scode like '%{0}%' or city like '%{0}%' or dname like '%{0}%' or telephone like '%{0}%')", sstr);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, "a", iv.u.rcode);
                if (svt == null || sstr == "")
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = ctrb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "cdate desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                al.Add(dr[column].ToString());
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
        #region/////保存订单跟踪记录
        [WebMethod(true)]
        public static string SaveRecord(string sid, string tdate, string ttext)
        {
            string r ="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            if (iv.f)
            {
                CB_OrderTraceRecord cor = new CB_OrderTraceRecord();
                cor.sid = sid;
                cor.ttype = "";
                cor.tdate = tdate;
                cor.maker = iv.u.ename;
                cor.ttext = ttext;
                cor.cdate = DateTime.Now.ToString();
                if (ctrb.Add(cor) > 0)
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
        #region/////获取订单跟踪记录
        [WebMethod(true)]
        public static ArrayList QueryRecordList(string sid)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<CB_OrderTraceRecord> lor = ctrb.QueryList(" and sid='" + sid + "' ");
                if (lor != null)
                {
                    foreach (CB_OrderTraceRecord cr in lor)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(cr.ttext);
                        al.Add(cr.tdate);
                        al.Add(cr.maker);
                        al.Add(cr.cdate);
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