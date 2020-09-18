using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
   public class ESBParam
    {
        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _actionKey;

        public string actionKey
        {
            get { return _actionKey; }
            set { _actionKey = value; }
        }
        private string _methodName;

        public string methodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }
        private string _applyData;

        public string applyData
        {
            get { return _applyData; }
            set { _applyData = value; }
        }
    }
}
