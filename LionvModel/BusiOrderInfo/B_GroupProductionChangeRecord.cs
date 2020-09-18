using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_GroupProductionChangeRecord
    {
        #region Model
        private int _id;
        private string _csid = "";
        private string _sid = "";
        private string _gsid = "";
        private string _psid = "";
        private int _gnum = 0;
        private string _iname = "";
        private string _icode = "";
        private string _mname = "";
        private string _uname = "";
        private decimal _inum = 0M;
        private string _place = "";
        private string _direction = "";
        private string _fix = "";
        private string _locktype;
        private string _locks;
        private string _itype = "";
        private string _ptype = "";
        private int  _height = 0;
        private int  _width = 0;
        private int  _deep = 0;
        private int  _fsize = 0;
        private decimal  _smoney = 0M;
        private decimal  _sovermoney = 0M;
        private decimal  _sothermoney = 0M;
        private decimal  _gmoney = 0M;
        private decimal  _govermoney = 0M;
        private decimal  _gothermoney = 0M;
        private decimal  _cmoney = 0M;
        private decimal  _covermoney = 0M;
        private decimal  _cothermoney = 0M;
        private decimal  _sdiscount = 1M;
        private decimal  _gdiscount = 1M;
        private decimal  _cdiscount = 1M;
        private string _pic = "";
        private int  _ichange = 0;
        private string _ps = "";
        private string _isjc = "";
        private int  _idiscount = 1;
        private decimal  _allprice = 0M;
        private decimal  _serverprice = 0M;
        private string _picname = "";
        private string _czyy = "";
        private string _zsize = "";
        private string _zjname = "";
        private string _zjcode = "";
        private string _zjmname = "";
        private string _tbcz = "";
        private string _lxcz = "";
        private string _tsid = "";
        private string _cpxz = "";
        private string _tjxz = "";
        private string _rimg = "";
        private decimal  _priceps = 0M;
        private decimal  _ghnum = 0M;
        private decimal  _cgnum = 0M;
        private string _floor = "";
        private string _moneyremark = "";
        private string _cavecode = "";
        private string _cavename = "";
        private string _msts = "";
        private string _mtts = "";
        private string _maker = "";
        private string _cdate ="";
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
        public string csid
        {
            set { _csid = value; }
            get { return _csid; }
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
        public int gnum
        {
            set { _gnum = value; }
            get { return _gnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
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
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal inum
        {
            set { _inum = value; }
            get { return _inum; }
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
        public string fix
        {
            set { _fix = value; }
            get { return _fix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string locktype
        {
            set { _locktype = value; }
            get { return _locktype; }
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
        public string itype
        {
            set { _itype = value; }
            get { return _itype; }
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
        public int  height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  deep
        {
            set { _deep = value; }
            get { return _deep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fsize
        {
            set { _fsize = value; }
            get { return _fsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  smoney
        {
            set { _smoney = value; }
            get { return _smoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sovermoney
        {
            set { _sovermoney = value; }
            get { return _sovermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sothermoney
        {
            set { _sothermoney = value; }
            get { return _sothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  gmoney
        {
            set { _gmoney = value; }
            get { return _gmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  govermoney
        {
            set { _govermoney = value; }
            get { return _govermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  gothermoney
        {
            set { _gothermoney = value; }
            get { return _gothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  cmoney
        {
            set { _cmoney = value; }
            get { return _cmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  covermoney
        {
            set { _covermoney = value; }
            get { return _covermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  cothermoney
        {
            set { _cothermoney = value; }
            get { return _cothermoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sdiscount
        {
            set { _sdiscount = value; }
            get { return _sdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  gdiscount
        {
            set { _gdiscount = value; }
            get { return _gdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  cdiscount
        {
            set { _cdiscount = value; }
            get { return _cdiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ichange
        {
            set { _ichange = value; }
            get { return _ichange; }
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
        public string isjc
        {
            set { _isjc = value; }
            get { return _isjc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  idiscount
        {
            set { _idiscount = value; }
            get { return _idiscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  allprice
        {
            set { _allprice = value; }
            get { return _allprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  serverprice
        {
            set { _serverprice = value; }
            get { return _serverprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string picname
        {
            set { _picname = value; }
            get { return _picname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string czyy
        {
            set { _czyy = value; }
            get { return _czyy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zsize
        {
            set { _zsize = value; }
            get { return _zsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjname
        {
            set { _zjname = value; }
            get { return _zjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjcode
        {
            set { _zjcode = value; }
            get { return _zjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjmname
        {
            set { _zjmname = value; }
            get { return _zjmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tbcz
        {
            set { _tbcz = value; }
            get { return _tbcz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lxcz
        {
            set { _lxcz = value; }
            get { return _lxcz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tsid
        {
            set { _tsid = value; }
            get { return _tsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cpxz
        {
            set { _cpxz = value; }
            get { return _cpxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjxz
        {
            set { _tjxz = value; }
            get { return _tjxz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string rimg
        {
            set { _rimg = value; }
            get { return _rimg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  priceps
        {
            set { _priceps = value; }
            get { return _priceps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  ghnum
        {
            set { _ghnum = value; }
            get { return _ghnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  cgnum
        {
            set { _cgnum = value; }
            get { return _cgnum; }
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
        public string moneyremark
        {
            set { _moneyremark = value; }
            get { return _moneyremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cavecode
        {
            set { _cavecode = value; }
            get { return _cavecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cavename
        {
            set { _cavename = value; }
            get { return _cavename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string msts
        {
            set { _msts = value; }
            get { return _msts; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtts
        {
            set { _mtts = value; }
            get { return _mtts; }
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
