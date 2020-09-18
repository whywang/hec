using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionvCommonBll
{
   public class BusiOrderStateBll
    {
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        private BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private Sys_DomainBll sdb = new Sys_DomainBll();
        #region//订单状态
        public string QueryOrderStateImg(string sid)
        {
            string r = "";
            Sys_Domain sd = sdb.Query(" and dtype='p'");
            CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
            if (cos != null)
            {
                r = sd.url + "/Image/custome/nomal.png";
                if (cos.ifast > 1)
                {
                    r = sd.url + "/Image/custome/fast.png";
                }
                if (cos.istop > 1)
                {
                    r = sd.url + "/Image/custome/stop.png";
                }
                if (cos.ichange > 1)
                {
                    r = sd.url + "/Image/custome/change.png";
                }
                if (cos.iover > 1)
                {
                    r = sd.url + "/Image/custome/canel.png";
                }

            }
            return r;
        }
        #endregion
        #region//生产状态
        public string QueryOrderProduceState(string sid)
        {
            string r = "";
            CB_OrderState cos = cosb.Query(" and sid='" + sid + "' and ifactorydeliver>0");
            if (cos != null)
            {
                r = "申请入库";
            }
            else
            {
                CB_OrderFlow fdf = bwfb.QueryAttrExWorkFlow(sid, "fd");
                CB_OrderFlow scf = bwfb.QueryAttrExWorkFlow(sid, "sc");
                if (scf != null)
                {
                    r = scf.wname;
                }
                else
                {
                    if (fdf != null)
                    {
                        r = fdf.wname;
                    }
                    else
                    {
                        r = "未分厂";
                    }
                }
            }
            return r;
        }
        #endregion
    }
}
