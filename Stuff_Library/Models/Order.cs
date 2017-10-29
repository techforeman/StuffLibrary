using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stuff_Library.Models
{
	public class Order
	{
		public int OrderID { get; set; }
		public string UserID { get; set; }
		public virtual ApplicationUser User { get; set; }

		[Required(ErrorMessage ="Musisz wprowadzić imię")]
		[StringLength(150)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Musisz wprowadzić nazwisko")]
		[StringLength(150)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Musisz wprowadzić adres e-mail")]
		[EmailAddress(ErrorMessage ="Błędny format adresu e-mail")]
		public string Email { get; set; }
		public string Comment { get; set; }
		
		public DateTime DateCreated { get; set; }
		public OrderState OrderState { get; set; }

		public List<OrderItem> OrderItem { get; set; }
	}

	public enum OrderState
	{
		New,
		Shipped
	}
}