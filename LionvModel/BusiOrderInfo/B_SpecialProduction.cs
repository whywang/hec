using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiOrderInfo
{
   public class B_SpecialProduction
    {
        #region Model
        private int _id;
        private string _sid;
        private string _gsid;
        private string _tjname = "";
        private string _tjcode = "";
        private decimal _tsprice=0;
        private decimal _tgprice=0;
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
        public string tjname
        {
            set { _tjname = value; }
            get { return _tjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjcode
        {
            set { _tjcode = value; }
            get { return _tjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tsprice
        {
            set { _tsprice = value; }
            get { return _tsprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tgprice
        {
            set { _tgprice = value; }
            get { return _tgprice; }
        }
        #endregion Model

    }
}
