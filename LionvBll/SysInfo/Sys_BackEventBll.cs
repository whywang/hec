using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_BackEventBll
    {
       private ISys_BackEventDal r = DataAccess.CreateSys_BackEventDal();
       #region  BasicMethod
       public bool Exists(string where)
       { 
           return r.Exists(where);
       }
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_BackEvent model)
       { 
           return r.Add(model); ;
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_BackEvent model)
       { 
           return r.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string ecode)
       { 
           return r.Delete(ecode);
       }
       public Sys_BackEvent Query(string where)
       { 
           return r.Query(where);
       }
       
       public List<Sys_BackEvent> QueryList(string strWhere)
       { 
           return r.QueryList(strWhere);
       }
       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       { 
           return r.CreateCode();
       }
       public void FireBackEvent(string basename,string ename,string sid,string maker)
       {
            r.FireBackEvent(basename,ename,sid,maker);
       }
       public string FireBackEventE(string basename, string ename, string sid, string maker)
       {
          return r.FireBackEventE(basename, ename, sid, maker);
       }
       public void FireBackEvent(string ename, string sid, string maker)
       {
           r.FireBackEvent(ename, sid, maker);
       }
       #endregion  ExtensionMethod
    }
}
