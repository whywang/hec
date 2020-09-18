using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_Message
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _rcode = "";
        private string _ename = "";
        private string _url = "";
        private string _ozt = "";
        private string _vtext = "";
        private string _dcode = "";
        private string _ndate;
        private int _dstate = 0;
        private string _dmaker = "";
        private string _ddate;
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
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ozt
        {
            set { _ozt = value; }
            get { return _ozt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vtext
        {
            set { _vtext = value; }
            get { return _vtext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ndate
        {
            set { _ndate = value; }
            get { return _ndate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int dstate
        {
            set { _dstate = value; }
            get { return _dstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmaker
        {
            set { _dmaker = value; }
            get { return _dmaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddate
        {
            set { _ddate = value; }
            get { return _ddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model

    }
}
