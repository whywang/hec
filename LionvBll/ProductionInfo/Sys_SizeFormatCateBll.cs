using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;

namespace LionvBll.ProductionInfo
{
   public class Sys_SizeFormatCateBll
    {
       
		private readonly ISys_SizeFormatCateDal dal=DataProductionAccess.CreateSys_SizeFormatCate();
	 
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sfcode)
		{
			return dal.Exists(sfcode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( Sys_SizeFormatCate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_SizeFormatCate model)
		{
			return dal.Update(model);
		}
 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sfcode)
		{
			
			return dal.Delete(sfcode);
		}
 
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  Sys_SizeFormatCate Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_SizeFormatCate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetSizeFormat(string icode,string pcode,string sfcode)
        {
            return dal.SetSizeFormat(icode, pcode, sfcode);
        }
        public bool ReSetSizeFormat(string icode, string pcode)
        {
            return dal.ReSetSizeFormat(icode, pcode);
        }
        public string GetSizeFormat(string pcode)
        {
            return dal.GetSizeFormat(pcode);
        }
		#endregion  ExtensionMethod
    }
}
