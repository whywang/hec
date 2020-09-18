function LogoImg(id, v) {
    var o = { "mtype": v }
    var url = "../../../UIServer/SystemInfo/SystemState.aspx/InitImg"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        $("#" + id).attr('src', r.murl);
    }
}