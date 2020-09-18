using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public class Sys_RepairDutyBll
    {
        private ISys_RepairDutyDal dal = DataAccess.CreateSys_RepairDuty();
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            return dal.Exists(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_RepairDuty model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_RepairDuty model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
            return dal.Delete(where);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_RepairDuty Query(string where)
        {
            return dal.Query(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_RepairDuty> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode(string rcode)
        {
            return dal.CreateCode(rcode);
        }

        #endregion  ExtensionMethod
    }
}
