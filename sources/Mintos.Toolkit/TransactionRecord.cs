namespace DustInTheWind.Mintos.Toolkit;

/// <summary>
/// Represents a transaction.
/// </summary>
public record class TransactionRecord
{
	public DateTime Date { get; set; }

	public string TransactionId { get; set; }

	public string Details { get; set; }

	public decimal Turnover { get; set; }

	public decimal Balance { get; set; }

	public Currency Currency { get; set; }

	public PaymentType PaymentType { get; set; }
}