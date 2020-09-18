using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvIDal.BusiCommon
{
   public interface ICB_OrderProduceProcessDal
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add( CB_OrderProduceProcess model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update( CB_OrderProduceProcess model);

        bool Delete(string idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
         CB_OrderProduceProcess Query(string id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
         List<CB_OrderProduceProcess> QueryList(string strWhere);
 
        #endregion  成员方法
        #region  MethodEx
         void SaveList(string sid,List<CB_OrderProduceProcess> strWhere);
         DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount);
         bool SetLongTime(CB_OrderProduceProcess p);
         bool UpState(string id, int znum);
        #endregion  MethodEx
    }
}
