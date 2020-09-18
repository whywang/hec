using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvIDal.FuncitonInfo
{
    public interface IF_SetOrderCodeDal
    {
        bool SetOrderCode(string tname, string codev, string where);
    }
}
