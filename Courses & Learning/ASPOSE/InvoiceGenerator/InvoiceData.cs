namespace InvoiceGenerator
{
	public class InvoiceData
	{
		public string InvoiceDate { get; set; }

		public string InvoiceNumber { get; set; }

		public string CustomerID { get; set; }

		public string CustomerName { get; set; }

		public string CustomerCompany { get; set; }

		public string CustomerAddress { get; set; }

		public string CustomerPhone { get; set; }

		public string Salesperson { get; set; }

		public string Job { get; set; }

		public string PaymentTerms { get; set; }

		public string DueDate { get; set; }

		public List<InvoiceItem> Items { get; set; }

		public decimal Subtotal => Items.Sum(i => i.Total);

		public decimal SalesTax => Subtotal * 0.05M;

		public decimal Total => Subtotal + SalesTax;
	}
}
