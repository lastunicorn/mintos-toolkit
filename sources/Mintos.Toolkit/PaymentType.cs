namespace DustInTheWind.Mintos.Toolkit;

/// <summary>
/// Value object that represents a transaction payment type.
/// The underlying value is the string used in the Payment Type column of the CSV statement file.
/// Make sure to export the CSV file in english from Mintos website. 
/// </summary>
public sealed record class PaymentType : IComparable<PaymentType>, IComparable<string>
{
	public static readonly PaymentType BondInterestIncome = new("Bond interest income");
	public static readonly PaymentType BondInvestmentPrincipalIncrease = new("Bond investment principal increase");
	public static readonly PaymentType BondTaxWithholding = new("Bond tax withholding");
	public static readonly PaymentType Bonus = new("Bonus");
	public static readonly PaymentType CashOutShareIncomeToSeller = new("Cash out share income to seller");
	public static readonly PaymentType DelayedInterestIncomeOnTransitRebuy = new("Delayed interest income on transit rebuy");
	public static readonly PaymentType Deposits = new("Deposits");
	public static readonly PaymentType InterestReceived = new("Interest received");
	public static readonly PaymentType InterestReceivedFromLoanRepurchase = new("Interest received from loan repurchase");
	public static readonly PaymentType InterestReceivedFromPendingPayments = new("Interest received from pending payments");
	public static readonly PaymentType Investment = new("Investment");
	public static readonly PaymentType LateFeesReceived = new("Late fees received");
	public static readonly PaymentType MintosCoreFee = new("Mintos Core fee");
	public static readonly PaymentType MintosCustomLoansFee = new("Mintos Custom Loans fee");
	public static readonly PaymentType PrincipalReceived = new("Principal received");
	public static readonly PaymentType PrincipalReceivedFromLoanRepurchase = new("Principal received from loan repurchase");
	public static readonly PaymentType PrincipalReceivedFromRepurchaseOfSmallLoanParts = new("Principal received from repurchase of small loan parts");
	public static readonly PaymentType RealEstateInterestIncome = new("Real estate interest income");
	public static readonly PaymentType RealEstateInvestmentPrincipalIncrease = new("Real estate investment principal increase");
	public static readonly PaymentType RealEstateTaxWithholding = new("Real estate tax withholding");
	public static readonly PaymentType SecondaryMarketTransaction = new("Secondary market transaction");
	public static readonly PaymentType SecondaryMarketTransactionDiscountOrPremium = new("Secondary market transaction - discount or premium");
	public static readonly PaymentType TaxWithholding = new("Tax withholding");
	public static readonly PaymentType Withdrawal = new("Withdrawal");

	/// <summary>
	/// While <see cref="PaymentType"/> may hold any string value, this collection of known values is provided for convenience.
	/// Take note that the collection may not be exhaustive, as Mintos may introduce new payment types in the future.
	/// </summary>
	public static readonly IReadOnlyCollection<PaymentType> KnownValues =
	[
		BondInterestIncome,
		BondInvestmentPrincipalIncrease,
		BondTaxWithholding,
		Bonus,
		CashOutShareIncomeToSeller,
		DelayedInterestIncomeOnTransitRebuy,
		Deposits,
		InterestReceived,
		InterestReceivedFromLoanRepurchase,
		InterestReceivedFromPendingPayments,
		Investment,
		LateFeesReceived,
		MintosCoreFee,
		MintosCustomLoansFee,
		PrincipalReceived,
		PrincipalReceivedFromLoanRepurchase,
		PrincipalReceivedFromRepurchaseOfSmallLoanParts,
		RealEstateInterestIncome,
		RealEstateInvestmentPrincipalIncrease,
		RealEstateTaxWithholding,
		SecondaryMarketTransaction,
		SecondaryMarketTransactionDiscountOrPremium,
		TaxWithholding,
		Withdrawal
	];

	public string Value { get; }

	public PaymentType(string value)
	{
		Value = value ?? throw new ArgumentNullException(nameof(value));
	}

	public override string ToString()
	{
		return Value;
	}

	public static implicit operator PaymentType(string value)
	{
		return value == null
			? null
			: new PaymentType(value);
	}

	public static implicit operator string(PaymentType paymentType)
	{
		return paymentType?.Value;
	}

	public int CompareTo(PaymentType other)
	{
		if (ReferenceEquals(this, other)) return 0;
		if (other is null) return 1;
		return string.Compare(Value, other.Value, StringComparison.Ordinal);
	}

	public int CompareTo(string other)
	{
		if (ReferenceEquals(Value, other)) return 0;
		if (other is null) return 1;
		return string.Compare(Value, other, StringComparison.Ordinal);
	}
}