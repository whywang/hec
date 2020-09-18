using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using LionvCommon;
using System.Configuration;
using LionvIDal.NewsInfo;

namespace LionvFactoryDal
{
    public sealed class NewsAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
        public NewsAccess()
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
        public static INB_NewsDal CreateNB_News()
        {
            string ClassNamespace = AssemblyPath + ".NewsInfo.NB_NewsDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( INB_NewsDal)objType;
        }
        /// <summary>
        /// 创建NB_NewsReader数据层接口。
        /// </summary>
        public static INB_NewsReaderDal CreateNB_NewsReader()
        {

            string ClassNamespace = AssemblyPath + ".NewsInfo.NB_NewsReaderDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( INB_NewsReaderDal)objType;
        }
        /// <summary>
		/// 创建NB_DepNews数据层接口。
		/// </summary>
		public static INB_DepNewsDal CreateNB_DepNews()
        {

            string ClassNamespace = AssemblyPath + ".NewsInfo.NB_DepNewsDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (INB_DepNewsDal)objType;
        }
    }
}
