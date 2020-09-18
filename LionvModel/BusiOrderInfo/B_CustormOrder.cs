using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    [Serializable]
    public partial class B_CustormOrder
    {
        public B_CustormOrder()
        { }
        #region Model
        private int _id;
        private string _csid = "";
        private string _ccode = "";//预定单编号
        private string _wcode = "";//网购编号 或店面编号
        private string _ycode = "";//原单编号
        private string _customer = "";
        private string _telephone = "";
        private string _community = "";
        private string _address = "";
        private string _aname = "";
        private string _acode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _gzname = "";
        private string _gztelephone = "";
        private string _saletelephone = "";
        private string _otype = "";
        private bool _state = false;
        private string _mname = "";
        private string _source = "";
        private string _ps = "";
        private string _e_city = "";//城市名称
        private string _e_citycode = "";//城市编码
        private string _maker = "";
        private string _cdate = "";
        private bool _istax = false;
        private bool _isdf = false;
        private string _e_citytype = "";//城市类型
        private string _tname = "";
        private string _tcode = "";

        ///博亮---

        private string _lxtype = "";//联系类型
        private string _colorpane = "";//色板类型
		private string _yxdate;//预计下单日期
		private string _disactname="";//活动命名
		private string _disactcode="";//活动编码
        private decimal _cmoney=0;//订金
        private decimal _pstate = 0;//支付状态 -2已退款 -1申请退款,0,未收款 1已收款
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        public bool state
        {
            set { _state = value; }
            get { return _state; }
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
        public string ps
        {
            set { _ps = value; }
            get { return _ps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_city
        {
            set { _e_city = value; }
            get { return _e_city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_citycode
        {
            set { _e_citycode = value; }
            get { return _e_citycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string e_citytype
        {
            set { _e_citytype = value; }
            get { return _e_citytype; }
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
        public bool istax
        {
            set { _istax = value; }
            get { return _istax; }
        }
        public bool isdf
        {
            set { _isdf = value; }
            get { return _isdf; }
        }
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
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
        public string yxdate
        {
            set { _yxdate = value; }
            get { return _yxdate; }
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
        public decimal cmoney
        {
            set { _cmoney = value; }
            get { return _cmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pstate
        {
            set { _pstate = value; }
            get { return _pstate; }
        }
        #endregion Model

    }
}
