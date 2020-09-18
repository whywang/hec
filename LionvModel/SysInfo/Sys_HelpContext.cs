using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_HelpContext
    {
        #region Model
        private int _id;
        private string _hcode;
        private string _hname = "";
        private string _hcontext = "";
        private string _maker = "";
        private string _cdate;
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
        public string hcode
        {
            set { _hcode = value; }
            get { return _hcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hname
        {
            set { _hname = value; }
            get { return _hname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hcontext
        {
            set { _hcontext = value; }
            get { return _hcontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        #endregion Model
    }
}
