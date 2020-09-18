using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProductionProcessCost
    {
        #region Model
        private int _id;
        private string _uname = "";
        private string _ucode;
        private string _gname = "";
        private string _gcode;
        private string _mname = "";
        private string _mcode;
        private string _utype = "";
        private decimal  _unum = 0M;
        private string _maker;
        private string _mc;
        private string _mk;
        private string _mh;
        private int  _utj = 0;
        private int  _ulg = 0;
        private int  _utg = 0;
        private int  _ulk = 0;
        private int  _utk = 0;
        private int  _ulh = 0;
        private int  _uth = 0;
        private string _dcode = "";
        private string  _cdate;
        private string _bjlist = "";

        public string bjlist
        {
            get { return _bjlist; }
            set { _bjlist = value; }
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
        public string gname
        {
            set { _gname = value; }
            get { return _gname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gcode
        {
            set { _gcode = value; }
            get { return _gcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        public decimal  unum
        {
            set { _unum = value; }
            get { return _unum; }
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
        public string mc
        {
            set { _mc = value; }
            get { return _mc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mk
        {
            set { _mk = value; }
            get { return _mk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mh
        {
            set { _mh = value; }
            get { return _mh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  utj
        {
            set { _utj = value; }
            get { return _utj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ulg
        {
            set { _ulg = value; }
            get { return _ulg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  utg
        {
            set { _utg = value; }
            get { return _utg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ulk
        {
            set { _ulk = value; }
            get { return _ulk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  utk
        {
            set { _utk = value; }
            get { return _utk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ulh
        {
            set { _ulh = value; }
            get { return _ulh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  uth
        {
            set { _uth = value; }
            get { return _uth; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
