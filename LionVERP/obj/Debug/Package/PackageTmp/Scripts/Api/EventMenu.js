var EventMenu = {
    IQueryEMenu: function (etype, evalue, kj) {
        var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/NQueryListEventMenu";
        var o = { "ptype": etype, "pvalue": evalue };
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
    },
    //获取全部表单
    IQueryEMenuAll: function (etype, kj) {
        var url = "../../../UIServer/BaseSet/WorkFlowManage/EventMenu.aspx/QueryListEventMenuEx";
        var o = { "ptype": etype };
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
    },
    IFlowPoint: function (emcode, kj) {
        var url = "../../../UIServer/BaseSet/WorkFlowManage/WorkFlow.aspx/QueryEventJdList";
        var o = { "emcode": emcode };
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