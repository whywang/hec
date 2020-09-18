using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_UnitDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string ucode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Unit model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Unit model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Unit Query(string where);
      
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Unit> QueryList(string where);
        List<Sys_Unit> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount);
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    } 
}
