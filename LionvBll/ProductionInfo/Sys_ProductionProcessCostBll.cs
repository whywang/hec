using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using System.Collections;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProductionProcessCostBll
    {
       
        private readonly ISys_ProductionProcessCostDal dal = DataProductionAccess.CreateSys_ProductionProcessCost();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ucode)
        {
            return dal.Exists(ucode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessCost model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProductionProcessCost model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ucode)
        {

            return dal.Delete(ucode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProductionProcessCost Query(string where)
        {
            Sys_ProductionProcessCostPartBll sppcpb = new Sys_ProductionProcessCostPartBll();
            Sys_ProductionProcessCost spp= dal.Query(where);
            if (spp != null)
            {
               spp.bjlist= sppcpb.QueryListStr(" and ucode='" + spp.ucode + "'");
            }
            return spp;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessCost> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetGyCost(ArrayList pcode, string gcode, string[] ucode)
        {
            return dal.SetGyCost(pcode, gcode, ucode);
        }
        public bool ReSetGyCost(ArrayList pcode, string gcode)
        {
            return dal.ReSetGyCost(pcode, gcode);
        }
        public string GetGyCost(string pcode, string gcode)
        {
            return dal.GetGyCost(pcode, gcode);
        }
        #endregion  ExtensionMethod
    }
}
