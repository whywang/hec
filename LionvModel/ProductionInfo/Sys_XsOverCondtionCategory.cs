using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_XsOverCondtionCategory
    {
        #region Model
        private int _id;
        private string _oname = "";
        private string _ocode;
        private string _ounit = "";
        private string _otype = "";
        private string _maker = "";
        private string _cdate;
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
        public string ounit
        {
            set { _ounit = value; }
            get { return _ounit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string otype
        {
            set { _otype = value; }
            get { return _otype; }
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
