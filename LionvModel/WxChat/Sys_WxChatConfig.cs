using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.WxChat
{
   public class Sys_WxChatConfig
    {
        #region Model
        private int _id;
        private string _acode;
        private string _appid = "";
        private string _appsec = "";
        private string _aurl = "";
        private string _cdate;
        private string _maker = "";
        private string _ewmimg = "";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appid
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appsec
        {
            set { _appsec = value; }
            get { return _appsec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aurl
        {
            set { _aurl = value; }
            get { return _aurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ewmimg
        {
            set { _ewmimg = value; }
            get { return _ewmimg; }
        }
        #endregion Model
    }
}
