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
   public class Sys_GroupBll
    {
       private ISys_GroupDal r = DataAccess.CreateSys_Group();
       #region  BasicMethod

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string gname)
       {
           return r.Exists(gname);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_Group model)
       { 
           return r.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_Group model)
       {  
           return r.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string gcode)
       { 
           return r.Delete(gcode);
       }

       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_Group Query(string where)
       { 
           return r.Query(where);
       }
 
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_Group> QueryList(string where)
       { 
           return r.QueryList(where);
       }

       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       { 
           return r.CreateCode();
       }
       public int SetGroupAccount(DataTable dt)
       {
           return r.SetGroupAccount(dt);
       }
       public int DelGroupAccount(string gcode)
       {
           return r.DelGroupAccount(gcode);
       }
       public string GetGroupAccount(string gcode)
       {
           return r.GetGroupAccount(gcode);
       }

       public int SetGroupMenu(DataTable dt)
       {
           return r.SetGroupMenu(dt);
       }
       public int DelGroupMenu(string gcode)
       {
           return r.DelGroupMenu(gcode);
       }
       public string GetGroupMenu(string gcode)
       {
           return r.GetGroupMenu(gcode);
       }
       #endregion  ExtensionMethod
    }
}
