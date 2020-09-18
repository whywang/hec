using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
   public class VPayOrder
    {
        private string _code = "";

        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _city = "";

        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _dname = "";

        public string dname
        {
            get { return _dname; }
            set { _dname = value; }
        }
        private string _dcode = "";

        public string dcode
        {
            get { return _dcode; }
            set { _dcode = value; }
        }
        private string _customer = "";

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _yingshou = "";

        public string yingshou
        {
            get { return _yingshou; }
            set { _yingshou = value; }
        }
        private string _yishou = "";

        public string yishou
        {
            get { return _yishou; }
            set { _yishou = value; }
        }
        private string _weishou = "";

        public string weishou
        {
            get { return _weishou; }
            set { _weishou = value; }
        }
        private string _settlment = "";

        public string settlment
        {
            get { return _settlment; }
            set { _settlment = value; }
        }
        private string _bjr = "";
        public string bjr
        {
            get { return _bjr; }
            set { _bjr = value; }
        }
        private string _telephone = "";
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
    }
}
