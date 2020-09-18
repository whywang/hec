var BigUpFile = {
    url: "",
    ufile: "",
    exfname: "", //回调方法
    upload: function (jdtname, skip, curwin, exefun) {
        var othis = this;
        var fsize = this.ufile.size;
        var formData = new FormData(); //初始化一个FormData对象
        var blockSize = 1000000; //每块的大小
        var lp = Math.ceil(this.ufile.size / blockSize);
        var nextSize = Math.min((skip + 1) * blockSize, fsize); //读取到结束位置        
        var fileData = this.ufile.slice(skip * blockSize, nextSize); //截取 部分文件 块
        formData.append("file", fileData); //将 部分文件 塞入FormData
        formData.append("fileName", this.ufile.name); //保存文件名字
        formData.append("partName", this.ufile.name + "-" + skip); //保存文件名字
        $.ajax({
            url: this.url,
            type: "POST",
            data: formData,
            processData: false,  // 告诉jQuery不要去处理发送的数据
            contentType: false,
            success: function (responseText) {
                if (jdtname != "") {
                    jdtname.setValue(Math.ceil((skip + 1) * 100 / lp))
                }
                if (fsize <= nextSize) {
                    alert("上传完成");
                    execfun(exefun)
                    if (curwin != null) {
                        curwin.setDisplay("none")
                    }
                    return;
                }
                othis.upload(jdtname, ++skip, curwin, exefun)
            }
        });
    }
}