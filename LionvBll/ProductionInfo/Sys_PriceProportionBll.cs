using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_PriceProportionBll
    {
        private readonly ISys_PriceProportionDal dal = DataProductionAccess.CreateSys_PriceProportion();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_PriceProportion model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_PriceProportion model)
        {
            return dal.Update(model);
        }
 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ppcode)
        {

            return dal.Delete(ppcode);
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_PriceProportion Query(string id)
        {
            return dal.Query(id);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_PriceProportion> QueryList(string where)
        {

            return dal.QueryList(where) ;
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetPriceBl(string icode, string ppcode)
        {
            return dal.SetPriceBl(icode, ppcode);
        }
        public int ReSetPriceBl(string icode)
        { 
            return dal.ReSetPriceBl(icode);
        }
        public string GetSetPriceBl(string icode)
        { 
            return dal.GetSetPriceBl(icode);
        }
        #endregion  ExtensionMethod
    }
}
