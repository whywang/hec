using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_FixProduction
    {
        #region Model
        private int _id;
        private string _apname = "";
        private string _apcode;
        private string _apunit = "";
        private decimal _apprice = 0;
        private string _aptype = "";
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
        public string apname
        {
            set { _apname = value; }
            get { return _apname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string apcode
        {
            set { _apcode = value; }
            get { return _apcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string apunit
        {
            set { _apunit = value; }
            get { return _apunit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal apprice
        {
            set { _apprice = value; }
            get { return _apprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string aptype
        {
            set { _aptype = value; }
            get { return _aptype; }
        }
        #endregion Model
    }
}
