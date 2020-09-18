using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_StatistcPartTypeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_StatistcPartType model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_StatistcPartType model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_StatistcPartType Query(string id);
        /// </summary>
        List<Sys_StatistcPartType> QueryList(string strWhere);
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetInvPartType(string icode, string pcode);
        int ReSetInvPartType(string icode);
        string GetInvPartType(string icode);
        #endregion  MethodEx
    } 
}
