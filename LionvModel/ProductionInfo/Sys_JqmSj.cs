using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_JqmSj
    {
        #region Model
        private int _id;
        private string _sjname = "";
        private string _mcode = "";
        private string _maker = "";
        private string _cdate ="";
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
        public string sjname
        {
            set { _sjname = value; }
            get { return _sjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
