using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.StatisticsInfo;
using System.Collections;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    //导出订单列表信息
    //1、木门订单列表
    //2、木作订单列表
    //3、反馈订单列表
    //处理过程为列表页面点击【导出】--》
    //获取相应Tab和查询条件--》
    //后台获取对应标题--》
    //获取类别页<thead>列--》
    //获取表格数据记录--》
    //生成<trow>--》
    //生成表格Html
    public partial class ExportOrder : System.Web.UI.Page
    {
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static BusiExportBll beb = new BusiExportBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string ExportSaleOrder(string bdate, string city, string code, string customer, string dname, string edate, string emcode,string otype, string tabcode)
        {
            string r = "";
            DataTable lsr = new DataTable();
            ArrayList row = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (customer != "")
                {
                    where.AppendFormat(" and customer like '%{0}%'", customer);
                }
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (city != "")
                {
                    where.AppendFormat(" and e_city like '%{0}%'", city);
                }
                if (dname != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", dname);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr=tsb.QueryList(svt.tname, svt.esqlcols, svt.sqlcondition, " order by id desc");
                    if (lsr != null)
                    {
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                
                                if (column.Caption == "zt")
                                {
                                    al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
                                }
                                else
                                {
                                    if (column.Caption == "sid")
                                    {
                                    }
                                    else
                                    {
                                        al.Add(dr[column].ToString());
                                    }
                                }
                            }
                            row.Add(al);
                        }
                    }
                }
                r = beb.ExportHtm(otype, svt.ecols, row);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
    }
}