using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_ServiceImg
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _iurl = "";
        private string _itype = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iurl
        {
            set { _iurl = value; }
            get { return _iurl; }
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
