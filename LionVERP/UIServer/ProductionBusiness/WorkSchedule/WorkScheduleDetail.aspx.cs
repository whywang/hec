using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionBusiness.WorkSchedule
{
    public partial class WorkScheduleDetail : System.Web.UI.Page
    {
        private static B_WorkScheduleBll bwsb = new B_WorkScheduleBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static ArrayList InitWorkSchedule(string mnum)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month;
                Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                if (sd != null)
                {
                    if (sd.dattr == "gc")
                    {
                        if (!bwsb.Exists(" and dcode='" + sd.dcode + "' and cyear=" + year + " and cmonth=" + month + ""))
                        {
                            bwsb.SaveList(sd.dname, sd.dcode, year, month);
                        }
                    }
                    if (mnum != "")
                    {
                        month =Convert.ToInt32( mnum);
                        if (mnum == "1")
                        {
                            year = year + 1;
                        }
                    }
                    List<B_WorkSchedule> lbw = bwsb.QueryList("  and dcode='" + sd.dcode + "' and cyear=" + year + " and cmonth="+month+"");
                    if (lbw != null)
                    {
                        foreach (B_WorkSchedule b in lbw)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(b.id);
                            al.Add(b.title);
                            al.Add(b.btime);
                            al.Add(b.etime);
                            al.Add(b.color);
                            al.Add(b.classname);
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
        [WebMethod(true)]
        public static ArrayList InitNextWorkSchedule()
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int year = DateTime.Now.Year;
                int month = DateTime.Now.Month+1;
                Sys_Depment sd = sdb.Query(" and dcode='" + iv.u.dcode + "'");
                if (sd != null)
                {
                    if (sd.dattr == "gc")
                    {
                        if (!bwsb.Exists(" and dcode='" + sd.dcode + "' and cyear=" + year + " and cmonth=" + month + ""))
                        {
                            bwsb.SaveList(sd.dname, sd.dcode, year, month);
                        }
                    }
                    List<B_WorkSchedule> lbw = bwsb.QueryList("  and dcode='" + sd.dcode + "' and cyear=" + year + " ");
                    if (lbw != null)
                    {
                        foreach (B_WorkSchedule b in lbw)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(b.id);
                            al.Add(b.title);
                            al.Add(b.btime);
                            al.Add(b.etime);
                            al.Add(b.color);
                            al.Add(b.classname);
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
        [WebMethod(true)]
        public static string SaveWorkSchedule(string dcode, string wdate, string wtype)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd = sdb.Query(" and dcode='" +dcode + "'");
                if (sd != null)
                {
                    int year = Convert.ToDateTime(wdate).Year;
                    int month = Convert.ToDateTime(wdate).Month;
                    B_WorkSchedule bws = new B_WorkSchedule();
                    bws.dcode = sd.dcode;
                    bws.dname = sd.dname;
                    bws.color = "green";
                    bws.cmonth = month;
                    bws.cyear = year;
                    bws.classname = "";
                    bws.cdate = DateTime.Now.ToString();
                    bws.curdate = wdate;
                    if (wtype == "上午生产")
                    {
                        bws.title = "上午生产";
                        bws.btime = wdate + " 07:30:00";
                        bws.etime = wdate + " 11:30:00";
                    }
                    if (wtype == "下午生产")
                    {
                        bws.title = "下午生产";
                        bws.btime = wdate + " 13:30:00";
                        bws.etime = wdate + " 17:30:00";
                    }
                    if (wtype == "晚上生产")
                    {
                        bws.title = "晚上生产";
                        bws.btime = wdate + " 19:00:00";
                        bws.etime = wdate + " 23:00:00";
                    }
                    bwsb.Delete(" and dcode='" + sd.dcode + "' and curdate='" + wdate + "' and title='" + wtype + "'");
                    if (bwsb.Add(bws) > 0)
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
        [WebMethod(true)]
        public static ArrayList QueryDayWorkSchedule(string dcode, string wdate)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                if (sd != null)
                {
                    List<B_WorkSchedule> lbw = bwsb.QueryList("  and dcode='" + sd.dcode + "' and curdate='" + wdate + "'");
                    if (lbw != null)
                    {
                        foreach (B_WorkSchedule b in lbw)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(b.id);
                            al.Add(b.title);
                            al.Add(b.btime);
                            al.Add(b.etime);
                            al.Add(b.color);
                            al.Add(b.classname);
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
        [WebMethod(true)]
        public static string DelWorkSchedule(string id)
        {
            string r ="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bwsb.Delete("  and id=" + id + ""))
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
    }
}