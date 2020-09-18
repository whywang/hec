using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionvIDal.ProductionInfo
{
   public interface IMsAttrDal
    {
       bool SetMsJst(string mscode, string jstcode);
       bool ReSetMsJst(string mscode);
       string GetMsJst(string mscode);
       bool SetMsColor(string mscode, string mname);
       bool ReSetMsColor(string mscode);
       string GetMsColor(string mscode);
       bool SetMsYt(string mscode, string ycode);
       bool ReSetMsYt(string mscode);
       string GetMsYt(string mscode);
       bool SetMsLock(string mscode, string lname);
       bool ReSetMsLock(string mscode);
       string GetMsLock(string mscode);
       ArrayList GetLock(string mscode);
       bool SetMsHy(string mscode, string lname);
       bool ReSetMsHy(string mscode);
       string GetMsHy(string mscode);
       ArrayList GetHy(string mscode);
       bool SetMsLine(string mscode, string xxname);
       bool ReSetMsLine(string mscode);
       string GetMsLine(string mscode);
       ArrayList GetLine(string mscode);
    }
}
