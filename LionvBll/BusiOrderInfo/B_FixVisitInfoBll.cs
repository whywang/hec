using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_FixVisitInfoBll
    {
       private readonly IB_FixVisitInfoDal dal = BusiOrderAccess.CreateB_FixVisitInfo();
       #region  BasicMethod

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(B_FixVisitInfo model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(B_FixVisitInfo model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string id)
       {

           return dal.Delete(id);
       }
 

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public B_FixVisitInfo Query(string where)
       {

           return dal.Query(where);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_FixVisitInfo> QueryList(string strWhere)
       {
           return dal.QueryList(strWhere);
       }
       #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
