using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_OrderFacotoryBll
    {
       private readonly IB_OrderFacotoryDal dal = BusiOrderAccess.CreateB_OrderFacotory();
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
       public int Add( B_OrderFacotory model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update( B_OrderFacotory model)
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
       public  B_OrderFacotory Query(string where)
       {

           return dal.Query(where);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_OrderFacotory> QueryList(string where)
       {
           return dal.QueryList(where);
       }
        

       #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
