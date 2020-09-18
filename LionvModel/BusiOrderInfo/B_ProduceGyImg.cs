using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_ProduceGyImg
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _gsid = "";
        private string _gname = "";
        private string _gurl = "";
        private string _cdate;
        private string _maker = "";
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
        public string gname
        {
            set { _gname = value; }
            get { return _gname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gurl
        {
            set { _gurl = value; }
            get { return _gurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        #endregion Model
    }
}
