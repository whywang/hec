using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_AfterReModifyOrder
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _asid = "";
        private string _osid = "";
        private string _scode = "";
        private string _ascode = "";
        private string _oscode = "";
        private string _city = "";
        private string _citycode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _customer = "";
        private string _telephone = "";
        private string _aprovince = "";
        private string _acity = "";
        private string _areason = "";
        private string _aduty = "";
        private string _adremark = "";
        private string _otype = "";
        private string _ptype = "";
        private bool _isbf = false;
        private string _senddate;
        private string _remark = "";
        private string _sperson = "";
        private string _settlment = "";
        private decimal _omoney = 0M;
        private decimal _qmoney = 0M;
        private string _sendtype = "";
        private string _sodate;
        private int _bnum = 0;
        private string _maker = "";
        private string _cdate;
        private string _address = "";
        private string _premark = "";
        private string _fname = "";
        private string _fcode = "";
        private string _rcode= "0";
        private string _sdate = "";
        private decimal _gofee = 0;
        private decimal _servfee = 0;
        private string _stext = "";
        private string _azperson = "";
        private string _fzt = "";
        private string _cinfo = "";
        private string _oinfo = "";
        private string _fodate = "";
        private string _qytype = "";
        private string _salearea = "";
        private decimal _fmoney = 0M;
        private string _kfperson = "";
        private decimal _tmoney = 0M;
        private string _tsdate = "";
        private bool _jsyf = false;
        private string _pmethod = "";


        public string tsdate
        {
            get { return _tsdate; }
            set { _tsdate = value; }
        }
        public string salearea
        {
            get { return _salearea; }
            set { _salearea = value; }
        }
        public string qytype
        {
            get { return _qytype; }
            set { _qytype = value; }
        }
        public string fodate
        {
            get { return _fodate; }
            set { _fodate = value; }
        }

        public string oinfo
        {
            get { return _oinfo; }
            set { _oinfo = value; }
        }

        public string cinfo
        {
            get { return _cinfo; }
            set { _cinfo = value; }
        }

        public string fzt
        {
            get { return _fzt; }
            set { _fzt = value; }
        }

        public string azperson
        {
            get { return _azperson; }
            set { _azperson = value; }
        }
        public string stext
        {
            get { return _stext; }
            set { _stext = value; }
        }

        public decimal servfee
        {
            get { return _servfee; }
            set { _servfee = value; }
        }

        public decimal gofee
        {
            get { return _gofee; }
            set { _gofee = value; }
        }

        public string sdate
        {
            get {
                if (_sdate == null || _sdate == "")
                {
                    _sdate = "";
                }
                else
                {
                    if (Convert.ToDateTime(_sdate) > Convert.ToDateTime("2020-01-01"))
                    {
                        _sdate = Convert.ToDateTime(_sdate).ToString("yyyy-MM-dd");
                    }
                }
                return _sdate; }
            set { _sdate = value; }
        }
       
        public string rcode
        {
            get { return _rcode; }
            set { _rcode = value; }
        }
        public string fcode
        {
            get { return _fcode; }
            set { _fcode = value; }
        }

        public string premark
        {
            get { return _premark; }
            set { _premark = value; }
        }

        public string fname
        {
            get { return _fname; }
            set { _fname = value; }
        }

        public string address
        {
            get { return _address; }
            set { _address = value; }
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
        public string asid
        {
            set { _asid = value; }
            get { return _asid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string osid
        {
            set { _osid = value; }
            get { return _osid; }
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
        public string ascode
        {
            set { _ascode = value; }
            get { return _ascode; }
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
        public string areason
        {
            set { _areason = value; }
            get { return _areason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aduty
        {
            set { _aduty = value; }
            get { return _aduty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adremark
        {
            set { _adremark = value; }
            get { return _adremark; }
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
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isbf
        {
            set { _isbf = value; }
            get { return _isbf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string senddate
        {
            set { _senddate = value; }
            get {
                if (_senddate != null)
                {
                    _senddate = Convert.ToDateTime(_senddate).ToString("yyyy-MM-dd");
                }
                return _senddate; }
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
        public string sperson
        {
            set { _sperson = value; }
            get { return _sperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string settlment
        {
            set { _settlment = value; }
            get { return _settlment; }
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
        public decimal qmoney
        {
            set { _qmoney = value; }
            get { return _qmoney; }
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
        /// 
        /// </summary>
        public string sodate
        {
            set { _sodate = value; }
            get {
                if (_sodate != null)
                {
                    _sodate = Convert.ToDateTime(_sodate).ToString("yyyy-MM-dd");
                }
                return _sodate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int bnum
        {
            set { _bnum = value; }
            get { return _bnum; }
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
        /// <summary>
        /// 
        /// </summary>
        public decimal fmoney
        {
            set { _fmoney = value; }
            get { return _fmoney; }
        }
        public string kfperson
        {
            get { return _kfperson; }
            set { _kfperson = value; }
        }
        public decimal tmoney
        {
            set { _tmoney = value; }
            get { return _tmoney; }
        }
        public bool jsyf
        {
            get { return _jsyf; }
            set { _jsyf = value; }
        }
        public string pmethod
        {
            get { return _pmethod; }
            set { _pmethod = value; }
        }
       
        #endregion Model
    }
}
