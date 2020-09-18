using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
    public class CB_SapRecordBll
    {
        private readonly ICB_SapRecordDal dal = BusiCommonAccess.CreateCB_SapRecord();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CB_SapRecord model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CB_SapRecord model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool Delete(string where)
        {
            return dal.Delete(where);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CB_SapRecord Query(string where)
        { 
            return dal.Query(where);
        }
 

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_SapRecord> QueryList(string strWhere)
        { 
            return dal.QueryList(strWhere);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool AddList(string[] idarr, string backstr, string mstr,string itype)
        {
            return dal.AddList( idarr,  backstr,  mstr, itype);
        }
        #endregion  ExtensionMethod
    }
}
