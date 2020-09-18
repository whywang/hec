using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.ProductionInfo;
using LionvIDal.BusiOrderInfo;

namespace LionvFactoryDal
{
    public sealed class DataProductionAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public DataProductionAccess()
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
        /// 创建Sys_SizeTransformDal数据层接口。
        /// </summary>
        public static  ISys_SizeTransformDal CreateSys_SizeTransform()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SizeTransformDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SizeTransformDal)objType;
        }
        /// <summary>
        /// 创建Sys_Remark数据层接口。
        /// </summary>
        public static ISys_RemarkDal CreateSys_Remark()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_RemarkDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RemarkDal)objType;
        }
        /// <summary>
        /// 创建Sys_RemarkCondition数据层接口。
        /// </summary>
        public static  ISys_RemarkConditionDal CreateSys_RemarkCondition()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_RemarkConditionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_RemarkConditionDal)objType;
        }
        /// <summary>
        /// 创建Sys_ComputeFunction数据层接口。
        /// </summary>
        public static  ISys_ComputeFunctionDal CreateSys_ComputeFunction()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ComputeFunctionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ComputeFunctionDal)objType;
        }
        /// <summary>
        /// 创建Sys_OverComputeFunction数据层接口。
        /// </summary>
        public static ISys_OverComputeFunctionDal CreateSys_OverComputeFunction()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_OverComputeFunctionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_OverComputeFunctionDal)objType;
        }
        /// <summary>
        /// 创建Sys_Assort数据层接口。
        /// </summary>
        public static ISys_AssortDal CreateSys_Assort()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_AssortDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_AssortDal)objType;
        }
        /// <summary>
        /// 创建Sys_PriceType数据层接口。
        /// </summary>
        public static ISys_PriceTypeDal CreateSys_PriceType()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_PriceTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_PriceTypeDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProduceImg数据层接口。
        /// </summary>
        public static  ISys_ProduceImgDal CreateSys_ProduceImg()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProduceImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProduceImgDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProcessFlow数据层接口。
        /// </summary>
        public static  ISys_ProcessFlowDal CreateSys_ProcessFlow()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProcessFlowDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProcessFlowDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProcessPoint数据层接口。
        /// </summary>
        public static  ISys_ProcessPointDal CreateSys_ProcessPoint()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProcessPointDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProcessPointDal)objType;
        }
        /// <summary>
        /// 创建Sys_ComponentCate数据层接口。
        /// </summary>
        public static ISys_ComponentCateDal CreateSys_ComponentCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ComponentCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ComponentCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_Component数据层接口。
        /// </summary>
        public static  ISys_ComponentDal CreateSys_Component()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ComponentDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ComponentDal)objType;
        }
        /// <summary>
        /// 创建Sys_PartType数据层接口。
        /// </summary>
        public static ISys_PartTypeDal CreateSys_PartType()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_PartTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_PartTypeDal)objType;
        }
        public static ISys_OptimizeDal CreateSys_Optimize()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_OptimizeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_OptimizeDal)objType;
        }
        public static  ISys_CgNomalSizeDal CreateSys_CgNomalSize()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_CgNomalSizeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_CgNomalSizeDal)objType;
        }
        public static  ISys_CgOverCondtionDal CreateSys_CgOverCondtion()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_CgOverCondtionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_CgOverCondtionDal)objType;
        }
        public static  ISys_CgOverCondtionCategoryDal CreateSys_CgOverCondtionCategory()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_CgOverCondtionCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_CgOverCondtionCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_Package数据层接口。
        /// </summary>
        public static ISys_PackageDal CreateSys_Package()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_PackageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_PackageDal)objType;
        }
        public static ISys_WjBomDal CreateSys_WjBom()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_WjBomDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_WjBomDal)objType;
        }
        /// <summary>
        /// 创建Sys_WorkLine数据层接口。
        /// </summary>
        public static ISys_WorkLineDal CreateSys_WorkLine()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_WorkLineDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_WorkLineDal)objType;
        }
        /// <summary>
        /// 创建Sys_WorkLineCate数据层接口。
        /// </summary>
        public static  ISys_WorkLineCateDal CreateSys_WorkLineCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_WorkLineCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_WorkLineCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_FixProduction数据层接口。
        /// </summary>
        public static ISys_FixProductionDal CreateSys_FixProduction()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_FixProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_FixProductionDal)objType;
        }
        /// <summary>
        /// 创建Sys_ColorPane数据层接口。
        /// </summary>
        public static  ISys_ColorPaneDal CreateSys_ColorPane()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ColorPaneDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ColorPaneDal)objType;
        }
        /// <summary>
        /// 创建Sys_Lx数据层接口。
        /// </summary>
        public static ISys_LxDal CreateSys_Lx()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_LxDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_LxDal)objType;
        }
        /// <summary>
        /// 创建Sys_SizeLimited数据层接口。
        /// </summary>
        public static  ISys_SizeLimitedDal CreateSys_SizeLimited()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SizeLimitedDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SizeLimitedDal)objType;
        }
        /// <summary>
        /// 创建Sys_SizeLimitedCategory数据层接口。
        /// </summary>
        public static  ISys_SizeLimitedCategoryDal CreateSys_SizeLimitedCategory()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SizeLimitedCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SizeLimitedCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_MsCz数据层接口。
        /// </summary>
        public static  ISys_MsCzDal CreateSys_MsCz()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_MsCzDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_MsCzDal)objType;
        }
        /// <summary>
        /// 创建Sys_LocksType数据层接口。
        /// </summary>
        public static  ISys_LocksTypeDal CreateSys_LocksType()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_LocksTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_LocksTypeDal)objType;
        }
        /// <summary>
        /// 创建Sys_SetMeal数据层接口。
        /// </summary>
        public static ISys_SetMealDal CreateSys_SetMeal()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SetMealDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SetMealDal)objType;
        }
        /// <summary>
        /// 创建Sys_SetMealProduction数据层接口。
        /// </summary>
        public static ISys_SetMealProductionDal CreateSys_SetMealProduction()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SetMealProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SetMealProductionDal)objType;
        }
        /// <summary>
        /// 创建Sys_SpecialProduction数据层接口。
        /// </summary>
        public static ISys_SpecialProductionDal CreateSys_SpecialProduction()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SpecialProductionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_SpecialProductionDal)objType;
        }
        /// <summary>
        /// 创建Sys_SpecialProductionCate数据层接口。
        /// </summary>
        public static  ISys_SpecialProductionCateDal CreateSys_SpecialProductionCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SpecialProductionCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SpecialProductionCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_RefSizeTransform数据层接口。
        /// </summary>
        public static  ISys_RefSizeTransformDal CreateSys_RefSizeTransform()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_RefSizeTransformDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RefSizeTransformDal)objType;
        }
        /// <summary>
        /// 创建Sys_PriceProportion数据层接口。
        /// </summary>
        public static  ISys_PriceProportionDal CreateSys_PriceProportion()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_PriceProportionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_PriceProportionDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionTempCate数据层接口。
        /// </summary>
        public static  ISys_ProductionTempCateDal CreateSys_ProductionTempCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionTempCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProductionTempCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionTemp数据层接口。
        /// </summary>
        public static  ISys_ProductionTempDal CreateSys_ProductionTemp()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionTempDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProductionTempDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionPriceTemp数据层接口。
        /// </summary>
        public static  ISys_ProductionPriceTempDal CreateSys_ProductionPriceTemp()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionPriceTempDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProductionPriceTempDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionPriceTempCate数据层接口。
        /// </summary>
        public static ISys_ProductionPriceTempCateDal CreateSys_ProductionPriceTempCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionPriceTempCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionPriceTempCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionXqTemp数据层接口。
        /// </summary>
        public static ISys_ProductionXqTempDal CreateSys_ProductionXqTemp()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionXqTempDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionXqTempDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionOrderLogo数据层接口。
        /// </summary>
        public static  ISys_ProductionOrderLogoDal CreateSys_ProductionOrderLogo()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionOrderLogoDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProductionOrderLogoDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionAttrEx数据层接口。
        /// </summary>
        public static  ISys_ProductionAttrExDal CreateSys_ProductionAttrEx()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionAttrExDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionAttrExDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionAttrExCate数据层接口。
        /// </summary>
        public static ISys_ProductionAttrExCateDal CreateSys_ProductionAttrExCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionAttrExCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionAttrExCateDal)objType;
        }
        public static ISys_XsOverCondtionCategoryDal CreateSys_XsOverCondtionCategory()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_XsOverCondtionCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_XsOverCondtionCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_XsOverCondition数据层接口。
        /// </summary>
        public static ISys_XsOverConditionDal CreateSys_XsOverCondition()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_XsOverConditionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_XsOverConditionDal)objType;
        }/// <summary>
        /// 创建Sys_HyType数据层接口。
        /// </summary>
        public static ISys_HyTypeDal CreateSys_HyType()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_HyTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_HyTypeDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcessCate数据层接口。
        /// </summary>
        public static ISys_ProductionProcessCateDal CreateSys_ProductionProcessCate()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcess数据层接口。
        /// </summary>
        public static ISys_ProductionProcessDal CreateSys_ProductionProcess()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessDal)objType;
        }
        /// <summary>
		/// 创建Sys_SizeTransformR数据层接口。
		/// </summary>
		public static ISys_SizeTransformRDal CreateSys_SizeTransformR()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeTransformRDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeTransformRDal)objType;
		}
        /// <summary>
		/// 创建Sys_Cave数据层接口。
		/// </summary>
		public static ISys_CaveDal CreateSys_Cave()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_CaveDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_CaveDal)objType;
		}
        /// <summary>
		/// 创建Sys_SectionPrice数据层接口。
		/// </summary>
		public static  ISys_SectionPriceDal CreateSys_SectionPrice()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SectionPriceDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SectionPriceDal)objType;
		}
        /// <summary>
		/// 创建Sys_SectionPriceCate数据层接口。
		/// </summary>
		public static ISys_SectionPriceCateDal CreateSys_SectionPriceCate()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SectionPriceCateDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SectionPriceCateDal)objType;
		}
        /// <summary>
        /// 创建Sys_ComputeUnit数据层接口。
        /// </summary>
        public static ISys_ComputeUnitDal CreateSys_ComputeUnit()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ComputeUnitDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ComputeUnitDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcessLine数据层接口。
        /// </summary>
        public static ISys_ProductionProcessLineDal CreateSys_ProductionProcessLine()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessLineDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessLineDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcessLinePoint数据层接口。
        /// </summary>
        public static ISys_ProductionProcessLinePointDal CreateSys_ProductionProcessLinePoint()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessLinePointDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessLinePointDal)objType;
        }
        /// <summary>
        /// 创建Sys_ConsumeMaterialCate数据层接口。
        /// </summary>
        public static ISys_ConsumeMaterialCateDal CreateSys_ConsumeMaterialCate()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ConsumeMaterialCateDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ConsumeMaterialCateDal)objType;
        }
        /// <summary>
        /// 创建Sys_ConsumeMaterial数据层接口。
        /// </summary>
        public static ISys_ConsumeMaterialDal CreateSys_ConsumeMaterial()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ConsumeMaterialDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ConsumeMaterialDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcessCost数据层接口。
        /// </summary>
        public static ISys_ProductionProcessCostDal CreateSys_ProductionProcessCost()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessCostDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessCostDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionProcessPrice数据层接口。
        /// </summary>
        public static ISys_ProductionProcessPriceDal CreateSys_ProductionProcessPrice()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessPriceDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessPriceDal)objType;
        }
        /// 创建Sys_StatistcPartType数据层接口。
        /// </summary>
        public static ISys_StatistcPartTypeDal CreateSys_StatistcPartType()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_StatistcPartTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_StatistcPartTypeDal)objType;
        }
        /// <summary>
		/// 创建Sys_Brands数据层接口。
		/// </summary>
		public static  ISys_BrandsDal CreateSys_Brands()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_BrandsDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_BrandsDal)objType;
		}
        /// <summary>
		/// 创建Sys_GlassCraft数据层接口。
		/// </summary>
		public static ISys_GlassCraftDal CreateSys_GlassCraft()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_GlassCraftDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_GlassCraftDal)objType;
		}
        /// <summary>
		/// 创建Sys_GlassDirection数据层接口。
		/// </summary>
		public static  ISys_GlassDirectionDal CreateSys_GlassDirection()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_GlassDirectionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_GlassDirectionDal)objType;
		}
        /// <summary>
		/// 创建Sys_MeasureProduction数据层接口。
		/// </summary>
		public static ISys_MeasureProductionDal CreateSys_MeasureProduction()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_MeasureProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_MeasureProductionDal)objType;
		}
        /// <summary>
		/// 创建Sys_SizeFormatCate数据层接口。
		/// </summary>
		public static ISys_SizeFormatCateDal CreateSys_SizeFormatCate()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeFormatCateDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeFormatCateDal)objType;
		}
        /// <summary>
		/// 创建Sys_SizeFomatCondition数据层接口。
		/// </summary>
		public static ISys_SizeFomatConditionDal CreateSys_SizeFomatCondition()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeFomatConditionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeFomatConditionDal)objType;
		}
        /// <summary>
		/// 创建Sys_SizeFormatCollection数据层接口。
		/// </summary>
		public static ISys_SizeFormatCollectionDal CreateSys_SizeFormatCollection()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeFormatCollectionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeFormatCollectionDal)objType;
		}
        /// <summary>
		/// 创建Sys_SizeFormatPart数据层接口。
		/// </summary>
		public static ISys_SizeFormatPartDal CreateSys_SizeFormatPart()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeFormatPartDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeFormatPartDal)objType;
		}
        /// <summary>
		/// 创建Sys_SizeFormatPartAttr数据层接口。
		/// </summary>
		public static  ISys_SizeFormatPartAttrDal CreateSys_SizeFormatPartAttr()
		{

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_SizeFormatPartAttrDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeFormatPartAttrDal)objType;
		}
        /// <summary>
        /// 创建Sys_SizeFormatPartAttr数据层接口。
        /// </summary>
        public static IMsAttrDal CreateMsAttr()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.MsAttrDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IMsAttrDal)objType;
        }
        	/// <summary>
		/// 创建Sys_DkSizeTransform数据层接口。
		/// </summary>
		public static ISys_DkSizeTransformDal CreateSys_DkSizeTransform()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_DkSizeTransformDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_DkSizeTransformDal)objType;
		}
        	/// <summary>
		/// 创建Sys_ProduceAllCapacity数据层接口。
		/// </summary>
		public static ISys_ProduceAllCapacityDal CreateSys_ProduceAllCapacity()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_ProduceAllCapacityDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ProduceAllCapacityDal)objType;
		}
        /// <summary>
		/// 创建Sys_ProduceCate数据层接口。
		/// </summary>
		public static ISys_ProduceCateDal CreateSys_ProduceCate()
		{

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProduceCateDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ProduceCateDal)objType;
		}
        	/// <summary>
		/// 创建Sys_ProductionCapacity数据层接口。
		/// </summary>
		public static  ISys_ProductionCapacityDal CreateSys_ProductionCapacity()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_ProductionCapacityDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ProductionCapacityDal)objType;
		}
        /// <summary>
        /// 创建Sys_ProductionProcessCostPart数据层接口。
        /// </summary>
        public static ISys_ProductionProcessCostPartDal CreateSys_ProductionProcessCostPart()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_ProductionProcessCostPartDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProductionProcessCostPartDal)objType;
        }
        		/// <summary>
		/// 创建Sys_XxType数据层接口。
		/// </summary>
		public static ISys_XxTypeDal CreateSys_XxType()
		{

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_XxTypeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_XxTypeDal)objType;
		}
       /// <summary>
		/// 创建Sys_HingeInterval数据层接口。
		/// </summary>
		public static ISys_HingeIntervalDal CreateSys_HingeInterval()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_HingeIntervalDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_HingeIntervalDal)objType;
		}
        /// <summary>
		/// 创建Sys_TPrice数据层接口。
		/// </summary>
		public static ISys_TPriceDal CreateSys_TPrice()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_TPriceDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_TPriceDal)objType;
		}
        	/// <summary>
		/// 创建Sys_TPriceCate数据层接口。
		/// </summary>
		public static  ISys_TPriceCateDal CreateSys_TPriceCate()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_TPriceCateDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_TPriceCateDal)objType;
		}
        /// <summary>
		/// 创建Sys_ProductionPeriod数据层接口。
		/// </summary>
		public static  ISys_ProductionPeriodDal CreateSys_ProductionPeriod()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_ProductionPeriodDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ProductionPeriodDal)objType;
		}
        /// <summary>
        /// 创建Sys_ProductionPeriod数据层接口。
        /// </summary>
        public static ISys_GlassProductionPeriodDal CreateSys_GlassProductionPeriod()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_GlassProductionPeriodDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_GlassProductionPeriodDal)objType;
        }
        /// <summary>
		/// 创建Sys_SizeAttr数据层接口。
		/// </summary>
		public static ISys_SizeAttrDal CreateSys_SizeAttr()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_SizeAttrDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SizeAttrDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmElm数据层接口。
		/// </summary>
		public static  ISys_JqmElmDal CreateSys_JqmElm()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmElmDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmElmDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmMsyl数据层接口。
		/// </summary>
		public static  ISys_JqmMsylDal CreateSys_JqmMsyl()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmMsylDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmMsylDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmFbt数据层接口。
		/// </summary>
		public static ISys_JqmFbtDal CreateSys_JqmFbt()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmFbtDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( ISys_JqmFbtDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmHz数据层接口。
		/// </summary>
		public static  ISys_JqmHzDal CreateSys_JqmHz()
		{

			string ClassNamespace = AssemblyPath +".ProductionInf.Sys_JqmHzDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmHzDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmHy数据层接口。
		/// </summary>
		public static ISys_JqmHyDal CreateSys_JqmHy()
		{

			string ClassNamespace = AssemblyPath +".ProductionInf.Sys_JqmHyDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmHyDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmKx数据层接口。
		/// </summary>
		public static  ISys_JqmKxDal CreateSys_JqmKx()
		{

			string ClassNamespace = AssemblyPath +".ProductionInf.Sys_JqmKxDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmKxDal)objType;
		}
        	/// <summary>
		/// 创建Sys_JqmSj数据层接口。
		/// </summary>
		public static  ISys_JqmSjDal CreateSys_JqmSj()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmSjDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmSjDal)objType;
		}
        /// <summary>
		/// 创建Sys_JqmSlm数据层接口。
		/// </summary>
		public static  ISys_JqmSlmDal CreateSys_JqmSlm()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmSlmDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmSlmDal)objType;
		}
        /// <summary>
		/// 创建Sys_Jqmxx数据层接口。
		/// </summary>
		public static  ISys_JqmxxDal CreateSys_Jqmxx()
		{

			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_JqmxxDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_JqmxxDal)objType;
		}
        /// <summary>
		/// 创建Sys_MtZsbEdit数据层接口。
		/// </summary>
		public static  ISys_MtZsbEditDal CreateSys_MtZsbEdit()
		{
			string ClassNamespace = AssemblyPath +".ProductionInfo.Sys_MtZsbEditDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_MtZsbEditDal)objType;
		}
    }
}
