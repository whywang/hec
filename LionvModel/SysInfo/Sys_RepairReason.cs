using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    /// </summary>
    [Serializable]
    public class Sys_RepairReason
    {
        public Sys_RepairReason()
        { }
        #region Model
        private int _id;
        private string _rcode = "";
        private string _rdetail = "";
        private string _rrcode = "";
        private string _rrname = "";
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
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rdetail
        {
            set { _rdetail = value; }
            get { return _rdetail; }
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
        public string rrname
        {
            set { _rrname = value; }
            get { return _rrname; }
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
