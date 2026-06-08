namespace DustInTheWind.Mintos.Toolkit;

public class TransactionRecord
{
	public DateTime Date { get; init; }

	public string TransactionId { get; init; }

	public string Details { get; init; }

	public decimal Turnover { get; init; }

	public decimal Balance { get; init; }

	public Currency Currency { get; init; }

	public PaymentType PaymentType { get; init; }
}