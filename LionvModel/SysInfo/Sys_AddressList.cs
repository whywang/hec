using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.SysInfo
{
   public class Sys_AddressList
    {
        #region Model
        private int _id;
        private string _aname = "";
        private string _adname = "";
        private string _adcode = "";
        private string _tel1 = "";
        private string _ftel = "";
        private string _tel2 = "";
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
        public string aname
        {
            set { _aname = value; }
            get { return _aname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adname
        {
            set { _adname = value; }
            get { return _adname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string adcode
        {
            set { _adcode = value; }
            get { return _adcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel1
        {
            set { _tel1 = value; }
            get { return _tel1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ftel
        {
            set { _ftel = value; }
            get { return _ftel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel2
        {
            set { _tel2 = value; }
            get { return _tel2; }
        }
        #endregion Model

    }
}
