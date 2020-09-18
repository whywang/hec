using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_EventMenu
    {
        public Sys_EventMenu()
        { }
        #region Model
        private int _id;
        private string _emname = "";
        private string _emcode = "";
        private string _mname = "";
        private string _mcode = "";
        private bool _isflow = false;
        private bool _islist = false;
        private bool _isspe = false;
        private int _isexp = 0;
        private string _emtype = "";
        private string _emattr = "";//通用 或专属
        private string _emattrex = "";//增加报表类型
        private bool _emread = false;
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
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
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
        public bool isflow
        {
            set { _isflow = value; }
            get { return _isflow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool islist
        {
            set { _islist = value; }
            get { return _islist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isspe
        {
            set { _isspe = value; }
            get { return _isspe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isexp
        {
            set { _isexp = value; }
            get { return _isexp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emtype
        {
            set { _emtype = value; }
            get { return _emtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emattr
        {
            set { _emattr = value; }
            get { return _emattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emattrex
        {
            set { _emattrex = value; }
            get { return _emattrex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool emread
        {
            set { _emread = value; }
            get { return _emread; }
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
