using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.SysInfo;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_RoleBll
    {
       private ISys_RoleDal r = DataAccess.CreateSys_Role();
        public bool Exists(string where)
        {
            return r.Exists(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_Role model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_Role model)
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
        public Sys_Role Query(string where)
        { 
            return r.Query(where);
        }

        public List<Sys_Role> QueryList(string where)
        {
            return r.QueryList(where);
        }
        public List<Sys_Role> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        { 
            return r.QueryList( curpage,  pagesize,  where,  sort, ref  rcount, ref  pcount);
        }
        #region  MethodEx
        public int CreateCode()
        { 
            return r.CreateCode();
        }
        #endregion  MethodEx
    }
}
