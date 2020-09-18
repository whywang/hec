using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;
using LionvModel.SysInfo;

namespace LionvBll.BusiCommon
{
   public class CB_ButtonEventBll
    {
       private ICB_ButtonEventDal r = BusiCommonAccess.CreateCB_ButtonEvent();
       #region  BasicMethod

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(CB_OrderEventBtn model)
       {
           return r.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(CB_OrderEventBtn model)
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
       public CB_OrderEventBtn Query(string where)
       {
 
           return r.Query(where);
       }

 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<CB_OrderEventBtn> QueryList(string where)
       { 
           return r.QueryList(where);
       }


       #endregion  BasicMethod
        #region  ExtensionMethod
       public int FireWorkFlow(string sid, Sys_Button sbn, int bstate, string bms, string maker)
       {
           return r.FireWorkFlow( sid,  sbn,  bstate,  bms,  maker);
       }
       public string GetOrderState(string sid)
       {
           return r.GetOrderState(sid);
       }
        #endregion  ExtensionMethod
    }
}
