﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.BusiCommon;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiCommon;
using ViewModel.BusiOrderInfo;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class InHouseDetail : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private static B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static B_InHouseRecordBll bohrb = new B_InHouseRecordBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 入库单信息
        [WebMethod(true)]
        public static string InHouseOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VInHouseOrder vpo = new VInHouseOrder();
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
                int bnum = bohrb.GetRecordCount(" sid='"+sid+"'");
                string zt = "";
                if (cos != null)
                {
                    if (cos.istoreget == 0)
                    {
                        zt = "未入库";
                    }
                    if (cos.istoreget == 1)
                    {
                        zt = "部分入库";
                    }
                    if (cos.istoreget == 2)
                    {
                        zt = "全部入库";
                    }
                }
                vpo.code = bso.scode;
                vpo.ycode = bso.oscode;
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