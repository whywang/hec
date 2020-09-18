using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;
using System.Data;
using System.Collections;

namespace LionvBll.BusiOrderInfo
{
   public class B_ProductionItemBll
    {
       private readonly IB_ProductionItemDal dal = BusiOrderAccess.CreateB_ProductionItem();
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
       public int Add(B_ProductionItem model)
       {
           return dal.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(B_ProductionItem model)
       { 
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string where)
       {
           return dal.Delete(where) ;

       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public B_ProductionItem Query(string where)
       {
 
           return dal.Query(where);

       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<B_ProductionItem> QueryList(string where)
       { 
           return dal.QueryList(where);

       }
       #endregion  BasicMethod
        #region  ExtensionMethod
       public int SaveItemList(List<B_ProductionItem> lb)
       {
           return dal.SaveItemList(lb);
       }
       public int UpdateWorkLine(DataTable dt)
       {
           return dal.UpdateWorkLine( dt);
       }
       public int TjItemNum(string sid, string etype)
       {
           return dal.TjItemNum(sid, etype);
       }
       public int TjItemNum(string where)
       {
           return dal.TjItemNum(where);
       }
        #region//编辑产品部件
        public int InsertAddUpdateItems(string sid,int gnum,List<B_ProductionItem> uitems, List<B_ProductionItem> iitems)
        {
            return dal.InsertAddUpdateItems(sid,gnum,uitems, iitems);
        }
        #endregion
        #region//售后编辑产品部件
        public int AfterUpdateItems(List<B_ProductionItem> epi, List<B_ProductionItem> dpi, ArrayList psids)
        {
            return dal.AfterUpdateItems(epi, dpi, psids);
        }
        #endregion
        public DataTable QueryTable(string where)
        {
            return dal.QueryTable(where);
        }
        public B_ProductionItem Query(DataTable dt, string where)
        {
            return dal.Query(dt, where);
        }
        #endregion  ExtensionMethod
    }
}
