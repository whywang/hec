var SysEmCode = {
    //通过系统编码获取Emcode
    IQueryCode: function (sv) {
        var url = "../../../SysMenuCode/QueryEmcode";
        var o = { "scode": sv };
        var b = AjaxExb(url, o);
        return b;
    },
    //通过sid获取Emcode
      IQueryCodeById: function (sv,rv) {
          var url = "../../../SysMenuCode/QueryEmcodeById";
          var o = { "sid": sv, "wrtype": rv };
        var b = AjaxExb(url, o);
        return b;
    },
     //通过sid获取主单Emcode
      IMainQueryCodeById: function (sv) {
          var url = "../../../SysMenuCode/QueryMEmcodeById";
          var o = { "sid": sv };
        var b = AjaxExb(url, o);
        return b;
    }
}