using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvIDal.SysInfo;
using LionvFactoryDal;

namespace LionvBll.SysInfo
{
   public class Sys_DepmentBll
    {
       private ISys_DepmentDal r = DataAccess.CreateSys_Depment();
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
       public bool Exists(string where)
       {
           return r.Exists(where);
       }
        /// <summary>
        /// 增加一条数据
        /// </summary>
       public int Add(Sys_Depment model)
       {
           return r.Add(model);
       }
        /// <summary>
        /// 更新一条数据
        /// </summary>
       public bool Update(Sys_Depment model)
       {
           return r.Update(model);
       }
        /// <summary>
        /// 删除一条数据
        /// </summary>
       public bool Delete(string dcode)
       {
           return r.Delete(dcode);
       }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public Sys_Depment Query(string where)
       {
           return r.Query(where);
       }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Sys_Depment> QueryList(string where)
       {
           return r.QueryList(where);
       }

        #endregion  成员方法
        #region  MethodEx
        public int CreateCode(string pdepcode)
        {
            return r.CreateCode(pdepcode);
        }
        //开通门厂或门店时增加子部门
        public int AddDepWithChildDep(Sys_Depment model)
        {
            int b=r.Add(model);
           // AddChildDep(model);
            return b;
        }
        private void AddChildDep(Sys_Depment model)
        {
            if (model.dattr == "md" || model.dattr == "mc")
            {
                if (model.dcdep != "")
                {
                    List<Sys_Depment> lsd = new List<Sys_Depment>();
                    string[] cdepAbsArr = model.dcdep.Split(';');
                    for (int i = 0; i < cdepAbsArr.Length; i++)
                    {
                        Sys_Depment sd = new Sys_Depment();
                        Sys_Depment prodep = new Sys_Depment();
                        Sys_Depment citdep = new Sys_Depment();
                        Sys_Depment shodep = new Sys_Depment();
                        Sys_Depment gcdep = new Sys_Depment();
                        Sys_Depment cpdep = new Sys_Depment();
                        Sys_Depment cldep = new Sys_Depment();
                        #region
                        switch (cdepAbsArr[i])
                        {
                            case "zb":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "zb";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0001";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "总办";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                break;
                            case "dq":
                                #region
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "dq";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0002";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "销售渠道";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                prodep.cdate = DateTime.Now.ToString();
                                prodep.dattr = "pv";
                                prodep.dcdate = sd.dcdate;
                                prodep.dcdep = "";
                                prodep.dcode = sd.dcode + "0001";
                                prodep.disend = true;
                                prodep.disused = true;
                                prodep.dmaker = "";
                                prodep.dname = "默认省";
                                prodep.dpcode = sd.dcode;
                                prodep.dpname = sd.dname;
                                prodep.maker = sd.maker;
                                prodep.dread = true;
                                lsd.Add(prodep);
                                citdep.cdate = DateTime.Now.ToString();
                                citdep.dattr = "s";
                                citdep.dcdate = prodep.dcdate;
                                citdep.dcdep = "";
                                citdep.dcode = prodep.dcode + "0001";
                                citdep.disend = true;
                                citdep.disused = true;
                                citdep.dmaker = "";
                                citdep.dname = "默认市";
                                citdep.dpcode = prodep.dcode;
                                citdep.dpname = prodep.dname;
                                citdep.maker = prodep.maker;
                                citdep.dread = true;
                                lsd.Add(citdep);
                                shodep.cdate = DateTime.Now.ToString();
                                shodep.dattr = "d";
                                shodep.dcdate = citdep.dcdate;
                                shodep.dcdep = "";
                                shodep.dcode = citdep.dcode + "0001";
                                shodep.disend = true;
                                shodep.disused = true;
                                shodep.dmaker = "";
                                shodep.dname = "默认店";
                                shodep.dpcode = citdep.dcode;
                                shodep.dpname = citdep.dname;
                                shodep.maker = citdep.maker;
                                shodep.dread = true;
                                lsd.Add(shodep);
                                #endregion
                                break;
                            case "dd":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "dd";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0003";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "订单部";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                break;
                            case "cw":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "cw";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0004";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "财务部";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                break;
                            case "sc":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "sc";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0005";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "生产部";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                break;
                            case "gc":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "gc";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0006";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "工厂";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                gcdep.cdate = DateTime.Now.ToString();
                                gcdep.dattr = "g";
                                gcdep.dcdate = sd.dcdate;
                                gcdep.dcdep = "";
                                gcdep.dcode = sd.dcode + "0001";
                                gcdep.disend = true;
                                gcdep.disused = true;
                                gcdep.dmaker = "";
                                gcdep.dname = "默认厂";
                                gcdep.dpcode = sd.dcode;
                                gcdep.dpname = sd.dname;
                                gcdep.maker = sd.maker;
                                gcdep.dread = true;
                                lsd.Add(gcdep);
                                break;
                            case "kf":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "kf";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0007";
                                sd.disend = false;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "库房";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                cpdep.cdate = DateTime.Now.ToString();
                                cpdep.dattr = "ck";
                                cpdep.dcdate = sd.dcdate;
                                cpdep.dcdep = "";
                                cpdep.dcode = sd.dcode + "0001";
                                cpdep.disend = true;
                                cpdep.disused = true;
                                cpdep.dmaker = "";
                                cpdep.dname = "默认成品库";
                                cpdep.dpcode = sd.dcode;
                                cpdep.dpname = sd.dname;
                                cpdep.maker = sd.maker;
                                cpdep.dread = true;
                                lsd.Add(cpdep);
                                cldep.cdate = DateTime.Now.ToString();
                                cldep.dattr = "mk";
                                cldep.dcdate = sd.dcdate;
                                cldep.dcdep = "";
                                cldep.dcode = sd.dcode + "0002";
                                cldep.disend = true;
                                cldep.disused = true;
                                cldep.dmaker = "";
                                cldep.dname = "默认材料库";
                                cldep.dpcode = sd.dcode;
                                cldep.dpname = sd.dname;
                                cldep.maker = sd.maker;
                                cldep.dread = true;
                                lsd.Add(cldep);
                                break;
                            case "cg":
                                sd.cdate = DateTime.Now.ToString();
                                sd.dattr = "cg";
                                sd.dcdate = model.dcdate;
                                sd.dcdep = "";
                                sd.dcode = model.dcode + "0008";
                                sd.disend = true;
                                sd.disused = true;
                                sd.dmaker = "";
                                sd.dname = "采购部";
                                sd.dpcode = model.dcode;
                                sd.dpname = model.dname;
                                sd.maker = model.maker;
                                sd.dread = true;
                                lsd.Add(sd);
                                break;
                        }
                        #endregion
                    }
                    if (lsd.Count > 0)
                    {
                        foreach (Sys_Depment d in lsd)
                        {
                            r.Add(d);
                        }
                    }
                }
            }
        }

        public bool SetProxyCity(string dcode, string ccode)
        {
            return r.SetProxyCity(dcode, ccode);
        }
        public bool ReSetProxyCity(string dcode)
        {
            return r.ReSetProxyCity(dcode);
        }
        public string GetProxyCity(string dcode)
        {
            return r.GetProxyCity(dcode);
        }
        #endregion  MethodEx
    }
}
