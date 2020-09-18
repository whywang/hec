using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_ProductionCost
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _psid = "";
        private int _pid = 0;
        private string _pname = "";
        private string _pcode = "";
        private decimal _height = 0M;
        private decimal _width = 0M;
        private decimal _deep = 0M;
        private decimal _pnum = 0M;
        private string _bjtype = "";
        private string _gname = "";
        private string _gcode = "";
        private string _uname = "";
        private string _ucode = "";
        private string _ccname = "";
        private string _cccode = "";
        private string _utype = "";
        private decimal _unum = 0M;
        private string _cdate = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string psid
        {
            set { _psid = value; }
            get { return _psid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal deep
        {
            set { _deep = value; }
            get { return _deep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pnum
        {
            set { _pnum = value; }
            get { return _pnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjtype
        {
            set { _bjtype = value; }
            get { return _bjtype; }
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
        public string ccname
        {
            set { _ccname = value; }
            get { return _ccname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cccode
        {
            set { _cccode = value; }
            get { return _cccode; }
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
        public decimal unum
        {
            set { _unum = value; }
            get { return _unum; }
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
