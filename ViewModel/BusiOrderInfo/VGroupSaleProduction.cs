using System;
using System.Collections.Generic;
using System.Linq ;
using System.Text ;

namespace ViewModel.BusiOrderInfo
{
    public class VGroupSaleProduction
    {
        private string _blcode="";
        private string _blname = "";
        private string _isjc = "";
        private string _ctcode = "";
        private string _ctcz = "";
        private string _ctname = "";
        private string _direction = "";
        private string _fix = "";
        private string _hjcode = "";
        private string _hjcz = "";
        private string _hjname = "";
        private string _hycode = "";
        private string _hyname = "";
        private string _hynum = "";
        private string _invcate = "";
        private string _mscode = "";
        private string _locks = "";
        private string _locktype = "";
        private string _mscz = "";
        private string _msname = "";
        private string _mtcode = "";
        private string _mtcz = "";
        private string _mtname = "";
        private string _ykcode = "";
        private string _wjname = "";
        private string _wjcode = "";
        private string _ykcz = "";
        private string _ykname = "";
        private string _gdname;
        private string _gdcode;
        private string _gdnum;
        private string _dlname;
        private string _dlcode;
        private string _dlnum;
        private string _jyname="";
        private string _jycode="";
        private string _sjcode = "";
        private string _qtname = "";
        private string _qtcz = "";
        private string _qtcode = "";
        private string _pwidth = "0";
        private string _zsize = "0";
        private string _fsize = "0";
        private string _pnum = "0";
        private string _plength = "0";
        private string _place = "";
        private string _pdeep = "0";
        private string _pbz = "";
        private string _sjname = "";
        private string _slblcode = "";
        private string _slblname = "";
        private string _zjname = "";
        private string _zjcode = "";
        private string _zjcz = "";
        private string _zjsname = "";
        private string _zjscode = "";
        private string _zjscz = "";
        private string _tbcz = "";
        private string _lxcz = "";
        private string _cavetype = "";
        private string _mtts = "";
        private string _msts = "";
        private string _mbname = "";
        private string _mbcode = "";
        private string _mbfx = "";
        private string _mbnum = "";
        private string _jstname = "";
        private string _sktname = "";
        private string _sktcode = "";
        private string _sktcz = "";
        private string _sktlx = "";
        private string _stype = ""; // 尺寸类型
        private string _ytcz = "";
        private string _xxline = "";
        private string _mbytcz = "";
        private string _slytcz = "";
        private string _zmsname = "";
        private string _zmscode = "";
        private string _slbname = "";
        private string _sktjc = "0";
        private string _cbjc = "0";
        private string _sxjf = "";
        private string _zyjf = "";
        private string _skttjc = "0";
        private string _fbtmname = "";
        private string _ykzt = "";
        private string _ykyt = "";
        private string _skttcz = "";
        private string _skttname = "";
        private string _skttcode = "";
        private string _gdg = "0";
        private string _gdk = "0";
        private string _zmgdk = "0";
        private string _ydeep = "0";
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
        private string _wlname = "";
        private string _wlcz = "";
        private string _wlcode = "";


        public string cbjc
        {
            get { return _cbjc; }
            set { _cbjc = value; }
        }
        public string sktjc
        {
            get { return _sktjc; }
            set { _sktjc = value; }
        }
        public string skttjc
        {
            get { return _skttjc; }
            set { _skttjc = value; }
        }
        public string slbname
        {
            get { return _slbname; }
            set { _slbname = value; }
        }
        private string _slbcode = "";

        public string slbcode
        {
            get { return _slbcode; }
            set { _slbcode = value; }
        }
        private string _slbnum = "0";

        public string slbnum
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
        public string xxline
        {
            get { return _xxline; }
            set { _xxline = value; }
        }
        public string ytcz
        {
            get { return _ytcz; }
            set { _ytcz = value; }
        }
        public string stype
        {
            get { return _stype; }
            set { _stype = value; }
        }
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
        public string jstname
        {
            get { return _jstname; }
            set { _jstname = value; }
        }
        public string mbnum
        {
            get { return _mbnum; }
            set { _mbnum = value; }
        }
        public string mbfx
        {
            get { return _mbfx; }
            set { _mbfx = value; }
        }
        public string mbcode
        {
            get { return _mbcode; }
            set { _mbcode = value; }
        }
        public string mbname
        {
            get { return _mbname; }
            set { _mbname = value; }
        }
        public string msts
        {
            get { return _msts; }
            set { _msts = value; }
        }

        public string mtts
        {
            get { return _mtts; }
            set { _mtts = value; }
        }
        public string cavetype
        {
            get { return _cavetype; }
            set { _cavetype = value; }
        }
        //产品平台编码
        private string _invprecode = "";
        public string tbcz
        {
            get { return _tbcz; }
            set { _tbcz = value; }
        }
        public string zsize
        {
            get { return _zsize; }
            set { _zsize = value; }
        }
        public string lxcz
        {
            get { return _lxcz; }
            set { _lxcz = value; }
        }
        public string zjname
        {
            get { return _zjname; }
            set { _zjname = value; }
        }
        
        public string zjcode
        {
            get { return _zjcode; }
            set { _zjcode = value; }
        }
    

        public string zjcz
        {
            get { return _zjcz; }
            set { _zjcz = value; }
        }
        public string zjsname
        {
            get { return _zjsname; }
            set { _zjsname = value; }
        }

        public string zjscode
        {
            get { return _zjscode; }
            set { _zjscode = value; }
        }


