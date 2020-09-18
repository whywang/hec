using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public  class Sys_TabMenu
    {
        #region Model
        private int _id;
        private string _tmname;
        private string _tmcode;
        private string _dcode = "";
        private bool _isflow = false;
        private string _maker = "";
        private string _cdate;
        private bool _tread = false;
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
        public string tmname
        {
            set { _tmname = value; }
            get { return _tmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tmcode
        {
            set { _tmcode = value; }
            get { return _tmcode; }
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
        public bool isflow
        {
            set { _isflow = value; }
            get { return _isflow; }
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
        public bool tread
        {
            set { _tread = value; }
            get { return _tread; }
        }
        #endregion Model

    }
}
