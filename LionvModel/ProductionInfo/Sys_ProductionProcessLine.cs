using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProductionProcessLine
    {
        #region Model
        private int _id;
        private string _lcode;
        private string _lname = "";
        private string _maker = "";
        private string _dcode = "";
        private string _cdate;
        private int _utime = 0;

        public int utime
        {
            get { return _utime; }
            set { _utime = value; }
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
        public string lcode
        {
            set { _lcode = value; }
            get { return _lcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lname
        {
            set { _lname = value; }
            get { return _lname; }
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
