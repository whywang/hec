using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_SelectProduceImg
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _xsid = "";
        private string _xpname = "";
        private string _xpurl = "";
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
        public string xsid
        {
            set { _xsid = value; }
            get { return _xsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xpname
        {
            set { _xpname = value; }
            get { return _xpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xpurl
        {
            set { _xpurl = value; }
            get { return _xpurl; }
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
