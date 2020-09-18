using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_StatistcPartTypeBll
    {
        private readonly ISys_StatistcPartTypeDal dal = DataProductionAccess.CreateSys_StatistcPartType();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string tcode)
        {
            return dal.Exists(tcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_StatistcPartType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_StatistcPartType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string tcode)
        {

            return dal.Delete(tcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_StatistcPartType Query(string id)
        {

            return dal.Query(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_StatistcPartType> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetInvPartType(string icode, string pcode)
        {
            return dal.SetInvPartType(icode, pcode);
        }
        public int ReSetInvPartType(string icode)
        {
            return dal.ReSetInvPartType(icode);
        }
        public string GetInvPartType(string icode)
        {
            return dal.GetInvPartType(icode);
        }
        #endregion  ExtensionMethod
    }
}
