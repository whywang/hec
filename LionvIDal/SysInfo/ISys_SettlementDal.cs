using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_SettlementDal
    {
        #region  成员方法
        bool Exists(string sname);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Settlement model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Settlement model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string scode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Settlement Query( string where);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Settlement> QueryList(string strWhere);
         
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetSettlemnt(string depcode, string scode);
        int ReSetSettlemnt(string depcode);
        string GetSettlemnt(string depcode);
        #endregion  MethodEx
    }
}
