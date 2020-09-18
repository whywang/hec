using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_GlassProductionPeriodDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string gqcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_GlassProductionPeriod model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_GlassProductionPeriod model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string gqcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_GlassProductionPeriod Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_GlassProductionPeriod> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetGlassPeriod(string icode, string fcode, string gqcode);
        bool ReSetGlassPeriod(string icode, string fcode);
        string GetGlassPeriod(string icode, string fcode);
        #endregion  MethodEx
    }
}
