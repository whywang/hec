using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_PackageDate
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _bsid = "";
        private string _bdate="";
        private string _insdate = "";
        private string _outsdate="";
        private string _incdate="";
        private string _outcdate = "";
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
        public string bsid
        {
            set { _bsid = value; }
            get { return _bsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bdate
        {
            set { _bdate = value; }
            get { return _bdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string insdate
        {
            set { _insdate = value; }
            get { return _insdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string outsdate
        {
            set { _outsdate = value; }
            get { return _outsdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string incdate
        {
            set { _incdate = value; }
            get { return _incdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string outcdate
        {
            set { _outcdate = value; }
            get { return _outcdate; }
        }
        #endregion Model
    }
}
