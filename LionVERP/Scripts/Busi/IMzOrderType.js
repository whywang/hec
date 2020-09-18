function QueryOrderType(vid,av) {
    var o = { "sid": vid, "attr": av }
    var url = "../../../UIServer/CommonFile/CommoOrder.aspx/QueryOrderType"
    var b = AjaxExb(url, o);
    return b;
}