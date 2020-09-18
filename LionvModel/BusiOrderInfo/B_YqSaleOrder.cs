using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    public class B_YqSaleOrder
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _csid = "";
        private string _ccode = "";
        private string _wcode = "";
        private string _ycode = "";
        private string _scode = "";
        private string _pcode = "";
        private string _aname = "";
        private string _acode = "";
        private string _city = "";
        private string _citytype;
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _community = "";
        private string _address = "";
        private string _gzname = "";
        private string _gztelephone = "";
        private string _saletelephone = "";
        private string _otype = "";
        private string _mname = "";
        private decimal _sdiscount = 1M;
        private decimal _gdiscount = 1M;
        private string _source = "";
        private bool _istax = false;
        private bool _isdf = false;
        private string _sname;
        private decimal _tax = 0M;
        private string _wlcompany = "";
        private string _qtimg = "";
        private string _lxtype = "";
        private string _colorpane = "";
        private string _disactname = "";
        private string _disactcode = "";
        private string _floor = "";
        private string _bdcode;
        private string _mtype;
        private bool _ismb = false;
        private bool _iswj = false;
        private string _saddress = "";
        private string _gytype = "";
        private string _khcode = "";
        private string _remark = "";
        private string _maker = "";
        private string _zbremark = "";

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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string csid
        {
            set { _csid = value; }
            get { return _csid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wcode
        {
            set { _wcode = value; }
            get { return _wcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ycode
        {
            set { _ycode = value; }
            get { return _ycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
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
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acode
        {
            set { _acode = value; }
            get { return _acode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citytype
        {
            set { _citytype = value; }
            get { return _citytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citycode
        {
            set { _citycode = value; }
            get { return _citycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
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
        public string customer
        {
            set { _customer = value; }
            get { return _customer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string community
        {
            set { _community = value; }
            get { return _community; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gzname
        {
            set { _gzname = value; }
            get { return _gzname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gztelephone
        {
            set { _gztelephone = value; }
            get { return _gztelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saletelephone
        {
            set { _saletelephone = value; }
            get { return _saletelephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
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
        public decimal sdiscount
        {
            set { _sdiscount = value; }
            get { return _sdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal gdiscount
        {
            set { _gdiscount = value; }
            get { return _gdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool istax
        {
            set { _istax = value; }
            get { return _istax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isdf
        {
            set { _isdf = value; }
            get { return _isdf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sname
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tax
        {
            set { _tax = value; }
            get { return _tax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string wlcompany
        {
            set { _wlcompany = value; }
            get { return _wlcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qtimg
        {
            set { _qtimg = value; }
            get { return _qtimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lxtype
        {
            set { _lxtype = value; }
            get { return _lxtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string colorpane
        {
            set { _colorpane = value; }
            get { return _colorpane; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string disactname
        {
            set { _disactname = value; }
            get { return _disactname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string disactcode
        {
            set { _disactcode = value; }
            get { return _disactcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string floor
        {
            set { _floor = value; }
            get { return _floor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool ismb
        {
            set { _ismb = value; }
            get { return _ismb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool iswj
        {
            set { _iswj = value; }
            get { return _iswj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saddress
        {
            set { _saddress = value; }
            get { return _saddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gytype
        {
            set { _gytype = value; }
            get { return _gytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string khcode
        {
            set { _khcode = value; }
            get { return _khcode; }
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

        public string zbremark
        {
            get { return _zbremark; }
            set { _zbremark = value; }
        }
        #endregion Model

    }
}
