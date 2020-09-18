using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvCommonBll
{
    public class BusiProduceCycBll
    {
        private Sys_ProduceCycBll dal = new Sys_ProduceCycBll();
        private BusiEventButtonBll bebb = new BusiEventButtonBll();
        private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        #region//<OutTime>获取生产周期 
        public List<Sys_ProduceCyc> QueryCheckList(string strWhere)
        {
            List<Sys_ProduceCyc> r = new List<Sys_ProduceCyc>();
            List<Sys_ProduceCyc> c = new List<Sys_ProduceCyc>();
            c = dal.QueryList(strWhere);
            if (c != null)
            {
                foreach (Sys_ProduceCyc spc in c)
                {
                    if (spc.csql != "")
                    {
                        if (bebb.CheckBtnSql(spc.csql))
                        {
                            r.Add(spc);
                        }
                    }
                    else
                    {
                        r.Add(spc);
                    }
                }
            }
            else
            {
                r = null;
            }
            return r;
        }
        #endregion
        #region//获取生产周期
        public Sys_ProduceCyc QueryCheckList(string dcode,string sid)
        {
            string emcode = "";
            Sys_ProduceCyc r = new Sys_ProduceCyc();
            CB_OrderFlow cof=cofb.Query(" and sid='" + sid + "' and wtype=''");
            emcode = cof != null ? cof.emcode : "";
            List<Sys_ProduceCyc>c = dal.QueryList(" and fcode='"+dcode+"' and otype='n' and emcode='"+emcode+"' and csql<>''");
            if (c != null)
            {
                foreach (Sys_ProduceCyc spc in c)
                {
                    if (spc.csql != "")
                    {
                        if (bebb.CheckBtnSql(spc.csql))
                        {
                            r=spc;
                        }
                        break;
                    }
                }
            }
            else
            {
                 r = dal.Query(" and fcode='"+dcode+"' and otype='n' and emcode='"+emcode+"' and csql=''");
            }
            return r;
        }
        #endregion
        #region//获取生产周期
        public Sys_ProduceCyc QueryCheckList(string bdcode, string fcode, string sid)
        {
            string emcode = "";
            string ztf = "n";
            Sys_ProduceCyc r = new Sys_ProduceCyc();
            CB_OrderFlow cof = cofb.Query(" and sid='" + sid + "' and wtype=''");
            CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
            if (cos != null)
            {
                if (cos.ifast > 0)
                {
                    ztf = "f";
                }
            }
            emcode = cof != null ? cof.emcode : "";
            List<Sys_ProduceCyc> c = dal.QueryList(" and bdcode='" + bdcode + "' and fcode='" + fcode + "' and otype='" + ztf + "' and emcode='" + emcode + "' and csql<>''");
            if (c != null)
            {
                foreach (Sys_ProduceCyc spc in c)
                {
                    if (spc.csql != "")
                    {
                        if (bebb.CheckBtnSql(spc.csql))
                        {
                            r = spc;
                        }
                        break;
                    }
                }
            }
            else
            {
                r = dal.Query(" and bdcode='" + bdcode + "' and fcode='" + fcode + "' and otype='" + ztf + "' and emcode='" + emcode + "' and csql=''");
            }
            return r;
        }
        #endregion
    }
}
