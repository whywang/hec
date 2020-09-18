using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
    public class B_SelectProduceImgBll
    {
        private readonly IB_SelectProduceImgDal dal = BusiOrderAccess.CreateB_SelectProduceImg();
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_SelectProduceImg model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_SelectProduceImg model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string xsid)
        {
            return dal.Delete(xsid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_SelectProduceImg Query(string where)
        { 
            return dal.Query(where);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_SelectProduceImg> QueryList(string strWhere)
        { 
            return dal.QueryList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
