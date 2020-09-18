using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ComputeFunctionBll
    {
       private readonly ISys_ComputeFunctionDal r = DataProductionAccess.CreateSys_ComputeFunction();
       #region  BasicMethod
       public bool Exists(string where)
       {
           return r.Exists(where);
       }
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add( Sys_ComputeFunction model)
       {
           return r.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update( Sys_ComputeFunction model)
       {
           return r.Update(model);
       }

 
       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string fcode)
       {

           return r.Delete(fcode);
       }
 

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_ComputeFunction Query(string where)
       {

           return r.Query(where);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_ComputeFunction> QueryList(string where)
       {
           return r.QueryList(where);
       }
       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       {
           return r.CreateCode();
       }
       public int SetProductionCm(string pcode, string fcode,string ptx)
       {
           return r.SetProductionCm(pcode, fcode,ptx);
       }
       public int ReSetProductionCm(string pcode, string ptx)
       {
           return r.ReSetProductionCm(pcode,ptx);
       }
       public string GetProductionCm(string pcode, string ptx)
       {
           return r.GetProductionCm(pcode,ptx);
       }
        #endregion  ExtensionMethod
    }
}
