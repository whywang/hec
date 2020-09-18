using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
    /// </summary>
    [Serializable]
    public partial class B_Attachment
    {
        public B_Attachment()
        { }
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _ftype = "";
        private string _fname = "";
        private string _furl = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gsid
        {
            set { _gsid = value; }
            get { return _gsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ftype
        {
            set { _ftype = value; }
            get { return _ftype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string furl
        {
            set { _furl = value; }
            get { return _furl; }
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
