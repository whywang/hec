using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_GlassCraft
    {
        #region Model
        private int _id;
        private string _gcname = "";
        private string _gccode;
        private string _maker = "";
        private string _cdate = "";
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
        public string gcname
        {
            set { _gcname = value; }
            get { return _gcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gccode
        {
            set { _gccode = value; }
            get { return _gccode; }
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
