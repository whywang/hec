using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.SysInfo;
using LionvBll.SysInfo;

namespace LionvCommonBll
{
   public class BusiSendTempBll
    {
       private BusiTempletBll btb = new BusiTempletBll();
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private Sys_DomainBll sdb = new Sys_DomainBll();
       private Sys_CityGetAddressBll scgab = new Sys_CityGetAddressBll();
       public string QuerySendOrderHtm(string sid, string emcode, string utype, string dcode)
       {
           StringBuilder thtm = new StringBuilder();
           string htemp = btb.TempDiv(dcode, emcode, utype);
           thtm.Append(ReplaceTempDiv(sid, htemp));
           return thtm.ToString();
       }
       private string ReplaceTempDiv(string sid, string htemp)
       {
           string city = "";
           string scode = "";
           string customer = "";
           string address = "";
           string qtimg="";
           string citycode="";
           string telephone = "";
           string gperson = "";
           string saddress = "";
           Sys_Domain sd = sdb.Query(" and dtype='p'");
           B_SaleOrder bso=bsob.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
                city = bso.city;
                scode = bso.scode;
                customer = bso.customer;
                address = bso.address;
                qtimg=bso.qtimg;
                citycode=bso.citycode;
                saddress = bso.saddress;
           }
           Sys_CityGetAddress sa=scgab.Query(" and dcode='" + citycode + "' isfrist='true' ");
           if (sa != null)
           {
               telephone = sa.telephone;
               gperson = sa.gperson;
               address = sa.address;
           }
            Sys_CityGetAddress ssa=scgab.Query(" and dcode='" + citycode + "' isfrist='false' ");
           if (sa != null)
           {
               telephone = ssa.telephone;
               gperson = ssa.gperson;
               address = ssa.address;
           }
           address = saddress == "" ? address : saddress;
           htemp = htemp.Replace("[CITY]", city);
           htemp = htemp.Replace("[SCODE]", scode);
           htemp = htemp.Replace("[CUSTOMER]", customer);
           htemp = htemp.Replace("[ADDRESS]", address);

           htemp = htemp.Replace("[EIMG]", "<img src='" + sd.url+qtimg + "'/>");

           htemp = htemp.Replace("[MSB]", "2");
           htemp = htemp.Replace("[MTB]", "1");
           htemp = htemp.Replace("[CTB]", "0");
           htemp = htemp.Replace("[YKB]", "0");
           htemp = htemp.Replace("[LXG]", "0");
           htemp = htemp.Replace("[LXB]", "0");
           htemp = htemp.Replace("[TSCPG]", "0");
           htemp = htemp.Replace("[TSCPB]", "0");
           htemp = htemp.Replace("[HJB]", "0");
           htemp = htemp.Replace("[TJXB]", "0");
           htemp = htemp.Replace("[DB]", "2");
           htemp = htemp.Replace("[XB]", "1");

           htemp = htemp.Replace("[FHDATE]", DateTime.Now.ToString());
           htemp = htemp.Replace("[TELEPHONE]", telephone);
           htemp = htemp.Replace("[SJR]", gperson);

           htemp = htemp.Replace("[FHR]", "");
           htemp = htemp.Replace("[WLCOMPANY]", "");
           htemp = htemp.Replace("[DF]", "");
           return htemp;
       }
    }
}
