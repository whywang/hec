using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_RepairDutyCategory
    {
        public Sys_RepairDutyCategory()
        { }
        #region Model
        private int _id;
        private string _rcname = "";
        private string _rccode = "";
        private string _rcpname = "";
        private string _rcpcode = "";
        private bool _isend = true;
        private bool _rread = false;
        private string _rtype = "";
        private string _dcode = "";
        private string _maker;
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
        public string rcname
        {
            set { _rcname = value; }
            get { return _rcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rccode
        {
            set { _rccode = value; }
            get { return _rccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rcpname
        {
            set { _rcpname = value; }
            get { return _rcpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rcpcode
        {
            set { _rcpcode = value; }
            get { return _rcpcode; }
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
