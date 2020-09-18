using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_SapOrderDal
    {
        DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
        DataTable QueryCanelList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
    }
}
