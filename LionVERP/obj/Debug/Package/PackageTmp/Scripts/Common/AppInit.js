AppInit = {
    
    DataBaseConnection: function () {
        var url = '../../../UIServer/SystemInfo/SystemState.aspx/CheckDataBaseState';
        var b = AjaxEb(url);
        if (b == "F") {
            alert("数据库连接失败,请检测服务器网络及系统设置！")
        }
    },
    pdomain: function () {
        var url = '../../../Domain/PcQuery';
        var b = AjaxEb(url);
        if (b != "F") {
            return "http://localhost:14875";
        }
    },
    ydomain: function () {
        var url = '../../../Domain/YdQuery';
        var b = AjaxEb(url);
        if (b == "F") {
             return b;
        }
     }
}