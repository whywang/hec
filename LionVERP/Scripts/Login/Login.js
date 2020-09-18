$(document).ready(function () {
    Init();
    $("#btn").click(function () {
       // scan()
        $("#tip").html("")
        var ln = $("#lname").val().trim();
        var lp = $("#lpwd").val();
        if (ln == "" || lp == "") {
            $("#tip").html("正确输入账号和密码");
        }
        else {
            var url = "UIServer/SystemLogin/Login.aspx/LoginSystem";
            var o = { iuname: ln, iupwd: lp };
            var b = AjaxExb(url, o);
            if (b == "F") {
                $("#tip").html("账号或密码错误！");
            }
            if (b == "S") {
                window.location = "default.aspx";
            }
        }

    });
});

function Init() {
    var name = "Cuser"
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) {
        var carr = arr[2].toString().split("=");
        var v = carr[1]
        $("#lname").val(decodeURI(carr[1]));
    } else {
        $("#lname").val();
    }
}
document.onkeydown = function (event) {
    var e = event || window.event || arguments.callee.caller.arguments[0];
    if (e && e.keyCode == 13) {

            $("#tip").html("")
            var ln = $("#lname").val();
            var lp = $("#lpwd").val();
            if (ln == "" || lp == "") {
                $("#tip").html("正确输入账号和密码");
            }
            else {
                var url = "UIServer/SystemLogin/Login.aspx/LoginSystem";
                var o = { iuname: ln, iupwd: lp };
                var b = AjaxExb(url, o);
                if (b == "F") {
                    $("#tip").html("账号或密码错误！");
                }
                if (b == "S") {
                    window.location = "default.aspx";
                }
            }
    }
}