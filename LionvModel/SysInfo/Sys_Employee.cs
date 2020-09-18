using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public  class Sys_Employee
    {
        public Sys_Employee()
        { }
        #region Model
        private int _id;
        private string _ename="";
        private string _eno = "";
        private string _dcode;
        private string _dname;
        private bool _estate;
        private string _dtcode;
        private bool _elogin;
        private string _ecdate;
        private string _emaker = "";
        private string _rcode = "";
        private string _elname = "";
        private string _etelephone = "";

       
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
        public string ename
        {
            set { _ename = value; }
            get { return _ename; }
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
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
        public bool estate
        {
            set { _estate = value; }
            get { return _estate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtcode
        {
            set { _dtcode = value; }
            get { return _dtcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool elogin
        {
            set { _elogin = value; }
            get { return _elogin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ecdate
        {
            set { _ecdate = value; }
            get { return _ecdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emaker
        {
            set { _emaker = value; }
            get { return _emaker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rcode
        {
            set { _rcode = value; }
            get { return _rcode; }
        }

        public string elname
        {
            get { return _elname; }
            set { _elname = value; }
        }
        public string etelephone
        {
            get { return _etelephone; }
            set { _etelephone = value; }
        }
        #endregion Model

    }
}
