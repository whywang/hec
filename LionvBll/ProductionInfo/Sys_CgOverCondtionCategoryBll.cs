﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_CgOverCondtionCategoryBll
    {
       private readonly ISys_CgOverCondtionCategoryDal dal = DataProductionAccess.CreateSys_CgOverCondtionCategory();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string ncode)
       {
           return dal.Exists(ncode);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_CgOverCondtionCategory model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_CgOverCondtionCategory model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>

       public bool Delete(string ncode)
       {

           return dal.Delete(ncode);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_CgOverCondtionCategory Query(string where)
       {

           return dal.Query(where);
       }


       public List<Sys_CgOverCondtionCategory> QueryList(string strWhere)
       {

           return dal.QueryList(strWhere);
       }


       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       {
           return dal.CreateCode();
       }
       #endregion  ExtensionMethod 
   }
}
