using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_Button
    {
        public Sys_Button()
        { }
        #region Model
        private int _id;
        private string _bname = "";
        private string _bcode;
        private string _babc = "";
        private string _emcode = "";
        private string _emname = "";
        private string _remcode = "";
        private string _wname = "";
        private string _wcode = "";
        private string _rwcode = "";
        private string _btype = "";
        private string _bstyle = "";
        private string _battr = "";
        private int _bstate = 0;
        private bool _bcheck = false;
        private bool _bshow = false;
        private string _burl = "";
        private string _bfn = "";
        private string _bsql = "";
        private string _brname = "";
        private string _brcode = "";
        private int _bspeattr = 0;
        private int _bsort = 0;
        private bool _biszt = false;
        private string _bproname = "";
        private string _bprocedure = "";
        private int _btip = 0;
        private string _bremark = "";
        private string _btab = "";
        private string _bico = "";

        
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
        public string bname
        {
            set { _bname = value; }
            get { return _bname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bcode
        {
            set { _bcode = value; }
            get { return _bcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string babc
        {
            set { _babc = value; }
            get { return _babc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remcode
        {
            set { _remcode = value; }
            get { return _remcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wname
        {
            set { _wname = value; }
            get { return _wname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rwcode
        {
            set { _rwcode = value; }
            get { return _rwcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string btype
        {
            set { _btype = value; }
            get { return _btype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bstyle
        {
            set { _bstyle = value; }
            get { return _bstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string battr
        {
            set { _battr = value; }
            get { return _battr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bstate
        {
            set { _bstate = value; }
            get { return _bstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bcheck
        {
            set { _bcheck = value; }
            get { return _bcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bshow
        {
            set { _bshow = value; }
            get { return _bshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string burl
        {
            set { _burl = value; }
            get { return _burl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bfn
        {
            set { _bfn = value; }
            get { return _bfn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bsql
        {
            set { _bsql = value; }
            get { return _bsql; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brname
        {
            set { _brname = value; }
            get { return _brname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brcode
        {
            set { _brcode = value; }
            get { return _brcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bspeattr
        {
            set { _bspeattr = value; }
            get { return _bspeattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bsort
        {
            set { _bsort = value; }
            get { return _bsort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool biszt
        {
            set { _biszt = value; }
            get { return _biszt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bproname
        {
            set { _bproname = value; }
            get { return _bproname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bprocedure
        {
            set { _bprocedure = value; }
            get { return _bprocedure; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int btip
        {
            set { _btip = value; }
            get { return _btip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bremark
        {
            set { _bremark = value; }
            get { return _bremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string btab
        {
            set { _btab = value; }
            get { return _btab; }
        }
        public string bico
        {
            get { return _bico; }
            set { _bico = value; }
        }
        #endregion Model

    }
}
