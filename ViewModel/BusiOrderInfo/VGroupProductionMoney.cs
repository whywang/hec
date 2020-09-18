using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
    public class VGroupProductionMoney
    {
        private decimal _smgmoney = 0;
        private decimal _smgdisc = 1;
        private decimal _smgdmoney = 0;

        private decimal _gmgmoney = 0;
        private decimal _gmgdisc = 1;
        private decimal _gmgdmoney = 0;

        private decimal _cmgmoney = 0;
        private decimal _cmgdisc = 1;
        private decimal _cmgdmoney = 0;

        public decimal smgmoney { get { return _smgmoney; } set { _smgmoney = value; } }
        public decimal smgdisc { get { return _smgdisc; } set { _smgdisc = value; } }
        public decimal smgdmoney { get { return _smgdmoney; } set { _smgdmoney = value; } }

        public decimal gmgmoney { get { return _gmgmoney; } set { _gmgmoney = value; } }
        public decimal gmgdisc { get { return _gmgdisc; } set { _gmgdisc = value; } }
        public decimal gmgdmoney { get { return _gmgdmoney; } set { _gmgdmoney = value; } }

        public decimal cmgmoney { get { return _cmgmoney; } set { _cmgmoney = value; } }
        public decimal cmgdisc { get { return _cmgdisc; } set { _cmgdisc = value; } }
        public decimal cmgdmoney { get { return _cmgdmoney; } set { _cmgdmoney = value; } }
    }
}
