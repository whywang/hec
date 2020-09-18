using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using System.Collections;

namespace LionvBll.SysInfo
{
   public class Sys_SaleDiscountBll
    {
        private readonly ISys_SaleDiscountDal dal = DataAccess.CreateSys_SaleDiscount();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SaleDiscount model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SaleDiscount model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string dcode)
        {

            return dal.Delete(dcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SaleDiscount Query(string id)
        {

            return dal.Query(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SaleDiscount> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetProdctionDiscount(string dcode,string icode, string[] pcodes)
        {
            return dal.SetProdctionDiscount(dcode, icode, pcodes);
        }
        public int ReSetProdctionDiscount(string dcode,string icode)
        {
            return dal.ReSetProdctionDiscount(dcode,icode);
        }
        public string GetProdctionDiscount(string dcode,string icode)
        {
            return dal.GetProdctionDiscount(dcode,icode);
        }
        public bool CheckProductionDiscount(string dcode, string pcode)
        {
            return dal.CheckProductionDiscount(dcode, pcode);
        }
        public int SetDepDiscount(string sdcode, string[] dcodes)
        {
            return dal.SetDepDiscount(sdcode, dcodes);
        }
        public int ReSetDepDiscount(string dcode)
        {
            return dal.ReSetDepDiscount(dcode);
        }
        public string GetDepDiscount(string dcode)
        { 
            return dal.GetDepDiscount(dcode);
        }
        public ArrayList QueryLoopSaleDiscount(string dcode)
        {
            return dal.QueryLoopSaleDiscount(dcode);
        }

        #endregion  ExtensionMethod
    }
}
