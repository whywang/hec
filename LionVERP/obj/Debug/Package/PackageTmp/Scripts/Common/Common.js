
themes = "aqua"
initstr = "<img src='../../../Image/System/nloading.gif' style='width:40px; height:40px; margin-left:30px'>";
upimgbox = "<div  style='background:url( 'Image/sysimg/addimg.png'); width:83px; height:83px'><a href='javascript:;' ></a><input type='file' name='file0' id='file0' multiple  style='opacity: 0;z-index: 10;position: absolute;top: 0;left: 0;height: 80px;width: 100%;'/></div>"
function CheckDataBaseConnection() {
    var url = '../../../UIServer/SystemInfo/SystemState.aspx/CheckDataBaseState';
    var b = AjaxEb(url);
    if (b == "F") {
        linb.warn("数据库连接失败,请检测服务器网络及系统设置！")
    }

}
isFlagLogin = 1;
// 处理字符串中空字符
String.prototype.Trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.LTrim = function () {
    return this.replace(/(^\s*)/g, "");
}
String.prototype.RTrim = function () {
    return this.replace(/(\s*$)/g, "");
}
function Ystr(obj) {
    var yarr = new Array()
    for (i = 2014; i < 2050; i++) {
        yarr.push({ "id": i, "caption": i });
    }
    obj.setItems(yarr)
}
function Mstr(obj) {
    var yarr = new Array()
    for (i = 1; i < 13; i++) {
        yarr.push({ "id": i, "caption": i });
    }
    obj.setItems(yarr)
}
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
    if (isFlagLogin == 1) {
        var ko = JSON.stringify(k);
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
            error: function (err) { linb.warn("请尝试重新操作") }
        });
        return r;
    }
}
function AjaxEb(u){
    if (isFlagLogin == 1) {
        var r;
        $.ajax({
            type: "POST",
            url: u,
            contentType: "application/json",
            data: "",
            dataType: "json",
            async: false,
            success: function (data) { r = data.d },
            error: function (err) { linb.warn("请尝试重新操作") }
        });
        return r;
    }
}
function AjaxDdExb(u, k) {
    var defer = $.Deferred();
    if (isFlagLogin == 1) {
        var ko = JSON.stringify(k)
        var r;
        $.ajax({
            type: "POST",
            url: u,
            contentType: "application/json",
            data: ko,
            dataType: "json",
            success: function (data) {
                defer.resolve(data.d)
            },
            error: function (err) { linb.warn("请尝试重新操作") }
        });
        return defer.promise();
    }
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
function IExeFun(f) {
    if (f != "") {
        if (!!(window.attachEvent && !window.opera)) {
            //ie
            execScript(f);
        } else {
            window.eval(f);
        }
    }
}
function IDel(v) {
    linb.confirms("删除提示", "确定要删除？", function () {Del(v)}, function () {return false;})
}
function IDelFun(f) {
    linb.confirms("删除提示", "确定要删除？", function () {
        if (f != "") {
            if (!!(window.attachEvent && !window.opera)) {
                //ie
                execScript(f);
            } else {
                window.eval(f);
            }
        }
    }, function () { return false; })
}
function IDoFun(tv,f) {
    linb.confirms("操作提示", tv, function () {
        if (f != "") {
            if (!!(window.attachEvent && !window.opera)) {
                //ie
                execScript(f);
            } else {
                window.eval(f);
            }
        }
    }, function () { return false; })
}
function GoBack() {
   window.history.back(-1)
}
function GoToUrl(id, url) {
    if (window.parent.name == "Main") {
        parent.window.location.href = url + "?Sid=" + id;
    }
    if (window.name == "Main") {
        window.location.href = url + "?Sid=" + id;
    }
    
}
function SetCookie(nv, v) {
    document.cookie = nv + "=" + v;
}
function execfun(f) {
    if (f != "") {
        if (!!(window.attachEvent && !window.opera)) {
            execScript(f);
        } else {
            window.eval(f);
        }
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
function UpFile(o, fid, u, fn) {
    $.ajaxFileUpload(
                {
                    url: u,
                    secureuri: false,
                    fileElementId: fid,
                    dataType: 'json',
                    success: function (data) {
                        if (data.msg == "S") {
                            if (o != null) {
                                o.setDisplay("none");
                            }
                            execfun(fn)
                            linb.msg("操作成功");
                        }
                        if (data.msg == "B") {
                            linb.warn("文件过大")
                        }

                        if (data.msg == "T") {
                            linb.warn("文件格式错误")
                        }
                    },
                    error: function (data, status, e) {
                        alert(e);
                    }
                }
)

}
function Reload() {
    window.location.href = window.location.href;
}
function OutSystem() {
    try {
        var url = "../../../UIServer/BaseSet/UserManager/UserList.aspx/UnLoad";
        var b = AjaxEb(url);
        this.parent.window.location.href = "../../../Login.htm";
    }
    catch (e) {
    }
}
function upDigit(n) {
    var fraction = ['角', '分'];
    var digit = ['零', '壹', '贰', '叁', '肆', '伍', '陆', '柒', '捌', '玖'];
    var unit = [['元', '万', '亿'], ['', '拾', '佰', '仟']];
    var head = n < 0 ? '欠' : '';
    n = Math.abs(n);

    var s = '';

    for (var i = 0; i < fraction.length; i++) {
        s += (digit[Math.floor(n * 10 * Math.pow(10, i)) % 10] + fraction[i]).replace(/零./, '');
    }
    s = s || '整';
    n = Math.floor(n);

    for (var i = 0; i < unit[0].length && n > 0; i++) {
        var p = '';
        for (var j = 0; j < unit[1].length && n > 0; j++) {
            p = digit[n % 10] + unit[1][j] + p;
            n = Math.floor(n / 10);
        }
        s = p.replace(/(零.)*零$/, '').replace(/^$/, '零') + unit[0][i] + s;
    }
    return head + s.replace(/(零.)*零元/, '元').replace(/(零.)+/g, '零').replace(/^整$/, '零元整');
}
function ArrToRow(arr) {
    var r = "";
    for (var i = 0; i < arr.length; i++) {
        var col = arr[i].cells;
        if (col) {
            r = r + "<tr id='tr" + arr[i].id + "'>";
            for (var k = 0; k < col.length; k++) {
                if (col[k].value != undefined) {
                    r = r + "<td>" + col[k].value + "</td>";
                }
            }
            r = r + "</tr>";
        }
    }
        return r;
}
function StringToRow(arr) {
    var r = "";
    r = r + "<tr id='head'>";
    for (var k = 0; k < arr.length; k++) {
        var acell = arr[k].toString().split(",")
        r = r + "<td>" + acell[0] + "</td>";
    }
    r = r + "</tr>";
    return r;
}
function StringToHead(str) {
    var r = "";
    var acell = str.toString().split(",")
    r = r + "<tr id='head'>";
    for (var k = 0; k < acell.length; k++) {
        r = r + "<td>" + acell[k] + "</td>";
    }
    r = r + "</tr>";
    return r;
}

//延迟执行
function sleep(d) {
    for (var t = Date.now(); Date.now() - t <= d; );
}
//linb 增加自定义方法
function AddCustomeFun(v) {
    
    if (linb.cumfun) {
        linb.cumfun = v;
    }
    else {
        linb["cumfun"] = v;
    }
}
function NumberRounding(v) {
    var lnum = v.toString().substr(v.length-1, 1)
    var lnumv = parseInt(lnum);
    if (lnumv >= 5) {
        v =parseInt( v) + 10 - lnumv;
    }
    else {
        v = parseInt(v) - lnumv;
    }
    return v;
}
function NumberFiveZero(v) {
    var lnum = v.toString().substr(v.length - 1, 1)
    var lnumv = parseInt(lnum);
    if (lnumv >= 5) {
        v = parseInt(v) + 5 - lnumv;
    }
    else {
        v = parseInt(v) - lnumv;
    }
    return v;
}
function removeDuplicates(arr) {
    var temp = {}, r = [];
    for (var i in arr)
        temp[arr[i]] = true;
    for (var k in temp)
        r.push(k);
    return r;
}