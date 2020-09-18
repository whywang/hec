using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
  public class VOrderMoney
    {
        private decimal _smhjmoney = 0;
        private decimal _smdisc = 1;
        private decimal _smdhjmoney = 0;

        private decimal _gmhjmoney = 0;
        private decimal _gmdisc = 1;
        private decimal _gmdhjmoney = 0;

        private decimal _cmhjmoney = 0;
        private decimal _cmdisc = 1;
        private decimal _cmdhjmoney = 0;

        private decimal _swhjmoney = 0;
        private decimal _swdisc = 1;
        private decimal _swdhjmoney = 0;

        private decimal _gwhjmoney = 0;
        private decimal _gwdisc = 1;
        private decimal _gwdhjmoney = 0;

        private decimal _cwhjmoney = 0;
        private decimal _cwdisc = 1;
        private decimal _cwdhjmoney = 0;

        private decimal _sohjmoney = 0;
        private decimal _sodisc = 1;
        private decimal _sodhjmoney = 0;

        private decimal _gohjmoney = 0;
        private decimal _godisc = 1;
        private decimal _godhjmoney = 0;

        private decimal _cohjmoney = 0;
        private decimal _codisc = 1;
        private decimal _codhjmoney = 0;

        private decimal _pmoney = 0;

        public decimal smhjmoney { get { return _smhjmoney; } set { _smhjmoney = value; } }
        public decimal smdisc { get { return _smdisc; } set { _smdisc = value; } }
        public decimal smdhjmoney { get { return _smdhjmoney; } set { _smdhjmoney = value; } }

        public decimal gmhjmoney { get { return _gmhjmoney; } set { _gmhjmoney = value; } }
        public decimal gmdisc { get { return _gmdisc; } set { _gmdisc = value; } }
        public decimal gmdhjmoney { get { return _gmdhjmoney; } set { _gmdhjmoney = value; } }

        public decimal cmhjmoney { get { return _cmhjmoney; } set { _cmhjmoney = value; } }
        public decimal cmdisc { get { return _cmdisc; } set { _cmdisc = value; } }
        public decimal cmdhjmoney { get { return _cmdhjmoney; } set { _cmdhjmoney = value; } }

        public decimal swhjmoney { get { return _swhjmoney; } set { _swhjmoney = value; } }
        public decimal swdisc { get { return _swdisc; } set { _swdisc = value; } }
        public decimal swdhjmoney { get { return _swdhjmoney; } set { _swdhjmoney = value; } }

        public decimal gwhjmoney { get { return _gwhjmoney; } set { _gwhjmoney = value; } }
        public decimal gwdisc { get { return _gwdisc; } set { _gwdisc = value; } }
        public decimal gwdhjmoney { get { return _gwdhjmoney; } set { _gwdhjmoney = value; }}

        public decimal cwhjmoney { get { return _gwhjmoney; } set { _gwhjmoney = value; } }
        public decimal cwdisc { get { return _gwdisc; } set { _gwdisc = value; } }
        public decimal cwdhjmoney { get { return _gwdhjmoney; } set { _gwdhjmoney = value; } }

        public decimal sohjmoney { get { return _sohjmoney; } set { _sohjmoney = value; } }
        public decimal sodisc { get { return _sodisc; } set { _sodisc = value; } }
        public decimal sodhjmoney { get { return _sodhjmoney; } set { _sodhjmoney = value; } }

        public decimal gohjmoney { get { return _gohjmoney; } set { _gohjmoney = value; } }
        public decimal godisc { get { return _godisc; } set { _godisc = value; } }
        public decimal godhjmoney { get { return _godhjmoney; } set { _godhjmoney = value; } }

        public decimal cohjmoney { get { return _cohjmoney; } set { _cohjmoney = value; } }
        public decimal codisc { get { return _codisc; } set { _codisc = value; } }
        public decimal codhjmoney { get { return _codhjmoney; } set { _codhjmoney = value; } }

        public decimal pmoney { get { return _pmoney; } set { _pmoney = value; } }
    }
}