using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.BusiOrderInfo;
using LionvFactoryDal;
using LionvModel.BusiOrderInfo;

namespace LionvBll.BusiOrderInfo
{
   public class B_AfterCompensateBll
    {
       private readonly IB_AfterCompensateDal dal = BusiOrderAccess.CreateB_AfterCompensate();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sid)
		{
			return dal.Exists(sid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add( B_AfterCompensate model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( B_AfterCompensate model)
		{
			return dal.Update(model);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sid)
		{
			
			return dal.Delete(sid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  B_AfterCompensate Query(string where)
		{

            return dal.Query(where);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<B_AfterCompensate> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		
		#endregion  BasicMethod
		#region  ExtensionMethod
        public string SelPcyy(string v,string p)
        {
            string r = "";
            if (p == "Q")
            {
                if (v.IndexOf("a") > -1)
                {
                    r = r + "<input type='checkbox' name='ztwq' value='Car'  checked='checked' /> 整体晚期<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='ztwq' value='Car'/> 整体晚期<br/>";
                }
                if (v.IndexOf("c") > -1)
                {
                    r = r + "<input type='checkbox' name='bjwq' value='Car'  checked='checked' /> 部件晚期<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='bjwq' value='Car'/> 部件晚期<br/>";
                }
                if (v.IndexOf("e") > -1)
                {
                    r = r + "<input type='checkbox' name='zlwt' value='Car'  checked='checked' /> 产品有质量问题<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='zlwt' value='Car'/> 产品有质量问题<br/>";
                }
            }
            if (p == "H")
            {
                if (v.IndexOf("b") > -1)
                {
                    r = r + "<input type='checkbox' name='ztwq' value='Car'  checked='checked' /> 现场安装问题<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='ztwq' value='Car'/> 现场安装问题<br/>";
                }
                if (v.IndexOf("d") > -1)
                {
                    r = r + "<input type='checkbox' name='bjwq' value='Car'  checked='checked' /> 现场损坏客户财产<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='bjwq' value='Car'/> 现场损坏客户财产<br/>";
                }
                if (v.IndexOf("f") > -1)
                {
                    r = r + "<input type='checkbox' name='zlwt' value='Car'  checked='checked' /> 其他<br/>";
                }
                else
                {
                    r = r + "<input type='checkbox' name='zlwt' value='Car'/> 其他<br/>";
                }
            }

            return r;
        }
		#endregion  ExtensionMethod
    }
}
