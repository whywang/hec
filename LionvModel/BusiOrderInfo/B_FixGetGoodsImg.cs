using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_FixGetGoodsImg
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _url = "";
        private string _fixer = "";
        private string _gdate;
        private string _ps = "";
        private string _maker = "";
        private string _cdate ="";
        private string _domain;

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
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fixer
        {
            set { _fixer = value; }
            get { return _fixer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string gdate
        {
            set { _gdate = value; }
            get { return _gdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ps
        {
            set { _ps = value; }
            get { return _ps; }
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
        public string domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        #endregion Model
    }
}
