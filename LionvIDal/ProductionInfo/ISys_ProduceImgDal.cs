using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_ProduceImgDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_ProduceImg model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_ProduceImg model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProduceImg Query(string where);

        List<Sys_ProduceImg> QueryList(string strWhere);
        
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetProductionImg(string pcode, string icode);
      
        int ReSetProductionImg(string pcode);
       
        string GetProductionImg(string pcode);
       
        #endregion  MethodEx
    }
}
