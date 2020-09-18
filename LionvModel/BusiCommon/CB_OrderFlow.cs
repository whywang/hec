using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
     
    public class CB_OrderFlow
    {
        public CB_OrderFlow()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _emcode = "";
        private string _wname = "";
        private string _wcode = "";
        private int _state = 0;
        private string _bdate;
        private string _edate;
        private string _maker = "";
        private string _wtype = "";
        private string _wrtype = "";

        public string wrtype
        {
            get { return _wrtype; }
            set { _wrtype = value; }
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
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
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdate
        {
            set { _bdate = value; }
            get { return _bdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string edate
        {
            set { _edate = value; }
            get { return _edate; }
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
        public string wtype
        {
            set { _wtype = value; }
            get { return _wtype; }
        }
        #endregion Model
    }
}
