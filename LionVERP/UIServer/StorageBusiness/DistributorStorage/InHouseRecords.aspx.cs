using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class InHouseRecords : System.Web.UI.Page
    {
        private static B_InHouseRecordBll bohrb = new B_InHouseRecordBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 保存入库记录信息
        [WebMethod(true)]
        public static string SaveInHouseRecord(string ibz, string icode, string idate, string inum, string iperson,string itype, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_InHouseRecord bihr = new B_InHouseRecord();
                bihr.bnum = Convert.ToInt32(inum);
                bihr.ccode = icode;
                bihr.cdate = DateTime.Now.ToString();
                bihr.maker = iv.u.ename;
                bihr.rdate = idate;
                bihr.remarke = ibz;
                bihr.rperson = iperson;
                bihr.sid = sid;
                if (bohrb.Add(bihr) > 0)
                {
                    r = "S";
                    if (itype == "1")
                    {
                        cbsb.UpState(sid, "istoreget", 1);
                    }
                    if (itype == "2")
                    {
                        cbsb.UpState(sid, "istoreget", 2);
                        cbsb.UpState(sid, "ifactorydeliver", 2);
                    }
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 入库记录信息
        [WebMethod(true)]
        public static ArrayList QueryInHouseRecord( string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_InHouseRecord> lb = bohrb.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    foreach (B_InHouseRecord p in lb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(p.id);
                        al.Add(p.ccode);
                        al.Add(p.bnum);
                        al.Add(p.rperson);
                        al.Add(p.rdate);
                        al.Add(p.remarke);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
    }
}