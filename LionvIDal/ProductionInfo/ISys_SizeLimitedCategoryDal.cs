using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_SizeLimitedCategoryDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_SizeLimitedCategory model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_SizeLimitedCategory model);
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string sccode);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_SizeLimitedCategory Query(string id);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_SizeLimitedCategory> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icode"></param>
        /// <param name="sccode"></param>
        /// <returns></returns>
        bool SetSizeLimitedCate(string icode, string sccode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icode"></param>
        /// <returns></returns>
        bool ReSetSizeLimitedCate(string icode);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="icode"></param>
        /// <returns></returns>
        string GetSizeLimitedCate(string icode);
 
        #endregion  MethodEx
    } 
}
