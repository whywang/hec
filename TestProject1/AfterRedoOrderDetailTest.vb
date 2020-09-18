Imports Microsoft.VisualStudio.TestTools.UnitTesting.Web

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder



'''<summary>
'''这是 AfterRedoOrderDetailTest 的测试类，旨在
'''包含所有 AfterRedoOrderDetailTest 单元测试
'''</summary>
<TestClass()> _
Public Class AfterRedoOrderDetailTest


    Private testContextInstance As TestContext

    '''<summary>
    '''获取或设置测试上下文，上下文提供
    '''有关当前测试运行及其功能的信息。
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "附加测试特性"
    '
    '编写测试时，还可使用以下特性:
    '
    '使用 ClassInitialize 在运行类中的第一个测试前先运行代码
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    '使用 ClassCleanup 在运行完类中的所有测试后再运行代码
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    '使用 TestInitialize 在运行每个测试前先运行代码
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    '使用 TestCleanup 在运行完每个测试后运行代码
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    'TODO: 确保 UrlToTest 特性指定一个指向 ASP.NET 页的 URL(例如，
    ' http://.../Default.aspx)。这对于在 Web 服务器上执行单元测试是必需的，
    '无论要测试页、Web 服务还是 WCF 服务都是如此。
    '''<summary>
    '''SaveOrder 的测试
    '''</summary>
    <TestMethod(), _
     HostType("ASP.NET"), _
     AspNetDevelopmentServerHost("D:\企业系统\霍尔茨售后\LionVERP", "/"), _
     UrlToTest("http://localhost:14875/")> _
    Public Sub SaveOrderTest()
        Dim acity As String = String.Empty ' TODO: 初始化为适当的值
        Dim address As String = String.Empty ' TODO: 初始化为适当的值
        Dim aprovince As String = String.Empty ' TODO: 初始化为适当的值
        Dim areason As String = String.Empty ' TODO: 初始化为适当的值
        Dim ascode As String = String.Empty ' TODO: 初始化为适当的值
        Dim asid As String = String.Empty ' TODO: 初始化为适当的值
        Dim bcode As String = String.Empty ' TODO: 初始化为适当的值
        Dim city As String = String.Empty ' TODO: 初始化为适当的值
        Dim citycode As String = String.Empty ' TODO: 初始化为适当的值
        Dim customer As String = String.Empty ' TODO: 初始化为适当的值
        Dim dcode As String = String.Empty ' TODO: 初始化为适当的值
        Dim dname As String = String.Empty ' TODO: 初始化为适当的值
        Dim emcode As String = String.Empty ' TODO: 初始化为适当的值
        Dim isfc As String = String.Empty ' TODO: 初始化为适当的值
        Dim maker As String = String.Empty ' TODO: 初始化为适当的值
        Dim oscode As String = String.Empty ' TODO: 初始化为适当的值
        Dim osid As String = String.Empty ' TODO: 初始化为适当的值
        Dim otype As String = String.Empty ' TODO: 初始化为适当的值
        Dim ptype As String = String.Empty ' TODO: 初始化为适当的值
        Dim remark As String = String.Empty ' TODO: 初始化为适当的值
        Dim sid As String = String.Empty ' TODO: 初始化为适当的值
        Dim stype As String = String.Empty ' TODO: 初始化为适当的值
        Dim telephone As String = String.Empty ' TODO: 初始化为适当的值
        Dim expected As String = String.Empty ' TODO: 初始化为适当的值
        Dim actual As String
        actual = AfterRedoOrderDetail.SaveOrder(acity, address, aprovince, areason, ascode, asid, bcode, city, citycode, customer, dcode, dname, emcode, isfc, maker, oscode, osid, otype, ptype, remark, sid, stype, telephone)
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("验证此测试方法的正确性。")
    End Sub
End Class
