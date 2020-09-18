using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.SapApi;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;

namespace LionvCommonBll
{
   public class SapAttrCommon
    {
       private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
       public List<ZSDS0007> InfoAtrrList(B_GroupProduction b)
       {
           List<ZSDS0007> r = new List<ZSDS0007>();
           ZSDS0007 TShuLiang = new ZSDS0007();
           TShuLiang.ZZGUID = b.sid;
           TShuLiang.ZZPID = b.psid.ToString();
           TShuLiang.MATNR = "SAPCODE";
           TShuLiang.ATNAM = "TShuLiang";
           TShuLiang.ATWRT = b.inum.ToString();
           TShuLiang.ATBEZ = "成套数量";
           TShuLiang.ATPCODE = b.icode;
           TShuLiang.ATPJG = "无";
           TShuLiang.ATCFLAG = "0";
           r.Add(TShuLiang);
           ZSDS0007 TCaiZhi = new ZSDS0007();
           TCaiZhi.ZZGUID = b.sid;
           TCaiZhi.ZZPID = b.psid.ToString();
           TCaiZhi.MATNR = "SAPCODE";
           TCaiZhi.ATNAM = "TCaiZhi";
           TCaiZhi.ATWRT = b.mname;
           TCaiZhi.ATBEZ = "成套材质";
           TCaiZhi.ATPCODE = b.icode;
           TCaiZhi.ATPJG = "无";
           TCaiZhi.ATCFLAG = "0";
           r.Add(TCaiZhi);
           ZSDS0007 DKGao = new ZSDS0007();
           DKGao.ZZGUID = b.sid;
           DKGao.ZZPID = b.psid.ToString();
           DKGao.MATNR = "SAPCODE";
           DKGao.ATNAM = "DKGao";
           DKGao.ATWRT = b.height.ToString();
           DKGao.ATBEZ = "洞口高";
           DKGao.ATPCODE = b.icode;
           DKGao.ATPJG = "无";
           DKGao.ATCFLAG = "0";
           r.Add(DKGao);
           ZSDS0007 DKKuan = new ZSDS0007();
           DKKuan.ZZGUID = b.sid;
           DKKuan.ZZPID = b.psid.ToString();
           DKKuan.MATNR = "SAPCODE";
           DKKuan.ATNAM = "DKKuan";
           DKKuan.ATWRT = b.width.ToString();
           DKKuan.ATBEZ = "洞口宽";
           DKKuan.ATPCODE = b.icode;
           DKKuan.ATPJG = "无";
           DKKuan.ATCFLAG = "0";
           r.Add(DKKuan);
           ZSDS0007 DKHou = new ZSDS0007();
           DKHou.ZZGUID = b.sid;
           DKHou.ZZPID = b.psid.ToString();
           DKHou.MATNR = "SAPCODE";
           DKHou.ATNAM = "DKHou";
           DKHou.ATWRT = b.deep.ToString();
           DKHou.ATBEZ = "洞口厚";
           DKHou.ATPCODE = b.icode;
           DKHou.ATPJG = "无";
           DKHou.ATCFLAG = "0";
           r.Add(DKHou);
           ZSDS0007 AZType = new ZSDS0007();
           AZType.ZZGUID = b.sid;
           AZType.ZZPID = b.psid.ToString();
           AZType.MATNR = "SAPCODE";
           AZType.ATNAM = "AZType";
           AZType.ATWRT = b.fix;
           AZType.ATBEZ = "安装方式";
           AZType.ATPCODE = b.icode;
           AZType.ATPJG = "无";
           AZType.ATCFLAG = "0";
           r.Add(AZType);
           ZSDS0007 KaiXiang = new ZSDS0007();
           KaiXiang.ZZGUID = b.sid;
           KaiXiang.ZZPID = b.psid.ToString();
           KaiXiang.MATNR = "SAPCODE";
           KaiXiang.ATNAM = "KaiXiang";
           KaiXiang.ATWRT = b.direction;
           KaiXiang.ATBEZ = "开向";
           KaiXiang.ATPCODE = b.icode;
           KaiXiang.ATPJG = "无";
           KaiXiang.ATCFLAG = "0";
           r.Add(KaiXiang);
           ZSDS0007 HeYe = new ZSDS0007();
           HeYe.ZZGUID = b.sid;
           HeYe.ZZPID = b.psid.ToString();
           HeYe.MATNR = "SAPCODE";
           HeYe.ATNAM = "HeYe";
           HeYe.ATWRT = b.locktype;
           HeYe.ATBEZ = "合页";
           HeYe.ATPCODE = b.icode;
           HeYe.ATPJG = "无";
           HeYe.ATCFLAG = "0";
           r.Add(HeYe);
           ZSDS0007 SuoKong = new ZSDS0007();
           SuoKong.ZZGUID = b.sid;
           SuoKong.ZZPID = b.psid.ToString();
           SuoKong.MATNR = "SAPCODE";
           SuoKong.ATNAM = "SuoKong";
           SuoKong.ATWRT = b.locks;
           SuoKong.ATBEZ = "锁孔";
           SuoKong.ATPCODE = b.icode;
           SuoKong.ATPJG = "无";
           SuoKong.ATCFLAG = "0";
           r.Add(SuoKong);
           return r;
       }
       public List<ZSDS0007> ItemAtrrType(B_ProductionItem b ,string mpsid)
       {
           List<ZSDS0007> r = new List<ZSDS0007>();
           string prenamestr = "";
           string premsstr="";
           string pjg = "";
           switch (b.e_ptype)
           {
               case "f":
                   prenamestr = "CP";
                   premsstr = "产品";
                   pjg = "门扇";
                   break;
               case "lx":
                   prenamestr = "CP";
                   premsstr = "产品";
                   pjg = "L线";
                   break;
               case "":
                   prenamestr = "CP";
                   premsstr = "产品";
                   break;
               case "s":
                   prenamestr = "ZMS";
                   premsstr = "副门扇";
                   pjg = "副门扇";
                   break;
               case "mt":
                   prenamestr = "HT";
                   premsstr = "横挺";
                   pjg = "横挺";
                   break;
               case "lb":
                   prenamestr = "ST";
                   premsstr = "立挺";
                   pjg = "立挺";
                   break;
               case "stl":
                   prenamestr = "HLX";
                   premsstr = "横L线";
                   pjg = "横L线";
                   break;
               case "ltl":
                   prenamestr = "SLX";
                   premsstr = "竖L线";
                   pjg = "竖L线";
                   break;
               case "tlh":
                   if (b.pcode.Substring(0, 4) == "0206")
                   {
                       prenamestr = "WGGDH";
                       premsstr = "轨道盒";
                       pjg = "轨道盒";
                   }
                   else
                   {
                       prenamestr = "DGX";
                       premsstr = "挡轨线";
                       pjg = "挡轨线";
                   }
                   break;
               case "dgx":
                   prenamestr = "DGX";
                   premsstr = "挡轨线";
                   pjg = "挡轨线";
                   break;
               case "sl":
                   prenamestr = "";
                   premsstr = "";
                   break;
               case "slhl":
                   prenamestr = "";
                   premsstr = "";
                   break;
                 default  :
                   prenamestr = "CP";
                   premsstr = "产品";
                   break;
           }
           if (prenamestr != "")
           {
               r = ItemAtrrList(b, prenamestr, premsstr, pjg, mpsid);
           }
           return r;
       }
       public List<ZSDS0007> ItemAtrrList( B_ProductionItem b,string prenamestr,string premsstr,string pjg,string mpsid)
       {

           B_GroupProduction gpms = bgpb.Query(" and psid='" + b.psid + "'");
           List<ZSDS0007> r = new List<ZSDS0007>();
           ZSDS0007 pname = new ZSDS0007();
           pname.ZZGUID = b.sid;
           pname.ZZPID = mpsid ==""?b.psid: mpsid;
           pname.MATNR = "SAPCODE";
           pname.ATNAM = prenamestr + "Name";
           pname.ATWRT = b.pname;
           pname.ATBEZ = premsstr + "名称";
           pname.ATPCODE = b.pcode;
           pname.ATPJG = pjg;
           pname.ATCFLAG = "2";
           r.Add(pname);
           ZSDS0007 Gao = new ZSDS0007();
           Gao.ZZGUID = b.sid;
           Gao.ZZPID = mpsid == "" ? b.psid : mpsid;
           Gao.MATNR = "SAPCODE";
           Gao.ATNAM = prenamestr + "Gao";
           Gao.ATWRT = b.height.ToString();
           Gao.ATBEZ = premsstr + "高";
           Gao.ATPCODE = b.pcode;
           Gao.ATPJG = pjg;
           Gao.ATCFLAG = "0";
           r.Add(Gao);
           ZSDS0007 Kuan = new ZSDS0007();
           Kuan.ZZGUID = b.sid;
           Kuan.ZZPID = mpsid == "" ? b.psid : mpsid;
           Kuan.MATNR = "SAPCODE";
           Kuan.ATNAM = prenamestr + "Kuan";
           Kuan.ATWRT = b.width.ToString();
           Kuan.ATBEZ = premsstr + "宽";
           Kuan.ATPCODE = b.pcode;
           Kuan.ATPJG = pjg;
           Kuan.ATCFLAG = "0";
           r.Add(Kuan);
           ZSDS0007 Hou = new ZSDS0007();
           Hou.ZZGUID = b.sid;
           Hou.ZZPID = mpsid == "" ? b.psid : mpsid;
           Hou.MATNR = "SAPCODE";
           Hou.ATNAM = prenamestr + "Hou";
           Hou.ATWRT = b.deep.ToString();
           Hou.ATBEZ = premsstr + "厚";
           Hou.ATPCODE = b.pcode;
           Hou.ATPJG = pjg;
           Hou.ATCFLAG = "0";
           r.Add(Hou);
           ZSDS0007 ShuLiang = new ZSDS0007();
           ShuLiang.ZZGUID = b.sid;
           ShuLiang.ZZPID = mpsid == "" ? b.psid : mpsid;
           ShuLiang.MATNR = "SAPCODE";
           ShuLiang.ATNAM = prenamestr + "ShuLiang";
           ShuLiang.ATWRT = b.pnum.ToString();
           ShuLiang.ATBEZ = premsstr + "数量";
           ShuLiang.ATPCODE = b.pcode;
           ShuLiang.ATCFLAG = "0";
           ShuLiang.ATPJG = pjg;
           r.Add(ShuLiang);
           ZSDS0007 CaiZhi = new ZSDS0007();
           CaiZhi.ZZGUID = b.sid;
           CaiZhi.ZZPID = mpsid == "" ? b.psid : mpsid;
           CaiZhi.MATNR = "SAPCODE";
           CaiZhi.ATNAM = prenamestr + "CaiZhi";
           CaiZhi.ATWRT = b.mname;
           CaiZhi.ATBEZ = premsstr + "材质";
           CaiZhi.ATPCODE = b.pcode;
           CaiZhi.ATPJG = pjg;
           CaiZhi.ATCFLAG = "1";
           r.Add(CaiZhi);
           return r;
       }
       public List<ZSDS0007> MtAtrrList(B_GroupProduction b,string mpsid)
       {
           List<ZSDS0007> r = new List<ZSDS0007>();
           ZSDS0007 pname = new ZSDS0007();
           pname.ZZGUID = b.sid;
           pname.ZZPID = mpsid == "" ? b.psid : mpsid; ; 
           pname.MATNR = "SAPCODE";
           pname.ATNAM = "MTName";
           pname.ATWRT = b.iname;
           pname.ATBEZ = "门套名称";
           pname.ATPCODE = b.icode;
           pname.ATCFLAG = "2";
           pname.ATPJG = "无";
           r.Add(pname);
           ZSDS0007 CaiZhi = new ZSDS0007();
           CaiZhi.ZZGUID = b.sid;
           CaiZhi.ZZPID = mpsid == "" ? b.psid : mpsid;
           CaiZhi.MATNR = "SAPCODE";
           CaiZhi.ATNAM = "MTCaiZhi";
           CaiZhi.ATWRT = b.mname;
           CaiZhi.ATBEZ = "门套材质";
           CaiZhi.ATPCODE = b.icode;
           CaiZhi.ATCFLAG = "1";
           CaiZhi.ATPJG = "无";
           r.Add(CaiZhi);
           return r;
       }
    }
}
