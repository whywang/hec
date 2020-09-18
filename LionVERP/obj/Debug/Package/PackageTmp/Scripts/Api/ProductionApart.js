var ProductionApart = {
    Iprodctionapart: function (cstr) {
        var url = "../../../SizeFormat/CommonSizeCollection";
        var b = AjaxEb(url);
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[4], "caption": cel[2] })
            }
            linb.UI.cacheData(cstr, arr)
        }
    }
}