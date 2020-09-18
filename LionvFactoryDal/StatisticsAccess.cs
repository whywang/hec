using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.StatisticsInfo;

namespace LionvFactoryDal
{
    public sealed class StatisticsAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        static Cache DataCache = new Cache();
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
        public static IT_StatisticsDal CreateT_Statistics()
        {
            string ClassNamespace = AssemblyPath + ".StatisticsInfo.T_StatisticsDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IT_StatisticsDal)objType;
        }
 
    }
}
