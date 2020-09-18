function Expend(v) {
    var code = v.substr(1, v.length);
    if ($('#C' + code).css("display") == "block") {
        $('#C' + code).css("display", "none")
        $("#P" + code).removeClass('active')
        $("#C" + code).empty();
    }
    else {
        $('#C' + code).css("display", "block")
        $("#P" + code).addClass('active');
        $("#C" + code).empty();
        GetAllMenu("C" + code, '1', code)
        initbar();
    }
}
function initbar() {
    var sh = document.documentElement.scrollHeight;
    $("#bar").css("height", sh);
    var mh = sh / 2 - 50;
    $("#bimg").css("margin-top", mh);
}
function GoUrl(id) {
    $(".actived").removeClass("actived")
    $("#" + id).addClass("actived")
}

function GetAllMenu(id, mt, pmc) {
    var url = "../../UIServer/SysMenus/MenuList.aspx/LoadMenu";
    var o = { "md": mt, "pmenucode": pmc }
    var b = AjaxExb(url, o)
    if (b == "O") {
        alert("登录超时，请重新登录")
        if (this.window.parent) {
            if (this.window.parent.parent) {
                this.window.parent.parent.location.href = "../../../Login.htm"
            }
            else {
                this.window.parent.location.href = "../../Login.htm"
            }
        }
    }
    else {
        if (b == "F") {
            alert("菜单加载失败")
        }
        else {
            $("#" + id).append(b)
        }
    }

}

