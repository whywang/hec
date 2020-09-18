using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvCommon
{
   public class BroadMessage
    {
        private string _rcode = "";

        public string rcode
        {
            get { return _rcode; }
            set { _rcode = value; }
        }
        private string _uname = "";

        public string uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        private string _url = "";

        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _zt = "";

        public string zt
        {
            get { return _zt; }
            set { _zt = value; }
        }
        private string _vtext = "";

        public string vtext
        {
            get { return _vtext; }
            set { _vtext = value; }
        }
    }
}
