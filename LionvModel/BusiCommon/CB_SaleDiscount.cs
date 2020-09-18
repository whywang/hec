using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_SaleDiscount
    {
        #region Model
        private int _id;
        private string _sid;
        private string _dname = "";
        private string _dcode = "";
        private string _tjcode = "0";
        private string _tjname="0";
        private string _dtype = "";
        private decimal _dvalue = 0;
        private decimal _dzk;
        private int _tjsort = 0;
        private string _tjfw = "";
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
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
        public string tjname
        {
            set { _tjname = value; }
            get { return _tjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dtype
        {
            set { _dtype = value; }
            get { return _dtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dvalue
        {
            set { _dvalue = value; }
            get { return _dvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dzk
        {
            set { _dzk = value; }
            get { return _dzk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tjsort
        {
            set { _tjsort = value; }
            get { return _tjsort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tjfw
        {
            set { _tjfw = value; }
            get { return _tjfw; }
        }
        #endregion Model

    }
}
