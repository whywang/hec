
function GetUser() {
    var url = "UIServer/BaseSet/UserManager/UserList.aspx/LoadUser";
    var b = AjaxEb(url);
    if (b != "") {
        bu = eval('(' + b + ')');
        $("#udep").html(bu.dname)
        $("#uname").html(bu.ename)
    }
}
//window.onbeforeunload = onbeforeunload_handler;
//function onbeforeunload_handler() {
//    var warning = "确认退出?";
//    return warning;
//}
var int = self.setInterval("clock()", 50)
function clock() {
    var t = new Date()
    var tt = t.Format("yyyy年MM月dd hh:mm:ss")
    $("#Rq").html(tt)
}
function Reflash() {
    window.parent.frames['Main'].location = window.parent.frames['Main'].location
}
function ControlTree(id) {
    if (window.parent.document.getElementById("MT").cols == "200,*") {
        window.parent.document.getElementById("MT").cols = "1,*"
        $("#" + id).attr("src", "Image/System/treeshow.png")
    }
    else {
        window.parent.document.getElementById("MT").cols = "200,*"
        $("#" + id).attr("src", "Image/System/treehide.png")
    }
}

 