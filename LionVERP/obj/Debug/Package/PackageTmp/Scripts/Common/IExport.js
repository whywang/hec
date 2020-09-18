function Export(id, fname) {
    var str = document.getElementById(id).innerHTML;
    openPostWindow(str, fname)
}
function ExportEx(sid, id, fname) {
    var str = document.getElementById(id).innerHTML;
    //var scode = QueryCode(sid);
//    if (scode != "") {
//        fname = fname + "-" + scode
//    }
    openPostWindow(str, fname)
}
function QueryCode(sid) {
    var o = { "sid": sid }
    var url = "../../../UIServer/CommonFile/CommoOrder.aspx/QueryOrderCode"
    var b = AjaxExb(url, o);
    if (b) {
        return b;
    }
    else {
        return "";
    }
} 
function openPostWindow(data, name) {

    var tempForm = document.createElement("form");
    tempForm.id = "tempForm1";
    tempForm.method = "post";
    tempForm.action = "../../../UIServer/CommonFile/Export.aspx";
    tempForm.target = name;
    var hideInput = document.createElement("input");
    var hfname = document.createElement("input");
    hideInput.type = "hidden";
    hideInput.name = "content";
    hideInput.value = data;
    hfname.name = "fname";
    hfname.type = "hidden";
    hfname.value = name;
    tempForm.appendChild(hideInput);
    tempForm.appendChild(hfname);
    if (window.addEventListener) {
        tempForm.addEventListener("onsubmit", function () { openWindow(name); });
    }
    else {
        tempForm.attachEvent("onsubmit", function () { openWindow(name); });
    }
    document.body.appendChild(tempForm);
    if (window.fireEvent) {
        tempForm.fireEvent("onsubmit");
    }
    else {
        if (document.createEvent) {
            var event = document.createEvent('HTMLEvents');
            event.initEvent("submit", true, true);
            event.eventType = 'message';
            tempForm.dispatchEvent(event);
        }
        if (document.createEventObject) {
            var event = document.createEventObject('HTMLEvents')
            tempForm.fireEvent("onsubmit", event);
        }
    }

    tempForm.submit();
    document.body.removeChild(tempForm);

}