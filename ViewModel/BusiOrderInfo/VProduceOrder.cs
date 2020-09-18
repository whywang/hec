using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
   public class VProduceOrder
    {
        string _code = "";

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        string _ycode = "";

        public string ycode
        {
            get { return _ycode; }
            set { _ycode = value; }
        }
        string _dname = "";

        public string dname
        {
            get { return _dname; }
            set { _dname = value; }
        }
        string _otype = "";

        public string otype
        {
            get { return _otype; }
            set { _otype = value; }
        }
        string _fname = "";

        public string fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        string _scdate = "";

        public string scdate
        {
            get { return _scdate; }
            set { _scdate = value; }
        }
        string _customer = "";

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        string _bz = "";

        public string bz
        {
            get { return _bz; }
            set { _bz = value; }
        }
        string _address = "";

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        string _overdate = "";

        public string overdate
        {
            get { return _overdate; }
            set { _overdate = value; }
        }
        private string _duty = "";
        public string duty
        {
            get { return _duty; }
            set { _duty = value; }
        }
        private string _reason = "";
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        private string _city = "";
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
    }
}
