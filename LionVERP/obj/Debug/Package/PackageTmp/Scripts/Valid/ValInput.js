function CheckInput(ns, o, rq, inputtype, rtip, ftip, svalue, bvalue) {
    var v = "";
    if (rq) {
        if (inputtype == "date") {
            v = o.getUIValue();
        }
        else {
            v = _.str.trim(o.getUIValue())
        }
        if (v == "" || v == null) {
            linb.warn(rtip)
            o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
            return false;
        }
        else {
            o.setCustomStyle()
        }
        switch (inputtype) {
            case "number":
                if (!isNum(v)) {
                    linb.warn(ftip);
                    o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
                    return false;
                }
                if (svalue != "") {
                    if (parseInt(v) < parseInt(svalue)) {
                        linb.warn("数值范围错误")
                        o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
                        return false;
                    }
                }
                if (bvalue != "") {
                    if (parseInt(v) >= parseInt(bvalue)) {
                        linb.warn("数值范围错误")
                        o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
                        return false;
                    }
                }
                break;
            case "telephone":
                var a = /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$|(^(13[0-9]|15[0-9]|18[0-9]|19[0-9]|17[0-9])\d{8}$)/;
                if (!a.test(v)) {
                    linb.warn(ftip)
                    o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
                    return false;
                }
                break;

        }
        return true;
    }
}
function CheckFormat(o, fstr, tip) {
    var v = _.str.trim(o.getUIValue())
    if (!fstr.test(v)) {
        linb.warn(tip);
        o.setCustomStyle({ "KEY": "border:1px solid #fa0611" })
        return false;
    }
    return true;
}
function isNum(input) {
    var re = /^-?(\d\d*\.\d*$)|(^-?\d\d*$)|(^-?\.\d\d*$)/
    if (!re.test(input)) {
        return false;
    }
    else {
        return true;
    }
}