namespace InvoiceGenerator
{
	public class InvoiceItem
	{
		public int Quantity { get; set; }
		
		public string Description { get; set; }
		
		public decimal UnitPrice { get; set; }
		
		public decimal Total => Quantity * UnitPrice;
	}
}
