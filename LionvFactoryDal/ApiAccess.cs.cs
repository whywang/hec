using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.Api;

namespace LionvFactoryDal
{
   public class ApiAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public ApiAccess()
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
		/// 创建API_yy数据层接口。
		/// </summary>
		public static  IAPI_yyDal CreateAPI_yy()
		{

            string ClassNamespace = AssemblyPath + ".API.API_yyDal";
			object objType=CreateObject(AssemblyPath,ClassNamespace);
			return (IAPI_yyDal)objType;
		}

    }
}
