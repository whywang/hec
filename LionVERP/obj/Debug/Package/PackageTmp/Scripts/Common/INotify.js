function ReadNotify(id) {
    var url = '../../../UIServer/CommonFile/Notify.aspx/ReadNotify'
    var o = { "id": id };
    var b = AjaxExb(url, o);
}  
