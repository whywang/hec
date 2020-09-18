function InvRemarkCheck(v) {
    var url = '../../../UIServer/CommonFile/CheckRemarks.aspx/CheckInvRemark';
    var o = { "icode": v };
    var b = AjaxExb(url, o);
    return b;
}
 
