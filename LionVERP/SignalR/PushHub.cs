using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using Owin;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using System.Web.Script.Serialization;

namespace LionVERP.SignalR
{
    [HubName("pushHub")]
    public class PushHub : Hub
    {
        CB_MessageBll cmb = new CB_MessageBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        public void SendMessage()
        {
            string jsstr = "";
            CB_Message cm= new CB_Message();
            List<CB_Message> lcm = cmb.QueryList("and dstate=0 order by id asc");
            if (lcm == null)
            {
                jsstr = js.Serialize(cm);
            }
            else
            {
                jsstr = js.Serialize(lcm);
            }
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<PushHub>();
            hubContext.Clients.All.addNewMessageToPage(jsstr);
        }
        public void Init() {
        }
    }
}