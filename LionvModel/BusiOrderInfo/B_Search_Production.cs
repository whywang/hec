using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public  class B_Search_Production
    {
        #region Model
        private int _pid;
        private int _oid;
        private string _sid;
        private string _iname;
        private string _icode;
        private string _iunit;
        private string _mname;
        private string _place;
        private string _fix;
        private string _direction;
        private int  _width=0;
        private int _height = 0;
        private int _deep = 0;
        private int _fwidth = 0;
        private int _fheight = 0;
        private int _fdeep = 0;
        private int _fnum = 0;
        private decimal _fmoney = 0;
        private int _fchange = 0;
        private decimal _fcmoney = 0;
        private int _swidth = 0;
        private int _sheight = 0;
        private int _sdeep = 0;
        private int _snum = 0;
        private decimal _smoney = 0;
        private int _schange = 0;
        private decimal _scmoney = 0;
        private string _tname;
        private string _tcode;
        private string _tmname;
        private string _tunit;
        private int _twidth = 0;
        private int _theight = 0;
        private int _tdeep = 0;
        private int _tnum = 0;
        private decimal _tmoney = 0;
        private int _mtchange = 0;
        private decimal _mtcmoney = 0;
        private int _ltlw = 0;
        private int _ltlh = 0;
        private int _ltld = 0;
        private int _ltlsl = 0;
        private int _stlw = 0;
        private int _stlh = 0;
        private int _stld = 0;
        private int _stlsl = 0;
        private int _mtw = 0;
        private int _mth = 0;
        private int _mtd = 0;
        private int _mtsl = 0;
        private int _lbw = 0;
        private int _lbh = 0;
        private int _lbd = 0;
        private int _lbsl = 0;
        private string _blname;
        private string _blcode;
        private int _blnum = 0;
        private decimal _blmoney = 0;
        private decimal _glasspmoney = 0;
        private string _sjname;
        private int _sjnum = 0;
        private string _sjcode;
        private string _sjmname;
        private string _remark;
        private decimal _pmoney = 0;
        private int _pjc = 0;
        private string _hyname;
        private int _fsnum = 0;
        private decimal _ffwsmoney = 0;
        private int _ffwchange = 0;
        private decimal _fxsmoney = 0;
        private int _fxschange = 0;
        private decimal _fghmoeny = 0;
        private int _fghchange = 0;
        private decimal _dmfghmoney = 0;
        private int _dmfghchange = 0;
        private int _ssnum = 0;
        private decimal _sfwmoney = 0;
        private int _sfwchange = 0;
        private decimal _sxsmoney = 0;
        private int _sxschange = 0;
        private decimal _sghmoney = 0;
        private int _sghchange = 0;
        private decimal _dmsghmoney = 0;
        private int _dmsghchange = 0;
        private int _mtsnum = 0;
        private decimal _mtsmoney = 0;
        private int _mtschange = 0;
        private decimal _mtxsmoney = 0;
        private int _mtxschange = 0;
        private decimal _mtghmoney = 0;
        private int _mtghchange = 0;
        private int _dmmtghmoney = 0;
        private decimal _dmmtghchange = 0;
        /// <summary>
        /// 
        /// </summary>
        public int pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int oid
        {
            set { _oid = value; }
            get { return _oid; }
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
        public string iunit
        {
            set { _iunit = value; }
            get { return _iunit; }
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
        public string place
        {
            set { _place = value; }
            get { return _place; }
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
        public string direction
        {
            set { _direction = value; }
            get { return _direction; }
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
        public int  height
        {
            set { _height = value; }
            get { return _height; }
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
        public int  fwidth
        {
            set { _fwidth = value; }
            get { return _fwidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fheight
        {
            set { _fheight = value; }
            get { return _fheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fdeep
        {
            set { _fdeep = value; }
            get { return _fdeep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fnum
        {
            set { _fnum = value; }
            get { return _fnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  fmoney
        {
            set { _fmoney = value; }
            get { return _fmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fchange
        {
            set { _fchange = value; }
            get { return _fchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  fcmoney
        {
            set { _fcmoney = value; }
            get { return _fcmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  swidth
        {
            set { _swidth = value; }
            get { return _swidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sheight
        {
            set { _sheight = value; }
            get { return _sheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sdeep
        {
            set { _sdeep = value; }
            get { return _sdeep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  snum
        {
            set { _snum = value; }
            get { return _snum; }
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
        public int  schange
        {
            set { _schange = value; }
            get { return _schange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  scmoney
        {
            set { _scmoney = value; }
            get { return _scmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tname
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tmname
        {
            set { _tmname = value; }
            get { return _tmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tunit
        {
            set { _tunit = value; }
            get { return _tunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  twidth
        {
            set { _twidth = value; }
            get { return _twidth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  theight
        {
            set { _theight = value; }
            get { return _theight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tdeep
        {
            set { _tdeep = value; }
            get { return _tdeep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tnum
        {
            set { _tnum = value; }
            get { return _tnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  tmoney
        {
            set { _tmoney = value; }
            get { return _tmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtchange
        {
            set { _mtchange = value; }
            get { return _mtchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  mtcmoney
        {
            set { _mtcmoney = value; }
            get { return _mtcmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ltlw
        {
            set { _ltlw = value; }
            get { return _ltlw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ltlh
        {
            set { _ltlh = value; }
            get { return _ltlh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ltld
        {
            set { _ltld = value; }
            get { return _ltld; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ltlsl
        {
            set { _ltlsl = value; }
            get { return _ltlsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  stlw
        {
            set { _stlw = value; }
            get { return _stlw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  stlh
        {
            set { _stlh = value; }
            get { return _stlh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  stld
        {
            set { _stld = value; }
            get { return _stld; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  stlsl
        {
            set { _stlsl = value; }
            get { return _stlsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtw
        {
            set { _mtw = value; }
            get { return _mtw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mth
        {
            set { _mth = value; }
            get { return _mth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtd
        {
            set { _mtd = value; }
            get { return _mtd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtsl
        {
            set { _mtsl = value; }
            get { return _mtsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbw
        {
            set { _lbw = value; }
            get { return _lbw; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbh
        {
            set { _lbh = value; }
            get { return _lbh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbd
        {
            set { _lbd = value; }
            get { return _lbd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbsl
        {
            set { _lbsl = value; }
            get { return _lbsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blname
        {
            set { _blname = value; }
            get { return _blname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blcode
        {
            set { _blcode = value; }
            get { return _blcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  blnum
        {
            set { _blnum = value; }
            get { return _blnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  blmoney
        {
            set { _blmoney = value; }
            get { return _blmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal glasspmoney
        {
            set { _glasspmoney = value; }
            get { return _glasspmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sjname
        {
            set { _sjname = value; }
            get { return _sjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sjnum
        {
            set { _sjnum = value; }
            get { return _sjnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sjcode
        {
            set { _sjcode = value; }
            get { return _sjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sjmname
        {
            set { _sjmname = value; }
            get { return _sjmname; }
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
        public decimal  pmoney
        {
            set { _pmoney = value; }
            get { return _pmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  pjc
        {
            set { _pjc = value; }
            get { return _pjc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hyname
        {
            set { _hyname = value; }
            get { return _hyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fsnum
        {
            set { _fsnum = value; }
            get { return _fsnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  ffwsmoney
        {
            set { _ffwsmoney = value; }
            get { return _ffwsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ffwchange
        {
            set { _ffwchange = value; }
            get { return _ffwchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  fxsmoney
        {
            set { _fxsmoney = value; }
            get { return _fxsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fxschange
        {
            set { _fxschange = value; }
            get { return _fxschange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  fghmoeny
        {
            set { _fghmoeny = value; }
            get { return _fghmoeny; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  fghchange
        {
            set { _fghchange = value; }
            get { return _fghchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  dmfghmoney
        {
            set { _dmfghmoney = value; }
            get { return _dmfghmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmfghchange
        {
            set { _dmfghchange = value; }
            get { return _dmfghchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ssnum
        {
            set { _ssnum = value; }
            get { return _ssnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sfwmoney
        {
            set { _sfwmoney = value; }
            get { return _sfwmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sfwchange
        {
            set { _sfwchange = value; }
            get { return _sfwchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sxsmoney
        {
            set { _sxsmoney = value; }
            get { return _sxsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sxschange
        {
            set { _sxschange = value; }
            get { return _sxschange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sghmoney
        {
            set { _sghmoney = value; }
            get { return _sghmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sghchange
        {
            set { _sghchange = value; }
            get { return _sghchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  dmsghmoney
        {
            set { _dmsghmoney = value; }
            get { return _dmsghmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmsghchange
        {
            set { _dmsghchange = value; }
            get { return _dmsghchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtsnum
        {
            set { _mtsnum = value; }
            get { return _mtsnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  mtsmoney
        {
            set { _mtsmoney = value; }
            get { return _mtsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtschange
        {
            set { _mtschange = value; }
            get { return _mtschange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  mtxsmoney
        {
            set { _mtxsmoney = value; }
            get { return _mtxsmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtxschange
        {
            set { _mtxschange = value; }
            get { return _mtxschange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  mtghmoney
        {
            set { _mtghmoney = value; }
            get { return _mtghmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtghchange
        {
            set { _mtghchange = value; }
            get { return _mtghchange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmmtghmoney
        {
            set { _dmmtghmoney = value; }
            get { return _dmmtghmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  dmmtghchange
        {
            set { _dmmtghchange = value; }
            get { return _dmmtghchange; }
        }
        #endregion Model

    }
}