        public string zjscz
        {
            get { return _zjscz; }
            set { _zjscz = value; }
        }
        public string blname
        {
            get { return _blname; }
            set { _blname = value; }
        }

        public string ctcode
        {
            get { return _ctcode; }
            set { _ctcode = value; }
        }
        
        public string ctcz
        {
            get { return _ctcz; }
            set { _ctcz = value; }
        }
        

        public string ctname
        {
            get { return _ctname; }
            set { _ctname = value; }
        }
      

        public string direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
      

        public string fix
        {
            get { return _fix; }
            set { _fix = value; }
        }
   

        public string hjcode
        {
            get { return _hjcode; }
            set { _hjcode = value; }
        }
        
        public string hjcz
        {
            get { return _hjcz; }
            set { _hjcz = value; }
        }
       

        public string hjname
        {
            get { return _hjname; }
            set { _hjname = value; }
        }
        

        public string hycode
        {
            get { return _hycode; }
            set { _hycode = value; }
        }
        public string jyname
        {
            get { return _jyname; }
            set { _jyname = value; }
        }


        public string jycode
        {
            get { return _jycode; }
            set { _jycode = value; }
        }
       

        public string hyname
        {
            get { return _hyname; }
            set { _hyname = value; }
        }
       

        public string hynum
        {
            get { return _hynum; }
            set { _hynum = value; }
        }
        

        public string invcate
        {
            get { return _invcate; }
            set { _invcate = value; }
        }
        

        public string locktype
        {
            get { return _locktype; }
            set { _locktype = value; }
        }
        
        public string locks
        {
            get { return _locks; }
            set { _locks = value; }
        }
        
        public string mscode
        {
            get { return _mscode; }
            set { _mscode = value; }
        }
        

        public string mscz
        {
            get { return _mscz; }
            set { _mscz = value; }
        }
        

        public string msname
        {
            get { return _msname; }
            set { _msname = value; }
        }
        

        public string mtcode
        {
            get { return _mtcode; }
            set { _mtcode = value; }
        }
        
        public string mtcz
        {
            get { return _mtcz; }
            set { _mtcz = value; }
        }
        

        public string mtname
        {
            get { return _mtname; }
            set { _mtname = value; }
        }
       

        public string pbz
        {
            get { return _pbz; }
            set { _pbz = value; }
        }
       
        public string pdeep
        {
            get { return _pdeep; }
            set { _pdeep = value; }
        }
        
        public string place
        {
            get { return _place; }
            set { _place = value; }
        }
        
        public string plength
        {
            get { return _plength; }
            set { _plength = value; }
        }
        
        public string pnum
        {
            get { return _pnum; }
            set { _pnum = value; }
        }
        
        public string fsize
        {
            get { return _fsize; }
            set { _fsize = value; }
        }
        
        public string pwidth
        {
            get { return _pwidth; }
            set { _pwidth = value; }
        }
        
        public string qtcode
        {
            get { return _qtcode; }
            set { _qtcode = value; }
        }
        
        public string qtcz
        {
            get { return _qtcz; }
            set { _qtcz = value; }
        }
        
        public string qtname
        {
            get { return _qtname; }
            set { _qtname = value; }
        }
       
        public string sjcode
        {
            get { return _sjcode; }
            set { _sjcode = value; }
        }
        
        public string sjname
        {
            get { return _sjname; }
            set { _sjname = value; }
        }
        
        public string slblcode
        {
            get { return _slblcode; }
            set { _slblcode = value; }
        }
        

        public string slblname
        {
            get { return _slblname; }
            set { _slblname = value; }
        }
      

        public string wjcode
        {
            get { return _wjcode; }
            set { _wjcode = value; }
        }
        

        public string wjname
        {
            get { return _wjname; }
            set { _wjname = value; }
        }
       
        public string ykcode
        {
            get { return _ykcode; }
            set { _ykcode = value; }
        }
       
        public string ykcz
        {
            get { return _ykcz; }
            set { _ykcz = value; }
        }
        public string ykname
        {
            get { return _ykname; }
            set { _ykname = value; }
        }
        public string blcode
        {
             get { return _blcode; }
             set { _blcode = value; }
        }
        public string isjc
        {
            get { return _isjc; }
            set { _isjc = value; }
        }
        
        public string gdname
        {
            get { return _gdname; }
            set { _gdname = value; }
        }
        
        public string gdcode
        {
            get { return _gdcode; }
            set { _gdcode = value; }
        }
        
        public string gdnum
        {
            get { return _gdnum; }
            set { _gdnum = value; }
        }
        
        public string dlname
        {
            get { return _dlname; }
            set { _dlname = value; }
        }
        
        public string dlcode
        {
            get { return _dlcode; }
            set { _dlcode = value; }
        }
        
        public string dlnum
        {
            get { return _dlnum; }
            set { _dlnum = value; }
        }
        public string invprecode
        {
            get { return _invprecode; }
            set { _invprecode = value; }
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
        public string gdk
        {
            get { return _gdk; }
            set { _gdk = value; }
        }
        public string gdg
        {
            get { return _gdg; }
            set { _gdg = value; }
        }
        public string zmgdk
        {
            get { return _zmgdk; }
            set { _zmgdk = value; }
        }
        public string ydeep
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
        public string wlcode
        {
            get { return _wlcode; }
            set { _wlcode = value; }
        }

        public string wlcz
        {
            get { return _wlcz; }
            set { _wlcz = value; }
        }

        public string wlname
        {
            get { return _wlname; }
            set { _wlname = value; }
        }
    }
}
