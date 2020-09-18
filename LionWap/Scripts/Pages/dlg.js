function InitDlg(tname,htmstr) {
    layer.open({
        type: 1,
        title: tname,
        closeBtn: 1,
        area: '80%',
        shadeClose: false,
        skin: 'yourclass',
        content: htmstr
    });
}