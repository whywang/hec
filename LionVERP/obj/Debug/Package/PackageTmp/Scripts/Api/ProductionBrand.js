var ProductionBrand = {
    //下拉框
    IPBrandItem: function (kj) {
        var url = "../../../ProductionBrand/DepBrandList";
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
    //树状
    IPBrandTreeItem: function (kj) {
        var url = "../../../ProductionBrand/QueryList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                if (cel[2] == "false") {
                    arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
                }
                else {
                    arr.push({ "id": cel[0], "caption": cel[1] })
                }
            }
            kj.setItems(arr)
        }
    },
    IFristFactory: function (bv, kj) {
        var url = "../../../ProductionBrand/QueryBrandFactory";
        var o = { "bcode": bv }
        var b = AjaxExb(url, o);
        if (b) {
            kj.setUIValue(b);
        }
    }
}
