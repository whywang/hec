using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{

    /// <summary>
    /// 接口层Sys_SizeTransform
    /// </summary>
    public interface ISys_SizeTransformDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string jcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_SizeTransform model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_SizeTransform model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string jcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_SizeTransform Query(string where);
         Sys_SizeTransform DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_SizeTransform> QueryList(string where);
         List<Sys_SizeTransform> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount);
        
      
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetProductionJc(string pcode, string jcode);
         int ReSetProductionJc(string pcode);
         string GetProductionJc(string pcode);
        #endregion  MethodEx
    }
}
