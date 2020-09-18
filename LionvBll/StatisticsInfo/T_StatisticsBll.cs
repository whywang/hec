using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.StatisticsInfo;
using LionvFactoryDal;
using System.Data;

namespace LionvBll.StatisticsInfo
{
    public class T_StatisticsBll
    {
        private readonly IT_StatisticsDal dal = StatisticsAccess.CreateT_Statistics();
        public DataTable QueryList(string tname, string vfield, string where, string sort)
        {
            return dal.QueryList( tname, vfield, where, sort);
        }
        public bool Exists(string tname,string where)
        {
            return dal.Exists(tname,where);
        }
        public bool BaseExists(string tname, string where)
        {
            return dal.BaseExists(tname, where);
        }
    }
}
