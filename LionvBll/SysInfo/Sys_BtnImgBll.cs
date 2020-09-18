using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;

namespace LionvBll.SysInfo
{
  public  class Sys_BtnImgBll
    {

        private readonly ISys_BtnImgDal dal = DataAccess.CreateSys_BtnImg();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string bcode)
        {
            return dal.Exists(bcode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_BtnImg model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_BtnImg model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string bcode)
        {

            return dal.Delete(bcode);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_BtnImg Query(string where)
        {

            return dal.Query(where);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_BtnImg> QueryList(string strWhere)
        {
            return dal.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public string QueryBurl(string bcode)
        {
            string r = "";
            if (bcode != "")
            {
                Sys_BtnImg sbi = Query(" and bcode='" + bcode + "'");
                if (sbi != null)
                {
                    r = sbi.burl;
                }
            }
            return r;
        }
        #endregion  ExtensionMethod
    }
}
