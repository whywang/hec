﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_HyTypeBll
    {
        private readonly ISys_HyTypeDal dal = DataProductionAccess.CreateSys_HyType();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string hycode)
        {
            return dal.Exists(hycode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_HyType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_HyType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string hycode)
        {

            return dal.Delete(hycode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_HyType Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_HyType> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        #endregion  ExtensionMethod
    }
}
