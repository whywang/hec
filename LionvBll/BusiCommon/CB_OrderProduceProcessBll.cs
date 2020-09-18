using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;
using System.Data;

namespace LionvBll.BusiCommon
{
   public class CB_OrderProduceProcessBll
    {
       private readonly ICB_OrderProduceProcessDal dal = BusiCommonAccess.CreateCB_OrderProduceProcess();
       #region  BasicMethod
 
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add( CB_OrderProduceProcess model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update( CB_OrderProduceProcess model)
       {
           return dal.Update(model);
       }

 
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string idlist)
       {
           return dal.Delete(idlist);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public  CB_OrderProduceProcess Query(string id)
       {

           return dal.Query(id);
       }

 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List< CB_OrderProduceProcess> QueryList(string strWhere)
       {

           return dal.QueryList(strWhere);
       }
      

       #endregion  BasicMethod
        #region  ExtensionMethod
       public void SaveList(string sid, List<CB_OrderProduceProcess> lp)
       {
           dal.SaveList(sid, lp);
       }
       public DataTable QueryList(int curpage, int pagesize, string sfeild, string where, string sort, ref int rcount, ref int pcount)
       {
           return dal.QueryList(curpage, pagesize, sfeild, where, sort, ref  rcount, ref  pcount);
       }
       public bool SetLongTime(CB_OrderProduceProcess p)
       {
           return dal.SetLongTime(p);
       }
       public bool UpState(string id, int znum)
       {
           return dal.UpState(id, znum);
       }
        #endregion  ExtensionMethod 
   }
}
