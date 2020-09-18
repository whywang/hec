using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_WjBom
    {
        #region Model
        private int _id;
        private string _icode = "";
        private string _bname = "";
        private string _bcode;
        private string _becode = "";
        private decimal _bprice = 0;
        private decimal _bnum =0;
        private string _bunit = "";
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
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bname
        {
            set { _bname = value; }
            get { return _bname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bcode
        {
            set { _bcode = value; }
            get { return _bcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string becode
        {
            set { _becode = value; }
            get { return _becode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bnum
        {
            set { _bnum = value; }
            get { return _bnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bprice
        {
            set { _bprice = value; }
            get { return _bprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cdate
        {
            set { _cdate = value; }
            get { return _cdate; }
        }

        public string bunit
        {
            get { return _bunit; }
            set { _bunit = value; }
        }
        #endregion Model
    }
}
