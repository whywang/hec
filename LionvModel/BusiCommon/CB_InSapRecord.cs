using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_InSapRecord
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _stype = "";
        private int _istate = 0;
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stype
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int istate
        {
            set { _istate = value; }
            get { return _istate; }
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
