using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Tables;

namespace DustInTheWind.Mintos.Toolkit.Demo;

internal static class Program
{
	public static async Task Main(string[] args)
	{
		const string fileName = "statement.csv";

		try
		{
			StatementDocument document = await StatementDocument.LoadFromFileAsync(fileName);

			DataGrid dataGrid = Display(document);
			dataGrid.Display();
		}
		catch (DocumentLoadException ex)
		{
			await Console.Error.WriteLineAsync($"Failed to read '{fileName}': {ex.Message}");
			Environment.ExitCode = 1;
		}
		catch (Exception ex)
		{
			await Console.Error.WriteLineAsync($"Unexpected error: {ex.Message}");
			Environment.ExitCode = 1;
		}
	}

	private static DataGrid Display(StatementDocument document)
	{
		DataGrid dataGrid = new()
		{
			Title = "Transactions",
			BorderTemplate = BorderTemplate.PlusMinusBorderTemplate,
			Footer = $"Count: {document.Count}"
		};

		dataGrid.Columns.Add("Date");
		dataGrid.Columns.Add("Transaction ID");
		dataGrid.Columns.Add("Details");
		dataGrid.Columns.Add("Turnover", HorizontalAlignment.Right);
		dataGrid.Columns.Add("Balance", HorizontalAlignment.Right);
		dataGrid.Columns.Add("Currency", HorizontalAlignment.Right);
		dataGrid.Columns.Add("Payment Type");

		foreach (TransactionRecord transaction in document)
			dataGrid.Rows.Add(
				transaction.Date.ToString("yyyy-MM-dd HH:mm:ss"),
				transaction.TransactionId,
				transaction.Details,
				transaction.Turnover.ToString(),
				transaction.Balance.ToString(),
				transaction.Currency,
				transaction.PaymentType);

		return dataGrid;
	}
}