using LionvCommonBll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject3
{
    
    
    /// <summary>
    ///这是 BusiCreateNewOrderFlowTest 的测试类，旨在
    ///包含所有 BusiCreateNewOrderFlowTest 单元测试
    ///</summary>
    [TestClass()]
    public class BusiCreateNewOrderFlowTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///CreateNewOrders 的测试
        ///</summary>
        [TestMethod()]
        public void CreateNewOrdersTest()
        {
            BusiCreateNewOrderFlow target = new BusiCreateNewOrderFlow(); // TODO: 初始化为适当的值
            string sid = "980cb068-e8e5-437b-9c8a-ed3390380293-7433"; // TODO: 初始化为适当的值
            string emcode = "0001"; // TODO: 初始化为适当的值
            target.CreateNewOrders(sid, emcode);
             
        }
    }
}
