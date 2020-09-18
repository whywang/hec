using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public class Sys_WorkEventBll
    {
        private ISys_WorkEventDal r = DataAccess.CreateSys_WorkEvent();
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

        public int Add(Sys_WorkEvent model)
        { 
            return r.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_WorkEvent model)
        {
            return r.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string wcode)
        { 
            return r.Delete(wcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_WorkEvent Query(string where)
        { 
            return r.Query(where);
        }
 

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_WorkEvent> QueryList(string where)
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
