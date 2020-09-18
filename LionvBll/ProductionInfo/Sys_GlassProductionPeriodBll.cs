using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_GlassProductionPeriodBll
    {
        private readonly ISys_GlassProductionPeriodDal dal = DataProductionAccess.CreateSys_GlassProductionPeriod();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string gqcode)
        {
            return dal.Exists(gqcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_GlassProductionPeriod model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_GlassProductionPeriod model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string gqcode)
        {

            return dal.Delete(gqcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_GlassProductionPeriod Query(string id)
        {

            return dal.Query(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_GlassProductionPeriod> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetGlassPeriod(string icode, string fcode, string gqcode)
        {
            return dal.SetGlassPeriod(icode, fcode, gqcode);
        }
        public bool ReSetGlassPeriod(string icode, string fcode)
        {
            return dal.ReSetGlassPeriod(icode, fcode);
        }
        public string GetGlassPeriod(string icode, string fcode)
        {
            return dal.GetGlassPeriod(icode, fcode);
        }
        #endregion  ExtensionMethod
    }
}
