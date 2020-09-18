using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_EventMenuAttr
    {
        #region Model
        private int _id=0;
        private string _emcode="";
        private string _emname = "";
        private string _dsource = "";
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emname
        {
            set { _emname = value; }
            get { return _emname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dsource
        {
            set { _dsource = value; }
            get { return _dsource; }
        }
        #endregion Model

    }
}
