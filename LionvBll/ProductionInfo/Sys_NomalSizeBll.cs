using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    
    public class Sys_NomalSizeBll
    {
        private static ISys_NomalSizeDal r = DataAccess.CreateSys_NomalSize();
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
        public int Add(Sys_NomalSize model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_NomalSize model)
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
        public Sys_NomalSize Query(string where)
        { 
            return r.Query(where);
        }
        

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_NomalSize> QueryList(string where)
        { 
            return r.QueryList(where);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        { 
            return r.CreateCode();
        }
        public int SetProductionNs(string pcode, string ncode)
        {
            return r.SetProductionNs(pcode, ncode);
        }
        public  int ReSetProductionNs(string pcode)
        {
            return r.ReSetProductionNs(pcode );
        }
        public  string GetProductionNs(string pcode)
        { 
            return r.GetProductionNs(pcode );
        }
        #endregion  ExtensionMethod
    }
}
