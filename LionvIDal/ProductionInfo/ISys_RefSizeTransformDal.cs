using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_RefSizeTransformDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string rjcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_RefSizeTransform model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_RefSizeTransform model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string rjcode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_RefSizeTransform Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_RefSizeTransform> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         bool SetMtMsSize(string mtcode, string mscode, string rjcode);
         bool ReSetMtMsSize(string mtcode, string mscode);
         string GetMtMsSize(string mtcode, string mscode);
        #endregion  MethodEx
    }
}
