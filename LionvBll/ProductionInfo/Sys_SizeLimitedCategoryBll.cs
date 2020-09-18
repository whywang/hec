﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeLimitedCategoryBll
    {
        private readonly ISys_SizeLimitedCategoryDal dal = DataProductionAccess.CreateSys_SizeLimitedCategory();

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SizeLimitedCategory model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SizeLimitedCategory model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string sccode)
        {

            return dal.Delete(sccode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SizeLimitedCategory Query(string where)
        {

            return dal.Query(where);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SizeLimitedCategory> QueryList(string where)
        {
            return dal.QueryList(where);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSizeLimitedCate(string icode, string sccode)
        {
            return dal.SetSizeLimitedCate(icode,sccode);
        }
        public bool ReSetSizeLimitedCate(string icode )
        {
            return dal.ReSetSizeLimitedCate(icode);
        }
        public string GetSizeLimitedCate(string icode)
        {
            return dal.GetSizeLimitedCate(icode);
        }
        #endregion  ExtensionMethod
    }
}
