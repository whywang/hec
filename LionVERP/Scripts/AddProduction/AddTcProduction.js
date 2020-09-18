function QueryTcList(kj) {
    var url = "../../../SetMeal/QueryAreaUsebleTc";
    var b = AjaxEb(url);
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        arr.push({ "id": "", "caption": "" })
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
               arr.push({ "id": cel[0], "caption": cel[1] })
        }
         kj.setItems(arr)
    }
 
}
function QuerySetMeal() {
    var sp=""
    var url = "../../../UIServer/SalesBusiness/DistributorOrder/SetMealProduction.aspx/QueryTc";
    var o = {"tsid":tsid}
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
      ns.tccp.setValue(r.tccode)
    }
}
function SelSetMeal() {
    var sv = ns.tccp.getUIValue();
    if (!sv) {
        sv = "";
    }
    var arr = new Array();
    var url = "../../../UIServer/SalesBusiness/DistributorOrder/SetMealProduction.aspx/QueryTcProduction";
    var o = { "sid": sid,'tsid':tsid ,"tccode": sv }
    var b = AjaxExb(url,o);
    var r = BackVad(b, "", false)
    if (r) {
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": i, "cells": [{ "value": cel[4], "id": i + "_1" }, { "value": cel[5], "id": i + "_2" }, { "value": cel[6], "id": i + "_3" }, { "value": cel[7], "id": i + "_4" }, { "value": cel[8], "id": i + "_5" }, { "value": cel[9], "id": i + "_6" }, { "value": cel[10], "id": i + "_7" }, { "value": cel[11], "id": i + "_8" }, { "value": cel[12], "id": i + "_9" }, { "value": cel[13], "id": i + "_10" }, { "value": cel[14], "id": i + "_11" }, { "value": cel[15], "id": i + "_12" }, { "value": cel[16], "id": i + "_13" }, { "value": cel[17], "id": i + "_14" }, { "value": cel[18], "id": i + "_15" }, { "value": cel[19], "id": i + "_16" }, { "value": cel[20], "id": i + "_17" }, { "value": cel[21], "id": i + "_18" }, { "value": cel[22], "id": i + "_19" }, { "value": cel[23], "id": i + "_20"}] })
        }
        ns.tctreegrid.setRows(arr)
    }
}
function ZpSelSetMeal() {
    var sv = ns.tccp.getUIValue();
    if (!sv) {
        sv = "";
    }
    var arr = new Array();
    var url = "../../../UIServer/SalesBusiness/DistributorOrder/SetMealProduction.aspx/QueryTcZProduction";
    var o = { "sid": sid, 'tsid': tsid, "tccode": sv }
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": i, "cells": [{ "value": cel[4], "id": i + "_1" }, { "value": cel[5], "id": i + "_2" }, { "value": cel[6], "id": i + "_3" }, { "value": cel[7], "id": i + "_4" }, { "value": cel[8], "id": i + "_5" }, { "value": cel[9], "id": i + "_6" }, { "value": cel[10], "id": i + "_7" }, { "value": cel[11], "id": i + "_8" }, { "value": cel[12], "id": i + "_9" }, { "value": cel[13], "id": i + "_10" }, { "value": cel[14], "id": i + "_11" }, { "value": cel[15], "id": i + "_12" }, { "value": cel[16], "id": i + "_13" }, { "value": cel[17], "id": i + "_14" }, { "value": cel[18], "id": i + "_15" }, { "value": cel[19], "id": i + "_16" }, { "value": cel[20], "id": i + "_17" }, { "value": cel[21], "id": i + "_18" }, { "value": cel[22], "id": i + "_19" }, { "value": cel[23], "id": i + "_20"}] })
        }
        ns.zptreegrid.setRows(arr)
    }
}
function SaveTcProduction() {
    var sv =ns.tccp.getUIValue();
    var prow = ns.tctreegrid.getRows("min");
    var zprow = ns.zptreegrid.getRows("min");
    var url = "../../../UIServer/SalesBusiness/DistributorOrder/SetMealProduction.aspx/SaveTcProduction";
    var o = { "sid": sid, "tsid": tsid, "tccode": sv, "prow": prow, "zprow": zprow }
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    window.location.href = "SaleOrderDetail.htm?Sid=" + sid+"&";
}
function DelTc(id) {
    alert(id);
}