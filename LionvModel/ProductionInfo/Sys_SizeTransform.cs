using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SizeTransform
    {
        public Sys_SizeTransform()
        { }

        #region Model
        private int _id;
        private string _jname = "";
        private string _jcode = "";
        private string _jtype = "";
        private string _fixmethod = "";
        private string _mcomputermethod = "";
        private int  _dg = 0;
        private int  _dk = 0;
        private int  _dh = 0;
        private int  _d1sl = 0;
        private int  _d2sl = 0;
        private decimal  _d1k = 0M;
        private decimal  _d2k = 0M;
        private decimal _d1g = 0M;
        private decimal  _d2g=0M;
        private string _mtg = "0";
        private string _mtk = "0";
        private string _mth = "0";
        private int  _mtsl = 0;
        private string  _mtge = "0";
        private string  _mtke = "0";
        private string  _mthe = "0";
        private int  _mtsle = 0;
        private string  _lbg = "0";
        private string  _lbk = "0";
        private string  _lbh = "0";
        private int  _lbsl = 0;
        private string  _lbge ="0" ;
        private string  _lbke = "0";
        private string  _lbhe = "0";
        private int  _lbsle = 0;
        private string  _stlg = "0";
        private string  _stlk = "0";
        private string  _stlh = "0";
        private int  _stlsl = 0;
        private string _stleg = "0";
        private string _stlek = "0";
        private string _stleh = "0";
        private int  _stlesl = 0;
        private string _mtsg = "0";
        private string _mtsk = "0";
        private string _mtsh = "0";
        private int  _mtssl = 0;
        private string _ltlg = "0";
        private string _ltlk = "0";
        private string _ltlh = "0";
        private int  _ltlsl = 0;
        private string _ltleg = "0";
        private string _ltlek = "0";
        private string _ltleh = "0";
        private int  _ltlesl = 0;
        private string _lbsg = "0";
        private string _lbsk = "0";
        private string _lbsh = "0";
        private int  _lbssl = 0;
        private string _tlhg ="0" ;
        private string _tlhk ="0";
        private string _tlhh ="0";
        private int  _tlhsl = 0;
        private string _tlh2g = "0";
        private string _tlh2k = "0";
        private string _tlh2h = "0";
        private int  _tlh2sl = 0;
        private string _dzg = "0";
        private string _dzk = "0";
        private string _dzh = "0";
        private int  _dzsl = 0;
        private string _dmxg = "0";
        private string _dmxk = "0";
        private string _dmxh = "0";
        private int  _dmxsl = 0;
        private string _mentg = "0";
        private string _mentk = "0";
        private string _menth = "0";
        private int  _mentsl = 0;
        private string _hmdxg = "0";
        private string _hmdxk = "0";
        private string _hmdxh = "0";
        private int  _hmdxsl = 0;
        private string _lmdxg = "0";
        private string _lmdxk = "0";
        private string _lmdxh = "0";
        private int  _lmdxsl = 0;
        private string _slg = "0";
        private string _slk = "0";
        private string _slh = "0";
        private int  _slsl = 0;
        private int  _sljs = 0;
        private string _slhlg = "0";
        private string  _slhlk = "0";
        private string _slhlh = "0";
        private int  _slhlsl = 0;
        private string _slslg = "0";
        private string _slslk = "0";
        private string _slslh = "0";
        private int  _slslsl = 0;
        private string _mtbg = "0";
        private string _mtbk = "0";
        private string _mtbh = "0";
        private int  _mtbsl = 0;
        private string _mtbeg = "0";
        private string _mtbek = "0";
        private string _mtbeh = "0";
        private int  _mtbesl = 0;
        private string _tlhdg = "0";
        private string _tlhdk = "0";
        private string _tlhdh = "0";
        private int  _tlhdsl = 0;
        private string _tlhcg = "0";
        private string _tlhck = "0";
        private string _tlhch = "0";
        private int  _tlhcsl = 0;
        private string _tlhgg = "0";
        private string _tlhgk = "0";
        private string _tlhgh = "0";
        private int  _tlhgsl = 0;
        private string _skxg = "0";
        private string _skxk = "0";
        private string _skxh = "0";
        private int  _skxsl = 0;
        private string _blytg = "0";
        private string _blytk = "0";
        private string _blyth = "0";
        private int  _blytsl = 0;
        private string _blyteg = "0";
        private string _blytek = "0";
        private string _blyteh = "0";
        private int _blytesl = 0;
        private string _maker = "";
        private string  _cdate = "";
        private string _dcode = "";
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
        public string jname
        {
            set { _jname = value; }
            get { return _jname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jcode
        {
            set { _jcode = value; }
            get { return _jcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jtype
        {
            set { _jtype = value; }
            get { return _jtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fixmethod
        {
            set { _fixmethod = value; }
            get { return _fixmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcomputermethod
        {
            set { _mcomputermethod = value; }
            get { return _mcomputermethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dg
        {
            set { _dg = value; }
            get { return _dg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dk
        {
            set { _dk = value; }
            get { return _dk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dh
        {
            set { _dh = value; }
            get { return _dh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  d1sl
        {
            set { _d1sl = value; }
            get { return _d1sl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  d2sl
        {
            set { _d2sl = value; }
            get { return _d2sl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  d1k
        {
            set { _d1k = value; }
            get { return _d1k; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  d2k
        {
            set { _d2k = value; }
            get { return _d2k; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal d1g
        {
            set { _d1g = value; }
            get { return _d1g; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  d2g
        {
            set { _d2g = value; }
            get { return _d2g; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  mtg
        {
            set { _mtg = value; }
            get { return _mtg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtk
        {
            set { _mtk = value; }
            get { return _mtk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mth
        {
            set { _mth = value; }
            get { return _mth; }
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
        public string mtge
        {
            set { _mtge = value; }
            get { return _mtge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  mtke
        {
            set { _mtke = value; }
            get { return _mtke; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mthe
        {
            set { _mthe = value; }
            get { return _mthe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtsle
        {
            set { _mtsle = value; }
            get { return _mtsle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  lbg
        {
            set { _lbg = value; }
            get { return _lbg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbk
        {
            set { _lbk = value; }
            get { return _lbk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbh
        {
            set { _lbh = value; }
            get { return _lbh; }
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
        public string  lbge
        {
            set { _lbge = value; }
            get { return _lbge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbke
        {
            set { _lbke = value; }
            get { return _lbke; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbhe
        {
            set { _lbhe = value; }
            get { return _lbhe; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbsle
        {
            set { _lbsle = value; }
            get { return _lbsle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stlg
        {
            set { _stlg = value; }
            get { return _stlg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stlk
        {
            set { _stlk = value; }
            get { return _stlk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stlh
        {
            set { _stlh = value; }
            get { return _stlh; }
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
        public string stleg
        {
            set { _stleg = value; }
            get { return _stleg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stlek
        {
            set { _stlek = value; }
            get { return _stlek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stleh
        {
            set { _stleh = value; }
            get { return _stleh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  stlesl
        {
            set { _stlesl = value; }
            get { return _stlesl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtsg
        {
            set { _mtsg = value; }
            get { return _mtsg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  mtsk
        {
            set { _mtsk = value; }
            get { return _mtsk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtsh
        {
            set { _mtsh = value; }
            get { return _mtsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtssl
        {
            set { _mtssl = value; }
            get { return _mtssl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  ltlg
        {
            set { _ltlg = value; }
            get { return _ltlg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ltlk
        {
            set { _ltlk = value; }
            get { return _ltlk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ltlh
        {
            set { _ltlh = value; }
            get { return _ltlh; }
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
        public string ltleg
        {
            set { _ltleg = value; }
            get { return _ltleg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ltlek
        {
            set { _ltlek = value; }
            get { return _ltlek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ltleh
        {
            set { _ltleh = value; }
            get { return _ltleh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  ltlesl
        {
            set { _ltlesl = value; }
            get { return _ltlesl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbsg
        {
            set { _lbsg = value; }
            get { return _lbsg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  lbsk
        {
            set { _lbsk = value; }
            get { return _lbsk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lbsh
        {
            set { _lbsh = value; }
            get { return _lbsh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lbssl
        {
            set { _lbssl = value; }
            get { return _lbssl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  tlhg
        {
            set { _tlhg = value; }
            get { return _tlhg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhk
        {
            set { _tlhk = value; }
            get { return _tlhk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhh
        {
            set { _tlhh = value; }
            get { return _tlhh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tlhsl
        {
            set { _tlhsl = value; }
            get { return _tlhsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  tlh2g
        {
            set { _tlh2g = value; }
            get { return _tlh2g; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlh2k
        {
            set { _tlh2k = value; }
            get { return _tlh2k; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlh2h
        {
            set { _tlh2h = value; }
            get { return _tlh2h; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tlh2sl
        {
            set { _tlh2sl = value; }
            get { return _tlh2sl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dzg
        {
            set { _dzg = value; }
            get { return _dzg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dzk
        {
            set { _dzk = value; }
            get { return _dzk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dzh
        {
            set { _dzh = value; }
            get { return _dzh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dzsl
        {
            set { _dzsl = value; }
            get { return _dzsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmxg
        {
            set { _dmxg = value; }
            get { return _dmxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmxk
        {
            set { _dmxk = value; }
            get { return _dmxk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dmxh
        {
            set { _dmxh = value; }
            get { return _dmxh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  dmxsl
        {
            set { _dmxsl = value; }
            get { return _dmxsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mentg
        {
            set { _mentg = value; }
            get { return _mentg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mentk
        {
            set { _mentk = value; }
            get { return _mentk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menth
        {
            set { _menth = value; }
            get { return _menth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mentsl
        {
            set { _mentsl = value; }
            get { return _mentsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hmdxg
        {
            set { _hmdxg = value; }
            get { return _hmdxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hmdxk
        {
            set { _hmdxk = value; }
            get { return _hmdxk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hmdxh
        {
            set { _hmdxh = value; }
            get { return _hmdxh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  hmdxsl
        {
            set { _hmdxsl = value; }
            get { return _hmdxsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lmdxg
        {
            set { _lmdxg = value; }
            get { return _lmdxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lmdxk
        {
            set { _lmdxk = value; }
            get { return _lmdxk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lmdxh
        {
            set { _lmdxh = value; }
            get { return _lmdxh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  lmdxsl
        {
            set { _lmdxsl = value; }
            get { return _lmdxsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slg
        {
            set { _slg = value; }
            get { return _slg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slk
        {
            set { _slk = value; }
            get { return _slk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slh
        {
            set { _slh = value; }
            get { return _slh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  slsl
        {
            set { _slsl = value; }
            get { return _slsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  sljs
        {
            set { _sljs = value; }
            get { return _sljs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slhlg
        {
            set { _slhlg = value; }
            get { return _slhlg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  slhlk
        {
            set { _slhlk = value; }
            get { return _slhlk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slhlh
        {
            set { _slhlh = value; }
            get { return _slhlh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  slhlsl
        {
            set { _slhlsl = value; }
            get { return _slhlsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slslg
        {
            set { _slslg = value; }
            get { return _slslg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  slslk
        {
            set { _slslk = value; }
            get { return _slslk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string slslh
        {
            set { _slslh = value; }
            get { return _slslh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  slslsl
        {
            set { _slslsl = value; }
            get { return _slslsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbg
        {
            set { _mtbg = value; }
            get { return _mtbg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbk
        {
            set { _mtbk = value; }
            get { return _mtbk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbh
        {
            set { _mtbh = value; }
            get { return _mtbh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtbsl
        {
            set { _mtbsl = value; }
            get { return _mtbsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbeg
        {
            set { _mtbeg = value; }
            get { return _mtbeg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbek
        {
            set { _mtbek = value; }
            get { return _mtbek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtbeh
        {
            set { _mtbeh = value; }
            get { return _mtbeh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  mtbesl
        {
            set { _mtbesl = value; }
            get { return _mtbesl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhdg
        {
            set { _tlhdg = value; }
            get { return _tlhdg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhdk
        {
            set { _tlhdk = value; }
            get { return _tlhdk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhdh
        {
            set { _tlhdh = value; }
            get { return _tlhdh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tlhdsl
        {
            set { _tlhdsl = value; }
            get { return _tlhdsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhcg
        {
            set { _tlhcg = value; }
            get { return _tlhcg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhck
        {
            set { _tlhck = value; }
            get { return _tlhck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhch
        {
            set { _tlhch = value; }
            get { return _tlhch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tlhcsl
        {
            set { _tlhcsl = value; }
            get { return _tlhcsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhgg
        {
            set { _tlhgg = value; }
            get { return _tlhgg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhgk
        {
            set { _tlhgk = value; }
            get { return _tlhgk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tlhgh
        {
            set { _tlhgh = value; }
            get { return _tlhgh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  tlhgsl
        {
            set { _tlhgsl = value; }
            get { return _tlhgsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string skxg
        {
            set { _skxg = value; }
            get { return _skxg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string skxk
        {
            set { _skxk = value; }
            get { return _skxk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string skxh
        {
            set { _skxh = value; }
            get { return _skxh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  skxsl
        {
            set { _skxsl = value; }
            get { return _skxsl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blytg
        {
            set { _blytg = value; }
            get { return _blytg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blytk
        {
            set { _blytk = value; }
            get { return _blytk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blyth
        {
            set { _blyth = value; }
            get { return _blyth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  blytsl
        {
            set { _blytsl = value; }
            get { return _blytsl; }
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
        public string  cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
   
        /// <summary>
        /// 
        /// </summary>
        public string blyteg
        {
            set { _blyteg = value; }
            get { return _blyteg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blytek
        {
            set { _blytek = value; }
            get { return _blytek; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string blyteh
        {
            set { _blyteh = value; }
            get { return _blyteh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int blytesl
        {
            set { _blytesl = value; }
            get { return _blytesl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model
    }
}
