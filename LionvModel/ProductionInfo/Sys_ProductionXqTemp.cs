using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_ProductionXqTemp
    {
      
        #region Model
        private int _id;
        private string _qtname = "";
        private string _qtcode;
        private string _dcode = "";
        private string _qtype = "";
        private bool _qread = false;
        private string _qttemp = "";
        private string _qtemp = "";
        private string _maker = "";
        private string _cdate;
        private string _emcode = "";

        public string emcode
        {
            get { return _emcode; }
            set { _emcode = value; }
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
        public string qtname
        {
            set { _qtname = value; }
            get { return _qtname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qtcode
        {
            set { _qtcode = value; }
            get { return _qtcode; }
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
        public string qtype
        {
            set { _qtype = value; }
            get { return _qtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool qread
        {
            set { _qread = value; }
            get { return _qread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qttemp
        {
            set { _qttemp = value; }
            get { return _qttemp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string qtemp
        {
            set { _qtemp = value; }
            get { return _qtemp; }
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
