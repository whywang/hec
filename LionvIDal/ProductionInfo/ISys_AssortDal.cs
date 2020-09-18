using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_AssortDal
    {
       bool Exist(string where);

       int SetAssort(string pcode, string pmtcode, ArrayList ptpcode);

       int ReSetAssort(string pcode);

       bool DelAssort(string pcode);

       string GetAssort(string pcode);


       int SetMsBl(string mcode, string blcode, string[] bcode);
     
       int ReSetMsBl(string mcode);
 
       string GetMsBl(string mcode, string blcode);

       bool ExistMsBl(string where);
       
    }
}
