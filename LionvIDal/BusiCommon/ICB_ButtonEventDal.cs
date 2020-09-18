using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using LionvModel.SysInfo;

namespace LionvIDal.BusiCommon
{
    public interface ICB_ButtonEventDal
    {
        #region  成员方法

        int Add(CB_OrderEventBtn model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_OrderEventBtn model);
 
        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CB_OrderEventBtn Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<CB_OrderEventBtn> QueryList(string strWhere);
       
        #endregion  成员方法
        #region  MethodEx
        int FireWorkFlow(string sid, Sys_Button sbn, int bstate, string bms, string maker);
        string GetOrderState(string sid);
        #endregion  MethodEx
    }
}
