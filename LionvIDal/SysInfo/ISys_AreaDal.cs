using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
   public interface ISys_AreaDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Area model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Area model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string acode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Area Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Area> QueryList(string strWhere);
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetAreaDepment(string acode, string[] adcode);
        int ReSetAreaDepment(string acode);
        string GetAreaDepment(string acode);
        #endregion  MethodEx
    }
}
