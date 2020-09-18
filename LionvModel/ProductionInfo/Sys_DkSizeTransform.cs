using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionvModel.ProductionInfo
{
   public class Sys_DkSizeTransform
   {
       #region
        private int _id;
		private string _sfname="";
		private string _sfcode;
		private string _ntdh="";
		private string _wtdh="";
		private string _ntdw="";
		private string _wtdw="";
		private string _bdcode="";
		private string _cdate="";
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
		public string sfname
		{
			set{ _sfname=value;}
			get{return _sfname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sfcode
		{
			set{ _sfcode=value;}
			get{return _sfcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ntdh
		{
			set{ _ntdh=value;}
			get{return _ntdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wtdh
		{
			set{ _wtdh=value;}
			get{return _wtdh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ntdw
		{
			set{ _ntdw=value;}
			get{return _ntdw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string wtdw
		{
			set{ _wtdw=value;}
			get{return _wtdw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bdcode
		{
			set{ _bdcode=value;}
			get{return _bdcode;}
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
