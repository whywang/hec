var SearchBox = {
    SetSearchCk: function (bname, tname, oname) {
        var sstr = "";
        var db = linb.DataBinder.getFromName(bname);
        var arg2 = db.updateDataFromUI().getData();
        var arg3 = db._nodes[0]._n
        for (i = 0; i < arg3.length; i++) {
            var fkey = arg3[i].alias;
            var kk = arg3[i].properties.value
            sstr = sstr + fkey + ":" + kk + "-";
        }
        SetCookie(oname + "-" + tname + "-" + bname, sstr)
    },
    GetSearchCk: function (bname, tname, oname) {
        var sstr = GetCookie(oname + "-" + tname + "-" + bname);
        var sarr = sarr = sstr.split("-");
        for (i = 0; i < sarr.length - 2; i++) {
            sv = sarr[i];
            var asv = sv.toString().split(":");
            if (asv[1].toString() != "" && asv[1] != null) {
                var estr = "skey." + asv[0] + ".setValue('" + asv[1] + "')";
                execfun(estr)
            }
        }
    }
}