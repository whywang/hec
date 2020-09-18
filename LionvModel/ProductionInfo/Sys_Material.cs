using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_Material
    {
        public Sys_Material()
        { }
        #region Model
        private int _id;
        private string _mname;
        private string _mcode;
        private string _mcname = "";
        private string _mccode = "";
        private bool _mstate = true;
        private string _maker = "";
        private string _cdate = "";
        private string _mtype = "";

        public string mtype
        {
            get { return _mtype; }
            set { _mtype = value; }
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
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcode
        {
            set { _mcode = value; }
            get { return _mcode; }
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
        public bool mstate
        {
            set { _mstate = value; }
            get { return _mstate; }
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
