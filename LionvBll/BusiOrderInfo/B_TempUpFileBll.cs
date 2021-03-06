﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;

namespace LionvBll.BusiOrderInfo
{
    public class B_TempUpFileBll
    {
        private readonly IB_TempUpFileDal dal = BusiOrderAccess.CreateB_TempUpFile();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_TempUpFile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_TempUpFile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_TempUpFile Query(string id)
        {

            return dal.Query(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_TempUpFile> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public int GetNum(string fname, string sid)
        {
            return dal.GetNum(fname, sid);
        }
        public bool UpOver(string where)
        {
            return dal.UpOver(where);
        }
        #endregion  ExtensionMethod
    }
}
