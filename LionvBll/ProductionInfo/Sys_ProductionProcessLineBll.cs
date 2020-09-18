using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProductionProcessLineBll
    {
        private readonly ISys_ProductionProcessLineDal dal = DataProductionAccess.CreateSys_ProductionProcessLine();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string lcode)
        {
            return dal.Exists(lcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProductionProcessLine model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProductionProcessLine model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string lcode)
        {

            return dal.Delete(lcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProductionProcessLine Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProductionProcessLine> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetProcessLine(string pcode, string lcode)
        {
            return dal.SetProcessLine(pcode, lcode);
        }
        public bool ReSetProcessLine(string pcode)
        {
            return dal.ReSetProcessLine(pcode);
        }
        public string GetProcessLine(string pcode)
        {
            return dal.GetProcessLine(pcode);
        }
        public bool UpUtime(string lcode, int utime)
        {
            return dal.UpUtime(lcode, utime);
        }
        #endregion  ExtensionMethod
    }
}
