using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_CgNomalSize
    {
        public Sys_CgNomalSize()
        { }
        #region Model
        private int _id;
        private string _ncode;
        private string _nname = "";
        private string _ntype = "";
        private decimal _olen = 0;
        private decimal _owid = 0;
        private decimal _odee = 0;
        private decimal _ofc = 0;
        private decimal _tlen = 0;
        private decimal _twid = 0;
        private decimal _tdee = 0;
        private string _cdate;
        private string _maker = "";
        private string _dcode = "";
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
        public string ncode
        {
            set { _ncode = value; }
            get { return _ncode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nname
        {
            set { _nname = value; }
            get { return _nname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ntype
        {
            set { _ntype = value; }
            get { return _ntype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal olen
        {
            set { _olen = value; }
            get { return _olen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal owid
        {
            set { _owid = value; }
            get { return _owid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal odee
        {
            set { _odee = value; }
            get { return _odee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ofc
        {
            set { _ofc = value; }
            get { return _ofc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tlen
        {
            set { _tlen = value; }
            get { return _tlen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal twid
        {
            set { _twid = value; }
            get { return _twid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tdee
        {
            set { _tdee = value; }
            get { return _tdee; }
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
