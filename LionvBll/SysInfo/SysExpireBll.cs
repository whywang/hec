using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvCommon;

namespace LionvBll.SysInfo
{
   public class SysExpireBll
   {
       //private readonly SysExpireDal r = new SysExpireDal();
       //#region//base
       //public bool Exists()
       //{
       //    return  r.Exists();
       //}
       //public int Add(SysExpire model)
       //{ 
       //    return r.Add(model);
       //}
       //public int Update(SysExpire model)
       //{ 
       //    return r.Update(model);
       //}
       //public SysExpire Query()
       //{ 
       //    return r.Query();
       //}
       //#endregion
       //#region//系统有效期
       //public bool SysExpire()
       //{
       //    bool r = false;
       //    SysExpire se = new SysExpire();
       //    Des des = new Des();
       //    se = Query();
       //    if (se != null)
       //    {
       //        try
       //        {
       //            if (Convert.ToDateTime(des.DecryptString(se.expdate)) > DateTime.Now)
       //            {
       //                r = true;
       //            }
       //            else
       //            {
       //                r = false;
       //            }
       //        }
       //        catch
       //        {
       //            r = false;
       //        }
       //    }
       //    else
       //    {
       //        r = false;
       //    }
       //    return r;
       //}
       //#endregion
   }
}
