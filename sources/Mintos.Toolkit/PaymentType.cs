namespace DustInTheWind.Mintos.Toolkit;

public sealed record class PaymentType
{
    public static readonly PaymentType CashOutShareIncomeToSeller = new("Cash out share income to seller");
    public static readonly PaymentType TransitRebuyDelayedInterest = new("Delayed interest income on transit rebuy");
    public static readonly PaymentType Deposits = new("Deposits");
    public static readonly PaymentType Interest = new("Interest received");
    public static readonly PaymentType LoanRepurchaseInterest = new("Interest received from loan repurchase");
    public static readonly PaymentType PendingPaymentsInterest = new("Interest received from pending payments");
    public static readonly PaymentType Investment = new("Investment");
    public static readonly PaymentType LateFee = new("Late fees received");
    public static readonly PaymentType MintosCoreFee = new("Mintos Core fee");
    public static readonly PaymentType MintosCustomLoansFee = new("Mintos Custom Loans fee");
    public static readonly PaymentType Principal = new("Principal received");
    public static readonly PaymentType LoanRepurchasePrincipal = new("Principal received from loan repurchase");
    public static readonly PaymentType SecondaryMarketTransaction = new("Secondary market transaction");
    public static readonly PaymentType TaxWithholding = new("Tax withholding");

    private static readonly Dictionary<string, PaymentType> KnownValues = new(StringComparer.OrdinalIgnoreCase)
    {
        [CashOutShareIncomeToSeller.Value] = CashOutShareIncomeToSeller,
        [TransitRebuyDelayedInterest.Value] = TransitRebuyDelayedInterest,
        [Deposits.Value] = Deposits,
        [Interest.Value] = Interest,
        [LoanRepurchaseInterest.Value] = LoanRepurchaseInterest,
        [PendingPaymentsInterest.Value] = PendingPaymentsInterest,
        [Investment.Value] = Investment,
        [LateFee.Value] = LateFee,
        [MintosCoreFee.Value] = MintosCoreFee,
        [MintosCustomLoansFee.Value] = MintosCustomLoansFee,
        [Principal.Value] = Principal,
        [LoanRepurchasePrincipal.Value] = LoanRepurchasePrincipal,
        [SecondaryMarketTransaction.Value] = SecondaryMarketTransaction,
        [TaxWithholding.Value] = TaxWithholding
    };

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
}


