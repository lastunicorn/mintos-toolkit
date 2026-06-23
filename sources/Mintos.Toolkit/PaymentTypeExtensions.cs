namespace DustInTheWind.Mintos.Toolkit;

public static class PaymentTypeExtensions
{
	/// <summary>
	/// In the mintos statements page, there is an overview section that shows the total amount of each payment type.
	/// The labels used in that section are different from the values of <see cref="PaymentType"/>.
	/// This method returns the label used in the overview section for a given <see cref="PaymentType"/>.
	/// This list of labels known by ths method is not exhaustive. For an unknown <see cref="PaymentType"/>, the
	/// underlying string representation of the <see cref="PaymentType"/> is returned.   
	/// </summary>
	public static string GetLabel(this PaymentType paymentType)
	{
		return PaymentTypeLabels.GetLabelFor(paymentType);
	}
}