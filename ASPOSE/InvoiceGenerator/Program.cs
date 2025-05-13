using Aspose.Words;
using Aspose.Words.Replacing;

string templatePath = "Templates/InvoiceTemplate.docx";
var doc = new Document(templatePath);

// Define the placeholders and their values
var replacements = new Dictionary<string, string>
		{
			{ "<<InvoiceDate>>", DateTime.Now.ToShortDateString() },
			{ "<<InvoiceNumber>>", "100" },
			{ "<<CustomerID>>", "ABC12345" },
			{ "<<CustomerName>>", "Anjali Chaturvedi" },
			{ "<<CustomerCompany>>", "Extra Frame Photography" },
			{ "<<CustomerAddress>>", "89 Pacific Ave\nSan Francisco, CA" },
			{ "<<CustomerPhone>>", "123-456-7890" },
			{ "<<Salesperson>>", "Oscar Ward" },
			{ "<<Job>>", "Sales" },
			{ "<<PaymentTerms>>", "Due on receipt" },
			{ "<<DueDate>>", "1/30/23" },
			{ "<<Qty>>", "10" },
			{ "<<Description>>", "20” x 30” hanging frames" },
			{ "<<UnitPrice>>", "15.00" },
			{ "<<LineTotal>>", "150.00" },
			{ "<<Subtotal>>", "400.00" },
			{ "<<SalesTax>>", "20.00" },
			{ "<<Total>>", "420.00" }
		};

// Replace all placeholders
foreach (var pair in replacements)
{
	doc.Range.Replace(pair.Key, pair.Value, new FindReplaceOptions());
}

// Save the result
doc.Save("Invoice_Completed.docx");

Console.WriteLine("Invoice generated successfully.");