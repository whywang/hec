using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.Api
{
   public class API_yy
    {
        #region Model
        private int _id;
        private string _dname = "";
        private string _dcode;
        private string _yycode = "";
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
        public string dname
        {
            set { _dname = value; }
            get { return _dname; }
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
        public string yycode
        {
            set { _yycode = value; }
            get { return _yycode; }
        }
        #endregion Model
    }
}
