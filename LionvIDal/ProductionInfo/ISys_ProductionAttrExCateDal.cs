using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
   public interface ISys_ProductionAttrExCateDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string accode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_ProductionAttrExCate model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_ProductionAttrExCate model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string accode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_ProductionAttrExCate Query(string where);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        List<Sys_ProductionAttrExCate> QueryList(string where);
 
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        bool SetAttrCateAttr(string accode, string acode);
        bool ReSetAttrCateAttr(string accode);
        string GetAttrCateAttr(string accode);

        bool SetInvAttrCate(string icode, string accode);
        bool ReSetInvAttrCate(string icode);
        string GetInvAttrCate(string icode);
        #endregion  MethodEx
    }
}
