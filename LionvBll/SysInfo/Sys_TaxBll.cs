using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public class Sys_TaxBll
    {
        private readonly ISys_TaxDal dal = DataAccess.CreateSys_Tax();
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
        public int Add(Sys_Tax model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_Tax model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {

            return dal.Delete(where);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_Tax Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Tax> QueryList(string where)
        {
            return dal.QueryList(where);
        }
 
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public int SetAgentTax(string dcode, string tcode)
        {
            return dal.SetAgentTax(dcode, tcode);
        }
        public int ReSetAgentTax(string dcode)
        {
            return dal.ReSetAgentTax(dcode);
        }
        public string GetAgentTax(string dcode)
        {
            return dal.GetAgentTax(dcode);
        }
        #endregion  ExtensionMethod
    }
}
