using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using System.Collections;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class MsAttrBll
    {
       private readonly IMsAttrDal dal = DataProductionAccess.CreateMsAttr();
       public bool SetMsJst(string mscode, string jstcode)
       {
           return dal.SetMsJst(mscode, jstcode);
       }
       public bool ReSetMsJst(string mscode)
       {
           return dal.ReSetMsJst(mscode);
       }
       public string GetMsJst(string mscode)
       {
           return dal.GetMsJst(mscode);
       }
       public bool SetMsColor(string mscode, string mname)
       {
           return dal.SetMsColor(mscode, mname);
       }
       public bool ReSetMsColor(string mscode)
       {
           return dal.ReSetMsColor(mscode);
       }
       public string GetMsColor(string mscode)
       {
           return dal.GetMsColor(mscode);
       }
       public bool SetMsYt(string mscode, string ycode)
       {
           return dal.SetMsYt(mscode, ycode);
       }
       public bool ReSetMsYt(string mscode)
       {
           return dal.ReSetMsYt(mscode);
       }
       public string GetMsYt(string mscode)
       {
           return dal.GetMsYt(mscode);
       }
       public Sys_InventoryDetail GetYt(string mscode, string ytlb, string mname)
       {
           Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
           Sys_InventoryDetail sid= sidb.Query(" and mname='" + mname + "' and icode in (select ycode from Sys_RMsYt where ycode like '"+ytlb+"%' and mscode='" + mscode.Substring(0, mscode.Length - 3) + "')");
           return sid;
       }
       public bool SetMsLock(string mscode, string lname)
       {
           return dal.SetMsLock(mscode, lname);
       }
       public bool ReSetMsLock(string mscode)
       {
           return dal.ReSetMsLock(mscode);
       }
       public string GetMsLock(string mscode)
       {
           return dal.GetMsLock(mscode);
       }
       public ArrayList GetLock(string mscode)
       {
           return dal.GetLock(mscode);
       }

       public bool SetMsHy(string mscode, string lname)
       {
           return dal.SetMsHy(mscode, lname);
       }
       public bool ReSetMsHy(string mscode)
       {
           return dal.ReSetMsHy(mscode);
       }
       public string GetMsHy(string mscode)
       {
           return dal.GetMsHy(mscode);
       }
       public ArrayList GetHy(string mscode)
       {
           return dal.GetHy(mscode);
       }

       public bool SetMsLine(string mscode, string xxname)
       {
           return dal.SetMsLine(mscode, xxname);
       }
       public bool ReSetMsLine(string mscode)
       {
           return dal.ReSetMsLine(mscode);
       }
       public string GetMsLine(string mscode)
       {
           return dal.GetMsLine(mscode);
       }
       public ArrayList GetLine(string mscode)
       {
           return dal.GetLine(mscode);
       }
    }
}
