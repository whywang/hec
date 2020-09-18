using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
    //反馈报价单显示
   public class VAOrderPrice
    {
        private string _omoney = "0";

        public string omoney
        {
            get { return _omoney; }
            set { _omoney = value; }
        }
        private string _fname = "";

        public string fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        private string _pfid = "0";

        public string pfid
        {
            get { return _pfid; }
            set { _pfid = value; }
        }
        private string _ohtm = "";

        public string ohtm
        {
            get { return _ohtm; }
            set { _ohtm = value; }
        }
        private string _bshow = "0";

        public string bshow
        {
            get { return _bshow; }
            set { _bshow = value; }
        }
    }
}
