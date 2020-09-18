﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;

namespace LionvIDal.ProductionInfo
{
    public interface ISys_MsCzDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Sys_MsCz model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Sys_MsCz model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string czcode);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Sys_MsCz Query(string id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Sys_MsCz> QueryList(string strWhere);

        #endregion  成员方法
        #region  MethodEx
        int CreateCode();
         bool SetMsCz(string icode, string czcode);
   
         bool ReSetMsCz(string icode);

         string GetMsCz(string icode);
   
        #endregion  MethodEx
    } 
}
