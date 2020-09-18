Class('App.ContractDlg', 'linb.Com', {
    Instance: {
        base: ["linb.UI"],

        iniComponents: function () {
            // [[code created by jsLinb UI Builder
            var host = this, children = [], append = function (child) { children.push(child.get(0)) };

            append(
                (new linb.UI.Dialog)
                .setHost(host, "cdlg")
                .setDock("center")
                .setLeft(20)
                .setTop(50)
                .setWidth(979)
                .setHeight(620)
                .setCaption("销售合同")
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
                (new linb.UI.Pane)
                .setHost(host, "pstr")
                .setDock("fill")
            );

            return children;
            // ]]code created by jsLinb UI Builder
        },
        customAppend: function () {
            this.cdlg.show();
            htjf="",htyf="",jfdz="",yfdz="",jfdh="",yfdh=""
            ds = this;
            QueryContract();
        },
        _ctoolbar_onclick: function (profile, item, group, e, src) {
            var ns = this, uictrl = profile.boxing();
            if (item.id == "a1") {
                createNewTable()
            }
            if (item.id == "a3") {
                ds.cdlg.setDisplay("none")
            }
        }
    },
    Static: {
        viewSize: { "width": 1024, "height": 768 }
    }
});

function QueryContract() {
    var tbstr = QueryHtProduction();
    QueryHtOrder();
    var tstr = "<div style='width:690px; list-style:none;margin-left:-20px'><ul style='list-style-type: none;' > <li style='margin-top:10px'>甲&nbsp;&nbsp;方：<span style='text-decoration:underline; width:200px'>" + htjf + "</span><span style='text-decoration: none;'>（需方）</span> </li><li style='margin-top:10px'><span style='text-decoration: none;'>详细地址：</span><span style='text-decoration: underline;'>" + jfdz + " </span></li><li style='margin-top:10px'><span style='text-decoration: none;'>联系电话：</span><span style='text-decoration: underline;'>" + jfdh + "</span><span style='text-decoration: none;'>传 真：</span><span style='text-decoration: underline;'> </span></li><li style='margin-top:10px'><span style='text-decoration: none;'>乙方：</span><span style='text-decoration: underline;'> " + htyf + "</span><span style='text-decoration: none;'>（经销商)</span></li><li style='margin-top:10px'><span style='text-decoration: none;'></span>详细地址：<span style='text-decoration: underline;'>" + yfdz + "</span></li><li style='margin-top:10px'> <span style='text-decoration: none;'>联系电话：</span><span style='text-decoration: underline;'> " + yfdh + "</span><span style='text-decoration: none;'>传 真：</span><span style='text-decoration: underline;'> </span> </li><li style='margin-top:10px'>&nbsp; &nbsp; &nbsp; &nbsp;为维护甲、乙双方的合法权益，根据《中华人民共和国消费者权益保护法》和《中华人民共和国合同法》及其相关规定，特制定本定单。</li><li style='margin-top:10px'>一、产品信息（本订单所指产品系“霍尔茨●T型门”）</li><li style='margin-top:10px'>二、规格及其它要求：详见第 号测量单。</li><li style='margin-top:10px'>三、生产标准</li><li style='margin-top:10px; text-indent:2em'>(一)、本产品根据定单、依据行业标准生产。</li><li style='margin-top:10px; text-indent:2em'>(二)、本产品所采用的钢化玻璃按GB/T9963-1998标准生产，玻璃制作多为手工工艺，故实际图案与样品存在差异，不属于产品质量问题，外观质量执行合格品标准。</li><li style='margin-top:10px'>四、交货日期及方式 </li><li style='margin-top:10px;text-indent:2em'>自本定单签订并向乙方交付全部货款之日起，<span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>（大写）天后，即为</span><span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>年</span><span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>月</span><span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>日交货；乙方将产品运到安装现场，并将产品交付给甲方，同时，甲方对产品进行核对、检查验收、签收验收单。</span> </li><li style='margin-top:10px'>五、产品的安装 </li> <li style='margin-top:10px; text-indent:2em'>(一)、安装环境：本产品属集成类产品，产品的安装环境需由甲方提供，甲方应将安装位置和内、外墙体及地面处理垂直、水平，达到安装要求；同时甲方需要为乙方提供必要的施工环境，从而确保产品安装质量。否则，出现任何安装问题乙方概不负责。</li><li style='margin-top:10px; text-indent:2em'> (二)、安装时间：产品的安装须在甲方铺完地板、地砖、墙体预留一遍面漆前进行，如需要先装门后铺地板，造成的一切损失与乙方无关。</li><li style='margin-top:10px;text-indent:2em'> (三)、如果由于甲方原因导致乙方不能如期安装，甲方应在再次安装时提前5天与乙方预约，乙方将视工作情况具体安排安装时间，由此造成延期责任和损失由甲方承担。</li><li style='margin-top:10px; text-indent:2em'> (四)、在甲方具备安装条件的情况下，由于乙方原因造成安装延期的，乙方应给甲方赔偿延期损失，赔偿金额最高为本定单总额的1‰ 。</li><li style='margin-top:10px;text-indent:2em'> (五)、由于甲方不具备安装条件且要求乙方到达现场未能安装，二次安装时甲方需承担二次上门费<span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>元</span>  </li><li style='margin-top:10px'>六、付款方式  </li><li style='margin-top:10px;text-indent:2em'>甲、乙双方在签订本订单时，甲方应预付乙方全部贷款，即大写人民币：<span style='text-decoration: underline;'> </span><span style='text-decoration: none;'>元，乙方安排生产。</span> </li><li style='margin-top:10px'>七、质量保证  </li><li style='margin-top:10px;text-indent:2em'>(一)、乙方产品已达到《室内装饰装修材料、人造板及其制品中甲醛释放量》标准，属E1级环保产品。 </li></ul></div>"
    var sstr = "<div style='width:690px; list-style:none;margin-left:-20px'><ul style='list-style:none'><li style='margin-top:10px;text-indent:2em'>(二)、在甲方正常使用情况下，出现质量问题，自购买之日起贰年内乙方负责保修。 </li><li style='margin-top:10px;text-indent:2em'>(三)、出现下列情况将不在保修范围，但在甲方支付材料成本费用的前提下乙方可以提供维修服务： </li><li style='margin-top:10px;text-indent:2em'>（1）、经甲方自行维修或非经乙方专业维修人员维修的；</li><li style='margin-top:10px;text-indent:2em'>（2）、由其他外力造成的损坏；  </li><li style='margin-top:10px;text-indent:2em'>（3）、产品实际型号与销售订单不符。</li><li style='margin-top:10px'> 八、订货须知</li><li style='margin-top:10px;text-indent:2em'>（一）、由于本产品是乙方根据甲方的特殊要求量身定做，无互换性。本定单一经签订，甲、乙双方任何一方不可以单方解除本定单，特殊情况除外，但要承担相应损失。</li><li style='margin-top:10px;text-indent:2em'>（二）、测量数据及型号等有关信息资料须经甲、乙双方认真核对，在确认无误后方可签订本定单。如甲方需要更改数据或变更相关信息，必须与乙方协商，在双方达成一致意见后方可做相应的变更。</li><li style='margin-top:10px;text-indent:2em'>（三）、乙方测量师是根据现有洞口进行测量量尺，甲方如有特殊要求，须注明否则出现损失乙方概不负责。</li><li style='margin-top:10px;text-indent:2em'>（四）、本产品采用的艺术玻璃的图案比例，人工色差与样品有差别属正常现象，不属于可以更换、重做的质量问题。</li><li style='margin-top:10px;text-indent:2em'>（五）、安装完毕后，请甲方检查门的外观质量后方可在安装任务单上签字，如后期出现表面划伤和磕碰问题，乙方概不负责。</li><li style='margin-top:10px;text-indent:2em'>（六）、甲方须在认真阅读本定单的条款并接受本定单条款约定的情况下，方可签订本定单，否则后果自负。</li><li style='margin-top:10px'>九、其他约定事项</li><li style='margin-top:10px;text-indent:2em'>（一）、本定单一式叁份，肆份均具有等同的法律效力。</li><li style='margin-top:10px;text-indent:2em'>（二）、本定单一经甲、乙双方签字或盖章即时发生效力。</li><li style='margin-top:10px;text-indent:2em'>（三）、甲、乙双方如有争议应协商解决，协商不成时，可以提交仲裁裁决或通过乙方所在地法院诉讼解决。</li><li style='margin-top:40px'>甲方（需方）：&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;乙方（经销商）：</li><li style='margin-top:40px'>年 月 日 <span style='font-size:14px;font-family:等线'>&nbsp;</span><span style='font-size:14px;font-family:等线'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; </span>  年  月  日</li></ul></div>"
    var bstr = "<div style='width:690px; list-style:none;margin-left:-20px' class='customtable'><ul style='list-style:none'> <table align='center' width='100%' border='1'><tbody><tr class='firstRow'><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>序号</td><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>安装<br/>位置 </td><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>产品<br/> 名称</td><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>型号</td><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>表面<br/>饰面</td><td width='55' colspan='1' rowspan='2' align='center' valign='middle'>玻璃<br/>型号</td> <td width='55' colspan='1' rowspan='2' align='center' valign='middle'>玻璃<br/> 安装</td><td width='56' colspan='1' rowspan='2' align='center' valign='middle' >单位</td><td width='56' colspan='1' rowspan='2' align='center' valign='middle'>数量</td><td width='67' colspan='1' rowspan='2' align='center' valign='middle'>单价</td><td colspan='8' rowspan='1' align='center' valign='middle'>金额</td></tr><tr><td width='10'  align='left' valign='middle'><span style='font-size: 10px;'>十</span></td><td width='10'  align='center' valign='middle'><span style='font-size: 10px;'>万</span></td><td width='10'  align='center' valign='middle'><span style='font-size: 10px;'>仟</span></td><td width='10'  align='center' valign='middle'><span style='font-size: 10px;'>百</span> </td><td width='10'  align='center' valign='middle'><span style='font-size: 10px;'>十</span></td><td width='10' align='center' valign='middle'><span style='font-size: 10px;'>元</span></td><td width='10'align='center' valign='middle'><span style='font-size: 10px;'>角</span></td><td width='10'  align='center' valign='middle'><span style='font-size: 10px;'>分</span></td></tr>" + tbstr + "</tbody></table></li></ul></div>"
    var vstr = "<div style='width:690px; list-style:none;margin-left:-20px'><ul style='width:690px; list-style:none;margin-left:-40px'><li style='text-indent:2em; text-align:center; font-size:20px;font-weight:bolder'>定单填写说明 </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>为强化合同管理，保护甲、乙双方的合法权益，根据《中华人民共和国消费者权益保护法》和《中华人民共和国合同法》及其它相关规定，对定单填写做如下说明：</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>一、甲方信息：按甲方提供的详细信息填写。甲方应填写购买产品的单位或个人；详细地址为产品的安装地址填写，即<u> </u>区<u>  </u>路<u>  </u>小区<u>  </u>号楼<u>  </u>单元<u>  </u>室；联系电话为甲方的移动电话与固定电话；传真为甲方的传真号码</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>二、乙方信息：按乙方详细的经销地址填写。</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>三、产品信息 </li> <li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(一)、安装位置：按测量单上测量人员填写的具体安装位置顺序填写，如：主卧、主卫、次卧、次卫、客厅、客卫、书房、厨房、储藏室、阳台等。  </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(二)、产品名称：按产品的系列名称填写，如标准门、特型门、乡村系列门、西克纳姆门、苏埃诺门、全玻璃门、风挡门、门套、窗套、锁具等。 </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(三)、型号：按产品价格手册产品所对应的型号填写或填写锁具的型号</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(四)、表面饰面：按照产品的花色编码说明填写； </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(五)、玻璃型号：按照产品的玻璃编码说明填写；</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(六)、计量单位：门的计量单位为樘；垭口套、窗套的计量单位为米；锁具的计量单位为套； </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(七)、数量：按甲方实际定制的数量填写；</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(八)、单价：按产品报价手册产品对应的价格填写或填写经过计算的产品价格；</li> <li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(九)、金额：按销售数量乘以单价后所得出的数值填写，适用四舍五入规则；</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>(十)、合计金额大小写金额必须保持一致；</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'> 四、测量单号：按甲方提供的测量单号填写。</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>五、交货日期：按规定的交货期限填写。  </li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'> 六、付款方式：预付货款按规定的比例填写。</li><li style='text-indent:2em; text-align:left; margin-top:10px; line-height:25px'>七、本定单须经甲、乙双方签字确认后，即发生效力。 </li><li style='text-indent:2em; text-align:center; margin-top:50px; line-height:25px'>售后服务热线：4001-888-600</li><li style='text-indent:2em; text-align:center; margin-top:10px; line-height:25px'> 网址：http：//www.holzer.com.cn  </li><li style='text-indent:2em; text-align:center; margin-top:10px; line-height:25px'>Email:holzer@holzer.com.cn</li></ul></div>";
    var str = "<div><div id='pageone' style='list-style:none'> <img src='http://39.100.109.37/Image/System/hto4.png'></div><div style='page-break-after:always;'></div> <div id='pagetwo'>" + tstr + " </div><div style='page-break-after:always;'></div> <div id='pagethree'>" + sstr + "</div><div style='page-break-after:always;'></div> <div id='pagefour'>" + bstr + "</div><div id='pagefive'>" + vstr + "</div></div>";
    ds.pstr.setHtml(str)
}
function QueryHtProduction() {
    var o = { "sid": sid,"ttype":"gh" }
    var url = "../../../UIServer/CommonFile/CommonTempProduction.aspx/HtProductionPriceDetail"
    var b = AjaxExb(url, o)
    return b;
}
function QueryHtOrder() {
    var o = { "sid": sid }
    var url ="../../../UIServer/SalesBusiness/DistributorDoorOrder/SaleOrderDetail.aspx/QueryOrder"
    var b = AjaxExb(url, o);
    var r = BackVad(b, "", false)
    if (r) {
        htjf = r.customer;
        htyf = r.dname;
        jfdz = r.address;
        yfdz = "";
        jfdh = r.telephone;
        yfdh = r.stelephone;
    }
}
                