using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using LionvBll.WxChat;
using LionvModel.WxChat;

namespace LionVERP.UIServer.WxChatBusiness
{
    public partial class ParseWeChat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = "";
            string eno = "";
            string opid = "";
            string b = "F";
            Sys_EmplyeeFouseWxBll sb = new Sys_EmplyeeFouseWxBll();
            if (Request.QueryString["code"] != null)
            {
                code = Request.QueryString["code"].ToString();
            }
            if (Request.QueryString["response_type"] != null)
            {
                eno = Request.QueryString["response_type"].ToString();
            }
            if (code != "" && eno != "")
            {
                opid = GetOpenid(code);
                if (opid != "")
                {
                    Sys_EmplyeeFouseWx sw=new Sys_EmplyeeFouseWx ();
                    sw.openid=opid;
                    sw.ename=eno;
                    if (sb.Add(sw) > 0)
                    {
                        b = "S";
                    }
                }
            }
            if (b == "S")
            {
            }
            else
            {
            }
        }
        public string  GetOpenid(string code)
        {
            string url = "";
            Sys_WxChatConfigBll swccb = new Sys_WxChatConfigBll();
            Sys_WxChatConfig wc = swccb.Query(" and acode='0001'");
            string getAccessTokenUrl = " https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            string respText = "";
            if (wc != null)
            {
                url = string.Format(getAccessTokenUrl, wc.appid, wc.appsec, code);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream resStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(resStream, Encoding.Default);
                    respText = reader.ReadToEnd();
                    resStream.Close();
                }
                int start = respText.IndexOf("openid");
                int end = respText.IndexOf("scope");
                start += 15;
                end -= 3;
                respText = respText.Substring(start, end - start);
            }
            else
            {
                respText = "";
            }
            return respText;
        }
    }
}