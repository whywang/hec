using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
    public class B_MeasureOrderBll
    {
        private readonly IB_MeasureOrderDal dal = BusiOrderAccess.CreateB_MeasureOrder();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            return dal.Exists(where);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_MeasureOrder model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_MeasureOrder model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            return dal.Delete(where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_MeasureOrder Query(string where)
        {

            return dal.Query(where);
        }
 
        public List<B_MeasureOrder> QueryList(string strWhere)
        {

            return dal.QueryList(strWhere);
        }
 
        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
        {
            return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
        }
        public bool SetMeasurePerson(string clperson, string sid)
        {
            return dal.SetMeasurePerson(clperson, sid);
        }
        #endregion  ExtensionMethod
    }
}
