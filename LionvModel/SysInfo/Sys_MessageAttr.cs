using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_MessageAttr
    {
        #region Model
        private int _id;
        private string _ename = "";
        private string _ecode;
        private string _eurl = "";
        private string _esource = "";
        private string _maker = "";
        private string _cdate;
        private string _dcode = "";

        public string dcode
        {
            get { return _dcode; }
            set { _dcode = value; }
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
        public string eurl
        {
            set { _eurl = value; }
            get { return _eurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string esource
        {
            set { _esource = value; }
            get { return _esource; }
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
