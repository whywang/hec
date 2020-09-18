using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Collections;

namespace LionvIDal.BusiOrderInfo
{
    public interface IB_ProductionItemDal
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string where);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(B_ProductionItem model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(B_ProductionItem model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string where);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        B_ProductionItem Query(string where);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<B_ProductionItem> QueryList(string where);
        
        #endregion  成员方法
        #region  MethodEx
        int SaveItemList(List<B_ProductionItem> lb);
        int UpdateWorkLine(DataTable dt);
        int TjItemNum(string sid, string etype);
        int TjItemNum(string where);
        int InsertAddUpdateItems(string sid,int gnum,List<B_ProductionItem> uitems, List<B_ProductionItem> iitems);
        int AfterUpdateItems(List<B_ProductionItem> epi, List<B_ProductionItem> dpi, ArrayList psids);
        DataTable QueryTable(string where);
        B_ProductionItem Query(DataTable dt, string where);
        #endregion  MethodEx
    } 
}
