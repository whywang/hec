using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.SizeTransformManage
{
    public partial class JianChis : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化减尺
        [WebMethod(true)]
        public static string InitJc(string jcode)
        {
            string r = "";
            Sys_SizeTransform stf = new Sys_SizeTransform();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransform cstf = stfb.Query(" and jcode='" + jcode + "'");
                if (cstf != null)
                {
                    r = js.Serialize(cstf);
                }
                else
                {
                    stf.jname = "";
                    stf.jcode = stfb.CreateCode().ToString().PadLeft(4, '0');
                    stf.id = 0;
                    r = js.Serialize(stf);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存门扇减尺
        [WebMethod(true)]
        public static string SaveDoorJc(string meg,string mek ,string mes,string mh ,string mg,string mk,string mjcode,
            string mjid,string mjname, string mjsfs, string myg, string myk, string mys
            )
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransform sstf = new Sys_SizeTransform();
                sstf.jname = mjname;
                sstf.jcode = mjcode;
                sstf.dg = Convert.ToInt32(mg);
                sstf.dk = Convert.ToInt32(mk);
                sstf.dh = Convert.ToInt32(mh);
                sstf.d1sl = Convert.ToInt32(mys);
                sstf.d1k = Convert.ToDecimal(myk);
                sstf.d2sl = Convert.ToInt32(mes);
                sstf.d2k = Convert.ToDecimal(mek);
                sstf.d1g = Convert.ToDecimal(myg);
                sstf.d2g = Convert.ToDecimal(meg);
                sstf.mcomputermethod = mjsfs;
                sstf.cdate = DateTime.Now.ToString();
                sstf.maker = iv.u.ename;
                sstf.jtype = "门扇";
                if (iv.u.rcode == "xtgl")
                {
                    sstf.dcode = "";
                }
                else
                {
                    sstf.dcode = iv.u.dcode.Substring(0, 8);
                }
                if (mjid == "0")
                {
                    if (sstfb.Add(sstf) > 0)
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
                    if (sstfb.Update(sstf))
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
        #endregion
        #region/// 减尺分页列表
        [WebMethod(true)]
        public static ArrayList QueryListFyJcDoor(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(sc.GetSqlWhere(" jtype ", "门扇", "", ""));
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                lsf = stfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsf != null)
                {
                    r.Add(pcount);
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.dg);
                        al.Add(s.dk);
                        al.Add(s.dh);
                        al.Add(s.mcomputermethod == "比例" ? "比例" : "固定");
                        al.Add(s.d1sl);
                        al.Add(s.d2sl);
                        al.Add(s.d1k);
                        al.Add(s.d2k);
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
        #region///  删除减尺
        [WebMethod(true)]
        public static string DelJc(string jcode)
        {
            string r = "";
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stfb.Delete(" and jcode='" + jcode + "'"))
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
        #region///  保存门套减尺
        [WebMethod(true)]
        public static string SaveTJc(string blytg, string blytge, string blyth, string blythe, string blytk, string blytke, string blytsl, string blytsle, string dmxg, string dmxh, string dmxk, string dmxsl, string hmdxg, string hmdxh, string hmdxk, string hmdxsl,
            string lbg, string lbge,string lbgs, string lbh, string lbhe, string lbhs,string lbk, string lbke,string lbks, string lbsl, string lbsle,string lbsls, string lmdxg, string lmdxh, string lmdxk, string lmdxsl, string ltleg, string ltleh, string ltlek, string ltlesl, string ltlg, string ltlh, string ltlk, string ltlsl,
            string mdg, string mdh, string mdk, string mdsl, string mentg, string menth, string mentk, string mentsl, string mtbeh, string mtbeg, string mtbek, string mtbesl, string mtbh, string mtbg, string mtbk, string mtbsl,
            string mtg, string mtge,string mtgs, string mth, string mthe,string mths, string mtk, string mtke,string mtks, string mtsl, string mtsle,string mtsls, string skxg,string skxh,string skxk,string skxsl,string slblg, string slblgsl, string slblh, string slblk, string slblsl, 
            string slhlg, string slhlh, string slhlk, string slhlsl, string slslg,string slslh, string slslk, string slslsl,
            string stleg, string stleh, string stlek, string stlesl, string stlg, string stlh, string stlk, string stlsl,
            string tjcazfs, string tjccode, string tjcname, string tjid,string tlhcg, string tlhch, string tlhck, string tlhcsl, string tlhdg, string tlhdh, string tlhdk, string tlhdsl, string tlheg, string tlheh, string tlhek, string tlhesl, 
            string tlhgg, string tlhgh, string tlhgk, string tlhgsl,string tlhyg,string tlhyh, string tlhyk, string tlhysl
            )
        {
 
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransform t = new Sys_SizeTransform();
                t.jname = tjcname;
                t.jcode = tjccode;
                t.dmxg = dmxg;     t.dzg = mdg;       t.mentg = mentg;   t.lbg = lbg;     t.ltlg = ltlg;   t.mtg = mtg;       t.slg = slblg;   t.mtge = mtge;    t.lbge = lbge;
                t.dmxk = dmxk;     t.dzk = mdk;       t.mentk = mentk;   t.lbk =lbk;      t.ltlk = ltlk;   t.mtk = mtk;       t.slk = slblk;   t.mtke = mtke;    t.lbke = lbke;
                t.dmxh = dmxh;     t.dzh = mdh;       t.menth = menth;   t.lbh =lbh;      t.ltlh = ltlh;   t.mth = mth;       t.slh = slblh;   t.mthe = mthe;    t.lbhe = lbhe;
                t.dmxsl = Convert.ToInt32(dmxsl); t.dzsl = Convert.ToInt32(mdsl); t.mentsl = Convert.ToInt32(mentsl); t.lbsl = Convert.ToInt32(lbsl); t.ltlsl = Convert.ToInt32(ltlsl); t.mtsl = Convert.ToInt32(mtsl); t.slsl = Convert.ToInt32(slblsl); t.sljs = Convert.ToInt32(slblgsl); t.mtsle = Convert.ToInt32(mtsle); t.lbsle = Convert.ToInt32(lbsle);
                t.slhlg = slhlg; t.slslg = slslg; t.tlh2g = tlheg; t.tlhg = tlhyg; t.stlg = stlg; t.hmdxg = hmdxg; t.lmdxg = lmdxg; t.mtbg = mtbg;
                t.slhlk = slhlk; t.slslk =slslk ; t.tlh2k = tlhek; t.tlhk = tlhyk; t.stlk = stlk; t.hmdxk = hmdxk; t.lmdxk = lmdxk; t.mtbk = mtbk;
                t.slhlh = slhlh; t.slslh = slslh; t.tlh2h = tlheh; t.tlhh = tlhyh; t.stlh = stlh; t.hmdxh = hmdxh; t.lmdxh = lmdxh; t.mtbh = mtbh;
                t.slhlsl = Convert.ToInt32(slhlsl); t.slslsl = Convert.ToInt32(slslsl); t.tlh2sl = Convert.ToInt32(tlhesl); t.tlhsl = Convert.ToInt32(tlhysl); t.stlsl = Convert.ToInt32(stlsl); t.hmdxsl = Convert.ToInt32(hmdxsl); t.lmdxsl = Convert.ToInt32(lmdxsl); t.mtbsl = Convert.ToInt32(mtbsl);
                t.tlhdg = tlhdg; t.tlhcg = tlhcg; t.tlhgg = tlhgg; t.stleg = stleg; t.ltleg = ltleg; t.mtbeg = mtbeg; t.skxg = skxg;
                t.tlhdk = tlhdh; t.tlhck = tlhck; t.tlhgk = tlhgk; t.stlek = stlek; t.ltlek = ltlek; t.mtbek = mtbek; t.skxk = skxk;
                t.tlhdh = tlhdk; t.tlhch = tlhch; t.tlhgh = tlhgh; t.stleh = stleh; t.ltleh = ltleh; t.mtbeh = mtbeh; t.skxh = skxh;
                t.tlhdsl = Convert.ToInt32(tlhdsl); t.tlhcsl = Convert.ToInt32(tlhcsl); t.tlhgsl = Convert.ToInt32(tlhgsl); t.stlesl = Convert.ToInt32(stlesl); t.ltlesl = Convert.ToInt32(ltlesl); t.mtbesl = Convert.ToInt32(mtbesl); t.skxsl = Convert.ToInt32(skxsl);
                t.mtsg = mtgs; t.lbsg =lbgs; t.blytg = blytg; t.blyteg = blytge;
                t.mtsk = mtks; t.lbsk =lbks; t.blytk = blytk; t.blytek = blytke;
                t.mtsh = mths; t.lbsh =lbhs; t.blyth = blyth; t.blyteh = blythe;
                t.mtssl = Convert.ToInt32(mtsls); t.lbssl = Convert.ToInt32(lbsls); t.blytsl = Convert.ToInt32(blytsl); t.blytesl = Convert.ToInt32(blytsle);
                t.mcomputermethod = "";
                t.cdate = DateTime.Now.ToString();
                t.maker = iv.u.ename;
                t.jtype = "套";
                if (iv.u.rcode == "xtgl")
                {
                    t.dcode = "";
                }
                else
                {
                    t.dcode = iv.u.dcode.Substring(0, 8);
                }
                if (tjid == "0")
                {
                    if (sstfb.Add(t) > 0)
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
                    if (sstfb.Update(t))
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
        #endregion
        #region/// 减尺分页列表
        [WebMethod(true)]
        public static ArrayList QueryListFyJcT(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(sc.GetSqlWhere(" jtype ", "套", "", ""));
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                lsf = stfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsf != null)
                {
                    r.Add(pcount);
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.jtype);
                        al.Add(s.mtg);
                        al.Add(s.mtk);
                        al.Add(s.mth);
                        al.Add(s.mtsl);
                        al.Add(s.lbg);
                        al.Add(s.lbk);
                        al.Add(s.lbh);
                        al.Add(s.lbsl);
                        al.Add(s.stlg);
                        al.Add(s.stlk);
                        al.Add(s.stlh);
                        al.Add(s.stlsl);
                        al.Add(s.ltlg);
                        al.Add(s.ltlk);
                        al.Add(s.ltlh);
                        al.Add(s.ltlsl);
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
        #region/// 减尺列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                lsf = stfb.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.jtype);
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
        #region///   设置产品减尺
        [WebMethod(true)]
        public static string SetProductionJc(string pcode, string jcode )
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (sstfb.SetProductionJc(pcode, jcode) > 0)
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
        #region///  重置产品减尺
        [WebMethod(true)]
        public static string ReSetProductionJc(string pcode)
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (sstfb.ReSetProductionJc(pcode) > 0)
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
        #region///  获取产品减尺
        [WebMethod(true)]
        public static string GetProductionJc(string pcode)
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sstfb.GetProductionJc(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //---------------------------------Cust----------------------------------
        #region///  保存门扇减尺
        [WebMethod(true)]
        public static string CustSaveDoorJc(string meg, string mek, string mes, string mh, string mg, string mk, string mjcode,string mjid, string mjname, string mjsfs, string myg, string myk, string mys)
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransform sstf = new Sys_SizeTransform();
                sstf.jname = mjname;
                sstf.jcode = mjcode;
                sstf.dg = Convert.ToInt32(mg);
                sstf.dk = Convert.ToInt32(mk);
                sstf.dh = Convert.ToInt32(mh);
                sstf.d1sl = Convert.ToInt32(mys);
                sstf.d1k = Convert.ToDecimal(myk);
                sstf.d2sl = Convert.ToInt32(mes);
                sstf.d2k = Convert.ToDecimal(mek);
                sstf.d1g = Convert.ToDecimal(myg);
                sstf.d2g = Convert.ToDecimal(meg);
                sstf.mcomputermethod = mjsfs;
                sstf.cdate = DateTime.Now.ToString();
                sstf.maker = iv.u.ename;
                sstf.jtype = "门扇";
                sstf.dcode = iv.u.dcode.Substring(0,8);
                if (mjid == "0")
                {
                    if (sstfb.Add(sstf) > 0)
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
                    if (sstfb.Update(sstf))
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
        #endregion
        #region///  保存门套减尺
        [WebMethod(true)]
        public static string CustSaveTJc(string blytg, string blytge, string blyth, string blythe, string blytk, string blytke, string blytsl, string blytsle, string dmxg, string dmxh, string dmxk, string dmxsl, string hmdxg, string hmdxh, string hmdxk, string hmdxsl,
            string lbg, string lbge, string lbgs, string lbh, string lbhe, string lbhs, string lbk, string lbke, string lbks, string lbsl, string lbsle, string lbsls, string lmdxg, string lmdxh, string lmdxk, string lmdxsl, string ltleg, string ltleh, string ltlek, string ltlesl, string ltlg, string ltlh, string ltlk, string ltlsl,
            string mdg, string mdh, string mdk, string mdsl, string mentg, string menth, string mentk, string mentsl, string mtbeh, string mtbeg, string mtbek, string mtbesl, string mtbh, string mtbg, string mtbk, string mtbsl,
            string mtg, string mtge, string mtgs, string mth, string mthe, string mths, string mtk, string mtke, string mtks, string mtsl, string mtsle, string mtsls, string skxg, string skxh, string skxk, string skxsl, string slblg, string slblgsl, string slblh, string slblk, string slblsl,
            string slhlg, string slhlh, string slhlk, string slhlsl, string slslg, string slslh, string slslk, string slslsl,
            string stleg, string stleh, string stlek, string stlesl, string stlg, string stlh, string stlk, string stlsl,
            string tjcazfs, string tjccode, string tjcname, string tjid, string tlhcg, string tlhch, string tlhck, string tlhcsl, string tlhdg, string tlhdh, string tlhdk, string tlhdsl, string tlheg, string tlheh, string tlhek, string tlhesl,
            string tlhgg, string tlhgh, string tlhgk, string tlhgsl, string tlhyg, string tlhyh, string tlhyk, string tlhysl
            )
        {
            string r = "";
            Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransform t = new Sys_SizeTransform();
                t.jname = tjcname;
                t.jcode = tjccode;
                t.dmxg = dmxg; t.dzg = mdg; t.mentg = mentg; t.lbg = lbg; t.ltlg = ltlg; t.mtg = mtg; t.slg = slblg; t.mtge = mtge; t.lbge = lbge;
                t.dmxk = dmxk; t.dzk = mdk; t.mentk = mentk; t.lbk = lbk; t.ltlk = ltlk; t.mtk = mtk; t.slk = slblk; t.mtke = mtke; t.lbke = lbke;
                t.dmxh = dmxh; t.dzh = mdh; t.menth = menth; t.lbh = lbh; t.ltlh = ltlh; t.mth = mth; t.slh = slblh; t.mthe = mthe; t.lbhe = lbhe;
                t.dmxsl = Convert.ToInt32(dmxsl); t.dzsl = Convert.ToInt32(mdsl); t.mentsl = Convert.ToInt32(mentsl); t.lbsl = Convert.ToInt32(lbsl); t.ltlsl = Convert.ToInt32(ltlsl); t.mtsl = Convert.ToInt32(mtsl); t.slsl = Convert.ToInt32(slblsl); t.sljs = Convert.ToInt32(slblgsl); t.mtsle = Convert.ToInt32(mtsle); t.lbsle = Convert.ToInt32(lbsle);
                t.slhlg = slhlg; t.slslg = slslg; t.tlh2g = tlheg; t.tlhg = tlhyg; t.stlg = stlg; t.hmdxg = hmdxg; t.lmdxg = lmdxg; t.mtbg = mtbg;
                t.slhlk = slhlk; t.slslk = slslk; t.tlh2k = tlhek; t.tlhk = tlhyk; t.stlk = stlk; t.hmdxk = hmdxk; t.lmdxk = lmdxk; t.mtbk = mtbk;
                t.slhlh = slhlh; t.slslh = slslh; t.tlh2h = tlheh; t.tlhh = tlhyh; t.stlh = stlh; t.hmdxh = hmdxh; t.lmdxh = lmdxh; t.mtbh = mtbh;
                t.slhlsl = Convert.ToInt32(slhlsl); t.slslsl = Convert.ToInt32(slslsl); t.tlh2sl = Convert.ToInt32(tlhesl); t.tlhsl = Convert.ToInt32(tlhysl); t.stlsl = Convert.ToInt32(stlsl); t.hmdxsl = Convert.ToInt32(hmdxsl); t.lmdxsl = Convert.ToInt32(lmdxsl); t.mtbsl = Convert.ToInt32(mtbsl);
                t.tlhdg = tlhdg; t.tlhcg = tlhcg; t.tlhgg = tlhgg; t.stleg = stleg; t.ltleg = ltleg; t.mtbeg = mtbeg; t.skxg = skxg;
                t.tlhdk = tlhdh; t.tlhck = tlhck; t.tlhgk = tlhgk; t.stlek = stlek; t.ltlek = ltlek; t.mtbek = mtbek; t.skxk = skxk;
                t.tlhdh = tlhdk; t.tlhch = tlhch; t.tlhgh = tlhgh; t.stleh = stleh; t.ltleh = ltleh; t.mtbeh = mtbeh; t.skxh = skxh;
                t.tlhdsl = Convert.ToInt32(tlhdsl); t.tlhcsl = Convert.ToInt32(tlhcsl); t.tlhgsl = Convert.ToInt32(tlhgsl); t.stlesl = Convert.ToInt32(stlesl); t.ltlesl = Convert.ToInt32(ltlesl); t.mtbesl = Convert.ToInt32(mtbesl); t.skxsl = Convert.ToInt32(skxsl);
                t.mtsg = mtgs; t.lbsg = lbgs; t.blytg = blytg; t.blyteg = blytge; 
                t.mtsk = mtks; t.lbsk = lbks; t.blytk = blytk; t.blytek = blytke;
                t.mtsh = mths; t.lbsh = lbhs; t.blyth = blyth; t.blyteh = blythe;
                t.mtssl = Convert.ToInt32(mtsls); t.lbssl = Convert.ToInt32(lbsls); t.blytsl = Convert.ToInt32(blytsl); t.blytesl = Convert.ToInt32(blytsle);
                t.mcomputermethod = "";
                t.cdate = DateTime.Now.ToString();
                t.maker = iv.u.ename;
                t.jtype = "套";
                t.dcode = iv.u.dcode.Substring(0, 8);
                if (tjid == "0")
                {
                    if (sstfb.Add(t) > 0)
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
                    if (sstfb.Update(t))
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
        #endregion
        #region/// 减尺分页列表
        [WebMethod(true)]
        public static ArrayList CustQueryListFyJcDoor(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(sc.GetSqlWhere(" jtype ", "门扇", "", ""));
                where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                lsf = stfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsf != null)
                {
                    r.Add(pcount);
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.dg);
                        al.Add(s.dk);
                        al.Add(s.dh);
                        al.Add(s.mcomputermethod == "比例" ? "比例" : "固定");
                        al.Add(s.d1sl);
                        al.Add(s.d2sl);
                        al.Add(s.d1k);
                        al.Add(s.d2k);
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
        #region/// 减尺分页列表
        [WebMethod(true)]
        public static ArrayList CustQueryListFyJcT(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                StringBuilder where = new StringBuilder();
                where.Append(sc.GetSqlWhere(" jtype ", "套", "", ""));
                where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                lsf = stfb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (lsf != null)
                {
                    r.Add(pcount);
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.jtype);
                        al.Add(s.mtg);
                        al.Add(s.mtk);
                        al.Add(s.mth);
                        al.Add(s.mtsl);
                        al.Add(s.lbg);
                        al.Add(s.lbk);
                        al.Add(s.lbh);
                        al.Add(s.lbsl);
                        al.Add(s.stlg);
                        al.Add(s.stlk);
                        al.Add(s.stlh);
                        al.Add(s.stlsl);
                        al.Add(s.ltlg);
                        al.Add(s.ltlk);
                        al.Add(s.ltlh);
                        al.Add(s.ltlsl);
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
        #region/// 减尺列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_SizeTransformBll stfb = new Sys_SizeTransformBll();
            List<Sys_SizeTransform> lsf = new List<Sys_SizeTransform>();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = stfb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_SizeTransform s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        al.Add(s.jtype);
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