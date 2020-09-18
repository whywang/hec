using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_GroupProductionMoney
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _psid = "";
        private int _gnum = 0;
        private int _pnum = 0;
        private string _pname = "";
        private string _pcode = "";
        private decimal _squality = 0;
        private string _sdistype = "";
        private decimal _sdiscount = 0;
        private decimal _smoney = 0;
        private decimal _sovermoney = 0;
        private decimal _sothermoney = 0;
        private decimal _dsmoney;
        private decimal _dsovermoney = 0;
        private decimal _dsothermoney = 0;
        private decimal _gquality = 0;
        private string _gdistype = "";
        private decimal _gdiscount = 0;
        private decimal _gmoney = 0;
        private decimal _govermoney = 0;
        private decimal _gothermoney = 0;
        private decimal _dgmoney = 0;
        private decimal _dgovermoney = 0;
        private decimal _dgothermoney = 0;
        private decimal _cquality = 0;
        private string _cdistype = "";
        private decimal _cdiscount = 0;
        private decimal _cmoney = 0;
        private decimal _covermoney = 0;
        private decimal _cothermoney = 0;
        private decimal _dcmoney = 0;
        private decimal _dcovermoney = 0;
        private decimal _dcothermoney = 0;
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
        public int pnum
        {
            set { _pnum = value; }
            get { return _pnum; }
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
        public decimal squality
        {
            set { _squality = value; }
            get { return _squality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sdistype
        {
            set { _sdistype = value; }
            get { return _sdistype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sdiscount
        {
            set { _sdiscount = value; }
            get
            {
                if (_sdiscount == 0)
                {
                    return 1;
                }
                else
                {
                    return _sdiscount;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal smoney
        {
            set { _smoney = value; }
            get { return _smoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sovermoney
        {
            set { _sovermoney = value; }
            get { return _sovermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sothermoney
        {
            set { _sothermoney = value; }
            get { return _sothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dsmoney
        {
            set { _dsmoney = value; }
            get { return _dsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dsovermoney
        {
            set { _dsovermoney = value; }
            get { return _dsovermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dsothermoney
        {
            set { _dsothermoney = value; }
            get { return _dsothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal gquality
        {
            set { _gquality = value; }
            get { return _gquality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gdistype
        {
            set { _gdistype = value; }
            get { return _gdistype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal gdiscount
        {
            set { _gdiscount = value; }
            get
            {
                if (_gdiscount == 0)
                {
                    return 1;
                }
                else
                {
                    return _gdiscount;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal gmoney
        {
            set { _gmoney = value; }
            get { return _gmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal govermoney
        {
            set { _govermoney = value; }
            get { return _govermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal gothermoney
        {
            set { _gothermoney = value; }
            get { return _gothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dgmoney
        {
            set { _dgmoney = value; }
            get { return _dgmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dgovermoney
        {
            set { _dgovermoney = value; }
            get { return _dgovermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dgothermoney
        {
            set { _dgothermoney = value; }
            get { return _dgothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cquality
        {
            set { _cquality = value; }
            get { return _cquality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdistype
        {
            set { _cdistype = value; }
            get { return _cdistype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cdiscount
        {
            set { _cdiscount = value; }
            get
            {
                if (_cdiscount == 0)
                {
                    return 1;
                }
                else
                {
                    return _cdiscount;
                }
            }
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
        public decimal covermoney
        {
            set { _covermoney = value; }
            get { return _covermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cothermoney
        {
            set { _cothermoney = value; }
            get { return _cothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dcmoney
        {
            set { _dcmoney = value; }
            get { return _dcmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dcovermoney
        {
            set { _dcovermoney = value; }
            get { return _dcovermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dcothermoney
        {
            set { _dcothermoney = value; }
            get { return _dcothermoney; }
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
