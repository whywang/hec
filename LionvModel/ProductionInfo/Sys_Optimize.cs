using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_Optimize
    {
        public Sys_Optimize()
        { }
        #region Model
        private int _id;
        private string _oname = "";
        private string _ocode = "";
        private string _mtype = "";
        private string _stype = "";
        private string _ocols = "";
        private string _pcols = "";
        private string _cdate="";
        private string _maker="";
        private string _dcode = "";

        public string dcode
        {
            get { return _dcode; }
            set { _dcode = value; }
        }
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
        public string oname
        {
            set { _oname = value; }
            get { return _oname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ocode
        {
            set { _ocode = value; }
            get { return _ocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mtype
        {
            set { _mtype = value; }
            get { return _mtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stype
        {
            set { _stype = value; }
            get { return _stype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ocols
        {
            set { _ocols = value; }
            get { return _ocols; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcols
        {
            set { _pcols = value; }
            get { return _pcols; }
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
