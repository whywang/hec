using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvMgModel;

namespace LionvIMgDal.BusiOrderInfo
{
   public interface IVProductionsDal
    {
         void Add(VProductions v);
         VProductions Query(string gsid, string vtype);
         void Delete(string sid, int gnum, string vtype);
         void ReSetGnum(string sid);
    }
}
