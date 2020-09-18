using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using LionvCommon;
using System.Reflection;
using LionvIDal.WxChat;

namespace LionvFactoryDal
{
    public sealed class WxChatAccess
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
        /// 创建Sys_WxChatConfig数据层接口。
        /// </summary>
        public static ISys_WxChatConfigDal CreateSys_WxChatConfig()
        {

            string ClassNamespace = AssemblyPath + ".WxChat.Sys_WxChatConfigDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_WxChatConfigDal)objType;
        }
        /// <summary>
        /// 创建Sys_WxChatTemp数据层接口。
        /// </summary>
        public static  ISys_WxChatTempDal CreateSys_WxChatTemp()
        {

            string ClassNamespace = AssemblyPath + ".WxChat.Sys_WxChatTempDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ISys_WxChatTempDal)objType;
        }
        /// <summary>
        /// 创建Sys_EmplyeeFouseWx数据层接口。
        /// </summary>
        public static ISys_EmplyeeFouseWxDal CreateSys_EmplyeeFouseWx()
        {
            string ClassNamespace = AssemblyPath + ".WxChat.Sys_EmplyeeFouseWxDal";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return ( ISys_EmplyeeFouseWxDal)objType;
        }

    }
}
