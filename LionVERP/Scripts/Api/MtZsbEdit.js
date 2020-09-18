var MtZsbEdit = {
    IMtZsbCheck: function (v) {
        var url = "../../../MtAttr/Query";
        var o = { "pcode": v }
        var b = AjaxExb(url, o);
        return b;
    }
}