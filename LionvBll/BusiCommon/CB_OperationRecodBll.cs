using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
    public class CB_OperationRecodBll
    {
        private readonly ICB_OperationRecodDal dal = BusiCommonAccess.CreateCB_OperationRecod();
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
        public int Add(CB_OperationRecod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CB_OperationRecod model)
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
        public CB_OperationRecod Query(string where)
        {

            return dal.Query(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_OperationRecod> QueryList(string where)
        {
            
            return dal.QueryList(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
