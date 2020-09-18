using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_AreaBll
    {
       private readonly ISys_AreaDal dal = DataAccess.CreateSys_Area();
       #region  BasicMethod

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_Area model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_Area model)
       {
           return dal.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string acode)
       {

           return dal.Delete(acode);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_Area Query(string where)
       {

           return dal.Query(where);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_Area> QueryList(string strWhere)
       {
           return dal.QueryList(strWhere);
       }
       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       {
           return dal.CreateCode();
       }
       public int SetAreaDepment(string acode, string[] adcode)
       {
           return dal.SetAreaDepment(acode, adcode);
       }
       public int ReSetAreaDepment(string acode)
       {
           return dal.ReSetAreaDepment(acode);
       }
       public string GetAreaDepment(string acode)
       {
           return dal.GetAreaDepment(acode);
       }
       public string QueryAreaColor (string acode)
       {
           string r = "";
           Sys_Area sa= dal.Query(" and acode='" + acode + "'");
           if (sa != null)
           {
               r=sa.atype;
           }
           return r;
       }
       public Sys_Area QueryDepArea(string dcode)
       {
          return  dal.Query(" and acode=(select acode from Sys_RDepmentArea where dcode='"+dcode+"')");
       }
        #endregion  ExtensionMethod
    }
}
