using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.BusiCommon
{
   public class CB_ProcessRecord
    {
        #region Model
		private int _id;
		private string _sid="";
		private int _jid=0;
		private string _rtext="";
		private string _jdname="";
		private string _maker="";
		private string _cdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sid
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int jid
		{
			set{ _jid=value;}
			get{return _jid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rtext
		{
			set{ _rtext=value;}
			get{return _rtext;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jdname
		{
			set{ _jdname=value;}
			get{return _jdname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maker
		{
			set{ _maker=value;}
			get{return _maker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cdate
		{
			set{ _cdate=value;}
			get{return _cdate;}
		}
		#endregion Model

    }
}
