

				
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Web;

		namespace SWCC.ActiveDirectory.API
		{
			[Serializable]
			public class APIResult
			{
				public string ResultCode { get; set; }
				public string ResultMessage { get; set; }
				public string MoreDetails { get; set; }
				public object ResultObject { get; set; }
			}
		}