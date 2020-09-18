using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ComponentCateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string cccode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ComponentCate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ComponentCate model);
      
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ComponentCate Query(string where);

        List<Sys_ComponentCate> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
        int CreateCode(string where);
        int SetInvComCate(string icode, string ccode);
         
        int ReSetInvComCate(string icode);
       
        string GetInvComCate(string icode);
        
        #endregion  MethodEx
    }
}
