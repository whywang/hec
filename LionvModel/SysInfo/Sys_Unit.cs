using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   [Serializable]
   public class Sys_Unit
    {
        public Sys_Unit()
        { }
        #region Model
        private int _id;
        private string _uname;
        private string _ucode;
        private string _utype;
        private bool _uread;
        private string _dcode;
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
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ucode
        {
            set { _ucode = value; }
            get { return _ucode; }
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
        public bool uread
        {
            set { _uread = value; }
            get { return _uread; }
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
