using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LionvIDal.StatisticsInfo
{
   public interface IT_StatisticsDal
    {
       DataTable QueryList(string tname,string vfield,string where,string sort);
       bool Exists(string tname, string where);
       bool BaseExists(string tname, string where);
    }
}
