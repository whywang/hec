var SizeType = {
    ICheckSizeType: function (v, dp, dg, dk, dh, zg, zgt, mg, mk, zmk) {
        var o = { "icode": v }
        var url = "../../../SizeType/GetSizeTypeAttr";
        var b = AjaxExb(url, o);
        var r = BackVad(b, "", false)
        if (r) {
            for (i = 1; i < r.length; i++) {
                var cel = r[i].toString().split(',')
                szarr.push(cel[2])
            }
        }
        if (szarr.length >= 1) {
            dp.setDisplay("block");
            dg.setDisplay("none");
            dk.setDisplay("none");
            dh.setDisplay("none");
            zg.setDisplay("none");
            zgt.setDisplay("none");
            mg.setDisplay("none");
            mk.setDisplay("none");
            zmk.setDisplay("none");
            for (var i = 0; i < szarr.length; i++) {
                if (szarr[i] == "H") {
                    dg.setDisplay("block");
                }
                if (szarr[i] == "W") {
                    dk.setDisplay("block");
                }
                if (szarr[i] == "D") {
                    dh.setDisplay("block");
                }
                if (szarr[i] == "F") {
                    zg.setDisplay("block");
                }
                if (szarr[i] == "B") {
                    zgt.setDisplay("block");
                }
                if (szarr[i] == "G") {
                    mg.setDisplay("block");
                }
                if (szarr[i] == "K") {
                    mk.setDisplay("block");
                }
                if (szarr[i] == "C") {
                    zmk.setDisplay("block");
                }
            }
        }
        else {
            if (d11 == "0") {
                dp.setDisplay("block");
            }
            else {
                dp.setDisplay("none");
            }
            dg.setDisplay("block");
            dk.setDisplay("block");
            dh.setDisplay("block");
            zg.setDisplay("none");
            zgt.setDisplay("none");
            mg.setDisplay("none");
            mk.setDisplay("none");
            zmk.setDisplay("none");
        }
        szarr.length = 0;
    }
}