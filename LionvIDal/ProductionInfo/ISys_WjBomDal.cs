using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_WjBomDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_WjBom model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_WjBom model);
   
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_WjBom Query(string where);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_WjBom> QueryList(string strWhere);
     
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetWjBom(string pcode, string[] bcode);
        bool ReSetWjBom(string pcode);
        string GetWjBom(string pcode);
        #endregion  MethodEx
    }
}
