function CheckLimited(icode,hv,wv,dv ,fv) {
    var o = { "icode": icode, "hv": hv ,"wv":wv,"dv":dv,"fv":fv}
    var url = "../../../SizeLimited/CheckTip"
    var b = AjaxExb(url, o);
    if (b=="S") {
        return true;
    }
    else {
        alert(b)
    }
    
}