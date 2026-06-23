namespace DustInTheWind.Mintos.Toolkit;

public class StatementLoadOptions
{
	public string FilePattern { get; set; }

	public bool Recursive { get; set; } = true;

	public Predicate<string> FilePathFilter { get; set; }
}