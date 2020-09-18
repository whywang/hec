function QueryOrderAttr(sid, kj) {
    var o = { "sid": sid }
    var url = "../../../UIServer/CommonFile/OrderAttrs.aspx/OrderAttrImg"
    var b = AjaxExb(url, o);
    kj.setHtml(b)
}
function QueryPrepareOrderAttr(sid, kj) {
    var o = { "sid": sid }
    var url = "../../../UIServer/CommonFile/OrderAttrs.aspx/PrepareOrderAttrImg"
    var b = AjaxExb(url, o);
    kj.setHtml(b)
}
function QueryOrderProduceAttr(sid, kj) {
    var o = { "sid": sid }
    var url = "../../../UIServer/CommonFile/OrderAttrs.aspx/OrderProduceState"
    var b = AjaxExb(url, o);
    kj.setCaption(b)
}