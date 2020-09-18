using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.Account;

namespace LionvFactoryDal
{
   public class AccountAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public AccountAccess()
		{ }
        #region CreateObject
        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch
            {
                return null;
            }

        }
        ////使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.Get(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.Insert(classNamespace, objType); 
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message; 
                }
            }
            return objType;
        }
        #endregion
        /// <summary>
        /// 创建A_CustomeAccount数据层接口。
        /// </summary>
        public static  IA_CustomeAccountDal CreateA_CustomeAccount()
        {
            string ClassNamespace = AssemblyPath + ".Account.A_CustomeAccountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IA_CustomeAccountDal)objType;
        }
        /// <summary>
        /// 创建Sbk_Account数据层接口。
        /// </summary>
        public static ISbk_AccountDal CreateSbk_Account()
        {

            string ClassNamespace = AssemblyPath + ".Account.Sbk_AccountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISbk_AccountDal)objType;
        }
        /// <summary>
        /// 创建Sbk_CollectionAccount数据层接口。
        /// </summary>
        public static  ISbk_CollectionAccountDal CreateSbk_CollectionAccount()
        {

            string ClassNamespace = AssemblyPath + ".Account.Sbk_CollectionAccountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISbk_CollectionAccountDal)objType;
        }
        /// <summary>
        /// 创建Sbk_PaymentAccount数据层接口。
        /// </summary>
        public static  ISbk_PaymentAccountDal CreateSbk_PaymentAccount()
        {

            string ClassNamespace = AssemblyPath + ".Account.Sbk_PaymentAccountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISbk_PaymentAccountDal)objType;
        }
        /// <summary>
        /// 创建Bk_AccountRecorder数据层接口。
        /// </summary>
        public static IB_ExchangeRecordDal CreateBk_AccountRecorder()
        {

            string ClassNamespace = AssemblyPath + ".Account.B_ExchangeRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_ExchangeRecordDal)objType;
        }
        /// <summary>
        /// 创建Bk_PaymentOrder数据层接口。
        /// </summary>
        public static  IBk_PaymentOrderDal CreateBk_PaymentOrder()
        {

            string ClassNamespace = AssemblyPath + ".Account.Bk_PaymentOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IBk_PaymentOrderDal)objType;
        }
        /// <summary>
        /// 创建B_CityPayOrder数据层接口。
        /// </summary>
        public static  IB_CityPayOrderDal CreateB_CityPayOrder()
        {

            string ClassNamespace = AssemblyPath + ".Account.B_CityPayOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_CityPayOrderDal)objType;
        }
        /// <summary>
		/// 创建Sys_Bank数据层接口。
		/// </summary>
		public static ISys_BankDal CreateSys_Bank()
		{
            string ClassNamespace = AssemblyPath + ".Account.Sys_BankDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_BankDal)objType;
		}
    }
}
