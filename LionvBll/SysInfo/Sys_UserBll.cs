using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using System.Data;

namespace LionvBll.SysInfo
{
    public class Sys_UserBll
    {
        private readonly ISys_UserDal r = DataAccess.CreateSys_User();
        public bool Exists(string uname)
        {
            return r.Exists(uname);
        }
        public int Add(Sys_User model)
        {
            return r.Add(model);
        }
        public bool Update(Sys_User model)
        {
            return r.Update(model);
        }
        public bool Delete(string where)
        {
            return r.Delete(where);
        }
        public Sys_User Query(string where)
        {
            return r.Query(where);

        }
        public List<Sys_User> QueryList(string where)
        {
            return r.QueryList(where);
        }
        public DataTable QueryTable(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            return r.QueryTable(curpage, pagesize, where, sort, ref  rcount, ref  pcount);
        }
        public int ReSetPass(string id,string mm)
        {
            return r.ReSetPass(id, mm);
        }
        public int SetState(string id, string v)
        {
            return r.SetState(id,v);
        }
        public int RePersonSetPass(string eno, string mm)
        {
            return r.RePersonSetPass(eno, mm);
        }
        public int SetEmployeeCity(string eno, string[] ptcode)
        {
            return r.SetEmployeeCity(eno, ptcode);
        }
        public int ReSetEmployeeCity(string eno)
        {
            return r.ReSetEmployeeCity(eno);
        }
        public string GetEmployeeCity(string eno)
        {
            return r.GetEmployeeCity(eno);
        }

    }
}
