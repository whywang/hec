//初始化对话框对象Dlg
 appinit = AppInit;
 var Dlg = {
     checkdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.CheckDlg",
                          appinit.pdomain() + "/Scripts/CommonCompent/CheckDlg.js?V=" + dt,
                          function () { var ins = new App.CheckDlg(); ins.show(); },
                          function () { linb.alert("faile") }
                    )
     },
     checkbackdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.CheckBackDlg",
                          appinit.pdomain() + "/Scripts/CommonCompent/CheckBackDlg.js?V=" + dt,
                          function () { var ins = new App.CheckBackDlg(); ins.show(); },
                          function () { linb.alert("faile") }
                    )
     },
     attachmentdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AttachmentDlg",
                          appinit.pdomain() + "/Scripts/CommonCompent/AttachmentDlg.js?V=" + dt,
                          function () { var ins = new App.AttachmentDlg(); ins.show(); },
                          function () { linb.alert("faile") }
                    )
     },
     apartdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ApartDlg",
                          appinit.pdomain() + "/Scripts/CommonCompent/ApartDlg.js?V=" + dt,
                          function () { var ins = new App.ApartDlg(); ins.show(); },
                          function () { linb.alert("faile") }
                    )
     },
     discountdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DiscountDlg",
                          appinit.pdomain() + "/Scripts/CommonCompent/DiscountDlg.js?V=" + dt,
                          function () { var ins = new App.DiscountDlg(); ins.show(); },
                          function () { linb.alert("faile") }
                    )
     },
     ordercodedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OrderCodeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OrderCodeDlg.js?V=" + dt,
            function () { var ins = new App.OrderCodeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     payimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.PayImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/PayImgDlg.js?V=" + dt,
            function () { var ins = new App.PayImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     showpaydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.PayImgListDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/PayImgListDlg.js?V=" + dt,
            function () { var ins = new App.PayImgListDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     rqdesigndlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.RequestDesignPlanDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/RequestDesignPlanDlg.js?V=" + dt,
            function () { var ins = new App.RequestDesignPlanDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     designdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DesignPlanDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DesignPlanDlg.js?V=" + dt,
            function () { var ins = new App.DesignPlanDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     otypedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OrderTypeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OrderTypeDlg.js?V=" + dt,
            function () { var ins = new App.OrderTypeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     custommoneydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.CustomerMoneyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/CustomerMoneyDlg.js?V=" + dt,
            function () { var ins = new App.CustomerMoneyDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     assignmentdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AssignmentTaskDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AssignmentTaskDlg.js?V=" + dt,
            function () { var ins = new App.AssignmentTaskDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     uppricefiledlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.UpPriceFileDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/UpPriceFileDlg.js?V=" + dt,
            function () { var ins = new App.UpPriceFileDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     aftrerimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterImgDlg.js?V=" + dt,
            function () { var ins = new App.AfterImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     afteruppricefiledlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterUpPriceFileDlg",
           appinit.pdomain() + "/Scripts/CommonCompent/AfterUpPriceFileDlg.js?V=" + dt,
            function () { var ins = new App.AfterUpPriceFileDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     dutydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DutyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DutyDlg.js?V=" + dt,
            function () { var ins = new App.DutyDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     measuredlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.MeasureDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/MeasureDlg.js?V=" + dt,
            function () { var ins = new App.MeasureDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     addbtnicodlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.BtnImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/BtnImgDlg.js?V=" + dt,
            function () { var ins = new App.BtnImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     showfunctiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.SFunDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SFunDlg.js?V=" + dt,
            function () { var ins = new App.SFunDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     addfunctiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AFunDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AFunDlg.js?V=" + dt,
            function () { var ins = new App.AFunDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     logdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.LogDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/LogDlg.js?V=" + dt,
            function () { var ins = new App.LogDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     addproductiondlg: function (dt) {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AddProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AddProductionDlg.js?V=" + dt,
            function () { var ins = new App.AddProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     showattachmentdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowAttachmentDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowAttachmentDlg.js?V=" + dt,
            function () { var ins = new App.ShowAttachmentDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     preparedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.PrePareDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/PrePareDlg.js?V=" + dt,
            function () { var ins = new App.PrePareDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     addyqproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AddProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AddYqProductionDlg.js?V=" + dt,
            function () { var ins = new App.AddProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     setordertypedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.SetOrderTypeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SetOrderTypeDlg.js?V=" + dt,
            function () { var ins = new App.SetOrderTypeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //设置订单备注
     setorderremarkdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OrderRemarkDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OrderRemarkDlg.js?V=" + dt,
            function () { var ins = new App.OrderRemarkDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //订单分厂
     orderdistributionfactorydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OrderDistributionFactroyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OrderDistributionFactroyDlg.js?V=" + dt,
            function () { var ins = new App.OrderDistributionFactroyDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //产品质检
     qualitydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.QualityDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/QualityDlg.js?V=" + dt,
            function () { var ins = new App.QualityDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     mqorderinhousedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.MqOrderInHouseDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/MqOrderInHouseDlg.js?V=" + dt,
            function () { var ins = new App.MqOrderInHouseDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //更改单产品更改需求录入
     productionchangedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ProdcutionChangeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProdcutionChangeDlg.js?V=" + dt,
            function () { var ins = new App.ProdcutionChangeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //更改单产品更改需求录入
     changecostdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ChangeCostDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ChangeCostDlg.js?V=" + dt,
            function () { var ins = new App.ChangeCostDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //更改单编辑产品
     changeproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ChangeProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ChangeProductionDlg.js?V=" + dt,
            function () { var ins = new App.ChangeProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //售后原因
     aftersalereasondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.AfterSaleReasonDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterSaleReasonDlg.js?V=" + dt,
            function () { var ins = new App.AfterSaleReasonDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //订单查询
     searchsaleorderdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.SearchSaleOrderDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SearchSaleOrderDlg.js?V=" + dt,
            function () { var ins = new App.SearchSaleOrderDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //产品图片
      productionimgdlg: function (vv) {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ProductionImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProductionImgDlg.js?V=" + dt,
            function () { var ins = new App.ProductionImgDlg(); ins.show();},
            function () { linb.alert("faile") }
        )
     } ,
     //订单生产方式
     setorderproducedlg: function (vv) {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ProduceTypeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProduceTypeDlg.js?V=" + dt,
            function () { var ins = new App.ProduceTypeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     }, 
     //售后显示图
     showafterimgdlg: function (vv) {
         var dt = new Date().Format("yyyyMMddhhmmss")
         linb.include("App.ShowAfterImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowAfterImgDlg.js?V=" + dt,
            function () { var ins = new App.ShowAfterImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //售后产品新增
     addafteryqproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterAddYqProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterAddYqProductionDlg.js?V=" + dt,
            function () { var ins = new App.AfterAddYqProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //木作店面设计需求
     rqdesigndlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DesignRequestDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DesignRequestDlg.js?V=" + dt,
            function () { var ins = new App.DesignRequestDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //木作产品类型
     productiontypedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ProductionTypeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProductionTypeDlg.js?V=" + dt,
            function () { var ins = new App.ProductionTypeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //新增物料产品
     addwlproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AddWlProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AddWlProductionDlg.js?V=" + dt,
            function () { var ins = new App.AddWlProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //返修类别选择
     afterptypedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterPtypeDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterPtypeDlg.js?V=" + dt,
            function () { var ins = new App.AfterPtypeDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //安装售后预约
     afterappointment: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AppointmentDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AppointmentDlg.js?V=" + dt,
            function () { var ins = new App.AppointmentDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //安装师分配
     afterdisfixerdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DisFixerDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DisFixerDlg.js?V=" + dt,
            function () { var ins = new App.DisFixerDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //上传服务图
     serviceimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ServiceDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ServiceDlg.js?V=" + dt,
            function () { var ins = new App.ServiceDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //显示服务图
     showserviceimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowServiceImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowServiceImgDlg.js?V=" + dt,
            function () { var ins = new App.ShowServiceImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //服务处理
     overserviecdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OverServiceDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OverServiceDlg.js?V=" + dt,
            function () { var ins = new App.OverServiceDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     } ,
     //添加售后产品
     addafterproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AddAfterProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AddAfterProductionDlg.js?V=" + dt,
            function () { var ins = new App.AddAfterProductionDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //售后产品图片
     afterproductionimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterProductionImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterProductionImgDlg.js?V=" + dt,
            function () { var ins = new App.AfterProductionImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     } ,
     //售后产品图片
     showafterproductionimgdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowAfterProductionImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowAfterProductionImgDlg.js?V=" + dt,
            function () { var ins = new App.ShowAfterProductionImgDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //售后产品图片
     afterdutydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterDutyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterDutyDlg.js?V=" + dt,
            function () { var ins = new App.AfterDutyDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //设置完工日期
     setoverdatadlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.SetOverDateDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SetOverDateDlg.js?V=" + dt,
            function () { var ins = new App.SetOverDateDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
      //售后产品入库
     afrerproductioninhousedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterProductionInHouseDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterProductionInHouseDlg.js?V=" + dt,
            function () { var ins = new App.AfterProductionInHouseDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //售后付费方式
     afrerpmethoddlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterPMethodDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterPMethodDlg.js?V=" + dt,
            function () { var ins = new App.AfterPMethodDlg(); ins.show(); },
            function () { linb.alert("faile") }
        )
     },
     //包装设置
     setpackagedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.SetPackageDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SetPackageDlg.js?V=" + dt,
            function () { var ins = new App.SetPackageDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //设置完工日期
     setsenddatadlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.SetSendDateDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/SetSendDateDlg.js?V=" + dt,
            function () { var ins = new App.SetSendDateDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
      //安装售后预约
     afterredoappointment: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterAppointmentDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterAppointmentDlg.js?V=" + dt,
            function () { var ins = new App.AfterAppointmentDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //测量预约
     measureappointment: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AppointmentMeasureDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AppointmentMeasure.js?V=" + dt,
            function () { var ins = new App.AppointmentMeasureDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //新加产品返修内容
     afterprouctionremark: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterProuctionRemarkDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterProuctionRemarkDlg.js?V=" + dt,
            function () { var ins = new App.AfterProuctionRemarkDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //新加产品返修内容
     setmeasureperson: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.MeasurePersonDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/MeasurePersonDlg.js?V=" + dt,
            function () { var ins = new App.MeasurePersonDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     // 显示测量单
     showmeasureimg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowMeasureImgDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowMeasureImgDlg.js?V=" + dt,
            function () { var ins = new App.ShowMeasureImgDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     // 设置产品车间
     setworkforms: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ProductionWorkFormDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProductionWorkFormDlg.js?V=" + dt,
            function () { var ins = new App.ProductionWorkFormDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //合同
     showcontract:function()
     {
       var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ContractDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ContractDlg.js?V=" + dt,
            function () { var ins = new App.ContractDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //售后实际金额
     aftertmoney: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AfterTMoneyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AfterTMoneyDlg.js?V=" + dt,
            function () { var ins = new App.AfterTMoneyDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //优惠金额
     favorablemoney: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.FavorableMoneyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/FavorableMoneyDlg.js?V=" + dt,
            function () { var ins = new App.FavorableMoneyDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //分配拆单
     dismantledlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DismantleDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DismantleDlg.js?V=" + dt,
            function () { var ins = new App.DismantleDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //门扇排产
     msplandlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.MsPlanDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/MsPlanDlg.js?V=" + dt,
            function () { var ins = new App.MsPlanDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //分包
     packagedlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.PackageDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/PackageDlg.js?V=" + dt,
            function () { var ins = new App.PackageDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //非标产品
     addcustomeproductiondlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.AddCustomeProductionDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/AddCustomeProductionDlg.js?V=" + dt,
            function () { var ins = new App.AddCustomeProductionDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
     ,
     //非标设计方案
     designdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.DesignDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/DesignDlg.js?V=" + dt,
            function () { var ins = new App.DesignDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //非标设计方案
     showdesigndlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowDesignDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowDesignDlg.js?V=" + dt,
            function () { var ins = new App.ShowDesignDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //非标设计方案
     setordermoneydlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.OrderMoneyDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/OrderMoneyDlg.js?V=" + dt,
            function () { var ins = new App.OrderMoneyDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //非标设计方案
     showapartdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ShowApartDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ShowApartDlg.js?V=" + dt,
            function () { var ins = new App.ShowApartDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     },
     //非标设计方案
     showpostdlg: function () {
         var dt = new Date().Format("yyyyMMddhhmmss");
         linb.include("App.ProductionCostDlg",
            appinit.pdomain() + "/Scripts/CommonCompent/ProductionCostDlg.js?V=" + dt,
            function () { var ins = new App.ProductionCostDlg(); ins.show(); },
            function () { linb.warn("加载失败") }
        )
     }
 }