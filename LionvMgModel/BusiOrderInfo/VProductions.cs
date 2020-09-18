using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvMgModel
{
    public class VProductions
    {
        private string _id = "";

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _vid = "";

        public string vid
        {
            get { return _vid; }
            set { _vid = value; }
        }

        private string _sid = "";

        public string sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        private int _gnum = 0;

        public int gnum
        {
            get { return _gnum; }
            set { _gnum = value; }
        }
        private string _htmtext = "";

        public string htmtext
        {
            get { return _htmtext; }
            set { _htmtext = value; }
        }
        private string _vtype = "";

        public string vtype
        {
            get { return _vtype; }
            set { _vtype = value; }
        }
    }
}
