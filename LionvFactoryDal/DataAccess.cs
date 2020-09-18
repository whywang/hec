using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using LionvCommon;
using LionvIDal.SysInfo;
using LionvIDal.ProductionInfo;

namespace LionvFactoryDal
{
    public sealed class DataAccess 
	{
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
		public DataAccess()
		{ }

        #region CreateObject 

		//不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath,string classNamespace)
		{		
			try
			{
				object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);	
				return objType;
			}
			catch//(System.Exception ex)
			{
				//string str=ex.Message;// 记录错误日志
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
                    DataCache.Insert(classNamespace, objType);// 写入缓存
                }
                catch(System.Exception ex)
                {
                    string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion
		/// <summary>
		/// 创建Sys_Button数据层接口。
		/// </summary>
        public static LionvIDal.SysInfo.ISys_ButtonDal CreateSys_Button()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_ButtonDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (LionvIDal.SysInfo.ISys_ButtonDal)objType;
		}
        /// <summary>
        /// 创建Sys_BackEventDal数据层接口。
        /// </summary>
        public static LionvIDal.SysInfo.ISys_BackEventDal CreateSys_BackEventDal()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_BackEventDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (LionvIDal.SysInfo.ISys_BackEventDal)objType;
        }
		/// <summary>
		/// 创建Sys_Depment数据层接口。
		/// </summary>
        public static LionvIDal.SysInfo.ISys_DepmentDal CreateSys_Depment()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_DepmentDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (LionvIDal.SysInfo.ISys_DepmentDal)objType;
		}
		/// <summary>
		/// 创建Sys_DepmentDpt数据层接口。
		/// </summary>
        public static LionvIDal.SysInfo.ISys_DepmentDptDal CreateSys_DepmentDpt()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_DepmentDptDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (LionvIDal.SysInfo.ISys_DepmentDptDal)objType;
		}
		/// <summary>
		/// 创建Sys_Duty数据层接口。
		/// </summary>
        public static LionvIDal.SysInfo.ISys_DutyDal CreateSys_Duty()
		{

            string ClassNamespace = AssemblyPath + ".Sys_Duty";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (LionvIDal.SysInfo.ISys_DutyDal)objType;
		}
		/// <summary>
		/// 创建Sys_EmployeeDpt数据层接口。
		/// </summary>
        public static ISys_EmployeeDptDal CreateSys_EmployeeDpt()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_EmployeeDptDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_EmployeeDptDal)objType;
		}
		/// <summary>
		/// 创建Sys_EventMenu数据层接口。
		/// </summary>
		public static  ISys_EventMenuDal CreateSys_EventMenu()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_EventMenuDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return ( ISys_EventMenuDal)objType;
		}
		/// <summary>
		/// 创建Sys_Expire数据层接口。
		/// </summary>
		public static  ISys_ExpireDal CreateSys_Expire()
		{

            string ClassNamespace = AssemblyPath + ".Sys_ExpireDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_ExpireDal)objType;
		}
		/// <summary>
		/// 创建Sys_Group数据层接口。
		/// </summary>
		public static  ISys_GroupDal CreateSys_Group()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_GroupDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( ISys_GroupDal)objType;
		}
		/// <summary>
		/// 创建Sys_Menu数据层接口。
		/// </summary>
		public static  ISys_MenuDal CreateSys_Menu()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_MenuDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_MenuDal)objType;
		}
		/// <summary>
		/// 创建Sys_Role数据层接口。
		/// </summary>
		public static ISys_RoleDal CreateSys_Role()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_RoleDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_RoleDal)objType;
		}
		/// <summary>
		/// 创建Sys_SearchCondtion数据层接口。
		/// </summary>
		public static  ISys_SearchCondtionDal CreateSys_SearchCondtion()
		{

            string ClassNamespace = AssemblyPath + ".Sys_SearchCondtionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( ISys_SearchCondtionDal)objType;
		}
		/// <summary>
		/// 创建Sys_User数据层接口。
		/// </summary>
		public static  ISys_UserDal CreateSys_User()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_UserDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return ( ISys_UserDal)objType;
		}
        /// <summary>
        /// 创建Sys_Settlement数据层接口。
        /// </summary>
        public static ISys_SettlementDal CreateSys_Settlement()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SettlementDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SettlementDal)objType;
        }
		/// <summary>
		/// 创建Sys_WorkEvent数据层接口。
		/// </summary>
		public static ISys_WorkEventDal CreateSys_WorkEvent()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_WorkEventDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_WorkEventDal)objType;
		}
		/// <summary>
		/// 创建Sys_Employee数据层接口。
		/// </summary>
		public static  ISys_EmployeeDal CreateSys_Employee()
		{

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_EmployeeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
            return (ISys_EmployeeDal)objType;
		}
        /// <summary>
        /// 创建Sys_Unit数据层接口。
        /// </summary>
        public static ISys_UnitDal CreateSys_Unit()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_UnitDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_UnitDal)objType;
        }
        /// <summary>
        /// 创建Sys_Unit数据层接口。
        /// </summary>
        public static ISys_MaterialCategoryDal CreateSys_MaterialCategory()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_MaterialCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_MaterialCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_Material数据层接口。
        /// </summary>
        public static ISys_MaterialDal CreateSys_Material()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_MaterialDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_MaterialDal)objType;
        }
        /// <summary>
        /// 创建Sys_InventoryCategory数据层接口。
        /// </summary>
        public static ISys_InventoryCategoryDal CreateSys_InventoryCategory()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_InventoryCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_InventoryCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_InventoryDetail数据层接口。
        /// </summary>
        public static ISys_InventoryDetailDal CreateSys_InventoryDetail()
        {
            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_InventoryDetailDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_InventoryDetailDal)objType;
        }
        public static ISys_NomalSizeDal CreateSys_NomalSize()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_NomalSizeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_NomalSizeDal)objType;
        }
        public static  ISys_OverComputeCategoryDal CreateSys_OverComputeCategory()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_OverComputeCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_OverComputeCategoryDal)objType;
        }
        public static ISys_OverConditionDal CreateSys_OverCondition()
        {

            string ClassNamespace = AssemblyPath + ".ProductionInfo.Sys_OverConditionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_OverConditionDal)objType;
        }
        /// <summary>
        /// 创建Sys_ViewTable数据层接口。
        /// </summary>
        public static ISys_ViewTableDal CreateSys_ViewTable()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_ViewTableDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ViewTableDal)objType;
        }
        /// <summary>
        /// 创建Sys_OrderType数据层接口。
        /// </summary>
        public static  ISys_OrderTypeDal CreateSys_OrderType()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_OrderTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_OrderTypeDal)objType;
        }
        /// <summary>
        /// 创建Sys_AgentFee数据层接口。
        /// </summary>
        public static ISys_AgentFeeDal CreateSys_AgentFee()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_AgentFeeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_AgentFeeDal)objType;
        }
        /// <summary>
        /// 创建Sys_Tax数据层接口。
        /// </summary>
        public static ISys_TaxDal CreateSys_Tax()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_TaxDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_TaxDal)objType;
        }
        /// <summary>
        /// 创建Sys_OrderSource数据层接口。
        /// </summary>
        public static  ISys_OrderSourceDal CreateSys_OrderSource()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_OrderSourceDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_OrderSourceDal)objType;
        }
        /// <summary>
        /// 创建Sys_Templet数据层接口。
        /// </summary>
        public static ISys_TempletDal CreateSys_Templet()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_TempletDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_TempletDal)objType;
        }
        public static ISys_OrderCodeDal CreateSys_OrderCode()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_OrderCodeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_OrderCodeDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProduceCyc数据层接口。
        /// </summary>
        public static  ISys_ProduceCycDal CreateSys_ProduceCyc()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_ProduceCycDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_ProduceCycDal)objType;
        }
        /// <summary>
        /// 创建Sys_RepairDuty数据层接口。
        /// </summary>
        public static ISys_RepairDutyDal CreateSys_RepairDuty()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_RepairDutyDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RepairDutyDal)objType;
        }
        /// <summary>
        /// 创建Sys_RepairDutyCategory数据层接口。
        /// </summary>
        public static ISys_RepairDutyCategoryDal CreateSys_RepairDutyCategory()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_RepairDutyCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RepairDutyCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_RepairReason数据层接口。
        /// </summary>
        public static ISys_RepairReasonDal CreateSys_RepairReason()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_RepairReasonDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RepairReasonDal)objType;
        }
        /// <summary>
        /// 创建Sys_RepairReasonCategory数据层接口。
        /// </summary>
        public static ISys_RepairReasonCategoryDal CreateSys_RepairReasonCategory()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_RepairReasonCategoryDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_RepairReasonCategoryDal)objType;
        }
        /// <summary>
        /// 创建Sys_SapApi数据层接口。
        /// </summary>
        public static ISys_SapApiDal CreateSys_SapApi()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SapApiDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SapApiDal)objType;
        }
        public static ISys_SystemImgDal CreateSys_SystemImgDal()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SystemImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SystemImgDal)objType;
        }
        /// <summary>
        /// 创建Sys_Area数据层接口。
        /// </summary>
        public static  ISys_AreaDal CreateSys_Area()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_AreaDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_AreaDal)objType;
        }
        /// <summary>
        /// 创建Sys_AddressList数据层接口。
        /// </summary>
        public static ISys_AddressListDal CreateSys_AddressList()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_AddressListDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_AddressListDal)objType;
        }
        /// <summary>
        /// 创建Sys_CityGetAddress数据层接口。
        /// </summary>
        public static ISys_CityGetAddressDal CreateSys_CityGetAddress()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_CityGetAddressDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_CityGetAddressDal)objType;
        }
        /// <summary>
        /// 创建Sys_HelpMenu数据层接口。
        /// </summary>
        public static  ISys_HelpMenuDal CreateSys_HelpMenu()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_HelpMenuDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_HelpMenuDal)objType;
        }
        /// <summary>
        /// 创建Sys_HelpContext数据层接口。
        /// </summary>
        public static  ISys_HelpContextDal CreateSys_HelpContext()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_HelpContextDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_HelpContextDal)objType;
        }
        /// <summary>
        /// 创建Sys_Domain数据层接口。
        /// </summary>
        public static  ISys_DomainDal CreateSys_Domain()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_DomainDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_DomainDal)objType;
        }
        /// <summary>
        /// 创建Sys_SaleDiscount数据层接口。
        /// </summary>
        public static  ISys_SaleDiscountDal CreateSys_SaleDiscount()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SaleDiscountDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SaleDiscountDal)objType;
        }
        /// <summary>
        /// 创建Sys_SaleDiscountCondition数据层接口。
        /// </summary>
        public static ISys_SaleDiscountConditionDal CreateSys_SaleDiscountCondition()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SaleDiscountConditionDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SaleDiscountConditionDal)objType;
        }
        /// <summary>
        /// 创建Sys_TabMenu数据层接口。
        /// </summary>
        public static  ISys_TabMenuDal CreateSys_TabMenu()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_TabMenuDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_TabMenuDal)objType;
        }
        /// <summary>
        /// 创建Sys_TabMenuAbc数据层接口。
        /// </summary>
        public static ISys_TabMenuAbcDal CreateSys_TabMenuAbc()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_TabMenuAbcDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_TabMenuAbcDal)objType;
        }
        /// <summary>
        /// 创建Sys_Message数据层接口。
        /// </summary>
        public static  ISys_MessageDal CreateSys_Message()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_MessageDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_MessageDal)objType;
        }
        /// <summary>
        /// 创建Sys_MessageAttr数据层接口。
        /// </summary>
        public static ISys_MessageAttrDal CreateSys_MessageAttr()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_MessageAttrDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_MessageAttrDal)objType;
        }
        /// <summary>
        /// 创建Sys_MzOrderType数据层接口。
        /// </summary>
        public static ISys_MzOrderTypeDal CreateSys_MzOrderType()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_MzOrderTypeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_MzOrderTypeDal)objType;
        }
        /// <summary>
        /// 创建Sys_ProductionOrderTemp数据层接口。
        /// </summary>
        public static ISys_ProductionOrderTempDal CreateSys_ProductionOrderTemp()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_ProductionOrderTempDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_ProductionOrderTempDal)objType;
        }
        /// <summary>
        /// 创建Sys_BtnImg数据层接口。
        /// </summary>
        public static ISys_BtnImgDal CreateSys_BtnImg()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_BtnImgDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_BtnImgDal)objType;
        }
        /// <summary>
        /// 创建Sys_Functions数据层接口。
        /// </summary>
        public static ISys_FunctionsDal CreateSys_Functions()
        {
            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_FunctionsDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_FunctionsDal)objType;
        }
        /// <summary>
        /// 创建Sys_SysMenuCode数据层接口。
        /// </summary>
        public static ISys_SysMenuCodeDal CreateSys_SysMenuCode()
        {

            string ClassNamespace = AssemblyPath + ".SysInfo.Sys_SysMenuCodeDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_SysMenuCodeDal)objType;
        }
        /// <summary>
		/// 创建Sys_DataTable数据层接口。
		/// </summary>
		public static ISys_DataTableDal CreateSys_DataTable()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_DataTableDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_DataTableDal)objType;
		}
        /// <summary>
		/// 创建Sys_EventMenuAttr数据层接口。
		/// </summary>
		public static ISys_EventMenuAttrDal CreateSys_EventMenuAttr()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_EventMenuAttrDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_EventMenuAttrDal)objType;
		}
        /// <summary>
		/// 创建Sys_Designer数据层接口。
		/// </summary>
		public static  ISys_DesignerDal CreateSys_Designer()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_DesignerDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_DesignerDal)objType;
		}
        /// <summary>
		/// 创建Sys_DesignerProduction数据层接口。
		/// </summary>
		public static ISys_DesignerProductionDal CreateSys_DesignerProduction()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_DesignerProductionDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_DesignerProductionDal)objType;
		}
        /// <summary>
		/// 创建Sys_RepairProductionType数据层接口。
		/// </summary>
		public static  ISys_RepairProductionTypeDal CreateSys_RepairProductionType()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_RepairProductionTypeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_RepairProductionTypeDal)objType;
		}
        /// <summary>
		/// 创建Sys_jlProvince数据层接口。
		/// </summary>
		public static ISys_jlProvinceDal CreateSys_jlProvince()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_jlProvinceDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_jlProvinceDal)objType;
		}
        /// <summary>
		/// 创建Sys_SendType数据层接口。
		/// </summary>
		public static  ISys_SendTypeDal CreateSys_SendType()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_SendTypeDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SendTypeDal)objType;
		}
        /// <summary>
		/// 创建Sys_ContractTemp数据层接口。
		/// </summary>
		public static ISys_ContractTempDal CreateSys_ContractTemp()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_ContractTempDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ContractTempDal)objType;
		}
        /// <summary>
		/// 创建Sys_ContractRowTemp数据层接口。
		/// </summary>
		public static  ISys_ContractRowTempDal CreateSys_ContractRowTemp()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_ContractRowTempDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_ContractRowTempDal)objType;
		}
        /// <summary>
		/// 创建Sys_SubWorkFlow数据层接口。
		/// </summary>
		public static ISys_SubWorkFlowDal CreateSys_SubWorkFlow()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_SubWorkFlowDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_SubWorkFlowDal)objType;
		}
        /// <summary>
		/// 创建Sys_MeasureLimited数据层接口。
		/// </summary>
		public static ISys_MeasureLimitedDal CreateSys_MeasureLimited()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_MeasureLimitedDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_MeasureLimitedDal)objType;
		}
        /// <summary>
		/// 创建Sys_RptTemp数据层接口。
		/// </summary>
		public static ISys_RptTempDal CreateSys_RptTemp()
		{

			string ClassNamespace = AssemblyPath +".SysInfo.Sys_RptTempDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (ISys_RptTempDal)objType;
		}
    }
}
