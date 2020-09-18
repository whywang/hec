using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_SizeFormatPart
    {
        #region Model
        private int _id;
        private string _bjcname = "";
        private string _bjname;
        private string _bjcode;
        private string _bjctype;
        private string _bjattr;
        private string _bjattrex = "";
        private string _ftype = "";
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
        public string bjcname
        {
            set { _bjcname = value; }
            get { return _bjcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjname
        {
            set { _bjname = value; }
            get { return _bjname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjcode
        {
            set { _bjcode = value; }
            get { return _bjcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjctype
        {
            set { _bjctype = value; }
            get { return _bjctype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjattr
        {
            set { _bjattr = value; }
            get { return _bjattr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bjattrex
        {
            set { _bjattrex = value; }
            get { return _bjattrex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ftype
        {
            set { _ftype = value; }
            get { return _ftype; }
        }
        #endregion Model

    }
}
