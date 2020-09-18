using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
    [Serializable]
    public class Sys_OrderType
    {
        public Sys_OrderType()
        { }
        #region Model
        private int _id;
        private string _tname = "";
        private string _tcode = "";
        private string _emname = "";
        private string _emcode = "";
        private bool _tread = false;
        private string _ttype = "";
        private string _dcode = "";
        private string _maker = "";
        private string _cdate;
        private string _tsource = "";
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
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
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
        public bool tread
        {
            set { _tread = value; }
            get { return _tread; }
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
        public string tsource
        {
            set { _tsource = value; }
            get { return _tsource; }
        }
        #endregion Model

    }
}
