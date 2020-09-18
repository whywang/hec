using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
    public class VInHouseOrder
    {
        private string _code = "";

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _ycode = "";

        public string ycode
        {
            get { return _ycode; }
            set { _ycode = value; }
        }
        private string _dname = "";

        public string dname
        {
            get { return _dname; }
            set { _dname = value; }
        }
        private string _city = "";

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _customer = "";

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _address = "";

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _telephone = "";

        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        private string _fname = "";

        public string fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        private string _zt = "";

        public string zt
        {
            get { return _zt; }
            set { _zt = value; }
        }
        private string _bnum = "0";

        public string bnum
        {
            get { return _bnum; }
            set { _bnum = value; }
        }
        private string _bz;

        public string bz
        {
            get { return _bz; }
            set { _bz = value; }
        }
    }
}
