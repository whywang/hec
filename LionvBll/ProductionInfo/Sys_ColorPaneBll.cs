using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.ProductionInfo;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;

namespace LionvBll.ProductionInfo
{
   public class Sys_ColorPaneBll
    {

       private readonly ISys_ColorPaneDal dal = DataProductionAccess.CreateSys_ColorPane();
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Sys_ColorPane model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update( Sys_ColorPane model)
        {
            return dal.Update(model);
        }

 
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string sbcode)
        {

            return dal.Delete(sbcode);
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public  Sys_ColorPane Query(string id)
        {
            return dal.Query(id);
        }
 
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List< Sys_ColorPane> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }
 
        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        #endregion  ExtensionMethod
    }
}
