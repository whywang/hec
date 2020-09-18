using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_AfterGroupProduction
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _psid = "";
        private int _gnum = 0;
        private string _itype = "";
        private string _place = "";
        private string _direction = "";
        private string _fixs = "";
        private string _mname = "";
        private string _locks = "";
        private string _glass = "";
        private string _gsize = "";
        private string _pname = "";
        private int _height = 0;
        private int _width = 0;
        private int _deep = 0;
        private int _iheight = 0;
        private int _iwidth = 0;
        private int _ideep = 0;
        private decimal _pnum = 0M;
        private string _remark = "";
        private string _maker = "";
        private string _cdate = "";
        private string _msname = "";
        private string _stype = "";
        private string _sitype = "";
        private string _ggy = "";
        private string _adremark = "";
        private string _workform = "";
        private string _pmsd = "";

        public string pmsd
        {
            get { return _pmsd; }
            set { _pmsd = value; }
        }
        public string workform
        {
            get { return _workform; }
            set { _workform = value; }
        }

        public string adremark
        {
            get { return _adremark; }
            set { _adremark = value; }
        }
        public string ggy
        {
            get { return _ggy; }
            set { _ggy = value; }
        }
        public string sitype
        {
            get { return _sitype; }
            set { _sitype = value; }
        }
        public string msname
        {
            get { return _msname; }
            set { _msname = value; }
        }
        

        public string stype
        {
            get { return _stype; }
            set { _stype = value; }
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
        public int gnum
        {
            set { _gnum = value; }
            get { return _gnum; }
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
        public string itype
        {
            set { _itype = value; }
            get { return _itype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string place
        {
            set { _place = value; }
            get { return _place; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string direction
        {
            set { _direction = value; }
            get { return _direction; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fixs
        {
            set { _fixs = value; }
            get { return _fixs; }
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
        public string locks
        {
            set { _locks = value; }
            get { return _locks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string glass
        {
            set { _glass = value; }
            get { return _glass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsize
        {
            set { _gsize = value; }
            get { return _gsize; }
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
        public int height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int deep
        {
            set { _deep = value; }
            get { return _deep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iheight
        {
            set { _iheight = value; }
            get { return _iheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int iwidth
        {
            set { _iwidth = value; }
            get { return _iwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ideep
        {
            set { _ideep = value; }
            get { return _ideep; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
