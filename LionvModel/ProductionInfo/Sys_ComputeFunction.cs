using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_ComputeFunction
    {
        public Sys_ComputeFunction()
        { }
        #region Model
        private int _id;
        private string _fname = "";
        private string _fcode = "";
        private string _fattr = "";
        private string _fstr = "";
        private string _ftx = "";
        private string _maker = "";
        private string _cdate = "";
        private string _dcode = "";
        private decimal _fminv = 0;

        
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
        public string fname
        {
            set { _fname = value; }
            get { return _fname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fcode
        {
            set { _fcode = value; }
            get { return _fcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fattr
        {
            set { _fattr = value; }
            get {return _fattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fstr
        {
            set { _fstr = value; }
            get { return _fstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ftx
        {
            set { _ftx = value; }
            get { return _ftx; }
        }
        public decimal fminv
        {
            get { return _fminv; }
            set { _fminv = value; }
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
        /// <summary>
        /// 
        /// </summary>
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model

    }
}
