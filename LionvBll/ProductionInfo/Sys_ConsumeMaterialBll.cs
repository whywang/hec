using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public class Sys_ConsumeMaterialBll
    {
        private readonly ISys_ConsumeMaterialDal dal = DataProductionAccess.CreateSys_ConsumeMaterial();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string mcode)
        {
            return dal.Exists(mcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ConsumeMaterial model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ConsumeMaterial model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string mcode)
        {

            return dal.Delete(mcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ConsumeMaterial Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ConsumeMaterial> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode(string pcode)
        {
            return dal.CreateCode(pcode);
        }
        #endregion  ExtensionMethod
    }
}
