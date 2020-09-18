using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;
using System.Data;

namespace LionvBll.SysInfo
{
   public class Sys_SettlementBll
    {
       private readonly ISys_SettlementDal r = DataAccess.CreateSys_Settlement();
       #region  BasicMethod

       public bool Exists(string sname)
       {
           return r.Exists(sname);
       }
       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_Settlement model)
       { 
           return r.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_Settlement model)
       { 
           return r.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string scode)
       { 
           return r.Delete(scode);

       }
       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_Settlement Query(string where)
       { 
           return r.Query(where);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_Settlement> QueryList(string strWhere)
       {
           return r.QueryList(strWhere);
       }

       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       { 
           return r.CreateCode();
       }
       public int SetSettlemnt(string depcode, string scode)
       {
           return r.SetSettlemnt(depcode, scode);
       }
       public int ReSetSettlemnt(string depcode)
       { 
           return r.ReSetSettlemnt(depcode);
       }
       public string GetSettlemnt(string depcode)
       { 
           return r.GetSettlemnt(depcode);
       }
       #endregion  ExtensionMethod
    }
}
