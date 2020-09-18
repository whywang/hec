using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_LimitSize
    {
        #region Model
        private int _id = 0;
        private string _lname = "";
        private string _lcode;
        private string _dcode = "";
        private int  _hmin = 0;
        private int _hmax = 0;
        private int _kmin = 0;
        private int _kmax = 0;
        private int _dmin = 0;
        private int _dmax = 0;
        private string _maker;
        private string  _cdate;
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
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  hmin
        {
            set { _hmin = value; }
            get { return _hmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  hmax
        {
            set { _hmax = value; }
            get { return _hmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  kmin
        {
            set { _kmin = value; }
            get { return _kmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  kmax
        {
            set { _kmax = value; }
            get { return _kmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmin
        {
            set { _dmin = value; }
            get { return _dmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmax
        {
            set { _dmax = value; }
            get { return _dmax; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
