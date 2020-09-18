
//登录超时处理
    function IsTimeOut(v) {
    alert("登录超时，请重新登录")
    if (this.window.parent) {
        if (this.window.parent.parent) {
            this.window.parent.parent.location.href="../../../Login.htm"
        }
        else {
            this.window.parent.location.href = "../../Login.htm"
        }
    }

}
    function No(v, f,uload) {
        alert("操作失败，请尝试重新操作")
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
        alert("操作失败，记录已存在")
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
        alert("操作成功")
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
            if (v == "") {
                return ;
            }
            if (v != "O" && v != "F" && v != "S" && v != "T"&&v!="") {
                return eval('('+v+')');
            }
        }
    }
