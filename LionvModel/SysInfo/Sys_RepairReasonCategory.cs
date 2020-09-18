using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public  class Sys_RepairReasonCategory
    {
        public Sys_RepairReasonCategory()
        { }
        #region Model
        private int _id;
        private string _rrname;
        private string _rrcode;
        private string _rrpcode = "";
        private string _rrpname = "";
        private bool _isend = true;
        private bool _rread = false;
        private string _rtype = "";
        private string _dcode = "";
        private string _maker = "";
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
        public string rrname
        {
            set { _rrname = value; }
            get { return _rrname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rrcode
        {
            set { _rrcode = value; }
            get { return _rrcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rrpcode
        {
            set { _rrpcode = value; }
            get { return _rrpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rrpname
        {
            set { _rrpname = value; }
            get { return _rrpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isend
        {
            set { _isend = value; }
            get { return _isend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool rread
        {
            set { _rread = value; }
            get { return _rread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rtype
        {
            set { _rtype = value; }
            get { return _rtype; }
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
