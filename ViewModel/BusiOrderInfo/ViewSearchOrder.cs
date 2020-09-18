using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.BusiOrderInfo
{
   public class ViewSearchOrder
    {
        private string _nsid;

        public string nsid
        {
            get { return _nsid; }
            set { _nsid = value; }
        }
        private string _osid;

        public string osid
        {
            get { return _osid; }
            set { _osid = value; }
        }
        private string _nfid;

        public string nfid
        {
            get { return _nfid; }
            set { _nfid = value; }
        }
        private string _ofid;

        public string ofid
        {
            get { return _ofid; }
            set { _ofid = value; }
        }
    }
}
