using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvCommon;
using MongoDB.Driver;
using LionvMgModel;
using LionvBll.BusiMgOrderInfo;
using LionvCommonBll;
using LionVERP.SignalR;
using Microsoft.AspNet.SignalR;
using System.Text;
using System.Net;
using System.IO;

namespace LionVERP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        QrCodeBll qcb = new QrCodeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sfstr = "Math.Ceiling((double)200/(double)1220)";
            ComputeFunction cf = new ComputeFunction(Type.GetType("System.Double"), sfstr, "EvaluateDouble");
            double r = (double)cf.EvaluateDouble("EvaluateDouble");
            string ddd = Math.Ceiling((double)(200 / 1220)).ToString();
            double dd = (double)(200.00 / 1220.00);
            Response.Write( r+"d"+ddd+""+dd.ToString());
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
              string iurl=qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/ImageMeasure/"), "http://www.baidu.com?sid=111111111111111111111111");
              Response.Write("<img src='" + CommonBll.GetHost() + "/UpFile/ImageMeasure/" + iurl + "' alt=''/> ");
        }
        //#region
        ///// <summary> 
        ///// 请求Url，发送json数据 
        ///// </summary> 
        //public static string PostUrl(string url, string postData)
        //{
        //    byte[] data = Encoding.UTF8.GetBytes(postData);

        //    // 设置参数 
        //    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        //    CookieContainer cookieContainer = new CookieContainer();
        //    request.CookieContainer = cookieContainer;
        //    request.AllowAutoRedirect = true;
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = data.Length;
        //    Stream outstream = request.GetRequestStream();
        //    outstream.Write(data, 0, data.Length);
        //    outstream.Close();

        //    //发送请求并获取相应回应数据 
        //    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //    //直到request.GetResponse()程序才开始向目标网页发送Post请求 
        //    Stream instream = response.GetResponseStream();
        //    StreamReader sr = new StreamReader(instream, Encoding.UTF8);
        //    //返回结果网页（html）代码 
        //    string content = sr.ReadToEnd();
        //    return content;
        //}

        ///// <summary>
        ///// 获取密钥
        ///// </summary>
        ///// <param name="corpid">appID</param>
        ///// <param name="corpsecret">secID</param>
        ///// <returns></returns>
        //public  string GetQYAccessToken(string corpid, string corpsecret)
        //{
        //    string getAccessTokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        //    string accessToken = "";
        //    string respText = "";

        //    //获取josn数据
        //    string url = string.Format(getAccessTokenUrl, corpid, corpsecret);

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    using (Stream resStream = response.GetResponseStream())
        //    {
        //        StreamReader reader = new StreamReader(resStream, Encoding.Default);
        //        respText = reader.ReadToEnd();
        //        resStream.Close();
        //    }

        //    try
        //    {
        //        int start = respText.IndexOf("access_token");
        //        int end = respText.IndexOf("expires_in");
        //        start += 15;
        //        end -= 3;
        //        respText = respText.Substring(start, end - start);

        //        //通过键access_token获取值
        //        accessToken = respText;
        //    }
        //    catch  { }

        //    return accessToken;
        //}

        ///// <summary>
        ///// 填充数据后返回json字符串
        ///// </summary>
        ///// <param name="touser"></param>
        ///// <param name="tmpid"></param>
        ///// <param name="title"></param>
        ///// <returns></returns>
        //public  string FillData(string touser, string tmpid, string title)
        //{
        //    string responeJsonStr = "{";
        //    responeJsonStr += "\"touser\": \"" + touser + "\",";
        //    responeJsonStr += "\"template_id\": \"" + tmpid + "\",";
        //    responeJsonStr += "\"url\": \"\",";
        //    responeJsonStr += "\"topcolor\": \"#FF0000\",";
        //    responeJsonStr += "  \"data\": {";
        //    responeJsonStr += "  \"first\": {\"value\":\"" + title + "\",\"color\":\"#FF0000\"},";
        //    responeJsonStr += "  \"name\": {\"value\":\"用户你好\",\"color\":\"#FF0000\"},";
        //    responeJsonStr += "  \"user\": {\"value\":\"感谢你的支持\",\"color\":\"#FF0000\"}";
        //    responeJsonStr += "}";
        //    responeJsonStr += "}";
        //    return responeJsonStr;
        //}

        ///// <summary>
        ///// 发送微信消息
        ///// </summary>
        ///// <param name="user">用户</param>
        ///// <param name="title">标题</param>
        //public void SendWXmessage(string title)
        //{
        //    string mytoken = GetQYAccessToken("wxc85a9d2685790012", "d9a42fbbfb2da494ad34bc3f74c30410");
        //   string w= PostUrl(string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", mytoken), FillData("okF181PwzJepmVGaDPdyKZkbkGSE", "ngqIpbwh8bUfcSsECmogfXcV14J0tQlEpBO27izEYtY", title));
        //   Response.Write(w);
        //}
        //#endregion

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    SendWXmessage("标题1111");
        //}
    }
}