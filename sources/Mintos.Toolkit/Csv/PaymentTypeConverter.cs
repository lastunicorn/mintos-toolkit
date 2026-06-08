using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace DustInTheWind.Mintos.Toolkit.Csv;

internal sealed class PaymentTypeConverter : DefaultTypeConverter
{
	public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
	{
		if (string.IsNullOrWhiteSpace(text))
			throw new TypeConverterException(this, memberMapData, text, row.Context, "Transaction type cannot be empty.");

		try
		{
			return new PaymentType(text);
		}
		catch (ArgumentException ex)
		{
			throw new TypeConverterException(this, memberMapData, text, row.Context, ex.Message, ex);
		}
	}

	public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
	{
		return value is PaymentType transactionType
			? transactionType.Value
			: base.ConvertToString(value, row, memberMapData);
	}
}