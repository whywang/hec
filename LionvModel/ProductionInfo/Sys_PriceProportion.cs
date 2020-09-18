using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_PriceProportion
    {
        public Sys_PriceProportion()
        { }
        #region Model
        private int _id;
        private string _ppname = "";
        private string _ppcode;
        private decimal _ppbl = 0;
        private decimal _pcbbl = 0;
        private decimal _pqtbl = 0;
        private string _pbz = "";
        private string _maker = "";
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
        public string ppname
        {
            set { _ppname = value; }
            get { return _ppname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ppcode
        {
            set { _ppcode = value; }
            get { return _ppcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ppbl
        {
            set { _ppbl = value; }
            get { return _ppbl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pcbbl
        {
            set { _pcbbl = value; }
            get { return _pcbbl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal pqtbl
        {
            set { _pqtbl = value; }
            get { return _pqtbl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pbz
        {
            set { _pbz = value; }
            get { return _pbz; }
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
