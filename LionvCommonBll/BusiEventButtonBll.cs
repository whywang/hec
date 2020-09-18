using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;
using LionvBll.SysInfo;

namespace LionvCommonBll
{
   public class BusiEventButtonBll
    {
       private ISys_ButtonDal sbtn = DataAccess.CreateSys_Button();
       private ISys_WorkEventDal swed = DataAccess.CreateSys_WorkEvent();
       private ICB_OrderFlowDal cof = BusiCommonAccess.CreateCB_OrderFlow();
       private ICB_OrderStateDal dal = BusiCommonAccess.CreateCB_OrderState();
       private Sys_DomainBll sdb = new Sys_DomainBll();
       private Sys_BtnImgBll sbib = new Sys_BtnImgBll();
       #region///获取列表页Button
       public List<Sys_Button> QueryBtnList(string emcode, string rcode, string btype)
       {
           List<Sys_Button> r = new List<Sys_Button>();
           List<Sys_Button> lst = new List<Sys_Button>();
           StringBuilder whbtn = new StringBuilder();
           if (rcode == "xtgl")
           {
               whbtn.AppendFormat(" and emcode='{0}' and btype='{1}'", emcode, btype);
           }
           else
           {
               whbtn.AppendFormat(" and bcode in ( select bcode from Sys_RRoleButton where rcode='{0}' and ecode='{1}') and btype='{2}'   ", rcode, emcode, btype);
           }
           lst = sbtn.QueryList(whbtn.ToString());
           if (lst != null)
           {
               foreach (Sys_Button s in lst)
               {
                   if (s.bsql != "")
                   {
                       string esql = s.bsql;
                       if (CheckBtnSql(esql))
                       {
                           r.Add(s);
                       }
                   }
                   else
                   {
                       r.Add(s);
                   }
               }
           }
           return r;
       }
       #endregion
       #region///获取列表页Button增加页面页签
       public List<Sys_Button> QueryBtnListEx(string emcode, string rcode, string btype,string tab)
       {
           List<Sys_Button> r = new List<Sys_Button>();
           List<Sys_Button> lst = new List<Sys_Button>();
           StringBuilder whbtn = new StringBuilder();
           if (rcode == "xtgl")
           {
               whbtn.AppendFormat(" and emcode='{0}' and btype='{1}'", emcode, btype);
           }
           else
           {
               whbtn.AppendFormat(" and bcode in ( select bcode from Sys_RRoleButton where rcode='{0}' and ecode='{1}') and btype='{2}' and bshow='true' and (btab='' or btab='{3}')   ", rcode, emcode, btype,tab);
           }
           lst = sbtn.QueryList(whbtn.ToString());
           if (lst != null)
           {
               foreach (Sys_Button s in lst)
               {
                   if (s.bsql != "")
                   {
                       string esql = s.bsql;
                       if (CheckBtnSql(esql))
                       {
                           r.Add(s);
                       }
                   }
                   else
                   {
                       r.Add(s);
                   }
               }
           }
           return r;
       }
       #endregion
       #region///获取列表项Button
       public string QueryBtnListItems(string emcode, string rcode, string btype, string sid)
        {
            List<Sys_Button> lst = new List<Sys_Button>();
            List<Sys_Button> rb = new List<Sys_Button>();
            StringBuilder whbtn = new StringBuilder();
            StringBuilder whpoint = new StringBuilder();
            StringBuilder r = new StringBuilder();
            if (rcode == "xtgl")
            {
                whbtn.AppendFormat(" and emcode='{0}' and btype='{1}'", emcode, btype);
            }
            else
            {
                whbtn.AppendFormat(" and bcode in ( select bcode from Sys_RRoleButton where rcode='{0}' and ecode='{1}') and btype='{2}'   ", rcode, emcode, btype);
            }
            lst = sbtn.QueryList(whbtn.ToString());
            if (lst != null)
            {
                foreach (Sys_Button b in lst)
                {
                    if (b.rwcode != "")
                    {
                        if (b.bstate == 0)
                        {
                            whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state<=0", b.remcode, b.rwcode, sid);
                        }
                        if (b.bstate == 1)
                        {
                            whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state=1", b.remcode, b.rwcode, sid);
                        }
                        if (cof.IsDid(whpoint.ToString()))
                        {
                            if (b.bsql != "")
                            {
                                string esql = b.bsql.Replace("[ID]", sid);
                                if (CheckBtnSql(esql))
                                {
                                    rb.Add(b);
                                }
                            }
                            else
                            {
                                rb.Add(b);
                            }
                        }
                    }
                    else
                    {
                        if (b.bsql != "")
                        {
                            string esql = b.bsql.Replace("[ID]", sid);
                            if (CheckBtnSql(esql))
                            {
                                rb.Add(b);
                            }
                        }
                        else
                        {
                            rb.Add(b);
                        }
                    }
                }
            }
            if (rb != null)
            {
                Sys_Domain sd = sdb.Query(" and dtype='p'");
                string url = sd != null ? sd.url : "";
                foreach (Sys_Button b in rb)
                {
                    string f = b.bfn.Replace("[ID]", sid.ToString()).Replace("[Url]", b.burl).Replace(",", "&#44;");
                    if (b.bico == "")
                    {
                        r.AppendFormat("<button  onclick=\"{0}\">{1}</button> &nbsp;&nbsp;", f, b.bname);
                    }
                    else
                    {
                        Sys_BtnImg sbi = sbib.Query(" and bcode='" + b.bico + "'");
                        if (sbi != null)
                        {
                            r.AppendFormat("<button  onclick=\"{0}\"><img src='{1}' style='width:16px; height:16px' alt=''/> &nbsp;{2}</button> &nbsp;&nbsp;", f, url + sbi.burl, b.bname);
                        }
                        else
                        {
                            r.AppendFormat("<button  onclick=\"{0}\">{1}</button> &nbsp;&nbsp;", f, b.bname);
                        }
                    }
                }
            }
            return r.ToString();
        }
       #endregion
       #region///获取流程页Button
       public List<Sys_Button> QueryWorkFlowBtnList(string sid, string emcode, string rcode)
       {
           List<Sys_Button> Tfbtn = QueryFirstTsBtn(sid,emcode,rcode);
           List<Sys_Button> Tsbtn = new List<Sys_Button> ();
           List<Sys_Button> QTbtn = new List<Sys_Button>();
           List<Sys_Button> Hbtn = new List<Sys_Button>();
           List<Sys_Button> b = new List<Sys_Button>();
           List<Sys_Button> r = new List<Sys_Button>();
           List<Sys_Button> sortbtn = new List<Sys_Button>();
           bool isflowbtn = false;
           if (Tfbtn == null)
           {
               CB_OrderState cos = dal.Query(" and sid='" + sid + "'");
               if (cos != null)
               {
                   if (cos.iover > 0)
                   {
                       isflowbtn = true;
                   }
                   if (cos.istop > 0)
                   {
                       isflowbtn = true;
                   }
                   if (cos.ichange > 0)
                   {
                       isflowbtn = true;
                   }
               }
               Tsbtn = QuerySecodeTsBtn(sid, emcode, rcode);
               QTbtn=QueryUnDoBtn(sid, emcode, rcode);
               Hbtn = QueryDoBtn(sid, emcode, rcode);
               //订单申请和已暂停，申请取消和已取消，申请更改和已更改则不再调研流程事件按钮
               if (isflowbtn)
               {
                   QTbtn =null;
                   Hbtn =null;
               }
               if (Tsbtn != null)
               {
                   foreach(Sys_Button s in Tsbtn)
                   {
                       b.Add(s);
                   }
               }
               if (QTbtn != null)
               {
                   foreach (Sys_Button s in QTbtn)
                   {
                       b.Add(s);
                   }
               }
               if (Hbtn != null)
               {
                   foreach (Sys_Button s in Hbtn)
                   {
                       b.Add(s);
                   }
               }
           }
           else
           {
               b = Tfbtn;
           }
           foreach (Sys_Button s in b)
           {
               if (s.bsql == "")
               {
                   sortbtn.Add(s);
               }
               else
               {
                   if (CheckBtnSql(s.bsql.Replace("[ID]", sid)))
                   {
                       sortbtn.Add(s);
                   }
               }
           }
           if (sortbtn.Count > 0)
           {
               r = sortbtn.OrderBy(s => s.bsort).ToList();
           }
           if (r.Count > 0)
           {
               return r;
           }
           else
           {
               return null;
           }
       }
       #endregion
       #region//获取新增页Button
       public List<Sys_Button> SinglePageBtnList(string sid, string emcode, string rcode)
       {
           StringBuilder whbtn = new StringBuilder();
           StringBuilder whpoint = new StringBuilder();
           List<Sys_Button> lst = new List<Sys_Button>();
           List<Sys_Button> rb = new List<Sys_Button>();
           if (rcode == "xtgl")
           {
               whbtn.AppendFormat(" and emcode='{0}' and bshow='true'", emcode);
           }
           else
           {
               whbtn.AppendFormat(" and emcode='{0}' and (brcode='{1}'or brcode='') and bshow='true'", emcode, rcode);
           }
           lst = sbtn.QueryList(whbtn.ToString());
           if (lst != null)
           {
               
               foreach (Sys_Button b in lst)
               {
                   if (ExpectRepeat(rb, b))
                   {
                       if (b.rwcode != "")
                       {
                           whpoint.Clear();
                           if (b.bstate == 0)
                           {
                               whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state<=0", b.remcode, b.rwcode, sid);
                           }
                           if (b.bstate == 1)
                           {
                               whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state=1", b.remcode, b.rwcode, sid);
                           }
                           #region //当流程不存在
                           if (b.bstate == 0)
                           {
                               CB_OrderFlow of = cof.Query(" and sid='" + sid + "'");
                               if (of == null)
                               {
                                   if (b.bsql != "")
                                   {
                                       string esql = b.bsql.Replace("[ID]", sid);
                                       if (CheckBtnSql(esql))
                                       {
                                           rb.Add(b);
                                       }
                                   }
                                   else
                                   {
                                       rb.Add(b);
                                   }
                               }
                           }
                           #endregion
                           #region //流程存在
                           if (cof.IsDid(whpoint.ToString()))
                           {
                               if (b.bsql != "")
                               {
                                   string esql = b.bsql.Replace("[ID]", sid);
                                   if (CheckBtnSql(esql))
                                   {
                                       rb.Add(b);
                                   }
                               }
                               else
                               {
                                   rb.Add(b);
                               }
                           }
                           #endregion
                       }
                       else
                       {
                           if (b.bsql != "")
                           {
                               string esql = b.bsql.Replace("[ID]", sid);
                               if (CheckBtnSql(esql))
                               {
                                   rb.Add(b);
                               }
                           }
                           else
                           {
                               rb.Add(b);
                           }
                       }
                   }
               }
           }
           return rb;
       }
       #endregion
       #region//获取详情项Button
       public string ItemsBtnList(string sid,string gnum, string emcode, string rcode)
       {
           StringBuilder r = new StringBuilder ();
           StringBuilder whbtn = new StringBuilder();
           StringBuilder whpoint = new StringBuilder();
           List<Sys_Button> lst = new List<Sys_Button>();
           List<Sys_Button> rb = new List<Sys_Button>();
           if (rcode == "xtgl")
           {
               whbtn.AppendFormat(" and emcode='{0}'", emcode);
           }
           else
           {
               whbtn.AppendFormat(" and emcode='{0}' and (brcode='{1}'or brcode='') ", emcode, rcode);
           }
           lst = sbtn.QueryList(whbtn.ToString());
           if (lst != null)
           {
               foreach (Sys_Button b in lst)
               {
                   if (b.rwcode != "")
                   {
                       whpoint.Clear();
                       if (b.bstate == 0)
                       {
                           whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state<=0", b.remcode, b.rwcode, sid);
                       }
                       if (b.bstate == 1)
                       {
                           whpoint.AppendFormat(" and emcode='{0}' and wcode='{1}' and sid='{2}' and state=1", b.remcode, b.rwcode, sid);
                       }
                       #region //当流程不存在
                       //if (b.bstate == 0)
                       //{
                       //    CB_OrderFlow of = cof.Query(" and sid='" + sid + "'");
                       //    if (of == null)
                       //    {
                       //        if (b.bsql != "")
                       //        {
                       //            string esql = b.bsql.Replace("[ID]", sid);
                       //            if (CheckBtnSql(esql))
                       //            {
                       //                rb.Add(b);
                       //            }
                       //        }
                       //        else
                       //        {
                       //            rb.Add(b);
                       //        }
                       //    }
                       //}
                       #endregion
                       #region //流程存在
                       if (cof.IsDid(whpoint.ToString()))
                       {
                           if (b.bsql != "")
                           {
                               string esql = b.bsql.Replace("[ID]", sid).Replace("[Gnum]", gnum);
                               if (CheckBtnSql(esql))
                               {
                                   rb.Add(b);
                               }
                           }
                           else
                           {
                               rb.Add(b);
                           }
                       }
                       #endregion
                   }
                   else
                   {
                       if (b.bsql != "")
                       {
                           string esql = b.bsql.Replace("[ID]", sid).Replace("[Gnum]",gnum);
                           if (CheckBtnSql(esql))
                           {
                               rb.Add(b);
                           }
                       }
                       else
                       {
                           rb.Add(b);
                       }
                   }
               }
           }
           if (rb != null)
           {
               foreach (Sys_Button b in rb)
               {
                   string f = b.bfn.Replace("[ID]", sid.ToString()).Replace("[Url]", b.burl).Replace("[Gnum]", gnum).Replace(",", "&#44;");
                   r.AppendFormat("<button class='dbtn' onclick=\"{0}\">{1}</button> &nbsp;&nbsp;", f, b.bname);
               }
           }
           //string bb = "EditProduction('[Gnum]')".Replace("[ID]", sid.ToString()).Replace("[Url]", "").Replace("[Gnum]", gnum).Replace(",", "&#44;");
           //StringBuilder bbb = new StringBuilder();
           //bbb.AppendFormat("<button class='dbtn' onclick=\"{0}\">{1}</button>", bb, "编辑");
           //return r.ToString() + bbb.ToString();
            return r.ToString();
       }
       #endregion
       #region// 私有方法
       public bool CheckBtnSql(string sql)
        {
            bool f = true;
            string[] sqlarr = sql.Split(';');
            for (int i = 0; i < sqlarr.Length; i++)
            {
                if (sqlarr[i] == "")
                {
                }
                else
                {
                    if (!sbtn.CheckBtnSql(sqlarr[i]))
                    {
                        f = false;
                        break;
                    }
                }
            }
            return f;
        }
       private List<Sys_Button> QueryFirstTsBtn(string sid,string emcode,string rcode)
       {
           List<Sys_Button> lsb = new List<Sys_Button>();
           List<Sys_Button> albtn = sbtn.QueryList(" and bshow='true' and emcode='" + emcode + "' and (brcode='" + rcode + "' or brcode='') and bspeattr=2 ");
           if (albtn != null)
           {
               foreach (Sys_Button s in albtn)
               {
                   if (s.bsql != "")
                   {
                       if (CheckBtnSql(s.bsql.Replace("[ID]", sid)))
                       {
                           lsb.Add(s);
                       }
                   }
                   else
                   {
                       lsb.Add(s);
                   }
               }
           }
           return lsb.Count > 0 ? lsb : null;
       }
       private List<Sys_Button> QuerySecodeTsBtn(string sid, string emcode, string rcode)
       {
           List<Sys_Button> lsb = new List<Sys_Button>();
           List<Sys_Button> albtn = sbtn.QueryList(" and bshow='true' and emcode='" + emcode + "' and (brcode='" + rcode + "' or brcode='') and bspeattr=1 ");
           if (albtn != null)
           {
               foreach (Sys_Button s in albtn)
               {
                   if (s.bsql != "")
                   {
                       if (CheckBtnSql(s.bsql.Replace("[ID]", sid)))
                       {
                           lsb.Add(s);
                       }
                   }
                   else
                   {
                       lsb.Add(s);
                   }
               }
           }
           return lsb ;
       }
       private List<Sys_Button> QueryUnDoBtn(string sid, string emcode, string rcode)
       {
           List<Sys_Button> wclbtn = new List<Sys_Button>();
           CB_OrderFlow cbof = cof.Query(" and state<1 and emcode='" + emcode + "' and sid='" + sid + "' order by id asc");
           if (cbof != null)
           {
               Sys_WorkEvent swe = swed.Query(" and wcode='" + cbof.wcode + "'");
               if (swe != null)
               {
                   if (swe.wrwcode == "")
                   {
                       wclbtn = sbtn.QueryList(" and wcode='" + cbof.wcode + "' and btype='W' and ( battr='T' or battr='Q') and brcode='" + rcode + "' and bshow='true'");
                   }
                   else
                   {
                       CB_OrderFlow reforderflow = cof.Query("and state<1 and emcode='" + swe.wremcode + "' and sid='" + sid + "' order by id asc");
                       if (reforderflow.wcode == swe.wrwcode)
                       {
                           wclbtn = sbtn.QueryList(" and wcode='" + cbof.wcode + "' and btype='W' and ( battr='T' or battr='Q') and brcode='" + rcode + "'  and bshow='true'");
                       }
                   }
               }
           }
           return wclbtn ;
       }
       private List<Sys_Button> QueryDoBtn(string sid, string emcode, string rcode)
       {
           List<Sys_Button> wclbtn = new List<Sys_Button>();
           CB_OrderFlow cbof = cof.Query(" and state=1 and emcode='" + emcode + "' and sid='" + sid + "' order by id desc");
           if (cbof != null)
           {
               wclbtn = sbtn.QueryList(" and wcode='" + cbof.wcode + "' and btype='W' and  battr='H'   and brcode='" + rcode + "'  and bshow='true'");
           }
           return wclbtn ;
       }
       private bool ExpectRepeat(List<Sys_Button> lsb ,Sys_Button sb)
       {
           bool r = false;
           if (lsb.Count > 0)
           {
               foreach(Sys_Button csb in lsb)
               {
                   if (csb.bname== sb.bname)
                   {
                       r = false;
                       break;
                   }
                   r = true;
               }
           }
           else
           {
               r = true;
           }
           return r;
       }
       #endregion
    }
}
