namespace DustInTheWind.Mintos.Toolkit;

public class HeaderAlreadyLoadedException : DocumentLoadException
{
	public HeaderAlreadyLoadedException()
		: base("Header row was already read.")
	{
	}
}