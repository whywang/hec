using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_ProductionItem
    {
        public B_ProductionItem()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _psid = "";
        private string _pname = "";
        private string _pcode;
        private string _mname = "";
        private string _ptype = "";
        private int _height = 0;
        private int _width = 0;
        private int _deep = 0;
        private decimal _pnum = 0;
        private string _e_ptype = "";
        private string _e_ptypeex = "";
        private string _addattr = "";//部件是否为增加项
        private string _addsw = "";//部件显示方式
        private string _aname = "";//部件名称
        private string _maker = "";
        private string _workline = "";
        private int _hinterval = 0;
        private string _ftype = "";
        private string _cdate ;
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
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
        public decimal pnum
        {
            set { _pnum = value; }
            get { return _pnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_ptype
        {
            set { _e_ptype = value; }
            get { return _e_ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_ptypeex
        {
            set { _e_ptypeex = value; }
            get { return _e_ptypeex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string workline
        {
            set { _workline = value; }
            get { return _workline; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string addattr
        {
            set { _addattr = value; }
            get { return _addattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string addsw
        {
            set { _addsw = value; }
            get { return _addsw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }

        public int hinterval
        {
            get { return _hinterval; }
            set { _hinterval = value; }
        }
        public string ftype
        {
            get { return _ftype; }
            set { _ftype = value; }
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
