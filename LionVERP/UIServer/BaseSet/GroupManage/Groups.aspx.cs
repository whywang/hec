using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;
using System.Data;

namespace LionVERP.UIServer.BaseSet.GroupManage
{
    public partial class Groups : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化权限组
        [WebMethod(true)]
        public static string InitGroup(string gcode)
        {
            string r = "";
            Sys_Group sg = new Sys_Group();
            Sys_GroupBll sdb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Group csg = sdb.Query(" and gcode='" + gcode + "'");
                if (csg != null)
                {
                    r = js.Serialize(csg);
                }
                else
                {
                    sg.gname = "";
                    sg.gcode = sdb.CreateCode().ToString().PadLeft(4, '0');
                    sg.id = 0;
                    r = js.Serialize(sg);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存权限组
        [WebMethod(true)]
        public static string SaveGroup(string gcode, string gid, string gname, string gremake)
        {
            string r = "";
            Sys_Group sg = new Sys_Group();
            Sys_GroupBll sgb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sg.gcode = gcode;
                sg.gname = gname;
                sg.gdetail = gremake;
                if (gid == "0")
                {
                    if (sgb.Add(sg) > 0)
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    if (sgb.Update(sg))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  获取权限组
        [WebMethod(true)]
        public static ArrayList QueryGroupList()
        {
            ArrayList r = new ArrayList();
            Sys_Group sd = new Sys_Group();
            Sys_GroupBll sdb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Group> ls = sdb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_Group s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.gcode);
                        al.Add(s.gname);
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
        #region///  删除权限组
        [WebMethod(true)]
        public static string DelSysGroup(string gcode)
        {
            string r = "";
            Sys_GroupBll sdb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (sdb.Delete(gcode))
                {
                    r = "S";
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

        #region///  设置组账号
        [WebMethod(true)]
        public static string SetGroupAccount(string gcode, string accountlist)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            ArrayList al = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sgb.DelGroupAccount(gcode);
                string[] alarr = accountlist.Split(';');
 
                if (alarr.Length > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("gcode", typeof(string)));
                    dt.Columns.Add(new DataColumn("uname", typeof(string)));
                    for (int i = 0; i < alarr.Length; i++)
                    {
                        dt.Rows.Add(new object[] { gcode,alarr[i]  });
                    }
                    if (sgb.SetGroupAccount(dt) > 0)
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
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
        #region///  重置组账号
        [WebMethod(true)]
        public static string ReSetGroupAccount(string gcode)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgb.DelGroupAccount(gcode) > 0)
                {
                    r = "S";
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
        #region///  获取组账号
        [WebMethod(true)]
        public static string GetGroupAccount(string gcode)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sgb.GetGroupAccount(gcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region///  设置组菜单
        [WebMethod(true)]
        public static string SetGroupMenu(string gcode, string menulist)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            ArrayList al = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sgb.DelGroupMenu(gcode);
                string[] mlarr = menulist.Split(';');
                for (int i = 0; i < mlarr.Length; i++)
                {
                    int arrstr = mlarr[i].Length;
                    int arrstrlen = arrstr / 2;
                    if (arrstrlen >= 1)
                    {
                        for (int k = 1; k <= arrstrlen; k++)
                        {
                            string leftcode = mlarr[i].Substring(0, k * 2);
                            if (!al.Contains(leftcode))
                            {
                                al.Add(leftcode);
                            }
                        }
                    }
                }
                if (al.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("gcode", typeof(string)));
                    dt.Columns.Add(new DataColumn("mcode", typeof(string)));
                    
                    for (int i = 0; i < al.Count; i++)
                    {
                        dt.Rows.Add(new object[] {  gcode ,al[i]});
                    }
                    if (sgb.SetGroupMenu(dt) > 0)
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
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
        #region///  重置组菜单
        [WebMethod(true)]
        public static string ReSetGroupMenu(string gcode)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgb.DelGroupMenu(gcode) > 0)
                {
                    r = "S";
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
        #region///  获取组菜单
        [WebMethod(true)]
        public static string GetGroupMenu(string gcode)
        {
            string r = "";
            Sys_GroupBll sgb = new Sys_GroupBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sgb.GetGroupMenu(gcode);
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