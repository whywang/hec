
using LionvModel.BusiOrderInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_HouseProdcutionDal
    {
        #region  成员方法
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Exist(string where);
        bool InUpdate(string[] idlist,string isid);
        bool OutUpdate(string[] idlist,string osid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_HouseProdcution> QueryList(string strWhere);
        
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        #endregion  MethodEx
    }
}