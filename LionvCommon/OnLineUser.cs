using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvCommon
{
   public class OnLineUser
    {
        private Guid gid;

        public Guid Gid
        {
            get { return gid; }
            set { gid = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int zt;

        public int Zt
        {
            get { return zt; }
            set { zt = value; }
        }
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string timestamp;

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
    }
}
