using System;
using Newtonsoft.Json;

namespace QMSales
{
	public class QMSalesContact
	{
		public QMSalesContact ()
		{
		}

			[JsonProperty(PropertyName = "ID")]
			public string ID { get; set; }

			[JsonProperty(PropertyName = "FirstName")]
			public string FirstName { get; set; }

			[JsonProperty(PropertyName = "LastName")]
			public string LastName { get; set; }

			[JsonProperty(PropertyName = "PhoneNumber")]
			public string PhoneNumber { get; set; }

			[JsonProperty(PropertyName = "Email")]
			public string Email { get; set; }

			[JsonProperty(PropertyName = "Address")]
			public string Address { get; set; }

			[JsonProperty(PropertyName = "User")]
			public string User { get; set; }

//			[JsonProperty(PropertyName = "ObjectACL")]
//			public ParseACL ObjectACL { get; set; }


		}
}

