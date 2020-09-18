using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_ButtonBll
    {
       private ISys_ButtonDal r = DataAccess.CreateSys_Button();
       #region  BasicMethod

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(string where)
       {
           return r.Exists(where);
       }


       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Sys_Button model)
       { 
           return r.Add(model);
       }
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public bool Update(Sys_Button model)
       { 
           return r.Update(model);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public bool Delete(string where)
       { 
           return r.Delete(where);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Sys_Button Query(string where)
       { 
           return r.Query(where);
       }
       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<Sys_Button> QueryList(string strWhere)
       { 
           return r.QueryList(strWhere);
       }


       #endregion  BasicMethod
       #region  ExtensionMethod
       public int CreateCode()
       { 
           return r.CreateCode();
       }
       public int SetRoleEmenuBtn(string rcode,string emcode,string[] bcode,string btype)
       {
           return r.SetRoleEmenuBtn(rcode, emcode, bcode, btype);
       }
       //获取角色列表页btn事件string
       public string GetRolePageBtn(string rcode, string emcode)
       {
           string bstr = "";
           List<Sys_Button> ls= r.GetRolePageListBtn(rcode, emcode,"L");
           if (ls != null)
           {
               foreach (Sys_Button s in ls)
               {
                   bstr = bstr + s.bcode + ";";
               }
               bstr = bstr.Substring(0, bstr.Length - 1);
           }
           return bstr;
       }

       public int SetRoleEmenuItemBtn(string rcode, string emcode, string[] bcode,string btype)
       {
           return r.SetRoleEmenuBtn(rcode, emcode, bcode,btype);
       }
       //获取角色列表页btn事件string
       public string GetRolePageItemBtn(string rcode, string emcode)
       {
           string bstr = "";
           List<Sys_Button> ls = r.GetRolePageListBtn(rcode, emcode,"LX");
           if (ls != null)
           {
               foreach (Sys_Button s in ls)
               {
                   bstr = bstr + s.bcode + ";";
               }
               bstr = bstr.Substring(0, bstr.Length - 1);
           }
           return bstr;
       }
       #endregion  ExtensionMethod
    }
    
}
