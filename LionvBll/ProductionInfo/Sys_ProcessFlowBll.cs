using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProcessFlowBll
    {
        private readonly ISys_ProcessFlowDal r = DataProductionAccess.CreateSys_ProcessFlow();
        #region  BasicMethod
        public bool Exists(string where)
        { 
            return r.Exists(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProcessFlow model)
        { 
            return r.Add(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProcessFlow model)
        { 
            return r.Update(model);
        }

        public bool Delete(string where)
        { 
            return r.Delete(where);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProcessFlow Query(string where)
        {
            return r.Query(where);

        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProcessFlow> QueryList(string strWhere)
        { 
            return r.QueryList(strWhere);
            
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        { 
            return r.CreateCode();
        }
        #endregion  ExtensionMethod
    }
}
