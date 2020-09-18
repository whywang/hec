Class('App.AssignmentTaskDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setLeft(130)
                .setTop(160)
                .setWidth(550)
                .setHeight(160)
                .setCaption("设计师")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.ToolBar)
                .setHost(host, "ctoolbar")
                .setItems([{ "id": "grp1", "sub": [{ "id": "a1", "caption": "确定" }, { "id": "a2", "type": "split", "split": true }, { "id": "a3", "caption": "取消"}], "caption": "grp1"}])
                .onClick("_ctoolbar_onclick")
            );

            host.cdlg.append(
                (new linb.UI.ComboInput)
                .setHost(host, "adesigner")
                .setLeft(50)
                .setTop(60)
                .setWidth(420)
                .setHeight(25)
                .setLabelSize(60)
                .setLabelCaption("设计师")
                .setType("listbox")

            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            ds = this;
            IEmployeeItems("0104", ds.adesigner)
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                var cv = ds.adesigner.getUIValue();
                if (!CheckInput(ds, ds.adesigner, true, "", "请选择设计师！", "", "", "")) {
                    return
                }
                setDesigner(cv);
                ds.cdlg.setDisplay("none")
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    }
});
function setDesigner(cv) {
    var o = { "sid": sid, 'dv': cv }
    var url = '../../../UIServer/CommonFile/CommoOrder.aspx/SetOrderDesigner';
    var b = AjaxExb(url, o);
    BackVad(b, "", true);
}
 

 