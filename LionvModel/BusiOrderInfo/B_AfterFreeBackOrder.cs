using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_AfterFreeBackOrder
    {	
       #region Model
		private int _id;
		private string _sid;
		private string _osid="";
		private string _asid="";
		private string _scode="";
		private string _oscode="";
		private string _sscode="";
		private string _city="";
		private string _citycode="";
		private string _dname="";
		private string _dcode="";
		private string _customer="";
		private string _telephone="";
		private string _aprovince="";
		private string _acity="";
		private string _address="";
		private string _areason="";
		private string _qtimg="";
		private string _sdate;
		private decimal _gofee=0M;
		private decimal _servfee=0M;
		private string _stext="";
        private string _remark = "";
        private string _otype = "";
        private string _oinfo = "";
        private string _cinfo = "";
		private string _maker="";
        private string _azperson = "";
		private string _cdate;
        private string _odate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string osid
		{
			set{ _osid=value;}
			get{return _osid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string asid
		{
			set{ _asid=value;}
			get{return _asid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string scode
		{
			set{ _scode=value;}
			get{return _scode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string oscode
		{
			set{ _oscode=value;}
			get{return _oscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sscode
		{
			set{ _sscode=value;}
			get{return _sscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string city
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string citycode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dname
		{
			set{ _dname=value;}
			get{return _dname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dcode
		{
			set{ _dcode=value;}
			get{return _dcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string aprovince
		{
			set{ _aprovince=value;}
			get{return _aprovince;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string acity
		{
			set{ _acity=value;}
			get{return _acity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string areason
		{
			set{ _areason=value;}
			get{return _areason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qtimg
		{
			set{ _qtimg=value;}
			get{return _qtimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sdate
		{
			set{ _sdate=value;}
			get{return _sdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal gofee
		{
			set{ _gofee=value;}
			get{return _gofee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal servfee
		{
			set{ _servfee=value;}
			get{return _servfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stext
		{
			set{ _stext=value;}
			get{return _stext;}
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
			set{ _maker=value;}
			get{return _maker;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string oinfo
        {
            set { _oinfo = value; }
            get { return _oinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cinfo
        {
            set { _cinfo = value; }
            get { return _cinfo; }
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
		public string cdate
		{
			set{ _cdate=value;}
			get{return _cdate;}
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
        public string odate
        {
            set { _odate = value; }
            get { return _odate; }
        }
		#endregion Model

    }
}
