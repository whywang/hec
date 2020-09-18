using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_TempUpFile
    {
        private int _id;
        private string _sid;
        private string _fname;
        private string _fpname;
        private string _furl;
        private int _fsize = 0;
        private int _fover = 0;
        private string _fdate = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fpname
        {
            set { _fpname = value; }
            get { return _fpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string furl
        {
            set { _furl = value; }
            get { return _furl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fsize
        {
            set { _fsize = value; }
            get { return _fsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fover
        {
            set { _fover = value; }
            get { return _fover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fdate
        {
            set { _fdate = value; }
            get { return _fdate; }
        }

    }
}
