function Login() {
    var uname = $("#uname").val();
    var upwd = $("#pwd").val();
    if (!uname || uname == "") {
        $("#tip").text("账号不能为空！")
        return;
   }
   if (!upwd || upwd == "") {
       $("#tip").text("密码不能为空！")
       return;
   }
   var url = "../../UIServer/Login.aspx/LoginSystem";
   var o = { "iuname": uname, 'iupwd': upwd }
   var b = AjaxExb(url, o);
   if (b == "S") {
     SetCookie("cname", uname)
     SetCookie("cpwd", upwd)
     window.location.href="main.htm"
   }
   else {
       $("#tip").text("登录失败！")
   }
}
function AutoLogin() {
    var uname = GetCookie("cname");
    var upwd = GetCookie("cpwd");
    var url = "../../UIServer/Login.aspx/LoginSystem";
    var o = { "iuname": uname, 'iupwd': upwd }
    var b = AjaxExb(url, o);
    if (b == "S") {
        SetCookie("cname", uname)
        SetCookie("cpwd", upwd)
        window.location.href = "main.htm"
    }
    else {
        $("#tip").text("登录失败！")
    }
}