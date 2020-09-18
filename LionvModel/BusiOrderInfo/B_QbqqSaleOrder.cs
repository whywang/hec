using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public class B_QbqqSaleOrder
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _csid = "";
        private string _ccode = "";
        private string _ycode = "";
        private string _wcode = "";
        private string _scode = "";
        private string _pcode = "";
        private string _bdcode = "";
        private string _aname = "";
        private string _acode = "";
        private string _city = "";
        private string _citycode = "";
        private string _citytype = "";
        private string _dname = "";
        private string _dcode = "";
        private string _khcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _address = "";
        private string _community = "";
        private string _clperson = "";
        private string _azperson = "";
        private string _saletelephone = "";
        private string _otype = "";
        private string _mname = "";
        private string _remark = "";
        private decimal _sdiscount = 0M;
        private decimal _gdiscount = 0M;
        private decimal _cdiscount = 0M;
        private string _source = "";
        private string _wlcompany = "";
        private string _colorpane = "";
        private string _disactname = "";
        private string _disactcode = "";
        private string _designer = "";
        private string _ndesigner = "";
        private decimal _dmoney = 0M;
        private decimal _omoney = 0M;
        private string _dtype = "";
        private string _packtype = "";
        private int _pagenum = 0;
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
        public string ycode
        {
            set { _ycode = value; }
            get { return _ycode; }
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
        public string bdcode
        {
            set { _bdcode = value; }
            get { return _bdcode; }
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
        public string citycode
        {
            set { _citycode = value; }
            get { return _citycode; }
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
        public string khcode
        {
            set { _khcode = value; }
            get { return _khcode; }
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
        public string address
        {
            set { _address = value; }
            get { return _address; }
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
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        public decimal cdiscount
        {
            set { _cdiscount = value; }
            get { return _cdiscount; }
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
        public string wlcompany
        {
            set { _wlcompany = value; }
            get { return _wlcompany; }
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
        public string designer
        {
            set { _designer = value; }
            get { return _designer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ndesigner
        {
            set { _ndesigner = value; }
            get { return _ndesigner; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dmoney
        {
            set { _dmoney = value; }
            get { return _dmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal omoney
        {
            set { _omoney = value; }
            get { return _omoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtype
        {
            set { _dtype = value; }
            get { return _dtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string packtype
        {
            set { _packtype = value; }
            get { return _packtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pagenum
        {
            set { _pagenum = value; }
            get { return _pagenum; }
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
