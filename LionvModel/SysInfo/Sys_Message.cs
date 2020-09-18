using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_Message
    {
        #region Model
        private int _id;
        private string _mname = "";
        private string _mcode;
        private string _rcode = "";
        private string _ename = "";
        private int _mstate = 0;
        private string _bcode = "";
        private bool _mcity = false;
        private bool _iused = false;
        private string _maker = "";
        private string _murl = "";
        private string _cdate;
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        public int mstate
        {
            set { _mstate = value; }
            get { return _mstate; }
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
        public bool mcity
        {
            set { _mcity = value; }
            get { return _mcity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string murl
        {
            set { _murl = value; }
            get { return _murl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool iused
        {
            set { _iused = value; }
            get { return _iused; }
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
        #endregion Model

    }
}
