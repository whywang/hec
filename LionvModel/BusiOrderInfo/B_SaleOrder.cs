using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public partial class B_SaleOrder
    {
        public B_SaleOrder()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _csid = "";
        private string _zsid = "";
        private string _scode = "";
        private string _oscode = "";
        private string _zcode = "";
        private string _wcode = "";
        private string _sdcode = "";
        private string _bdcode = "";
        private string _city = "";
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _community = "";
        private string _address = "";
        private string _aprovince="";
        private string _acity = "";
        private string _saddress = "";
        private string _gzname = "";
        private string _gztelephone = "";
        private string _stelephone = "";
        private string _otype = "";
        private string _pbdcode = "";
        private string _sendtype = "";
        private string _sdtype = "";
        private string _mname = "";
        private string _source = "";
        private decimal _sdiscount = 1M;
        private decimal _gdiscount = 1M;
        private bool _istax = false;
        private bool _isdf = false;
        private bool _iscl = false;
        private string _colorpane = "";
        private string _disactname = "";
        private string _disactcode = "";
        private string _floor = "";
        private string _clperson = "";
        private string _azperson = "";
        private string _ydate;
        private string _qtimg = "";
        private string _remark = "";
        private string _zbremark = "";
        private string _maker = "";
        private string _cdate;
        private string _pbdname = "";
        private string _qytype = "";
        private string _ctype = "";
        //--------------------------------------

        private string _fcname = "";
        private string _fccode = "";
        private string _fhdate = "";
        private string _overdate = "";
        private string _cdy = "";
        private decimal _omoney = 0M;
        private string _package = "";
        private string _untype = "";
        private string _mremark = "";
       
        
        public decimal omoney
        {
            get { return _omoney; }
            set { _omoney = value; }
        }
        public string cdy
        {
            get { return _cdy; }
            set { _cdy = value; }
        }
        public string overdate
        {
            get { return _overdate; }
            set { _overdate = value; }
        }
        public string fhdate
        {
            get { return _fhdate; }
            set { _fhdate = value; }
        }

        private string _ztimg = "";

        public string ztimg
        {
            get { return _ztimg; }
            set { _ztimg = value; }
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
        public string csid
        {
            set { _csid = value; }
            get { return _csid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zsid
        {
            set { _zsid = value; }
            get { return _zsid; }
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
        public string oscode
        {
            set { _oscode = value; }
            get { return _oscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zcode
        {
            set { _zcode = value; }
            get { return _zcode; }
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
        public string sdcode
        {
            set { _sdcode = value; }
            get { return _sdcode; }
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
        public string city
        {
            set { _city = value; }
            get { return _city; }
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
        public string aprovince
        {
            set { _aprovince = value; }
            get { return _aprovince; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string acity
        {
            set { _acity = value; }
            get { return _acity; }
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
        public string stelephone
        {
            set { _stelephone = value; }
            get { return _stelephone; }
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
        public string pbdcode
        {
            set { _pbdcode = value; }
            get { return _pbdcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sendtype
        {
            set { _sendtype = value; }
            get { return _sendtype; }
        }
        /// <summary>
        /// 门店类型
        /// </summary>
        public string sdtype
        {
            set { _sdtype = value; }
            get { return _sdtype; }
        }
        /// <summary>
        /// 门店类型
        /// </summary>
        public string ctype
        {
            set { _ctype = value; }
            get { return _ctype; }
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
        public string source
        {
            set { _source = value; }
            get { return _source; }
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
        public bool iscl
        {
            set { _iscl = value; }
            get { return _iscl; }
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
        public string clperson
        {
            set { _clperson = value; }
            get { return _clperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string azperson
        {
            set { _azperson = value; }
            get { return _azperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ydate
        {
            set { _ydate = value; }
            get {
                if (_ydate != "")
                {
                    if (_ydate == null)
                    {
                        _ydate = "";
                    }
                    else
                    {
                        _ydate = Convert.ToDateTime(_ydate).ToString("yyyy-MM-dd");
                    }
                }
                return _ydate; 
            }
        }
        /// <summary>
        /// 二维码
        /// </summary>
        public string qtimg
        {
            set { _qtimg = value; }
            get { return _qtimg; }
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
        public string zbremark
        {
            set { _zbremark = value; }
            get { return _zbremark; }
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
        public string pbdname
        {
            get { return _pbdname; }
            set { _pbdname = value; }
        }
        public string qytype
        {
            get { return _qytype; }
            set { _qytype = value; }
        }
        public string fcname
        {
            get { return _fcname; }
            set { _fcname = value; }
        }
        public string fccode
        {
            get { return _fccode; }
            set { _fccode= value; }
        }
        public string package
        {
            get { return _package; }
            set { _package = value; }
        }
        public string untype
        {
            get { return _untype; }
            set { _untype = value; }
        }
        public string mremark
        {
            get { return _mremark; }
            set { _mremark = value; }
        }
        #endregion Model
    }
}
