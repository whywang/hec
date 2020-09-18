function GetUser() {
    var url = "../../UIServer/Login.aspx/LoadUser";
    var b = AjaxEb(url);

    if (b != "") {
        bu = eval('(' + b + ')');
        $("#bm").text(bu.dname)
        $("#mc").text(bu.ename)
        $("#zh").text(bu.elname)
        $("#dh").text(bu.etelephone)
        if (!bu.ename) {
            window.location.href = "Login.htm"
        }
    }
    else {
        window.location.href = "Login.htm"
    }
}
function UnLogin() {
    var url = "../../UIServer/Login.aspx/UnLoad";
    var b = AjaxEb(url);
    window.location.href = "Login.htm"
}