using Aspose.Words;
using Aspose.Words.Reporting;
using InvoiceGenerator;

var data = new InvoiceData
{
	InvoiceDate = DateTime.Now.ToShortDateString(),
	InvoiceNumber = "100",
	CustomerID = "ABC12345",
	CustomerName = "Anjali Chaturvedi",
	CustomerCompany = "Extra Frame Photography",
	CustomerAddress = "89 Pacific Ave\nSan Francisco, CA",
	CustomerPhone = "123-456-7890",
	Salesperson = "Oscar Ward",
	Job = "Sales",
	PaymentTerms = "Due on receipt",
	DueDate = "1/30/23",
	Items = new List<InvoiceItem>
			{
				new InvoiceItem { Quantity = 10, Description = "20” x 30” hanging frames", UnitPrice = 15.00M },
				new InvoiceItem { Quantity = 50, Description = "5” x 7” standing frames", UnitPrice = 5.00M }
			}
};

string templatePath = "Templates/InvoiceTemplate.docx";
Document doc = new Document(templatePath);
ReportingEngine engine = new ReportingEngine();
engine.BuildReport(doc, data, "Invoice");

doc.Save("Invoice_Filled.docx");

Console.WriteLine("Invoice created using template syntax.");