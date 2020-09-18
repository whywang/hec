using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;

namespace LionvIDal.BusiCommon
{
    public interface ICB_OrderStateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(CB_OrderState model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(CB_OrderState model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        CB_OrderState Query(string where);

        List<CB_OrderState> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int UpState(string sid, string feild, int value);
        bool BatchUpState(string[] sidarr, string feild, int value);
        #endregion  MethodEx
    } 
}
