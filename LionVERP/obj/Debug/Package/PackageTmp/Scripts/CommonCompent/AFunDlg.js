Class('App.AFunDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.DataBinder)
                .setHost(host, "fbinder")
                .setName("fbinder")
            );

            append(
                (new linb.UI.Dialog)
                .setHost(host, "fdlg")
                .setLeft(130)
                .setTop(160)
                .setWidth(550)
                .setHeight(190)
                .setCaption("增加方法")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.fdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ftoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ftoolbar_onclick")
            );

            host.fdlg.append(
                (new linb.UI.Input)
                .setHost(host, "fname")
                .setDataBinder("fbinder")
                .setDataField("fname")
                .setLeft(70)
                .setTop(40)
                .setWidth(370)
                .setHeight(50)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("方法名称")
                .setLabelHAlign("left")
            );

            host.fdlg.append(
                (new linb.UI.Input)
                .setHost(host, "fstr")
                .setLeft(70)
                .setTop(90)
                .setWidth(370)
                .setHeight(50)
                .setLabelSize(20)
                .setLabelPos("top")
                .setLabelCaption("方法")
                .setLabelHAlign("left")
                .setDataBinder("fbinder")
                .setDataField("fstr")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            ds = this;
            this.fdlg.show();
        },
        _ftoolbar_onclick: function (profile, item, group, e, src) {
            var ds = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                SaveFunction()
            }
            ds.fdlg.setDisplay("none")
        }
    }
});
function SaveFunction() {
    if (!CheckInput(ds, ds.fname, true, "", "方法名称不能为空！", "", "", "")) {
        return
    }
    if (!CheckInput(ds, ds.fstr, true, " ", "方法不能为空", " ", "", "")) {
        return
    }
    var url = "../../../CommonFunction/SaveFun"
    var db = linb.DataBinder.getFromName("fbinder");
    var o = db.updateDataFromUI().getData();
    var b = AjaxExb(url, o)
    BackVad(b, "", false)
}