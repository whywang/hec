using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProductionProcessLinePointBll
    {
        private readonly ISys_ProductionProcessLinePointDal dal = DataProductionAccess.CreateSys_ProductionProcessLinePoint();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessLinePoint model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProductionProcessLinePoint model)
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
        public Sys_ProductionProcessLinePoint Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessLinePoint> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);

        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int AddList(string lcode, List<Sys_ProductionProcessLinePoint> m)
        {
            return dal.AddList(lcode, m);
        }
        #endregion  ExtensionMethod
    }
}
