var ProductionApartType = {
    IApartTypeCate: function (kj) {
        var url = "../../../UIServer/ProductionSet/PartTypeManage/Parttypes.aspx/QueryCateList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[1], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    },
    IApartTypeItems: function (kj) {
        var url = "../../../UIServer/ProductionSet/PartTypeManage/Parttypes.aspx/QueryList";
        var b = AjaxEb(url);
        kj.setItems();
        var r = BackVad(b, "", false)
        if (r) {
            var arr = new Array();
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                arr.push({ "id": cel[2], "caption": cel[1] })
            }
            kj.setItems(arr)
        }
    }
}