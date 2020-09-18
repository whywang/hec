using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
    public class Sys_ProduceImgBll
    {
        private readonly ISys_ProduceImgDal r = DataProductionAccess.CreateSys_ProduceImg();
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            return r.Exists(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Sys_ProduceImg model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_ProduceImg model)
        { 
            return r.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        { 
            return r.Delete(where);

        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Sys_ProduceImg Query(string where)
        { 
            return r.Query(where);
        }
 

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_ProduceImg> QueryList(string strWhere)
        { 
            return r.QueryList(strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        { 
            return r.CreateCode();

        }
        public int SetProductionImg(string pcode, string icode)
        {
            return r.SetProductionImg(pcode, icode);
        }
        public int ReSetProductionImg(string pcode)
        {
            return r.ReSetProductionImg(pcode);
        }
        public  string GetProductionImg(string pcode)
        {
            return r.GetProductionImg(pcode);
        }
        /// <summary>
        /// 获取产品图片
        /// </summary>
        /// <param name="pcode"></param>
        /// <returns></returns>
        public Sys_ProduceImg QueryInvImg(string pcode)
        {
            Sys_ProduceImg b = new Sys_ProduceImg();
            string icode=r.GetProductionImg(pcode);
            if (icode != "")
            {
                b = r.Query(" and icode='" + icode + "'");
            }
            else
            {
                b = null;
            }
            return b;
        }
        #endregion  ExtensionMethod
    }
}
