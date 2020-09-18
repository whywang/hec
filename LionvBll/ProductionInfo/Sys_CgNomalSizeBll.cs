using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_CgNomalSizeBll
    {
       private readonly ISys_CgNomalSizeDal dal = DataProductionAccess.CreateSys_CgNomalSize();
       #region  BasicMethod
       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string ncode)
       {
           return dal.Exists(ncode);
       }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add( Sys_CgNomalSize model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update( Sys_CgNomalSize model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
 
       public bool Delete(string ncode)
       {

           return dal.Delete(ncode);
       }
 
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_CgNomalSize Query(string where)
       {

           return dal.Query(where);
       }

 
       public List< Sys_CgNomalSize> QueryList(string strWhere)
       {

           return dal.QueryList(strWhere);
       }
 

       #endregion  BasicMethod
        #region  ExtensionMethod
       public int CreateCode()
       {
           return dal.CreateCode();
       }
       public int SetProductionNs(string pcode, string ncode)
       {
           return dal.SetProductionNs(pcode, ncode);
       }
       public int ReSetProductionNs(string pcode)
       {
           return dal.ReSetProductionNs(pcode);
       }
       public string GetProductionNs(string pcode)
       {
           return dal.GetProductionNs(pcode);
       }
        #endregion  ExtensionMethod
    }
}
