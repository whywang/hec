var WorkCraft = {
    IWorkCraftItem: function (kj) {
             var o = { "lcode": "" }
            var url = "../../../ProductionProcessPrice/QueryGyAllList";
            var b = AjaxExb(url, o);
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
    }
}