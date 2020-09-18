using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiCommon;
using LionvFactoryDal;
using LionvModel.BusiCommon;

namespace LionvBll.BusiCommon
{
    public class CB_OrderFlowBll
    {
        private ICB_OrderFlowDal r = BusiCommonAccess.CreateCB_OrderFlow();
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(CB_OrderFlow model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CB_OrderFlow model)
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
        public CB_OrderFlow Query(string where)
        { 
            return r.Query(where);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CB_OrderFlow> QueryList(string strWhere)
        { 
            return r.QueryList(strWhere);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod

        public int CreateWorkFlow(string sql)
        {
            return r.CreateWorkFlow(sql);
        }
        //获取当前流程节点
        public string QueryCurWorkFlow(string sid)
        {
            return r.QueryCurWorkFlow(sid);
        }
        #endregion  ExtensionMethod
    }
}
