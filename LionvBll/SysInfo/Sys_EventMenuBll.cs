using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvFactoryDal;
using LionvIDal.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_EventMenuBll
    {
       private ISys_EventMenuDal r = DataAccess.CreateSys_EventMenu();
        #region  成员方法
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
        public int Add(Sys_EventMenu model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_EventMenu model)
        {
            return r.Update(model); ;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string emcode)
        { 
            return r.Delete(emcode);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_EventMenu Query(string where)
        { 
            return r.Query(where);
        }
 

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_EventMenu> QueryList(string where)
        { 
            return r.QueryList(where);
        }

        #endregion  成员方法
        #region  MethodEx
        public int CreateCode()
        {
            return r.CreateCode();
        }
        #endregion  MethodEx
    }
}
