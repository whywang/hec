using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_Depment
    {
        public Sys_Depment()
        { }
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode = "";
        private string _dpname = "";
        private string _dpcode = "";
        private string _dcdate;
        private bool _disused = false;
        private string _dattr = "";
        private string _dmaker = "";
        private bool _disend = false;
        private string _dcdep = "";
        private string _maker = "";
        private string _cdate = "";
        private bool _dread = false;
        private string _dabc = "";
        private string _khcode = "";
        private int _dsort = 0;
        private string _dmattr = "";
        private string _dcity = "";
        private decimal _dsquare = 0;

        
        public string dmattr
        {
            get { return _dmattr; }
            set { _dmattr = value; }
        }

        public int dsort
        {
            get { return _dsort; }
            set { _dsort = value; }
        }
        public string dcity
        {
            get { return _dcity; }
            set { _dcity = value; }
        }
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dpname
        {
            set { _dpname = value; }
            get { return _dpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dpcode
        {
            set { _dpcode = value; }
            get { return _dpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string khcode
        {
            set { _khcode = value; }
            get { return _khcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcdate
        {
            set { _dcdate = value; }
            get { return _dcdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool disused
        {
            set { _disused = value; }
            get { return _disused; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dattr
        {
            set { _dattr = value; }
            get { return _dattr; }
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
        public bool disend
        {
            set { _disend = value; }
            get { return _disend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcdep
        {
            set { _dcdep = value; }
            get { return _dcdep; }
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
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool dread
        {
            set { _dread = value; }
            get { return _dread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dabc
        {
            set { _dabc = value; }
            get { return _dabc; }
        }
        public decimal dsquare
        {
            get { return _dsquare; }
            set { _dsquare = value; }
        }
        #endregion Model

    }
}
