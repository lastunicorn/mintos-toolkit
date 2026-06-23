namespace DustInTheWind.Mintos.Toolkit;

public static class PaymentTypeLabels
{
	/// <summary>
	/// This dictionary contains the labels used in the overview section of the mintos statements page
	/// for each <see cref="PaymentType"/>.
	/// Some of the payment types are displayed under the same label, so there is no error when you will
	/// see the same label returned by more than one payment type.
	/// </summary>
	public static readonly Dictionary<PaymentType, string> LabelsByPaymentType = new()
	{
		[PaymentType.BondInterestIncome] = "Interest received - Bonds",
		[PaymentType.BondTaxWithholding] = "Tax withholding - Bonds",
		[PaymentType.Deposits] = "Deposits",
		[PaymentType.Investment] = "Investment",
		[PaymentType.PrincipalReceived] = "Principal received",
		[PaymentType.InterestReceived] = "Interest received",
		[PaymentType.LateFeesReceived] = "Late fees received",
		[PaymentType.SecondaryMarketTransaction] = "Secondary market transaction",
		[PaymentType.PrincipalReceivedFromLoanRepurchase] = "Principal received from loan repurchase",
		[PaymentType.InterestReceivedFromLoanRepurchase] = "Interest received from loan repurchase",
		[PaymentType.DelayedInterestIncomeOnTransitRebuy] = "Interest received from loan repurchase",
		[PaymentType.InterestReceivedFromPendingPayments] = "Interest earned on overdue payments",
		[PaymentType.TaxWithholding] = "Withholding tax",
		[PaymentType.CashOutShareIncomeToSeller] = "Notes cashout from Mintos strategies",
		[PaymentType.MintosCoreFee] = "Loan Portfolios fee",
		[PaymentType.MintosCustomLoansFee] = "Loan Portfolios fee",
	};
	
	/// <summary>
	/// In the mintos statements page, there is an overview section that shows the total amount of each payment type.
	/// The labels used in that section are different from the values of <see cref="PaymentType"/>.
	/// This method returns the label used in the overview section for a given <see cref="PaymentType"/>.
	/// This list of labels known by ths method is not exhaustive. For an unknown <see cref="PaymentType"/>, the
	/// underlying string representation of the <see cref="PaymentType"/> is returned.   
	/// </summary>
	public static string GetLabelFor(PaymentType paymentType)
	{
		return LabelsByPaymentType.TryGetValue(paymentType, out string label)
			? label
			: paymentType;
	}
}