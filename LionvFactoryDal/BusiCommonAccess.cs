using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvCommon;
using System.Configuration;
using System.Reflection;
using LionvIDal.BusiCommon;

namespace LionvFactoryDal
{
   public sealed  class BusiCommonAccess
    {
         private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public BusiCommonAccess()
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
        /// 创建CB_ButtonEvent数据层接口。
        /// </summary>
        public static ICB_ButtonEventDal CreateCB_ButtonEvent()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OrderEventBtnDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_ButtonEventDal)objType;
        }
        /// <summary>
		/// 创建CB_OrderFlow数据层接口。
		/// </summary>
        public static ICB_OrderFlowDal CreateCB_OrderFlow()
        {
            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OrderFlowDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICB_OrderFlowDal)objType;
        }
        /// <summary>
        /// 创建CB_OperationRecod数据层接口。
        /// </summary>
        public static ICB_OperationRecodDal CreateCB_OperationRecod()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OperationRecodDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICB_OperationRecodDal)objType;
        }
        /// <summary>
        /// 创建CB_OrderState数据层接口。
        /// </summary>
        public static ICB_OrderStateDal CreateCB_OrderState()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OrderStateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_OrderStateDal)objType;
        }
        /// <summary>
        /// 创建View_s_allorders数据层接口。
        /// </summary>
        public static IAll_SearchOrderDal CreateAll_SearchOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.All_SearchOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IAll_SearchOrderDal)objType;
        }
        /// <summary>
        /// 创建CB_SapRecord数据层接口。
        /// </summary>
        public static  ICB_SapRecordDal CreateCB_SapRecord()
        {
            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_SapRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_SapRecordDal)objType;
        }
        /// <summary>
        /// 创建CB_OrderTraceRecord数据层接口。
        /// </summary>
        public static  ICB_OrderTraceRecordDal CreateCB_OrderTraceRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OrderTraceRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICB_OrderTraceRecordDal)objType;
        }
        /// <summary>
        /// 创建CB_InSapRecord数据层接口。
        /// </summary>
        public static ICB_InSapRecordDal CreateCB_InSapRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_InSapRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICB_InSapRecordDal)objType;
        }
        /// <summary>
        /// 创建CB_SaleDiscount数据层接口。
        /// </summary>
        public static  ICB_SaleDiscountDal CreateCB_SaleDiscount()
        {
            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_SaleDiscountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_SaleDiscountDal)objType;
        }
        /// <summary>
        /// 创建CB_OrderProduceProcess数据层接口。
        /// </summary>
        public static ICB_OrderProduceProcessDal CreateCB_OrderProduceProcess()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_OrderProduceProcessDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_OrderProduceProcessDal)objType;
        }
        /// <summary>
        /// 创建CB_Message数据层接口。
        /// </summary>
        public static ICB_MessageDal CreateCB_Message()
        {
            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_MessageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ICB_MessageDal)objType;
        }
        /// <summary>
        /// 创建CB_ProcessRecord数据层接口。
        /// </summary>
        public static  ICB_ProcessRecordDal CreateCB_ProcessRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_ProcessRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ICB_ProcessRecordDal)objType;
        }
        /// <summary>
		/// 创建CB_CodeRecorder数据层接口。
		/// </summary>
		public static ICB_CodeRecorderDal CreateCB_CodeRecorder()
		{

			string ClassNamespace = AssemblyPath +".BusiCommon.CB_CodeRecorderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ICB_CodeRecorderDal)objType;
		}
       	/// <summary>
		/// 创建CB_ProductionProcess数据层接口。
		/// </summary>
		public static ICB_ProductionProcessDal CreateCB_ProductionProcess()
		{

			string ClassNamespace = AssemblyPath +".BusiCommon.CB_ProductionProcessDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ICB_ProductionProcessDal)objType;
		}
        /// <summary>
		/// 创建CB_SendAddress数据层接口。
		/// </summary>
		public static ICB_SendAddressDal CreateCB_SendAddress()
		{
			string ClassNamespace = AssemblyPath +".BusiCommon.CB_SendAddressDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ICB_SendAddressDal)objType;
		}
        /// <summary>
		/// 创建CB_OrderProduceType数据层接口。
		/// </summary>
		public static ICB_OrderProduceTypeDal CreateCB_OrderProduceType()
		{

			string ClassNamespace = AssemblyPath +".BusiCommon.CB_OrderProduceTypeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ICB_OrderProduceTypeDal)objType;
		}
       /// <summary>
		/// 创建CB_ProduceStartDate数据层接口。
		/// </summary>
		public static ICB_ProduceStartDateDal CreateCB_ProduceStartDate()
		{

            string ClassNamespace = AssemblyPath + ".BusiCommon.CB_ProduceStartDateDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ICB_ProduceStartDateDal)objType;
		}
    }
}
