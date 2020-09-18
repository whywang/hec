using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_OverComputeFunctionBll
    {
        private readonly ISys_OverComputeFunctionDal r = DataProductionAccess.CreateSys_OverComputeFunction();
        #region  BasicMethod
        public bool Exists(string where)
        {
            return r.Exists(where);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_OverComputeFunction model)
        {
            return r.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_OverComputeFunction model)
        {
            return r.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fcode)
        {

            return r.Delete(fcode);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_OverComputeFunction Query(string where)
        {
            return r.Query(where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_OverComputeFunction> QueryList(string where)
        {
            return r.QueryList(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return r.CreateCode();
        }
        public int SetProductionOcm(string pcode, string fcode)
        {
            return r.SetProductionOcm(pcode, fcode);
        }
        public int ReSetProductionOcm(string pcode)
        {
            return r.ReSetProductionOcm(pcode);
        }
        public string GetProductionOcm(string pcode)
        {
            return r.GetProductionOcm(pcode);
        }
        #endregion  ExtensionMethod
    }
}
