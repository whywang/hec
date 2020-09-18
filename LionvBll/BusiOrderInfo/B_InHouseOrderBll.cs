﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_InHouseOrderBll
    {
       private readonly IB_InHouseOrderDal dal = BusiOrderAccess.CreateB_InHouseOrder();
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
       public int Add(B_InHouseOrder model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(B_InHouseOrder model)
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
       public B_InHouseOrder Query(string id)
       {

           return dal.Query(id);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_InHouseOrder> QueryList(string strWhere)
       {

           return dal.QueryList(strWhere);
       }

       #endregion  BasicMethod
        #region  ExtensionMethod
       public int QueryIorderNum(string strWhere)
       {
           return dal.QueryIorderNum(strWhere);
       }
       public bool SaveQualityOrder(B_InHouseOrder bpqo, List<B_InhousePackage> lq)
       {
           return dal.SaveQualityOrder(bpqo, lq);
       }
        #endregion  ExtensionMethod
    }
}
