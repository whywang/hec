﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using ViewModel.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorAfterYqDoorOrder
{
    public partial class AfterOutHouseDetail : System.Web.UI.Page
    {
        private static B_YqAfterSaleOrderBll bsob = new B_YqAfterSaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static B_OutHouseRecordBll bohrb = new B_OutHouseRecordBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 发货单信息
        [WebMethod(true)]
        public static string OutnHouseOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VInHouseOrder vpo = new VInHouseOrder();
                B_YqAfterSaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
                int bnum = bohrb.GetRecordCount(" sid='" + sid + "'");
                string zt = "";
                if (cos != null)
                {
                    if (cos.istoredeliver == 0)
                    {
                        zt = "未发库";
                    }
                    if (cos.istoredeliver == 1)
                    {
                        zt = "部分发库";
                    }
                    if (cos.istoredeliver == 2)
                    {
                        zt = "全部发库";
                    }
                }
                vpo.code = bso.fcode;
                vpo.ycode = bso.scode;
                vpo.customer = bso.customer;
                vpo.address = bso.address;
                vpo.dname = bso.dname;
                vpo.fname = bof == null ? "" : bof.dname;
                vpo.bz = bso.remark;
                vpo.city = bso.city;
                vpo.telephone = bso.telephone;
                vpo.bnum = bnum.ToString();
                vpo.zt = zt;
                r = js.Serialize(vpo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}