function SetOrderPrice(id,bv) {
    var o = { "sid": id,"bcode":bv }
    var url = "../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderPrint"
    var b = AjaxExb(url, o);
}