using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_MaterialCategory
    {
        public Sys_MaterialCategory()
        { }
        #region Model
        private int _id;
        private string _mcname;
        private string _mccode;
        private string _mcpname = "";
        private string _mcpcode = "";
        private bool _mcstate = true;
        private string _maker = "";
        private string _cdate ="";
        private string _dcode = "";
        private string _mtype = "";
        private string _btype = "";
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
        public string mcname
        {
            set { _mcname = value; }
            get { return _mcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mccode
        {
            set { _mccode = value; }
            get { return _mccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcpname
        {
            set { _mcpname = value; }
            get { return _mcpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcpcode
        {
            set { _mcpcode = value; }
            get { return _mcpcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool mcstate
        {
            set { _mcstate = value; }
            get { return _mcstate; }
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
        public string btype
        {
            set { _btype = value; }
            get { return _btype; }
        }
        #endregion Model
    }
}
