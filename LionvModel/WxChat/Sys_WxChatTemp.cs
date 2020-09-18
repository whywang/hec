using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.WxChat
{
  public  class Sys_WxChatTemp
    {
        #region Model
        private int _id;
        private string _tcode;
        private string _tid = "";
        private string _turl = "";
        private string _ttitle = "";
        private string _tremark = "";
        private string _ttype = "";
        private string _cdate;
        private string _maker = "";
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
        public string tcode
        {
            set { _tcode = value; }
            get { return _tcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tid
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string turl
        {
            set { _turl = value; }
            get { return _turl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttitle
        {
            set { _ttitle = value; }
            get { return _ttitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tremark
        {
            set { _tremark = value; }
            get { return _tremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ttype
        {
            set { _ttype = value; }
            get { return _ttype; }
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
        public string maker
        {
            set { _maker = value; }
            get { return _maker; }
        }
        #endregion Model
    }
}
