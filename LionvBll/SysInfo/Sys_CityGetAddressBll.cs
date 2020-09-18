using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvIDal.SysInfo;
using LionvFactoryDal;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
   public class Sys_CityGetAddressBll
    {
       private readonly ISys_CityGetAddressDal dal=DataAccess.CreateSys_CityGetAddress();

		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string sacode)
		{
			return dal.Exists(sacode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Sys_CityGetAddress model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Sys_CityGetAddress model)
		{
			return dal.Update(model);
		}

 
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string sacode)
		{
			
			return dal.Delete(sacode);
		}
 

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Sys_CityGetAddress Query(string where)
		{

            return dal.Query(where);
		}
 
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Sys_CityGetAddress> QueryList(string where)
		{ 
			return dal.QueryList(where);
		}
 

		#endregion  BasicMethod
		#region  ExtensionMethod
        public int CreateCode()
        {
            return dal.CreateCode();
        }
        public Sys_CityGetAddress QueryFrist(string where)
        {
            Sys_CityGetAddress r = new Sys_CityGetAddress();
            string wheres = " and isfrist='true'" + where;
            Sys_CityGetAddress sa = dal.Query(wheres);
            if (sa == null)
            {
                List<Sys_CityGetAddress> lsa = dal.QueryList(where);
                if (lsa != null)
                {
                    r = lsa[0];
                }
            }
            else
            {
                r = sa;
            }
            return r;
        }
        public Sys_CityGetAddress QueryRefFrist(string code)
        {
            Sys_CityGetAddress r = new Sys_CityGetAddress();
            string wheres = " and isfrist='true' and dcode='"+code+"'";
            Sys_CityGetAddress sa = dal.Query(wheres);
            if (sa == null)
            {
                List<Sys_CityGetAddress> lsa = dal.QueryList(" and dcode='"+code+"'");
                if (lsa != null)
                {
                    r = lsa[0];
                }
                else
                {
                     
                    Sys_CityGetAddress saa = dal.Query(" and isfrist='true' and dcode='" + code.Substring(0,code.Length-3) + "'");
                    if (saa != null)
                    {
                        r = saa;
                    }
                    else
                    {
                        List<Sys_CityGetAddress> lsaa = dal.QueryList(" and dcode='" + code.Substring(0, code.Length - 3) + "'");
                        if (lsaa != null)
                        {
                            r = lsaa[0];
                        }
                    }
                }
            }
            else
            {
                r = sa;
            }
            return r;
        }
		#endregion  ExtensionMethod
    }
}
