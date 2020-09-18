using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_PartTypeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string pcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_PartType model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_PartType model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
    
        bool Delete(string pcode);
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_PartType Query(string where);
       
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_PartType> QueryList(string where);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetInvPartType(string icode, string pcode);
        int ReSetInvPartType(string icode );
        string GetInvPartType(string icode);
        DataTable QueryCateList(string where);
        #endregion  MethodEx
    }
}
