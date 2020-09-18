using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.FuncitonInfo;

namespace LionvBll.FuncitonInfo
{
    public class F_CommonFunctionBll
    {
        private readonly IF_CommonFunctionDal dal = FuntionsAccess.CreateF_CommonFunction();
        public bool ExceUpdate(string tname, string field,string fv, string where)
        {
            return dal.ExceUpdate(tname, field, fv, where);
        }
        public bool ExceProcess(string mtable, string stable, string sid, string nsid,string qtimg)
        {
            return dal.ExceProcess(mtable, stable, sid, nsid,qtimg);
        }
    }
}
