using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    public class Sys_BackEvent
    {
        public Sys_BackEvent()
        { }
        #region Model
        private int _id;
        private string _ename;
        private string _ecode;
        private string _bname;
        private string _bcode;
        private string _esort;
        private string _source;
        private string _ebody;
        private string _estate;

        public string estate
        {
            get { return _estate; }
            set { _estate = value; }
        }  /// 
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
        public string ecode
        {
            set { _ecode = value; }
            get { return _ecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bname
        {
            set { _bname = value; }
            get { return _bname; }
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
        public string esort
        {
            set { _esort = value; }
            get { return _esort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ebody
        {
            set { _ebody = value; }
            get { return _ebody; }
        }
        #endregion Model

    }
}
