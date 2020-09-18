using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_OrderSourceBll
    {
       private readonly ISys_OrderSourceDal dal = DataAccess.CreateSys_OrderSource();
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
       public int Add(Sys_OrderSource model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_OrderSource model)
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
       public Sys_OrderSource Query(string where)
       {

           return dal.Query(where);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List< Sys_OrderSource> QueryList(string strWhere)
       {
           return dal.QueryList(strWhere);
       }
 

       #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
