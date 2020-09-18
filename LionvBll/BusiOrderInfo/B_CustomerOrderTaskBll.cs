using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_CustomerOrderTaskBll
    {
       private readonly IB_CustomerOrderTaskDal dal = BusiOrderAccess.CreateB_CustomerOrderTask();
       #region  BasicMethod
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add( B_CustomerOrderTask model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update( B_CustomerOrderTask model)
       {
           return dal.Update(model);
       }
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string idlist)
       {
           return dal.Delete(idlist);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public  B_CustomerOrderTask Query(string id)
       {

           return dal.Query(id);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_CustomerOrderTask> QueryList(string strWhere)
       {
            return dal.QueryList(strWhere);
       }
 
       #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
