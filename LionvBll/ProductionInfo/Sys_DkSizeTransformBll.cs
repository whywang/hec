using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.ProductionInfo;
using LionvFactoryDal;
using LionvModel.ProductionInfo;
using LionvCommon;

namespace LionvBll.ProductionInfo
{
   public class Sys_DkSizeTransformBll
    {
       	private readonly ISys_DkSizeTransformDal dal=DataProductionAccess.CreateSys_DkSizeTransform();
	 
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
		public int  Add( Sys_DkSizeTransform model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( Sys_DkSizeTransform model)
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
		public  Sys_DkSizeTransform Query(string id)
		{

            return dal.Query(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Sys_DkSizeTransform> QueryList(string strWhere)
		{
            return dal.QueryList(strWhere);
		}
		 
		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public bool SetRDsize(string icode, string sfcode)
        {
            return dal.SetRDsize(icode, sfcode);
        }
        public bool ReSetRDsize(string icode)
        {
            return dal.ReSetRDsize(icode);
        }
        public string GetRDsize(string icode)
        {
            return dal.GetRDsize(icode);
        }
        public string[] GetRDsize(string icode, string g, string k, string t)
        {
            string[] arr = new string[2];
            if (t != "dk"&&t!="")
            {
                string pcode = icode.Substring(0, icode.Length - 3);
                string dcode = dal.GetRDsize(pcode);
                Sys_DkSizeTransform sf = Query(" and sfcode='" + dcode + "'");
                if (sf != null)
                {
                    if (t == "wj")
                    {
                        int wh = 0;
                        int ww = 0;
                        string gstr = sf.wtdh.Replace("H", g);
                        ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Int32"), gstr, "EvaluateInt");
                        wh = gcf.EvaluateInt("EvaluateInt");
                        string gstr1 = sf.wtdw.Replace("W", k);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        ww = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] = wh.ToString();
                        arr[1] = ww.ToString();
                    }
                    if (t == "nj")
                    {
                        int nh = 0;
                        int nw = 0;
                        string gstr = sf.ntdh.Replace("H", g);
                        ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Int32"), gstr, "EvaluateInt");
                        nh = gcf.EvaluateInt("EvaluateInt");
                        string gstr1 = sf.ntdw.Replace("W", k);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        nw = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] = nh.ToString();
                        arr[1] = nw.ToString();
                    }
                    if (t == "ng")
                    {
                        int nh = 0;
                        string gstr = sf.ntdh.Replace("H", g);
                        ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Int32"), gstr, "EvaluateInt");
                        nh = gcf.EvaluateInt("EvaluateInt");
                        arr[0] = nh.ToString();
                        arr[1] = k;
                    }
                    if (t == "nk")
                    {
                        int nw = 0;
                        string gstr1 = sf.ntdw.Replace("W", k);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        nw = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] = g;
                        arr[1] = nw.ToString();
                    }
                    if (t == "wg")
                    {
                        int nh = 0;
                        string gstr = sf.wtdh.Replace("H", g);
                        ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Int32"), gstr, "EvaluateInt");
                        nh = gcf.EvaluateInt("EvaluateInt");
                        arr[0] = nh.ToString();
                        arr[1] = k;
                    }
                    if (t == "wk")
                    {
                        int nw = 0;
                        string gstr1 = sf.wtdw.Replace("W", k);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        nw = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] = g;
                        arr[1] = nw.ToString();
                    }
                    if (t == "wkng")
                    {
                        int wk = 0;
                        string gstr2= sf.wtdw.Replace("W", k);
                        ComputeFunction gcf2= new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                        wk = gcf2.EvaluateInt("EvaluateInt");
                        int ng = 0;
                        string gstr1 = sf.ntdh.Replace("H", g);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        ng = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] =ng.ToString();
                        arr[1] =wk.ToString() ;
                    }
                    if (t == "wgnk")
                    {
                        int wg = 0;
                        string gstr1 = sf.wtdh.Replace("H", g);
                        ComputeFunction gcf1 = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                        wg = gcf1.EvaluateInt("EvaluateInt");
                        int nw = 0;
                        string gstr2 = sf.ntdw.Replace("W", k);
                        ComputeFunction gcf2 = new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                        nw = gcf1.EvaluateInt("EvaluateInt");
                        arr[0] = wg.ToString();
                        arr[1] = nw.ToString();
                    }
                }
                else
                {
                    arr = null;
                }
            }
            else
            {
                arr = null;
            }
            return arr;
        }
		#endregion  ExtensionMethod
    }
}
