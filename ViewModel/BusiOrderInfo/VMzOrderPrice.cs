using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
   public class VMzOrderPrice
    {
        private string _dmoney = "0";

        public string dmoney
        {
            get { return _dmoney; }
            set { _dmoney = value; }
        }
        private string _omoney = "0";

        public string omoney
        {
            get { return _omoney; }
            set { _omoney = value; }
        }
        private string _pfname = "";

        public string pfname
        {
            get { return _pfname; }
            set { _pfname = value; }
        }
        private string _pfid = "";

        public string pfid
        {
            get { return _pfid; }
            set { _pfid = value; }
        }
        private string _djhtm = "";

        public string djhtm
        {
            get { return _djhtm; }
            set { _djhtm = value; }
        }
        private string _omhtm = "";

        public string omhtm
        {
            get { return _omhtm; }
            set { _omhtm = value; }
        }
        private string _bshow = "0";

        public string bshow
        {
            get { return _bshow; }
            set { _bshow = value; }
        }
    }
}
