using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using LionvBll.BusiOrderInfo;
using LionvBll.StatisticsInfo;
using System.Data;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvCommonBll
{
   public class BusiiOptimitsBll
    {
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private T_StatisticsBll tsb = new T_StatisticsBll();
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       private Sys_OptimizeBll sob = new Sys_OptimizeBll();
       private B_ProductionItemBll bpib = new B_ProductionItemBll();
       private B_PackageBll bpb = new B_PackageBll();
       private Code128 c128 = new Code128();
       //销售产品优化
       public ArrayList ListOptProduction(string ptype,string mcode,string sortstr,string bdate,string edate)
       {
           ArrayList r = new ArrayList();
           StringBuilder where = new StringBuilder();
           StringBuilder sort = new StringBuilder();
           Sys_Optimize so=sob.Query(" and ocode='" + ptype + "'");
           if (mcode != "")
           {
               where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_Material] where mcode like '{0}%')", mcode);
           }
           if (ptype != "")
           {
               where.AppendFormat(" and icode in (select pcode from [LvErpBase].[dbo].[Sys_RInventoryOptimize] where ocode='{0}')", ptype);
           }
           if (bdate != "")
           {
               where.AppendFormat(" and osid in (select sid from CB_OrderFlow where wcode='0008' and   edate  >=  '{0}')", bdate);
           }
           if (edate != "")
           {
               where.AppendFormat(" and osid in (select sid from CB_OrderFlow where wcode='0008' and  edate  <=  '{0}')", edate);
           }
           if (ptype == "0001")
           {
               sortstr = "ccyx";
           }
           if (ptype == "0005")
           {
               sortstr = "lx";
           }
           if (sortstr == "xhyx" || sortstr == "")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by  omname ,width  ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by  mname ,width  ,gid asc");
               }
           }
           if (sortstr == "czyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by  omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by  mname ,width ,gid asc");
               }
           }
           if (sortstr == "ccyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "lx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,osid,gnum ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,osid,gnum ,gid asc");
               }
           }
           if (so != null)
           {
               switch (so.stype)
               {
                   case "ms":
                       r = SaleGetMsOpts(where.ToString(), sort.ToString());
                       break;
                   case "mt":
                       r = SaleGetMtOpts(where.ToString(), sort.ToString());
                       break;
                   case "tb":
                       r = SaleGetTbOpts(where.ToString(), sort.ToString());
                       break;
                   case "tlx":
                       r = SaleGetLxOpts(where.ToString(), sort.ToString());
                       break;
                   case "dlx":
                       r = SaleGetDQtOpts(where.ToString(), sort.ToString());
                       break;
                   case "qt":
                       r = SaleGetQtOpts(where.ToString(), sort.ToString());
                       break;
               }
           }
           return r;
       }
       private ArrayList SaleGetMsOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();

           DataTable dt = tsb.QueryList("View_Tj_Mstj", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction bl = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '05%'");
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   al.Add(bpb.QueryPackageCodeEx(dr["psid"].ToString(), "P", dr["height"].ToString(),dr["width"].ToString()));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   al.Add(dr["height"].ToString());
                   al.Add(dr["width"].ToString());
                   al.Add(dr["pnum"].ToString());
                   if ((dr["icode"].ToString().Substring(0, 4) == "0103" || dr["icode"].ToString().Substring(0, 4) == "0102") && dr["e_ptype"].ToString() == "s")
                   {
                       al.Add("");
                       al.Add("");
                       al.Add(dr["locktype"].ToString());
                       al.Add(CommonBll.DirectionFormat(dr["direction"].ToString()));
                   }
                   else
                   {
                       al.Add(bl == null ? "" : bl.iname);
                       al.Add(dr["locks"].ToString()!=""?dr["locks"].ToString():sj == null ? "" : sj.iname);
                       al.Add(dr["locktype"].ToString());
                       al.Add(dr["direction"].ToString());
                   }
                  
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["isjc"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + bpb.QueryPackageCode(dr["psid"].ToString(), "P","") + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetMtOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   B_ProductionItem ms = bpib.Query(" and psid=(select psid from B_GroupProduction where sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '01%')");
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   if (ms != null)
                   {
                       al.Add(ms.pname);
                       al.Add(ms.height);
                       al.Add(ms.width);
                       al.Add(ms.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (ht != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                            al.Add("一号横挺");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("二号横挺");
                       }
                       else
                       {
                           al.Add("横挺");
                       }
                       
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("双门档线");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("垭口");
                       }
                       else
                       {
                           al.Add("竖挺");
                       }
 
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(sj == null ? "" : sj.iname);
                   al.Add(dr["locktype"].ToString());
                   al.Add(dr["direction"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetTbOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横挺");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖挺");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetLxOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='stl'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='ltl'");
                   B_ProductionItem lx = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lx'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横L线");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       if (lx != null)
                       {
                           al.Add("L线");
                           al.Add(lx.height);
                           al.Add(lx.width);
                           al.Add(lx.deep);
                           al.Add(lx.pnum);
                       }
                       else
                       {
                           al.Add("横L线");
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }
                   }
                   if (st != null)
                   {
                       al.Add("竖L线");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("竖L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetQtOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   string icode=dr["icode"].ToString();
                   if (icode.Substring(0, 2) == "02")
                   {
                       #region//处理门套待挡轨线
                       ArrayList al = new ArrayList();
                       B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='tlh'");
                       if (ht != null)
                       {
                           string dgxname = "";
                           if (icode.Substring(0, 4) == "0202")
                           {
                               dgxname = "3号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0203")
                           {
                               dgxname = "2号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0206")
                           {
                               dgxname = "挡轨线";
                           }
                           al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                           al.Add(i);
                           al.Add(dr["gnum"].ToString());
                           al.Add(dr["customer"].ToString());
                           al.Add(dr["scode"].ToString());
                           al.Add(dr["fix"].ToString());
                           al.Add(dr["place"].ToString());
                           al.Add(dgxname);
                           al.Add(ht.height);
                           al.Add(ht.width);
                           al.Add(ht.deep);
                           al.Add(ht.pnum);
                           al.Add(dr["mname"].ToString());
                           al.Add(dr["ps"].ToString());
                           al.Add(dr["e_city"].ToString());
                           al.Add(dr["cdate"].ToString());
                           al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                           r.Add(al);
                           i = i + 1;
                       }
                       #endregion
                   }
                   else
                   {
                       ArrayList al = new ArrayList();
                       B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");

                       al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                       al.Add(i);
                       al.Add(dr["gnum"].ToString());
                       al.Add(dr["customer"].ToString());
                       al.Add(dr["scode"].ToString());
                       al.Add(dr["fix"].ToString());
                       al.Add(dr["place"].ToString());
                       al.Add(dr["iname"].ToString());
                       if (qt != null)
                       {
                           al.Add(qt.height);
                           al.Add(qt.width);
                           al.Add(qt.deep);
                           al.Add(qt.pnum);
                       }
                       else
                       {
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }

                       al.Add(dr["mname"].ToString());
                       al.Add(dr["ps"].ToString());
                       al.Add(dr["e_city"].ToString());
                       al.Add(dr["cdate"].ToString());
                       al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                       r.Add(al);
                       i = i + 1;
                   }
                   
               }
           }
           return r;
       }
       private ArrayList SaleGetDQtOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                       ArrayList al = new ArrayList();
                       B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");

                       al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                       al.Add(i);
                       al.Add(dr["gnum"].ToString());
                       al.Add(dr["customer"].ToString());
                       al.Add(dr["scode"].ToString());
                       al.Add(dr["fix"].ToString());
                       al.Add(dr["place"].ToString());
                       al.Add(dr["iname"].ToString());
                       if (qt != null)
                       {
                           al.Add(qt.height);
                           al.Add(qt.width);
                           al.Add(qt.deep);
                           al.Add(qt.pnum);
                       }
                       else
                       {
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }
                       al.Add(dr["omname"].ToString());
                       al.Add(dr["ps"].ToString());
                       al.Add(dr["e_city"].ToString());
                       al.Add(dr["cdate"].ToString());
                       al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                       r.Add(al);
                       i = i + 1;
               }
           }
           return r;
       }
       //售后产品优化
       public ArrayList ListOptAProduction(string ptype, string mcode, string sortstr, string bdate, string edate)
       {
           ArrayList r = new ArrayList();
           StringBuilder where = new StringBuilder();
           StringBuilder sort = new StringBuilder();
           Sys_Optimize so = sob.Query(" and ocode='" + ptype + "'");
           if (mcode != "")
           {
               where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_Material] where mcode like '{0}%')", mcode);
           }
           if (ptype != "")
           {
               where.AppendFormat(" and icode in (select pcode from [LvErpBase].[dbo].[Sys_RInventoryOptimize] where ocode='{0}')", ptype);
           }
           if (bdate != "")
           {
               where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0022' and   edate  >=  '{0}')", bdate);
           }
           if (edate != "")
           {
               where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0022' and  edate  <=  '{0}')", edate);
           }
           if (sortstr == "xhyx" || sortstr == "")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width,gid asc");
               }
           }
           if (sortstr == "czyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width,gid asc");
               }
           }
           if (sortstr == "ccyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width,gid asc");
               }
           }
           if (sortstr == "lx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,sid,gnum,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,sid,gnum,gid asc");
               }
               
           }
           if (so != null)
           {
               switch (so.stype)
               {
                   case "ms":
                       r = ASaleGetMsOpts(where.ToString(), sort.ToString());
                       break;
                   case "mt":
                       r = ASaleGetMtOpts(where.ToString(), sort.ToString());
                       break;
                   case "tb":
                       r = ASaleGetTbOpts(where.ToString(), sort.ToString());
                       break;
                   case "tlx":
                       r = ASaleGetLxOpts(where.ToString(), sort.ToString());
                       break;
                   case "qt":
                       r = ASaleGetQtOpts(where.ToString(), sort.ToString());
                       break;
                   case "dlx":
                       r = ASaleGetDLxOpts(where.ToString(), sort.ToString());
                       break;
               }
           }
           return r;
       }
       private ArrayList ASaleGetMsOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();

           DataTable dt = tsb.QueryList("View_Tj_AMstj", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction bl = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '05%'");
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   al.Add(bpb.QueryPackageCodeEx(dr["psid"].ToString(), "P", dr["height"].ToString(), dr["width"].ToString()));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   al.Add(dr["height"].ToString());
                   al.Add(dr["width"].ToString());
                   al.Add(dr["pnum"].ToString());
                   if ((dr["icode"].ToString().Substring(0, 4) == "0103" || dr["icode"].ToString().Substring(0, 4) == "0102") && dr["e_ptype"].ToString() == "s")
                   {
                       al.Add("");
                       al.Add("");
                       al.Add(dr["locktype"].ToString());
                       al.Add(CommonBll.DirectionFormat(dr["direction"].ToString()));
                   }
                   else
                   {
                       al.Add(bl == null ? "" : bl.iname);
                       al.Add(dr["locks"].ToString() != "" ? dr["locks"].ToString() : sj == null ? "" : sj.iname);
                       al.Add(dr["locktype"].ToString());
                       al.Add(dr["direction"].ToString());
                   }

                   al.Add(dr["mname"].ToString());
                   al.Add(dr["isjc"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + bpb.QueryPackageCode(dr["psid"].ToString(), "P","") + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetMtOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   B_ProductionItem ms = bpib.Query(" and psid=(select psid from B_GroupProduction where sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '01%')");
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   if (ms != null)
                   {
                       al.Add(ms.pname);
                       al.Add(ms.height);
                       al.Add(ms.width);
                       al.Add(ms.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (ht != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("一号横挺");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("二号横挺");
                       }
                       else
                       {
                           al.Add("横挺");
                       }

                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("双门档线");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("垭口");
                       }
                       else
                       {
                           al.Add("竖挺");
                       }

                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(sj == null ? "" : sj.iname);
                   al.Add(dr["locktype"].ToString());
                   al.Add(dr["direction"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetTbOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横挺");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖挺");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetLxOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and  e_ptype='stl'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='ltl'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横L线");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖L线");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("竖L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetQtOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   string icode=dr["icode"].ToString();
                   if (icode.Substring(0, 2) == "02")
                   {
                       #region//处理门套待挡轨线
                       ArrayList al = new ArrayList();
                       B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='tlh'");
                       if (ht != null)
                       {
                           string dgxname = "";
                           if (icode.Substring(0, 4) == "0202")
                           {
                               dgxname = "3号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0203")
                           {
                               dgxname = "2号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0206")
                           {
                               dgxname = "挡轨线";
                           }
                           al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                           al.Add(i);
                           al.Add(dr["gnum"].ToString());
                           al.Add(dr["customer"].ToString());
                           al.Add(dr["scode"].ToString());
                           al.Add(dr["fix"].ToString());
                           al.Add(dr["place"].ToString());
                           al.Add(dgxname);
                           al.Add(ht.height);
                           al.Add(ht.width);
                           al.Add(ht.deep);
                           al.Add(ht.pnum);
                           al.Add(dr["mname"].ToString());
                           al.Add(dr["ps"].ToString());
                           al.Add(dr["e_city"].ToString());
                           al.Add(dr["cdate"].ToString());
                           al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                           r.Add(al);
                           i = i + 1;
                       }
                       #endregion
                   }
                   else
                   {
                       ArrayList al = new ArrayList();
                       B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                       al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                       al.Add(i);
                       al.Add(dr["gnum"].ToString());
                       al.Add(dr["customer"].ToString());
                       al.Add(dr["scode"].ToString());
                       al.Add(dr["fix"].ToString());
                       al.Add(dr["place"].ToString());
                       al.Add(dr["iname"].ToString());
                       if (qt != null)
                       {
                           al.Add(qt.height);
                           al.Add(qt.width);
                           al.Add(qt.width);
                           al.Add(qt.pnum);
                       }
                       else
                       {
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }
                       al.Add(dr["mname"].ToString());
                       al.Add(dr["ps"].ToString());
                       al.Add(dr["e_city"].ToString());
                       al.Add(dr["cdate"].ToString());
                       al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                       r.Add(al);
                       i = i + 1;
                   }
               }
           }
           return r;
       }
       private ArrayList ASaleGetDLxOpts(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                   al.Add("P" + dr["gid"].ToString().PadLeft(8, '0'));
                   al.Add(i);
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (qt != null)
                   {
                       al.Add(qt.height);
                       al.Add(qt.width);
                       al.Add(qt.deep);
                       al.Add(qt.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }

                   al.Add(dr["omname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   al.Add(dr["cdate"].ToString());
                   al.Add("<button  onclick=\"PrintLab(\'tr" + "P" + dr["gid"].ToString().PadLeft(8, '0') + "\')\">打印标签</button>");
                   r.Add(al);
                   i = i + 1;
               }
           }
           return r;
       }
       //销售产品包装
       public ArrayList ListPackageProduction(string ptype, string mcode, string sortstr, string bdate, string edate)
       {
           ArrayList r = new ArrayList();
           StringBuilder where = new StringBuilder();
           StringBuilder sort = new StringBuilder();
           Sys_Optimize so = sob.Query(" and ocode='" + ptype + "'");
           if (mcode != "")
           {
               where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_Material] where mcode like '{0}%')", mcode);
           }
           if (ptype != "")
           {
               where.AppendFormat(" and icode in (select pcode from [LvErpBase].[dbo].[Sys_RInventoryOptimize] where ocode='{0}')", ptype);
           }
           if (bdate != "")
           {
               where.AppendFormat(" and osid in (select sid from CB_OrderFlow where wcode='0008' and   edate  >=  '{0}')", bdate);
           }
           if (edate != "")
           {
               where.AppendFormat(" and osid in (select sid from CB_OrderFlow where wcode='0008' and  edate  <=  '{0}')", edate);
           }
           if (ptype == "0001")
           {
               sortstr = "ccyx";
           }
           if (ptype == "0005")
           {
               sortstr = "lx";
           }
           if (sortstr == "xhyx" || sortstr == "")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "czyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "ccyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "lx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,osid,gnum ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,osid,gnum ,gid asc");
               }
           }
           if (so != null)
           {
               switch (so.stype)
               {
                   case "ms":
                       r = SaleGetMsPacs(where.ToString(), sort.ToString());
                       break;
                   case "mt":
                       r = SaleGetMtPacs(where.ToString(), sort.ToString());
                       break;
                   case "tb":
                       r = SaleGetTbPacs(where.ToString(), sort.ToString());
                       break;
                   case "tlx":
                       r = SaleGetLxPacs(where.ToString(), sort.ToString());
                       break;
                   case "qt":
                       r = SaleGetQtPacs(where.ToString(), sort.ToString());
                       break;
                   case "dlx":
                       r = SaleGetDQtPacs(where.ToString(), sort.ToString());
                       break;
               }
           }
           return r;
       }
       private ArrayList SaleGetMsPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();

           DataTable dt = tsb.QueryList("View_Tj_Mstj", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction bl = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '05%'");
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");

                   al.Add(i);
                   al.Add(bpb.QueryPackageCodeEx(dr["psid"].ToString(), "P", dr["height"].ToString(), dr["width"].ToString()));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   al.Add(dr["height"].ToString());
                   al.Add(dr["width"].ToString());
                   al.Add(dr["pnum"].ToString());
                   if ((dr["icode"].ToString().Substring(0, 4) == "0103" || dr["icode"].ToString().Substring(0, 4) == "0102") && dr["e_ptype"].ToString() == "s")
                   {
                       al.Add("");
                       al.Add("");
                       al.Add(dr["locktype"].ToString());
                       al.Add(CommonBll.DirectionFormat(dr["direction"].ToString()));
                   }
                   else
                   {
                       al.Add(bl == null ? "" : bl.iname);
                       al.Add(sj == null ? "" : sj.iname);
                       al.Add(dr["locktype"].ToString());
                       al.Add(dr["direction"].ToString());
                   }

                   al.Add(dr["mname"].ToString());
                   al.Add(dr["isjc"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetMtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   B_ProductionItem ms = bpib.Query(" and psid=(select psid from B_GroupProduction where sid='" + dr["osid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '01%')");
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "门套"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   if (ms != null)
                   {
                       al.Add(ms.pname);
                       al.Add(ms.height);
                       al.Add(ms.width);
                       al.Add(ms.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (ht != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("一号横挺");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("二号横挺");
                       }
                       else
                       {
                           al.Add("横挺");
                       }

                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("双门档线");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("垭口");
                       }
                       else
                       {
                           al.Add("竖挺");
                       }

                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(sj == null ? "" : sj.iname);
                   al.Add(dr["locktype"].ToString());
                   al.Add(dr["direction"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetTbPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "套板"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横挺");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖挺");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetLxPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='stl'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='ltl'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "L线"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横L线");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖L线");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("竖L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList SaleGetQtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   string icode=dr["icode"].ToString();
                   if (icode.Substring(0, 2) == "02")
                   {
                       #region//处理门套待挡轨线
                       ArrayList al = new ArrayList();
                       B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='tlh'");
                       if (ht != null)
                       {
                           string dgxname = "";
                           if (icode.Substring(0, 4) == "0202")
                           {
                               dgxname = "3号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0203")
                           {
                               dgxname = "2号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0206")
                           {
                               dgxname = "挡轨线";
                           }
                           al.Add(i);
                           al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "挡轨线"));
                           al.Add(dr["gnum"].ToString());
                           al.Add(dr["customer"].ToString());
                           al.Add(dr["scode"].ToString());
                           al.Add(dr["fix"].ToString());
                           al.Add(dr["place"].ToString());
                           al.Add(dgxname);
                           al.Add(ht.height);
                           al.Add(ht.width);
                           al.Add(ht.deep);
                           al.Add(ht.pnum);
                           al.Add(dr["mname"].ToString());
                           al.Add(dr["ps"].ToString());
                           al.Add(dr["e_city"].ToString());
                           r.Add(al);
                           i++;
                       }
                       #endregion
                   }
                   else
                   {
                       ArrayList al = new ArrayList();
                       B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                       al.Add(i);
                       al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", ""));
                       al.Add(dr["gnum"].ToString());
                       al.Add(dr["customer"].ToString());
                       al.Add(dr["scode"].ToString());
                       al.Add(dr["fix"].ToString());
                       al.Add(dr["place"].ToString());
                       al.Add(dr["iname"].ToString());
                       if (qt != null)
                       {
                           al.Add(qt.height);
                           al.Add(qt.width);
                           al.Add(qt.deep);
                           al.Add(qt.pnum);
                       }
                       else
                       {
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }
                       al.Add(dr["mname"].ToString());
                       al.Add(dr["ps"].ToString());
                       al.Add(dr["e_city"].ToString());
                       r.Add(al);
                       i++;
                   }
               }
           }
           return r;
       }
       private ArrayList SaleGetDQtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_Production", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", ""));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (qt != null)
                   {
                       al.Add(qt.height);
                       al.Add(qt.width);
                       al.Add(qt.deep);
                       al.Add(qt.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i = i + 1;
               }
           }
           return r;
       }
       //售后产品包装
       public ArrayList ListPackageAProduction(string ptype, string mcode, string sortstr, string bdate, string edate)
       {
           ArrayList r = new ArrayList();
           StringBuilder where = new StringBuilder();
           StringBuilder sort = new StringBuilder();
           Sys_Optimize so = sob.Query(" and ocode='" + ptype + "'");
           if (mcode != "")
           {
               where.AppendFormat(" and mname in (select mname from [LvErpBase].[dbo].[Sys_Material] where mcode like '{0}%')", mcode);
           }
           if (ptype != "")
           {
               where.AppendFormat(" and icode in (select pcode from [LvErpBase].[dbo].[Sys_RInventoryOptimize] where ocode='{0}')", ptype);
           }
           if (bdate != "")
           {
               where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0022' and   edate  >=  '{0}')", bdate);
           }
           if (edate != "")
           {
               where.AppendFormat(" and sid in (select sid from CB_OrderFlow where wcode='0022' and  edate  <=  '{0}')", edate);
           }
           if (sortstr == "xhyx" || sortstr == "")
           {
               
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "czyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "ccyx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,width ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,width ,gid asc");
               }
           }
           if (sortstr == "lx")
           {
               if (so.stype == "tlx" || so.stype == "dlx")
               {
                   //L线按订单材质排序
                   sort.AppendFormat(" order by omname ,sid,gnum ,gid asc");
               }
               else
               {
                   sort.AppendFormat(" order by mname ,sid,gnum ,gid asc");
               }
           }
           if (so != null)
           {
               switch (so.stype)
               {
                   case "ms":
                       r = ASaleGetMsPacs(where.ToString(), sort.ToString());
                       break;
                   case "mt":
                       r = ASaleGetMtPacs(where.ToString(), sort.ToString());
                       break;
                   case "tb":
                       r = ASaleGetTbPacs(where.ToString(), sort.ToString());
                       break;
                   case "tlx":
                       r = ASaleGetLxPacs(where.ToString(), sort.ToString());
                       break;
                   case "qt":
                       r = ASaleGetQtPacs(where.ToString(), sort.ToString());
                       break;
                   case "dlx":
                       r = ASaleGetDQtPacs(where.ToString(), sort.ToString());
                       break;
               }
           }
           return r;
       }
       private ArrayList ASaleGetMsPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AMstj", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction bl = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '05%'");
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");

                   al.Add(i);
                   al.Add(bpb.QueryPackageCodeEx(dr["psid"].ToString(), "P", dr["height"].ToString(), dr["width"].ToString()));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   al.Add(dr["height"].ToString());
                   al.Add(dr["width"].ToString());
                   al.Add(dr["pnum"].ToString());
                   if ((dr["icode"].ToString().Substring(0, 4) == "0103" || dr["icode"].ToString().Substring(0, 4) == "0102") && dr["e_ptype"].ToString() == "s")
                   {
                       al.Add("");
                       al.Add("");
                       al.Add(dr["locktype"].ToString());
                       al.Add(CommonBll.DirectionFormat(dr["direction"].ToString()));
                   }
                   else
                   {
                       al.Add(bl == null ? "" : bl.iname);
                       al.Add(sj == null ? "" : sj.iname);
                       al.Add(dr["locktype"].ToString());
                       al.Add(dr["direction"].ToString());
                   }

                   al.Add(dr["mname"].ToString());
                   al.Add(dr["isjc"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetMtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_GroupProduction sj = bgpb.Query(" and sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '0401%'");
                   B_ProductionItem ms = bpib.Query(" and psid=(select psid from B_GroupProduction where sid='" + dr["sid"].ToString() + "' and gnum=" + dr["gnum"].ToString() + " and icode like '01%')");
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "门套"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   if (ms != null)
                   {
                       al.Add(ms.pname);
                       al.Add(ms.height);
                       al.Add(ms.width);
                       al.Add(ms.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (ht != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("一号横挺");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("二号横挺");
                       }
                       else
                       {
                           al.Add("横挺");
                       }

                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       if (ht.pcode.Substring(0, 4) == "0202")
                       {
                           al.Add("双门档线");
                       }
                       else if (ht.pcode.Substring(0, 4) == "0203")
                       {
                           al.Add("垭口");
                       }
                       else
                       {
                           al.Add("竖挺");
                       }

                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(sj == null ? "" : sj.iname);
                   al.Add(dr["locktype"].ToString());
                   al.Add(dr["direction"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetTbPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_TjAProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='mt'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='lb'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "套板"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横挺");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖挺");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("横挺");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetLxPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='stl'");
                   B_ProductionItem st = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='ltl'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "L线"));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (ht != null)
                   {
                       al.Add("横L线");
                       al.Add(ht.height);
                       al.Add(ht.width);
                       al.Add(ht.deep);
                       al.Add(ht.pnum);
                   }
                   else
                   {
                       al.Add("横L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   if (st != null)
                   {
                       al.Add("竖L线");
                       al.Add(st.height);
                       al.Add(st.width);
                       al.Add(st.deep);
                       al.Add(st.pnum);
                   }
                   else
                   {
                       al.Add("竖L线");
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["mname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i++;
               }
           }
           return r;
       }
       private ArrayList ASaleGetQtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   string icode = dr["icode"].ToString();
                   if (icode.Substring(0, 2) == "02")
                   {
                       #region//处理门套待挡轨线
                       ArrayList al = new ArrayList();
                       B_ProductionItem ht = bpib.Query(" and psid='" + dr["psid"].ToString() + "' and e_ptype='tlh'");
                       if (ht != null)
                       {
                           string dgxname = "";
                           if (icode.Substring(0, 4) == "0202")
                           {
                               dgxname = "3号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0203")
                           {
                               dgxname = "2号挡轨线";
                           }
                           if (icode.Substring(0, 4) == "0206")
                           {
                               dgxname = "挡轨线";
                           }
                           al.Add(i);
                           al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", "挡轨线"));
                           al.Add(dr["gnum"].ToString());
                           al.Add(dr["customer"].ToString());
                           al.Add(dr["scode"].ToString());
                           al.Add(dr["fix"].ToString());
                           al.Add(dr["place"].ToString());
                           al.Add(dgxname);
                           al.Add(ht.height);
                           al.Add(ht.width);
                           al.Add(ht.deep);
                           al.Add(ht.pnum);
                           al.Add(dr["mname"].ToString());
                           al.Add(dr["ps"].ToString());
                           al.Add(dr["e_city"].ToString());
                           r.Add(al);
                           i++;
                       }
                       #endregion
                   }
                   else
                   {
                       ArrayList al = new ArrayList();
                       B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                       al.Add(i);
                       al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", ""));
                       al.Add(dr["gnum"].ToString());
                       al.Add(dr["customer"].ToString());
                       al.Add(dr["scode"].ToString());
                       al.Add(dr["fix"].ToString());
                       al.Add(dr["place"].ToString());
                       al.Add(dr["iname"].ToString());
                       if (qt != null)
                       {
                           al.Add(qt.height);
                           al.Add(qt.width);
                           al.Add(qt.deep);
                           al.Add(qt.pnum);
                       }
                       else
                       {
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                           al.Add(0);
                       }

                       al.Add(dr["mname"].ToString());
                       al.Add(dr["ps"].ToString());
                       al.Add(dr["e_city"].ToString());
                       r.Add(al);
                       i++;

                   }
               }
           }
           return r;
       }
       private ArrayList ASaleGetDQtPacs(string where, string sort)
       {
           ArrayList r = new ArrayList();
           DataTable dt = tsb.QueryList("View_Tj_AProduction", "*", where, sort);
           if (dt != null)
           {
               int i = 1;
               foreach (DataRow dr in dt.Rows)
               {
                   ArrayList al = new ArrayList();
                   B_ProductionItem qt = bpib.Query(" and psid='" + dr["psid"].ToString() + "'");
                   al.Add(i);
                   al.Add(bpb.QueryPackageCode(dr["psid"].ToString(), "P", ""));
                   al.Add(dr["gnum"].ToString());
                   al.Add(dr["customer"].ToString());
                   al.Add(dr["scode"].ToString());
                   al.Add(dr["fix"].ToString());
                   al.Add(dr["place"].ToString());
                   al.Add(dr["iname"].ToString());
                   if (qt != null)
                   {
                       al.Add(qt.height);
                       al.Add(qt.width);
                       al.Add(qt.deep);
                       al.Add(qt.pnum);
                   }
                   else
                   {
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                       al.Add(0);
                   }
                   al.Add(dr["omname"].ToString());
                   al.Add(dr["ps"].ToString());
                   al.Add(dr["e_city"].ToString());
                   r.Add(al);
                   i = i + 1;
               }
           }
           return r;
       }
    }
}
