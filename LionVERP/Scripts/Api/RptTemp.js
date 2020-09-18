
//报表模板
var RptTemp = {
    IRptTempHead: function (ev) {
        var url = "../../../RptTemp/QueryOne";
        var o = {"emcode":ev}
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        if (r) {
            return r.thtext;
        }
    }
}