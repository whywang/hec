using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeAttrBll
    {
       private readonly ISys_SizeAttrDal dal=DataProductionAccess.CreateSys_SizeAttr();
	 
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
		public int  Add( Sys_SizeAttr model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SizeAttr model)
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
		public  Sys_SizeAttr Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeAttr> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSizeType(List<string> icode, string[] scode)
        {
            return dal.SetSizeType(icode, scode);
        }
        public bool ReSetSizeType(List<string> icode)
        {
            return dal.ReSetSizeType(icode);
        }
        public string GetSizeType(string icode)
        {
            return dal.GetSizeType(icode);
        }
		#endregion  ExtensionMethod
    }
}
