using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvIDal.FuncitonInfo
{
   public interface IF_CommonFunctionDal
    {
       bool ExceUpdate(string tname, string field, string fv, string where);
       bool ExceProcess(string mtable, string stable, string sid, string nsid,string qtimg);
    }
}
