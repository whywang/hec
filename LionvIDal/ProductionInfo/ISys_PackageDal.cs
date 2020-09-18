using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_PackageDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Package model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Package model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Package Query(string where);
        Sys_Package DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Package> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        int SetInvPackage(string pcode, string icode,string [] ppcode);
        int ReSetInvPackage(string pcode);
        string GetInvPackage(string pcode,string icode);
        #endregion  MethodEx
    }
}
