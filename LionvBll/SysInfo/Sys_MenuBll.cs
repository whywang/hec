using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using System.Data;
using System.Collections;

namespace LionvBll.SysInfo
{
    public class Sys_MenuBll
    {
        private readonly ISys_MenuDal r = DataAccess.CreateSys_Menu();
        public List<Sys_Menu> QueryList(string where)
        {
            return r.QueryList(where);
        }
        public Sys_Menu Query(string where)
        {
            return r.Query(where);
        }
        public int DelRoleMenu(string rcode)
        {
            
            return r.DelRoleMenu(rcode);
        }
        public int SetRoleMenu(DataTable dt)
        {
             
            return r.SetRoleMenu(dt);
        }
        public string GetRoleMenu(string rcode)
        { 
            return r.GetRoleMenu(rcode);
        }
        public int CreateCode(string pmcode)
        {
            return r.CreateCode(pmcode);
        }
        public int Add(Sys_Menu model)
        {
            return r.Add(model);
        }
        public bool Update(Sys_Menu model)
        {
            return r.Update(model);
        }
        public ArrayList QueryMenuGroup(string pmcode)
        {
            return r.QueryMenuGroup(pmcode);
        }
    }
}
