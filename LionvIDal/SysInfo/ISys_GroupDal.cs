using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Data;

namespace LionvIDal.SysInfo
{
    public interface ISys_GroupDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string gcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_Group model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_Group model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         Sys_Group Query(string gcode);
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<Sys_Group> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         int CreateCode();
         int SetGroupAccount(DataTable dt);
         int DelGroupAccount(string gcode);
         string GetGroupAccount(string gcode);

         int SetGroupMenu(DataTable dt);
         int DelGroupMenu(string gcode);
         string GetGroupMenu(string gcode);
        #endregion  MethodEx
    } 
}
