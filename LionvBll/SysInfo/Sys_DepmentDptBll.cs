using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_DepmentDptBll
    {
       private ISys_DepmentDptDal r = DataAccess.CreateSys_DepmentDpt();
       #region  成员方法
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_DepmentDpt model)
       { 
           return r.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_DepmentDpt model)
       { 
           return r.Update(model);
       }
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string where)
       { 
           return r.Delete(where);
       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_DepmentDpt Query(string where)
       {
           return r.Query(where);
       }
      
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_DepmentDpt> QueryList(string where)
       { 
           return r.QueryList(where);
       }

       #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}
