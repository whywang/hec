using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_CodeRecorder
    {
        #region Model
        private int _id;
        private string _sid = "";
        private string _emcode = "";
        private int _ynum = 0;
        private string _areatype = "";
        private string _citytype = "";
        private string _cdate = "";
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
        public string sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string emcode
        {
            set { _emcode = value; }
            get { return _emcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ynum
        {
            set { _ynum = value; }
            get { return _ynum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string areatype
        {
            set { _areatype = value; }
            get { return _areatype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string citytype
        {
            set { _citytype = value; }
            get { return _citytype; }
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
