function BtnDo(sid,menucode, item) {
    var funstr = item.fun.toString();
    funstr = funstr.replace('[ID]', sid).replace("[Menu]", menucode).replace('[Url]', item.url).replace('[Btn]', item.bcode).replace(new RegExp('_', 'g'), ",") ;
    if (!!(window.attachEvent && !window.opera)) {
        execScript(funstr);
    } else {
        window.eval(funstr);
    }
}
function BtnDoTip(sid, menucode,item,isback) {
    var ko = JSON.stringify(item)
    linb.confirms("确定要操作？", "execfune('" + sid + "', '" + menucode + "'," + ko + " ," + isback + ")")
}
function execfune(sid, menucode, item, isback) {
    BtnDo(sid, menucode, item); if (isback) { GoBack() }
}
///处理一般性事件
function FireGeneralBtn(sid, btn, bms) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/FireEventBtn";
    var o = { "sid": sid,  "bcode": btn, "bstate": 1, "bms": bms }
    var b = AjaxExb(url, o);
    BackVad(b, "", true)
}
///跳转到列表页
function FireGeneralBtnWithBack(sid, btn,bstate, bms) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/FireEventBtn";
    var o = { "sid": sid, "bcode": btn, "bstate": bstate, "bms": bms }
    var b = AjaxExb(url, o);
    BackVad(b, "GoBack()", true)
}
///处理一般性事件
function FireEventBtnAgr(sid, btn, bms) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/FireEventBtnAgr";
    var o = { "sid": sid, "bcode": btn, "bstate": 1, "bms": bms }
    var b = AjaxExb(url, o);
    BackVad(b, "", true)
}
///处理审核性事件
function FireCheckBtn(sid, btn, bstate, bms) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/FireEventBtn";
    var o = { "sid": sid,  "bcode": btn, "bstate": bstate, "bms": bms }
    var b = AjaxExb(url, o);
    BackVad(b, "", true)
}
///处理一般性页面事件
function FireGeneralPageBtn(sid, btn, bms) {
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/FireGeneralPageBtn";
    var o = { "sid": sid, "bcode": btn, "bms": bms }
    var b = AjaxExb(url, o);
    BackVad(b, "", true)
}
///批量处理一般性流程事件
function BatchFireGeneralBtn(sid, btn, bms) {
    var r;
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/BatchFireEventBtn";
    var o = { "sid": sid, "bcode": btn, "bstate": 1, "bms": bms }
    var b = AjaxExb(url, o);
    if (b.length > 1) {
        r = b[1].toString();
    }
    else {
        r = "";
        if (b == "F") {
            linb.warn("操作失败！");
        }
        if (b == "S") {
            linb.msg("操作成功！");
            sleep(5000);
            window.location.href = window.location.href
        }
    }
    return r;
}
function MBatchFireGeneralBtn(sid, bms) {
    var r;
    var url = "../../../UIServer/BaseSet/WorkFlowManage/EventBtnDo.aspx/MBatchFireEventBtn";
    var o = { "sid": sid, "bms": bms }
    var b = AjaxExb(url, o);
    if (b.length > 1) {
        r = b[1].toString();
    }
    else {
        r = "";
        if (b == "F") {
            linb.warn("操作失败！");
        }
        if (b == "S") {
            linb.msg("操作成功！");
            sleep(5000);
            window.location.href = window.location.href
        }
    }
    return r;
}