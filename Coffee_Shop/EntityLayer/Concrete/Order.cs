using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
		public string OrderName { get; set; }

		public double OrderPrice { get; set; }

		public string? OrderUrl { get; set; }
		public int OrderCount { get; set; }
		public int RegisterID { get; set; }
		public int OrderStatus {  get; set; }
		public Register Register { get; set; }	
	}
}
