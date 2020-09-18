using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiServiceTempBll
    {
        private BusiTempletBll btb = new BusiTempletBll();
        private B_AfterFreeBackOrderBll bsob = new B_AfterFreeBackOrderBll();
        private B_AfterReModifyOrderBll barmob = new B_AfterReModifyOrderBll();
        private Sys_DomainBll sdb = new Sys_DomainBll();
        public string QueryServiceOrderHtm(string sid, string emcode, string utype, string dcode)
        {
            StringBuilder thtm = new StringBuilder();
            string htemp = btb.TempHead(dcode, emcode, utype);
            htemp = htemp+btb.TempBody(dcode, emcode, utype);
            htemp = htemp + btb.TempFoot(dcode, emcode, utype);
            thtm.Append(ReplaceTempDiv(sid, htemp));
            return thtm.ToString();
        }
        private string ReplaceTempDiv(string sid, string htemp)
        {
            string oscode = "";
            string scode = "";
            string customer = "";
            string address = "";
            string qtimg = "";
            string citycode = "";
            string telephone = "";
            string sdate = "";
            string dname = "";
            string gofee = "";
            string servfee = "";
            string stext = "";
            string remark = "";
            string azperson = "";
            string cinfo = "";
            string oinfo = "";
            Sys_Domain sd = sdb.Query(" and dtype='p'");
            B_AfterFreeBackOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                oscode = bso.oscode;
                scode = bso.scode;
                customer = bso.customer;
                address = bso.aprovince + bso.acity + bso.address;
                telephone = bso.telephone;
                qtimg = bso.qtimg;
                citycode = bso.citycode;
                dname = bso.dname;
                sdate = bso.sdate;
                gofee = bso.gofee.ToString();
                servfee = bso.servfee.ToString();
                stext = bso.stext;
                azperson = bso.azperson;
                remark = bso.remark;
            }
            B_AfterReModifyOrder bao = barmob.Query("and sid='" + sid + "'");
            if(bao!=null)
            {
                oscode = bao.oscode;
                scode = bao.scode;
                customer = bao.customer;
                address = bao.aprovince + bao.acity + bao.address;
                telephone = bao.telephone;
                qtimg = "";// bao.qtimg;
                citycode = bao.citycode;
                dname = bao.dname;
                sdate = bao.sdate;
                gofee = bao.gofee.ToString();
                servfee = bao.servfee.ToString();
                stext = bao.stext;
                azperson = bao.azperson;
                remark = bao.remark;
                cinfo = bao.cinfo;
                if (bao.fzt != "")
                {
                    oinfo = bao.fzt + "</br>完工日期：" + bao.fodate + "</br>" + bao.oinfo;
                }
            }
            //Sys_CityGetAddress sa = scgab.Query(" and dcode='" + citycode + "' isfrist='true' ");
            //if (sa != null)
            //{
            //    telephone = sa.telephone;
            //    gperson = sa.gperson;
            //    address = sa.address;
            //}
            //Sys_CityGetAddress ssa = scgab.Query(" and dcode='" + citycode + "' isfrist='false' ");
            //if (sa != null)
            //{
            //    telephone = ssa.telephone;
            //    gperson = ssa.gperson;
            //    address = ssa.address;
            //}
            //address = saddress == "" ? address : saddress;
            htemp = htemp.Replace("[OSCODE]", oscode);
            htemp = htemp.Replace("[SCODE]", scode);
            htemp = htemp.Replace("[CUSTOMER]", customer);
            htemp = htemp.Replace("[ADDRESS]", address);

            // htemp = htemp.Replace("[EIMG]", "<img src='" + sd.url + qtimg + "'/>");

            htemp = htemp.Replace("[TELEPHONE]", telephone);
            htemp = htemp.Replace("[DNAME]", dname);
            htemp = htemp.Replace("[SDATE]", sdate);
            htemp = htemp.Replace("[GOFEE]", gofee);
            htemp = htemp.Replace("[SERVFEE]", servfee);
            htemp = htemp.Replace("[REMARK]", remark);
            htemp = htemp.Replace("[STEXT]", stext);
            htemp = htemp.Replace("[AZPERSON]", azperson);
            htemp = htemp.Replace("[CINFO]", cinfo);
            htemp = htemp.Replace("[OINFO]", oinfo);
            return htemp;
        }
    }
}
