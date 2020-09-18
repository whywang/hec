using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_BackEventDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string bcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_BackEvent model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_BackEvent model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string bcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_BackEvent Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_BackEvent> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        void FireBackEvent(string basename, string ename, string sid, string maker);
        string FireBackEventE(string basename, string ename, string sid, string maker);
        void FireBackEvent(string ename, string sid, string maker);
        #endregion  MethodEx
    }
}
