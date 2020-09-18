var CaveType = {
    ICaveItem: function (kj) {
        var url = "../../../SizeTransformR/QueryCaveList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    },
    ////门扇门套管理
    IRCaveItem: function (mv, tv, kj) {
        var url = "../../../SizeTransformR/QueryCaveType";
        var o = { "mcode": mv, "tcode": tv }
        var b = AjaxExb(url, o);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r.length>1) {
            kj.setDisplay("block")
            var arr = new Array();
            arr.push({ "id": "", "caption": "" });
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[0], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
        else {
            kj.setDisplay("none")
            kj.setUIValue("");
        }
    }
}