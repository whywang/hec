using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_Templet
    {
        public Sys_Templet()
        { }
        #region Model
        private int _id;
        private string _emcode = "";
        private string _emname = "";
        private string _ttype = "";
        private string _ttext = "";
        private string _dcode = "";
        private string _utype = "";
        private string _maker = "";
        private string _cdate = "";
        private string _limg = "";
        private string _ptype = "";
        private string _fname = "";
        public string limg
        {
            get { return _limg; }
            set { _limg = value; }
        }
        public string emname
        {
            get { return _emname; }
            set { _emname = value; }
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
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttype
        {
            set { _ttype = value; }
            get { return _ttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttext
        {
            set { _ttext = value; }
            get { return _ttext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string utype
        {
            set { _utype = value; }
            get { return _utype; }
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
        /// <summary>
        /// 
        /// </summary>
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        #endregion Model
    }
}
