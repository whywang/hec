using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIMgDal.BusiOrderInfo;

namespace LionvFactoryDal
{
    public sealed class BusiMgOrderAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["MgDAL"];
        static Cache DataCache = new Cache();
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
        /// <summary>
        /// 创建CB_ButtonEvent数据层接口。
        /// </summary>
        public static IVProductionsDal CreateVProductions()
        {
            string ClassNamespace = AssemblyPath + ".BusiOrderInfo.VProductionsDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (IVProductionsDal)objType;
        }
    }
}
