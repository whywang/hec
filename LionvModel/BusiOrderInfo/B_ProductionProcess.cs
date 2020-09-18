using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_ProductionProcess
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _psid = "";
        private string _iname = "";
        private string _icode = "";
        private string _lname = "";
        private string _lcode = "";
        private string _gname = "";
        private string _gcode = "";
        private int  _nsort = 0;
        private int  _usetime = 0;
        private int  _fusetime = 0;
        private string  _bdate;
        private string  _cdate = "";
        private string _fname = "";
        private string _fcode = "";
        private string _zpc = "";
        private int _cpc = 0;
        private string _mname = "";

        public string mname
        {
            get { return _mname; }
            set { _mname = value; }
        }
        public string zpc
        {
            get { return _zpc; }
            set { _zpc = value; }
        }

        public int cpc
        {
            get { return _cpc; }
            set { _cpc = value; }
        }
        public string fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public string fcode
        {
            get { return _fcode; }
            set { _fcode = value; }
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsid
        {
            set { _gsid = value; }
            get { return _gsid; }
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
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
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
        public int  nsort
        {
            set { _nsort = value; }
            get { return _nsort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  usetime
        {
            set { _usetime = value; }
            get { return _usetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fusetime
        {
            set { _fusetime = value; }
            get { return _fusetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  bdate
        {
            set { _bdate = value; }
            get { return _bdate; }
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
