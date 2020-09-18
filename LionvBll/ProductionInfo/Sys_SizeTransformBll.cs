using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeTransformBll
    {
       private static ISys_SizeTransformDal r = DataProductionAccess.CreateSys_SizeTransform();
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
        public int Add(Sys_SizeTransform model)
        { 
            return r.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Sys_SizeTransform model)
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
        public Sys_SizeTransform Query(string where)
        {
             
            return r.Query(where);

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_SizeTransform> QueryList(string where)
        {
            return r.QueryList(where);
        }
        public List<Sys_SizeTransform> QueryList(int curpage, int pagesize, string where, string sort, ref int rcount, ref int pcount)
        {
            return r.QueryList( curpage,  pagesize,  where,  sort, ref  rcount, ref  pcount);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public int CreateCode()
        {
            return r.CreateCode();
        }
        public int SetProductionJc(string pcode, string jcode)
        {
            return r.SetProductionJc(pcode, jcode);
        }
        public int ReSetProductionJc(string pcode )
        {
            return r.ReSetProductionJc(pcode );
        }
        public string GetProductionJc(string pcode)
        {
            return r.GetProductionJc(pcode);
        }
        #endregion  ExtensionMethod
    }
}
