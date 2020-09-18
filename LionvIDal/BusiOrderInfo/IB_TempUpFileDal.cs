using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_TempUpFileDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_TempUpFile model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_TempUpFile model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_TempUpFile Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_TempUpFile> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int GetNum(string fname, string sid);
        bool UpOver(string where);
        #endregion  MethodEx
    }
}
