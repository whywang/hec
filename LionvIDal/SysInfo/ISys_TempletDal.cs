using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_TempletDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_Templet model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_Templet model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_Templet Query(string where);
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_Templet> QueryList(string where);
        
        #endregion  成员方法
        #region  MethodEx
        bool UpImg(string url, string fname,int id);
        #endregion  MethodEx
    } 
}
