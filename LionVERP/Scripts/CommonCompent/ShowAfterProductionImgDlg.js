Class('App.ShowAfterProductionImgDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setTop(140)
                .setWidth(1000)
                .setHeight(450)
                .setCaption("返修产品图")
                .setMinBtn(false)
                .setMaxBtn(false)
            );

            host.cdlg.append(
                (new linb.UI.Pane)
                .setHost(host, "plimg")
                .setDock("top")
                .setHeight("auto")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            ds = this;
            this.cdlg.show();
            QueryImg()
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});
function QueryImg() {
    var o = { "sid": sid,"gnum":agnum }
    var url = '../../../UIServer/CommonFile/ImageFiles.aspx/AfterProductionImgShow';
    var b = AjaxExb(url, o);
    if (b) {
        ds.plimg.setHtml(b)
    }
}