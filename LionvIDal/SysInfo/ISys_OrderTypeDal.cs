﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;

namespace LionvIDal.SysInfo
{
    public interface ISys_OrderTypeDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string tcode);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( Sys_OrderType model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( Sys_OrderType model);
  
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_OrderType Query(string where);
      
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_OrderType> QueryList(string where);
        
        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
        #endregion  MethodEx
    } 
}