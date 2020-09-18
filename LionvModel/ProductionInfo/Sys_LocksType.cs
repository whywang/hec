using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public   class Sys_LocksType
    {
        #region Model
        private int _id;
        private string _lname = "";
        private string _lcode;
        private decimal _lprice = 0;
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
        public string lname
        {
            set { _lname = value; }
            get { return _lname; }
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
        public decimal lprice
        {
            set { _lprice = value; }
            get { return _lprice; }
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model
    }
}
