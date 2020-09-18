BankAccount = {
    //城市付款账户
    IPaccount: function (kj) {
        var url = "../../../PayAccount/QueryPList";
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
    //总部收款账户
    IGaccount: function (kj) {
        var url = "../../../CollectionAccount/QueryCList";
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
    //系统账户
    ISaccount: function (kj) {
        var url = "../../../CityAccount/QueryCityList";
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
    IBankList:function(kj)  {
    var url = "../../../Banks/QueryList";
    var b = AjaxEb(url);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[0] })
        }
        kj.setItems(arr)
    }
}
}