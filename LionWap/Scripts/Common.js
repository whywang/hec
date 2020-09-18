function GetRequest() {

    var url = "";
    if (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE6.0") {
        url = location.search;
    }
    else if (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE7.0") {
        url = location.search;
    }
    else if (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE8.0") {
        url = location.search;
    }
    else if (navigator.appName == "Microsoft Internet Explorer" && navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE9.0") {
        url = location.search;
    }
    else {
        url = decodeURI(location.search);
    }
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        var strs = str.split("&");

        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;

}
function AjaxExb(u, k) {
    var ko = JSON.stringify(k)
    var r;
    $.ajax({
        type: "POST",
        url: u,
        contentType: "application/json",
        data: ko,
        dataType: "json",
        async: false,
        success: function (data) {
            r = data.d
        },
        error: function (err) { alert("请尝试重新操作") }
    });
    return r;
}
function AjaxEb(u) {
    var r;
    $.ajax({
        type: "POST",
        url: u,
        contentType: "application/json",
        data: "",
        dataType: "json",
        async: false,
        success: function (data) { r = data.d },
        error: function (err) { alert("请尝试重新操作") }
    });
    return r;
}
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
function UpFile(o, fid, u, fn) {
    $.ajaxFileUpload(
                {
                    url: u,
                    secureuri: false,
                    fileElementId: fid,
                    dataType: 'json',
                    success: function (data, status) {
                        if (data.msg == "S") {
                            // o.setDisplay("none");
                            fn();
                            alert("操作成功");
                        }
                        if (data.msg == "B") {
                            alert("文件过大")
                        }
                        if (data.msg == "T") {
                            alert("文件格式错误")
                        }
                     
                    },
                    error: function (data, status, e) {
                        alert(e);
                    }

                }

)
                window.location.href = window.location.href;
            }
function ClearInput(id,msg) {
    var pv = $("#"+id).val();
    if (pv == msg) {
        $("#pctel").val('');
    }
}
function BackInput(id, msg) {
    var pv = $("#"+id).val();
    if (pv == "") {
        $("#"+id).val(msg);
    }
}
function GetCookie(name) {
    var r = "";
    var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
    if (arr != null) {
        var carr = arr[2].toString().split("=");
        r = decodeURI(carr[0])
    }
    return r;
}
function SetCookie(nv, v) {
    document.cookie = nv + "=" + v;
}