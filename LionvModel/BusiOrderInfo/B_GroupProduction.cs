using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    /// </summary>
    [Serializable]
    public class B_GroupProduction
    {
        public B_GroupProduction()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _psid = "";
        private int _gnum = 0;
        private string _iname = "";
        private string _icode = "";
        private string _mname = "";
        private string _uname = "";
        private decimal _inum = 0;
        private string _place = "";
        private string _direction = "";
        private string _fix = "";
        private string _itype = "";
        private string _locktype = "";
        private string _locks = "";
        private int _height = 0;
        private int _width = 0;
        private int _deep = 0;
        private int _fsize = 0;
        private int _zsize = 0;
        private string _ptype = "";
        private decimal _smoney = 0;
        private decimal _sovermoney = 0;
        private decimal _sothermoney = 0;
        private decimal _gmoney = 0;
        private decimal _govermoney = 0;
        private decimal _gothermoney = 0;
        private decimal _cmoney = 0;
        private decimal _covermoney = 0;
        private decimal _cothermoney = 0;
        private decimal _sdiscount = 0;
        private decimal _gdiscount = 0;
        private decimal _cdiscount = 0;
        private decimal _allprice = 0;
        private decimal _serverprice = 0;
        private string _pic = "";
        private int _ichange = 0;
        private string _ps = "";
        private string _isjc = "";
        private int _idiscount = 0;
        private string _czyy = "";
        private string _picname = "";
        private string _maker = "";
        private string _cdate ;
        private string _zjname = "";
        private string _zjcode = "";
        private string _zjmname="";
        private string _zjsname = "";
        private string _zjscode = "";
        private string _zjsmname = "";
        private string _rimg = "";
        private string _priceps = "";
        private string _tbcz = "";
        private string _lxcz = "";
        private decimal _ghnum = 0;
        private decimal _cgnum = 0;
        private string _cpxz = "";
        private string _tjxz = "";
        private string _floor = "";
        private string _moneyremark = "";
        private string _cavename = "";
        private string _cavecode = "";
        ///产品套色
        private string _msts = "";
        private string _mtts = "";
        private string _csid = "";
        private string _spec = "";//规格
        private string _ggy = "";
        private string _gfx = "";
        private string _jstname = "";
        private string _jstcode = "";
        private string _ytcz = "";
        private string _mbname = "";
        private string _mbytcz = "";
        private string _slytcz = "";
        private string _sktname = "";
        private string _sktcode = "";
        private string _sktcz = "";
        private string _sktlx = "";
        private string _stype = ""; // 尺寸类型
        private string _xxline = ""; // 尺寸类型
        private string _zmsname = "";
        private string _zmscode = "";
        private string _slbname = "";
        private int _sktjc = 0;
        private int _skttjc = 0;
        private int _cbjc = 0;
        private string _slbcode = "";
        private int _slbnum = 0;
        private string _mbcode = "";
        private string _mbfx = "";
        private int _mbnum = 0;
        private string _sxjf = "";
        private string _zyjf = "";
        private string _fbtmname = "";
        private string _ykzt = "";
        private string _ykyt = "";
        private string _skttcz = "";
        private string _skttname = "";
        private string _skttcode = "";
        private int _gdg = 0;
        private int _gdk = 0;
        private int _zmgdk = 0;
        private int _ydeep = 0;
        private string _ykacb = "";
        private string _ykhjft = "";
        private string _ykhjfw = "";
        private string _ykhq = "";
        private string _ykscb = "";
        private string _yksjft = "";
        private string _yksjtw = "";
        private string _ykycb = "";
        private string _ykzcb = "";
        private string _msfmcz = "";


        public string sktlx
        {
            get { return _sktlx; }
            set { _sktlx = value; }
        }
        public string sktcz
        {
            get { return _sktcz; }
            set { _sktcz = value; }
        }
        public string sktcode
        {
            get { return _sktcode; }
            set { _sktcode = value; }
        }
        public string sktname
        {
            get { return _sktname; }
            set { _sktname = value; }
        }
        public string mbname
        {
            get { return _mbname; }
            set { _mbname = value; }
        }
        public string mbcode
        {
            get { return _mbcode; }
            set { _mbcode = value; }
        }
        public string mbfx
        {
            get { return _mbfx; }
            set { _mbfx = value; }
        }
        public int mbnum
        {
            get { return _mbnum; }
            set { _mbnum = value; }
        }
        public string spec
        {
            get { return _spec; }
            set { _spec = value; }
        }
        public string csid
        {
            get { return _csid; }
            set { _csid = value; }
        }
        public string mtts
        {
            get { return _mtts; }
            set { _mtts = value; }
        }
        public string msts
        {
            get { return _msts; }
            set { _msts = value; }
        }
        public string cavename
        {
            get { return _cavename; }
            set { _cavename = value; }
        }
        public string cavecode
        {
            get { return _cavecode; }
            set { _cavecode = value; }
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
        public string itype
        {
            set { _itype = value; }
            get { return _itype; }
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
        public int height
        {
            set { _height = value; }
            get { return _height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int width
        {
            set { _width = value; }
            get { return _width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int deep
        {
            set { _deep = value; }
            get { return _deep; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int fsize
        {
            set { _fsize = value; }
            get { return _fsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int zsize
        {
            set { _zsize = value; }
            get { return _zsize; }
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
        public decimal ghnum
        {
            set { _ghnum = value; }
            get { return _ghnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal cgnum
        {
            set { _cgnum = value; }
            get { return _cgnum; }
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
        public decimal allprice
        {
            set { _allprice = value; }
            get { return _allprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal serverprice
        {
            set { _serverprice = value; }
            get { return _serverprice; }
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
        public int ichange
        {
            set { _ichange = value; }
            get { return _ichange; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int idiscount
        {
            set { _idiscount = value; }
            get { return _idiscount; }
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
        public string tjxz
        {
            set { _tjxz = value; }
            get { return _tjxz; }
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
        public string czyy
        {
            set { _czyy = value; }
            get { return _czyy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string picname
        {
            set { _picname= value; }
            get { return _picname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        public string ptype
        {
            set { _ptype = value; }
            get { return _ptype; }
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
        public string priceps
        {
            set { _priceps = value; }
            get { return _priceps; }
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
        public string tsid { get; set; }
        public string cpxz
        {
            set { _cpxz = value; }
            get { return _cpxz; }
        }
        public string floor
        {
            set { _floor = value; }
            get { return _floor; }
        }
        public string moneyremark
        {
            set { _moneyremark = value; }
            get { return _moneyremark; }
        }
        public string ggy
        {
            get { return _ggy; }
            set { _ggy = value; }
        }
        public string gfx
        {
            get { return _gfx; }
            set { _gfx = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jstname
        {
            set { _jstname = value; }
            get { return _jstname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jstcode
        {
            set { _jstcode = value; }
            get { return _jstcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ytcz
        {
            set { _ytcz = value; }
            get { return _ytcz; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xxline
        {
            set { _xxline = value; }
            get { return _xxline; }
        }
        public string slytcz
        {
            set { _slytcz = value; }
            get { return _slytcz; }
        }
        public string mbytcz
        {
            set { _mbytcz = value; }
            get { return _mbytcz; }
        }
        public int cbjc
        {
            get { return _cbjc; }
            set { _cbjc = value; }
        }
        public int sktjc
        {
            get { return _sktjc; }
            set { _sktjc = value; }
        }
        public int skttjc
        {
            get { return _skttjc; }
            set { _skttjc = value; }
        }
        public string slbname
        {
            get { return _slbname; }
            set { _slbname = value; }
        }
        public int slbnum
        {
            get { return _slbnum; }
            set { _slbnum = value; }
        }
        public string zmsname
        {
            get { return _zmsname; }
            set { _zmsname = value; }
        }
        public string zmscode
        {
            get { return _zmscode; }
            set { _zmscode = value; }
        }
        public string stype
        {
            get { return _stype; }
            set { _stype = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjscode
        {
            set { _zjscode = value; }
            get { return _zjscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjsmname
        {
            set { _zjsmname = value; }
            get { return _zjsmname; }
        }
        public string zjsname
        {
            set { _zjsname = value; }
            get { return _zjsname; }
        }
        public string slbcode
        {
            get { return _slbcode; }
            set { _slbcode = value; }
        }
        public string sxjf
        {
            set { _sxjf = value; }
            get { return _sxjf; }
        }
        public string zyjf
        {
            get { return _zyjf; }
            set { _zyjf = value; }
        }
        public string fbtmname
        {
            get { return _fbtmname; }
            set { _fbtmname = value; }
        }
        public string ykzt
        {
            get { return _ykzt; }
            set { _ykzt = value; }
        }
        public string ykyt
        {
            get { return _ykyt; }
            set { _ykyt = value; }
        }
        public string skttname
        {
            get { return _skttname; }
            set { _skttname = value; }
        }
        public string skttcz
        {
            get { return _skttcz; }
            set { _skttcz = value; }
        }
        public string skttcode
        {
            get { return _skttcode; }
            set { _skttcode = value; }
        }
        public int gdk
        {
            get { return _gdk; }
            set { _gdk = value; }
        }
        public int gdg
        {
            get { return _gdg; }
            set { _gdg = value; }
        }
        public int zmgdk
        {
            get { return _zmgdk; }
            set { _zmgdk = value; }
        }
        public int ydeep
        {
            get { return _ydeep; }
            set { _ydeep = value; }
        }
        public string ykacb
        {
            get { return _ykacb; }
            set { _ykacb = value; }
        }
        public string ykhjft
        {
            get { return _ykhjft; }
            set { _ykhjft = value; }
        }
        public string ykhjfw
        {
            get { return _ykhjfw; }
            set { _ykhjfw = value; }
        }
        public string ykhq
        {
            get { return _ykhq; }
            set { _ykhq = value; }
        }
        public string ykscb
        {
            get { return _ykscb; }
            set { _ykscb = value; }
        }
        public string yksjft
        {
            get { return _yksjft; }
            set { _yksjft = value; }
        }
        public string yksjtw
        {
            get { return _yksjtw; }
            set { _yksjtw = value; }
        }
        public string ykycb
        {
            get { return _ykycb; }
            set { _ykycb = value; }
        }
        public string ykzcb
        {
            get { return _ykzcb; }
            set { _ykzcb = value; }
        }
        public string msfmcz
        {
            get { return _msfmcz; }
            set { _msfmcz = value; }
        }
        #endregion Model
    }
}
