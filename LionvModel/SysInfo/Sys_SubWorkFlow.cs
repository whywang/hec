using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_SubWorkFlow
    {
        #region Model
        private int _id;
        private string _socode;
        private string _soname = "";
        private string _emcode = "";
        private string _semcode = "";
        private string _dtable = "";
        private string _mtable = "";
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
        public string socode
        {
            set { _socode = value; }
            get { return _socode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string soname
        {
            set { _soname = value; }
            get { return _soname; }
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
        public string semcode
        {
            set { _semcode = value; }
            get { return _semcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtable
        {
            set { _dtable = value; }
            get { return _dtable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtable
        {
            set { _mtable = value; }
            get { return _mtable; }
        }
        #endregion Model

    }
}
