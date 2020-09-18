using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_ConsumeMaterialCateBll
    {
        private readonly ISys_ConsumeMaterialCateDal dal = DataProductionAccess.CreateSys_ConsumeMaterialCate();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ccode)
        {
            return dal.Exists(ccode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ConsumeMaterialCate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ConsumeMaterialCate model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ccode)
        {

            return dal.Delete(ccode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ConsumeMaterialCate Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ConsumeMaterialCate> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode(string pcode)
        {
            return dal.CreateCode(pcode);
        }
        public bool UpdateEnd(string ccode)
        {
            return dal.UpdateEnd(ccode);
        }
        #endregion  ExtensionMethod
    }
}
