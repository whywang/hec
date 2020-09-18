var DataSource = {
    IDataSourceItems: function (kj) {
        var url = "../../../DataSource/QueryList";
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
 
