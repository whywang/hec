using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using System.Collections;

namespace LionvBll.ProductionInfo
{
   public class Sys_AssortBll
    {
       private readonly ISys_AssortDal r = DataProductionAccess.CreateSys_Assort();
       public bool Exist(string where)
       {
           return r.Exist(where);
       }
       #region  ExtensionMethod
       public bool DelAssort(string pcode)
       {
           return r.DelAssort(pcode);
       }
       public int SetAssort(string pcode, string pmtcode, ArrayList ptpcode)
       {
           return r.SetAssort(pcode, pmtcode, ptpcode);
       }
       public int ReSetAssort(string pcode)
       {
           return r.ReSetAssort(pcode);
       }
       public string GetAssort(string pcode)
       {
           return r.GetAssort(pcode);
       }

       public int SetMsBl(string mcode, string blcode, string[] bcode)
       { 
           return r.SetMsBl( mcode,  blcode, bcode);
       }
       public int ReSetMsBl(string mcode)
       { 
           return r.ReSetMsBl(mcode);
       }
       public string GetMsBl(string mcode, string blcode)
       {
           return r.GetMsBl( mcode, blcode);
       }
       public bool ExistMsBl(string mscode,string blcode)
       {
           return r.ExistMsBl(mscode);
       }
       public bool ExistMsBl(string where)
       {
           return r.ExistMsBl(where);
       }
 

       #endregion  ExtensionMethod
    }
}
