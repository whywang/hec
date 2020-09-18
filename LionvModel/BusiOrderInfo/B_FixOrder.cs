using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_FixOrder
    {
        #region Model
        private int _id;
        private string _sid;
        private string _scode = "";
        private string _dname = "";
        private string _dcode = "";
        private string _customer;
        private string _telephone;
        private string _address;
        private string _remark;
        private string _maker;
        private string _cdate;
        private decimal _othermoney = 0;

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
        public string scode
        {
            set { _scode = value; }
            get { return _scode; }
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
        public string address
        {
            set { _address = value; }
            get { return _address; }
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
        #region 扩展属性
        private string _fixter = "";

        public string fixter
        {
            get { return _fixter; }
            set { _fixter = value; }
        }
        private string _fixdate = "";

        public string fixdate
        {
            get { return _fixdate; }
            set { _fixdate = value; }
        }

        public decimal othermoney
        {
            get { return _othermoney; }
            set { _othermoney = value; }
        }
        private string _fixstate = "";

        public string fixstate
        {
            get { return _fixstate; }
            set { _fixstate = value; }
        }
        private int _fixsh = 0;

        public int fixsh
        {
            get { return _fixsh; }
            set { _fixsh = value; }
        }
        private int _fixaz = 0;

        public int fixaz
        {
            get { return _fixaz; }
            set { _fixaz = value; }
        }
        #endregion
    }
}
