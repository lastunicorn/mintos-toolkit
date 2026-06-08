using CsvHelper.Configuration;

namespace DustInTheWind.Mintos.Toolkit.Csv;

internal sealed class TransactionRecordMap : ClassMap<TransactionRecord>
{
	public TransactionRecordMap()
	{
		Map(x => x.Date)
			.Name("Date");

		Map(x => x.TransactionId)
			.Name("Transaction ID:");

		Map(x => x.Details)
			.Name("Details");

		Map(x => x.Turnover)
			.Name("Turnover");

		Map(x => x.Balance)
			.Name("Balance");

		Map(x => x.Currency)
			.Name("Currency")
			.TypeConverter<CurrencyConverter>();

		Map(x => x.PaymentType)
			.Name("Payment Type")
			.TypeConverter<PaymentTypeConverter>();
	}
}