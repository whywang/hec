using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_UnitBll
    {
       private ISys_UnitDal r = DataAccess.CreateSys_Unit();
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
        public int Add(Sys_Unit model)
        {
             
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_Unit model)
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
        public Sys_Unit Query(string where)
        { 
            return r.Query(where);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Unit> QueryList(string where)
        { 
            return r.QueryList(where);
        }

        public List<Sys_Unit> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        { 
            return r.QueryList( curpage,  pagesize,  where,  sort, ref  rcount, ref  pcount);
        }
        #endregion
        #region  MethodEx
        public int CreateCode()
        {
             return r.CreateCode();
        }
        #endregion  MethodEx
    }
}
