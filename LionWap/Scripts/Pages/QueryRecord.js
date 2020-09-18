var QueryRecord = {
    init: function () {
        var qr = {};
        qr.QueryList = function (timespan, curpage, pagesize, url,wheres,utype) {
            var o = { 'timespan': timespan, 'curpage': curpage, 'pagesize': pagesize, 'wheres': wheres, 'utype': utype }
            return AjaxExb(url, o);
        }
        return qr;
    }

}