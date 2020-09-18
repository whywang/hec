using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
    public class Sys_ProduceImg
    {

        public Sys_ProduceImg()
        { }
        #region Model
        private int _id;
        private string _iname = "";
        private string _icode = "";
        private string _iurl = "";
        private string _ifurl = "";
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
        public string iname
        {
            set { _iname = value; }
            get { return _iname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string icode
        {
            set { _icode = value; }
            get { return _icode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string iurl
        {
            set { _iurl = value; }
            get { return _iurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ifurl
        {
            set { _ifurl = value; }
            get { return _ifurl; }
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
