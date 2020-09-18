using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIMgDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvMgModel;

namespace LionvBll.BusiMgOrderInfo
{
    public class VProductionsBll
    {
        private readonly IVProductionsDal dal = BusiMgOrderAccess.CreateVProductions();
        public void Add(VProductions v)
        {
            dal.Add(v);
        }
        public VProductions Query(string gsid,  string vtype)
        {
            return  dal.Query(gsid,vtype);
        }
        public void Delete(string sid, int gnum, string vtype)
        {
            dal.Delete(sid, gnum, vtype);
        }
        public void ReSetGnum(string sid)
        {
            dal.ReSetGnum(sid);
        }
    }
}
