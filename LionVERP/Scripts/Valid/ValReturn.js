
//登录超时处理
    function IsTimeOut(v) {
        alert("登录超时，请重新登录")
        isFlagLogin =0;
    if (this.window.parent) {
        if (this.window.parent.parent) {
            this.window.parent.parent.location.href="../../../Login.htm"
        }
        else {
            this.window.parent.location.href = "../../Login.htm"
        }
    }

}
function No(v, f, uload) {
    if (toastr) {
        toastr.error("操作失败，请尝试重新操作")
    }
    else {
        linb.warn("操作失败，请尝试重新操作")
    }
        if (f != "") {
            if (!!(window.attachEvent && !window.opera)) {
                //ie
                execScript(f);
            } else {
                window.eval(f);
            }
        }
        if (uload) {
            window.location.href = window.location.href
        }

    }
    function Same(v, f, uload) {
        linb.warn("操作失败，记录已存在")
        if (f != "") {
            if (!!(window.attachEvent && !window.opera)) {
                //ie
                execScript(f);
            } else {
                window.eval(f);
            }
        }
        if (uload) {
            window.location.href = window.location.href
        }

    }
    function Ok(v, f, uload) {
            linb.msg("操作成功")
        if (f != "") {
            if (!!(window.attachEvent && !window.opera)) {
                //ie
                execScript(f);
            } else {
                window.eval(f);
            }
        }
        if (uload) {
            window.location.href = window.location.href
        }
    }
    function BackVad(v, f, uload) {
        if ((typeof v == 'object') && v.constructor == Array) {
            if (v[0] == "O") {
                IsTimeOut(v)
                return;
            }
            if (v[0] == "F") {
                No(v, f, uload)
                return;
            }
            if (v[0] == "S") {
                return v;
            }
 
        }
        if ((typeof v == 'string') && v.constructor == String) {
            if (v == "O") {
                IsTimeOut(v)
                return ;
            }
            if (v == "F") {
                No(v, "", uload)
                return ;
            }
            if (v == "S") {
                Ok(v, f, uload)
                return ;
            }
            if (v == "T") {
                Same(v, f, uload)
                return;
            }
            if (v == "TA") {
                alert("登录账号已存在！")
                return;
            }
            if (v == "") {
                return ;
            }
            if (v == "MB") {
                alert("金额过大")
                return;
            }
            if (v == "PB") {
                alert("请用店面账号添加订单")
                return;
            }
            if (v == "ML") {
                linb.warn("账户金额不足")
                return;
            }
            if (v == "R") {
                alert("系统默认设置，无法操作！")
                return;
            }
            if (v == "MOB") {
                linb.warn("测量预约已满，请选择其他日期！")
                return;
            }
            if (v!= "MOB"&&v != "R" && v != "O" && v != "F" && v != "S" && v != "T" && v != "" && v != "MB") {
                return eval('('+v+')');
            }
        }
    }
