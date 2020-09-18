using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public partial class Sys_ProductionPriceTempCateBll
    {
        private readonly ISys_ProductionPriceTempCateDal dal = DataProductionAccess.CreateSys_ProductionPriceTempCate();
        
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ppicode)
        {
            return dal.Exists(ppicode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionPriceTempCate model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProductionPriceTempCate model)
        {
            return dal.Update(model);
        }

 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ppicode)
        {

            return dal.Delete(ppicode);
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProductionPriceTempCate Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionPriceTempCate> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
 
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        { 
            return dal.CreateCode();
        }
        public bool SetInvPtemp(string icode, string ptcode)
        {
            return dal.SetInvPtemp(icode, ptcode);
        }
        public bool ReSetInvPtemp(string icode)
        {
            return dal.ReSetInvPtemp(icode);
        }
        public string GetInvPtemp(string icode)
        {
            return dal.GetInvPtemp(icode);
        }
         
        #endregion  ExtensionMethod
    }
}
