using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_ProductionAttrExCateBll
    {
       private readonly ISys_ProductionAttrExCateDal dal=DataProductionAccess.CreateSys_ProductionAttrExCate();
 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string accode)
		{
			return dal.Exists(accode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_ProductionAttrExCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_ProductionAttrExCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string accode)
		{
			
			return dal.Delete(accode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_ProductionAttrExCate Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_ProductionAttrExCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere); 
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetAttrCateAttr(string accode, string acode)
        {
            return dal.SetAttrCateAttr(accode, acode);
        }
        public bool ReSetAttrCateAttr(string accode)
        {
            return dal.ReSetAttrCateAttr(accode);
        }
        public string GetAttrCateAttr(string accode)
        {
            return dal.GetAttrCateAttr(accode);
        }

        public bool SetInvAttrCate(string icode, string accode)
        {
            return dal.SetInvAttrCate(icode, accode);
        }
        public bool ReSetInvAttrCate(string icode)
        {
            return dal.ReSetInvAttrCate(icode);
        }
        public string GetInvAttrCate(string icode)
        {
            return dal.GetInvAttrCate(icode);
        }
		#endregion  ExtensionMethod
    }
}
