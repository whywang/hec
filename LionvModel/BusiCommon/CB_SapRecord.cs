using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
    public class CB_SapRecord
    {
        #region Model
        private int _id;
        private string _sid;
        private string _backstr="";
        private string _mstr="";
        private string _itype="";
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
        public string itype
        {
            set { _itype = value; }
            get { return _itype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mstr
        {
            set { _mstr = value; }
            get { return _mstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string backstr
        {
            set { _backstr = value; }
            get { return _backstr; }
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
