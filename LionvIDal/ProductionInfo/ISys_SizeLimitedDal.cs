using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_SizeLimitedDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_SizeLimited model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_SizeLimited model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string tcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_SizeLimited Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_SizeLimited> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetSizeLimitedCate(string icode, string lcode);
        bool ReSetSizeLimitedCate(string icode);
        string GetSizeLimitedCate(string icode);
        #endregion  MethodEx
    }
}
