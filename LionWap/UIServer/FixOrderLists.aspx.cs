using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services;
using System.Text;
using System.Data;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvBll.StatisticsInfo;

namespace LionWap.UIServer
{
    public partial class FixOrderLists : System.Web.UI.Page
    {
        private static B_FixOrderBll bfb = new B_FixOrderBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static ArrayList QueryFixOrderList(string timespan, string curpage, string pagesize,string wheres,string utype)
        {
            StringBuilder where = new StringBuilder();
            DataTable lsr = new DataTable();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (timespan != "")
                {
                    where.AppendFormat(" and edate <= '{0}'", timespan);
                }
                where.Append(wheres.Replace("[user]", " and sid in ( select sid from B_FixOrderTask where azs='"+iv.u.ename+"')"));
                lsr = bfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), " sid ,scode,customer ", where.ToString(), " edate desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    if (Convert.ToInt32(curpage) <= pcount)
                    {
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(dr["scode"].ToString());
                            al.Add(dr["customer"].ToString());
                            if (utype == "w")
                            {
                                al.Add("<a href='orderdetail.htm?Sid=" + dr["sid"].ToString() + "' rel='external'> <img src='Image/sysimg/odetail.png' /></a>");
                            }
                            if (utype == "y")
                            {
                                al.Add("<a href='yorderdetail.htm?Sid=" + dr["sid"].ToString() + "' rel='external'> <img src='Image/sysimg/odetail.png' /></a>");
                            }
                            r.Add(al);
                        }
                    }
                }
                else
                {
                    r.Add(1);
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        [WebMethod(true)]
        public static ArrayList QueryProductionSummary(string bdate, string edate, string code, string wheres)
        {
            StringBuilder where = new StringBuilder();
            DataTable lsr = new DataTable();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != "")
                {
                    where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0043' and [state]=1 and edate >= '{0}')", bdate);
                }
                else
                {
                    where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0043' and [state]=1 and edate >= '{0}')", CommonBll.GetBdate());
                }
                if (edate != "")
                {
                    where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0043' and [state]=1 and edate <= '{0}')", edate);
                }
                else
                {
                    where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0043' and [state]=1 and edate <= '{0}')", CommonBll.GetEdate());
                }
                if (code != "")
                {
                    where.AppendFormat(" and sid in (select sid from B_FixOrder where scode like '%{0}%')", code);
                }
                where.Append(wheres.Replace("[user]",iv.u.ename));
                where.Append(" group by pcode,pname ");
                lsr = tsb.QueryList("B_FixProduction", " pname, isnull(sum(pnum),0) as nums ", where.ToString(), "");
                if (lsr != null)
                {
                
                    foreach (DataRow dr in lsr.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr["pname"].ToString());
                        al.Add(dr["nums"].ToString());
                        r.Add(al);
                    }
                }
                else
                {
                    r.Add(iv.badstr);
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
    
    }
}
 