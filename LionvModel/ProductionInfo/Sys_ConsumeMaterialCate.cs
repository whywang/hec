using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ConsumeMaterialCate
    {
        #region Model
        private int _id;
        private string _cname = "";
        private string _ccode;
        private string _pcname = "";
        private string _pccode = "";
        private bool _isend = true;
        private bool _isuse = true;
        private string _dcode = "";
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
        public string cname
        {
            set { _cname = value; }
            get { return _cname; }
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
        public string ccode
        {
            set { _ccode = value; }
            get { return _ccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcname
        {
            set { _pcname = value; }
            get { return _pcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pccode
        {
            set { _pccode = value; }
            get { return _pccode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isend
        {
            set { _isend = value; }
            get { return _isend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool isuse
        {
            set { _isuse = value; }
            get { return _isuse; }
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
