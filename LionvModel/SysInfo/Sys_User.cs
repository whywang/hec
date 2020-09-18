using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_User
    {
        public Sys_User()
        { }
        #region Model
        private int _id;
        private string _uname = "";
        private string _upass = "";
        private string _eno = "";
        private bool _ulogin = false;
        private string _uip = "";
        private string _ulogintime;
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
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string upass
        {
            set { _upass = value; }
            get { return _upass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string eno
        {
            set { _eno = value; }
            get { return _eno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ulogin
        {
            set { _ulogin = value; }
            get { return _ulogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string uip
        {
            set { _uip = value; }
            get { return _uip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ulogintime
        {
            set { _ulogintime = value; }
            get { return _ulogintime; }
        }
        #endregion Model

    }
}
