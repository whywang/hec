using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_HelpMenuBll
    {
       private readonly ISys_HelpMenuDal dal = DataAccess.CreateSys_HelpMenu();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string hcode)
       {
           return dal.Exists(hcode);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_HelpMenu model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_HelpMenu model)
       {
           return dal.Update(model);
       }
 
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string hcode)
       {

           return dal.Delete(hcode);
       }
 
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_HelpMenu Query(string where)
       {

           return dal.Query(where);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_HelpMenu> QueryList(string strWhere)
       {
           return dal.QueryList(strWhere);
       }
 
       #endregion  BasicMethod
        #region  ExtensionMethod
       public int CreateCode(string hcode)
       {
           return dal.CreateCode(hcode);
       }
        #endregion  ExtensionMethod
    }
}
