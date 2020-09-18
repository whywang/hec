using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
    public class B_ProduceGyImgBll
    {
        private readonly IB_ProduceGyImgDal dal = BusiOrderAccess.CreateB_ProduceGyImg();
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_ProduceGyImg model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_ProduceGyImg model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string gsid)
        {
            return dal.Delete(gsid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_ProduceGyImg Query(string where)
        { 
            return dal.Query(where);
        }
 
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public List<B_ProduceGyImg> QueryList(string where)
        { 
            return dal.QueryList(where);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
