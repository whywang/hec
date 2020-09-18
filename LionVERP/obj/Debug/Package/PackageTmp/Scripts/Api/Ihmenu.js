///获取帮助文档
function IHelpItems(v, kj) {
    var url = "../../../HelpMenu/QueryList";
    var o = { "hcode": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                arr.push({ "id": cel[0], "caption": cel[1], "sub": [] })
            }
            else {
                arr.push({ "id": cel[0], "caption": cel[1], "type": "checkbox" })
            }
        }
        kj.setItems(arr)
    }
}
//获取子帮助文档
function IHelpCItems(item, kj) {
    var url = "../../../HelpMenu/QueryList";
    var o = { "hcode": item.id };
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    var l = item.hasOwnProperty("sub");
    if (l && item.sub.length <= 0) {
        var arr = new Array();
        kj.removeChildren(item.id, true);
        for (var i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            if (cel[2] == "false") {
                kj.insertItems([{ "id": cel[0], "caption": cel[1], "sub": []}], item.id)
            }
            else {
                kj.insertItems([{ "id": cel[0], "caption": cel[1]}], item.id)
            }
        }
    }
}
//检索末级文档标题
function IHelpEndItem(v, kj) {
    var url = "../../../HelpMenu/QueryAllHmenu";
    var o = { "tstr": v };
    var b = AjaxExb(url, o);
    kj.setItems();
    var r = BackVad(b, "", false)
    if (r) {
        var arr = new Array();
        for (i = 1; i < r.length; i++) {
            var cel = r[i].toString().split(',')
            arr.push({ "id": cel[0], "caption": cel[1], "type": "checkbox" });
        }
        kj.setItems(arr)
    }
}