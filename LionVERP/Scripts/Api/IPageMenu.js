//获取详情页对应表单编码
function QueryEmcodeByPmcode(v) {
    var r = "";
    var o = { "tmcode": v }
    var url = "../../../MenuTab/CustGetTabMenuEventMenu"
    var b = AjaxExb(url, o);
    if (b) {
        r = b;
    }
    return r;
}