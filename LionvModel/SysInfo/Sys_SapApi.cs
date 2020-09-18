using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_SapApi
    {
        #region Model
        private int _id;
        private string _sname;
        private string _scode;
        private string _surl;
        private string _suser;
        private string _spwd;
        private string _sfwname;
        private string _sfwmethod;
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
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string surl
        {
            set { _surl = value; }
            get { return _surl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string suser
        {
            set { _suser = value; }
            get { return _suser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spwd
        {
            set { _spwd = value; }
            get { return _spwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfwname
        {
            set { _sfwname = value; }
            get { return _sfwname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sfwmethod
        {
            set { _sfwmethod = value; }
            get { return _sfwmethod; }
        }
        #endregion Model

    }
}
