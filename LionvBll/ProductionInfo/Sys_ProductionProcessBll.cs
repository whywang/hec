using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProductionProcessBll
    {

        private readonly ISys_ProductionProcessDal dal = DataProductionAccess.CreateSys_ProductionProcess();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string gcode)
        {
            return dal.Exists(gcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcess model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProductionProcess model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string gcode)
        {

            return dal.Delete(gcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProductionProcess Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcess> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        #endregion  ExtensionMethod
    }
}
