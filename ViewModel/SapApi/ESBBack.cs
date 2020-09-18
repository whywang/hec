using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
   public class ESBBack
    {
        private string _resultStauts;

        public string resultStauts
        {
            get { return _resultStauts; }
            set { _resultStauts = value; }
        }
        private string _resultDesc;

        public string resultDesc
        {
            get { return _resultDesc; }
            set { _resultDesc = value; }
        }
        private string _resultData;

        public string resultData
        {
            get { return _resultData; }
            set { _resultData = value; }
        }
    }
}
