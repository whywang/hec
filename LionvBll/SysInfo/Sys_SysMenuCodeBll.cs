using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public class Sys_SysMenuCodeBll
    {
        private readonly ISys_SysMenuCodeDal dal = DataAccess.CreateSys_SysMenuCode();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string scode)
        {
            return dal.Exists(scode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_SysMenuCode model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SysMenuCode model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string scode)
        {

            return dal.Delete(scode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_SysMenuCode Query(string id)
        {

            return dal.Query(id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SysMenuCode> QueryList(string strWhere)
        {

            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetEnMenuCode(string emcode, string scode, string dcode)
        {
            return dal.SetEnMenuCode(emcode, scode, dcode);
        }
        public bool ReSetEnMenuCode(string emcode)
        {
            return dal.ReSetEnMenuCode(emcode);
        }
        public string GetEnMenuCode(string emcode)
        {
            return dal.GetEnMenuCode(emcode);
        }
        public string QueryEmcode(string scode, string bdcode)
        {
            return dal.QueryEmcode(scode, bdcode);
        }

        #endregion  ExtensionMethod
    }
}
