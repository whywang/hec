using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.StatisticsBusiness.OrderTj
{
    public partial class AfterOrderTjs : System.Web.UI.Page
    {
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static B_AfterGroupProductionBll bgb = new B_AfterGroupProductionBll();
        private static  Sys_AreaBll sab = new Sys_AreaBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获反馈订单统计
        [WebMethod(true)]
        public static string QueryOrderTj(string bdate,  string edate, string emcode,string pzt, string tabcode)
        {
            string r = "";
            StringBuilder hstr= new StringBuilder ();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    string b = "";
                    string e = "";
                    if (bdate == null || bdate == "")
                    {
                        b = CommonBll.GetBdate2();
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate); ;
                    }
                    if (pzt != "")
                    {
                        if (pzt == "scz")
                        {
                            where.Append(" and sid in (select sid from CB_orderflow where wcode='0094' and state<1)");
                        }
                        if (pzt == "ysc")
                        {
                            where.Append(" and sid in (select sid from CB_orderflow where wcode='0094' and state=1)");
                        }
                    }
                    string sqlw = svt.sqlcondition.Replace("[dcode]", iv.u.dcode).Replace("[bdate]", b).Replace("[edate]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by scode desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            int rnum = 0;
                            List<B_AfterGroupProduction> lbp=bgb.QueryList(" and sid='" + dr["sid"].ToString() + "' order by id asc");
                            if (lbp != null)
                            {
                                rnum = lbp.Count;
                            }
                            
                            hstr.Append("<tr>");
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>",rnum, i.ToString());
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["scode"].ToString());
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["oscode"].ToString());
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["dname"].ToString());
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["customer"].ToString());
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["isfc"].ToString() =="True"?"是":"否");
                            hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, dr["adremark"].ToString());
                             if (rnum> 0)
                            {
                                hstr.AppendFormat("<td>{0}</td>", "1." + lbp[0].place);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].itype);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].sitype);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].msname);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].direction);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].stype);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].height.ToString() + "*" + lbp[0].width.ToString() + "*" + lbp[0].deep.ToString());
                                if (lbp[0].itype == "门板")
                                {
                                    hstr.AppendFormat("<td>{0}</td>", lbp[0].deep.ToString());
                                }
                                else
                                {
                                    hstr.AppendFormat("<td>{0}</td>", lbp[0].pmsd.ToString());
                                }
                               // hstr.AppendFormat("<td>{0}</td>", lbp[0].pnum.ToString());
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].mname);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].glass);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].gsize);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].fixs);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].locks);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].workform);
                                hstr.AppendFormat("<td>{0}</td>", lbp[0].pname+lbp[0].remark);
                                hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum, CommonBll.GetBdate(dr["scdate"].ToString()));
                                hstr.AppendFormat("<td rowspan='{0}'>{1}</td>", rnum,CommonBll.GetBdate( dr["sodate"].ToString()));
                           
                            }
                            else
                            {
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                      
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                                hstr.AppendFormat("<td>{0}</td>", "");
                            }
                            hstr.Append("</tr>");
                            if (rnum > 1)
                            {
                                int pxh = 2;
                                for (int k = 1; k < rnum; k++)
                                {
                                    hstr.Append("<tr>");
                                    hstr.AppendFormat("<td>{0}</td>", pxh.ToString() + "." + lbp[k].place);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].itype);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].sitype);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].msname);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].direction);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].stype);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].height.ToString() + "*" + lbp[k].width.ToString() + "*" + lbp[k].deep.ToString());
                                    if (lbp[k].itype == "门板")
                                    {
                                        hstr.AppendFormat("<td>{0}</td>", lbp[k].deep.ToString());
                                    }
                                    else
                                    {
                                        hstr.AppendFormat("<td>{0}</td>", lbp[k].pmsd.ToString());
                                    }
                            
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].mname);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].glass);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].gsize);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].fixs);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].locks);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].workform);
                                    hstr.AppendFormat("<td>{0}</td>", lbp[k].pname + lbp[k].remark);
                                    hstr.Append("</tr>");
                                    pxh++;
                                }
                            }
                            i++;
                        }
                    }
                    r = hstr.ToString();
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