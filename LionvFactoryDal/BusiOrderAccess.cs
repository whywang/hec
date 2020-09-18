using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.BusiOrderInfo;

namespace LionvFactoryDal
{
    public sealed class BusiOrderAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public BusiOrderAccess()
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
		/// 创建B_Customer数据层接口。
		/// </summary>
		public static  IB_CustomerDal CreateB_Customer()
		{

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CustomerDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_CustomerDal)objType;
		}
        /// <summary>
        /// 创建B_CustormOrder数据层接口。
        /// </summary>
        public static IB_CustormOrderDal CreateB_CustormOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CustormOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_CustormOrderDal)objType;
        }
        /// <summary>
        /// 创建B_FixecImg数据层接口。
        /// </summary>
        public static IB_FixecImgDal CreateB_FixecImg()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixecImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_FixecImgDal)objType;
        }
        /// <summary>
        /// 创建B_GroupProduction数据层接口。
        /// </summary>
        public static  IB_GroupProductionDal CreateB_GroupProduction()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_GroupProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_GroupProductionDal)objType;
        }
        /// <summary>
        /// 创建B_InHouseOrder数据层接口。
        /// </summary>
        public static IB_InHouseOrderDal CreateB_InHouseOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_InHouseOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_InHouseOrderDal)objType;
        }
        /// <summary>
        /// 创建B_InhousePackage数据层接口。
        /// </summary>
        public static IB_InhousePackageDal CreateB_InhousePackage()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_InhousePackageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_InhousePackageDal)objType;
        }
        /// <summary>
        /// 创建B_MeasureImg数据层接口。
        /// </summary>
        public static IB_MeasureImgDal CreateB_MeasureImg()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MeasureImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_MeasureImgDal)objType;
        }
        /// <summary>
        /// 创建B_MeasureOrder数据层接口。
        /// </summary>
        public static IB_MeasureOrderDal CreateB_MeasureOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MeasureOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_MeasureOrderDal)objType;
        }
        /// <summary>
        /// 创建B_OrderFacotory数据层接口。
        /// </summary>
        public static IB_OrderFacotoryDal CreateB_OrderFacotory()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_OrderFacotoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_OrderFacotoryDal)objType;
        }
        /// <summary>
        /// 创建B_OutHouseOrder数据层接口。
        /// </summary>
        public static IB_OutHouseOrderDal CreateB_OutHouseOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_OutHouseOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_OutHouseOrderDal)objType;
        }
        /// <summary>
        /// 创建B_OutHousePackage数据层接口。
        /// </summary>
        public static IB_OutHousePackageDal CreateB_OutHousePackage()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_OutHousePackageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_OutHousePackageDal)objType;
        }
        /// <summary>
        /// 创建B_Package数据层接口。
        /// </summary>
        public static IB_PackageDal CreateB_Package()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PackageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_PackageDal)objType;
        }
        /// <summary>
        /// 创建B_PayRecord数据层接口。
        /// </summary>
        public static  IB_PayRecordDal CreateB_PayRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PayRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_PayRecordDal)objType;
        }
        /// <summary>
        /// 创建B_ProcessRecord数据层接口。
        /// </summary>
        public static IB_ProcessRecordDal CreateB_ProcessRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_ProcessRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_ProcessRecordDal)objType;
        }
        /// <summary>
        /// 创建B_ProductionItem数据层接口。
        /// </summary>
        public static  IB_ProductionItemDal CreateB_ProductionItem()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_ProductionItemDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_ProductionItemDal)objType;
        }
        /// <summary>
        /// 创建B_SaleOrder数据层接口。
        /// </summary>
        public static  IB_SaleOrderDal CreateB_SaleOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SaleOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_SaleOrderDal)objType;
        }
        /// <summary>
        /// 创建B_yyFixOrderRecord数据层接口。
        /// </summary>
        public static IB_yyFixOrderRecordDal CreateB_yyFixOrderRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_yyFixOrderRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_yyFixOrderRecordDal)objType;
        }
        /// <summary>
        /// 创建B_InHouseRecord数据层接口。
        /// </summary>
        public static  IB_OutHouseRecordDal CreateB_OutHouseRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_OutHouseRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_OutHouseRecordDal)objType;
        }
        /// <summary>
        /// 创建B_InHouseRecord数据层接口。
        /// </summary>
        public static  IB_InHouseRecordDal CreateB_InHouseRecord()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_InHouseRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_InHouseRecordDal)objType;
        }
        /// <summary>
        /// 创建B_InHouseRecord数据层接口。
        /// </summary>
        public static IB_CityInHouseRecordDal CreateB_CityInHouseRecord()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CityInHouseRecordDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_CityInHouseRecordDal)objType;
        }
        /// <summary>
        /// 创建B_AfterSaleOrder数据层接口。
        /// </summary>
        public static IB_AfterSaleOrderDal CreateB_AfterSaleOrder()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterSaleOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_AfterSaleOrderDal)objType;
        }
        /// <summary>
        /// 创建B_FeedBackImg数据层接口。
        /// </summary>
        public static IB_FeedBackImgDal CreateB_FeedBackImg()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FeedBackImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FeedBackImgDal)objType;
        }
        /// <summary>
        /// 创建B_FeedBackImg数据层接口。
        /// </summary>
        public static IB_PreWjOrderDal CreateB_PreWjOrder()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PreWjOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_PreWjOrderDal)objType;
        }
        /// <summary>
        /// 创建B_SelectProduceImg数据层接口。
        /// </summary>
        public static IB_SelectProduceImgDal CreateB_SelectProduceImg()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SelectProduceImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_SelectProduceImgDal)objType;
        }
        /// <summary>
        /// 创建B_ProduceGyImg数据层接口。
        /// </summary>
        public static IB_ProduceGyImgDal CreateB_ProduceGyImg()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_ProduceGyImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_ProduceGyImgDal)objType;
        }
        /// <summary>
        /// 创建B_AfterSearchOrder数据层接口。
        /// </summary>
        public static  IB_AfterSearchOrderDal CreateB_AfterSearchOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterSearchOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_AfterSearchOrderDal)objType;
        }
        /// <summary>
        /// 创建B_SearchSaleOrder数据层接口。
        /// </summary>
        public static  IB_SearchSaleOrderDal CreateB_SearchSaleOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SearchSaleOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_SearchSaleOrderDal)objType;
        }
        /// <summary>
        /// 创建B_Search_Production数据层接口。
        /// </summary>
        public static  IB_Search_ProductionDal CreateB_Search_Production()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_Search_ProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_Search_ProductionDal)objType;
        }
        /// <summary>
        /// 创建B_AfterSearch_Production数据层接口。
        /// </summary>
        public static  IB_AfterSearch_ProductionDal CreateB_AfterSearch_Production()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterSearch_ProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_AfterSearch_ProductionDal)objType;
        }
        /// <summary>
        /// 创建B_CustomerOrderTask数据层接口。
        /// </summary>
        public static IB_CustomerOrderTaskDal CreateB_CustomerOrderTask()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CustomerOrderTaskDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_CustomerOrderTaskDal)objType;
        }
        /// <summary>
        /// 创建B_PackageDate数据层接口。
        /// </summary>
        public static  IB_PackageDateDal CreateB_PackageDate()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PackageDateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_PackageDateDal)objType;
        }
        /// <summary>
        /// 创建B_PackageInSap数据层接口。
        /// </summary>
        public static IB_PackageInSapDal CreateB_PackageInSap()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PackageInSapDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_PackageInSapDal)objType;
        }
        /// <summary>
        /// 获取导入SAP数据层接口。
        /// </summary>
        public static IB_SapOrderDal CreateB_SapOrder()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SapOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_SapOrderDal)objType;
        }
        /// <summary>
        /// 创建B_FixOrder数据层接口。
        /// </summary>
        public static IB_FixOrderDal CreateB_FixOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixOrderDal)objType;
        }
        /// <summary>
        /// 创建B_FixProduction数据层接口。
        /// </summary>
        public static IB_FixProductionDal CreateB_FixProduction()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixProductionDal)objType;
        }
        /// <summary>
        /// 创建B_FixOrderTask数据层接口。
        /// </summary>
        public static IB_FixOrderTaskDal CreateB_FixOrderTask()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixOrderTaskDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixOrderTaskDal)objType;
        }
        /// <summary>
        /// 创建B_FixGetGoodsImg数据层接口。
        /// </summary>
        public static  IB_FixGetGoodsImgDal CreateB_FixGetGoodsImg()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixGetGoodsImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixGetGoodsImgDal)objType;
        }
        /// <summary>
        /// 创建B_FixVisitInfo数据层接口。
        /// </summary>
        public static IB_FixVisitInfoDal CreateB_FixVisitInfo()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixVisitInfoDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixVisitInfoDal)objType;
        }
        /// <summary>
        /// 创建B_FixMoney数据层接口。
        /// </summary>
        public static IB_FixMoneyDal CreateB_FixMoney()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_FixMoneyDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_FixMoneyDal)objType;
        }
        /// <summary>
        /// 创建B_CustomerGather数据层接口。
        /// </summary>
        public static  IB_CustomerGatherDal CreateB_CustomerGather()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CustomerGatherDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_CustomerGatherDal)objType;
        }
        /// <summary>
        /// 创建B_SetMeal数据层接口。
        /// </summary>
        public static IB_SetMealDal CreateB_SetMeal()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SetMealDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_SetMealDal)objType;
        }
        /// <summary>
        /// 创建B_AfterCompensate数据层接口。
        /// </summary>
        public static  IB_AfterCompensateDal CreateB_AfterCompensate()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterCompensateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_AfterCompensateDal)objType;
        }
        /// <summary>
        /// 创建B_YySend数据层接口。
        /// </summary>
        public static  IB_YySendDal CreateB_YySend()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_YySendDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_YySendDal)objType;
        }
        /// <summary>
        /// 创建B_SpecialProduction数据层接口。
        /// </summary>
        public static  IB_SpecialProductionDal CreateB_SpecialProduction()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_SpecialProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_SpecialProductionDal)objType;
        }
        /// <summary>
        /// 创建B_Attachment数据层接口。
        /// </summary>
        public static IB_AttachmentDal CreateB_Attachment()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AttachmentDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_AttachmentDal)objType;
        }
        /// <summary>
        /// 创建B_PayImg数据层接口。
        /// </summary>
        public static  IB_PayImgDal CreateB_PayImg()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_PayImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_PayImgDal)objType;
        }
        /// <summary>
		/// 创建B_HouseProdcution数据层接口。
		/// </summary>
		public static  IB_HouseProdcutionDal CreateB_HouseProdcution()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_HouseProdcutionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_HouseProdcutionDal)objType;
        }
        /// <summary>
        /// 创建B_ApartSendOrder数据层接口。
        /// </summary>
        public static  IB_ApartSendOrderDal CreateB_ApartSendOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_ApartSendOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_ApartSendOrderDal)objType;
        }
        /// <summary>
        /// 创建B_MzSaleOrder数据层接口。
        /// </summary>
        public static IB_QbqqSaleOrderDal CreateB_QbqqSaleOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_QbqqSaleOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_QbqqSaleOrderDal)objType;
        }
        /// <summary>
        /// 创建B_RequstDesignPlan数据层接口。
        /// </summary>
        public static IB_MzRequstDesignDal CreateB_RequstDesignPlan()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzRequstDesignDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_MzRequstDesignDal)objType;
        }
        /// <summary>
        /// 创建B_MzDesignPlan数据层接口。
        /// </summary>
        public static IB_MzDesignPlanDal CreateB_MzDesignPlan()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzDesignPlanDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_MzDesignPlanDal)objType;
        }
        /// <summary>
        /// 创建B_MzDesignTask数据层接口。
        /// </summary>
        public static IB_MzDesignTaskDal CreateB_MzDesignTask()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzDesignTaskDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_MzDesignTaskDal)objType;
        }
        /// <summary>
        /// 创建B_MzPriceFile数据层接口。
        /// </summary>
        public static  IB_MzPriceFileDal CreateB_MzPriceFile()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzPriceFileDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_MzPriceFileDal)objType;
        }
        /// <summary>
        /// 创建B_AfterPriceFile数据层接口。
        /// </summary>
        public static IB_AfterPriceFileDal CreateB_AfterPriceFile()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterPriceFileDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_AfterPriceFileDal)objType;
        }
        /// <summary>
        /// 创建B_MzMeasureFile数据层接口。
        /// </summary>
        public static  IB_MzMeasureFileDal CreateB_MzMeasureFile()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzMeasureFileDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( IB_MzMeasureFileDal)objType;
        }
        /// <summary>
        /// 创建B_CustomeMoneyOrder数据层接口。
        /// </summary>
        public static IB_CustomeMoneyOrderDal CreateB_CustomeMoneyOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_CustomeMoneyOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_CustomeMoneyOrderDal)objType;
        }
        /// <summary>
        /// 创建B_GroupProductionAttr数据层接口。
        /// </summary>
        public static IB_GroupProductionAttrDal CreateB_GroupProductionAttr()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_GroupProductionAttrDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_GroupProductionAttrDal)objType;
        }
        /// <summary>
		/// 创建B_NewProductionPriceOrder数据层接口。
		/// </summary>
		public static IB_NewProductionPriceOrderDal CreateB_NewProductionPriceOrder()
		{

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_NewProductionPriceOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_NewProductionPriceOrderDal)objType;
		}
        /// <summary>
		/// 创建B_DrawProductionOrder数据层接口。
		/// </summary>
		public static IB_DrawProductionOrderDal CreateB_DrawProductionOrder()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_DrawProductionOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_DrawProductionOrderDal)objType;
		}
        /// <summary>
		/// 创建B_WjPartOrder数据层接口。
		/// </summary>
		public static IB_WjPartOrderDal CreateB_WjPartOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_WjPartOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_WjPartOrderDal)objType;
		}
        /// <summary>
		/// 创建B_WjPreparePartOrder数据层接口。
		/// </summary>
		public static IB_WjPreparePartOrderDal CreateB_WjPreparePartOrder()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_WjPreparePartOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_WjPreparePartOrderDal)objType;
		}
        /// <summary>
		/// 创建B_WjPreParePartGroupProduction数据层接口。
		/// </summary>
		public static IB_WjPreParePartGroupProductionDal CreateB_WjPreParePartGroupProduction()
		{
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_WjPreParePartGroupProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_WjPreParePartGroupProductionDal)objType;
		}
        /// <summary>
		/// 创建B_WjPartGroupProduction数据层接口。
		/// </summary>
		public static  IB_WjPartGroupProductionDal CreateB_WjPartGroupProduction()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_WjPartGroupProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_WjPartGroupProductionDal)objType;
		}
        /// <summary>
        /// 创建B_GroupProductionMoney数据层接口。
        /// </summary>
        public static IB_GroupProductionMoneyDal CreateB_GroupProductionMoney()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_GroupProductionMoneyDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_GroupProductionMoneyDal)objType;
        }
        /// <summary>
		/// 创建B_YqSaleOrder数据层接口。
		/// </summary>
		public static IB_YqSaleOrderDal CreateB_YqSaleOrder()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_YqSaleOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_YqSaleOrderDal)objType;
		}
        /// <summary>
		/// 创建B_ProductionCost数据层接口。
		/// </summary>
		public static  IB_ProductionCostDal CreateB_ProductionCost()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_ProductionCostDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_ProductionCostDal)objType;
		}
        /// <summary>
		/// 创建B_PartQualityOrder数据层接口。
		/// </summary>
		public static IB_PartQualityOrderDal CreateB_PartQualityOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_PartQualityOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_PartQualityOrderDal)objType;
		}
        /// <summary>
		/// 创建B_PartQualityItems数据层接口。
		/// </summary>
		public static IB_PartQualityItemsDal CreateB_PartQualityItems()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_PartQualityItemsDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( IB_PartQualityItemsDal)objType;
		}
        /// <summary>
		/// 创建B_PackageCode数据层接口。
		/// </summary>
		public static  IB_PackageCodeDal CreateB_PackageCode()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_PackageCodeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_PackageCodeDal)objType;
		}
        /// <summary>
		/// 创建B_SaleChangeOrder数据层接口。
		/// </summary>
		public static IB_SaleChangeOrderDal CreateB_SaleChangeOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_SaleChangeOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_SaleChangeOrderDal)objType;
		}
        /// <summary>
		/// 创建B_GroupProductionChangeRequst数据层接口。
		/// </summary>
		public static IB_GroupProductionChangeRequstDal CreateB_GroupProductionChangeRequst()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_GroupProductionChangeRequstDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_GroupProductionChangeRequstDal)objType;
		}
        /// <summary>
		/// 创建B_GroupProductionChange数据层接口。
		/// </summary>
		public static  IB_GroupProductionChangeDal CreateB_GroupProductionChange()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_GroupProductionChangeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_GroupProductionChangeDal)objType;
		}
        /// <summary>
		/// 创建B_GroupProductionChangeRecord数据层接口。
		/// </summary>
		public static IB_GroupProductionChangeRecordDal CreateB_GroupProductionChangeRecord()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_GroupProductionChangeRecordDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_GroupProductionChangeRecordDal)objType;
		}
        /// <summary>
		/// 创建B_ProductionItemChangeRecorder数据层接口。
		/// </summary>
		public static IB_ProductionItemChangeRecorderDal CreateB_ProductionItemChangeRecorder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_ProductionItemChangeRecorderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_ProductionItemChangeRecorderDal)objType;
		}
        /// <summary>
		/// 创建B_AfterQbqqSaleOrder数据层接口。
		/// </summary>
		public static  IB_AfterQbqqSaleOrderDal CreateB_AfterQbqqSaleOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterQbqqSaleOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterQbqqSaleOrderDal)objType;
		}
        /// <summary>
		/// 创建B_YqAfterSaleOrder数据层接口。
		/// </summary>
		public static  IB_YqAfterSaleOrderDal CreateB_YqAfterSaleOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_YqAfterSaleOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_YqAfterSaleOrderDal)objType;
		}
        /// <summary>
        /// 创建B_AfterOrderDuty数据层接口。
        /// </summary>
        public static IB_AfterOrderDutyDal CreateB_AfterOrderDuty()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_AfterOrderDutyDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_AfterOrderDutyDal)objType;
        }
        /// <summary>
        /// 创建B_MzSaleOrder数据层接口。
        /// </summary>
        public static IB_MzSaleOrderDal CreateB_MzSaleOrder()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MzSaleOrderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_MzSaleOrderDal)objType;
        }
        /// <summary>
        /// 创建B_TempUpFile数据层接口。
        /// </summary>
        public static IB_TempUpFileDal CreateB_TempUpFile()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_TempUpFileDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_TempUpFileDal)objType;
        }
        /// <summary>
		/// 创建B_SaleMaterielOrder数据层接口。
		/// </summary>
		public static IB_SaleMaterielOrderDal CreateB_SaleMaterielOrder()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_SaleMaterielOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_SaleMaterielOrderDal)objType;
		}
        /// <summary>
		/// 创建B_AfterApplyOrder数据层接口。
		/// </summary>
		public static IB_AfterApplyOrderDal CreateB_AfterApplyOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterApplyOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterApplyOrderDal)objType;
		}
        /// <summary>
		/// 创建B_AfterFreeBackOrder数据层接口。
		/// </summary>
		public static  IB_AfterFreeBackOrderDal CreateB_AfterFreeBackOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterFreeBackOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterFreeBackOrderDal)objType;
		}
        /// <summary>
		/// 创建B_ServiceImg数据层接口。
		/// </summary>
		public static IB_ServiceImgDal CreateB_ServiceImg()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_ServiceImgDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_ServiceImgDal)objType;
		}
        /// <summary>
		/// 创建B_AfterReModifyOrder数据层接口。
		/// </summary>
		public static  IB_AfterReModifyOrderDal CreateB_AfterReModifyOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterReModifyOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterReModifyOrderDal)objType;
		}
        /// <summary>
		/// 创建B_AfterGroupProduction数据层接口。
		/// </summary>
		public static  IB_AfterGroupProductionDal CreateB_AfterGroupProduction()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterGroupProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterGroupProductionDal)objType;
		}
        /// <summary>
		/// 创建B_AfterProductionImg数据层接口。
		/// </summary>
		public static IB_AfterProductionImgDal CreateB_AfterProductionImg()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterProductionImgDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterProductionImgDal)objType;
		}
        /// 创建B_AfterPartInHouseOrder数据层接口。
		/// </summary>
		public static  IB_AfterPartInHouseOrderDal CreateB_AfterPartInHouseOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_AfterPartInHouseOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_AfterPartInHouseOrderDal)objType;
		}
        /// <summary>
        /// 创建B_Orders数据层接口。
        /// </summary>
        public static IB_OrdersDal CreateB_Orders()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_OrdersDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_OrdersDal)objType;
        }
        /// <summary>
		/// 创建B_MeasureProduction数据层接口。
		/// </summary>
		public static IB_MeasureProductionDal CreateB_MeasureProduction()
		{

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_MeasureProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_MeasureProductionDal)objType;
		}
        /// <summary>
		/// 创建B_WjOrder数据层接口。
		/// </summary>
		public static  IB_WjOrderDal CreateB_WjOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_WjOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( IB_WjOrderDal)objType;
		}
        /// <summary>
		/// 创建B_GlassOrder数据层接口。
		/// </summary>
		public static  IB_GlassOrderDal CreateB_GlassOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_GlassOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_GlassOrderDal)objType;
		}
        /// <summary>
        /// 创建B_GroupProductionCompnent数据层接口。
        /// </summary>
        public static IB_GroupProductionCompnentDal CreateB_GroupProductionCompnent()
        {

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_GroupProductionCompnentDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IB_GroupProductionCompnentDal)objType;
        }
        	/// <summary>
		/// 创建B_ProductionProcess数据层接口。
		/// </summary>
		public static IB_ProductionProcessDal CreateB_ProductionProcess()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_ProductionProcessDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_ProductionProcessDal)objType;
		}
        	/// <summary>
		/// 创建B_WorkSchedule数据层接口。
		/// </summary>
		public static IB_WorkScheduleDal CreateB_WorkSchedule()
		{

            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.B_WorkScheduleDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_WorkScheduleDal)objType;
		}
        /// <summary>
		/// 创建B_OrderFavorable数据层接口。
		/// </summary>
		public static  IB_OrderFavorableDal CreateB_OrderFavorable()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_OrderFavorableDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_OrderFavorableDal)objType;
		}
        /// <summary>
		/// 创建B_BatchProduceOrder数据层接口。
		/// </summary>
		public static IB_BatchProduceOrderDal CreateB_BatchProduceOrder()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_BatchProduceOrderDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_BatchProduceOrderDal)objType;
		}
        	/// <summary>
		/// 创建B_DismantleOrderTask数据层接口。
		/// </summary>
		public static  IB_DismantleOrderTaskDal CreateB_DismantleOrderTask()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_DismantleOrderTaskDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_DismantleOrderTaskDal)objType;
		}
        /// <summary>
		/// 创建B_CustomeGroupProduction数据层接口。
		/// </summary>
		public static IB_CustomeGroupProductionDal CreateB_CustomeGroupProduction()
		{

			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_CustomeGroupProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_CustomeGroupProductionDal)objType;
		}
        /// <summary>
		/// 创建B_DesignPlan数据层接口。
		/// </summary>
		public static  IB_DesignPlanDal CreateB_DesignPlan()
		{
			string ClassNamespace = AssemblyPath +".BusiOrderInfo.B_DesignPlanDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IB_DesignPlanDal)objType;
		}
    }
}
