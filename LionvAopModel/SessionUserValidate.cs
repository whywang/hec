using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using System.Collections;

namespace LionvAopModel
{
   public class SessionUserValidate
    {
       private Sys_Employee _u = null;

       public Sys_Employee u
        {
            get { return _u; }
            set { _u = value; }
        }
        private string _badstr = null;

        public string badstr
        {
            get { return _badstr; }
            set { _badstr = value; }
        }
        private bool _f = false;

        public bool f
        {
            get { return _f; }
            set { _f = value; }
        }
    }
}
