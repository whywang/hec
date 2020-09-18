using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    [Serializable]
    public class Sys_Package
    {
        public Sys_Package()
        { }
        #region Model
        private int _id;
        private string _pname = "";
        private string _pcode;
        private int _basenum = 0;
        private string _zjtype = "";
        private string _istz = "";
        private int _tznum = 0;
        private string _psort = "";
        private int _maxnum = 0;
        private int _hlvalue = 0;
        private int _htvalue = 0;
        private int _klvalue = 0;
        private int _ktvalue = 0;
        private string _maker = "";
        private string _cdate;
        private string _cptype="";
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
        public string pname
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pcode
        {
            set { _pcode = value; }
            get { return _pcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int basenum
        {
            set { _basenum = value; }
            get { return _basenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zjtype
        {
            set { _zjtype = value; }
            get { return _zjtype; }
        }
        /// <summary>
        /// 是否为套装
        /// </summary>
        public string istz
        {
            set { _istz = value; }
            get { return _istz; }
        }
        /// <summary>
        /// 套装件数
        /// </summary>
        public int tznum
        {
            set { _tznum = value; }
            get { return _tznum; }
        }
        /// <summary>
        /// 包装顺序
        /// </summary>
        public string psort
        {
            set { _psort = value; }
            get { return _psort; }
        }
        /// <summary>
        /// 包装最大件数
        /// </summary>
        public int maxnum
        {
            set { _maxnum = value; }
            get { return _maxnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int hlvalue
        {
            set { _hlvalue = value; }
            get { return _hlvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int htvalue
        {
            set { _htvalue = value; }
            get { return _htvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int klvalue
        {
            set { _klvalue = value; }
            get { return _klvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ktvalue
        {
            set { _ktvalue = value; }
            get { return _ktvalue; }
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
        public string cptype
        {
            set { _cptype = value; }
            get { return _cptype; }
        }
        public string dcode
        {
            set { _dcode = value; }
            get { return _dcode; }
        }
        #endregion Model

    }
}
